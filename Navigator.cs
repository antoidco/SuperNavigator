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

            string args = $"--targets {_workingDirrectory}\\{targets_json} --settings {_workingDirrectory}\\{settings_json} --nav-data {_workingDirrectory}\\{nav_data_json} --hydrometeo {_workingDirrectory}\\{hydrometeo_json} --constraints {_workingDirrectory}\\{constraints_json} --route {_workingDirrectory}\\{route_json} --analyse {_workingDirrectory}\\{analyse_json}.json";

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
    }
}
