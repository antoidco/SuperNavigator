using Newtonsoft.Json.Linq;
using SuperNavigator.Visuals;
using System;
using System.Collections.Generic;
using System.IO;

namespace SuperNavigator.Simulator
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
        public const string predict_real_json = "real-target-maneuvers.json";
        public const string ongoing_json = "ongoing.json";


        const string _backup = "_backup";
        const string _init = "_init";
        private bool _workStarted;
        private string _workInitPath;

        /// <summary>
        /// Директория запускаемого приложения
        /// </summary>
        public string AppDirectory { get; }
        /// <summary>
        /// Директория с исходными данными для проекта
        /// </summary>
        public string WorkInitPath
        {
            get => _workInitPath;
            set { _workInitPath = value; _workStarted = false; }
        }
        /// <summary>
        /// Рабочая директория навигатора (с результатами расчета)
        /// </summary>
        public string WorkingDirectory { get; private set; }
        /// <summary>
        /// Путь к визуализатору KTViz: https://github.com/Dostoyewski/KTViz
        /// </summary>
        public string KtVizDirectory { get; set; }
        /// <summary>
        /// Путь к USV.exe: https://github.com/mangoozt/BKS/
        /// </summary>
        public string UsvDirectory { get; set; }
        public List<string> BackupFiles { get; }

        public bool WorkStarted => _workStarted;
       

        public FileWorker(string appDir)
        {
            AppDirectory = appDir;
            BackupFiles = new List<string> { targets_json, nav_data_json };
        }

        public void Start()
        {
            if (_workStarted) return;
            try
            {
                WorkingDirectory = WorkInitPath + $"\\{System.DateTime.Now.ToString("yyyy_dd_M_HH_mm_ss")}";
                System.IO.Directory.CreateDirectory(WorkingDirectory);
                File.Copy($"{WorkInitPath}\\{nav_data_json}", $"{WorkingDirectory}\\{nav_data_json}");
                File.Copy($"{WorkInitPath}\\{targets_json}", $"{WorkingDirectory}\\{targets_json}");
                File.Copy($"{WorkInitPath}\\{hydrometeo_json}", $"{WorkingDirectory}\\{hydrometeo_json}");
                File.Copy($"{WorkInitPath}\\{route_json}", $"{WorkingDirectory}\\{route_json}");
                File.Copy($"{WorkInitPath}\\{settings_json}", $"{WorkingDirectory}\\{settings_json}");
                File.Copy($"{WorkInitPath}\\{constraints_json}", $"{WorkingDirectory}\\{constraints_json}");
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException("Not enough data in initial working directory: " + e.Message);
            }
            _workStarted = true;
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

        public Path GetManeuver(AlgorithmPrefer prefer)
        {
            return Path.ReadFromJson(GetManuever(prefer));
        }

        /// <summary>
        /// Получить маневр (Path) из файла построенных решений-маневров рабочей директории
        /// </summary>
        /// <param name="prefer">Предпочитаемый маневр по типу решателя</param>
        /// <returns>(JObject) Маневр как Path</returns>
        public JObject GetManuever(AlgorithmPrefer prefer)
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

        /// <summary>
        /// Получить маршрут (Path) из файла машрута рабочей директории
        /// </summary>
        /// <returns>Маршрут как Path</returns>
        public Path GetRoute()
        {
            return Path.ReadFromJson(JObject.Parse(File.ReadAllText(WorkingDirectory + "\\" + FileWorker.route_json)));
        }

        /// <summary>
        /// Удалить файл акутального маневра, если он существует
        /// </summary>
        public void ClearOngoing()
        {
            if (File.Exists(WorkingDirectory + "\\" + ongoing_json))
            {
                File.Delete(WorkingDirectory + "\\" + ongoing_json);
            }
        }

        /// <summary>
        /// Сохранить результаты рассчитанного маневра в новую папку внутри рабочей директории
        /// Их можно открыть в KTViz, или скриптом сгенерировать изображение ситуации
        /// </summary>
        /// <param name="result">Результат для визуализации</param>
        public void SaveManuever(ref Result result)
        {
            string saveDirectory = $"{WorkInitPath}\\{result.ManeuverPathes.Count.ToString()}";
            System.IO.Directory.CreateDirectory(saveDirectory);
            // copy data
            File.Copy($"{WorkingDirectory}\\{nav_data_json}", $"{saveDirectory}\\{nav_data_json}");
            File.Copy($"{WorkingDirectory}\\{targets_json}", $"{saveDirectory}\\{targets_json}");
            File.Copy($"{WorkingDirectory}\\{hydrometeo_json}", $"{saveDirectory}\\{hydrometeo_json}");
            File.Copy($"{WorkingDirectory}\\{route_json}", $"{saveDirectory}\\{route_json}");
            File.Copy($"{WorkingDirectory}\\{settings_json}", $"{saveDirectory}\\{settings_json}");
            File.Copy($"{WorkingDirectory}\\{constraints_json}", $"{saveDirectory}\\{constraints_json}");
            // copy results
            File.Copy($"{WorkingDirectory}\\{maneuver_json}", $"{saveDirectory}\\{maneuver_json}");
            File.Copy($"{WorkingDirectory}\\{predict_json}", $"{saveDirectory}\\{predict_json}");
            File.Copy($"{WorkingDirectory}\\{predict_real_json}", $"{saveDirectory}\\{predict_real_json}");
            result.ManeuverPathes.Add(saveDirectory);
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
    }
}
