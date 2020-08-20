using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNavigator.Simulator
{
    /// <summary>
    /// Состояние симулятора для визуализации
    /// </summary>
    public class State : List<Position> {
        public double Time { get; set; }
    }
}
