using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GCS.Framework.Security.UnitTests
{
    [TestClass]
    public class PasswordGeneratorValidatorTest
    {
        [TestMethod]
        public void test_GeneratePassword()
        {
            PasswordGeneratorValidator objTest = new PasswordGeneratorValidator();
            GeneratePasswordParameters passwordParams = new GeneratePasswordParameters()
            {
                IncludeLowerCaseCharacterCount = 4,
                IncludeUpperCaseCharacterCount = 4,
                IncludeNumericDigitCount = 3,
                IncludeSpecialCharacterCount = 2,
                MinimumLength = 4,
                MaximumLength = 13
            };
            passwordParams.ExcludeChar('O');
            passwordParams.ExcludeChar('I');
            passwordParams.ExcludeChar('0');
            passwordParams.ExcludeChar('1');

            string password = objTest.GeneratePassword(passwordParams);
            System.Diagnostics.Trace.WriteLine(password);
            Assert.IsTrue(password.Length == passwordParams.MaximumLength, string.Format("GeneratePassword password length should have been {0}", passwordParams.MaximumLength));
        }

        [TestMethod]
        public void test_GenerateTwoFactorCode()
        {
            for (int x = 0; x < 100; x++)
            {
                using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
                {
                    byte[] rno = new byte[5];
                    rg.GetBytes(rno);
                    var randomvalue = BitConverter.ToUInt32(rno, 0);
                    var finalValue = randomvalue % 999999;
                    if( finalValue < 100000)
                        finalValue += 100000;

                    Trace.WriteLine(string.Format("{0}:{1}",randomvalue, finalValue));
                }
            }
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void test_GenerateStrongPassword()
        {
            PasswordGeneratorValidator objTest = new PasswordGeneratorValidator();
            int length = 20;
            string password = string.Empty;
            //for (int x = 0; x < 20; x++)
            //{
            //    password = objTest.GenerateStrongPassword(length);
            //    System.Diagnostics.Trace.WriteLine(password);
            //}
            password = objTest.GeneratePassword(length);
            Assert.IsTrue(password.Length == length, string.Format("GenerateStrongPassword password length should have been {0}", length));

        }

        // REGULAR EXPRESSION LIBRARY
        // http://regexlib.com/Search.aspx?k=password&c=-1&m=5&ps=20. 
        [TestMethod]
        public void test_ValidatePassword()
        {
            List<string> passwordsToValidate = new List<string>();
            passwordsToValidate.Add("12qwAS!@");
            passwordsToValidate.Add("12qwAS!$");
            PasswordGeneratorValidator objTest = new PasswordGeneratorValidator();
            ValidatePasswordParameters parameters = new ValidatePasswordParameters();
            IEnumerable<PasswordValidationResult> result;
            parameters.MinimumLength = 4;
            parameters.MaximumLength = 10;
            parameters.RequiredLowerCaseCharacterCount = 2;
            parameters.RequiredUpperCaseCharacterCount = 2;
            parameters.RequiredNumericDigitCount = 2;
            parameters.RequiredSpecialCharacterCount = 2;
            foreach (string password in passwordsToValidate)
            {
                result = objTest.ValidatePassword(password, parameters);
                foreach (PasswordValidationResult res in result)
                    Assert.IsTrue(res == PasswordValidationResult.Valid);
            }

            passwordsToValidate.Clear();
            string pwd = "12QWER$#";
            result = objTest.ValidatePassword(pwd, parameters);
            foreach (string password in passwordsToValidate)
            {
                result = objTest.ValidatePassword(password, parameters);
                foreach (PasswordValidationResult res in result)
                    Assert.IsTrue(res == PasswordValidationResult.InsufficientLowerCaseCharacters);
            }

            pwd = "12Qsdf$#";
            result = objTest.ValidatePassword(pwd, parameters);
            foreach (string password in passwordsToValidate)
            {
                result = objTest.ValidatePassword(password, parameters);
                foreach (PasswordValidationResult res in result)
                    Assert.IsTrue(res == PasswordValidationResult.InsufficientUpperCaseCharacters);
            }

            pwd = "1QRsdf$#";
            result = objTest.ValidatePassword(pwd, parameters);
            foreach (string password in passwordsToValidate)
            {
                result = objTest.ValidatePassword(password, parameters);
                foreach (PasswordValidationResult res in result)
                    Assert.IsTrue(res == PasswordValidationResult.InsufficientNumericDigits);
            }

            pwd = "12QRsdf";
            result = objTest.ValidatePassword(pwd, parameters);
            foreach (string password in passwordsToValidate)
            {
                result = objTest.ValidatePassword(password, parameters);
                foreach (PasswordValidationResult res in result)
                    Assert.IsTrue(res == PasswordValidationResult.InsufficientSpecialCharacters);
            }

            parameters.UseCustomRegularExpression = true;
            parameters.CustomRegularExpression =
                "(?-i)(?=^.{8,}$)((?!.*\\s)(?=.*[A-Z])(?=.*[a-z]))((?=(.*\\d){1,})|(?=(.*\\W){1,}))^.*$";
            pwd = "spR1ng14";
            result = objTest.ValidatePassword(pwd, parameters);
            foreach (string password in passwordsToValidate)
            {
                result = objTest.ValidatePassword(password, parameters);
                foreach (PasswordValidationResult res in result)
                    Assert.IsTrue(res == PasswordValidationResult.Valid);
            }

            pwd = "SpringSp ";
            result = objTest.ValidatePassword(pwd, parameters);
            foreach (string password in passwordsToValidate)
            {
                result = objTest.ValidatePassword(password, parameters);
                foreach (PasswordValidationResult res in result)
                    Assert.IsTrue(res == PasswordValidationResult.InvalidDoesNotMatchRegularExpression);
            }

        }

        [TestMethod]
        public void test_ReadablePhrases()
        {
            var generator = new PasswordGeneratorValidator();
            for (int x = 0; x < 100; x++)
            {
                var pwd = generator.GenerateReadablePhrase(ReadablePhraseStrength.NormalRequiredSpeech, 200);
                Trace.WriteLine(pwd);
            }

            Assert.IsTrue(true);

        }

        [TestMethod]
        public void test_GenerateCloudStylePassword()
        {
            var minLength = 17;
            var maxLength = 65;
            foreach (ReadablePhraseStrength s in Enum.GetValues(typeof(ReadablePhraseStrength)))
            {
                if( s == ReadablePhraseStrength.Custom)
                    continue;

                Trace.WriteLine($"");
                Trace.WriteLine($"----- {s.ToString()} -----");
                for (int x = 0; x < 10; x++)
                {
                    var pwd = PasswordGeneratorValidator.GenerateCloudStylePassword(minLength, maxLength, 4, 6, s);
                    Assert.IsTrue(pwd.Length >= minLength && pwd.Length <= maxLength, $"Invalid length:{pwd.Length}");
                    Trace.WriteLine(pwd);
                }
            }

            Assert.IsTrue(true);

        }
    }
}
