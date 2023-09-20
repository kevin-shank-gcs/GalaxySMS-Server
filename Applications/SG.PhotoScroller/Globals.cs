using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Media.Effects;
using GalaSoft.MvvmLight.Messaging;
using GCS.SysGal.SDK;
using GCS.SysGal.SDK.ClientGatewayConnection;
using GCS.SysGal.SDK.DataClasses;
using SG.PhotoScroller.DataClasses;
using SG.PhotoScroller.Properties;
using GCS.Core.Common;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI.Core;
using GCS.Framework.Licensing.Extensions;
using GCS.Framework.Utilities;
using Portable.Licensing;
using Portable.Licensing.Validation;
using License = Portable.Licensing.License;

namespace SG.PhotoScroller
{
    public class Globals : ViewModelBase
    {
        #region Private fields
        private static Globals _instance;
        private Effect _backgroundSubduedEffect;
        private double _backgroundSubduedOpacity;
        private License _license;
        private IEnumerable<IValidationFailure> _licenseValidationFailures;
        private bool _isLicenseValid;
        private SecuritySystemManager _ssManager = new SecuritySystemManager();
        private UserToken _currentUserToken;
        #endregion

        #region Constructor
        [ImportingConstructor]
        private Globals()
        {
            _backgroundSubduedOpacity = Settings.Default.BackgroundSubduedOpacity;
            if (Settings.Default.BackgroundSubduedBlur == true)
                _backgroundSubduedEffect = new BlurEffect();
            CustomerName = Settings.Default.CustomerName;
            CustomerEmail = Settings.Default.CustomerEmail;
            ImageHeight = Properties.Settings.Default.ImageHeight;
            ImageWidth = Properties.Settings.Default.ImageWidth;
        }
        #endregion

