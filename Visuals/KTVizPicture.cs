using SuperNavigator.Simulator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace SuperNavigator.Visuals
{
    public class KTVizPicture
    {
        public List<Image> Images { get; set; }
        private string _picGenerationPy;
        private string _maneuverFileName;
        private const string pngName = "result.png";
        public KTVizPicture(string picGenerationPy, string maneuverFileName)
        {
            _picGenerationPy = picGenerationPy;
            _maneuverFileName = maneuverFileName;
            Images = new List<Image>();
        }
        public async Task<string> CreateOne(string maneuverPath)
        {
            if (!File.Exists($"{maneuverPath}\\{pngName}"))
            {
                string command = "python";
                string args = $"\"{_picGenerationPy}\" \"{maneuverPath}\" \"{maneuverPath}\\{_maneuverFileName}\" \"{maneuverPath}\\{pngName}\"";
                return (await ProcessAsyncHelper.ExecuteShellCommand(command, args, false)).Output;
            }
            return "";
        }
        /// <summary>
        /// Создает набор png файлов, соответствующий набору выполненных маневров
        /// генерируется с помощью скрипта для KTViz
        /// </summary>
        public async Task<string> CreatePictures(Result result)
        {
            string res = "";
            foreach (var path in result.ManeuverPathes)
            {
                res += System.Environment.NewLine + await CreateOne(path);
                try
                {
                    Images.Add(new Bitmap($"{path}\\{pngName}"));
                }
                catch (Exception e)
                {
                    res += System.Environment.NewLine + e.Message;
                }
            }
            return res;
        }
    }
}
