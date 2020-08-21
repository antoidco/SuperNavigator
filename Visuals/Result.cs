using SuperNavigator.Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNavigator.Visuals
{
    public class Result
    {
        public const string result_filename_png = "result.png";
        public string Output { get; set; }
        public List<string> ManeuverPathes { get; set; } = new List<string>();
    }
}
