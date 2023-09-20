using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Security
{
    //public interface ITextEncoding
    //{
    //    byte[] GetBytes(string s);
    //    string GetString(byte[] bytes);
    //}

    public class Crypto
    {
        public enum EncodingType { UTF8, Unicode };
        //public static string EncryptString(string Message, string Passphrase, EncodingType encodingType = EncodingType.Unicode)
        //{
        //    if (Message == null)
        //        return string.Empty;

        //    byte[] Results;
        //    //UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
        //    ITextEncoding encoding = null;
        //    switch (encodingType)
        //    {
        //        case EncodingType.UTF8:
        //            encoding = new UTF8Encoding() as ITextEncoding;
        //            break;

        //        case EncodingType.Unicode:
        //            encoding = new UnicodeEncoding() as ITextEncoding;
        //            break;
        //    }

        //    // Step 1. We hash the passphrase using MD5
        //    // We use the MD5 hash generator as the result is a 128 bit byte array
        //    // which is a valid length for the TripleDES encoder we use below

        //    MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
        //    byte[] TDESKey = HashProvider.ComputeHash(encoding.GetBytes(Passphrase));

        //    // Step 2. Create a new TripleDESCryptoServiceProvider object
        //    TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

        //    // Step 3. Setup the encoder
        //    TDESAlgorithm.Key = TDESKey;
        //    TDESAlgorithm.Mode = CipherMode.ECB;
        //    TDESAlgorithm.Padding = PaddingMode.PKCS7;

        //    // Step 4. Convert the input string to a byte[]
        //    byte[] DataToEncrypt = encoding.GetBytes(Message);

        //    // Step 5. Attempt to encrypt the string
        //    try
        //    {
        //        ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
        //        Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
        //    }
        //    finally
        //    {
        //        // Clear the TripleDes and Hashprovider services of any sensitive information
        //        TDESAlgorithm.Clear();
        //        HashProvider.Clear();
        //    }

        //    // Step 6. Return the encrypted string as a base64 encoded string
        //    return Convert.ToBase64String(Results);
        //}
        public static string EncryptString(string Message, string Passphrase, EncodingType encodingType = EncodingType.Unicode)
        {
            if (Message == null)
                return string.Empty;

            byte[] Results;
            //UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            Encoding encoding = null;
            switch (encodingType)
            {
                case EncodingType.UTF8:
                    encoding = new UTF8Encoding();
                    break;

                case EncodingType.Unicode:
                    encoding = new UnicodeEncoding();
                    break;
            }

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(encoding.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = encoding.GetBytes(Message);

            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the encrypted string as a base64 encoded string
            return Convert.ToBase64String(Results);
        }

        //public static string DecryptString(string Message, string Passphrase, EncodingType encodingType = EncodingType.Unicode)
        //{
        //    if (string.IsNullOrEmpty(Message) || string.IsNullOrWhiteSpace(Message))
        //        return string.Empty;

        //    try
        //    {
        //        byte[] Results;
        //        ITextEncoding encoding = null;
        //        switch (encodingType)
        //        {
        //            case EncodingType.UTF8:
        //                encoding = new UTF8Encoding() as ITextEncoding;
        //                break;

        //            case EncodingType.Unicode:
        //                encoding = new UnicodeEncoding() as ITextEncoding;
        //                break;
        //        }

        //        // Step 1. We hash the Passphrase using MD5
        //        // We use the MD5 hash generator as the result is a 128 bit byte array
        //        // which is a valid length for the TripleDES encoder we use below

        //        MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
        //        byte[] TDESKey = HashProvider.ComputeHash(encoding.GetBytes(Passphrase));

        //        // Step 2. Create a new TripleDESCryptoServiceProvider object
        //        TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

        //        // Step 3. Setup the decoder
        //        TDESAlgorithm.Key = TDESKey;
        //        TDESAlgorithm.Mode = CipherMode.ECB;
        //        TDESAlgorithm.Padding = PaddingMode.PKCS7;

        //        // Step 4. Convert the input string to a byte[]
        //        byte[] DataToDecrypt = Convert.FromBase64String(Message);

        //        // Step 5. Attempt to decrypt the string
        //        try
        //        {
        //            ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
        //            Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
        //        }
        //        catch (Exception e)
        //        {
        //            return string.Empty;
        //        }
        //        finally
        //        {
        //            // Clear the TripleDes and HashProvider services of any sensitive information
        //            TDESAlgorithm.Clear();
        //            HashProvider.Clear();
        //        }

        //        // Step 6. Return the decrypted string in UTF8 format
        //        return encoding.GetString(Results);
        //    }
        //    catch (Exception e)
        //    {
        //        return string.Empty;
        //    }
        //}
        public static string DecryptString(string Message, string Passphrase, EncodingType encodingType = EncodingType.Unicode)
        {
            if (string.IsNullOrEmpty(Message) || string.IsNullOrWhiteSpace(Message))
                return string.Empty;

            try
            {
                byte[] Results;
                Encoding encoding = null;
                switch (encodingType)
                {
                    case EncodingType.UTF8:
                        encoding = new UTF8Encoding();
                        break;

                    case EncodingType.Unicode:
                        encoding = new UnicodeEncoding();
                        break;
                }

                // Step 1. We hash the Passphrase using MD5
                // We use the MD5 hash generator as the result is a 128 bit byte array
                // which is a valid length for the TripleDES encoder we use below

                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(encoding.GetBytes(Passphrase));

                // Step 2. Create a new TripleDESCryptoServiceProvider object
                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

                // Step 3. Setup the decoder
                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;

                // Step 4. Convert the input string to a byte[]
                byte[] DataToDecrypt = Convert.FromBase64String(Message);

                // Step 5. Attempt to decrypt the string
                try
                {
                    ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                    Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
                }
                catch (Exception e)
                {
                    return string.Empty;
                }
                finally
                {
                    // Clear the TripleDes and HashProvider services of any sensitive information
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }

                // Step 6. Return the decrypted string in UTF8 format
                return encoding.GetString(Results);
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public static string ReadEncryptedFileAsString(string sFilename, string sCryptoKey, EncodingType encodingType = EncodingType.Unicode)
        {
            string s = string.Empty;
            try
            {
                string sFileText = System.IO.File.ReadAllText(sFilename);
                s = Crypto.DecryptString(sFileText, sCryptoKey, encodingType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return s;
        }

        public static void WriteStringToEncryptedFile(string sFilename, string sValue, string sCryptoKey, EncodingType encodingType = EncodingType.Unicode)
        {
            try
            {
                string sEncrypted = Crypto.EncryptString(sValue, sCryptoKey, encodingType);
                System.IO.StreamWriter writer = System.IO.File.CreateText(sFilename);
                writer.WriteLine(sEncrypted);
                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
