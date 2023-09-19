using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Newtonsoft.Json;

namespace GCS.Core.Common.Extensions
{
    public static class ByteArrayExtensions
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A byte[] extension method that convert byte array to base 64 string. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="bytes">    The bytes to act on. </param>
        ///
        /// <returns>   The byte converted array to base 64 string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string ToBase64String(this byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return string.Empty;
            return System.Convert.ToBase64String(bytes);
        }

        public static string ToHexString(this byte[] bytes, char byteSeparator)
        {
            if (bytes == null || bytes.Length == 0)
                return string.Empty;
            var hexLen = bytes.Length * 2;
            if (byteSeparator != 0)
                hexLen += bytes.Length;
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:X2}", b);
                if (byteSeparator != 0)
                    hex.Append(byteSeparator);
            }
            return hex.ToString();
        }

        public static bool AreEqual(this byte[] bytes, byte[] other)
        {
            if ((bytes == null || bytes.Length == 0) &&
                (other == null || other.Length == 0))
                return true;
            if (bytes == null || other == null)
                return false;
            if (bytes.Length != other.Length)
                return false;
            for (var x = 0; x < bytes.Length; x++)
            {
                if (bytes[x] != other[x])
                    return false;
            }

            return true;
        }

        public static byte[] DeepCopy(this byte[] bytes)
        {
            if (bytes == null)
                return null;

            var newBytes = new byte[bytes.Length];
            Buffer.BlockCopy(bytes, 0, newBytes, 0, newBytes.Length);

            return newBytes;
        }

    }
}
