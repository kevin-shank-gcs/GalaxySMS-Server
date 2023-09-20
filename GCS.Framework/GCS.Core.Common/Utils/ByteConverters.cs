////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Utils\ByteConverters.cs
//
// summary:	Implements the byte converters class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.Utils
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A byte converters. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class ByteConverters
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Three bytes to int. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="b1">   The first byte. </param>
        /// <param name="b2">   The second byte. </param>
        /// <param name="b3">   The third byte. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static int ThreeBytesToInt(byte b1, byte b2, byte b3)
        {
            int r = 0;
            //byte b0 = 0x0;

            //if ((b1 & 0x80) != 0) r |= b0 << 24;
            r |= b1 << 16;
            r |= b2 << 8;
            r |= b3;
            return r;
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
    }
}
