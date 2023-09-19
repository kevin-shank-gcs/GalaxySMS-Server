using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using GalaxySMS.Admin.Properties;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.Licensing.Entities;
using GalaxySMS.Client.SDK;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Client.SDK.WebApiClients;
using GalaxySMS.Common.Constants;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI.Core;
using GCS.Core.Common.Utils;
using GCS.Framework.Licensing;
using GCS.Framework.Utilities;
using Microsoft.Win32;
using Portable.Licensing.Prime;
using Portable.Licensing.Prime.Validation;

namespace GalaxySMS.Admin.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LicenseViewModel : ViewModelBase
    {
        #region Constructor

        public LicenseViewModel()
        {
            Attributes = Globals.Instance.MyAssemblyAtrributes;
            HeaderBackground = new LinearGradientBrush(Colors.SteelBlue, Colors.DarkGray, .5);
            MiddleBackground = new LinearGradientBrush(Colors.SkyBlue, Colors.WhiteSmoke, .5);
            GradientStartColor = Colors.Transparent;
            GradientMiddleColor = Colors.Transparent;
            GradientStopColor = Colors.Transparent;
            AboutUri = new Uri("http://www.galaxysys.com");
            AboutUriDescription = Properties.Resources.AboutView_AboutUriDescription;
            ImportLicenseFileCommand = new DelegateCommand<object>(ExecuteImportLicenseFileCommand,
                CanExecuteImportLicenseFileCommand);
            ImportLicenseOverInternetCommand =
                new DelegateCommand<object>(ExecuteGetLicenseDataFromOnlineServerCommand,
                    CanExecuteGetLicenseDataFromOnlineServerCommand);
            ActivateLicenseOverInternetCommand = new DelegateCommand<object>(ExecuteActivateLicenseOverInternetCommand, CanExecuteActivateLicenseOverInternetCommand);
            CreateActivateLicenseDataFileCommand = new DelegateCommand<object>(ExecuteCreateActivateLicenseDataFileCommand, CanExecuteCreateActivateLicenseDataFileCommand);
            CloseActivateLicenseOverInternetCommand = new DelegateCommand<object>(ExecuteCloseActivateLicenseOverInternetCommand, CanExecuteCloseActivateLicenseOverInternetCommand);
            PasteLicenseDataFromClipboardCommand =
                new DelegateCommand<object>(ExecutePasteLicenseDataFromClipboardCommand,
                    CanExecutePasteLicenseDataFromClipboardCommand);
            SaveLicenseCommand = new DelegateCommand<object>(ExecuteSaveLicenseCommand, CanExecuteSaveLicenseCommand);

            //EnsureIdProducerIsLicensedCommand = new DelegateCommand<object>(ExecuteEnsureIdProducerIsLicensedCommand, CanExecuteEnsureIdProducerIsLicensedCommand);

            _systemManager = new SystemManager(Globals.Instance.ServerConnections[0]);
            _systemManager.GetSystemCompletedEvent += _systemManager_GetSystemCompletedEvent;
            _systemManager.SaveSystemCompletedEvent += _systemManager_SaveSystemCompletedEvent;
            _systemManager.ErrorsOccurredEvent += _systemManager_ErrorsOccurredEvent;

            ActivateLicenseData = new ActivateSystemLicenseData()
            {
                SystemThumbprint = Globals.MyLicense.ProductFeatures.FirstOrDefault(o => o.Key == LicenseFeatureKey.ServerThumbPrint.ToString()).Value,
                ServerSystemNumber = Globals.MyLicense.ProductFeatures.FirstOrDefault(o => o.Key == LicenseFeatureKey.ServerSystemNumber.ToString()).Value,
                LicenseKey = Globals.MyLicense.ProductFeatures.FirstOrDefault(o => o.Key == LicenseFeatureKey.SoftwareLicenseKey.ToString()).Value,
                CustomerName = Globals.MyLicense.LicensedCustomerName,
                CustomerEmailAddress = Globals.MyLicense.LicensedCustomerEmail,
                LicenseType = Common.Constants.LicenseType.Standard,
                MajorVersion = Globals.SystemData.SystemVersion.Major,
            };
            if (Globals.UserSessionToken != null)
                ActivateLicenseData.ActivatedByPersonName = Globals.UserSessionToken.UserData.UserName;
        }

        //private async void ExecuteEnsureIdProducerIsLicensedCommand(object obj)
        //{
        //    BusyContent = string.Format(Properties.Resources.LicenseView_PleaseWaitWhileIdProducerLicenseIsValidated);

        //    try
        //    {
        //        IsBusy = true;

        //        var c = new IdProducerManager(Globals.Instance.ServerConnections[0]);
        //        var idProducerLicense = await c.EnsureIsLicensedAsync(new SaveParameters<IdProducerSaveMasterLicenseParameters>()
        //        {
        //            Data = new IdProducerSaveMasterLicenseParameters()
        //            {
        //                CompanyName = Globals.MyLicense.LicensedCustomerName,
        //                IsLicensePeriodUnlimited = true,
        //                IsTrialPeriod = false,
        //                LicensedMaxPrinterCount = Globals.MyLicense.GetFeatureValue<int>(LicenseFeatureKey.MaximumBadgePrinters.ToString()),
        //                SupportsMultiplePrinters = true,
        //                DefaultTimeZone = string.Empty,
        //                IsInactive = false,
        //                IsReseller = false,
        //                MasterUserName = "galaxyApi@idProducer.com",
        //                MasterPassword = "g@1axy"
        //            }
        //        });

        //        if (c.HasErrors)
        //        {
        //            AddCustomErrors(c.Errors, true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().DebugFormat($"ExecuteEnsureIdProducerIsLicensedCommand: {ex.Message}");
        //        AddCustomError(new CustomError(ex));
        //    }

        //    IsBusy = false;

        //}

        //private bool CanExecuteEnsureIdProducerIsLicensedCommand(object obj)
        //{
        //    // The SMS license must be valid AND it must be registered for idPRODUCER
        //    if (MyLicense.IsLicenseValid)
        //    {
        //        var isIdProducerLicensed = MyLicense.GetFeatureValue<bool>(LicenseFeatureKey.BadgingSystemIdProducer.ToString());
        //        return isIdProducerLicensed;
        //    }
        //    return false;
        //}

        #endregion

        #region Private fields

        private bool? _dialogResult;
        private Brush _headerBackground;
        private Brush _middleBackground;
        private Brush _footerBackground;
        private string _headerText;
        private string _footerText;
        private AssemblyAttributes _attributes;
        private Uri _aboutUri;
        private string _aboutUriDescription;
        private LicenseData _importedLicense;
        private bool _isImportedLicenseValid;
        private IValidationFailure[] _importedLicenseValidationFailures;
        private readonly SystemManager _systemManager;

        #endregion

        #region Public properties

        public bool? DialogResult
        {
            get { return _dialogResult; }
            internal set
            {
                _dialogResult = value;
                OnPropertyChanged(() => DialogResult, false);
            }
        }

        public Color GradientStartColor { get; set; }
        public Color GradientMiddleColor { get; set; }
        public Color GradientStopColor { get; set; }

        public Brush HeaderBackground
        {
            get { return _headerBackground; }
            set
            {
                if (_headerBackground != value)
                {
                    _headerBackground = value;
                    OnPropertyChanged(() => HeaderBackground, false);
                }
            }
        }

        public Brush MiddleBackground
        {
            get { return _middleBackground; }
            set
            {
                if (_middleBackground != value)
                {
                    _middleBackground = value;
                    OnPropertyChanged(() => MiddleBackground, false);
                }
            }
        }

        public Brush FooterBackground
        {
            get { return _footerBackground; }
            set
            {
                if (_footerBackground != value)
                {
                    _footerBackground = value;
                    OnPropertyChanged(() => FooterBackground, false);
                }
            }
        }

        public Brush LicenseBorderBrush
        {
            get
            {
                if (IsLicenseValid)
                    return new SolidColorBrush(Colors.AntiqueWhite);
                return new SolidColorBrush(Colors.Red);
            }
        }

        public string HeaderText
        {
            get { return _headerText; }
            set
            {
                if (_headerText != value)
                {
                    _headerText = value;
                    OnPropertyChanged(() => HeaderText, false);
                }
            }
        }

        public string FooterText
        {
            get { return _footerText; }
            set
            {
                if (_footerText != value)
                {
                    _footerText = value;
                    OnPropertyChanged(() => FooterText, false);
                }
            }
        }

        public string CopyrightNotice
        {
            get { return Attributes.Copyright; }
        }

        public string ApplicationName
        {
            get { return Attributes.Title; }
        }

        public Guid ApplicationGuid
        {
            get { return Attributes.Guid; }
        }

        public AssemblyAttributes Attributes
        {
            get { return _attributes; }
            internal set
            {
                _attributes = value;
                OnPropertyChanged(() => Attributes, false);
            }
        }

        public Uri AboutUri
        {
            get { return _aboutUri; }
            internal set
            {
                _aboutUri = value;
                OnPropertyChanged(() => AboutUri, false);
            }
        }

        public string AboutUriDescription
        {
            get { return _aboutUriDescription; }
            set
            {
                _aboutUriDescription = value;
                OnPropertyChanged(() => AboutUriDescription, false);
            }
        }

        public Globals Globals
        {
            get { return Globals.Instance; }
        }

        public LicenseData MyLicense
        {
            get
            {
                if (ImportedLicense != null)
                    return ImportedLicense;
                return Globals.Instance.MyLicense;
            }
        }

        public bool IsLicenseValid
        {
            get
            {
                if (ImportedLicense != null)
                    return IsImportedLicenseValid;
                return Globals.Instance.MyLicense.IsLicenseValid;
            }
        }

        public bool CanUpdateLicense { get; set; }

        public IDictionary<string, string> ProductFeatures
        {
            get { return MyLicense?.License?.ProductFeatures?.GetAll(); }
        }

        public override string ViewTitle
        {
            get { return string.Format(Properties.Resources.AboutView_Title, Attributes.Title); }
        }

        public bool IsImportedLicenseValid
        {
            get
            {
                if (ImportedLicense == null)
                    return false;
                return ImportedLicense.IsLicenseValid;
            }
        }

        private ActivateSystemLicenseEditorDataModel _activateSystemLicenseEditorData;

        public ActivateSystemLicenseEditorDataModel ActivateLicenseEditorData
        {
            get { return _activateSystemLicenseEditorData; }
            set
            {
                if (_activateSystemLicenseEditorData != value)
                {
                    _activateSystemLicenseEditorData = value;
                    OnPropertyChanged(() => ActivateLicenseEditorData, true);
                }
            }
        }

        private CountryModel _selectedCountryModel;

        public CountryModel SelectedCountry
        {
            get { return _selectedCountryModel; }
            set
            {
                if (_selectedCountryModel != value)
                {
                    _selectedCountryModel = value;
                    OnPropertyChanged(() => SelectedCountry, true);
                    if (SelectedCountry != null)
                        ActivateLicenseData.CountryIso3 = SelectedCountry.Iso3;
                    else
                        ActivateLicenseData.CountryIso3 = string.Empty;
                }
            }
        }

        private StateModel _selectedStateModel;

        public StateModel SelectedState
        {
            get { return _selectedStateModel; }
            set
            {
                if (_selectedStateModel != value)
                {
                    _selectedStateModel = value;
                    OnPropertyChanged(() => SelectedState, true);
                    if (SelectedState != null)
                        ActivateLicenseData.StateProvinceCode = SelectedState.StateProvinceCode;
                    else
                        ActivateLicenseData.StateProvinceCode = string.Empty;
                }
            }
        }

        private CityModel _selectedCityModel;

        public CityModel SelectedCity
        {
            get { return _selectedCityModel; }
            set
            {
                if (_selectedCityModel != value)
                {
                    _selectedCityModel = value;
                    OnPropertyChanged(() => SelectedCity, true);
                    if (SelectedCity != null)
                        ActivateLicenseData.City = SelectedCity.CityName;
                    else
                        ActivateLicenseData.City = string.Empty;
                    Validate();
                }
            }
        }

        private string _CityName;

        public string CityName
        {
            get { return _CityName; }
            set
            {
                if (_CityName != value)
                {
                    _CityName = value;
                    OnPropertyChanged(() => CityName, true);
                }
            }
        }

        private FacilityTypeModel _selectedFacilityTypeModel;

        public FacilityTypeModel SelectedFacilityType
        {
            get { return _selectedFacilityTypeModel; }
            set
            {
                if (_selectedFacilityTypeModel != value)
                {
                    _selectedFacilityTypeModel = value;
                    OnPropertyChanged(() => SelectedFacilityType, true);
                    if (SelectedFacilityType != null)
                        ActivateLicenseData.FacilityType = SelectedFacilityType.FacilityTypeName;
                    else
                        ActivateLicenseData.FacilityType = string.Empty;

                }
            }
        }

        ActivateSystemLicenseData _activateSystemLicenseData;
        public ActivateSystemLicenseData ActivateLicenseData
        {
            get { return _activateSystemLicenseData; }
            set
            {
                if (_activateSystemLicenseData != value)
                {
                    _activateSystemLicenseData = value;
                    OnPropertyChanged(() => ActivateLicenseData, true);
                }
            }
        }

        private bool _activatingOnline;

        public bool ActivatingOnline
        {
            get { return _activatingOnline; }
            set
            {
                if (_activatingOnline != value)
                {
                    _activatingOnline = value;
                    OnPropertyChanged(() => ActivatingOnline, true);
                }
            }
        }

        #endregion Public properties

        #region Commands

        public DelegateCommand<object> ImportLicenseFileCommand { get; private set; }
        public DelegateCommand<object> ImportLicenseOverInternetCommand { get; private set; }
        public DelegateCommand<object> PasteLicenseDataFromClipboardCommand { get; private set; }
        public DelegateCommand<object> SaveLicenseCommand { get; private set; }
        public DelegateCommand<object> ActivateLicenseOverInternetCommand { get; private set; }
        public DelegateCommand<object> CloseActivateLicenseOverInternetCommand { get; private set; }
        public DelegateCommand<object> CreateActivateLicenseDataFileCommand { get; private set; }
        //public DelegateCommand<object> EnsureIdProducerIsLicensedCommand { get; private set; }
        public LicenseData ImportedLicense
        {
            get { return _importedLicense; }
            internal set
            {
                _importedLicense = value;
                OnPropertyChanged(() => ImportedLicense, true);
                OnPropertyChanged(() => IsImportedLicenseValid, true);
                OnPropertyChanged(() => LicenseBorderBrush, false);
            }
        }

        private bool CanExecuteGetLicenseDataFromOnlineServerCommand(object obj)
        {
            return true;
        }

        private async void ExecuteGetLicenseDataFromOnlineServerCommand(object obj)
        {
            try
            {
                IsBusy = true;
                ActivatingOnline = true;
                CustomErrors.Clear();
                var c = new GalaxyLicenceManagerClient();
                var licenseKey = Globals.MyLicense.ProductFeatures.FirstOrDefault(o => o.Key == LicenseFeatureKey.SoftwareLicenseKey.ToString()).Value;
                this.ActivateLicenseEditorData = await c.GetActivateLicenseEditorData(licenseKey);
                if (ActivateLicenseEditorData?.CurrentSystemLicenseData != null && !string.IsNullOrEmpty(ActivateLicenseEditorData.CurrentSystemLicenseData.LicenseKey))
                {
                    SimpleMapper.PropertyMap(ActivateLicenseEditorData.CurrentSystemLicenseData, ActivateLicenseData);
                    SelectedFacilityType = ActivateLicenseEditorData.FacilityTypes.FirstOrDefault(o => o.FacilityTypeName == ActivateLicenseData.FacilityType);
                    SelectedCountry = ActivateLicenseEditorData.Countries.FirstOrDefault(o => o.Iso3 == ActivateLicenseData.CountryIso3);
                    SelectedState = SelectedCountry?.States.FirstOrDefault(o => o.StateProvinceCode == ActivateLicenseData.StateProvinceCode);
                    SelectedCity = SelectedState?.Cities.FirstOrDefault(o => o.CityName == ActivateLicenseData.City);
                }

            }
            catch (Exception ex)
            {
                this.Log().DebugFormat($"ExecuteGetLicenseDataFromOnlineServerCommand: {ex.Message}");
                AddCustomError(new CustomError(ex));
            }
            IsBusy = false;
        }

        private bool CanExecuteImportLicenseFileCommand(object obj)
        {
            return true;
        }

        private bool CanExecuteActivateLicenseOverInternetCommand(object obj)
        {
            if (ActivateLicenseData == null)
                return false;
            return ActivateLicenseData.IsDirty;
        }

        private async void ExecuteActivateLicenseOverInternetCommand(object obj)
        {
            ValidateModel();

            if (IsValid)
            {
                BusyContent = string.Format(Properties.Resources.LicenseView_PleaseWaitWhileActivateLicense);

                try
                {
                    IsBusy = true;

                    var c = new GalaxyLicenceManagerClient();

                    var activateSystemLicenseModel = new ActivateSystemLicenseModel();
                    SimpleMapper.PropertyMap(ActivateLicenseData, activateSystemLicenseModel);

                    var licenseData = await c.ActiveSystemLicense(activateSystemLicenseModel, null);

                    if (ImportedLicense == null)
                        ImportedLicense = new LicenseData();

                    ImportedLicense.InitializeFromXmlString(licenseData.PublicKey, licenseData.LicenseContent);

                    ClearCustomErrors();
                    foreach (var err in ImportedLicense.LicenseValidationFailures)
                    {
                        AddCustomError(new CustomError(err.Message));
                    }

                    OnPropertyChanged(() => ImportedLicense, true);
                    OnPropertyChanged(() => LicenseBorderBrush, true);
                    OnPropertyChanged(() => MyLicense, true);
                    ActivatingOnline = false;

                }
                catch (Exception ex)
                {
                    this.Log().DebugFormat($"ExecuteActivateLicenseOverInternetCommand: {ex.Message}");
                    AddCustomError(new CustomError(ex));
                }

                IsBusy = false;
            }
        }
        private bool CanExecuteCloseActivateLicenseOverInternetCommand(object obj)
        {
            return true;
        }

        private bool CanExecuteCreateActivateLicenseDataFileCommand(object obj)
        {
            return true;
        }

        private void ExecuteCreateActivateLicenseDataFileCommand(object obj)
        {
            ValidateModel();

            if (IsValid)
            {

                try
                {
                    var saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = string.Format("{0}|*.licact.txt", Properties.Resources.LicenseView_ActivateLicenseDataFileSaveFilter);
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        var c = new GalaxyLicenceManagerClient();

                        var activateSystemLicenseModel = new ActivateSystemLicenseModel();
                        SimpleMapper.PropertyMap(ActivateLicenseData, activateSystemLicenseModel);
                        var licenseData = Newtonsoft.Json.JsonConvert.SerializeObject(activateSystemLicenseModel);

                        File.WriteAllText(saveFileDialog.FileName, licenseData);
                        Process.Start("notepad.exe", saveFileDialog.FileName);
                    }

                }
                catch (Exception ex)
                {
                    this.Log().DebugFormat($"ExecuteCreateActivateLicenseDataFileCommand: {ex.Message}");
                    AddCustomError(new CustomError(ex));
                }

            }
        }

        private void ExecuteCloseActivateLicenseOverInternetCommand(object obj)
        {
            ActivatingOnline = false;
        }

        private void ExecuteImportLicenseFileCommand(object obj)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = string.Format("{0}|*.gcslic.txt", Properties.Resources.LicenseView_LicenseFileOpenFilter);
            if (openFileDialog.ShowDialog() == true)
            {
                var jsonInput = File.ReadAllText(openFileDialog.FileName);

                var licenseData = Newtonsoft.Json.JsonConvert.DeserializeObject<ActivatedLicenseModel>(jsonInput);

                if (ImportedLicense == null)
                    ImportedLicense = new LicenseData();

                ImportedLicense.InitializeFromXmlString(licenseData.PublicKey, licenseData.LicenseContent);

                ClearCustomErrors();
                foreach (var err in ImportedLicense.LicenseValidationFailures)
                {
                    AddCustomError(new CustomError(err.Message));
                }

                OnPropertyChanged(() => ImportedLicense, true);
                OnPropertyChanged(() => LicenseBorderBrush, true);
                OnPropertyChanged(() => MyLicense, true);
            }
        }

        private bool CanExecutePasteLicenseDataFromClipboardCommand(object obj)
        {
            return true;
        }

        private void ExecutePasteLicenseDataFromClipboardCommand(object obj)
        {
        }

        private bool CanExecuteSaveLicenseCommand(object obj)
        {
            return IsImportedLicenseValid;
        }

        private void ExecuteSaveLicenseCommand(object obj)
        {
            if (MyLicense == null)
                return;
            var licenseString = MyLicense.ToString();
            //var systemData = Globals.SystemData;
            //systemData.License = licenseString;
            if (UseAsyncServiceCalls == false)
            {
                _systemManager.SaveSystemLicense(SystemIds.GalaxySMS_System_Id, MyLicense.PublicKey, licenseString);
            }
            else
            {
                _systemManager.SaveSystemLicenseAsync(SystemIds.GalaxySMS_System_Id, MyLicense.PublicKey, licenseString);
            }
        }

        #endregion

        #region Event handlers

        private void _systemManager_SaveSystemCompletedEvent(object sender, SaveSystemCompletedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(delegate { });
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                Globals.UpdateSystemData(e.System);
            });
        }

        private void _systemManager_ErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            foreach (var error in e.Errors)
            {
                AddCustomError(error);
            }
        }

        private void _systemManager_GetSystemCompletedEvent(object sender, GetSystemCompletedEventArgs e)
        {
        }

        #endregion
        #region Protected Methods
        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(ActivateLicenseData);
        }
        #endregion
        #region  Private methods

        #endregion
    }
}