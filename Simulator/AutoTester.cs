using SuperNavigator.Visuals;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNavigator.Simulator
{

    public static class AutoTester
    {
        public static async Task<string> RunAsync(Navigator navigator, string folder, double time_step, bool use_target_settings, IProgress<string> progress)
        {
            StreamWriter logfile;
            try
            {
                var logrile_path = System.IO.Path.Combine(folder, $"AutoTest_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.log");
                logfile = File.AppendText(logrile_path);
            }
            catch (Exception e)
            {
                progress.Report("Cannot save to logfile: " + e);
                logfile = null;
            };

            var logger_report = new Progress<string>(update =>
            {
                progress?.Report(update);
                logfile?.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss: ") + update);
                logfile.Flush();
            });
            IProgress<string> logger = logger_report;
            logger.Report("AUTOTEST Started");

            var report = new Report();
            string output = "";
            var dirs = Directory.GetDirectories(folder);
            int successCount = 0;
            foreach (var dir in dirs)
            {
                if (!File.Exists($"{dir}\\{FileWorker.nav_data_json}")) continue;
                string FolderName = new DirectoryInfo(dir).Name;
                logger.Report($"{Environment.NewLine}Scenario {FolderName}");
                navigator.FileWorker.WorkInitPath = dir;
                var working_directory = navigator.FileWorker.Start(use_target_settings);
                logger.Report($"Working directory: '{working_directory}'{Environment.NewLine}");

                var result = await navigator.SimulateAsync(time_step, logger_report);
                if (result.Success) successCount++;
                report.AddResult(FolderName, result.Success);
                navigator.FileWorker.Stop();
            }
            logger.Report($"{Environment.NewLine}{Environment.NewLine}Succeded {successCount} times");
            logger.Report($"{Environment.NewLine}{report}");
            return output;
        }
    }
}
