////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Utils\HexEncoding.cs
//
// summary:	Implements the hexadecimal encoding class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Extensions;
using System;

namespace GCS.Core.Common.Utils
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A hexadecimal encoding. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class HexEncoding
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public HexEncoding()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Determine if we are byte arrays equivalent. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="a1">   The first byte[]. </param>
        /// <param name="a2">   The second byte[]. </param>
        ///
        /// <returns>   True if byte arrays equivalent, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool AreByteArraysEquivalent(byte[] a1, byte[] a2)
        {
            if (a1 == null && a2 == null)
                return true;
            if (a1 == null && a2 != null)
                return false;
            if (a1 != null && a2 == null)
                return false;

            if (a1.Length != a2.Length)
                return false;

            for (int i = 0; i < a1.Length; i++)
                if (a1[i] != a2[i])
                    return false;

            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets byte count. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="hexString">    string to convert to byte array. </param>
        ///
        /// <returns>   The byte count. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static int GetByteCount(string hexString)
        {
            int numHexChars = 0;
            char c;
            // remove all none A-F, 0-9, characters
            for (int i = 0; i < hexString.Length; i++)
            {
                c = hexString[i];
                if (IsHexDigit(c))
                    numHexChars++;
            }
            // if odd number of characters, discard last character
            if (numHexChars % 2 != 0)
            {
                numHexChars--;
            }
            return numHexChars / 2; // 2 characters per byte
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Creates a byte array from the hexadecimal string. Each two characters are combined to create
        /// one byte. First two hexadecimal characters become first byte in returned array. Non-
        /// hexadecimal characters are ignored.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="hexString">    string to convert to byte array. </param>
        ///
        /// <returns>   byte array, in the same left-to-right order as the hexString. </returns>
        ///
        /// ### <param name="discarded">    number of characters in string ignored. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static byte[] GetBytesFromHexString(string hexString)
        {
            string newString = "";
            char c;

            if (string.IsNullOrEmpty(hexString))
                return null;

            // remove all none A-F, 0-9, characters
            for (int i = 0; i < hexString.Length; i++)
            {
                c = hexString[i];
                if (IsHexDigit(c))
                    newString += c;
                else
                    return null;    // if the string is invalid, return null
            }


            int byteLength = newString.Length / 2;
            byte[] bytes = new byte[byteLength];
            string hex;
            int j = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                hex = new String(new Char[] { newString[j], newString[j + 1] });
                bytes[i] = HexToByte(hex);
                j = j + 2;
            }
            return bytes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Creates a byte array from the hexadecimal string. Each two characters are combined to create
        /// one byte. First two hexadecimal characters become first byte in returned array. Non-
        /// hexadecimal characters are ignored.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="hexString">    string to convert to byte array. </param>
        /// <param name="padToLength">  Length of the pad to. </param>
        /// <param name="discarded">    [out] number of characters in string ignored. </param>
        ///
        /// <returns>   byte array, in the same left-to-right order as the hexString. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static byte[] GetBytesFromHexString(string hexString, int padToLength, out int discarded)
        {
            discarded = 0;
            string newString = "";
            char c;
            // remove all none A-F, 0-9, characters
            for (int i = 0; i < hexString.Length; i++)
            {
                c = hexString[i];
                if (IsHexDigit(c))
                    newString += c;
                else
                    discarded++;
            }

            if (padToLength > 0)
            {
                while (newString.Length < (padToLength * 2))
                {
                    newString = "0" + newString;
                }
            }

            // if odd number of characters, discard last character
            if (newString.Length % 2 != 0)
            {
                discarded++;
                newString = newString.Substring(0, newString.Length - 1);
            }

            int byteLength = newString.Length / 2;
            byte[] bytes = new byte[byteLength];
            string hex;
            int j = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                hex = new String(new Char[] { newString[j], newString[j + 1] });
                bytes[i] = HexToByte(hex);
                j = j + 2;
            }
            return bytes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates a byte array from the decimal string. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="decimalString">    string to convert to byte array. </param>
        /// <param name="padToLength">      Length of the pad to. </param>
        /// <param name="discarded">        [out] number of characters in string ignored. </param>
        ///
        /// <returns>   byte array, in the same left-to-right order as the decimalString. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static byte[] GetBytesFromDecimalString(string decimalString, int padToLength, out int discarded)
        {
            UInt64 u64Data = 0;
            if (UInt64.TryParse(decimalString, out u64Data))
            {
                string s = string.Format("x{0}", u64Data.ToString("X"));
                return GetBytesFromHexString(s, padToLength, out discarded);
            }
            discarded = 0;
            return new byte[padToLength];

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets bytes from string. </summary>
        ///
        /// <remarks>   Kevin, 3/23/2022. </remarks>
        ///
        /// <param name="s">            The string. </param>
        /// <param name="padToLength">  Length of the pad to. </param>
        /// <param name="discarded">    [out] number of characters in string ignored. </param>
        ///
        /// <returns>   An array of byte. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static byte[] GetBytesFromString(string s, int padToLength, out int discarded)
        {
            discarded = 0;
            var hexPrefix = false;
            var isHex = false;
            var sLower = s.ToLower();
            if (sLower.StartsWith("0x") || sLower.StartsWith("x"))
            {
                // Get rid of the 0 before the 0x
                sLower = sLower.TrimStart('0');
                hexPrefix = true;
                isHex = sLower.IsHexadecimal(true);
                // 0x or x prefix says the data is hex, but it contains invalid hex characters.
                // In this case, return all 0 bytes because the incoming string cannot be converted to hex
                if (!isHex)
                {
                    return new byte[padToLength];
                }
                // Otherwise, return the bytes, considering the incoming string to be hex
                return GetBytesFromHexString(sLower, padToLength, out discarded);
            }

            // If the incoming string does not have a 0x or x prefix, then if it contains hex characters, then treat it as hex
            isHex = sLower.IsHexadecimal(true);
            var isDecimal = sLower.IsDecimal();
            if (isDecimal && sLower.Length > 18) // If it is greater than 18 digits, it cannot be represented in a 64 bit number, so automatically treat as hex 9,223,372,036,854,775,807
                isDecimal = false;
            if (isDecimal )    
                return GetBytesFromDecimalString(sLower, padToLength, out discarded);
            if (isHex)
                return GetBytesFromHexString(sLower, padToLength, out discarded);
            return new byte[padToLength];
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets a bit in a byte array to the specified value. </summary>
        ///
        /// <remarks>   Kevin, 11/2/2016. </remarks>
        ///
        /// <param name="bytes">        The byte array to operate on. The bytes are considered to be
        ///                             right-adjusted. </param>
        /// <param name="bitNumber">    The bit number to set, counting from the right. One based. </param>
        /// <param name="bitValue">     true or false, the bit value. </param>
        ///
        /// <returns>   A byte[]. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static byte[] SetBit(byte[] bytes, int bitNumber, bool bitValue)
        {
            if (bitNumber < 1)
                return bytes;

            var length = bytes.Length;
            int byteNumberToEffect = (bitNumber - 1) / 8;

            if (byteNumberToEffect >= length)
                return bytes;

            byteNumberToEffect = length - 1 - byteNumberToEffect;   // now convert to byte offset from the right
            int bitToEffect = bitNumber % 8;
            if (bitToEffect == 0)
                bitToEffect = 8;
            byte mask = 1;
            mask <<= (bitToEffect - 1);
            if (bitValue == true)
            {
                bytes[byteNumberToEffect] |= mask;
            }
            else
            {
                bytes[byteNumberToEffect] &= (byte)~mask;
            }
            return bytes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Convert this HexEncoding into a string representation. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="bytes">                        The byte array to operate on. The bytes are
        ///                                             considered to be right-adjusted. </param>
        /// <param name="bDiscardLeadingZeros">         True to discard leading zeros. </param>
        /// <param name="hexPrefix">                    The hexadecimal prefix. </param>
        /// <param name="bReturnDecimalIfPossible">     True to return decimal if possible. </param>
        /// <param name="maximumDecimalFormatBitCount"> Number of maximum decimal format bits. </param>
        ///
        /// <returns>   A string that represents this HexEncoding. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string ToString(byte[] bytes, bool bDiscardLeadingZeros, string hexPrefix, bool bReturnDecimalIfPossible, short maximumDecimalFormatBitCount)
        {
            var temp = new byte[bytes.Length];
            Array.Copy(bytes, temp, temp.Length);
            string sRet = string.Empty;
            string hexString = hexPrefix;
            string decString = string.Empty;
            int idx = 0;
            if (bDiscardLeadingZeros == true)
            {
                foreach (byte b in temp)
                {
                    if (b == 0)
                        idx++;
                    else
                        break;
                }
            }

            for (; idx < temp.Length; idx++)
            {
                hexString += temp[idx].ToString("X2");
            }

            sRet = hexString;
            if (bReturnDecimalIfPossible == true)
            {
                short hightest1Bit = GetHighestNonZeroBit(temp);
                if (hightest1Bit <= maximumDecimalFormatBitCount && hightest1Bit <= 64)
                {	// only attempt if this can fit into a 64 bit
                    // If the system architecture is little-endian (that is, little end first), 
                    // reverse the byte array. 
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(temp);

                    UInt64 value = BitConverter.ToUInt64(temp, 0);
                    decString = value.ToString();
                    if (decString != string.Empty)
                        sRet = decString;
                }
            }
            return sRet;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Pad byte array. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="bytes">            The byte array to operate on. The bytes are considered to be
        ///                                 right-adjusted. </param>
        /// <param name="padToLength">      Length of the pad to. </param>
        /// <param name="addPaddingToEnd">  True to add padding to end. </param>
        ///
        /// <returns>   A byte[]. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static byte[] PadByteArray(byte[] bytes, int padToLength, bool addPaddingToEnd)
        {
            byte[] originalBytes = bytes;
            if (bytes.Length < padToLength)
            {
                byte[] padding = new byte[padToLength - bytes.Length];
                byte[] rv = new byte[bytes.Length + padding.Length];
                if (addPaddingToEnd)
                {
                    Buffer.BlockCopy(bytes, 0, rv, 0, bytes.Length);
                    Buffer.BlockCopy(padding, 0, rv, bytes.Length, padding.Length);
                }
                else
                {
                    Buffer.BlockCopy(padding, 0, rv, 0, padding.Length);
                    Buffer.BlockCopy(bytes, 0, rv, padding.Length, bytes.Length);
                }
                bytes = new byte[rv.Length];
                Array.Copy(rv, bytes, rv.Length);
            }
            return bytes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Rights. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="bytes">            The byte array to operate on. The bytes are considered to be
        ///                                 right-adjusted. </param>
        /// <param name="numberOfBytes">    Number of bytes. </param>
        ///
        /// <returns>   A byte[]. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static byte[] Right(byte[] bytes, int numberOfBytes)
        {
            byte[] originalBytes = bytes;
            if (bytes.Length <= numberOfBytes)   // if the incoming array is shorter or equal to the requested # of byte, just return the original array
                return bytes;
            // chop off the upper bytes
            byte[] returnData = new byte[numberOfBytes];
            int startingIndex = bytes.Length - numberOfBytes;
            Buffer.BlockCopy(bytes, startingIndex, returnData, 0, numberOfBytes);
            return returnData;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Determines if given string is in proper hexadecimal string format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="hexString">    . </param>
        ///
        /// <returns>   True if hexadecimal format, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public static bool IsHexFormat(string hexString)
        //{
        //    bool hexFormat = true;

        //    foreach (char digit in hexString)
        //    {
        //        if (!IsHexDigit(digit))
        //        {
        //            hexFormat = false;
        //            break;
        //        }
        //    }
        //    return hexFormat;
        //}


        public static bool IsHexFormat(string s)
        {
            var isHex = false;
            //var isDecimal = false;
            var sLower = s.ToLower();
            if (sLower.StartsWith("0x") || sLower.StartsWith("x"))
            {
                // Get rid of the 0 before the 0x
                sLower = sLower.TrimStart('0');
                var hexPrefix = true;
                isHex = sLower.IsHexadecimal(true);
                // 0x or x prefix says the data is hex, but it contains invalid hex characters.
                // In this case, return all 0 bytes because the incoming string cannot be converted to hex
                if (!isHex)
                {
                    return false;
                }
            }

            // If the incoming string does not have a 0x or x prefix, then if it contains hex characters, then treat it as hex
            isHex = sLower.IsHexadecimal(true);
            //isDecimal = sLower.IsDecimal();
            return isHex;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Determines if given string is in proper decimal string format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="decString">    . </param>
        ///
        /// <returns>   True if decimal format, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsDecimalFormat(string decString)
        {
            bool decFormat = true;

            foreach (char digit in decString)
            {
                if (!IsDecimalDigit(digit))
                {
                    decFormat = false;
                    break;
                }
            }
            return decFormat;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns true is c is a hexadecimal digit (A-F, a-f, 0-9) </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="c">    Character to test. </param>
        ///
        /// <returns>   true if hex digit, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsHexDigit(Char c)
        {
            int numChar;
            int numA = Convert.ToInt32('A');
            int num1 = Convert.ToInt32('0');
            c = Char.ToUpper(c);
            numChar = Convert.ToInt32(c);
            if (numChar >= numA && numChar < (numA + 6))
                return true;
            if (numChar >= num1 && numChar < (num1 + 10))
                return true;
            return false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns true is c is a decimal digit (0-9) </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="c">    Character to test. </param>
        ///
        /// <returns>   true if decimal digit, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsDecimalDigit(Char c)
        {
            int numChar;
            int num1 = Convert.ToInt32('0');
            numChar = Convert.ToInt32(c);
            if (numChar >= num1 && numChar < (num1 + 10))
                return true;
            return false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts 1 or 2 character string into equivalant byte value. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        ///
        /// <param name="hex">  1 or 2 character string. </param>
        ///
        /// <returns>   byte. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static byte HexToByte(string hex)
        {
            if (hex.Length > 2 || hex.Length <= 0)
                throw new ArgumentException("hex must be 1 or 2 characters in length");
            foreach (var c in hex)
            {
                if (!c.IsHex())
                    return 0;
            }
            byte newByte = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            return newByte;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Spins through a Generic array and determines if all elements match the specified value.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="array">        array of generic objects. </param>
        /// <param name="compareTo">    object of T to compare against. </param>
        ///
        /// <returns>   bool. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool CompareArray<T>(T[] array, T compareTo)
        {
            foreach (T element in array)
            {
                if (element.Equals(compareTo) == false)
                    return false;
            }
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets highest non zero bit. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="array">    array of generic objects. </param>
        ///
        /// <returns>   The highest non zero bit. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static short GetHighestNonZeroBit(byte[] array)
        {
            short highestBit = (short)(array.Length * 8);
            bool bBitFound = false;

            foreach (byte b in array)
            {
                if (bBitFound == true)
                    break;
                if (b == 0)
                {
                    highestBit -= 8;
                    continue;
                }

                byte mask = 0x80;
                for (int bit = 0; bit < 8; bit++, mask >>= 1)
                {
                    if ((b & mask) == 0)
                    {
                        highestBit -= 1;
                    }
                    else
                    {
                        bBitFound = true;
                        break;
                    }
                }
            }

            return highestBit;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Applies the mask. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="array">            array of generic objects. </param>
        /// <param name="mask">             The mask. </param>
        /// <param name="bApplyMaskToEnd">  True to apply mask to end. </param>
        ///
        /// <returns>   A byte[]. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static byte[] ApplyMask(byte[] array, byte[] mask, bool bApplyMaskToEnd)
        {
            if (array == null || mask == null)
                return array;
            if (array.Length < mask.Length)
                return array;

            if (array.Length == mask.Length)
            {
                for (int x = 0; x < array.Length; x++)
                {
                    array[x] &= mask[x];
                }
            }
            else
            {
                if (bApplyMaskToEnd)
                {
                    mask = PadByteArray(mask, array.Length, false);
                    for (int x = 0; x < mask.Length; x++)
                    {
                        int arrayIndex = x + (array.Length - mask.Length);
                        array[arrayIndex] &= mask[x];
                    }
                }
                else
                {
                    mask = PadByteArray(mask, array.Length, true);
                    for (int x = 0; x < mask.Length; x++)
                    {
                        array[x] &= mask[x];
                    }
                }
            }
            return array;
        }
    }

}
