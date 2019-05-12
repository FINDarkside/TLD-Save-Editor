using System.Text;

namespace The_Long_Dark_Save_Editor_2.Helpers
{
    public class EncryptString
    {
        public static byte[] Compress(string json)
        {
            return CLZF.Compress(Encoding.UTF8.GetBytes(json));
        }

        public static string Decompress(byte[] bytes)
        {
            return Encoding.UTF8.GetString(CLZF.Decompress(bytes));
        }
    }
}
