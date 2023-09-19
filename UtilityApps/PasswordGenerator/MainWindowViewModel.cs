using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GCS.Framework.Security;
using Telerik.Windows.Controls;

namespace PasswordGenerator
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            _generatePasswordParameters = new GeneratePasswordParameters();
            _generatePasswordParameters.MinimumLength = 8;
            _generatePasswordParameters.MaximumLength = 12;
            _generatePasswordParameters.IncludeLowerCaseCharacterCount = 2;
            _generatePasswordParameters.IncludeUpperCaseCharacterCount = 2;
            _generatePasswordParameters.IncludeNumericDigitCount = 2;
            _generatePasswordParameters.IncludeSpecialCharacterCount = 2;
            GeneratePasswordCommand = new DelegateCommand(OnGeneratePasswordCommand, OnCanGeneratePasswordCommand);
            CopyPasswordCommand = new DelegateCommand(OnCopyPasswordCommand, OnCanCopyPasswordCommand);
        }

        private bool OnCanCopyPasswordCommand(object obj)
        {
            return !string.IsNullOrEmpty(GeneratedPassword);
        }

        private void OnCopyPasswordCommand(object obj)
        {
            Clipboard.SetText(GeneratedPassword);
        }

        private bool OnCanGeneratePasswordCommand(object obj)
        {
            return (PasswordMinimumLength <= PasswordMaximumLength &&
                    PasswordMaximumLength >=
                    (MinimumLowerCase + MinimumUpperCase + MinimumNumericDigits + MinimumSpecialCharacters));
        }

        private void OnGeneratePasswordCommand(object obj)
        {
            var generator = new PasswordGeneratorValidator();
            if( !GenerateCloudStylePassword)
                GeneratedPassword = generator.GeneratePassword(_generatePasswordParameters);
            else
            {
                GeneratedPassword =
                    PasswordGeneratorValidator.GenerateCloudStylePassword(PasswordMinimumLength, PasswordMaximumLength, 5, 8, ReadablePhraseStrength.Random);
            }
            CopyPasswordCommand.InvalidateCanExecute();
        }

        private bool _GenerateCloudStylePassword;

        public bool GenerateCloudStylePassword
        {
            get
            {
                return _GenerateCloudStylePassword;
            }
            set
            {
                if (_GenerateCloudStylePassword != value)
                {
                    _GenerateCloudStylePassword = value;
                    this.OnPropertyChanged("GenerateCloudStylePassword");
                }
            }
        }


        private GeneratePasswordParameters _generatePasswordParameters;
        private string _generatedPassword;

        public int PasswordMinimumLength
        {
            get { return _generatePasswordParameters.MinimumLength; }
            set
            {
                if (_generatePasswordParameters.MinimumLength != value)
                {
                    _generatePasswordParameters.MinimumLength = value;
                    this.OnPropertyChanged("PasswordMinimumLength");
                }
            }
        }

        public int PasswordMaximumLength
        {
            get { return _generatePasswordParameters.MaximumLength; }
            set
            {
                if (_generatePasswordParameters.MaximumLength != value)
                {
                    _generatePasswordParameters.MaximumLength = value;
                    this.OnPropertyChanged("PasswordMaximumLength");
                }
            }
        }

        public int MinimumUpperCase
        {
            get { return _generatePasswordParameters.IncludeUpperCaseCharacterCount; }
            set
            {
                if (_generatePasswordParameters.IncludeUpperCaseCharacterCount != value)
                {
                    _generatePasswordParameters.IncludeUpperCaseCharacterCount = value;
                    OnPropertyChanged("MinimumUpperCase");
                }
            }
        }

        public int MinimumLowerCase
        {
            get { return _generatePasswordParameters.IncludeUpperCaseCharacterCount; }
            set
            {
                if (_generatePasswordParameters.IncludeUpperCaseCharacterCount != value)
                {
                    _generatePasswordParameters.IncludeUpperCaseCharacterCount = value;
                    OnPropertyChanged("MinimumLowerCase");
                }
            }
        }

        public int MinimumNumericDigits
        {
            get { return _generatePasswordParameters.IncludeNumericDigitCount; }
            set
            {
                if (_generatePasswordParameters.IncludeNumericDigitCount != value)
                {
                    _generatePasswordParameters.IncludeNumericDigitCount = value;
                    OnPropertyChanged("MinimumNumericDigits");
                }
            }
        }

        public int MinimumSpecialCharacters
        {
            get { return _generatePasswordParameters.IncludeSpecialCharacterCount; }
            set
            {
                if (_generatePasswordParameters.IncludeSpecialCharacterCount != value)
                {
                    _generatePasswordParameters.IncludeSpecialCharacterCount = value;
                    OnPropertyChanged("MinimumSpecialCharacters");
                }
            }
        }

        public string GeneratedPassword 
        {
            get { return _generatedPassword; }
            set
            {
                if (_generatedPassword != value)
                {
                    _generatedPassword = value;
                    OnPropertyChanged("GeneratedPassword");
                }
            }
        }

        public DelegateCommand GeneratePasswordCommand { get; set; }
        public DelegateCommand CopyPasswordCommand { get; set; }
    }
}
