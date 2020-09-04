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
        public static async Task<string> RunAsync(Navigator navigator, string folder, double time_step, bool use_target_settings)
        {
            var report = new Report();
            string output = "";
            var dirs = Directory.GetDirectories(folder);
            int successCount = 0;
            foreach (var dir in dirs)
            {
                if (!File.Exists($"{dir}\\{FileWorker.nav_data_json}")) continue;
                string FolderName = new DirectoryInfo(dir).Name;
                navigator.FileWorker.WorkInitPath = dir;
                navigator.FileWorker.Start(use_target_settings);
                var result = await navigator.Simulate(time_step);
                output += $"{Environment.NewLine}Scenario {FolderName}";
                output += result.Output;
                if (result.Success) successCount++;
                report.AddResult(FolderName, result.Success);
                navigator.FileWorker.Stop();
            }
            output += $"{Environment.NewLine}{Environment.NewLine}Succeded {successCount} times";
            output += $"{Environment.NewLine}{report.ToString()}";
            return output;
        }
    }
}
