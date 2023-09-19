using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCS.Framework.Utilities
{
    public class HexEncoding
    {
        public HexEncoding()
        {
            //
            // TODO: Add constructor logic here
            //
        }


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
        /// <summary>
        /// Creates a byte array from the hexadecimal string. Each two characters are combined
        /// to create one byte. First two hexadecimal characters become first byte in returned array.
        /// Non-hexadecimal characters are ignored. 
        /// </summary>
        /// <param name="hexString">string to convert to byte array</param>
        /// <param name="discarded">number of characters in string ignored</param>
        /// <returns>byte array, in the same left-to-right order as the hexString</returns>
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

        /// <summary>
        /// Creates a byte array from the decimal string. 
        /// </summary>
        /// <param name="decimalString">string to convert to byte array</param>
        /// <param name="discarded">number of characters in string ignored</param>
        /// <returns>byte array, in the same left-to-right order as the decimalString</returns>
        public static byte[] GetBytesFromDecimalString(string decimalString, int padToLength, out int discarded)
        {
            UInt64 u64Data = UInt64.Parse(decimalString);
            string s = string.Format("x{0}", u64Data.ToString("X"));
            byte[] bytes = GetBytesFromHexString(s, padToLength, out discarded);

            return bytes;
        }

        public static string ToString(byte[] bytes, bool bDiscardLeadingZeros, string hexPrefix, bool bReturnDecimalIfPossible, short maximumDecimalFormatBitCount )
        {
			  string sRet = string.Empty;
				string hexString = hexPrefix;
				string decString = string.Empty;
				int idx = 0;
				if (bDiscardLeadingZeros == true)
				{
					foreach (byte b in bytes)
					{
						if (b == 0)
							idx++;
						else
							break;
					}
				}

				for (; idx < bytes.Length; idx++)
            {
					hexString += bytes[idx].ToString("X2");
            }

				sRet = hexString;
				if( bReturnDecimalIfPossible == true )
				{
					short hightest1Bit = GCS.Framework.Utilities.HexEncoding.GetHighestNonZeroBit(bytes);
					if (hightest1Bit <= maximumDecimalFormatBitCount && hightest1Bit <= 64 )
					{	// only attempt if this can fit into a 64 bit
						// If the system architecture is little-endian (that is, little end first), 
						// reverse the byte array. 
						if (BitConverter.IsLittleEndian)
							 Array.Reverse(bytes);

                        bytes = PadByteArray(bytes, sizeof(UInt64));
                        UInt64 value = BitConverter.ToUInt64(bytes, 0);
						decString = value.ToString();
						if (decString != string.Empty)
							sRet = decString;
					}
				}
				return sRet;
        }

        public static byte[] PadByteArray(byte[] bytes, int padToLength)
        {
            if (bytes.Length < padToLength)
            {
                byte[] padding = new byte[padToLength - bytes.Length];
                byte[] rv = new byte[bytes.Length + padding.Length];
                System.Buffer.BlockCopy(bytes, 0, rv, 0, bytes.Length);
                System.Buffer.BlockCopy(padding, 0, rv, bytes.Length, padding.Length);
                bytes = new byte[rv.Length];
                Array.Copy(rv, bytes, rv.Length);
            }
            return bytes;
        }

        /// <summary>
        /// Determines if given string is in proper hexadecimal string format
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static bool IsHexFormat(string hexString)
        {
            bool hexFormat = true;

            foreach (char digit in hexString)
            {
                if (!IsHexDigit(digit))
                {
                    hexFormat = false;
                    break;
                }
            }
            return hexFormat;
        }

		  /// <summary>
		  /// Determines if given string is in proper decimal string format
		  /// </summary>
		  /// <param name="hexString"></param>
		  /// <returns></returns>
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
		 /// <summary>
        /// Returns true is c is a hexadecimal digit (A-F, a-f, 0-9)
        /// </summary>
        /// <param name="c">Character to test</param>
        /// <returns>true if hex digit, false if not</returns>
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

        /// <summary>
        /// Returns true is c is a decimal digit (0-9)
        /// </summary>
        /// <param name="c">Character to test</param>
        /// <returns>true if decimal digit, false if not</returns>
        public static bool IsDecimalDigit(Char c)
        {
            int numChar;
            int num1 = Convert.ToInt32('0');
            numChar = Convert.ToInt32(c);
            if (numChar >= num1 && numChar < (num1 + 10))
                return true;
            return false;
        }
        /// <summary>
        /// Converts 1 or 2 character string into equivalant byte value
        /// </summary>
        /// <param name="hex">1 or 2 character string</param>
        /// <returns>byte</returns>
        private static byte HexToByte(string hex)
        {
            if (hex.Length > 2 || hex.Length <= 0)
                throw new ArgumentException("hex must be 1 or 2 characters in length");
            byte newByte = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            return newByte;
        }

		  /// <summary>
		  /// Spins through a Generic array and determines if all elements match the specified value
		  /// </summary>
		  /// <param name="array"> array of generic objects</param>
		  /// <param name="compareTo"> object of T to compare against</param>
		  /// <returns>bool</returns>
		  public static bool CompareArray<T>(T[] array, T compareTo)
		  {
			  foreach (T element in array)
			  {
				  if (element.Equals(compareTo) == false)
					  return false;
			  }
			  return true;
		  }

		  public static short GetHighestNonZeroBit(byte[] array)
		  {
			  short highestBit = (short)(array.Length * 8);
			  bool bBitFound = false;

			  foreach(byte b in array)
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
	 }
}
