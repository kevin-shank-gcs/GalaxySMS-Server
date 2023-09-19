using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GCS.Framework.Security
{
    public class PasswordValidationException : ApplicationException
    {
        public PasswordValidationException(string message)
            : this(message, null)
        {
            ValidationResults = new ReadOnlyCollection<PasswordValidationResult>(new List<PasswordValidationResult>());
        }

        public PasswordValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
            ValidationResults = new ReadOnlyCollection<PasswordValidationResult>(new List<PasswordValidationResult>());
        }
        public PasswordValidationException(string message, Exception innerException, IEnumerable<PasswordValidationResult> validationResults )
            : base(message, innerException)
        {
            var results = new List<PasswordValidationResult>();
            foreach (PasswordValidationResult res in validationResults.ToList())
                results.Add(res);
            ValidationResults = new ReadOnlyCollection<PasswordValidationResult>(results);

        }

        public override string ToString()
        {
            if (ValidationResults == null || ValidationResults.Count == 0)
                return base.Message;
            string s = string.Empty;
            foreach (PasswordValidationResult res in ValidationResults)
            {
                if (s.Length > 0)
                    s += "\n";
                s += res.ToString();
            }
            return s;
        }

        public ReadOnlyCollection<PasswordValidationResult> ValidationResults { get; internal set; }
    }
    public class GeneratePasswordParameters
    {
        public GeneratePasswordParameters()
        {
            MinimumLength = 4;
            MaximumLength = 8;
            IncludeLowerCaseCharacterCount = 0;
            IncludeUpperCaseCharacterCount = 0;
            IncludeNumericDigitCount = 0;
            IncludeSpecialCharacterCount = 0;
        }

        public int MinimumLength { get; set; }
        public int MaximumLength { get; set; }
        public int IncludeUpperCaseCharacterCount { get; set; }
        public int IncludeLowerCaseCharacterCount { get; set; }
        public int IncludeNumericDigitCount { get; set; }
        public int IncludeSpecialCharacterCount { get; set; }
    }

    // http://regexlib.com/Search.aspx?k=password&c=-1&m=5&ps=20
    public class ValidatePasswordParameters
    {
        public ValidatePasswordParameters()
        {
            MinimumLength = 4;
            MaximumLength = 8;
            RequiredLowerCaseCharacterCount = 0;
            RequiredUpperCaseCharacterCount = 0;
            RequiredNumericDigitCount = 0;
            RequiredSpecialCharacterCount = 0;
            UseCustomRegularExpression = false;
            CustomRegularExpression = string.Empty;
            IllegalContents = new List<string>();
        }
        public int MinimumLength { get; set; }
        public int MaximumLength { get; set; }
        public int RequiredUpperCaseCharacterCount { get; set; }
        public int RequiredLowerCaseCharacterCount { get; set; }
        public int RequiredNumericDigitCount { get; set; }
        public int RequiredSpecialCharacterCount { get; set; }
        public bool UseCustomRegularExpression { get; set; }
        public string CustomRegularExpression { get; set; }
        public List<string> IllegalContents { get; internal set; }

        public void AddIllegalContent(string s)
        {
            if (string.IsNullOrEmpty(s))
                return;
            if (string.IsNullOrWhiteSpace(s))
                return;

            if( IllegalContents.Contains(s.Trim()) == false)
                IllegalContents.Add(s.Trim());
        }
    }
    public enum PasswordValidationResult
    {
        Unknown,
        Valid,
        InvalidIsEmpty,
        InvalidLengthToShort,
        InvalidLengthToLong,
        InsufficientUpperCaseCharacters,
        InsufficientLowerCaseCharacters,
        InsufficientNumericDigits,
        InsufficientSpecialCharacters,
        InvalidMatchesPreviousPassword,
        InsufficientNumberOfCharactersChanged,
        InvalidContainsIllegalContent,
        InvalidDoesNotMatchRegularExpression,
        InvalidParameter,

    }

    public class PasswordGeneratorValidator
    {
        private static string _alphaCaps = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string _alphaLow = "abcdefghijklmnopqrstuvwxyz";
        private static string _numerics = "0123456789";
        private static string _special = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";

        //create another string which is a concatenation of all above
        private string _allChars = _alphaCaps + _alphaLow + _numerics + _special;

        Random _r = new Random();

        const Int32 defaultMinimumLength = 4;

        public PasswordGeneratorValidator()
        {

        }

        public IEnumerable<PasswordValidationResult> ValidatePassword(string password, ValidatePasswordParameters parameters)
        {
            List<PasswordValidationResult> results = new List<PasswordValidationResult>();
            //System.Diagnostics.Trace.WriteLine(_special);
            if (password == null)
            {
                results.Add(PasswordValidationResult.InvalidIsEmpty);
                return results;
            }

            if (parameters == null)
                throw new ArgumentNullException("parameters");

            if( string.IsNullOrEmpty(password))
                results.Add(PasswordValidationResult.InvalidIsEmpty);
            else if (string.IsNullOrWhiteSpace(password))
                results.Add(PasswordValidationResult.InvalidIsEmpty);
               
            if (parameters.UseCustomRegularExpression == false)
            {
                if (password.Length < parameters.MinimumLength)
                    results.Add(PasswordValidationResult.InvalidLengthToShort);
                else if (password.Length > parameters.MaximumLength)
                    results.Add(PasswordValidationResult.InvalidLengthToLong);

                int lowerCaseCount = 0;
                int upperCaseCount = 0;
                int numberCount = 0;
                int specialCount = 0;

                foreach (char c in password)
                {
                    if (Char.IsLower(c))
                        lowerCaseCount++;
                    else if (Char.IsUpper(c))
                        upperCaseCount++;
                    else if (Char.IsDigit(c))
                        numberCount++;
                    else if (_special.Contains(c))
                        specialCount++;
                }
                if (parameters.RequiredUpperCaseCharacterCount != 0 && upperCaseCount < parameters.RequiredUpperCaseCharacterCount)
                    results.Add(PasswordValidationResult.InsufficientUpperCaseCharacters);
                if (parameters.RequiredLowerCaseCharacterCount != 0 && lowerCaseCount < parameters.RequiredLowerCaseCharacterCount)
                    results.Add(PasswordValidationResult.InsufficientLowerCaseCharacters);
                if (parameters.RequiredNumericDigitCount != 0 && numberCount < parameters.RequiredNumericDigitCount)
                    results.Add(PasswordValidationResult.InsufficientNumericDigits);
                if (parameters.RequiredSpecialCharacterCount != 0 && specialCount < parameters.RequiredSpecialCharacterCount)
                    results.Add(PasswordValidationResult.InsufficientSpecialCharacters);

                foreach (string sIllegal in parameters.IllegalContents)
                {
                    string sTestFor = sIllegal.Trim().ToUpperInvariant();
                    if (string.IsNullOrEmpty(sTestFor))
                        continue;
                    if (password.Trim().ToUpperInvariant().Contains(sTestFor))
                    {
                        results.Add(PasswordValidationResult.InvalidContainsIllegalContent);
                        break;
                    }
                }

                if( results.Count == 0 )
                    results.Add(PasswordValidationResult.Valid);
                return results;
            }
            else
            {
                try
                {
                    var regex = new Regex(parameters.CustomRegularExpression);
                    if (regex.IsMatch(password) == true)
                    {
                        foreach (string sIllegal in parameters.IllegalContents)
                        {
                            if (password.Trim().ToUpperInvariant().Contains(sIllegal.Trim().ToUpperInvariant()))
                            {
                                results.Add(PasswordValidationResult.InvalidContainsIllegalContent);
                                break;
                            }
                        }
                        if( results.Count == 0 )
                            results.Add(PasswordValidationResult.Valid);
                        return results;
                    }
                    return results;
                }
                catch (ArgumentNullException e)
                {
                    throw new ArgumentNullException("ValidatePassword CustomRegularExpression is null", e);
                }
                catch (ArgumentException e)
                {
                    throw new ArgumentException("ValidatePassword CustomRegularExpression is not a valid regular expression", e);
                }
                catch (Exception e)
                {
                    throw new Exception("ValidatePassword incurred an exception.", e);
                }
            }
        }

        public string GeneratePassword(GeneratePasswordParameters parameters)
        {
            if (parameters == null)
                parameters = new GeneratePasswordParameters();

            int requiredCharactersCount = parameters.IncludeLowerCaseCharacterCount +
                                          parameters.IncludeUpperCaseCharacterCount +
                                          parameters.IncludeNumericDigitCount +
                                          parameters.IncludeSpecialCharacterCount;

            if (requiredCharactersCount == 0)
            {
                parameters.IncludeUpperCaseCharacterCount = 4;
                parameters.IncludeLowerCaseCharacterCount = 4;
                requiredCharactersCount = parameters.IncludeLowerCaseCharacterCount +
                                          parameters.IncludeUpperCaseCharacterCount;
            }

            if (parameters.MinimumLength < requiredCharactersCount)
                parameters.MinimumLength = requiredCharactersCount;

            if (parameters.MinimumLength > parameters.MaximumLength)
                parameters.MinimumLength = parameters.MaximumLength;

            if (parameters.MaximumLength < parameters.MinimumLength)
                parameters.MaximumLength = parameters.MinimumLength;


            Random r = new Random();
            double rand;
            string useTheseCharacters = string.Empty;
            if (parameters.IncludeLowerCaseCharacterCount != 0)
                useTheseCharacters += _alphaLow;
            if (parameters.IncludeUpperCaseCharacterCount != 0)
                useTheseCharacters += _alphaCaps;
            if (parameters.IncludeNumericDigitCount != 0)
                useTheseCharacters += _numerics;
            if (parameters.IncludeSpecialCharacterCount != 0)
                useTheseCharacters += _special;

            String generatedPassword = string.Empty;

            for (int i = 0; i < parameters.IncludeLowerCaseCharacterCount; i++)
            {
                rand = r.NextDouble();
                generatedPassword += _alphaLow.ToCharArray()[(int)Math.Floor(rand * _alphaLow.Length)];
            }

            for (int i = 0; i < parameters.IncludeUpperCaseCharacterCount; i++)
            {
                rand = r.NextDouble();
                generatedPassword += _alphaCaps.ToCharArray()[(int)Math.Floor(rand * _alphaCaps.Length)];
            }

            for (int i = 0; i < parameters.IncludeNumericDigitCount; i++)
            {
                rand = r.NextDouble();
                generatedPassword += _numerics.ToCharArray()[(int)Math.Floor(rand * _numerics.Length)];
            }

            for (int i = 0; i < parameters.IncludeSpecialCharacterCount; i++)
            {
                rand = r.NextDouble();
                generatedPassword += _special.ToCharArray()[(int)Math.Floor(rand * _special.Length)];
            }

            while (generatedPassword.Length < parameters.MaximumLength)
            {
                rand = r.NextDouble();
                generatedPassword += useTheseCharacters.ToCharArray()[(int)Math.Floor(rand * useTheseCharacters.Length)];
            }

            // now shuffle the characters
            string shuffledPassword = new string(generatedPassword.ToCharArray().
                OrderBy(s => (r.Next(2) % 2) == 0).ToArray());

            return shuffledPassword;
        }

        public string GenerateStrongPassword(int length)
        {
            String generatedPassword = "";

            if (length < defaultMinimumLength)
                throw new Exception(string.Format("Number of characters should be greater than {0}.", defaultMinimumLength));

            // Generate four repeating random numbers are positions of lower, upper, numeric and special characters
            // By filling these positions with corresponding characters, we can ensure the password has at least one
            // character of those types

            int pLower, pUpper, pNumber, pSpecial;
            string posArray = "0123456789";
            if (length < posArray.Length)
                posArray = posArray.Substring(0, length);
            pLower = GetRandomPosition(ref posArray);
            pUpper = GetRandomPosition(ref posArray);
            pNumber = GetRandomPosition(ref posArray);
            pSpecial = GetRandomPosition(ref posArray);

            for (int i = 0; i < length; i++)
            {
                if (i == pLower)
                    generatedPassword += GetRandomChar(_alphaCaps);
                else if (i == pUpper)
                    generatedPassword += GetRandomChar(_alphaLow);
                else if (i == pNumber)
                    generatedPassword += GetRandomChar(_numerics);
                else if (i == pSpecial)
                    generatedPassword += GetRandomChar(_special);
                else
                    generatedPassword += GetRandomChar(_allChars);
            }
            return generatedPassword;
        }

        private string GetRandomChar(string fullString)
        {
            return fullString.ToCharArray()[(int)Math.Floor(_r.NextDouble() * fullString.Length)].ToString();
        }

        private int GetRandomPosition(ref string posArray)
        {
            int pos;
            string randomChar = posArray.ToCharArray()[(int)Math.Floor(_r.NextDouble()
                                           * posArray.Length)].ToString();
            pos = int.Parse(randomChar);
            posArray = posArray.Replace(randomChar, "");
            return pos;
        }

        public static string GetStrongPasswordRegularExpression()
        {
            return string.Format("^[a-zA-Z0-9]{{8,20}}$");
        }

        public static string GetStrongPasswordRegularExpression(int minLength, int maxLength)
        {
            return string.Format("^[a-zA-Z0-9]{{{0},{1}}}$", minLength, maxLength);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Check to see if the password passed in is a "strong" password. The minimum length defaults to 8 and the maximum length defaults to 20.
        /// </summary>
        ///
        /// <remarks>	Kevin, 9/23/2013. </remarks>
        ///
        /// <param name="password">	The password. </param>
        ///
        /// <returns>	true if password strong, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsPasswordStrong(string password)
        {
            if (password.Length >= defaultMinimumLength)
                return true;
            return false;
        }

        public static bool IsPasswordValid(string password, int minLength)
        {
            if (password.Length >= minLength)
                return true;
            return false;
        }

        public static bool IsPasswordValid(string password, int minLength, int maxLength)
        {
            if (password.Length >= minLength && password.Length <= maxLength)
                return true;
            return false;
        }

        public static bool IsPasswordValid(string password, string regularExpression)
        {
            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(regularExpression);
            return regEx.IsMatch(password);

        }

    }

}
