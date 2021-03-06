﻿
namespace SuperNavigator.Simulator
{
    public class Key
    {
        private const string analyseKey = "--analyse ";
        private const string predictKey = "--predict ";
        private const string maneuverKey = "--maneuver ";
        private const string hmiKey = "--hydrometeo ";
        private const string targetsKey = "--targets ";
        private const string settingsKey = "--settings ";
        private const string navdataKey = "--nav-data ";
        private const string constraintsKey = "--constraints ";
        private const string routeKey = "--route ";
        private const string ongoingKey = "--ongoing ";
        private const string nopredictionKey = "--no-prediction ";
        private const string fullPredictionKey = "--full-prediction ";
        private const string forceRvoKey = "--rvo ";
        private const string targetSettingsKey = "--target-settings ";

        private readonly FileWorker _fw;
        public Key(FileWorker fileWorker)
        {
            _fw = fileWorker;
        }
        public string Analyse => $"{analyseKey}\"{_fw.WorkingDirectory}\\{FileWorker.analyse_json}\" ";
        public string Predict => $"{predictKey}\"{_fw.WorkingDirectory}\\{FileWorker.predict_json}\" ";
        public string PredictReal => $"{predictKey}\"{_fw.WorkingDirectory}\\{FileWorker.predict_real_json}\" ";
        public string Manuever => $"{maneuverKey}\"{_fw.WorkingDirectory}\\{FileWorker.maneuver_json}\" ";
        public string Hmi => $"{hmiKey}\"{_fw.WorkingDirectory}\\{FileWorker.hydrometeo_json}\" ";
        public string Targets => $"{targetsKey}\"{_fw.WorkingDirectory}\\{FileWorker.targets_json}\" ";
        public string Settings => $"{settingsKey}\"{_fw.WorkingDirectory}\\{FileWorker.settings_json}\" ";
        public string Navdata => $"{navdataKey}\"{_fw.WorkingDirectory}\\{FileWorker.nav_data_json}\" ";
        public string Constraints => $"{constraintsKey}\"{_fw.WorkingDirectory}\\{FileWorker.constraints_json}\" ";
        public string Route => $"{routeKey}\"{_fw.WorkingDirectory}\\{FileWorker.route_json}\" ";
        public string Ongoing => $"{ongoingKey}\"{_fw.WorkingDirectory}\\{FileWorker.ongoing_json}\" ";
        public string OngoingRoute => $"{ongoingKey}\"{_fw.WorkingDirectory}\\{FileWorker.route_json}\" ";
        public string TargetSettings => _fw.Target_settings ? $"{targetSettingsKey}\"{_fw.WorkingDirectory}\\{FileWorker.target_settings_json}\" " : "";
        public string Noprediction => nopredictionKey;
        public string FullPrediction => fullPredictionKey;
        public string ForceRvo => forceRvoKey;

        public string Data => $"{Hmi}{Targets}{Settings}{Navdata}{Constraints}{Route}{TargetSettings}";
        public string ManeuverData => Manuever + Predict + Data;
        public string AnalyseData => Analyse + Data;
    }
}
