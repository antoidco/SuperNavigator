using GeographicLib;
using System;
using System.Numerics;

namespace SuperNavigator.Simulator
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
        /// Переведено с python (KTViz)
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

        /// <summary>
        /// Вычисляет приблизительную дистанцию до сегмента от точки C
        /// </summary>
        /// <param name="C">Положение точки C</param>
        /// <returns>Дистанция (с погрешностью)</returns>
        public double distance(Vector2 C)
        {
            if (0.0000001 > Math.Abs(curve))
            {
                var start_point = new Vector2((float)lat, (float)lon);
                var A = start_point;
                var B = start_point + 
                    new Vector2((float)(length * Math.Cos(begin_angle)), (float)(length * Math.Sin(begin_angle)));
                // Straight
                /*
                                     AC * AB
                                r = ---------
                                      |AC|
                    r has the following meaning:
                    1)
                        r = 0: P = A
                        r < 0: P is on the backward extension of AB
                    2)
                        r = |AB|: P = B
                        r > |AB|: P is on the forward extension of AB
                    3)
                        0 < r < |AB|: P is interior to AB
                */
                var AB = B - A;
                var AC = C - A;
                var ABabs = AB.Length();
                var r = Vector2.Dot(AC, AB) / ABabs;
                // 1)
                if (r <= 0.0)
                {
                    return AC.Length() * 57;
                }
                // 2)
                if (r >= length)
                {
                    return (C - B).Length() * 57;
                }
                /*
                    3)
                                    |AB^AC|
                        distance = ---------
                                       L
                */
                return (AB.X * AC.Y - AB.Y * AC.X) / length * 57;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
