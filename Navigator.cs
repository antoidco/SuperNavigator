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
        const string analyse_json = "nav-report.json";
        const string nav_data_json = "nav-data.json";
        const string maneuver_json = "maneuver.json";
        const string targets_json = "target-data.json";
        const string constraints_json = "constraints.json";
        const string hydrometeo_json = "hmi-data.json";
        const string route_json = "route-data.json";
        const string settings_json = "settings.json";
        const string predict_json = "target-maneuvers.json";
        const string ongoing_json = "ongoing.json";

        private string _appDirrectory;
        private string _workingDirrectory;
        private string _ktVizDirrectory;
        private string _usvDirrectory;

        public string AppDirrectory
        {
            get => _appDirrectory;
        }
        public string WorkingDirrectory
        {
            get => _workingDirrectory;
            set => _workingDirrectory = value;
        }
        public string KtVizDirrectory
        {
            get => _ktVizDirrectory;
            set => _ktVizDirrectory = value;
        }
        public string UsvDirrectory
        {
            get => _usvDirrectory;
            set => _usvDirrectory = value;
        }

        public Navigator(string appDirr)
        {
            _appDirrectory = appDirr;
        }

        public async Task<ProcessResult> Analyze()
        {
            string command = UsvDirrectory + "\\USV.exe";

            string args = $"--targets {_workingDirrectory}\\{targets_json} --settings {_workingDirrectory}\\{settings_json} --nav-data {_workingDirrectory}\\{nav_data_json} --hydrometeo {_workingDirrectory}\\{hydrometeo_json} --constraints {_workingDirrectory}\\{constraints_json} --route {_workingDirrectory}\\{route_json} --analyse {_workingDirrectory}\\{analyse_json}";

            return await ProcessAsyncHelper.ExecuteShellCommand(command, args);
        }

        public bool GetAnalyzeReportDangerous()
        {
            var obj = JObject.Parse(File.ReadAllText(_workingDirrectory + "\\" + analyse_json));
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

        public async Task<int> Maneuver()
        {
            string command = UsvDirrectory + "\\USV.exe";

            string args = $"--maneuver {_workingDirrectory}\\{maneuver_json} --predict {_workingDirrectory}\\{predict_json} --targets {_workingDirrectory}\\{targets_json} --settings {_workingDirrectory}\\{settings_json} --nav-data {_workingDirrectory}\\{nav_data_json} --hydrometeo {_workingDirrectory}\\{hydrometeo_json} --constraints {_workingDirrectory}\\{constraints_json} --route {_workingDirrectory}\\{route_json} --analyse {_workingDirrectory}\\{analyse_json}.json";

            var result = await ProcessAsyncHelper.ExecuteShellCommand(command, args);

            return (int)result.ExitCode;
        }

        public async Task<int> Actual()
        {
            string command = UsvDirrectory + "\\USV.exe";

            string args = $"--ongoing {_workingDirrectory}\\{ongoing_json} --targets {_workingDirrectory}\\{targets_json} --settings {_workingDirrectory}\\{settings_json} --nav-data {_workingDirrectory}\\{nav_data_json} --hydrometeo {_workingDirrectory}\\{hydrometeo_json} --constraints {_workingDirrectory}\\{constraints_json} --route {_workingDirrectory}\\{route_json} --analyse {_workingDirrectory}\\{analyse_json}.json";

            var result = await ProcessAsyncHelper.ExecuteShellCommand(command, args);

            return (int)result.ExitCode;
        }

        private void deleteBackup()
        {
            string targets_name = $"{_workingDirrectory}\\{targets_json}" + "_backup";
            string nav_data_name = $"{_workingDirrectory}\\{nav_data_json}" + "_backup";

            if (File.Exists(targets_name)) File.Delete(targets_name);
            if (File.Exists(nav_data_name)) File.Delete(nav_data_name);
        }

        private void deleteInit()
        {
            string targets_name = $"{_workingDirrectory}\\{targets_json}" + "_init";
            string nav_data_name = $"{_workingDirrectory}\\{nav_data_json}" + "_init";

            if (File.Exists(targets_name)) File.Delete(targets_name);
            if (File.Exists(nav_data_name)) File.Delete(nav_data_name);
        }

        public void SaveFilesAsInit()
        {
            string targets_name = $"{_workingDirrectory}\\{targets_json}";
            string nav_data_name = $"{_workingDirrectory}\\{nav_data_json}";

            deleteInit();
            File.Copy(targets_name, targets_name + "_init");
            File.Copy(nav_data_name, nav_data_name + "_init");
        }

        public void ReturnFilesToInit()
        {
            string targets_name = $"{_workingDirrectory}\\{targets_json}";
            string nav_data_name = $"{_workingDirrectory}\\{nav_data_json}";

            if (File.Exists(targets_name + "_init")
             && File.Exists(nav_data_name + "_init"))
            {
                deleteBackup();
                File.Replace(targets_name + "_init", targets_name, targets_name + "_backup");
                File.Replace(nav_data_name + "_init", nav_data_name, nav_data_name + "_backup");
            }
        }

        public void FollowManeuver(double seconds, AlgorithmPrefer prefer)
        {
            var objArr = JArray.Parse(File.ReadAllText(_workingDirrectory + "\\" + maneuver_json));
            Path path;
            if (objArr.Count > 1) {
                foreach (var solution in objArr)
                {
                    if ((solution["solver_name"].Value<string>() == "Main" && prefer == AlgorithmPrefer.PreferBase)
                     || (solution["solver_name"].Value<string>() == "RVO" && prefer == AlgorithmPrefer.PreferRVO))
                    {
                        path = Path.ReadFromJson(solution["path"].ToObject<JObject>());
                        break;
                    }
                }
            }
            else {
                path = Path.ReadFromJson(objArr[0]["path"].ToObject<JObject>());
            }
        }
    }
    public enum AlgorithmPrefer
    {
        PreferBase,
        PreferRVO
    }
}
