////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Utils\ByteArrayUtilities.cs
//
// summary:	Implements the byte array utilities class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo.RegisteredServers;

namespace GCS.Core.Common.Utils
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A byte array utilities. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class ByteArrayUtilities
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Byte array equals. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="a">    The byte[] to process. </param>
        /// <param name="b">    The byte[] to process. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool ByteArrayEquals(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets bytes from array. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="source">           [in,out] Source for the. </param>
        /// <param name="lengthToGet">      The length to get. </param>
        /// <param name="startingIndex">    Zero-based index of the starting. </param>
        ///
        /// <returns>   An array of byte. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static byte[] GetBytesFromArray(ref byte[] source, int lengthToGet, int startingIndex)
        {
            if (lengthToGet > source.Length)
                return null;

            if (startingIndex > source.Length)
                return null;

            if (lengthToGet + startingIndex > source.Length)
                return null;

            byte[] newBytes = new byte[lengthToGet];
            Buffer.BlockCopy(source, startingIndex, newBytes, 0, lengthToGet);
            return newBytes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets bytes from array. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="source">           Source for the. </param>
        /// <param name="lengthToGet">      The length to get. </param>
        /// <param name="startingIndex">    Zero-based index of the starting. </param>
        ///
        /// <returns>   An array of byte. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static byte[] GetBytesFromArray(byte[] source, int lengthToGet, int startingIndex)
        {
            if (lengthToGet > source.Length)
                return null;

            if (startingIndex > source.Length)
                return null;

            if (lengthToGet + startingIndex > source.Length)
                return null;

            byte[] newBytes = new byte[lengthToGet];
            Buffer.BlockCopy(source, startingIndex, newBytes, 0, lengthToGet);
            return newBytes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A byte[] extension method that convert byte array to base 64 string. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="bytes">    The bytes to act on. </param>
        ///
        /// <returns>   The byte converted array to base 64 string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string ConvertByteArrayToBase64String(this byte[] bytes)
        {
            if( bytes == null || bytes.Length == 0)
                return string.Empty;
            return System.Convert.ToBase64String(bytes);
        }


    }
}
