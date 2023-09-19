using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.ConfigManager.Support.Entities
{
    public class SQLServerInstallSettings : ObjectBase
    {
        public enum FileStreamLevel
        {
            Disabled = 0,
            TSqlAccess = 1,
            TSqlAndFileIoStreaming = 2,
            RemoteClientAccess = 3
        }

        private string _saPassword;
        private string _saPasswordConfirm;
        private string _clientAccountUserName;
        private string _clientAccountPassword;
        private string _clientAccountPasswordConfirm;
        private string _sqlInstanceName;
        private bool _allowEditCredentials;
        private FileStreamLevel _fileStreamLevel;

        public string SaPassword
        {
            get { return _saPassword; }
            set
            {
                if (_saPassword != value)
                {
                    _saPassword = value;
                    OnPropertyChanged(() => SaPassword, true);
                    OnPropertyChanged(() => IsValid, true);
                }
            }
        }

        public string SaPasswordConfirm
        {
            get { return _saPasswordConfirm; }
            set
            {
                if (_saPasswordConfirm != value)
                {
                    _saPasswordConfirm = value;
                    OnPropertyChanged(() => SaPasswordConfirm, true);
                    OnPropertyChanged(() => IsValid, true);
                }
            }
        }

        public string ClientAccountUserName
        {
            get { return _clientAccountUserName; }
            set
            {
                if (_clientAccountUserName != value)
                {
                    _clientAccountUserName = value;
                    OnPropertyChanged(() => ClientAccountUserName, true);
                    OnPropertyChanged(() => IsValid, true);
                }
            }
        }

        public string ClientAccountPassword
        {
            get { return _clientAccountPassword; }
            set
            {
                if (_clientAccountPassword != value)
                {
                    _clientAccountPassword = value;
                    OnPropertyChanged(() => ClientAccountPassword, true);
                    OnPropertyChanged(() => IsValid, true);
                }
            }
        }

        public string ClientAccountPasswordConfirm
        {
            get { return _clientAccountPasswordConfirm; }
            set
            {
                if (_clientAccountPasswordConfirm != value)
                {
                    _clientAccountPasswordConfirm = value;
                    OnPropertyChanged(() => ClientAccountPasswordConfirm, true);
                    OnPropertyChanged(() => IsValid, true);
                }
            }
        }

        public string SqlInstanceName
        {
            get { return _sqlInstanceName; }
            set
            {
                if (_sqlInstanceName != value)
                {
                    _sqlInstanceName = value;
                    OnPropertyChanged(() => SqlInstanceName, true);
                    OnPropertyChanged(() => IsValid, true);
                }
            }
        }

        public bool AllowEditCredentials
        {
            get { return _allowEditCredentials; }
            set
            {
                if (_allowEditCredentials != value)
                {
                    _allowEditCredentials = value;
                    OnPropertyChanged(() => AllowEditCredentials, true);
                }
            }
        }

        public FileStreamLevel FileStreamLevelSetting
        {
            get { return _fileStreamLevel; }
            set
            {
                if (_fileStreamLevel != value)
                {
                    _fileStreamLevel = value;
                    OnPropertyChanged(() => FileStreamLevelSetting, true);
                }
            }
        }

        public bool IsValid
        {
            get { 

                if( string.IsNullOrEmpty(SqlInstanceName) ||
                    string.IsNullOrEmpty(SaPassword) ||
                    string.IsNullOrEmpty(SaPasswordConfirm) ||
                    string.IsNullOrEmpty(ClientAccountUserName) ||
                    string.IsNullOrEmpty(ClientAccountPassword) ||
                    string.IsNullOrEmpty(ClientAccountPasswordConfirm))
                    return false;

                if( SaPasswordConfirm != SaPassword)
                    return false;

                if( ClientAccountPassword != ClientAccountPasswordConfirm)
                    return false;


                return true;

            }
            set
            {
                OnPropertyChanged(() => IsValid, true);
            }
        }

    }
}
