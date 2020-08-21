using GeographicLib;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public Tuple<Position, Position> FindBorders(List<State> states)
        {
            Position minLatLon = new Position { course = 0, lat = 999, lon = 999, speed = 0 };
            Position maxLatLon = new Position { course = 0, lat = -999, lon = -999, speed = 0 };
            foreach (var state in states)
            {
                foreach (var pos in state)
                {
                    if (pos.lat > maxLatLon.lat) maxLatLon.lat = pos.lat;
                    if (pos.lon > maxLatLon.lon) maxLatLon.lon = pos.lon;
                    if (pos.lat < minLatLon.lat) minLatLon.lat = pos.lat;
                    if (pos.lon < minLatLon.lon) minLatLon.lon = pos.lon;
                }
            }
            return new Tuple<Position, Position>(minLatLon, maxLatLon);
        }
    }
}
