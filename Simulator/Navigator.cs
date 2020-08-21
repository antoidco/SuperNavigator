﻿using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;
using static SuperNavigator.Simulator.ProcessAsyncHelper;

namespace SuperNavigator.Simulator
{
    public class Navigator
    {
        public FileWorker FileWorker;
        public Key Key;
        public Settings Settings;
        public Navigator(string appDir)
        {
            FileWorker = new FileWorker(appDir);
            Key = new Key(FileWorker);
            Settings = new Settings();
        }

        /// <summary>
        /// Запуск модуля оценки анализа обстановки для текущих данных, заданных в рабочей директории
        /// Если существует ongoing маневр - анализирует обстановку, учитывая его
        /// </summary>
        /// <returns>Информация о процессе</returns>
        public async Task<ProcessResult> Analyze()
        {
            string command = FileWorker.UsvDirectory + "\\USV.exe";

            string args = Key.AnalyseData;

            if (File.Exists(FileWorker.WorkingDirectory + "\\" + FileWorker.ongoing_json))
                args += Key.Ongoing;

            return await ProcessAsyncHelper.ExecuteShellCommand(command, args);
        }

        /// <summary>
        /// По файлу анализа обстановки определяет, опасна ли ситуация
        /// </summary>
        /// <returns>true, если опасна</returns>
        public bool GetAnalyzeReportDangerous()
        {
            var obj = JObject.Parse(File.ReadAllText(FileWorker.WorkingDirectory + "\\" + FileWorker.analyse_json));
            var statuses = obj["target_statuses"];

            foreach (var status in statuses)
            {
                if (status["danger_level"].Value<int>() == 2)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Запускает алгоритм построения маневра по файлам рабочей директории
        /// </summary>
        /// <returns>Код возврата</returns>
        public async Task<int> Maneuver()
        {
            string command = FileWorker.UsvDirectory + "\\USV.exe";

            string args = Key.ManeuverData;
            if (Settings.PredictionType == PredictionType.Linear) args += Key.Noprediction;

            if (File.Exists(FileWorker.WorkingDirectory + "\\" + FileWorker.ongoing_json))
                args += Key.Ongoing;
            else
                args += Key.OngoingRoute;

            var result = await ProcessAsyncHelper.ExecuteShellCommand(command, args);

            return (int)result.ExitCode;
        }

        /// <summary>
        /// Модифицирует файлы рабочей директории, моделируя цели и свое судно на seconds времени вперед
        /// Свое судно движется по ongoing маневру
        /// </summary>
        /// <param name="seconds">Время</param>
        /// <returns>false, если маневр закончится через seconds</returns>
        public bool FollowOngoing(double seconds)
        {
            var jPath = JObject.Parse(File.ReadAllText(FileWorker.WorkingDirectory + "\\" + FileWorker.ongoing_json));
            var path = Path.ReadFromJson(jPath);

            // update ship
            var ship_time = updateShip(path, seconds);

            // update goals (linearly)
            updateGoals(seconds);

            return !path.IsEnding(ship_time + seconds);
        }

        /// <summary>
        /// Модифицирует файлы рабочей директории, моделируя цели и свое судно на seconds времени вперед
        /// Свое судно движется по маршруту
        /// </summary>
        /// <param name="seconds">Время</param>
        /// <returns>false, если маршрут закончится через seconds</returns>
        public bool FollowRoute(double seconds)
        {
            var route = FileWorker.GetRoute();

            // update ship
            var ship_time = updateShip(route, seconds);

            // update goals (linearly)
            updateGoals(seconds);

            return !route.IsEnding(ship_time + seconds);
        }

        /// <summary>
        /// Создает ongoing файл с маневром согласно выбранной траектории
        /// </summary>
        public void WriteOngoing()
        {
            string maneuver_file = FileWorker.WorkingDirectory + "\\" + FileWorker.maneuver_json;
            string ongoing_file = FileWorker.WorkingDirectory + "\\" + FileWorker.ongoing_json;
            var pathObj = FileWorker.GetManuever(Settings.AlgorithmPrefer);
            File.WriteAllText(ongoing_file, pathObj.ToString());
        }
        /// <summary>
        /// Следовать ongoing, если он существует
        /// В ином случае следовать маршруту
        /// </summary>
        /// <param name="time_step">Шаг по времени, секунды</param>
        /// <returns>False, если маневр закончится через time_step</returns>
        public bool Follow(double time_step)
        {
            if (File.Exists(FileWorker.WorkingDirectory + "\\" + FileWorker.ongoing_json))
            {
                return FollowOngoing(time_step);
            }
            else
            {
                return FollowRoute(time_step);
            }
        }
        /// <summary>
        /// Запуск полного цикла моделирования сценария.
        /// При моделировании движения своего судна по маршруту/построенному маневру
        /// и движения целей по заданным траекториям выполняется анализ ситуации и
        /// принимается решение о будущих действиях своего судна.
        /// </summary>
        /// <param name="time_step">Шаг по времени, секунды</param>
        /// <returns>Строка с отчетом</returns>
        public async Task<string> Simulate(double time_step)
        {
            FileWorker.ClearOngoing();
            string nl = System.Environment.NewLine;
            string result = "";
            double time = 0;

            while (true)
            {
                await Analyze();
                var dangerous = GetAnalyzeReportDangerous();
                result += $"{nl}danger at t = {time} is: {dangerous}";
                if (dangerous)
                {
                    var maneuver_result = await Maneuver();
                    if (maneuver_result == 5)
                    {
                        result += $"{nl}ongoing maneuver/route is OK";
                    }
                    else if (maneuver_result != 2)
                    {
                        result += $"{nl}ongoing maneuver/route is not OK";
                        result += $"{nl}maneuver found!";
                        WriteOngoing();
                    }
                    else
                    {
                        result += $"{nl}ongoing maneuver/route is not OK";
                        result += $"{nl}maneuver not found!{nl}FAILED";
                        break;
                    }
                }
                result += $"{nl}following...";
                if (!Follow(time_step))
                {
                    result += $"{nl}finished{nl}SUCCESS";
                    break;
                }
                time += time_step;
            }

            return result;
        }

        /// <summary>
        /// Генерирует файл с реальными маневрами целей линейно экстраполируя текущие параметры движения
        /// </summary>
        /// <returns>ExitCode</returns>
        public async Task<int> CreateLinearTargetsManeuvers()
        {
            string command = FileWorker.UsvDirectory + "\\USV.exe";

            string args = Key.PredictReal + Key.Noprediction + Key.Data;

            var result = await ProcessAsyncHelper.ExecuteShellCommand(command, args);

            return (int)result.ExitCode;
        }

        /// <summary>
        /// Проверить, соответствует ли nav-data какой либо точке на route
        /// </summary>
        public bool OnRoute()
        {
            var path = FileWorker.GetRoute();
            string ship_file = FileWorker.WorkingDirectory + "\\" + FileWorker.nav_data_json;
            var obj = JObject.Parse(File.ReadAllText(ship_file));
            var lat = obj["lat"].Value<double>();
            var lon = obj["lon"].Value<double>();
            // not implemented:
            //return path.distance(new Vector2((float)lat, (float)lon));
            return true;
        }

        private double updateShip(Path path, double seconds)
        {
            string ship_file = FileWorker.WorkingDirectory + "\\" + FileWorker.nav_data_json;
            var obj = JObject.Parse(File.ReadAllText(ship_file));
            var newShipPosition = path.position(obj["timestamp"].Value<double>() + seconds);
            obj["lat"] = newShipPosition.lat;
            obj["lon"] = newShipPosition.lon;
            obj["SOG"] = newShipPosition.speed * 3600;
            obj["STW"] = newShipPosition.speed * 3600;
            obj["COG"] = newShipPosition.course;
            obj["heading"] = newShipPosition.course;
            obj["timestamp"] = obj["timestamp"].Value<long>() + (long)seconds;
            File.WriteAllText(ship_file, obj.ToString());

            return obj["timestamp"].Value<double>();
        }
        /// <summary>
        /// Обновить target-data на seconds вперед согласно заведомо заданным реальным траеториям целей
        /// </summary>
        /// <param name="seconds">Время</param>
        private void updateGoals(double seconds)
        {
            string goals_input_file = FileWorker.WorkingDirectory + "\\" + FileWorker.real_target_maneuvers_json;
            string goals_output_file = FileWorker.WorkingDirectory + "\\" + FileWorker.targets_json;

            var outputArr = JArray.Parse(File.ReadAllText(goals_output_file));
            var inputArr = JArray.Parse(File.ReadAllText(goals_input_file));
            for (int iObj = 0; iObj < inputArr.Count; ++iObj)
            {
                var inputObj = inputArr[iObj];
                var outputObj = outputArr[iObj];
                var goalPath = Path.ReadFromJson(inputObj.ToObject<JObject>());
                var timestamp = outputObj["timestamp"].Value<double>();
                var newShipPosition = goalPath.position(timestamp + seconds);
                outputObj["lat"] = newShipPosition.lat;
                outputObj["lon"] = newShipPosition.lon;
                outputObj["SOG"] = newShipPosition.speed * 3600;
                outputObj["STW"] = newShipPosition.speed * 3600;
                outputObj["COG"] = newShipPosition.course;
                outputObj["heading"] = newShipPosition.course;
                outputObj["timestamp"] = (long)(timestamp + seconds);
            }
            File.WriteAllText(goals_output_file, outputArr.ToString());
        }

        public void SaveFilesAsInit()
        {
            FileWorker.SaveFilesAsInit();
        }

        public void ReturnFilesToInit()
        {
            FileWorker.ReturnFilesToInit();
        }
    }
}