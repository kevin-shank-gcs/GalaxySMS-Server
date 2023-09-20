using System;
using System.Security.Cryptography;

namespace GCS.Security
{
    public class ShaHash
    {
        public enum TextEncoding { Default, ASCII, Unicode, BigEndianUnicode, UTF7, UTF8, UTF32 };

        public static byte[] CreateSHAHash(bool bAddTimestamp, int len, string phrase, TextEncoding encoding)
        {
            // SHA1Managed is 160 bits
            SHA1Managed sha1 = new SHA1Managed();

            string sPhrase = string.Empty;
            if (bAddTimestamp == true)
                sPhrase = DateTimeOffset.Now.ToString();

            sPhrase += phrase;
            sPhrase += "galaxy rules";

            //			byte[] data = System.Text.Encoding.Unicode.GetBytes(sPhrase);
            byte[] data = null;
            switch (encoding)
            {
                case TextEncoding.Default:
                    data = System.Text.Encoding.Default.GetBytes(sPhrase);
                    break;

                case TextEncoding.ASCII:
                    data = System.Text.Encoding.ASCII.GetBytes(sPhrase);
                    break;

                case TextEncoding.Unicode:
                    data = System.Text.Encoding.Unicode.GetBytes(sPhrase);
                    break;

                case TextEncoding.BigEndianUnicode:
                    data = System.Text.Encoding.BigEndianUnicode.GetBytes(sPhrase);
                    break;

                case TextEncoding.UTF7:
                    data = System.Text.Encoding.UTF7.GetBytes(sPhrase);
                    break;

                case TextEncoding.UTF8:
                    data = System.Text.Encoding.UTF8.GetBytes(sPhrase);
                    break;

                case TextEncoding.UTF32:
                    data = System.Text.Encoding.UTF32.GetBytes(sPhrase);
                    break;
            }

            byte[] hash1 = sha1.ComputeHash(data);
            byte[] hash = new byte[len];
            for (int x = 0; x < hash.Length; x++)
            {
                if (x == hash1.Length)
                    break;
                hash[x] = hash1[x];
            }
            return hash;
        }

    }

}
