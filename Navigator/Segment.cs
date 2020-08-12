using GeographicLib;
using System;

namespace SuperNavigator
{
    public class Segment
    {
        public double port_dev;
        public double starboard_dev;
        public double duration;
        public double length;
        public double curve;
        public double begin_angle; // degrees
        public double lon;
        public double lat;

        /// <summary>
        /// Вычисляет позицию на сегменте в момент времени time
        /// </summary>
        /// <param name="time">Время</param>
        /// <returns>Позиция на сегменте</returns>
        public Position position(double time)
        {
            // converted from python
            // ...
            double speed = this.length / this.duration;
            double length = speed * time;

            if (this.curve == 0)
            {
                double dist = length;
                var direct = Geodesic.WGS84.Direct(this.lat, this.lon, this.begin_angle, dist * 1852);
                return new Position { lat = direct.lat2, lon = direct.lon2, course = this.begin_angle, speed = speed };
            }
            else
            {
                var b_cos = Math.Cos(Math.PI / 180 * (this.begin_angle));
                var b_sin = Math.Sin(Math.PI / 180 * (this.begin_angle));
                var r = Math.Abs(1 / this.curve);
                var dangle = Math.Abs(length * this.curve);
                var sign = this.curve > 0 ? 1 : -1;
                var x_ = Math.Sin(dangle);
                var y_ = sign * (1 - Math.Cos(dangle));
                var dx = r * (x_ * b_cos - y_ * b_sin);
                var dy = r * (x_ * b_sin + y_ * b_cos);
                var dist = Math.Sqrt(dx * dx + dy * dy);
                var azi1 = Math.Atan2(dy, dx);
                var direct = Geodesic.WGS84.Direct(this.lat, this.lon,  180 / Math.PI * (azi1), dist * 1852);
                return new Position { lat = direct.lat2, lon = direct.lon2, course = this.begin_angle + sign * 180 / Math.PI * (dangle), speed = speed };
            }
        }
    }
}
