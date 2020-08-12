﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNavigator
{
    public class FileWorker
    {
        public const string analyse_json = "nav-report.json";
        public const string nav_data_json = "nav-data.json";
        public const string maneuver_json = "maneuver.json";
        public const string targets_json = "target-data.json";
        public const string constraints_json = "constraints.json";
        public const string hydrometeo_json = "hmi-data.json";
        public const string route_json = "route-data.json";
        public const string settings_json = "settings.json";
        public const string predict_json = "target-maneuvers.json";
        public const string ongoing_json = "ongoing.json";

        const string _backup = "_backup";
        const string _init = "_init";

        public string AppDirectory { get; }
        public string WorkingDirectory { get; set; }
        public string KtVizDirectory { get; set; }
        public string UsvDirectory { get; set; }
        public List<string> BackupFiles { get; }

        public FileWorker(string appDir)
        {
            AppDirectory = appDir;
            BackupFiles = new List<string> { targets_json, nav_data_json };
        }
        private void deleteBackup()
        {
            deletePostfix(_backup);
        }
        private void deleteInit()
        {
            deletePostfix(_init);
        }

        private void deletePostfix(string postfix)
        {
            foreach (var item in BackupFiles)
            {
                string filename = $"{WorkingDirectory}\\{item}" + postfix;
                if (File.Exists(filename)) File.Delete(filename);
            }
        }

        public void SaveFilesAsInit()
        {
            deleteInit();
            foreach (var item in BackupFiles)
            {
                string filename = $"{WorkingDirectory}\\{item}";
                if (File.Exists(filename))
                    File.Copy(filename, filename + _init);
            }
        }

        public void ReturnFilesToInit()
        {
            deleteBackup();
            foreach (var item in BackupFiles)
            {
                string filename = $"{WorkingDirectory}\\{item}";
                if (File.Exists(filename + _init) && File.Exists(filename)) 
                    File.Replace(filename + _init, filename, filename + _backup);
            }
        }

        public Path ReadPath(AlgorithmPrefer prefer)
        {
            return Path.ReadFromJson(ReadPathJson(prefer));
        }

        public JObject ReadPathJson(AlgorithmPrefer prefer)
        {
            var objArr = JArray.Parse(File.ReadAllText(WorkingDirectory + "\\" + FileWorker.maneuver_json));
            Path path = new Path();
            if (objArr.Count > 1)
            {
                foreach (var solution in objArr)
                {
                    if (Helpers.AlgorithmPreferToString(prefer) == solution["solver_name"].Value<string>())
                    {
                        return solution["path"].ToObject<JObject>();
                    }
                }
                return objArr[0]["path"].ToObject<JObject>();
            }
            else
            {
                return objArr[0]["path"].ToObject<JObject>();
            }
        }

        public Path ReadRoute()
        {
            return Path.ReadFromJson(JObject.Parse(File.ReadAllText(WorkingDirectory + "\\" + FileWorker.route_json)));
        }
    }
}
