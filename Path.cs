using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace SuperNavigator
{
    public class Path
    {
        public List<Segment> items;
        public long start_time;

        public static Path ReadFromJson(JObject json)
        {
            var jsonText = json.ToString();
            var result = JsonConvert.DeserializeObject<Path>(jsonText);
            return result;
        }
        public JObject WriteToJson()
        {
            JObject result = JObject.Parse(JsonConvert.SerializeObject(this));
            return result;
        }
        public void WriteToFile(string filename)
        {
            var result = JsonConvert.SerializeObject(this);
            File.WriteAllText(filename, result);
        }
    }
}
