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
            progress?.Report($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: AUTOTEST Started");
            var report = new Report();
            string output = "";
            var dirs = Directory.GetDirectories(folder);
            int successCount = 0;
            foreach (var dir in dirs)
            {
                if (!File.Exists($"{dir}\\{FileWorker.nav_data_json}")) continue;
                string FolderName = new DirectoryInfo(dir).Name;
                progress?.Report($"{Environment.NewLine}Scenario {FolderName}");
                navigator.FileWorker.WorkInitPath = dir;
                var working_directory = navigator.FileWorker.Start(use_target_settings);
                progress?.Report($"Working directory: '{working_directory}'{Environment.NewLine}");

                var result = await navigator.SimulateAsync(time_step, progress);
                if (result.Success) successCount++;
                report.AddResult(FolderName, result.Success);
                navigator.FileWorker.Stop();
            }
            progress?.Report($"{Environment.NewLine}{Environment.NewLine}Succeded {successCount} times");
            progress?.Report($"{Environment.NewLine}{report}");
            return output;
        }
    }
}
