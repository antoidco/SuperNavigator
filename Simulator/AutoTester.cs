using SuperNavigator.Visuals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNavigator.Simulator
{
    public static class AutoTester
    {
        public static async Task<string> RunAsync(Navigator navigator, string folder, double time_step)
        {
            string output = "";
            var dirs = Directory.GetDirectories(folder);
            int successCount = 0;
            foreach (var dir in dirs)
            {
                navigator.FileWorker.WorkInitPath = dir;
                navigator.FileWorker.Start();
                var result = await navigator.Simulate(time_step);
                output += result.Output;
                if (result.Success) successCount++;
                navigator.FileWorker.Stop();
            }
            output += $"{Environment.NewLine}{Environment.NewLine}Succeded {successCount} times";
            return output;
        }
    }
}
