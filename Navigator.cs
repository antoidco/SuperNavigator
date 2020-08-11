using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuperNavigator.ProcessAsyncHelper;

namespace SuperNavigator
{
    public class Navigator
    {
        public FileWorker FileWorker;
        public Navigator(string appDir)
        {
            FileWorker = new FileWorker(appDir);
        }

        /// <summary>
        /// Запуск модуля оценки анализа обстановки для текущих данных, заданных в рабочей директории
        /// </summary>
        /// <returns>Информация о процессе</returns>
        public async Task<ProcessResult> Analyze()
        {
            string command = FileWorker.UsvDirectory + "\\USV.exe";

            string args = $"--targets {FileWorker.WorkingDirectory}\\{FileWorker.targets_json} --settings {FileWorker.WorkingDirectory}\\{FileWorker.settings_json} --nav-data {FileWorker.WorkingDirectory}\\{FileWorker.nav_data_json} --hydrometeo {FileWorker.WorkingDirectory}\\{FileWorker.hydrometeo_json} --constraints {FileWorker.WorkingDirectory}\\{FileWorker.constraints_json} --route {FileWorker.WorkingDirectory}\\{FileWorker.route_json} --analyse {FileWorker.WorkingDirectory}\\{FileWorker.analyse_json}";

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

            string args = $"--maneuver {FileWorker.WorkingDirectory}\\{FileWorker.maneuver_json} --predict {FileWorker.WorkingDirectory}\\{FileWorker.predict_json} --targets {FileWorker.WorkingDirectory}\\{FileWorker.targets_json} --settings {FileWorker.WorkingDirectory}\\{FileWorker.settings_json} --nav-data {FileWorker.WorkingDirectory}\\{FileWorker.nav_data_json} --hydrometeo {FileWorker.WorkingDirectory}\\{FileWorker.hydrometeo_json} --constraints {FileWorker.WorkingDirectory}\\{FileWorker.constraints_json} --route {FileWorker.WorkingDirectory}\\{FileWorker.route_json} --analyse {FileWorker.WorkingDirectory}\\{FileWorker.analyse_json}.json";

            var result = await ProcessAsyncHelper.ExecuteShellCommand(command, args);

            return (int)result.ExitCode;
        }

        /// <summary>
        /// Запускает проверку актуальности ongoing маневра по файлам рабочей директории
        /// </summary>
        /// <returns>Код возврата</returns>
        public async Task<int> Actual()
        {
            string command = FileWorker.UsvDirectory + "\\USV.exe";

            string args = $"--ongoing {FileWorker.WorkingDirectory}\\{FileWorker.ongoing_json} --predict {FileWorker.WorkingDirectory}\\{FileWorker.predict_json} --targets {FileWorker.WorkingDirectory}\\{FileWorker.targets_json} --settings {FileWorker.WorkingDirectory}\\{FileWorker.settings_json} --nav-data {FileWorker.WorkingDirectory}\\{FileWorker.nav_data_json} --hydrometeo {FileWorker.WorkingDirectory}\\{FileWorker.hydrometeo_json} --constraints {FileWorker.WorkingDirectory}\\{FileWorker.constraints_json} --route {FileWorker.WorkingDirectory}\\{FileWorker.route_json} --analyse {FileWorker.WorkingDirectory}\\{FileWorker.analyse_json}.json";

            var result = await ProcessAsyncHelper.ExecuteShellCommand(command, args);

            return (int)result.ExitCode;
        }

        /// <summary>
        /// Модифицирует файлы рабочей директории, моделируя цели и свое судно на seconds времени вперед
        /// Создает ongoing маневр согласно выбранной траектории
        /// </summary>
        /// <param name="seconds">Время</param>
        /// <param name="prefer">Предпочитаемый алгоритм при наличии двух решений в maneuver файле</param>
        public void FollowManeuver(double seconds, AlgorithmPrefer prefer)
        {
            var path = FileWorker.ReadPath(prefer);

            // update ship
            updateShip(path, seconds);

            // update goals (linearly)
            updateGoalsLinearly(seconds);

            // write ongoing maneuver
            WriteOngoing(prefer);
        }

        public void WriteOngoing(AlgorithmPrefer prefer)
        {
            string maneuver_file = FileWorker.WorkingDirectory + "\\" + FileWorker.maneuver_json;
            string ongoing_file = FileWorker.WorkingDirectory + "\\" + FileWorker.ongoing_json;
            var pathObj = FileWorker.ReadPathJson(prefer);
            File.WriteAllText(ongoing_file, pathObj.ToString());
        }

        private void updateShip(Path path, double seconds)
        {
            var newShipPosition = path.position(path.start_time + seconds);
            string ship_file = FileWorker.WorkingDirectory + "\\" + FileWorker.nav_data_json;
            var obj = JObject.Parse(File.ReadAllText(ship_file));
            obj["lat"] = newShipPosition.lat;
            obj["lon"] = newShipPosition.lon;
            obj["SOG"] = newShipPosition.speed * 3600;
            obj["STW"] = newShipPosition.speed * 3600;
            obj["COG"] = newShipPosition.course;
            obj["heading"] = newShipPosition.course;
            obj["timestamp"] = obj["timestamp"].Value<long>() + (long)seconds;
            File.WriteAllText(ship_file, obj.ToString());
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
