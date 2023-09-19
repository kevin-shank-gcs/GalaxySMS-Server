using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GCS.Security
{
	public class AesCrypto
	{
		public const int KEY_SIZE = 16;
		public const int BUFFER_SIZE = 16;

		static public byte[] EncryptBytesToBytes_AES(byte[] plain, byte[] Key)//, byte[] IV)
		{
			// Check arguments.
			if (plain == null || plain.Length <= 0)
				throw new ArgumentNullException("plain");
			if (Key == null || Key.Length <= 0)
				throw new ArgumentNullException("Key");
			//if (IV == null || IV.Length <= 0)
			//    throw new ArgumentNullException("IV");

			// Declare the streams used
			// to encrypt to an in memory
			// array of bytes.
			MemoryStream msEncrypt = null;
			CryptoStream csEncrypt = null;
			//           StreamWriter swEncrypt = null;

			// Declare the RijndaelManaged object
			// used to encrypt the data.
			RijndaelManaged aesAlg = null;

			// Declare the bytes used to hold the
			// encrypted data.
			byte[] encrypted = null;

			try
			{
				// Create a RijndaelManaged object
				// with the specified key and IV.
				aesAlg = new RijndaelManaged();
				aesAlg.Key = Key;
				aesAlg.IV = new byte[aesAlg.IV.Length];// IV;
				aesAlg.Padding = PaddingMode.Zeros;// PaddingMode.None;
				//                aesAlg.BlockSize = AESCrypto.BUFFER_SIZE;
				//                aesAlg.BlockSize
				// Create a decrytor to perform the stream transform.
				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

				// Create the streams used for encryption.
				msEncrypt = new MemoryStream();
				csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
				//swEncrypt = new StreamWriter(csEncrypt);

				////Write all data to the stream.
				//swEncrypt.Write(plain);
				//Write all data to the crypto stream and flush it.
				csEncrypt.Write(plain, 0, plain.Length);
				csEncrypt.FlushFinalBlock();

				//Get encrypted array of bytes.
				encrypted = msEncrypt.ToArray();
			}
			catch (Exception ex)
			{
				string s = ex.ToString();
			}
			finally
			{
				// Clean things up.

				// Close the streams.
				//if (swEncrypt != null)
				//    swEncrypt.Close();
				if (csEncrypt != null)
					csEncrypt.Close();
				if (msEncrypt != null)
					msEncrypt.Close();

				// Clear the RijndaelManaged object.
				if (aesAlg != null)
					aesAlg.Clear();
			}

			// Return the encrypted bytes from the memory stream.
			return encrypted;

		}

		static public byte[] DecryptBytesFromBytes_AES(byte[] cipher, byte[] Key)//, byte[] IV)
		{
			// Check arguments.
			if (cipher == null || cipher.Length <= 0)
				throw new ArgumentNullException("cipher");
			if (Key == null || Key.Length <= 0)
				throw new ArgumentNullException("Key");
			//if (IV == null || IV.Length <= 0)
			//    throw new ArgumentNullException("IV");

			byte[] bPlain = new byte[cipher.Length];
			// TDeclare the streams used
			// to decrypt to an in memory
			// array of bytes.
			MemoryStream msDecrypt = null;
			CryptoStream csDecrypt = null;
			//           StreamReader srDecrypt = null;

			// Declare the RijndaelManaged object
			// used to decrypt the data.
			RijndaelManaged aesAlg = null;

			// Declare the string used to hold
			// the decrypted text.

			try
			{
				// Create a RijndaelManaged object
				// with the specified key and IV.
				aesAlg = new RijndaelManaged();
				aesAlg.Key = Key;
				aesAlg.IV = new byte[aesAlg.IV.Length];//cipher.Length];// IV;
				aesAlg.Padding = PaddingMode.Zeros;// PaddingMode.None;

				// Create a decrytor to perform the stream transform.
				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

				// Create the streams used for decryption.
				msDecrypt = new MemoryStream(cipher);
				csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
				//               srDecrypt = new StreamReader(csDecrypt);

				//// Read the decrypted bytes from the decrypting stream
				//// and place them in a buffer.
				//               int count = srDecrypt.ReadBlock(plain, 0, cipher.Length);

				//Read the data out of the crypto stream.
				csDecrypt.Read(bPlain, 0, bPlain.Length);
			}
			catch (Exception ex)
			{
				string s = ex.ToString();
			}
			finally
			{
				// Clean things up.

				// Close the streams.
				//if (srDecrypt != null)
				//    srDecrypt.Close();
				if (csDecrypt != null)
					csDecrypt.Close();
				if (msDecrypt != null)
					msDecrypt.Close();

				// Clear the RijndaelManaged object.
				if (aesAlg != null)
					aesAlg.Clear();
			}

			return bPlain;

		}

		public class FixedSizeMessage
		{
			byte[] m_Msg;
			string m_sMsg = string.Empty;
			byte[] m_Tag;

			public FixedSizeMessage(string msg)
			{
				m_Msg = new byte[KEY_SIZE];
				m_Tag = new byte[KEY_SIZE];
				m_sMsg = msg;
				for (int x = 0; x < msg.Length; x++)
				{
					if (x >= m_Msg.Length)
						break;
					m_Msg[x] = (byte)msg[x];
				}
			}

			public FixedSizeMessage(byte[] msg)
			{
				m_Msg = new byte[KEY_SIZE];
				m_Tag = new byte[msg.Length - m_Msg.Length];
				for (int x = 0; x < msg.Length; x++)
				{
					if (x < m_Msg.Length)
						m_Msg[x] = msg[x];
					else
					{
						m_Tag[x - KEY_SIZE] = (byte)msg[x];
					}
				}
				m_sMsg = Msg;
			}

			public string Msg
			{
				get
				{
					string s = string.Empty;
					for (int x = 0; x < m_Msg.Length; x++)
					{
						if (m_Msg[x] == 0)
							break;
						s += (char)m_Msg[x];
					}
					return s;
				}
			}

			public byte[] MsgRaw
			{
				get { return m_Msg; }
			}

			public byte[] Tag
			{
				get { return m_Tag; }
			}

			public bool CreateAESEncryptedTag(byte[] key)
			{
				//               byte[] iv = new byte[m_Msg.Length];//myRijndael.IV.Length];
				m_Tag = EncryptBytesToBytes_AES(m_Msg, key);//, iv );//myRijndael.Key, iv);
				//               byte[] decrypted = DecryptBytesFromBytes_AES(m_Tag, key, iv);// myRijndael.Key, iv);
				return true;

			}

			public byte[] GetBytes()
			{
				byte[] ba = new byte[GetLength()];
				int x = 0;
				for (int y = 0; y < m_Msg.Length; y++)
					ba[x++] = m_Msg[y];
				for (int y = 0; y < m_Tag.Length; y++)
					ba[x++] = (byte)m_Tag[y];

				return ba;
			}

			public int GetLength()
			{
				int len = m_Msg.Length + m_Tag.Length;
				return len;
			}

			public bool Compare(byte[] data)
			{
				byte[] myData = GetBytes();
				for (int x = 0; x < data.Length; x++)
				{
					if (x >= myData.Length)
						return false;
					if (myData[x] != data[x])
						return false;
				}
				return true;
			}

			public byte[] DecryptTag(byte[] key)
			{
				//             byte[] iv = new byte[key.Length];
				return DecryptBytesFromBytes_AES(m_Tag, key);//, iv);
			}
		}

		//static byte[] EncryptStringToBytes_AES(string plainText, byte[] Key, byte[] IV)
		//{
		//    // Check arguments.
		//    if (plainText == null || plainText.Length <= 0)
		//        throw new ArgumentNullException("plainText");
		//    if (Key == null || Key.Length <= 0)
		//        throw new ArgumentNullException("Key");
		//    if (IV == null || IV.Length <= 0)
		//        throw new ArgumentNullException("Key");

		//    // Declare the streams used
		//    // to encrypt to an in memory
		//    // array of bytes.
		//    MemoryStream msEncrypt = null;
		//    CryptoStream csEncrypt = null;
		//    StreamWriter swEncrypt = null;

		//    // Declare the RijndaelManaged object
		//    // used to encrypt the data.
		//    RijndaelManaged aesAlg = null;

		//    // Declare the bytes used to hold the
		//    // encrypted data.
		//    byte[] encrypted = null;

		//    try
		//    {
		//        // Create a RijndaelManaged object
		//        // with the specified key and IV.
		//        aesAlg = new RijndaelManaged();
		//        aesAlg.Key = Key;
		//        aesAlg.IV = IV;

		//        // Create a decrytor to perform the stream transform.
		//        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

		//        // Create the streams used for encryption.
		//        msEncrypt = new MemoryStream();
		//        csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
		//        swEncrypt = new StreamWriter(csEncrypt);

		//        //Write all data to the stream.
		//        swEncrypt.Write(plainText);

		//    }
		//    finally
		//    {
		//        // Clean things up.

		//        // Close the streams.
		//        if (swEncrypt != null)
		//            swEncrypt.Close();
		//        if (csEncrypt != null)
		//            csEncrypt.Close();
		//        if (msEncrypt != null)
		//            msEncrypt.Close();

		//        // Clear the RijndaelManaged object.
		//        if (aesAlg != null)
		//            aesAlg.Clear();
		//    }

		//    // Return the encrypted bytes from the memory stream.
		//    return msEncrypt.ToArray();

		//}

		//static string EecryptStringFromBytes_AES(byte[] cipherText, byte[] Key, byte[] IV)
		//{
		//    // Check arguments.
		//    if (cipherText == null || cipherText.Length <= 0)
		//        throw new ArgumentNullException("cipherText");
		//    if (Key == null || Key.Length <= 0)
		//        throw new ArgumentNullException("Key");
		//    if (IV == null || IV.Length <= 0)
		//        throw new ArgumentNullException("Key");

		//    // TDeclare the streams used
		//    // to decrypt to an in memory
		//    // array of bytes.
		//    MemoryStream msDecrypt = null;
		//    CryptoStream csDecrypt = null;
		//    StreamReader srDecrypt = null;

		//    // Declare the RijndaelManaged object
		//    // used to decrypt the data.
		//    RijndaelManaged aesAlg = null;

		//    // Declare the string used to hold
		//    // the decrypted text.
		//    string plaintext = null;

		//    try
		//    {
		//        // Create a RijndaelManaged object
		//        // with the specified key and IV.
		//        aesAlg = new RijndaelManaged();
		//        aesAlg.Key = Key;
		//        aesAlg.IV = IV;

		//        // Create a decrytor to perform the stream transform.
		//        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

		//        // Create the streams used for decryption.
		//        msDecrypt = new MemoryStream(cipherText);
		//        csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
		//        srDecrypt = new StreamReader(csDecrypt);

		//        // Read the decrypted bytes from the decrypting stream
		//        // and place them in a string.
		//        plaintext = srDecrypt.ReadToEnd();
		//    }
		//    finally
		//    {
		//        // Clean things up.

		//        // Close the streams.
		//        if (srDecrypt != null)
		//            srDecrypt.Close();
		//        if (csDecrypt != null)
		//            csDecrypt.Close();
		//        if (msDecrypt != null)
		//            msDecrypt.Close();

		//        // Clear the RijndaelManaged object.
		//        if (aesAlg != null)
		//            aesAlg.Clear();
		//    }

		//    return plaintext;

		//}


	}
}
