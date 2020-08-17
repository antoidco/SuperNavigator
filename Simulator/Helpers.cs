using GeographicLib;
using System;

namespace SuperNavigator.Simulator
{
    public class Helpers
    {
        public static Position ExtrapolatePosition(Position pos, double time)
        {
            double dist = time * pos.speed;
            var direct = Geodesic.WGS84.Direct(pos.lat, pos.lon, pos.course, dist * 1852);
            return new Position { lat = direct.lat2, lon = direct.lon2, course = pos.course, speed = pos.speed };
        }
        public static string AlgorithmPreferToString(AlgorithmPrefer prefer)
        {
            if (prefer == AlgorithmPrefer.PreferBase) return "Main";
            if (prefer == AlgorithmPrefer.PreferRVO) return "RVO";
            throw new Exception();
        }
    }
}
