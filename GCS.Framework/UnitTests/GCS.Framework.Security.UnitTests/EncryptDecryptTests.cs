using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Security.UnitTests
{
    [TestClass]
    public class EncryptDecryptTests
    {
         [TestMethod]
        public void test_EncryptString()
        {
            var encryptThis = "encrypt this string";
            var passphrase = "1234567890-tESTpHRASE";
            string encryptedString = GCS.Framework.Security.Crypto.EncryptString(encryptThis, passphrase, Crypto.EncodingType.Unicode);
            string decryptedString = GCS.Framework.Security.Crypto.DecryptString(encryptedString, passphrase, Crypto.EncodingType.Unicode);
            Assert.AreEqual(encryptThis, decryptedString);
        }

        [TestMethod]
        public void test_Encrypt()
        {  
            var passphrase = "1234567890-tESTpHRASE";
            var stringsToEncrypt = new List<string>();
            stringsToEncrypt.Add("123456");
            stringsToEncrypt.Add("123456789");
            stringsToEncrypt.Add("qwerty");
            stringsToEncrypt.Add("password");
            stringsToEncrypt.Add("111111");
            stringsToEncrypt.Add("12345678");
            stringsToEncrypt.Add("abc123");
            stringsToEncrypt.Add("1234567");
            stringsToEncrypt.Add("password1");
            stringsToEncrypt.Add("12345");
            var passwordGen = new PasswordGeneratorValidator();
            for( int x = 0; x < 1000; x++)
                stringsToEncrypt.Add(passwordGen.GeneratePassword(16));

            foreach (var s in stringsToEncrypt)
            {
                string encryptedString = GCS.Framework.Security.Crypto.Encrypt(s, passphrase, Crypto.EncodingType.Unicode);
                string decryptedString = GCS.Framework.Security.Crypto.Decrypt(encryptedString, passphrase, Crypto.EncodingType.Unicode);
                Assert.AreEqual(s, decryptedString);
            }
        }


   }
}
