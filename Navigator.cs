using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading.Tasks;
using static SuperNavigator.ProcessAsyncHelper;

namespace SuperNavigator
{
    public class Navigator
    {
        public FileWorker FileWorker;
        public string AppDirectory { get => FileWorker.AppDirectory; }
        public string WorkingDirectory => FileWorker.WorkingDirectory;
        public string KtVizDirectory => FileWorker.KtVizDirectory;
        public string UsvDirectory => FileWorker.UsvDirectory;

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
            string command = UsvDirectory + "\\USV.exe";

            string args = $"--targets {WorkingDirectory}\\{FileWorker.targets_json} --settings {FileWorker.WorkingDirectory}\\{FileWorker.settings_json} --nav-data {WorkingDirectory}\\{FileWorker.nav_data_json} --hydrometeo {WorkingDirectory}\\{FileWorker.hydrometeo_json} --constraints {WorkingDirectory}\\{FileWorker.constraints_json} --route {WorkingDirectory}\\{FileWorker.route_json} --analyse {WorkingDirectory}\\{FileWorker.analyse_json}";

            return await ProcessAsyncHelper.ExecuteShellCommand(command, args);
        }

        /// <summary>
        /// По файлу анализа обстановки определяет, опасна ли ситуация
        /// </summary>
        /// <returns>true, если опасна</returns>
        public bool GetAnalyzeReportDangerous()
        {
            var obj = JObject.Parse(File.ReadAllText(WorkingDirectory + "\\" + FileWorker.analyse_json));
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
            string command = UsvDirectory + "\\USV.exe";

            string args = $"--maneuver {WorkingDirectory}\\{FileWorker.maneuver_json} --predict {WorkingDirectory}\\{FileWorker.predict_json} --targets {WorkingDirectory}\\{FileWorker.targets_json} --settings {WorkingDirectory}\\{FileWorker.settings_json} --nav-data {WorkingDirectory}\\{FileWorker.nav_data_json} --hydrometeo {WorkingDirectory}\\{FileWorker.hydrometeo_json} --constraints {WorkingDirectory}\\{FileWorker.constraints_json} --route {WorkingDirectory}\\{FileWorker.route_json} --analyse {WorkingDirectory}\\{FileWorker.analyse_json}.json";

            var result = await ProcessAsyncHelper.ExecuteShellCommand(command, args);

            return (int)result.ExitCode;
        }

        /// <summary>
        /// Запускает проверку актуальности ongoing маневра по файлам рабочей директории
        /// </summary>
        /// <returns>Код возврата</returns>
        public async Task<int> Actual()
        {
            string command = UsvDirectory + "\\USV.exe";

            string args = $"--ongoing {WorkingDirectory}\\{FileWorker.ongoing_json} --targets {WorkingDirectory}\\{FileWorker.targets_json} --settings {WorkingDirectory}\\{FileWorker.settings_json} --nav-data {WorkingDirectory}\\{FileWorker.nav_data_json} --hydrometeo {WorkingDirectory}\\{FileWorker.hydrometeo_json} --constraints {WorkingDirectory}\\{FileWorker.constraints_json} --route {WorkingDirectory}\\{FileWorker.route_json} --analyse {WorkingDirectory}\\{FileWorker.analyse_json}.json";

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