        #region Public Properties
        public static Globals Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Globals();
                }
                return _instance;
            }
        }

        public AssemblyAttributes MyAssemblyAtrributes
        {
            get
            {
                System.Reflection.Assembly myAssembly = this.
                    GetType().Assembly;
                return GCS.Framework.Utilities.SystemUtilities.
                    GetAssemblyAttributes(ref myAssembly);
            }
        }

        public String CustomerName { get; set; }
        public String CustomerEmail { get; set; }

        public Boolean IsLicenseValid
        {
            get { return _isLicenseValid; }
            internal set { _isLicenseValid = value; }
        }

        public License MyLicense
        {
            get { return _license; }
        }

        public String LicensedCustomerName
        {
            get
            {
                if (_license == null)
                    return string.Empty;
                return _license.Customer.Name;
            }
        }

        public String LicensedCustomerCompany
        {
            get
            {
                if (_license == null)
                    return string.Empty;
                return _license.Customer.Company;
            }
        }

        public String LicensedCustomerEmail
        {
            get
            {
                if (_license == null)
                    return string.Empty;
                return _license.Customer.Email;
            }
        }

        public DateTimeOffset LicenseExpiration
        {
            get
            {
                if (_license == null)
                    return DateTimeOffset.MinValue;
                return _license.Expiration;
            }
        }

        public LicenseType LicenseType
        {
            get
            {
                if (_license == null)
                    return LicenseType.Trial;
                return _license.Type;
            }
        }

        public string LicenseTypeDescription
        {
            get
            {
                if (_license == null)
                    return Properties.Resources.AboutView_LicenseTypeNone;
                switch (LicenseType)
                {
                    case LicenseType.Standard:
                        return Properties.Resources.AboutView_LicenseTypeStandard;
                    case LicenseType.Trial:
                        return Properties.Resources.AboutView_LicenseTypeTrial;
                }
                return Properties.Resources.AboutView_LicenseTypeNone;
            }
        }
        public Guid LicenseId
        {
            get
            {
                if (_license == null)
                    return Guid.Empty;
                return _license.Id;
            }
        }

        public IEnumerable<IValidationFailure> LicenseValidationFailures
        {
            get { return _licenseValidationFailures; }
            internal set { _licenseValidationFailures = value; }
        }

        public SecuritySystemManager SSManager
        {
            get { return _ssManager; }
        }

        public Messenger Messenger { get; internal set; }
        public UserToken CurrentUserToken
        {
            get { return _currentUserToken; }
            internal set
            {
                _currentUserToken = value;
                OnPropertyChanged(() => CurrentUserToken, false);
                OnPropertyChanged(() => UserName, false);
            }
        }


        public string UserName
        {
            get
            {
                if (CurrentUserToken == null)
                    return string.Empty;
                return CurrentUserToken.Name;
            }
        }

     
        public bool IsSignedIn
        {
            get
            {
                if (CurrentUserToken != null)
                    return CurrentUserToken.IsLoggedOn;
                return false;
            }
        }

        private int _imageWidth;

        public int ImageWidth
        {
            get { return _imageWidth; }
            set
            {
                if (_imageWidth != value)
                {
                    _imageWidth = value;
                    OnPropertyChanged(() => ImageWidth, false);
                }
            }
        }

        private int _imageHeight;

        public int ImageHeight
        {
            get { return _imageHeight; }
            set
            {
                if (_imageHeight != value)
                {
                    _imageHeight = value;
                    OnPropertyChanged(() => ImageHeight, false);
                }
            }
        }
        
        #endregion

        #region Public methods
        public bool Init()
        {
            string myProcessName = GCS.Framework.Utilities.SystemUtilities.MyProcessName;

            if (myProcessName.EndsWith(".vshost"))
                myProcessName = myProcessName.Replace(".vshost", string.Empty);
            string licenseFilename = string.Format("{0}\\{1}.license",
                GCS.Framework.Utilities.SystemUtilities.MyFolderLocation,
                myProcessName);

            LoadLicense(GCS.Framework.Licensing.Constants.PublicKey, licenseFilename);
            Messenger = new Messenger();
            bool bValidLicense = SSManager.SetLicense(new GCS.SysGal.SDK.DataClasses.License("3C22FCAB-7C9C-4D41-B2B5-E5F5DBC9EBF1", string.Empty, string.Empty));

            SSManager.ActivityLogEvent += SSManager_OnActivityLogEvent;
            SSManager.ConnectionStatusEvent += SSManager_ConnectionStatusEvent;
            return true;
        }

        public bool SignIn( string userName, string password)
        {
            try
            {
                UserLogOnCredential cred = new UserLogOnCredential();
                cred.UserName = userName;
                cred.Password = password;
                CurrentUserToken = SSManager.LogOn(cred);
                if (CurrentUserToken != null)
                {
                    if (CurrentUserToken.IsLoggedOn == true)
                    {
                        OnPropertyChanged(() => IsSignedIn, false);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Log().ErrorFormat("SignIn exception: {0}", ex.Message);
            }
            OnPropertyChanged(() => IsSignedIn, false);
            return false;
        }

        public void SignOut()
        {
            if (CurrentUserToken != null)
                SSManager.LogOff(CurrentUserToken);
            CurrentUserToken = null;
            OnPropertyChanged(() => IsSignedIn, false);
        }

        public void ConnectToGalaxyServer()
        {
            ClientGatewayConnectionParameters connectionParams = new ClientGatewayConnectionParameters();
            connectionParams.ConnectionTag = Globals.Instance.MyAssemblyAtrributes.Title;

            if (Properties.Settings.Default.EncryptClientGatewayTraffic == true)
                connectionParams.EncryptionType = EncryptionTypes.GCS_AES;
            else
                connectionParams.EncryptionType = EncryptionTypes.NO_ENCRYPTION;
            SSManager.ConnectToClientGatewayService(CurrentUserToken, connectionParams);
        }
        public void DisconnectFromGalaxyServer()
        {
            SSManager.DisconnectFromClientGatewayService();
        }

  
        public bool LoadLicense(string publicKey, string licenseFilename)
        {
            try
            {
                if (File.Exists(licenseFilename) == false)
                {
                    CustomErrors.Add(new CustomError(string.Format(Properties.Resources.LicenseFileDoesNotExist, licenseFilename)));
                    return false;
                }

                using (var streamReader = new StreamReader(licenseFilename))
                {
                    _license = License.Load(streamReader);
                }

                var validationFailures = _license.Validate()
                                              .IsLicensedTo(CustomerName.Trim(), CustomerEmail.Trim())
                                              .And()
                                              .Signature(publicKey)
                                              .AssertValidLicense();

                _licenseValidationFailures = validationFailures as IValidationFailure[] ?? validationFailures.ToArray();

                foreach (var validationFailure in _licenseValidationFailures)
                {
                    CustomErrors.Add(new CustomError(string.Format("{0}: {1}", validationFailure.Message, validationFailure.HowToResolve)));
                }

                if (!_licenseValidationFailures.Any())
                    IsLicenseValid = true;
                else
                    IsLicenseValid = false;
            }
            catch (Exception ex)
            {
                CustomErrors.Add(new CustomError(ex.Message));
            }
            return IsLicenseValid;
        }

        #endregion

        #region Private methods
        private string LoadPublicKeyFile(string filename)
        {
            string sReturn = string.Empty;
            using (var streamReader = new StreamReader(filename))
            {
                sReturn = streamReader.ReadToEnd();
            }
            return sReturn;
        }
        #endregion

        #region Events
        private void SSManager_ConnectionStatusEvent(object sender, GCS.SysGal.SDK.ClientGatewayConnection.ConnectionStatusEventArgs e)
        {
            try
            {
                Messenger.Send<ClientGatewayConnectionStatus>(e.StatusData);
            }
            catch (Exception ex)
            {
                this.Log().ErrorFormat("SSManager_ConnectionStatusEvent exception: {0}", ex.Message);
            }
        }

        private void SSManager_OnActivityLogEvent(object sender, ActivityLogEventArgs e)
        {
            if (e.EventData.IsCardEvent == false)
                return;

            bool bAccept = true;
            //if (ReaderIds.Count != 0)
            //    bAccept = ReaderIds.Contains(e.EventData.DeviceIDPk);

            if (bAccept == false)
                return;

            try
            {
                var personEvent = new PersonActivityEvent(e.EventData);

                GCS.SysGal.SDK.ManagerClasses.GetPersonImageParams imageParams = new GCS.SysGal.SDK.ManagerClasses.GetPersonImageParams();
                imageParams.SelectBy = GCS.SysGal.SDK.ManagerClasses.SelectBy.PersonId;
                imageParams.PersonID = (uint)personEvent.EventData.EmployeeID;
                //imageParams.ScaleOption = GCS.SysGal.SDK.ManagerClasses.ImageScaleOption.ScaleToWidth;
                //imageParams.ScaleToWidth = Properties.Settings.Default.ImageWidth *
                //                           Properties.Settings.Default.QualityMultiplier;
                imageParams.ImageType = GCS.SysGal.SDK.DataClasses.PersonImages.ImageType.PrimaryPhoto;
                DateTimeOffset photoUpdatedAt = DateTimeOffset.MinValue;
                personEvent.Photo = GCS.SysGal.SDK.ManagerClasses.PersonManager.GetPersonImage(CurrentUserToken, imageParams, ref photoUpdatedAt);

                Messenger.Send<PersonActivityEvent>(personEvent);
            }
            catch (Exception ex)
            {
                this.Log().ErrorFormat("SSManager_OnActivityLogEvent exception: {0}", ex.Message);
            }
        }
        #endregion
    }
}
