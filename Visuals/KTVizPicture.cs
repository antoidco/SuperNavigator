using SuperNavigator.Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNavigator.Visuals
{
    public class KTVizPicture
    {
        private string _picGenerationPy;
        private string _maneuverFileName;
        public KTVizPicture(string picGenerationPy, string maneuverFileName)
        {
            _picGenerationPy = picGenerationPy;
            _maneuverFileName = maneuverFileName;
        }
        public async Task CreateOne(string maneuverPath)
        {
            string command = "python";
            string args = $"\"{_picGenerationPy}\" \"{maneuverPath}\\{_maneuverFileName}\" \"{maneuverPath}\\{_picGenerationPy}\"";
            await ProcessAsyncHelper.ExecuteShellCommand(command, args, true);
        }
        /// <summary>
        /// Создает набор png файлов, соответствующий набору выполненных маневров
        /// генерируется с помощью скрипта для KTViz
        /// </summary>
        public async Task CreatePictures(Result result)
        {
            foreach (var path in result.ManeuverPathes)
            {
                await CreateOne(path);
            }
        }
    }
}
