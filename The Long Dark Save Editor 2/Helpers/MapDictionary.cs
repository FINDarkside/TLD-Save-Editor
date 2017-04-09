using System.Collections.Generic;
using System.Diagnostics;
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
	}

	public static class MapDictionary
	{
		private static Dictionary<string, MapInfo> dict = new Dictionary<string, MapInfo>
		{
			{ "CoastalRegion",new MapInfo {origo = new Point(1441, 1426), width = 2687, height = 2065, pixelsPerCoordinate = 0.98541666666f} },
			{ "LakeRegion", new MapInfo {origo = new Point(260, 2006), width = 2125, height = 2291, pixelsPerCoordinate = 0.98476190476f} },
			{ "WhalingStationRegion", new MapInfo {origo = new Point(94.5, 2018.3), width = 1434, height = 1477, pixelsPerCoordinate = 0.98583333333f} },
			{ "RuralRegion", new MapInfo {origo = new Point(-117, 2238.5), width = 2000, height = 2245, pixelsPerCoordinate = 0.68233333333f} },
			{ "CrashMountainRegion", new MapInfo {origo = new Point(62.5, 2006), width = 2000, height = 2245, pixelsPerCoordinate = 0.98476190476f} },
			{ "MarshRegion", new MapInfo {origo = new Point(260, 2006), width = 2125, height = 2291, pixelsPerCoordinate = 0.98476190476f} },
			{ "RavineTransitionZone", new MapInfo {origo = new Point(1275.5, 543.5), width = 1538, height = 958, pixelsPerCoordinate = 0.98538461538f} },
			{ "HighwayTransitionZone", new MapInfo {origo = new Point(88, 905.2), width = 1182, height = 787, pixelsPerCoordinate = 0.986f} }
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
