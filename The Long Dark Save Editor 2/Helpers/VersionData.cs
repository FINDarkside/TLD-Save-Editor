using System;

namespace The_Long_Dark_Save_Editor_2.Helpers
{
    public class VersionData
    {
        public string version { get; set; }
        public string url { get; set; }
        public string changes { get; set; }

        public static bool operator <(VersionData v1, VersionData v2)
        {
            return CompareTo(v1, v2) < 0;
        }

        public static bool operator >(VersionData v1, VersionData v2)
        {
            return CompareTo(v1, v2) > 0;
        }

        public static int CompareTo(VersionData v1, VersionData v2)
        {
            string[] s1 = v1.version.Split('.');
            string[] s2 = v2.version.Split('.');

            int major1 = Int32.Parse(s1[0]);
            int major2 = Int32.Parse(s2[0]);
            if (major1 > major2) return 1;
            if (major1 < major2) return -1;

            int minor1 = Int32.Parse(s1[1]);
            int minor2 = Int32.Parse(s2[1]);
            if (minor1 > minor2) return 1;
            if (minor1 < minor2) return -1;

            int patch1 = s1.Length >= 3 ? Int32.Parse(s1[2]) : 0;
            int patch2 = s2.Length >= 3 ? Int32.Parse(s2[2]) : 0;
            if (patch1 > patch2) return 1;
            if (patch1 < patch2) return -1;

            return 0;
        }

        public override string ToString()
        {
            return version;
        }
    }
}
