using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
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
        /// <summary>
        /// Вычисляет позицию на path в момент времени time
        /// </summary>
        /// <param name="time">Время</param>
        /// <returns>Позиция на path</returns>
        public Position position(double time)
        {
            time -= this.start_time;
            if (time >= 0) {
                foreach (var item in this.items) {
                    if (time < item.duration)
                        return item.position(time);
                    time -= item.duration;
                }
            }
            return new Position { lat = 0, lon = 0, course = 0, speed = -1 };
        }
        public bool IsEnding(double in_time)
        {
            return position(in_time).speed < 0;
        }
    }
}
