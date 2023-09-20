////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Utils\ByteFlipper.cs
//
// summary:	Implements the byte flipper class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace GCS.Core.Common.Utils
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A byte flipper. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ByteFlipper
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   reverse byte order (32-bit) </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="value">    The value. </param>
        ///
        /// <returns>   An UInt32. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static UInt16 ReverseBytes(UInt16 value)
        {
            return (UInt16)((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   reverse byte order (32-bit) </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="value">    The value. </param>
        ///
        /// <returns>   An UInt32. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static UInt32 ReverseBytes(UInt32 value)
        {
            return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                   (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   reverse byte order (64-bit) </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="value">    The value. </param>
        ///
        /// <returns>   An UInt64. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static UInt64 ReverseBytes(UInt64 value)
        {
            return (value & 0x00000000000000FFUL) << 56 | (value & 0x000000000000FF00UL) << 40 |
                   (value & 0x0000000000FF0000UL) << 24 | (value & 0x00000000FF000000UL) << 8 |
                   (value & 0x000000FF00000000UL) >> 8 | (value & 0x0000FF0000000000UL) >> 24 |
                   (value & 0x00FF000000000000UL) >> 40 | (value & 0xFF00000000000000UL) >> 56;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Reverse bytes. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="bytes">    The bytes. </param>
        ///
        /// <returns>   A byte[]. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static byte[] ReverseBytes(byte[] bytes)
        {
            if (bytes == null)
                return bytes;
            byte[] newBytes = new byte[bytes.Length];
            int x = bytes.Length;
            foreach (byte b in bytes)
            {
                newBytes[x - 1] = b;
                x--;
            }
            return newBytes;
        }

        public static UInt32 RotateBytesRight(UInt32 value)
        {
            var bytes = BitConverter.GetBytes(value);
            var rotatedBytes = new byte[bytes.Length];
            rotatedBytes[1] = bytes[0];
            rotatedBytes[2] = bytes[1];
            rotatedBytes[3] = bytes[2];
            rotatedBytes[0] = bytes[3];

            return BitConverter.ToUInt32(rotatedBytes, 0);
        }
        public static int RotateBytesRight(int value)
        {
            return (int) RotateBytesRight((uint) value);
        }


        public static UInt32 RotateBytesLeft(UInt32 value)
        {
            var bytes = BitConverter.GetBytes(value);
            var rotatedBytes = new byte[bytes.Length];
            rotatedBytes[2] = bytes[3];
            rotatedBytes[1] = bytes[2];
            rotatedBytes[0] = bytes[1];
            rotatedBytes[3] = bytes[0];

            return BitConverter.ToUInt32(rotatedBytes, 0);
        }

        public static int RotateBytesLeft(int value)
        {
            return (int)RotateBytesLeft((uint)value);
        }
    }
}
