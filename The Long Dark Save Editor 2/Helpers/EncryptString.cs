using System;
using System.Text;

namespace The_Long_Dark_Save_Editor_2.Helpers
{
    public class EncryptString
    {
        public static string Compress(string json)
        {
            byte[] data = CLZF.Compress(Encoding.UTF8.GetBytes(json));
            return Convert.ToBase64String(data);
        }

        public static string Decompress(string s)
        {
            byte[] data = Convert.FromBase64String(s);
            return Encoding.UTF8.GetString(CLZF.Decompress(data));
        }

        public static byte[] CompressToBytes(string json)
        {
            return CLZF.Compress(Encoding.UTF8.GetBytes(json));
        }

        public static string DecompressBytes(byte[] bytes)
        {
            return Encoding.UTF8.GetString(CLZF.Decompress(bytes));
        }
    }
}
