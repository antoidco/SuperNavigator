using System;
using System.Collections.Generic;

namespace SuperNavigator.Simulator
{
    public class Report
    {
        public List<Tuple<string, bool>> Results { get; set; } = new List<Tuple<string, bool>>();
        public void AddResult(string name, bool success)
        {
            Results.Add(new Tuple<string, bool>(name, success));
        }
        public override string ToString()
        {
            string result = "";
            foreach (var tuple in Results)
            {
                result += $"{Environment.NewLine}{tuple.Item1}:";
                result += "\t";
                result += tuple.Item2 ? "Success" : "Failed";
            }
            return result;
        }
    }
}
