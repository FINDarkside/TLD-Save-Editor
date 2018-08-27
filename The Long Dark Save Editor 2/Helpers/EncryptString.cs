using System;
using System.Text;
using System.Security.Cryptography;


namespace The_Long_Dark_Save_Editor_2.Helpers
{
    public class EncryptString
    {
        public static byte[] CompressStringToBytes(string toEncrypt)
        {
            return CLZF.Compress(Encoding.UTF8.GetBytes(toEncrypt));
        }

        public static string DecompressBytesToString(byte[] toDecrypt)
        {
            return Encoding.UTF8.GetString(CLZF.Decompress(toDecrypt));
        }
    }
}
