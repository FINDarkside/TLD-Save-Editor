using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace The_Long_Dark_Save_Editor_2.Helpers
{
    public class MapInfo
    {
        public string inGameName;
        public Point origo;
        public int width;
        public int height;
        public float pixelsPerCoordinate;
        public Point ToRegion(Point point)
        {
            return new Point((point.X - origo.X) / pixelsPerCoordinate,
                    (point.Y - origo.Y) / -pixelsPerCoordinate);
        }
        public Point ToLayer(Point point)
        {
            return new Point(point.X * pixelsPerCoordinate + origo.X,
                    point.Y * -pixelsPerCoordinate + origo.Y);
        }
    }

    public static class MapDictionary
    {
        private static Dictionary<string, MapInfo> dict = new Dictionary<string, MapInfo>
        {
            { "CoastalRegion",new MapInfo {origo = new Point(1441, 1426), width = 2687, height = 2065, pixelsPerCoordinate = 0.98541666666f} },
            { "LakeRegion", new MapInfo {origo = new Point(343, 2037), width = 2330, height = 2330, pixelsPerCoordinate = 0.9999f} },
            { "WhalingStationRegion", new MapInfo {origo = new Point(94.5, 2018.3), width = 1434, height = 1477, pixelsPerCoordinate = 0.98583333333f} },
            { "RuralRegion", new MapInfo {origo = new Point(-58, 2209), width = 2000, height = 2245, pixelsPerCoordinate = 0.68233333333f} },
            { "CrashMountainRegion", new MapInfo {origo = new Point(62.5, 2006), width = 2124, height = 2349, pixelsPerCoordinate = 0.98476190476f} },
            { "MarshRegion", new MapInfo {origo = new Point(132, 2193), width = 1988, height = 2419, pixelsPerCoordinate = 0.937f} },
            { "RavineTransitionZone", new MapInfo {origo = new Point(1275.5, 543.5), width = 1538, height = 958, pixelsPerCoordinate = 0.98538461538f} },
            { "HighwayTransitionZone", new MapInfo {origo = new Point(88, 905.2), width = 1182, height = 787, pixelsPerCoordinate = 0.986f} },
            { "TracksRegion", new MapInfo {origo = new Point(308, 1746), width = 1763, height = 2007, pixelsPerCoordinate = 0.9385f} },
            { "RiverValleyRegion", new MapInfo {origo = new Point(99.18, 1832), width = 1968, height = 2092, pixelsPerCoordinate = 0.9385f} },
            { "MountainTownRegion", new MapInfo {origo = new Point(38.15, 2380), width = 2156, height = 2606, pixelsPerCoordinate = 0.9385f} },
            { "CanneryRegion", new MapInfo {origo = new Point(1399, 1401), width = 2500, height = 2602, pixelsPerCoordinate = 1.0f} },
            { "AshCanyonRegion", new MapInfo {origo = new Point(1133.7, 1118), width = 2274, height = 2655, pixelsPerCoordinate = 1.0f} }
        };

        public static List<string> MapNames
        {
            get { return dict.Keys.ToList(); }
        }

        public static MapInfo GetMapInfo(string mapName)
        {
            return dict[mapName];
        }

        public static bool MapExists(string region)
        {
            return dict.ContainsKey(region);
        }

        public static string GetInGameName(string region)
        {
            return Properties.Resources.ResourceManager.GetString(region) ?? region;
        }

    }
}
