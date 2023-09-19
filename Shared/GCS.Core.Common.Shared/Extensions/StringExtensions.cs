////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Extensions\StringExtensions.cs
//
// summary:	Implements the string extensions class
////////////////////////////////////////////////////////////////////////////////////////////////////

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace GCS.Core.Common.Extensions
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A string extensions. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class StringExtensions
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A string extension method that query if 's' is valid email address. </summary>
        ///
        /// <remarks>   Kevin, 1/4/2016. </remarks>
        ///
        /// <param name="s">    The s to act on. </param>
        ///
        /// <returns>   true if valid email address, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsValidEmailAddress(this string s)
        {
            //Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            var regex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            return regex.IsMatch(s);
        }

        public static bool IsValidMacAddress(this string s)
        {
            Regex regex = new Regex(@"^[0-9a-fA-F]{2}(((:[0-9a-fA-F]{2}){5})|((-[0-9a-fA-F]{2}){5}))$");
            return regex.IsMatch(s);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A string extension method that query if 'theValue' is numeric. </summary>
        ///
        /// <remarks>   Kevin, 1/4/2016. </remarks>
        ///
        /// <param name="theValue"> The theValue to act on. </param>
        ///
        /// <returns>   true if numeric, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsNumeric(this string theValue)
        {
            long retNum;
            return long.TryParse(theValue, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Encryptes a string using the supplied key. Encoding is done using RSA encryption.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentException">    Occurs when stringToEncrypt or key is null or empty. </exception>
        ///
        /// <param name="stringToEncrypt">  String that must be encrypted. </param>
        /// <param name="key">              Encryptionkey. </param>
        ///
        /// <returns>   A string representing a byte array separated by a minus sign. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string Encrypt(this string stringToEncrypt, string key)
        {
            if (string.IsNullOrEmpty(stringToEncrypt))
            {
                throw new ArgumentException("An empty string value cannot be encrypted.");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Cannot encrypt using an empty key. Please supply an encryption key.");
            }

            CspParameters cspp = new CspParameters();
            cspp.KeyContainerName = key;

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspp);
            rsa.PersistKeyInCsp = true;

            byte[] bytes = rsa.Encrypt(System.Text.UTF8Encoding.UTF8.GetBytes(stringToEncrypt), true);

            return BitConverter.ToString(bytes);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Decryptes a string using the supplied key. Decoding is done using RSA encryption.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentException">    Occurs when stringToDecrypt or key is null or empty. </exception>
        ///
        /// <param name="stringToDecrypt">  String that must be decrypted. </param>
        /// <param name="key">              Decryptionkey. </param>
        ///
        /// <returns>   The decrypted string or null if decryption failed. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string Decrypt(this string stringToDecrypt, string key)
        {
            string result = null;

            if (string.IsNullOrEmpty(stringToDecrypt))
            {
                throw new ArgumentException("An empty string value cannot be encrypted.");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Cannot decrypt using an empty key. Please supply a decryption key.");
            }

            try
            {
                CspParameters cspp = new CspParameters();
                cspp.KeyContainerName = key;

                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspp);
                rsa.PersistKeyInCsp = true;

                string[] decryptArray = stringToDecrypt.Split(new string[] { "-" }, StringSplitOptions.None);
                byte[] decryptByteArray = Array.ConvertAll<string, byte>(decryptArray, (s => Convert.ToByte(byte.Parse(s, System.Globalization.NumberStyles.HexNumber))));


                byte[] bytes = rsa.Decrypt(decryptByteArray, true);

                result = System.Text.UTF8Encoding.UTF8.GetString(bytes);

            }
            finally
            {
                // no need for further processing
            }

            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A string extension method that truncates. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="source">   The source to act on. </param>
        /// <param name="length">   The length. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string Truncate(this string source, int length)
        {
            if (source.Length > length)
            {
                source = source.Substring(0, length);
            }
            return source;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A string extension method that truncate left. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="source">   The source to act on. </param>
        /// <param name="length">   The length. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string TruncateLeft(this string source, int length)
        {
            if (source.Length > length)
            {
                source = source.Substring(source.Length - length, length);
            }
            return source;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// A string extension method that queries if a null white space or is empty.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="source">   The source to act on. </param>
        ///
        /// <returns>   True if a null white space or is empty, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsNullWhiteSpaceOrEmpty(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return true;
            return string.IsNullOrWhiteSpace(source);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A string extension method that encode for XML. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="stringToEncode">   The stringToEncode to act on. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string EncodeForXml(this string stringToEncode)
        {
            var badAmpersand = new Regex("&(?![a-zA-Z]{2,6};|#[0-9]{2,4};)");
            stringToEncode = badAmpersand.Replace(stringToEncode, "&amp;");
            //stringToEncode = stringToEncode.Replace("\"", "&quot;");
            //stringToEncode = stringToEncode.Replace("\'", "&apos;");
            //stringToEncode = stringToEncode.Replace("<", "&lt;");
            //stringToEncode = stringToEncode.Replace(">", "&gt;");
            //stringToEncode = stringToEncode.Replace("&", "&amp;");

            try
            {
                if (stringToEncode.ValidateXml())
                    return stringToEncode;
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

            //var encodedString = System.Security.SecurityElement.Escape(stringToEncode);


            //return encodedString;//.Replace("<", "&lt;").Replace(">", "gt;").Replace("\"", "&quot;");
        }

        public static bool ValidateXml(this string xml)
        {
            //try
            //{
            //    new XmlDocument().Load(xml);
            //    return true;
            //}
            //catch(Exception ex)
            //{
            //    return false;
            //}


            try
            {
                if (!string.IsNullOrEmpty(xml))
                {
                    System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                    xmlDoc.LoadXml(xml);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Xml.XmlException ex)
            {
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A string extension method that splits at upper case characters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="stringToSplit">    The stringToSplit to act on. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string SplitAtUpperCaseCharacters(this string stringToSplit)
        {
            // if it is not the first character and it is uppercase
            //  and the previous character is not uppercase then insert a space
            var result = stringToSplit.SelectMany((c, i) => i != 0 && char.IsUpper(c) && !char.IsUpper(stringToSplit[i - 1]) ? new char[] { ' ', c } : new char[] { c });
            return new String(result.ToArray());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A string extension method that query if 'strInput' is hexadecimal. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="strInput">         The strInput to act on. </param>
        /// <param name="allowLeadingX">    True to allow, false to deny leading x coordinate. </param>
        ///
        /// <returns>   True if hexadecimal, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsHexadecimal(this string strInput, bool allowLeadingX)
        {

            System.Text.RegularExpressions.Regex myRegex;
            if (allowLeadingX)
                myRegex = new System.Text.RegularExpressions.Regex("^(?:[x])?[a-fA-F0-9]+$");
            else
                myRegex = new System.Text.RegularExpressions.Regex("^[a-fA-F0-9]+$");
            //boolean variable to hold the status
            bool isValid = false;
            if (string.IsNullOrEmpty(strInput))
            {
                isValid = false;
            }
            else
            {
                isValid = myRegex.IsMatch(strInput);
            }
            //return the results
            return isValid;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A string extension method that query if 'strInput' is decimal. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="strInput"> The strInput to act on. </param>
        ///
        /// <returns>   True if decimal, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsDecimal(this string strInput)
        {

            System.Text.RegularExpressions.Regex myRegex = new System.Text.RegularExpressions.Regex("^[0-9]+$");
            //boolean variable to hold the status
            bool isValid = false;
            if (string.IsNullOrEmpty(strInput))
            {
                isValid = false;
            }
            else
            {
                isValid = myRegex.IsMatch(strInput);
            }
            //return the results
            return isValid;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A string extension method that reads from JSON. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="json">         The JSON to act on. </param>
        /// <param name="messageType">  Type of the message. </param>
        ///
        /// <returns>   The data that was read from the JSON. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static object ReadFromJson(this string json, string messageType)
        {
            var type = Type.GetType(messageType);
            return JsonConvert.DeserializeObject(json, type);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A string extension method that reads from JSON. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// 
        /// <param name="json">         The JSON to act on. </param>
        /// <param name="messageType">  Type of the message. </param>
        /// <param name="settings"></param>
        /// <returns>   The data that was read from the JSON. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static object ReadFromJson(this string json, string messageType, JsonSerializerSettings settings)
        {
            var type = Type.GetType(messageType);
            return JsonConvert.DeserializeObject(json, type, settings);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A string extension method that reads from JSON. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="json">         The JSON to act on. </param>
        /// <param name="messageType">  Type of the message. </param>
        ///
        /// <returns>   The data that was read from the JSON. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static T ReadFromJson<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static T ReadFromJson<T>(this string json, JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject<T>(json, settings);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// A string extension method that removes the special characters described by str.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="str">  The str to act on. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '-' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A string extension method that removes the special characters. </summary>
        ///
        /// <param name="str">                  The str to act on. </param>
        /// <param name="charactersToRemove">   The characters to remove. </param>
        ///
        /// <returns>   A string. </returns>
        ///=================================================================================================

        public static string RemoveSpecialCharacters(this string str, string charactersToRemove)
        {
            var invalidChars = charactersToRemove.ToCharArray();
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if (!invalidChars.Contains(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A string extension method that convert base 64 string to byte array. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="str">  The str to act on. </param>
        ///
        /// <returns>   The base converted 64 string to byte array. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static byte[] ConvertBase64StringToByteArray(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;
            return System.Convert.FromBase64String(str);
        }


        public static string Base64StringEncode(this string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            var encodedString = Convert.ToBase64String(bytes);

            return encodedString;
        }

        public static string EscapeForSql(this string str)
        {
            return str.Replace("'", "''");
        }

        //public static bool ToBoolean(this string str, bool defaultValue)
        //{
        //    bool bResult = defaultValue;
        //    if (bool.TryParse(str, out bResult))
        //        return bResult;
        //    return defaultValue;
        //}

        public static T ConvertTo<T>(this string input, T defaultValue)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    // Cast ConvertFromString(string text) : object to (T)
                    return (T)converter.ConvertFromString(input);
                }
                return defaultValue;//default(T);
            }
            catch (NotSupportedException)
            {
                return defaultValue;//default(T);
            }
        }

        public static string GenerateRandomString(int length = 40, bool startWithGuid = true)
        {
            var random = new Random((int)DateTimeOffset.Now.Ticks);
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

            if (startWithGuid)
            {
                var newGuid = Guid.NewGuid().ToString();
                var guidParts = newGuid.Split('-');
                newGuid = String.Empty;
                foreach (var p in guidParts)
                {
                    newGuid += p;
                }

                var result = newGuid;

                if (result.Length < length)
                {
                    var rs = new string(Enumerable.Repeat(chars, length - newGuid.Length)
                        .Select(s => s[random.Next(s.Length)]).ToArray());
                    result += rs;
                }

                return result;
            }

            var randomString = new string(Enumerable.Repeat(chars, length)
                                                    .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;

        }

        public static bool IsVersionLater(this string v1, string v2)
        {
            // split into groups
            string[] cur = v1.Split('.');
            string[] cmp = v2.Split('.');
            // get max length and fill the shorter one with zeros
            int len = Math.Max(cur.Length, cmp.Length);
            int[] vs = new int[len];
            int[] cs = new int[len];
            Array.Clear(vs, 0, len);
            Array.Clear(cs, 0, len);
            int idx = 0;
            // skip non digits
            foreach (string n in cur)
            {
                if (!Int32.TryParse(n, out vs[idx]))
                {
                    vs[idx] = -999; // mark for skip later
                }
                idx++;
            }
            idx = 0;
            foreach (string n in cmp)
            {
                if (!Int32.TryParse(n, out cs[idx]))
                {
                    cs[idx] = -999; // mark for skip later
                }
                idx++;
            }
            for (int i = 0; i < len; i++)
            {
                // skip non digits
                if ((vs[i] == -999) || (cs[i] == -999))
                {
                    continue;
                }
                if (vs[i] < cs[i])
                {
                    return (false);
                }
                else if (vs[i] > cs[i])
                {
                    return (true);
                }
            }
            return (true);
        }

        public static IEnumerable<Guid> ToIEnumerableGuid(this string stringToSplit, char splitChar)
        {
            var results = new HashSet<Guid>();
            if (string.IsNullOrEmpty(stringToSplit))
                return results;
            var parts = stringToSplit.Split(splitChar);
            foreach (var part in parts)
            {
                var g = Guid.Empty;
                if (Guid.TryParse(part, out g))
                    results.Add(g);
            }

            return results;
        }

        public static IEnumerable<T> ToIEnumerableOf<T>(this string stringToSplit, char splitChar)
        {
            var results = new HashSet<T>();
            if (string.IsNullOrEmpty(stringToSplit))
                return results;
            
            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter != null)
            {
                var parts = stringToSplit.Split(splitChar);
                foreach (var part in parts)
                {
                    try
                    {
                        var x = (T) converter.ConvertFromString(part);
                        results.Add(x);
                    }
                    catch (NotSupportedException)
                    {
                    }
                }
            }

            return results;
        }

        public static IEnumerable<string> ToIEnumerableString(this string stringToSplit, char splitChar)
        {
            var results = new HashSet<string>();
            if (string.IsNullOrEmpty(stringToSplit))
                return results;
            var parts = stringToSplit.Split(splitChar);
            results.AddRange(parts);
            return results;
        }

        public static bool Contains(this String str, String substring,
            StringComparison comp)
        {
            if (substring == null)
                throw new ArgumentNullException("substring",
                    "substring cannot be null.");
            else if (!Enum.IsDefined(typeof(StringComparison), comp))
                throw new ArgumentException("comp is not a member of StringComparison",
                    "comp");

            return str.IndexOf(substring, comp) >= 0;
        }
    }
}
