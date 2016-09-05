using System;
using System.Text;
using System.Security.Cryptography;


namespace The_Long_Dark_Save_Editor_2.Helpers
{
	public class EncryptString
	{
		private static bool m_Initialized;
		private static byte[] keyArray;
		private static ICryptoTransform m_EncoderTransform;
		private static ICryptoTransform m_DecoderTransform;

		static EncryptString()
		{
			EncryptString.keyArray = Encoding.UTF8.GetBytes(EncryptString.GetKey());
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.Key = EncryptString.keyArray;
			rijndaelManaged.Mode = CipherMode.ECB;
			rijndaelManaged.Padding = PaddingMode.PKCS7;
			EncryptString.m_EncoderTransform = rijndaelManaged.CreateEncryptor();
			EncryptString.m_DecoderTransform = rijndaelManaged.CreateDecryptor();
			EncryptString.m_Initialized = true;

		}

		private static string GetKey()
		{
			return "FL8j2zG0wY9MkUp9DJlXsW8f9FUaZ9nL";
		}

		public static string Encrypt(string toEncrypt)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(toEncrypt);
			byte[] inArray = EncryptString.m_EncoderTransform.TransformFinalBlock(bytes, 0, bytes.Length);
			return Convert.ToBase64String(inArray, 0, inArray.Length);
		}

		public static string Decrypt(string toDecrypt)
		{
			try
			{
				throw new Exception();
				byte[] inputBuffer = Convert.FromBase64String(toDecrypt);
				return Encoding.UTF8.GetString(EncryptString.m_DecoderTransform.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
			}
			catch
			{
				return string.Empty;
			}
		}

		public static byte[] CompressStringToBytes(string toEncrypt)
		{
			return CLZF.Compress(Encoding.UTF8.GetBytes(toEncrypt));
		}

		public static string DecompressBytesToString(byte[] toDecrypt)
		{
			try
			{
				string @string = Encoding.UTF8.GetString(CLZF.Decompress(toDecrypt));
				if (!string.IsNullOrEmpty(@string))
				{
					if (@string.StartsWith("{"))
					{
						if (@string.EndsWith("}"))
							return @string;
					}
				}
			}
			catch
			{
				return string.Empty;
			}
			return string.Empty;
		}
	}
}
