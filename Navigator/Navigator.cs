﻿using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading.Tasks;
using static SuperNavigator.ProcessAsyncHelper;

namespace SuperNavigator
{
    public class Navigator
    {
        public FileWorker FileWorker;
        public Key Key;
        public Navigator(string appDir)
        {
            FileWorker = new FileWorker(appDir);
            Key = new Key(FileWorker);
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

            var result = await ProcessAsyncHelper.ExecuteShellCommand(command, args);

            return (int)result.ExitCode;
        }

        /// <summary>
        /// Модифицирует файлы рабочей директории, моделируя цели и свое судно на seconds времени вперед
        /// Свое судно движется по ongoing маневру
        /// </summary>
        /// <param name="seconds">Время</param>
        /// <param name="prefer">Предпочитаемый алгоритм при наличии двух решений в maneuver файле</param>
        /// <returns>false, если маневр закончится через seconds</returns>
        public bool FollowOngoing(double seconds)
        {
            var jPath = JObject.Parse(File.ReadAllText(FileWorker.WorkingDirectory + "\\" + FileWorker.maneuver_json));
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
        /// <param name="prefer">Предпочитаемый алгоритм</param>
        public void WriteOngoing(AlgorithmPrefer prefer)
        {
            string maneuver_file = FileWorker.WorkingDirectory + "\\" + FileWorker.maneuver_json;
            string ongoing_file = FileWorker.WorkingDirectory + "\\" + FileWorker.ongoing_json;
            var pathObj = FileWorker.GetManuever(prefer);
            File.WriteAllText(ongoing_file, pathObj.ToString());
        }

        /// <summary>
        /// Следовать по построенному маршруту до тех пор, пока он остается актуальным
        /// Маневр при запуске перестроится автоматически
        /// </summary>
        /// <param name="time_step">Шаг по времени, секунды</param>
        /// <param name="prefer">Предпочитаемый алгоритм</param>
        public async Task<string> Simulate(double time_step, AlgorithmPrefer prefer)
        {
            FileWorker.ClearOngoing();
            string nl = System.Environment.NewLine;
            string result = "";
            double time = 0;

            bool success = false;
            bool followingRoute = true;
            while (true)
            {
                await Analyze();
                var dangerous = GetAnalyzeReportDangerous();
                result += nl + "Danger at t = " + time.ToString() + ": " + (dangerous ? "DANGER" : "SAFE");
                if (dangerous) followingRoute = false;
                if (followingRoute)
                {
                    result += nl + "following route...";
                    var follow_result = FollowRoute(time_step);
                    if (!follow_result)
                    {
                        result += nl + "end of route reached!";
                        success = true;
                        break;
                    }
                }
                else // following ongoing
                {
                    if (File.Exists(FileWorker.WorkingDirectory + "\\" + FileWorker.ongoing_json))
                    {
                        result += nl + "following ongoing...";
                        var follow_result = FollowOngoing(time_step);
                        if (!follow_result)
                        {
                            result += nl + "end of ongoing reached!";
                            success = true;
                            break;
                        }
                    }
                    else
                    {
                        result += nl + "no ongoing found: try to build new maneuver";
                        if (await Maneuver() != 2)
                        {
                            result += nl + "maneuver found!";
                            WriteOngoing(prefer);
                            result += nl + "following ongoing (found)...";
                            var follow_result = FollowOngoing(time_step);
                            if (!follow_result)
                            {
                                result += nl + "end of ongoing reached!";
                                success = true;
                                break;
                            }
                        }
                        else 
                        {
                            result += nl + "failed to find maneuver!";
                            success = false;
                            break;
                        }
                    }
                }
                time += time_step;
            }
            result += nl + (success ? "SUCCESS" : "FAIL");

            return result;
        }

        /// <summary>
        /// Генерирует файл с реальными маневрами целей линейно экстраполируя текущие параметры движения
        /// </summary>
        /// <returns>ExitCode</returns>
        public async Task<int> CreateLinearTargetsManeuvers()
        {
            string command = FileWorker.UsvDirectory + "\\USV.exe";

            string args = Key.Predict + Key.Noprediction + Key.Data;

            var result = await ProcessAsyncHelper.ExecuteShellCommand(command, args);

            return (int)result.ExitCode;
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

        private void updateGoalsLinearly(double seconds)
        {
            string goals_file = FileWorker.WorkingDirectory + "\\" + FileWorker.targets_json;
            var objArr = JArray.Parse(File.ReadAllText(goals_file));
            foreach (var item in objArr)
            {
                var pos = new Position
                {
                    speed = item["SOG"].Value<double>() / 3600,
                    course = item["COG"].Value<double>(),
                    lat = item["lat"].Value<double>(),
                    lon = item["lon"].Value<double>()
                };
                var newPos = Helpers.ExtrapolatePosition(pos, seconds);

                item["lat"] = newPos.lat;
                item["lon"] = newPos.lon;
                item["SOG"] = newPos.speed * 3600;
                item["COG"] = newPos.course;
                item["timestamp"] = item["timestamp"].Value<long>() + (long)seconds;
            }
            File.WriteAllText(goals_file, objArr.ToString());
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
    public enum AlgorithmPrefer
    {
        PreferBase,
        PreferRVO
    }
}
