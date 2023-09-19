////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Utils\BitShifter.cs
//
// summary:	Implements the bit shifter class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.Utils
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A bit shifter. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class BitShifter
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Shift left. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="value">    The value. </param>
        /// <param name="bitcount"> The bitcount. </param>
        ///
        /// <returns>   A byte[]. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static byte[] ShiftLeft(byte[] value, int bitcount)
        {
            byte[] temp = new byte[value.Length];
            if (bitcount >= 8)
            {
                Array.Copy(value, bitcount / 8, temp, 0, temp.Length - (bitcount / 8));
            }
            else
            {
                Array.Copy(value, temp, temp.Length);
            }
            if (bitcount % 8 != 0)
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] <<= bitcount % 8;
                    if (i < temp.Length - 1)
                    {
                        temp[i] |= (byte)(temp[i + 1] >> 8 - bitcount % 8);
                    }
                }
            }
            return temp;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Shift right. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="value">    The value. </param>
        /// <param name="bitcount"> The bitcount. </param>
        ///
        /// <returns>   A byte[]. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static byte[] ShiftRight(byte[] value, int bitcount)
        {
            byte[] temp = new byte[value.Length];
            if (bitcount >= 8)
            {
                Array.Copy(value, 0, temp, bitcount / 8, temp.Length - (bitcount / 8));
            }
            else
            {
                Array.Copy(value, temp, temp.Length);
            }
            if (bitcount % 8 != 0)
            {
                for (int i = temp.Length - 1; i >= 0; i--)
                {
                    temp[i] >>= bitcount % 8;
                    if (i > 0)
                    {
                        temp[i] |= (byte)(temp[i - 1] << 8 - bitcount % 8);
                    }
                }
            }
            return temp;
        }
    }

}
