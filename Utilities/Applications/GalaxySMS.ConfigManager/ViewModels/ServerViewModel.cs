using GalaxySMS.ConfigManager.Properties;
using GalaxySMS.ConfigManager.Support.Entities;
using GalaxySMS.ConfigManager.Support.Telerik;
using GalaxySMS.ConfigManager.Views;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Shared.Extensions;
using GCS.Core.Common.UI.Core;
using GCS.Core.Common.Utils;
using GCS.Framework.ActiveDirectory;
using GCS.Framework.InstallHelpers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using Telerik.Windows.Controls;
using static GalaxySMS.ConfigManager.Support.Entities.CreateDBSettings;
using static GCS.Framework.InstallHelpers.Helpers;
using Application = System.Windows.Application;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;

namespace GalaxySMS.ConfigManager.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ServerViewModel : ViewModelBase
    {
        #region Private fields

        private ObservableCollection<SqlInstanceData> _sqlInstances;
        private ObservableCollection<string> _databases;
        private bool _useIntegratedSecurity = true;
        private SqlInstanceData _selectedSqlInstance;
        private string _sqlUserName;
        private string _sqlPassword;
        private bool _sqlConnectionValid;
        private string _selectedDatabase;
        private SQLVersion _selectedSqlVersion;
        private ObservableCollection<SQLVersion> _sqlVersions;
        private string _installSQLFolder;
        private string _sharedWOWFolder;
        private Requirements requirements;
        private SQLServerInstallSettings _sqlServerInstallSettings;
        private string _gcsServiceGroupName = RequirementType.GCSServicesGroup.ToString();
        private string _gcsServiceAccountName = RequirementType.GCSServiceAccount.ToString();
        private string _gcsServiceAccountPassword = "G@laxyServ1ce";
        private string _gcsServiceAccountPasswordConfirm = "G@laxyServ1ce";
        private MsmqInstaller _msmqInstaller = new MsmqInstaller();
        private IisInstaller _iisInstaller = new IisInstaller();
        private string _SqlCmdPath;
        private bool _bAutoInstallSSMS = true;
        private bool _bAutoPublishDatabases = true;
        private bool _CanInstallServerSoftware;

        #endregion

        #region Constructor

        [ImportingConstructor]
        public ServerViewModel()
        {
            TestConnectionCommand =
                new DelegateCommand<SqlInstanceData>(ExecuteTestConnectionCommand, CanExecuteTestConnectionCommand);
            InstallSQLServerCommand =
                new DelegateCommand<object>(ExecuteInstallSQLServerCommand, CanExecuteInstallSQLServerCommand);
            SelectInstallFolderCommand = new DelegateCommand<object>(ExecuteSelectInstallFolderCommand);
            InstallSSMSCommand = new DelegateCommand<object>(ExecuteInstallSSMSCommand);
            InstallServerCommand = new DelegateCommand<object>(ExecuteInstallServerCommand, CanExecuteInstallServerCommand);
            InstallWebUiCommand = new DelegateCommand<object>(ExecuteInstallWebUiCommand, CanExecuteInstallWebUiCommand);

            DownloadSSMSCommand = new DelegateCommand<object>(ExecuteDownloadSSMSCommand);
            PublishGalaxySMSDBCommand = new DelegateCommand<SqlInstanceData>(ExecutePublishGalaxySMSDBCommand,
                CanExecutePublishGalaxySMSDBCommand);
            PublishGalaxySMSAuditDBCommand = new DelegateCommand<SqlInstanceData>(ExecutePublishGalaxySMSAuditDBCommand,
                CanExecutePublishGalaxySMSAuditDBCommand);
            PublishGalaxySMSLoggingDBCommand =
                new DelegateCommand<SqlInstanceData>(ExecutePublishGalaxySMSLoggingDBCommand,
                    CanExecutePublishGalaxySMSLoggingDBCommand);
            PublishGalaxySMSHangfireDBCommand =
                new DelegateCommand<SqlInstanceData>(ExecutePublishGalaxySMSHangfireDBCommand,
                    CanExecutePublishGalaxySMSHangfireDBCommand);

            InstallPreRequisiteCommand = new DelegateCommand<Requirement>(ExecuteInstallPreRequisiteCommand,
                CanExecuteInstallPreRequisiteCommand);

            BuildRequirements();
            BuildSQLVersions();
            SqlServerInstallSettings = new SQLServerInstallSettings()
            {
                SqlInstanceName = "GCSSQLEXPRESS",
                SaPassword = "GCSs@5560",
                SaPasswordConfirm = "GCSs@5560",
                ClientAccountUserName = "GalaxySMSClient",
                ClientAccountPassword = "SM$.5560",
                ClientAccountPasswordConfirm = "SM$.5560",
                FileStreamLevelSetting = SQLServerInstallSettings.FileStreamLevel.RemoteClientAccess
            };

            ScanForRequirementsStatus();
            GetDataSourcesFromRegistry();
            SelectedSqlInstance = SqlInstances.FirstOrDefault(o => o.IsSqlVersionOrGreater(2019));
            if (SelectedSqlInstance == null)
                SelectedSqlInstance = SqlInstances.FirstOrDefault(o => o.IsSqlVersionOrGreater(2016));
            if (SelectedSqlInstance == null)
                SelectedSqlInstance = SqlInstances.FirstOrDefault(o => o.AllowInstallNewInstance == true);

            InstallSQLFolder =
                $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Microsoft SQL Server\\";
            SharedWOWFolder =
                $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)}\\Microsoft SQL Server\\";
            base.BackgroundSubduedOpacity = .5;
        }


        #endregion

        #region Commands

        public DelegateCommand<SqlInstanceData> TestConnectionCommand { get; private set; }
        public DelegateCommand<object> InstallSQLServerCommand { get; private set; }
        public DelegateCommand<object> SelectInstallFolderCommand { get; private set; }
        public DelegateCommand<object> InstallSSMSCommand { get; private set; }
        public DelegateCommand<object> InstallServerCommand { get; private set; }
        public DelegateCommand<object> InstallWebUiCommand { get; private set; }
        
        public DelegateCommand<object> DownloadSSMSCommand { get; private set; }
        public DelegateCommand<SqlInstanceData> PublishGalaxySMSDBCommand { get; private set; }
        public DelegateCommand<SqlInstanceData> PublishGalaxySMSAuditDBCommand { get; private set; }
        public DelegateCommand<SqlInstanceData> PublishGalaxySMSLoggingDBCommand { get; private set; }
        public DelegateCommand<SqlInstanceData> PublishGalaxySMSHangfireDBCommand { get; private set; }

        public DelegateCommand<Requirement> InstallPreRequisiteCommand { get; private set; }

        #endregion

        #region Public Properties
        public Globals Globals
        {
            get { return Globals.Instance; }
        }

        public override string ViewTitle
        {
            get
            {
                return Resources.ServerView_Title;
            }
        }

        public ObservableCollection<SqlInstanceData> SqlInstances
        {
            get { return _sqlInstances; }
            set
            {
                if (_sqlInstances != value)
                {
                    _sqlInstances = value;
                    OnPropertyChanged(() => SqlInstances, false);
                }
            }
        }

        public ObservableCollection<string> Databases
        {
            get { return _databases; }
            set
            {
                if (_databases != value)
                {
                    _databases = value;
                    OnPropertyChanged(() => Databases, true);
                }
            }
        }

        public bool UseIntegratedSecurity
        {
            get { return _useIntegratedSecurity; }
            set
            {
                if (_useIntegratedSecurity != value)
                {
                    _useIntegratedSecurity = value;
                    OnPropertyChanged(() => UseIntegratedSecurity, true);
                    SqlConnectionValid = false;
                }
            }
        }

        public SqlInstanceData SelectedSqlInstance
        {
            get { return _selectedSqlInstance; }
            set
            {
                if (_selectedSqlInstance != value)
                {
                    _selectedSqlInstance = value;
                    OnPropertyChanged(() => SelectedSqlInstance, true);
                    SqlConnectionValid = false;
                }
            }
        }

        public string SqlUserName
        {
            get { return _sqlUserName; }
            set
            {
                if (_sqlUserName != value)
                {
                    _sqlUserName = value;
                    OnPropertyChanged(() => SqlUserName, true);
                    SqlConnectionValid = false;
                }
            }
        }

        public string SqlPassword
        {
            get { return _sqlPassword; }
            set
            {
                if (_sqlPassword != value)
                {
                    _sqlPassword = value;
                    OnPropertyChanged(() => SqlPassword, true);
                    SqlConnectionValid = false;
                }
            }
        }

        public bool SqlConnectionValid
        {
            get { return _sqlConnectionValid; }
            set
            {
                if (_sqlConnectionValid != value)
                {
                    _sqlConnectionValid = value;
                    OnPropertyChanged(() => SqlConnectionValid, true);
                }
            }
        }

        public bool CanCreateGalaxySMSDB
        {
            get
            {
                if (Databases == null || Databases.Contains(CreateDBSettings.ToDatabaseName(DBNames.GalaxySMS)))
                    return false;
                return true;
            }
            set
            {
                OnPropertyChanged(() => CanCreateGalaxySMSDB, true);
            }
        }

        public bool CanCreateGalaxySMSAuditDB
        {
            get
            {
                if (Databases == null || Databases.Contains(ToDatabaseName(DBNames.GalaxySMS_AuditActivity)))
                    return false;
                return true;
            }
            set
            {
                OnPropertyChanged(() => CanCreateGalaxySMSAuditDB, true);
            }
        }


        public bool CanCreateGalaxySMSLoggingDB
        {
            get
            {
                if (Databases == null || Databases.Contains(ToDatabaseName(DBNames.GalaxySMS_Logging)))
                    return false;
                return true;
            }
            set
            {
                OnPropertyChanged(() => CanCreateGalaxySMSLoggingDB, true);
            }
        }

        public bool CanCreateGalaxySMSHangfireDB
        {
            get
            {
                if (Databases == null || Databases.Contains(ToDatabaseName(DBNames.GalaxySMS_Hangfire)))
                    return false;
                return true;
            }
            set
            {
                OnPropertyChanged(() => CanCreateGalaxySMSHangfireDB, true);
            }
        }




        public bool CanInstallServerSoftware
        {
            get
            {
                return RequiredItems.AllCompleted &&
                  !CanCreateGalaxySMSDB &&
                  !CanCreateGalaxySMSAuditDB &&
                  !CanCreateGalaxySMSLoggingDB &&
                  !CanCreateGalaxySMSHangfireDB &&
                  SqlConnectionValid && SelectedSqlInstance != null &&
                  !SelectedSqlInstance.AllowInstallNewInstance &&
                  SelectedSqlInstance.IsConnectionValid;
            }
            set
            {
                OnPropertyChanged(() => CanInstallServerSoftware, true);
            }
        }

        public string SelectedDatabase
        {
            get { return _selectedDatabase; }
            set
            {
                if (_selectedDatabase != value)
                {
                    _selectedDatabase = value;
                    OnPropertyChanged(() => SelectedDatabase, true);
                }
            }
        }

        public SQLVersion SelectedSqlVersion
        {
            get { return _selectedSqlVersion; }
            set
            {
                if (_selectedSqlVersion != value)
                {
                    _selectedSqlVersion = value;
                    OnPropertyChanged(() => SelectedSqlVersion, true);
                }
            }
        }

        public ObservableCollection<SQLVersion> SqlVersions
        {
            get { return _sqlVersions; }
            set
            {
                if (_sqlVersions != value)
                {
                    _sqlVersions = value;
                    OnPropertyChanged(() => SqlVersions, true);
                }
            }
        }

        public string InstallSQLFolder
        {
            get { return _installSQLFolder; }
            set
            {
                if (_installSQLFolder != value)
                {
                    _installSQLFolder = value;
                    OnPropertyChanged(() => InstallSQLFolder, true);
                }
            }
        }

        public string SharedWOWFolder
        {
            get { return _sharedWOWFolder; }
            set
            {
                if (_sharedWOWFolder != value)
                {
                    _sharedWOWFolder = value;
                    OnPropertyChanged(() => SharedWOWFolder, true);
                }
            }
        }

        public SQLServerInstallSettings SqlServerInstallSettings
        {
            get { return _sqlServerInstallSettings; }
            set
            {
                if (_sqlServerInstallSettings != value)
                {
                    _sqlServerInstallSettings = value;
                    OnPropertyChanged(() => SqlServerInstallSettings, true);
                }
            }
        }

        public Requirements RequiredItems
        {
            get { return requirements; }
            set
            {
                if (requirements != value)
                {
                    requirements = value;
                    OnPropertyChanged(() => RequiredItems, true);
                }
            }
        }

        public string GCSServiceGroupName
        {
            get { return _gcsServiceGroupName; }
            set
            {
                if (_gcsServiceGroupName != value)
                {
                    _gcsServiceGroupName = value;
                    OnPropertyChanged(() => GCSServiceGroupName, true);
                }
            }
        }

        public string GCSServiceAccountName
        {
            get { return _gcsServiceAccountName; }
            set
            {
                if (_gcsServiceAccountName != value)
                {
                    _gcsServiceAccountName = value;
                    OnPropertyChanged(() => GCSServiceAccountName, true);
                }
            }
        }

        public string GCSServiceAccountPassword
        {
            get { return _gcsServiceAccountPassword; }
            set
            {
                if (_gcsServiceAccountPassword != value)
                {
                    _gcsServiceAccountPassword = value;
                    OnPropertyChanged(() => GCSServiceAccountPassword, true);
                }
            }
        }

        public string GCSServiceAccountPasswordConfirm
        {
            get { return _gcsServiceAccountPasswordConfirm; }
            set
            {
                if (_gcsServiceAccountPasswordConfirm != value)
                {
                    _gcsServiceAccountPasswordConfirm = value;
                    OnPropertyChanged(() => GCSServiceAccountPasswordConfirm, true);
                }
            }
        }

        public string SqlCmdPath
        {
            get { return _SqlCmdPath; }
            set
            {
                if (_SqlCmdPath != value)
                {
                    _SqlCmdPath = value;
                    OnPropertyChanged(() => SqlCmdPath, true);
                }
            }
        }

        public bool AutomaticallyInstallSSMS
        {
            get { return _bAutoInstallSSMS; }
            set
            {
                if (_bAutoInstallSSMS != value)
                {
                    _bAutoInstallSSMS = value;
                    OnPropertyChanged(() => AutomaticallyInstallSSMS, true);
                }
            }
        }

        public bool AutomaticallyPublishDatabases
        {
            get { return _bAutoPublishDatabases; }
            set
            {
                if (_bAutoPublishDatabases != value)
                {
                    _bAutoPublishDatabases = value;
                    OnPropertyChanged(() => AutomaticallyPublishDatabases, true);
                }
            }
        }

        #endregion

        #region Private Methods

        private bool CanExecuteInstallPreRequisiteCommand(Requirement obj)
        {
            //if( obj != null && obj.Type == RequirementType.MSMQ)
            //    return true;

            if (obj == null || obj.Status == InstallStatus.Installed)
                return false;

            switch (obj.Type)
            {
                case RequirementType.NetFramework_4_8:
                    break;

                case RequirementType.GCSServicesGroup:
                    return !string.IsNullOrEmpty(GCSServiceGroupName);

                case RequirementType.GCSServiceAccount:
                    if (string.IsNullOrEmpty(GCSServiceAccountName) ||
                      string.IsNullOrEmpty(GCSServiceAccountPassword) ||
                      string.IsNullOrEmpty(GCSServiceAccountPasswordConfirm) ||
                      GCSServiceAccountPasswordConfirm != GCSServiceAccountPassword)
                        return false;
                    var group = RequiredItems.Items.FirstOrDefault(o => o.Type == RequirementType.GCSServicesGroup);
                    if (group != null && group.Status != InstallStatus.Installed)
                        return false;

                    return true;

                case RequirementType.SQLServerInstance:
                    break;

                case RequirementType.MSMQ:
                    return this._msmqInstaller != null;

                case RequirementType.Redis:
                    break;

            }

            return true;
        }

        private async void ExecuteInstallPreRequisiteCommand(Requirement obj)
        {
            if (obj == null)
                return;
            uint valueDetected = 0;
            Globals.IsBusy = true;
            switch (obj.Type)
            {
                case RequirementType.NetFramework_4_8:
                    //InstallDotNetFramework();
                    await InstallDotNetFrameworkAsync();
                    valueDetected = IsDotNetInstalled(valueDetected, obj);
                    break;

                case RequirementType.GCSServicesGroup:
                    if (string.IsNullOrEmpty(GCSServiceGroupName))
                    {
                        ShowAlertDialog(MessageBoxView.IconType.Warning, Resources.DatabaseView_GCSServiceAccountValidation_Header, Resources.DatabaseView_ServiceAccount_InvalidValues, true, OnShowAlertClosed);
                        return;
                    }
                    GCSADManager.CreateLocalGroup(this.GCSServiceGroupName, Resources.GCSServicesGroup_Description);
                    DoesLocalGroupExist(obj);
                    break;

                case RequirementType.GCSServiceAccount:
                    if (string.IsNullOrEmpty(GCSServiceAccountName) ||
                        string.IsNullOrEmpty(GCSServiceAccountPassword) ||
                        string.IsNullOrEmpty(GCSServiceAccountPasswordConfirm))
                    {
                        ShowAlertDialog(MessageBoxView.IconType.Warning, Resources.DatabaseView_GCSServiceAccountValidation_Header, Resources.DatabaseView_ServiceAccount_InvalidValues, true, OnShowAlertClosed);
                        return;
                    }

                    if (GCSServiceAccountPasswordConfirm != GCSServiceAccountPassword)
                    {
                        ShowAlertDialog(MessageBoxView.IconType.Warning, Resources.DatabaseView_GCSServiceAccountValidation_Header, Resources.DatabaseView_ServiceAccount_PasswordsDoNotMatch, true, OnShowAlertClosed);
                        return;
                    }

                    GCSADManager.CreateLocalUser(this.GCSServiceAccountName, this.GCSServiceAccountPassword, Resources.GCSServiceAccountName_Description, new List<string>() { GCSServiceGroupName });

                    LoginUtilities.GrantUserLogOnAsAService(this.GCSServiceAccountName);

                    DoesLocalUserExist(obj);
                    break;

                case RequirementType.SQLServerInstance:
                    break;

                case RequirementType.MSMQ:
                    //                   _msmqInstaller.InstallMSMQ();
                    Globals.BusyContent = $"{Resources.DatabaseView_Busy_Content_InstallingMSMQ}. {Resources.PleaseWait}";
                    await _msmqInstaller.InstallMSMQAsync();
                    //IsMSMQInstalled(obj);
                    await IsMSMQInstalledAsync(obj);
                    break;

                case RequirementType.Redis:
                    Globals.BusyContent = $"{Resources.DatabaseView_Busy_Content_InstallingRedis}. {Resources.PleaseWait}";

                    await InstallRedisAsync();
                    ////IsMSMQInstalled(obj);
                    IsRedisInstalled(obj);
                    break;

                case RequirementType.IIS:
                    Globals.BusyContent = $"{Resources.DatabaseView_Busy_Content_InstallingIIS}. {Resources.PleaseWait}";
                    await _iisInstaller.InstallIISAsync();
                    //IsMSMQInstalled(obj);
                    await IsIISInstalledAsync(obj);
                    await InstallIisUrlRewriteAsync();
                    break;
            }
            RequiredItems.AllCompleted = false;
            CanInstallServerSoftware = false;
            Globals.IsBusy = false;
        }

        private bool CanExecuteTestConnectionCommand(SqlInstanceData obj)
        {   // perform logic to indicate if the command can be executed
            if (obj == null)
                return false;

            if (obj.AllowInstallNewInstance == true)
                return false;

            if (string.IsNullOrEmpty(obj.InstanceName))
                return false;

            if (UseIntegratedSecurity == false && (string.IsNullOrEmpty(SqlUserName) || string.IsNullOrEmpty(SqlPassword)))
                return false;

            return true;
        }

        private async void ExecuteTestConnectionCommand(SqlInstanceData sqlInstance)
        {
            var bResult = await TestConnection(sqlInstance, true);
        }

        private async Task<bool> TestConnection(SqlInstanceData sqlInstance, bool bShowMessage)
        {
            try
            {
                Globals.IsBusy = true;
                Globals.BusyContent = $"{Resources.DatabaseView_Busy_Content_TestingDBConnectionTo} {sqlInstance.InstanceName}. {Resources.PleaseWait}";
                ClearCustomErrors();
                SqlConnectionValid = false;
                if (UseIntegratedSecurity)
                {
                    sqlInstance.ConnectionString = $"Data Source={SelectedSqlInstance.InstanceName};Initial Catalog=master;Integrated Security=SSPI";
                    sqlInstance.SqlCmdConnectString = $"-S {SelectedSqlInstance.InstanceName} -E";
                }
                else
                {
                    sqlInstance.ConnectionString = $"Data Source={SelectedSqlInstance.InstanceName};Initial Catalog=master;User ID={SqlUserName};Password={SqlPassword}";
                    sqlInstance.SqlCmdConnectString = $"-S {SelectedSqlInstance.InstanceName} -U {SqlUserName} -P {SqlPassword}";
                }

                var connection = new System.Data.SqlClient.SqlConnection(sqlInstance.ConnectionString);
                await connection.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("select InstanceDefaultDataPath = serverproperty('InstanceDefaultDataPath'), InstanceDefaultLogPath = serverproperty('InstanceDefaultLogPath')", connection))
                {
                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            sqlInstance.DataFilePath = ((IDataRecord)dr)[0].ToString();
                            sqlInstance.LogFilePath = ((IDataRecord)dr)[1].ToString();
                            sqlInstance.IsConnectionValid = true;
                            SqlCmdPath = GetSqlCmdPath(sqlInstance);
                            break;
                        }
                    }
                }


                connection.Close();
                var dbs = await GetListOfDatabases(sqlInstance.ConnectionString);
                Databases = dbs.ToObservableCollection();
                SqlConnectionValid = true;
                CanInstallServerSoftware = false;
                if (bShowMessage)
                {
                    ShowAlertDialog(MessageBoxView.IconType.Success, Resources.DatabaseView_TestConnection_Success, Resources.DatabaseView_TestConnection_Header, true, OnShowAlertClosed);
                }
            }
            catch (Exception ex)
            {
                AddCustomError(new GCS.Core.Common.CustomError(ex));
                SqlConnectionValid = false;
                ShowAlertDialog(MessageBoxView.IconType.Warning, $"{Resources.DatabaseView_TestConnection_Fail}{Environment.NewLine}{ex.Message}", Resources.DatabaseView_TestConnection_Header, true, OnShowAlertClosed);
            }
            Globals.IsBusy = false;
            return SqlConnectionValid;
        }

        //private async void ExecuteCreateSqlLogin(CreateDBSettings settings)
        //{
        //    try
        //    {
        //        Globals.IsBusy = true;
        //        ClearCustomErrors();
        //        SqlConnectionValid = false;

        //        var connection = new System.Data.SqlClient.SqlConnection(settings.ConnectionString);
        //        await connection.OpenAsync();

        //        using (SqlCommand cmd = new SqlCommand("select InstanceDefaultDataPath = serverproperty('InstanceDefaultDataPath'), InstanceDefaultLogPath = serverproperty('InstanceDefaultLogPath')", connection))
        //        {
        //            using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
        //            {
        //                while (await dr.ReadAsync())
        //                {

        //                    break;
        //                }
        //            }
        //        }


        //        connection.Close();
        //        ShowAlertDialog(MessageBoxView.IconType.Success, Resources.DatabaseView_TestConnection_Success, Resources.DatabaseView_TestConnection_Header, true, OnShowAlertClosed);
        //    }
        //    catch (Exception ex)
        //    {
        //        AddCustomError(new GCS.Core.Common.CustomError(ex));
        //        SqlConnectionValid = false;
        //        ShowAlertDialog(MessageBoxView.IconType.Warning, $"{Resources.DatabaseView_TestConnection_Fail}{Environment.NewLine}{ex.Message}", Resources.DatabaseView_TestConnection_Header, true, OnShowAlertClosed);
        //    }
        //    Globals.IsBusy = false;
        //}

        private void ShowAlertDialog(MessageBoxView.IconType iconType, string message, string title, bool subdueBackground, EventHandler<WindowClosedEventArgs> eventHandler)
        {
            if (subdueBackground)
                SetBackgroundSubdued();
            TelerikHelpers.ShowAlertDialog(eventHandler, iconType, message, title);
            if (subdueBackground)
                ClearBackgroundSubdued();
        }

        private bool CanExecutePublishGalaxySMSLoggingDBCommand(SqlInstanceData obj)
        {
            return CanCreateGalaxySMSLoggingDB;
        }

        private bool CanExecutePublishGalaxySMSHangfireDBCommand(SqlInstanceData obj)
        {
            return CanCreateGalaxySMSHangfireDB;
        }

        private async void ExecutePublishGalaxySMSLoggingDBCommand(SqlInstanceData obj)
        {
            await PublishGalaxySMSLoggingDB(obj, true);
        }

        private async void ExecutePublishGalaxySMSHangfireDBCommand(SqlInstanceData obj)
        {
            await PublishGalaxySMSHangfireDB(obj, true);
        }

        
        private async Task PublishGalaxySMSLoggingDB(SqlInstanceData obj, bool bDisplayCompletedSuccessMessage)
        {
            var now = DateTimeOffset.Now;
            var dbName = CreateDBSettings.ToDatabaseName(DBNames.GalaxySMS_Logging);
            dbName = dbName.Replace('_', '-');
            var createDbSettings = new CreateDBSettings(obj)
            {
                DatabaseName = dbName,
                CreateScriptFilename = $"Create-{dbName}.sql",
                OutputFilename = $"Create-{dbName}-{now.Year}-{now.Month:d2}-{now.Day:d2}_{now.Hour:d2}-{now.Minute:d2}.log"
            };
            var galaxyServiceAccount = RequiredItems.Items.FirstOrDefault(o => o.Type == RequirementType.GCSServiceAccount);
            if (galaxyServiceAccount.Status == InstallStatus.Installed)
            {
                createDbSettings.SqlLogins.Add(new CreateDBSettings.SqlLoginInfo()
                {
                    LoginName = GCSServiceAccountName,
                    IsWindowsLogin = true
                });
            }

            createDbSettings.SqlLogins.Add(new CreateDBSettings.SqlLoginInfo()
            {
                LoginName = SqlServerInstallSettings.ClientAccountUserName,
                Password = SqlServerInstallSettings.ClientAccountPassword,
                IsWindowsLogin = false
            });

            await CreateDatabase(createDbSettings, bDisplayCompletedSuccessMessage);
        }

        private async Task PublishGalaxySMSHangfireDB(SqlInstanceData obj, bool bDisplayCompletedSuccessMessage)
        {
            var now = DateTimeOffset.Now;
            var dbName = ToDatabaseName(DBNames.GalaxySMS_Hangfire);
            dbName = dbName.Replace('_', '-');
            var createDbSettings = new CreateDBSettings(obj)
            {
                DatabaseName = dbName,
                CreateScriptFilename = $"Create-{dbName}.sql",
                OutputFilename = $"Create-{dbName}-{now.Year}-{now.Month:d2}-{now.Day:d2}_{now.Hour:d2}-{now.Minute:d2}.log"
            };
            var galaxyServiceAccount = RequiredItems.Items.FirstOrDefault(o => o.Type == RequirementType.GCSServiceAccount);
            if (galaxyServiceAccount.Status == InstallStatus.Installed)
            {
                createDbSettings.SqlLogins.Add(new CreateDBSettings.SqlLoginInfo()
                {
                    LoginName = GCSServiceAccountName,
                    IsWindowsLogin = true
                });
            }

            createDbSettings.SqlLogins.Add(new CreateDBSettings.SqlLoginInfo()
            {
                LoginName = SqlServerInstallSettings.ClientAccountUserName,
                Password = SqlServerInstallSettings.ClientAccountPassword,
                IsWindowsLogin = false
            });

            await CreateDatabase(createDbSettings, bDisplayCompletedSuccessMessage);
        }


        private bool CanExecutePublishGalaxySMSAuditDBCommand(SqlInstanceData obj)
        {
            return CanCreateGalaxySMSAuditDB;
        }

        private async void ExecutePublishGalaxySMSAuditDBCommand(SqlInstanceData obj)
        {
            await PublishGalaxySMSAuditDB(obj, true);
        }

        private async Task PublishGalaxySMSAuditDB(SqlInstanceData obj, bool bDisplayCompletedSuccessMessage)
        {
            var now = DateTimeOffset.Now;
            var dbName = ToDatabaseName(DBNames.GalaxySMS_AuditActivity);
            dbName = dbName.Replace('_', '-');
            var createDbSettings = new CreateDBSettings(obj)
            {
                DatabaseName = dbName,
                CreateScriptFilename = $"Create-{dbName}.sql",
                OutputFilename = $"Create-{dbName}-{now.Year}-{now.Month:d2}-{now.Day:d2}_{now.Hour:d2}-{now.Minute:d2}.log"
            };
            var galaxyServiceAccount = RequiredItems.Items.FirstOrDefault(o => o.Type == RequirementType.GCSServiceAccount);
            if (galaxyServiceAccount.Status == InstallStatus.Installed)
            {
                createDbSettings.SqlLogins.Add(new CreateDBSettings.SqlLoginInfo()
                {
                    LoginName = GCSServiceAccountName,
                    IsWindowsLogin = true
                });
            }

            createDbSettings.SqlLogins.Add(new CreateDBSettings.SqlLoginInfo()
            {
                LoginName = SqlServerInstallSettings.ClientAccountUserName,
                Password = SqlServerInstallSettings.ClientAccountPassword,
                IsWindowsLogin = false
            });

            await CreateDatabase(createDbSettings, bDisplayCompletedSuccessMessage);
        }

        private bool CanExecutePublishGalaxySMSDBCommand(SqlInstanceData obj)
        {
            return CanCreateGalaxySMSDB;
        }

        private async void ExecutePublishGalaxySMSDBCommand(SqlInstanceData obj)
        {
            await PublishGalaxySMSDB(obj, true);

        }

        private async Task PublishGalaxySMSDB(SqlInstanceData obj, bool bDisplayCompletedSuccessMessage)
        {
            var now = DateTimeOffset.Now;
            var dbName = CreateDBSettings.ToDatabaseName(DBNames.GalaxySMS);
            var createDbSettings = new CreateDBSettings(obj)
            {
                DatabaseName = dbName,
                CreateScriptFilename = $"Create-{dbName}.sql",
                OutputFilename = $"Create-{dbName}-{now.Year}-{now.Month:d2}-{now.Day:d2}_{now.Hour:d2}-{now.Minute:d2}.log",
                AddFileStreamGroup = true
            };
            var galaxyServiceAccount = RequiredItems.Items.FirstOrDefault(o => o.Type == RequirementType.GCSServiceAccount);
            if (galaxyServiceAccount.Status == InstallStatus.Installed)
            {
                createDbSettings.SqlLogins.Add(new CreateDBSettings.SqlLoginInfo()
                {
                    LoginName = GCSServiceAccountName,
                    IsWindowsLogin = true
                });
            }

            createDbSettings.SqlLogins.Add(new CreateDBSettings.SqlLoginInfo()
            {
                LoginName = SqlServerInstallSettings.ClientAccountUserName,
                Password = SqlServerInstallSettings.ClientAccountPassword,
                IsWindowsLogin = false
            });

            await CreateDatabase(createDbSettings, bDisplayCompletedSuccessMessage);
        }

        private async Task CreateDatabase(CreateDBSettings settings, bool bDisplayCompletedSuccessMessage)
        {
            try
            {
                if (settings.IsConnectionValid == false)
                {
                    TelerikHelpers.ShowAlertDialog(OnShowAlertClosed, MessageBoxView.IconType.Warning, Resources.DatabaseView_DBConnectionNotConfirmed, Resources.DatabaseView_CreateDatabase);
                    return;
                }

                var bSuccessful = false;
                Globals.IsBusy = true;
                Globals.BusyContent = $"{Resources.DatabaseView_Busy_Content_PublishingDatabase} {settings.DatabaseName}. {Resources.PleaseWait}";
                using (var connection = new SqlConnection(settings.ConnectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(settings.SQLCmd, connection))
                    {
                        await cmd.ExecuteNonQueryAsync();
                        var tempPath = System.IO.Path.GetTempPath();
                        var createDBScriptFilename = $"{tempPath}{settings.CreateScriptFilename}";
                        var outputFilename = $"{tempPath}{settings.OutputFilename}";

                        if( File.Exists(createDBScriptFilename))
                            File.Delete(createDBScriptFilename);

                        if (settings.DatabaseName == ToDatabaseName(DBNames.GalaxySMS))
                        {
                            File.WriteAllText(createDBScriptFilename, GalaxySMS.DB.Properties.Resources.Create_GalaxySMS);
                            File.AppendAllText(createDBScriptFilename, GalaxySMS.DB.Properties.Resources.InsertCountriesAndStateData);
                        }
                        else if (settings.DatabaseName == ToDatabaseName(DBNames.GalaxySMS_AuditActivity))
                        {
                            File.WriteAllText(createDBScriptFilename, GalaxySMS.DB.Properties.Resources.Create_GalaxySMS_AuditActivity);
                        }
                        else if (settings.DatabaseName == ToDatabaseName(DBNames.GalaxySMS_Logging))
                        {
                            File.WriteAllText(createDBScriptFilename, GalaxySMS.DB.Properties.Resources.Create_GalaxySMS_Logging);
                        }
                        else if (settings.DatabaseName == ToDatabaseName(DBNames.GalaxySMS_Hangfire))
                        {
                            File.WriteAllText(createDBScriptFilename, GalaxySMS.DB.Properties.Resources.Create_Hangfire);
                        }

                        // now execute script to create database schema
                        var sqlcmd = $"sqlcmd.exe";
                        sqlcmd = SqlCmdPath;
                        var sqlCmdParams = $"{settings.SqlCmdConnectString} -i {createDBScriptFilename} -o {outputFilename}";

                        var exitCode = await ProcessUtilities.ExecAsync(sqlcmd, sqlCmdParams);
                        if (exitCode == 0)
                        {   // SUCCESSFUL
                            var msgCount = Support.FileUtilities.CountStringInFile(outputFilename, "Msg ");
                            var warningCount = Support.FileUtilities.CountStringInFile(outputFilename, "Warning ");
                            if (msgCount != 0 || warningCount != 0)
                            {
                                TelerikHelpers.ShowAlertDialog(null, MessageBoxView.IconType.Warning, $"{settings.DatabaseName} creation has finished with {msgCount} errors and {warningCount} warnings. Review the output file '{outputFilename}', searching for the text 'Msg ' to locate each error. Search for the text 'Warning ' to locate each warning. Try running the upgrade script a second time. If errors still occur, then contact technical support for assistance.", $"{settings.DatabaseName} Database Creation");
                            }
                            else
                            {
                                bSuccessful = true;
                                foreach (var login in settings.SqlLogins)
                                {
                                    try
                                    {
                                        using (SqlCommand loginExists = new SqlCommand(login.SqlLoginExistsCmd, connection))
                                        {
                                            var count = await loginExists.ExecuteScalarAsync();
                                            if ((int)count == 0)
                                            {
                                                using (SqlCommand loginCmd = new SqlCommand(login.SqlCreateLoginCmd, connection))
                                                {
                                                    await loginCmd.ExecuteNonQueryAsync();
                                                }
                                            }

                                            using (SqlCommand userCmd = new SqlCommand(login.SqlCreateUserCmd, connection))
                                            {
                                                connection.ChangeDatabase(settings.DatabaseName);
                                                await userCmd.ExecuteNonQueryAsync();

                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        TelerikHelpers.ShowAlertDialog(null, MessageBoxView.IconType.Warning, $"{ex.ToString()}", $"{settings.DatabaseName} Database Creation");
                                        bSuccessful = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            TelerikHelpers.ShowAlertDialog(null, MessageBoxView.IconType.Warning, $"{settings.DatabaseName} creation failed.\n{exitCode}", $"{settings.DatabaseName} Database Creation");
                        }
                        var proc = Process.Start("wordpad.exe", string.Format("\"{0}\"", outputFilename));
                    }


                    //ProcessStartInfo psi = new ProcessStartInfo(sqlcmd, sqlCmdParams);
                    //psi.WindowStyle = ProcessWindowStyle.Hidden;
                    //Process proc = Process.Start(psi);
                    //if (proc != null)
                    //{
                    //    proc.WaitForExit();
                    //    if (proc.ExitCode == 0)
                    //    {   // SUCCESSFUL
                    //        var msgCount = Support.FileUtilities.CountStringInFile(outputFilename, "Msg ");

                    //        if (msgCount != 0)
                    //        {
                    //            TelerikHelpers.ShowAlertDialog(OnShowAlertClosed, MessageBoxView.IconType.Warning, $"{settings.DatabaseName} creation has finished with {msgCount} errors. Review the output file '{outputFilename}', searching for the text 'Msg ' to locate each error. Try running the upgrade script a second time. If errors still occur, then contact technical support for assistance.", $"{settings.DatabaseName} Database Creation");
                    //        }
                    //    }
                    //    else
                    //    {
                    //        TelerikHelpers.ShowAlertDialog(OnShowAlertClosed, MessageBoxView.IconType.Warning, $"{settings.DatabaseName} creation failed.\n{proc.ExitCode.ToString()}", $"{settings.DatabaseName} Database Creation");
                    //    }
                    //    proc = Process.Start("wordpad.exe", string.Format("\"{0}\"", outputFilename));
                    //}



                    var dbs = await GetListOfDatabases(settings.ConnectionString);
                    Databases = dbs.ToObservableCollection();
                    SqlConnectionValid = true;
                    if (bDisplayCompletedSuccessMessage && bSuccessful)
                        ShowAlertDialog(MessageBoxView.IconType.Success, $"{Resources.DatabaseView_Database} {settings.DatabaseName} {Resources.CreatedSuccessfully}", Resources.DatabaseView_CreateDatabase, true, OnShowAlertClosed);
                }
            }
            catch (Exception ex)
            {
                AddCustomError(new GCS.Core.Common.CustomError(ex));
                ShowAlertDialog(MessageBoxView.IconType.Stop, $"{Resources.DatabaseView_TestConnection_Fail}{Environment.NewLine}{ex.Message}", Resources.DatabaseView_TestConnection_Header, true, OnShowAlertClosed);

            }
            Globals.IsBusy = false;
        }

        private bool CanExecuteInstallSQLServerCommand(object obj)
        {
            return SqlServerInstallSettings.IsValid;
        }

        private async void ExecuteInstallSQLServerCommand(object obj)
        {
            InstallSQLFolder = InstallSQLFolder.TrimEnd('\\');
            SharedWOWFolder = SharedWOWFolder.TrimEnd('\\');

            var strFeatures = string.Empty;
            foreach (var sqlFeature in SelectedSqlVersion.Features.Where(o => o.IsSelected))
            {
                if (!string.IsNullOrEmpty(strFeatures))
                    strFeatures += ",";
                strFeatures += sqlFeature.Code;
            }

            var strSetupParameters = string.Format("/Action=INSTALL /UpdateEnabled=False /IACCEPTSQLSERVERLICENSETERMS=true /Features={3} /SQLSYSADMINACCOUNTS=\"Builtin\\Administrators\" /InstanceDir=\"{0}\" /INSTALLSHAREDDIR=\"{1}\" /INSTALLSHAREDWOWDIR=\"{2}\"",
                InstallSQLFolder,
                InstallSQLFolder,
                SharedWOWFolder,
                strFeatures);
            strSetupParameters += string.Format(" /HIDECONSOLE=true");
            strSetupParameters += string.Format(" /NPENABLED=1");
            strSetupParameters += string.Format(" /TCPENABLED=1");

            strSetupParameters += string.Format(" /SQLSVCSTARTUPTYPE=\"Automatic\" /SECURITYMODE=SQL");
            strSetupParameters += string.Format(" /SAPWD=\"{0}\"", this.SqlServerInstallSettings.SaPassword);
            strSetupParameters += string.Format(" /SQLSVCACCOUNT=\"NT AUTHORITY\\NETWORK SERVICE\"");
            strSetupParameters += string.Format(" /AGTSVCACCOUNT=\"NT AUTHORITY\\NETWORK SERVICE\"");
            strSetupParameters += string.Format(" /AGTSVCACCOUNT=\"NT AUTHORITY\\NETWORK SERVICE\"");
            //                    strSetupParameters += string.Format(" /RSSVCACCOUNT=\"NT AUTHORITY\\NETWORK SERVICE\"");// NO longer needed as of SQL 2017
            //strSetupParameters += string.Format(" /ASSVCACCOUNT=\"NT AUTHORITY\\NETWORK SERVICE\"");    // Analysis Services
            strSetupParameters += string.Format(" /ISSVCACCOUNT=\"NT AUTHORITY\\NETWORK SERVICE\"");

            // Setup filestream support
            // https://docs.microsoft.com/en-us/sql/database-engine/install-windows/install-sql-server-from-the-command-prompt?view=sql-server-ver15#Install
            //strSetupParameters += string.Format(" /FILESTREAMLEVEL=0"); // 0 =Disable FILESTREAM support for this instance. (Default value)
            //                                                            // 1=Enable FILESTREAM for Transact-SQL access.
            //                                                            // 2=Enable FILESTREAM for Transact-SQL and file I/O streaming access. (Not valid for Cluster scenarios)
            //                                                            // 3=Allow remote clients to have streaming access to FILESTREAM data.

            //strSetupParameters += string.Format(" /FILESTREAMSHARENAME=\"LOCAL_PATH\"");//The sharename has to be a local name, without a server/computer name on it. Filestream will then share the data. It isn't a UNC path, it's a local share.


            if (!string.IsNullOrEmpty(SqlServerInstallSettings.SqlInstanceName))
            {
                strSetupParameters += string.Format(" /INSTANCENAME=\"{0}\"", SqlServerInstallSettings.SqlInstanceName);
                strSetupParameters += $" /FILESTREAMLEVEL=\"{(int)SqlServerInstallSettings.FileStreamLevelSetting}\"";

                switch (SqlServerInstallSettings.FileStreamLevelSetting)
                {
                    case SQLServerInstallSettings.FileStreamLevel.Disabled:
                        break;
                    case SQLServerInstallSettings.FileStreamLevel.TSqlAccess:
                        break;
                    case SQLServerInstallSettings.FileStreamLevel.TSqlAndFileIoStreaming:
                    case SQLServerInstallSettings.FileStreamLevel.RemoteClientAccess:
                        strSetupParameters += string.Format(" /FILESTREAMSHARENAME=\"{0}\"", SqlServerInstallSettings.SqlInstanceName);//The sharename has to be a local name, without a server/computer name on it. Filestream 
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            var commandLine = strSetupParameters;
            await InstallSQLServer(commandLine);

        }

        private async void ExecuteInstallSSMSCommand(object obj)
        {
            await InstallSSMS();

        }

        private async Task InstallSSMS()
        {
            Globals.Instance.IsBusy = true;
            Globals.BusyContent = $"{Resources.DatabaseView_Busy_Content_InstallingSSMS}. {Resources.PleaseWait}";
            try
            {
                var ssmsPath = string.Format("{0}\\Installers\\SSMS\\SSMS-Setup-ENU.exe", SystemUtilities.MyFolderLocation);
                if (!File.Exists(ssmsPath))
                {

                    var openFolderDialog = new RadOpenFileDialog()
                    {
                        Filter = "Setup Applications|*.exe",
                        Owner = Application.Current.MainWindow,
                        FileName = ssmsPath

                    };
                    openFolderDialog.ShowDialog();
                    if (openFolderDialog.DialogResult == true)
                    {
                        ssmsPath = openFolderDialog.FileName;
                    }
                }

                Process proc = null;
                if (File.Exists(ssmsPath))
                {
                    String sMessageTitle = Resources.DatabaseView_SSMS_Installation_Finished;

                    proc = Process.Start(ssmsPath, string.Empty);

                    if (proc != null)
                    {
                        await proc.WaitForExitAsync();
                        if (proc.ExitCode == 0)
                        {   // SUCCESSFUL
                            ShowAlertDialog(MessageBoxView.IconType.Success, Resources.DatabaseView_The_SSMS_installation_completed_successfully, Resources.DatabaseView_Installation_Finished, true, OnShowAlertClosed);
                        }
                        else
                        {
                            ShowAlertDialog(MessageBoxView.IconType.Warning, string.Format(Resources.DatabaseView_SSMS_Install_did_not_succeed, proc.ExitCode), Resources.DatabaseView_Installation_Error, true, OnShowAlertClosed); ;
                        }
                    }
                }
                //else
                //    System.Diagnostics.Process.Start("https://aka.ms/ssmsfullsetup");

            }
            catch (FileNotFoundException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            catch (ArgumentException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            catch (Win32Exception ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            catch (ObjectDisposedException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            catch (Exception ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            Globals.Instance.IsBusy = false;
        }

        private void ExecuteDownloadSSMSCommand(object obj)
        {
            System.Diagnostics.Process.Start("https://aka.ms/ssmsfullsetup");
        }


        private bool CanExecuteInstallServerCommand(object obj)
        {
            return CanInstallServerSoftware;
        }

        private async void ExecuteInstallServerCommand(object obj)
        {
            await InstallServer();
        }

        private bool CanExecuteInstallWebUiCommand(object obj)
        {
            return CanInstallServerSoftware;
        }

        private async void ExecuteInstallWebUiCommand(object obj)
        {
            await InstallWebUi();
        }

        private async Task InstallServer()
        {
            Globals.Instance.IsBusy = true;
            Globals.BusyContent = $"{Resources.ServerView_Busy_Content_InstallingServer}. {Resources.PleaseWait}";
            try
            {
                var setupPath = string.Format("{0}\\Installers\\GalaxySMS-Server-Setup.exe", SystemUtilities.MyFolderLocation);
                if (!File.Exists(setupPath))
                {
                    var openFolderDialog = new RadOpenFileDialog()
                    {
                        Filter = "Setup Applications|*.exe",
                        Owner = Application.Current.MainWindow,
                        FileName = setupPath

                    };
                    openFolderDialog.ShowDialog();
                    if (openFolderDialog.DialogResult == true)
                    {
                        setupPath = openFolderDialog.FileName;
                    }
                }

                Process proc = null;
                if (File.Exists(setupPath))
                {
                    String sMessageTitle = Resources.ServerView_ServerSoftware_Installation_Finished;
                    var sqlAuth = 0;
                    //if( SqlServerInstallSettings.client)
                    var args = $"\"/lvx %TEMP%\\GalaxySMS-Server-Setup.log\" /v\"IS_SQLSERVER_SERVER={SelectedSqlInstance.InstanceName} IS_SQLSERVER_PASSWORD={SqlServerInstallSettings.SaPassword} IS_SQLSERVER_AUTHENTICATION={sqlAuth} GCS_SERVICE_USERNAME={GCSServiceAccountName} GCS_SERVICE_PASSWORD={GCSServiceAccountPassword}\"";

                    proc = Process.Start(setupPath, args);

                    if (proc != null)
                    {
                        await proc.WaitForExitAsync();
                        if (proc.ExitCode == 0)
                        {   // SUCCESSFUL
                            ShowAlertDialog(MessageBoxView.IconType.Success, Resources.ServerView_The_ServerSoftware_installation_completed_successfully, sMessageTitle, true, OnShowAlertClosed);
                        }
                        else
                        {
                            ShowAlertDialog(MessageBoxView.IconType.Warning, string.Format(Resources.ServerView_ServerSoftware_Install_did_not_succeed, proc.ExitCode), Resources.ServerView_Installation_Error, true, OnShowAlertClosed);
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.ServerView_Error, true, OnShowAlertClosed);
            }
            catch (ArgumentException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.ServerView_Error, true, OnShowAlertClosed);
            }
            catch (Win32Exception ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.ServerView_Error, true, OnShowAlertClosed);
            }
            catch (ObjectDisposedException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.ServerView_Error, true, OnShowAlertClosed);
            }
            catch (Exception ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.ServerView_Error, true, OnShowAlertClosed);
            }
            Globals.Instance.IsBusy = false;
        }
        
        private async Task InstallWebUi()
        {
            Globals.Instance.IsBusy = true;
            Globals.BusyContent = $"{Resources.ServerView_Busy_Content_InstallingWebUI}. {Resources.PleaseWait}";
            try
            {
                var setupPath = string.Format("{0}\\Installers\\GalaxySMS-WebUI-Setup.exe", SystemUtilities.MyFolderLocation);
                if (!File.Exists(setupPath))
                {
                    var openFolderDialog = new RadOpenFileDialog()
                    {
                        Filter = "Setup Applications|*.exe",
                        Owner = Application.Current.MainWindow,
                        FileName = setupPath

                    };
                    openFolderDialog.ShowDialog();
                    if (openFolderDialog.DialogResult == true)
                    {
                        setupPath = openFolderDialog.FileName;
                    }
                }

                Process proc = null;
                if (File.Exists(setupPath))
                {
                    String sMessageTitle = Resources.ServerView_The_WebUISoftware_Installation_Finished;
                    //if( SqlServerInstallSettings.client)
                    var args = string.Empty;

                    proc = Process.Start(setupPath, args);

                    if (proc != null)
                    {
                        await proc.WaitForExitAsync();
                        if (proc.ExitCode == 0)
                        {   // SUCCESSFUL
                            ShowAlertDialog(MessageBoxView.IconType.Success, Resources.ServerView_The_WebUI_installation_completed_successfully, sMessageTitle, true, OnShowAlertClosed);
                        }
                        else
                        {
                            ShowAlertDialog(MessageBoxView.IconType.Warning, string.Format(Resources.ServerView_The_WebUISoftware_Install_did_not_succeed, proc.ExitCode), Resources.ServerView_Installation_Error, true, OnShowAlertClosed);
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.ServerView_Error, true, OnShowAlertClosed);
            }
            catch (ArgumentException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.ServerView_Error, true, OnShowAlertClosed);
            }
            catch (Win32Exception ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.ServerView_Error, true, OnShowAlertClosed);
            }
            catch (ObjectDisposedException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.ServerView_Error, true, OnShowAlertClosed);
            }
            catch (Exception ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.ServerView_Error, true, OnShowAlertClosed);
            }
            Globals.Instance.IsBusy = false;
        }

        private async Task InstallDotNetFrameworkAsync()
        {
            Globals.Instance.IsBusy = true;
            Globals.BusyContent = $"{Resources.DatabaseView_Busy_Content_InstallingDotNetFramework}. {Resources.PleaseWait}";
            try
            {
                var exePath = $"{SystemUtilities.MyFolderLocation}\\NETFramework\\4.8\\ndp48-x86-x64-allos-enu.exe";
                if (!File.Exists(exePath))
                {

                    var openFolderDialog = new RadOpenFileDialog()
                    {
                        Filter = "Setup Applications|*.exe",
                        Owner = Application.Current.MainWindow,
                        FileName = exePath

                    };
                    openFolderDialog.ShowDialog();
                    if (openFolderDialog.DialogResult == true)
                    {
                        exePath = openFolderDialog.FileName;
                    }
                }

                Process proc = null;
                if (File.Exists(exePath))
                {
                    String sMessageTitle = Resources.DatabaseView_DOTNETFramework_Installation_Finished;

                    proc = Process.Start(exePath, string.Empty);

                    if (proc != null)
                    {
                        await proc.WaitForExitAsync();
                        if (proc.ExitCode == 0)
                        {   // SUCCESSFUL
                            ShowAlertDialog(MessageBoxView.IconType.Success, Resources.DatabaseView_The_DOTNETFramework_installation_completed_successfully, Resources.DatabaseView_Installation_Finished, true, OnShowAlertClosed);
                        }
                        else
                        {
                            ShowAlertDialog(MessageBoxView.IconType.Warning, string.Format(Resources.DatabaseView_DOTNETFramework_Install_did_not_succeed, proc.ExitCode), Resources.DatabaseView_Installation_Error, true, OnShowAlertClosed);
                        }
                    }
                }
                //else
                //    System.Diagnostics.Process.Start("https://aka.ms/ssmsfullsetup");

            }
            catch (FileNotFoundException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            catch (ArgumentException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            catch (Win32Exception ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            catch (ObjectDisposedException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            catch (Exception ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            Globals.Instance.IsBusy = false;
        }

        private async Task InstallSQLServer(string commandLine)
        {
            string sLogFilename = string.Empty;
            var sqlServiceName = string.Empty;
            Globals.IsBusy = true;
            Globals.BusyContent = $"{Resources.DatabaseView_Busy_Content_InstallingSqlServer}. {Resources.PleaseWait}";
            try
            {
                if (!string.IsNullOrEmpty(SqlServerInstallSettings.SqlInstanceName))
                    sqlServiceName = string.Format("MSSQL${0}", SqlServerInstallSettings.SqlInstanceName);
                else
                    sqlServiceName = string.Format("MSSQLSERVER");

                var sMessage = string.Format(Resources.DatabaseView_0_Installed_successfully, SelectedSqlVersion);
                var sMessageTitle = Resources.DatabaseView_SQL_Server_Installation_Finished;

                var myPath = SystemUtilities.MyFolderLocation;
                switch (SelectedSqlVersion.SqlType)
                {
                    case SQLVersion.SQL_TYPE.SQL2019_EXPRESS_64_BIT:
                        sLogFilename = string.Format("{0}\\Microsoft SQL Server\\150\\Setup Bootstrap\\LOG\\Summary.txt",
                            Environment.GetEnvironmentVariable("ProgramFiles"));
                        if (string.IsNullOrEmpty(this.SelectedSqlVersion.SetupPath))
                        {
                            var setupPath = string.Format("{0}\\Installers\\SQLExpress2019_x64\\setup.exe", myPath);

                            if (!File.Exists(setupPath))
                            {
                                var openFolderDialog = new RadOpenFileDialog()
                                {
                                    Filter = "Setup Applications|*.exe",
                                    Owner = Application.Current.MainWindow,
                                    FileName = setupPath

                                };
                                openFolderDialog.ShowDialog();
                                if (openFolderDialog.DialogResult == true)
                                {
                                    SelectedSqlVersion.SetupPath = openFolderDialog.FileName;
                                }
                            }
                            else
                                SelectedSqlVersion.SetupPath = setupPath;
                        }

                        if (!File.Exists(SelectedSqlVersion.SetupPath))
                        {
                            sMessage = string.Format(Resources.File_0_not_found, SelectedSqlVersion.SetupPath);
                            sMessageTitle = Resources.DatabaseView_FileNotFound_Title;

                            ShowAlertDialog(MessageBoxView.IconType.Warning, sMessage, sMessageTitle, true, OnShowAlertClosed);
                            return;
                        }

                        var exitCode = await ProcessUtilities.ExecAsync(SelectedSqlVersion.SetupPath,
                            commandLine);
                        if (exitCode == 0 || exitCode == 3010)
                        {
                            StartService(sqlServiceName, true);

                            if (AutomaticallyPublishDatabases)
                            {
                                sMessage += $"\n{Resources.DatabaseView_Will_AutomaticallyPublishDatabases}";
                                if (AutomaticallyInstallSSMS)
                                    sMessage += $"\n{Resources.DatabaseView_SSMS_ThenInstallWillStart}";
                            }
                            else if (AutomaticallyInstallSSMS)
                                sMessage += $"\n{Resources.DatabaseView_SSMS_InstallWillStart}";

                            ShowAlertDialog(MessageBoxView.IconType.Success, sMessage, sMessageTitle, true, OnShowAlertClosed);

                            GetDataSourcesFromRegistry();

                            SelectedSqlInstance = SqlInstances.FirstOrDefault(o => o.InstanceName == SqlServerInstallSettings.SqlInstanceName);


                            if (SelectedSqlInstance == null)
                                SelectedSqlInstance = SqlInstances.FirstOrDefault(o => o.IsSqlVersionOrGreater(2019));

                            if (SelectedSqlInstance == null)
                                SelectedSqlInstance = SqlInstances.FirstOrDefault(o => o.AllowInstallNewInstance == true);

                            if (SelectedSqlInstance != null && AutomaticallyPublishDatabases)
                            {
                                var bConnected = await TestConnection(SelectedSqlInstance, false);
                                if (CanExecutePublishGalaxySMSAuditDBCommand(SelectedSqlInstance))
                                {
                                    await PublishGalaxySMSAuditDB(SelectedSqlInstance, false);
                                }

                                if (CanExecutePublishGalaxySMSDBCommand(SelectedSqlInstance))
                                {
                                    await PublishGalaxySMSDB(SelectedSqlInstance, false);
                                }

                                if (CanExecutePublishGalaxySMSLoggingDBCommand(SelectedSqlInstance))
                                {
                                    await PublishGalaxySMSLoggingDB(SelectedSqlInstance, false);
                                }

                                if (CanExecutePublishGalaxySMSHangfireDBCommand(SelectedSqlInstance))
                                {
                                    await PublishGalaxySMSHangfireDB(SelectedSqlInstance, false);
                                }
                            }

                            if (AutomaticallyInstallSSMS)
                            {
                                await Task.Delay(5000);
                                await InstallSSMS();
                            }
                            // SUCCESSFUL
                            //if (bClientTools == false)
                            //{
                            //    StartService(MSSQLServiceName, true);
                            //    MessageBox.Show(sMessage, sMessageTitle);

                            //    GetLocalServersInstalledInstances();
                            //    lbExistingInstances.SelectedItem = this.txtInstanceName.Text.ToUpper();
                            //    lbExistingInstances_SelectedIndexChanged(null, null);
                            //    this.cmbAuthenticationMode.SelectedIndex = 1;
                            //    cmbAuthenticationMode_SelectedIndexChanged(null, null);
                            //    txtAuthenticationUserName.Text = "sa";
                            //    txtAuthenticationPassword.Text = txtSAPassword.Text;

                            //    this.btnCopyAndAttachDatabase_Click(null, null);
                            //    Hide();
                            //    this.btnFirewallException_Click(null, null);
                            //    if (bAttachSuccessful == true && bFirewallPokedSuccessful == true)
                            //    {
                            //        var msg = "SQL Server Express has been installed.\nThe System Galaxy database files have been attached and the Windows firewall has been opened up so client workstations can connect to the database.";
                            //        if (chkInstallSSMS.Checked == true)
                            //            msg += "\nWhen this message is closed, the SQL Server Management Studio (SSMS) installer will start.";

                            //        MessageBox.Show(msg, "SQL Server Express", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //        if (chkInstallSSMS.Checked == true)
                            //            btn_InstallSSMS_Click(null, null);

                            //        Application.Exit();
                            //    }
                            //}
                        }
                        else
                        {
                            ShowAlertDialog(MessageBoxView.IconType.Warning, string.Format(Resources.DatabaseView_SQL_Server_Express_install_failed, exitCode), Resources.DatabaseView_Installation_Error, true, OnShowAlertClosed);

                            if (sLogFilename.Length > 0)
                                Process.Start(sLogFilename);
                        }
                        break;

                }

            }
            catch (FileNotFoundException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            catch (ArgumentException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            catch (Win32Exception ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            catch (ObjectDisposedException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            catch (Exception ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            Globals.Instance.IsBusy = false;

        }

        private async Task InstallRedisAsync()
        {
            Globals.Instance.IsBusy = true;
            Globals.BusyContent = $"{Resources.DatabaseView_Busy_Content_InstallingRedis}. {Resources.PleaseWait}";
            try
            {
                var exePath = $"{SystemUtilities.MyFolderLocation}\\Installers\\Redis\\Redis-x64-3.0.504.msi";
                //var exePath =
                //    $"msiexec /quiet /i \"{SystemUtilities.MyFolderLocation}\\Installers\\Redis\\Redis-x64-3.0.504.msi\"";
                if (!File.Exists(exePath))
                {
                    var openFolderDialog = new RadOpenFileDialog()
                    {
                        Filter = "MSI Installers|*.msi",
                        Owner = Application.Current.MainWindow,
                        FileName = exePath
                    };
                    openFolderDialog.ShowDialog();
                    if (openFolderDialog.DialogResult == true)
                    {
                        exePath = openFolderDialog.FileName;
                    }
                }

                Process proc = null;
                if (File.Exists(exePath))
                {
                    String sMessageTitle = Resources.DatabaseView_Redis_Installation_Finished;

                    proc = Process.Start(exePath, string.Empty);

                    if (proc != null)
                    {
                        await proc.WaitForExitAsync();
                        if (proc.ExitCode == 0)
                        {   // SUCCESSFUL
                            ShowAlertDialog(MessageBoxView.IconType.Success, Resources.DatabaseView_The_Redis_installation_completed_successfully, Resources.DatabaseView_Installation_Finished, true, OnShowAlertClosed);
                        }
                        else
                        {
                            ShowAlertDialog(MessageBoxView.IconType.Warning, string.Format(Resources.DatabaseView_Redis_Install_did_not_succeed, proc.ExitCode), Resources.DatabaseView_Installation_Error, true, OnShowAlertClosed);
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            catch (ArgumentException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            catch (Win32Exception ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            catch (ObjectDisposedException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            catch (Exception ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            Globals.Instance.IsBusy = false;
        }

        private async Task InstallIisUrlRewriteAsync()
        {
            Globals.Instance.IsBusy = true;
            Globals.BusyContent = $"{Resources.DatabaseView_Busy_Content_InstallingUrlRewriteModule}. {Resources.PleaseWait}";
            try
            {
                var exePath = $"{SystemUtilities.MyFolderLocation}\\Installers\\IISExtensions\\rewrite_amd64_en-US.msi";

                if (!File.Exists(exePath))
                {
                    var openFolderDialog = new RadOpenFileDialog()
                    {
                        Filter = "MSI Installers|*.msi",
                        Owner = Application.Current.MainWindow,
                        FileName = exePath
                    };
                    openFolderDialog.ShowDialog();
                    if (openFolderDialog.DialogResult == true)
                    {
                        exePath = openFolderDialog.FileName;
                    }
                }

                Process proc = null;
                if (File.Exists(exePath))
                {
                    String sMessageTitle = Resources.DatabaseView_UrlRewrite_Installation_Finished;

                    proc = Process.Start(exePath, string.Empty);

                    if (proc != null)
                    {
                        await proc.WaitForExitAsync();
                        if (proc.ExitCode == 0)
                        {   // SUCCESSFUL
                            ShowAlertDialog(MessageBoxView.IconType.Success, Resources.DatabaseView_The_UrlRewrite_installation_completed_successfully, Resources.DatabaseView_Installation_Finished, true, OnShowAlertClosed);
                        }
                        else
                        {
                            ShowAlertDialog(MessageBoxView.IconType.Warning, string.Format(Resources.DatabaseView_UrlRewrite_Install_did_not_succeed, proc.ExitCode), Resources.DatabaseView_Installation_Error, true, OnShowAlertClosed);
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            catch (ArgumentException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            catch (Win32Exception ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            catch (ObjectDisposedException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            catch (Exception ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.DatabaseView_Error, true, OnShowAlertClosed);
            }
            Globals.Instance.IsBusy = false;
        }

        private void StartService(string ServiceName, bool bStart)
        {
            // Check whether the Alerter service is started.

            ServiceController sc = new ServiceController
            {
                ServiceName = ServiceName
            };

            if (sc.Status == ServiceControllerStatus.Stopped && bStart == false)
                return;

            if (sc.Status == ServiceControllerStatus.Running && bStart == true)
                return;
            if (bStart == true)
            {
                // Start the service if the current status is stopped.
                try
                {
                    // Start the service, and wait until its status is "Running".
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running);
                    ShowAlertDialog(MessageBoxView.IconType.Success, string.Format(Resources.DatabaseViewModel_service_started, ServiceName), Resources.DatabaseView_Service_Status, true, OnShowAlertClosed);

                }
                catch (InvalidOperationException)
                {
                    //                  Console.WriteLine("Could not start the Alerter service.");
                }
            }
            else
            {
                try
                {
                    // Start the service, and wait until its status is "Running".
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped);
                }
                catch (InvalidOperationException)
                {
                    //                   Console.WriteLine("Could not start the Alerter service.");
                }
            }
        }

        private void ExecuteSelectInstallFolderCommand(object obj)
        {
            SetBackgroundSubdued();
            var openFolderDialog = new RadOpenFolderDialog
            {
                Owner = Application.Current.MainWindow,
                FileName = InstallSQLFolder
            };
            openFolderDialog.ShowDialog();
            if (openFolderDialog.DialogResult == true)
            {
                InstallSQLFolder = openFolderDialog.FileName;
            }
            ClearBackgroundSubdued();
        }

        private void OnShowAlertClosed(object sender, WindowClosedEventArgs e)
        {
            ClearBackgroundSubdued();
        }

        private async void ScanForRequirementsStatus()
        {
            Globals.IsBusy = true;
            uint valueDetected = 0;
            foreach (var r in RequiredItems.Items)
            {
                switch (r.Type)
                {
                    case RequirementType.NetFramework_4_8:
                        valueDetected = IsDotNetInstalled(valueDetected, r);
                        break;

                    //case RequirementType.NetCore_3_1:
                    //    break;

                    case RequirementType.GCSServicesGroup:
                        DoesLocalGroupExist(r);
                        break;

                    case RequirementType.GCSServiceAccount:
                        DoesLocalUserExist(r);
                        break;

                    case RequirementType.SQLServerInstance:
                        IsSqlInstanceInstalled(r);
                        break;

                    //case Requirement.RequirementType.GalaxySMSDb:
                    //    break;

                    //case Requirement.RequirementType.GalaxySMSAuditActivityDb:
                    //    break;

                    case RequirementType.MSMQ:
                        //                       IsMSMQInstalled(r);
                        Globals.BusyContent = $"{Resources.DatabaseView_Busy_Content_Analyzing_MSMQ_Status}. {Resources.PleaseWait}";

                        await IsMSMQInstalledAsync(r);
                        break;

                    case RequirementType.Redis:
                        Globals.BusyContent = $"{Resources.DatabaseView_Busy_Content_Analyzing_Redis_Status}. {Resources.PleaseWait}";
                        IsRedisInstalled(r);
                        break;

                    case RequirementType.IIS:
                        //                       IsMSMQInstalled(r);
                        Globals.BusyContent = $"{Resources.DatabaseView_Busy_Content_Analyzing_IIS_Status}. {Resources.PleaseWait}";

                        await IsIISInstalledAsync(r);
                        break;
                }
            }
            RequiredItems.AllCompleted = false;
            CanInstallServerSoftware = false;
            Globals.IsBusy = false;
        }

        //private void IsMSMQInstalled(Requirement r)
        //{
        //    _msmqInstaller.RefreshMSMQStatus();
        //    if (_msmqInstaller.MSMQServiceInstalled == false)
        //        r.Status = InstallStatus.NotInstalled;
        //    else if (_msmqInstaller.IsPartiallyInstalled)
        //        r.Status = InstallStatus.PartiallyInstalled;
        //    else
        //        r.Status = InstallStatus.Installed;
        //}

        private async Task IsMSMQInstalledAsync(Requirement r)
        {
            await _msmqInstaller.RefreshMSMQStatusAsync();
            if (_msmqInstaller.MSMQServiceInstalled == false)
                r.Status = InstallStatus.NotInstalled;
            else if (_msmqInstaller.IsPartiallyInstalled)
                r.Status = InstallStatus.PartiallyInstalled;
            else
                r.Status = InstallStatus.Installed;
        }


        private async Task IsIISInstalledAsync(Requirement r)
        {
            await _iisInstaller.RefressIISStatusAsync();
            if (_iisInstaller.IisInstalled == false)
                r.Status = InstallStatus.NotInstalled;
            else if (_iisInstaller.IsPartiallyInstalled)
                r.Status = InstallStatus.PartiallyInstalled;
            else
                r.Status = InstallStatus.Installed;
        }

        private void IsSqlInstanceInstalled(Requirement r)
        {
            if (SqlInstances.Count > 1)
                r.Status = InstallStatus.Installed;
            else
                r.Status = InstallStatus.NotInstalled;
        }

        private void DoesLocalUserExist(Requirement r)
        {
            if (GCSADManager.DoesLocalUserExist(this.GCSServiceAccountName) == true)
            {
                r.Status = InstallStatus.Installed;
            }
            else
                r.Status = InstallStatus.NotInstalled;
        }

        private void DoesLocalGroupExist(Requirement r)
        {
            if (GCSADManager.DoesLocalGroupExist(this.GCSServiceGroupName) == true)
                r.Status = InstallStatus.Installed;
            else
                r.Status = InstallStatus.NotInstalled;
        }

        private uint IsDotNetInstalled(uint valueDetected, Requirement r)
        {
            if (Helpers.IsDotNetInstalled("v4", r.AcceptableValues, ref valueDetected) == true)
                r.Status = InstallStatus.Installed;
            else
                r.Status = InstallStatus.NotInstalled;
            r.ValueDetected = valueDetected;
            return valueDetected;
        }

        private bool IsRedisInstalled(Requirement r)
        {
            var bFound = Helpers.IsApplicationInstalled("{6E927557-4447-4348-AE9C-4B2EA64BDA17}");
            if (bFound == true)
                r.Status = InstallStatus.Installed;
            else
                r.Status = InstallStatus.NotInstalled;
            return bFound;
        }


        private void GetDataSourcesFromRegistry()
        {
            var sqlInstances = new List<SqlInstanceData>();
            SqlInstances = new ObservableCollection<SqlInstanceData>();

            string ServerName = Environment.MachineName;
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    foreach (var instanceName in instanceKey.GetValueNames())
                    {
                        var data = new SqlInstanceData()
                        {
                            InstanceName = $"{ServerName}\\{instanceName}",
                            InstanceData = instanceKey.GetValue(instanceName).ToString()
                        };
                        sqlInstances.Add(data);
                    }
                }

                foreach (var instanceData in sqlInstances)
                {
                    instanceKey = hklm.OpenSubKey($"SOFTWARE\\Microsoft\\Microsoft SQL Server\\{instanceData.InstanceData}\\MSSQLServer\\CurrentVersion", false);
                    foreach (var value in instanceKey.GetValueNames())
                    {
                        if (value == "CurrentVersion")
                        {
                            instanceData.CurrentVersionFromRegistry = instanceKey.GetValue(value).ToString();
                        }
                    }
                }
            }

            foreach (var o in sqlInstances)
            {
                if (o.IsSqlVersionOrGreater(2016))
                    SqlInstances.Add(o);
            }

            SqlInstances.Add(new SqlInstanceData()
            {
                InstanceName = Resources.DatabaseView_InstallNewSQLInstance,
                InstanceData = string.Empty,
                AllowInstallNewInstance = true
            });
        }

        private string GetSqlCmdPath(SqlInstanceData sqlInstance)
        {
            var pathName = "sqlcmd.exe";

            string ServerName = Environment.MachineName;
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey setupKey = hklm.OpenSubKey($"SOFTWARE\\Microsoft\\Microsoft SQL Server\\{sqlInstance.SqlVersionRawNumber}0\\Tools\\ClientSetup", false);
                if (setupKey != null)
                {
                    var toolsPath = setupKey.GetValue("ODBCToolsPath").ToString();
                    if (!string.IsNullOrEmpty(toolsPath))
                        return toolsPath + "sqlcmd.exe";
                }
            }
            return pathName;
        }

        private async Task<List<string>> GetListOfDatabases(string connectionString)
        {
            var dbs = new List<string>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                    {
                        using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                        {
                            while (dr.Read())
                            {
                                dbs.Add(dr[0].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddCustomError(new GCS.Core.Common.CustomError(ex));
                ShowAlertDialog(MessageBoxView.IconType.Stop, $"{Resources.DatabaseView_TestConnection_Fail}{Environment.NewLine}{ex.Message}", Resources.DatabaseView_TestConnection_Header, true, OnShowAlertClosed);

            }
            return dbs;
        }

        private void BuildRequirements()
        {
            int orderNumber = 0;
            RequiredItems = new Requirements();
            var req = new Requirement()
            {
                Type = RequirementType.NetFramework_4_8,
                OrderNumber = orderNumber++,
                Title = Resources.Requirement_NETFramework4_8_Title,
                Description = Resources.Requirement_NETFramework4_8_Desc,
            };
            req.AcceptableValues.Add(NetFramework4xReleaseNumbers.v48Win10May2019Update);
            req.AcceptableValues.Add(NetFramework4xReleaseNumbers.v48WindowsMay2019Update);
            req.AcceptableValues.Add(NetFramework4xReleaseNumbers.v48WindowsMay2020Update);
            req.AcceptableValues.Add(NetFramework4xReleaseNumbers.v48Windows11Server2022Update);
            req.AcceptableValues.Add(NetFramework4xReleaseNumbers.v481Windows112022Update);
            req.AcceptableValues.Add(NetFramework4xReleaseNumbers.v481Windows2022Update);
            RequiredItems.Items.Add(req);

            //RequiredItems.Items.Add(new Requirement()
            //{
            //    Type = Requirement.RequirementType.NetCore_3_1,
            //    OrderNumber = orderNumber++,
            //    Title = Resources.Requirement_NETCore3_1_Title,
            //    Description = Resources.Requirement_NETCore3_1_Desc,
            //});

            RequiredItems.Items.Add(new Requirement()
            {
                Type = RequirementType.GCSServicesGroup,
                OrderNumber = orderNumber++,
                Title = Resources.Requirement_GCSServicesGroup_Title,
                Description = Resources.Requirement_GCSServicesGroup_Desc,
            });

            RequiredItems.Items.Add(new Requirement()
            {
                Type = RequirementType.GCSServiceAccount,
                OrderNumber = orderNumber++,
                Title = Resources.Requirement_GCSServiceAccount_Title,
                Description = Resources.Requirement_GCSServiceAccount_Desc,
            });

            //RequiredItems.Items.Add(new Requirement()
            //{
            //    Type = Requirement.RequirementType.SQLServerInstance,
            //    OrderNumber = orderNumber++,
            //    Title = Resources.Requirement_SQLServerInstance_Title,
            //    Description = Resources.Requirement_SQLServerInstance_Desc,
            //});

            //RequiredItems.Items.Add(new Requirement()
            //{
            //    Type = Requirement.RequirementType.GalaxySMSDb,
            //    OrderNumber = orderNumber++,
            //    Title = Resources.Requirement_GalaxySMSDb_Title,
            //    Description = Resources.Requirement_GalaxySMSDb_Desc,
            //});

            //RequiredItems.Items.Add(new Requirement()
            //{
            //    Type = Requirement.RequirementType.GalaxySMSAuditActivityDb,
            //    OrderNumber = orderNumber++,
            //    Title = Resources.Requirement_GalaxySMSAuditActivityDb_Title,
            //    Description = Resources.Requirement_GalaxySMSAuditActivityDb_Desc,
            //});

            RequiredItems.Items.Add(new Requirement()
            {
                Type = RequirementType.MSMQ,
                OrderNumber = orderNumber++,
                Title = Resources.Requirement_MSMQ_Title,
                Description = Resources.Requirement_MSMQ_Desc,
            });

            RequiredItems.Items.Add(new Requirement()
            {
                Type = RequirementType.Redis,
                OrderNumber = orderNumber++,
                Title = Resources.Requirement_Redis_Title,
                Description = Resources.Requirement_Redis_Desc,
            });

            RequiredItems.Items.Add(new Requirement()
            {
                Type = RequirementType.IIS,
                OrderNumber = orderNumber++,
                Title = Resources.Requirement_IIS_Title,
                Description = Resources.Requirement_IIS_Desc,
            });

        }

        private void BuildSQLVersions()
        {
            SqlVersions = new ObservableCollection<SQLVersion>();
            var sqlVersion = new SQLVersion
            {
                Name = Resources.DatabaseView_SQL_Server_2019_Express,
                SqlType = SQLVersion.SQL_TYPE.SQL2019_EXPRESS_64_BIT
            };
            var myPath = SystemUtilities.MyFolderLocation;

            var setupPath = string.Format("{0}\\SQLExpress2019_x64\\setup.exe", myPath);
            if (File.Exists(setupPath))
                sqlVersion.SetupPath = setupPath;

            sqlVersion.Features.Add(new SqlFeature()
            {
                Title = "SQL Engine",
                Code = "SQLEngine",
                IsSelected = true
            });

            sqlVersion.Features.Add(new SqlFeature()
            {
                Title = "Connectivity Components",
                Code = "Conn",
                IsSelected = true
            });

            sqlVersion.Features.Add(new SqlFeature()
            {
                Title = "Replication Components",
                Code = "Replication",
                IsSelected = true
            });

            sqlVersion.Features.Add(new SqlFeature()
            {
                Title = "Full Text",
                Code = "FullText",
                IsSelected = true
            });


            sqlVersion.Features.Add(new SqlFeature()
            {
                Title = "LocalDB",
                Code = "LocalDB",
                IsSelected = true
            });

            sqlVersion.Features.Add(new SqlFeature()
            {
                Title = "Integration Services",
                Code = "IS",
                IsSelected = false
            });

            SqlVersions.Add(sqlVersion);
            SelectedSqlVersion = SqlVersions.FirstOrDefault();
        }

        #endregion

        #region Protected methods
        protected override void OnViewLoaded()
        {
            ClearCustomErrors();
        }

        #endregion
    }
}
