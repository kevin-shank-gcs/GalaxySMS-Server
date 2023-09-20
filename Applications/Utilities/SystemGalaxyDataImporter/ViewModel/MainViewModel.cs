using GalaSoft.MvvmLight.Messaging;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using GCS.Core.Common;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI.Core;
using GCS.WebApi.Core;
using GCS.WebApi.SysGal.Client;
using GCS.WebApi.SysGal.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using SystemGalaxyDataImporter.Entities;
using GalaxySMSEntities = GalaxySMS.Client.Entities;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;

namespace SystemGalaxyDataImporter.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ViewTitle = "GalaxySMS Import Data from System Galaxy";
            Globals.Messenger.Register<NotificationMessage<GalaxySMSEntities.UserEntity>>(this, OnUserEntityChanged);
            Globals.Messenger.Register<NotificationMessage<GalaxySMSEntities.Site>>(this, OnSiteChanged);
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            SGSignOnCommand = new DelegateCommand<object>(OnSGSignOnCommandExecute, OnSGSignOnCommandCanExecute);
            SGSignOffCommand = new DelegateCommand<object>(OnSGSignOffCommandExecute, OnSGSignOffCommandCanExecute);
            GalaxySMSSignOnCommand = new DelegateCommand<object>(OnGalaxySMSSignOnCommandExecute, OnGalaxySMSSignOnCommandCanExecute);
            GalaxySMSSignOffCommand = new DelegateCommand<object>(OnGalaxySMSSignOffCommandExecute, OnGalaxySMSSignOffCommandCanExecute);

            EnsureMatchingEntityExistsCommand = new DelegateCommand<CompositeCustomerData>(OnEnsureMatchingEntityExistsCommandExecute);
            SyncDepartmentsCommand = new DelegateCommand<CompositeCustomerData>(OnSyncDepartmentsCommandExecute);
            SyncCardholderPropertyItemsCommand = new DelegateCommand<CompositeCustomerData>(OnSyncCardholderPropertyItemsCommandExecute);

            SyncAccessProfilesCommand = new DelegateCommand<CompositeCustomerData>(OnSyncAccessProfilesCommandExecute);
            SyncBadgeTemplatesCommand = new DelegateCommand<CompositeCustomerData>(OnSyncBadgeTemplatesCommandExecute);
            SyncPeopleCommand = new DelegateCommand<CompositeCustomerData>(OnSyncPeopleCommandExecute);
            ImportClusterIntoGalaxySMSCommand = new DelegateCommand<CompositeClusterData>(OnImportClusterIntoGalaxySMSCommandExecute);
            ImportControlPanelCommand = new DelegateCommand<ControlPanelEx>(OnImportControlPanelCommandExecute, OnImportControlPanelCommandCanExecute);
        }


        #region Private fields
        private Guid _selectEntityOnSignon = Guid.Empty;
        #endregion

        #region Public Properties
        public Globals Globals { get { return Globals.Instance; } }

        public bool AreConversionControlsVisible
        {
            get
            {
                if (Globals.SystemGalaxyConnectionData?.UserToken == null || Globals.IsUserSessionValid == false)
                    return false;
                return Globals.SystemGalaxyConnectionData.UserToken.IsLoggedOn && Globals.IsUserSessionValid;
            }
            set
            {
                OnPropertyChanged(() => AreConversionControlsVisible, false);
            }
        }

        #endregion

        #region Commands
        public DelegateCommand<object> SGSignOnCommand { get; private set; }
        public DelegateCommand<object> SGSignOffCommand { get; private set; }
        public DelegateCommand<object> GalaxySMSSignOnCommand { get; private set; }
        public DelegateCommand<object> GalaxySMSSignOffCommand { get; private set; }
        public DelegateCommand<CompositeCustomerData> EnsureMatchingEntityExistsCommand { get; set; }
        public DelegateCommand<CompositeCustomerData> SyncDepartmentsCommand { get; set; }
        public DelegateCommand<CompositeCustomerData> SyncCardholderPropertyItemsCommand { get; set; }
        public DelegateCommand<CompositeCustomerData> SyncAccessProfilesCommand { get; set; }
        public DelegateCommand<CompositeCustomerData> SyncBadgeTemplatesCommand { get; set; }
        public DelegateCommand<CompositeCustomerData> SyncPeopleCommand { get; set; }

        public DelegateCommand<CompositeClusterData> ImportClusterIntoGalaxySMSCommand { get; set; }
        public DelegateCommand<ControlPanelEx> ImportControlPanelCommand { get; set; }
        #endregion

        #region Private methods

        void LogErrors(IEnumerable<CustomError> errors, bool clearCurrentErrors)
        {
            var customErrors = errors as CustomError[] ?? errors.ToArray();
            this.AddCustomErrors(customErrors.ToList(), clearCurrentErrors);
            foreach (var e in customErrors)
                this.Log().Error(e);
        }

        private bool OnSGSignOffCommandCanExecute(object obj)
        {
            if (Globals.SystemGalaxyConnectionData?.UserToken == null)
                return false;
            return Globals.SystemGalaxyConnectionData.UserToken.IsLoggedOn;
        }

        private async void OnSGSignOffCommandExecute(object obj)
        {
            try
            {
                Globals.SystemGalaxyData?.CustomerList?.Clear();
                Globals.SystemGalaxyData?.ClusterList?.Clear();
                Globals.IsBusy = true;
                Globals.BusyContent = Properties.Resources.BusyContent_PleaseWait;

                var client = new UserClient(Globals.SystemGalaxyConnectionData.WebApiUrl);
                Globals.SystemGalaxyConnectionData.UserToken = await client.SignOff(Globals.SystemGalaxyConnectionData.UserToken, null);
                if (Globals.SystemGalaxyConnectionData.UserToken.IsLoggedOn == false)
                    Globals.SystemGalaxyConnectionData.UserToken.TokenGuid = Guid.Empty;
                OnGalaxySMSSignOffCommandExecute(null);
                AreConversionControlsVisible = false;
                this.Log().Info($"Signed out of System Galaxy API");
            }
            catch (Exception e)
            {
                this.Log().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {e.ToString()}");
            }
            Globals.IsBusy = false;
        }

        private bool OnSGSignOnCommandCanExecute(object obj)
        {
            if (Globals.SystemGalaxyConnectionData?.UserToken == null)
                return true;
            return !Globals.SystemGalaxyConnectionData.UserToken.IsLoggedOn;
        }

        private async void OnSGSignOnCommandExecute(object obj)
        {
            try
            {
                Globals.IsBusy = true;
                Globals.BusyContent = Properties.Resources.BusyContent_PleaseWait;
                var apiClient = new ApiClient(Globals.SystemGalaxyConnectionData.WebApiUrl);
                var license = new ApiLicense
                {
                    Guid = "3C22FCAB-7C9C-4D41-B2B5-E5F5DBC9EBF1",
                    CompanyName = "Galaxy Control Systems",
                    ProductName = ""
                };
                var bLicenseValid = await apiClient.SetApiLicense(license);
                if (bLicenseValid)
                {
                    Globals.SystemGalaxyConnectionData.UserToken = null;
                    var credential = new UserLogOnCredential
                    {
                        UserName = Globals.SystemGalaxyConnectionData.UserName,
                        Password = Globals.SystemGalaxyConnectionData.Password,
                        ClientMachineName = Dns.GetHostName()
                    };
                    var client = new UserClient(Globals.SystemGalaxyConnectionData.WebApiUrl);
                    Globals.SystemGalaxyConnectionData.UserToken = await client.SignOn(credential, null);
                    if (Globals.SystemGalaxyConnectionData.UserToken.IsLoggedOn)
                    {
                        var customerClient = new CustomerClient(Globals.SystemGalaxyConnectionData.WebApiUrl);
                        var customers = await customerClient.RequestCustomerList(new GetCustomerListParams(Globals.SystemGalaxyConnectionData.UserToken.TokenGuid)
                        {
                            IncludeBlankEntry = true,
                        });
                        var noCust = customers.FirstOrDefault(c => c.ID == 0);
                        if (noCust != null)
                            noCust.Name = "** NO CUSTOMER **";

                        foreach (var c in customers)
                        {
                            Globals.SystemGalaxyData.CustomerList.Add(new CompositeCustomerData(c));
                        }

                        var clusterClient = new ClusterLoopClient(Globals.SystemGalaxyConnectionData.WebApiUrl);
                        var allClusters = await clusterClient.RequestClusterList(new RequestClusterListParameters(Globals.SystemGalaxyConnectionData.UserToken.TokenGuid) { RequestClusterListBy = RequestClusterListBy.AllClusters, IncludeControllers = true });
                        foreach (var cluster in allClusters.Where(c => c.ClusterType == LoopClusterType.System600))
                        {
                            Globals.SystemGalaxyData.ClusterList.Add(new CompositeClusterData(cluster));
                        }
                    }
                    AreConversionControlsVisible = true;
                    this.Log().Info($"Signed into System Galaxy API successfully as: {Globals.SystemGalaxyConnectionData.UserToken.Name}");
                }
            }
            catch (Exception e)
            {
                this.Log().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {e.ToString()}");
            }
            Globals.IsBusy = false;

        }

        private bool OnGalaxySMSSignOffCommandCanExecute(object obj)
        {
            return Globals.UserSessionToken != null && Globals.UserSessionToken?.SessionId != Guid.Empty;
        }

        private async void OnGalaxySMSSignOffCommandExecute(object obj)
        {
            try
            {
                Globals.IsBusy = true;
                var mgr = Globals.GetManager<UserSessionManager>();
                var t = await mgr.SignOutAsync(Globals.UserSessionToken.SessionId);
                Globals.UserSignedOut(t);
                AreConversionControlsVisible = false;
                this.Log().Info($"Signed out of GalaxySMS");
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
            }
            Globals.IsBusy = false;
        }

        private bool OnGalaxySMSSignOnCommandCanExecute(object obj)
        {
            return Globals.UserSessionToken == null || Globals.UserSessionToken?.SessionId == Guid.Empty;
        }

        private async void OnGalaxySMSSignOnCommandExecute(object obj)
        {
            try
            {
                Globals.IsBusy = true;
                Globals.BusyContent = Properties.Resources.BusyContent_PleaseWait;

                var mgr = Globals.GetManager<UserSessionManager>();

                // Call the SignInRequestAsync method and save the result.
                var userSignInRequest = new GalaxySMSEntities.UserSignInRequest()
                {
                    SignInBy = GalaxySMSEntities.UserSignInRequestBase.SignInUsing.AutoDetect,
                    UserName = Globals.GalaxySMSConnectionData.UserName,
                    Password = Globals.GalaxySMSConnectionData.Password,
                    // The ApplicationId is important. The user must be allowed to use the application that is identified by this value
                    ApplicationId = mgr.ClientUserSessionData.ApplicationId,
                    IncludeEntityPhotos = true,
                    EntityPhotosPixelWidth = 200,
                    IncludeUserPhotos = true,
                    UserPhotosPixelWidth = 200,
                };

                userSignInRequest.PermissionsForApplicationIds.Add(ApplicationIds.GalaxySMS_DefaultApp_Id);


                Globals.SignInResult = await mgr.SignInRequestAsync(userSignInRequest);
                if (mgr.HasErrors)
                    LogErrors(mgr.Errors, true);
                else
                {
                    this.Log().Info($"Signed into GalaxySMS API successfully as: {Globals.SignInResult.SessionToken.UserData.UserName}");

                    // The result can be evaluated by examining the RequestResult enum value
                    if (Globals.SignInResult.RequestResult == GCS.Framework.Security.UserSignInRequestResult.Success || Globals.SignInResult.RequestResult == GCS.Framework.Security.UserSignInRequestResult.SuccessWithInfo)
                    {
                        // Select the default entity
                        Globals.CurrentUserEntity = _selectEntityOnSignon == Guid.Empty ? Globals.CurrentUserEntities.FirstOrDefault(o => o.EntityId == Globals.UserSessionToken.UserData.PrimaryEntityId) : Globals.CurrentUserEntities.FirstOrDefault(o => o.EntityId == _selectEntityOnSignon);

                        var entityMgr = Globals.GetManager<EntityManager>();
                        var allEntities = await entityMgr.GetAllEntitiesAsync(new GalaxySMSEntities.GetParametersWithPhoto() { IncludePhoto = false, IncludeMemberCollections = false });
                        if (entityMgr.HasErrors)
                            LogErrors(entityMgr.Errors, false);
                        else
                        {
                            foreach (var c in Globals.SystemGalaxyData.CustomerList)
                            {
                                c.SmsEntity = c.Customer.ID == 0 ? allEntities.Items.FirstOrDefault(o => o.EntityId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id) : allEntities.Items.FirstOrDefault(o => o.EntityName == c.Customer.Name);
                            }
                        }

                        await PopulateSmsClusterData();
                        //var clusterMgr = Globals.GetManager<ClusterManager>();
                        //var allClusters = await clusterMgr.GetAllClustersAsync(new GalaxySMSEntities.GetParametersWithPhoto() { IncludePhoto = false, IncludeMemberCollections = true });
                        //if (mgr.HasErrors)
                        //    LogErrors(mgr.Errors, false);
                        //else
                        //{
                        //    foreach (var c in Globals.SystemGalaxyData.ClusterList)
                        //    {
                        //        c.SmsCluster = allClusters.FirstOrDefault(o => o.ClusterName == c.SgClusterData.ClusterName);
                        //    }
                        //}
                    }
                    else
                    {

                    }
                }

                AreConversionControlsVisible = true;
            }
            catch (Exception e)
            {
                this.Log().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {e.ToString()}");
            }
            Globals.IsBusy = false;
        }

        private async Task PopulateSmsClusterData()
        {
            var clusterMgr = Globals.GetManager<ClusterManager>();
            var allClusters = await clusterMgr.GetAllClustersAsync(new GalaxySMSEntities.GetParametersWithPhoto() { IncludePhoto = false, IncludeMemberCollections = true });
            if (clusterMgr.HasErrors)
                LogErrors(clusterMgr.Errors, false);
            else
            {
                foreach (var c in Globals.SystemGalaxyData.ClusterList)
                {
                    c.SmsCluster = allClusters.FirstOrDefault(o => o.ClusterName == c.SgClusterData.ClusterName);
                }
            }
        }

        private void OnUserEntityChanged(NotificationMessage<GalaxySMSEntities.UserEntity> obj)
        {
            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}({obj?.Content?.EntityName})");
        }

        private void OnSiteChanged(NotificationMessage<GalaxySMSEntities.Site> obj)
        {
            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}({obj?.Content?.SiteName})");
        }

        private async void OnEnsureMatchingEntityExistsCommandExecute(CompositeCustomerData obj)
        {
            try
            {
                Globals.IsBusy = true;
                Globals.BusyContent = Properties.Resources.BusyContent_EnsureEntityExists;
                var mgr = Globals.GetManager<EntityManager>();
                var allEntities = await mgr.GetAllEntitiesAsync(new GalaxySMSEntities.GetParametersWithPhoto() { IncludePhoto = false, IncludeMemberCollections = false });
                if (obj.Customer.ID == 0)    // No Customer - hardcode this mapping to the default Entity 
                {
                    obj.SmsEntity = allEntities.Items.FirstOrDefault(o => o.EntityId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id);
                }
                else
                {

                }
                obj.SmsEntity = allEntities.Items.FirstOrDefault(o => o.EntityName == obj.Customer.Name);

                if (obj.SmsEntity == null)
                {   // None exists, so lets add one
                    var parameters = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.gcsEntity>()
                    {
                        SavePhoto = true,
                        Data = new GalaxySMSEntities.gcsEntity()
                        {
                            EntityName = obj.Customer.Name,
                            EntityDescription = obj.Customer.Name,
                            EntityKey = obj.Customer.Name,
                            IsActive = true
                        },
                    };

                    var newEntity = await mgr.SaveEntityAsync(parameters);
                    if (newEntity != null && newEntity.EntityId != Guid.Empty && !mgr.HasErrors)
                    {
                        this.Log().Info($"Entity created: {newEntity.Name}, EntityId:{newEntity.EntityId}");
                        obj.SmsEntity = await mgr.GetEntityAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                        {
                            UniqueId = newEntity.EntityId,
                            IncludeMemberCollections = true
                        });
                    }
                    if (mgr.HasErrors)
                    {
                        LogErrors(mgr.Errors, true);
                    }
                    else if (obj.SmsEntity != null)
                    {
                        _selectEntityOnSignon = obj.SmsEntity.EntityId;
                        var dayTypeManager = Globals.GetManager<DayTypeManager>();
                        var dayTypes = await dayTypeManager.EnsureDefaultDayTypesExistForEntityAsync(new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.DayType>()
                        {
                            //SessionId = _clientServices.UserSessionToken.SessionId,
                            CurrentEntityId = obj.SmsEntity.EntityId
                        });
                    }
                    else
                    {
                        _selectEntityOnSignon = Guid.Empty;
                    }


                    // Sign on to SmsAgain to pull the new entity into the user data
                    OnGalaxySMSSignOnCommandExecute(null);

                    // Now bring in all customer specific data
                    // Departments
                    // Access Profiles
                    // Badge templates

                }
                else if (mgr.HasErrors)
                {
                    LogErrors(mgr.Errors, true);
                }
            }
            catch (Exception e)
            {
                this.Log().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {e.ToString()}");
            }
            Globals.IsBusy = false;
        }

        private async void OnSyncPeopleCommandExecute(CompositeCustomerData obj)
        {
            try
            {
                Globals.IsBusy = true;
                Globals.BusyContent = Properties.Resources.BusyContent_EnsurePeopleExist;

                await GetFullSgCustomerData(obj, true);
                if (obj.FullSgCustomerDataCustomers == null)
                    return;

                Globals.CurrentUserEntity = Globals.CurrentUserEntities.FirstOrDefault(o => o.EntityId == obj.SmsEntity.EntityId);
                var mgr = Globals.GetManager<PersonManager>();
                var smsPeople = await mgr.SearchAsync(new GalaxySMSEntities.PersonSummarySearchParameters()
                {
                    SearchType = PersonSearchType.AllRecords
                });
                if (mgr.HasErrors)
                {
                    LogErrors(mgr.Errors, true);
                }

                var sgPersonClient = new PersonClient(Globals.SystemGalaxyConnectionData.WebApiUrl);
                Globals.BusyContent = Properties.Resources.BusyContent_GettingPersonEditingData;
                var personEditingData = await mgr.GetPersonEditingDataAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                {

                });

                var personActiveStatusType = personEditingData.PersonActiveStatusTypes.FirstOrDefault(o => o.PersonInactiveState == false);
                var personInactiveStatusType = personEditingData.PersonActiveStatusTypes.FirstOrDefault(o => o.PersonInactiveState == true);
                var personCredentialRoleAccessControl = personEditingData.PersonCredentialRoles.FirstOrDefault(o => o.Code == GalaxySMS.Common.Enums.PersonCredentialRoles.AccessControl);
                var personCredentialRoleAlarmControl = personEditingData.PersonCredentialRoles.FirstOrDefault(o => o.Code == GalaxySMS.Common.Enums.PersonCredentialRoles.AlarmControl);
                var personActivationModeImmediately = personEditingData.PersonActivationModes.FirstOrDefault(o => o.Code == PersonActivationModes.ImmediatelyActive);
                var clusterSelectionItems = new List<GalaxySMSEntities.ClusterSelectionItemBasic>();
                foreach (var r in personEditingData.AccessAndAlarmControlPermissionsEditingData.Regions)
                {
                    foreach (var s in r.Sites)
                    {
                        clusterSelectionItems.AddRange(s.Clusters);
                    }
                }

                var accessPortalMgr = Globals.GetManager<AccessPortalManager>();

                var accessPortals = await accessPortalMgr.GetAllAccessPortalsAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                {
                    CurrentEntityId = Globals.CurrentUserEntity.EntityId,
                    IncludeHardwareAddress = true,
                    IncludeMemberCollections = false,
                });

                foreach (var sgCh in obj.FullSgCustomerDataCustomers.CardholderIds)
                {
                    var smsPersonSummary = smsPeople.FirstOrDefault(o => o.SysGalEmployeeId == sgCh.Id);
                    var sgPerson = await sgPersonClient.GetPersonData(sgCh.Id, Globals.SystemGalaxyConnectionData.UserToken.TokenGuid);
                    GalaxySMSEntities.Person smsPerson = null;
                    if (smsPersonSummary != null)
                    {
                        smsPerson = await mgr.GetPersonAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                        {
                            UniqueId = smsPersonSummary.PersonUid,
                            IncludeMemberCollections = true,
                            IncludePhoto = true,
                        });
                    }

                    if (smsPerson == null)
                    {
                        // The person does not exist in Sms, so add it
                        smsPerson = new GalaxySMSEntities.Person()
                        {
                            SysGalEmployeeId = sgPerson.EMPLOYEEID,
                            EntityId = obj.SmsEntity.EntityId,
                            PersonId = sgPerson.EMPLOYEEID.ToString(),
                        };
                    }
                    else
                        smsPerson.CleanAll();
                    smsPerson.LastName = sgPerson.LASTNAME;
                    smsPerson.FirstName = sgPerson.FIRSTNAME;
                    smsPerson.MiddleName = sgPerson.MIDDLENAME;
                    smsPerson.TextData1 = sgPerson.DATA1;
                    smsPerson.TextData2 = sgPerson.DATA2;
                    smsPerson.TextData3 = sgPerson.DATA3;
                    smsPerson.TextData4 = sgPerson.DATA4;
                    smsPerson.TextData5 = sgPerson.DATA5;
                    smsPerson.TextData6 = sgPerson.DATA6;
                    smsPerson.TextData7 = sgPerson.DATA7;
                    smsPerson.TextData8 = sgPerson.DATA8;
                    smsPerson.TextData9 = sgPerson.DATA9;
                    smsPerson.TextData10 = sgPerson.DATA10;
                    smsPerson.TextData11 = sgPerson.DATA11;
                    smsPerson.TextData12 = sgPerson.DATA12;
                    smsPerson.TextData13 = sgPerson.DATA13;
                    smsPerson.TextData14 = sgPerson.DATA14;
                    smsPerson.TextData15 = sgPerson.DATA15;
                    smsPerson.TextData16 = sgPerson.DATA16;
                    smsPerson.TextData17 = sgPerson.DATA17;
                    smsPerson.TextData18 = sgPerson.DATA18;
                    smsPerson.TextData19 = sgPerson.DATA19;
                    smsPerson.TextData20 = sgPerson.DATA20;
                    smsPerson.TextData21 = sgPerson.DATA21;
                    smsPerson.TextData22 = sgPerson.DATA22;
                    smsPerson.TextData23 = sgPerson.DATA23;
                    smsPerson.TextData24 = sgPerson.DATA24;
                    smsPerson.TextData25 = sgPerson.DATA25;
                    smsPerson.TextData26 = sgPerson.DATA26;
                    smsPerson.TextData27 = sgPerson.DATA27;
                    smsPerson.TextData28 = sgPerson.DATA28;
                    smsPerson.TextData29 = sgPerson.DATA29;
                    smsPerson.TextData30 = sgPerson.DATA30;
                    smsPerson.TextData31 = sgPerson.DATA31;
                    smsPerson.TextData32 = sgPerson.DATA32;
                    smsPerson.TextData33 = sgPerson.DATA33;
                    smsPerson.TextData34 = sgPerson.DATA34;
                    smsPerson.TextData35 = sgPerson.DATA35;
                    smsPerson.TextData36 = sgPerson.DATA36;
                    smsPerson.TextData37 = sgPerson.DATA37;
                    smsPerson.TextData38 = sgPerson.DATA38;
                    smsPerson.TextData39 = sgPerson.DATA39;
                    smsPerson.TextData40 = sgPerson.DATA40;
                    smsPerson.TextData41 = sgPerson.DATA41;
                    smsPerson.TextData42 = sgPerson.DATA42;
                    smsPerson.TextData43 = sgPerson.DATA43;
                    smsPerson.TextData44 = sgPerson.DATA44;
                    smsPerson.TextData45 = sgPerson.DATA45;
                    smsPerson.TextData46 = sgPerson.DATA46;
                    smsPerson.TextData47 = sgPerson.DATA47;
                    smsPerson.TextData48 = sgPerson.DATA48;
                    smsPerson.TextData49 = sgPerson.DATA49;
                    smsPerson.TextData50 = sgPerson.DATA50;
                    smsPerson.VeryImportantPerson = sgPerson.VIP != 0;
                    smsPerson.HasPhysicalDisability = sgPerson.HASDISABILITY != 0;
                    smsPerson.HasVertigo = sgPerson.VERTIGO != 0;
                    smsPerson.Trace = sgPerson.TRACEENABLED != 0;


                    if (sgPerson.CARDDISABLED != 0 && personInactiveStatusType != null)
                        smsPerson.PersonActiveStatusTypeUid = personInactiveStatusType.PersonActiveStatusTypeUid;
                    else if (personActiveStatusType != null)
                        smsPerson.PersonActiveStatusTypeUid = personActiveStatusType.PersonActiveStatusTypeUid;

                    // Department
                    if (sgPerson.DEPARTMENTNUMBER > 0)
                    {   // Get the department from SG by number
                        var sgDept = obj.FullSgCustomerDataCustomers.Departments.FirstOrDefault(o => o.DEPARTMENTNUMBER == sgPerson.DEPARTMENTNUMBER);
                        if (sgDept != null)
                        {   // Get the SMS department by name
                            var smsDepartment = personEditingData.Departments.FirstOrDefault(o => o.DepartmentName == sgDept.NAME);
                            if (smsDepartment != null)
                                smsPerson.DepartmentUid = smsDepartment.DepartmentUid;
                        }
                    }

                    // Record type
                    if (sgPerson.CARDHOLDERTYPEID != 0)
                    {   // Get the record type from SG by number
                        var sgRecordType = obj.FullSgCustomerDataCustomers.CardholderTypes.FirstOrDefault(o => o.CARDHOLDERTYPEID == sgPerson.CARDHOLDERTYPEID);
                        if (sgRecordType != null)
                        {   // Get the SMS record type by name
                            var smsRecordType = personEditingData.PersonRecordTypes.FirstOrDefault(o => o.Display == sgRecordType.DESCRIPTION);
                            if (smsRecordType != null)
                                smsPerson.PersonRecordTypeUid = smsRecordType.PersonRecordTypeUid;
                        }
                    }

                    // Row Origin and OriginID for Active Directory
                    if (sgPerson.CardholderActiveDir != null && !string.IsNullOrEmpty(sgPerson.CardholderActiveDir.ACTIVEDIRPATH))
                    {
                        smsPerson.RowOrigin = RowOrigins.ActiveDirectory;
                        smsPerson.OriginId = sgPerson.CardholderActiveDir.ACTIVEDIRPATH;
                    }

                    //smsPerson.PersonAddresses.Add(new GalaxySMSEntities.PersonAddress()
                    //    {
                    //    });
                    //// Address
                    //var address = new GalaxySMSEntities.Address()
                    //{

                    //    StreetAddress = $"{sgPerson.ADDRESS1}{Environment.NewLine}{sgPerson.ADDRESS2}",
                    //    City = sgPerson.CITY,
                    //    PostalCode = sgPerson.POSTALCODE
                    //};

                    //if (!string.IsNullOrEmpty(address.StreetAddress))
                    //    address.StreetAddress = "Main Street";
                    //if (!string.IsNullOrEmpty(address.City))
                    //    address.City = "Anytown";
                    //if (!string.IsNullOrEmpty(address.PostalCode))
                    //    address.PostalCode = "00000";
                    //var country = personEditingData.Countries.FirstOrDefault(o => o.Iso3 == "USA");
                    //if (country != null)
                    //{
                    //    var state = country.StateProvinces.FirstOrDefault(o => o.StateProvinceCode == "MD");
                    //    if (state != null)
                    //        address.StateProvinceUid = state.StateProvinceUid;
                    //}

                    //smsPerson.PersonAddresses.Add(address);

                    // Phone #
                    if (!string.IsNullOrEmpty(sgPerson.PHONE))
                        smsPerson.PersonPhoneNumbers.Add(new GalaxySMSEntities.PersonPhoneNumber()
                        {
                            PhoneNumber = sgPerson.PHONE,
                            Label = "Phone"
                        });

                    if (!string.IsNullOrEmpty(sgPerson.HOMEPHONE))
                        smsPerson.PersonPhoneNumbers.Add(new GalaxySMSEntities.PersonPhoneNumber()
                        {
                            PhoneNumber = sgPerson.HOMEPHONE,
                            Label = "Home Phone"
                        });

                    // Select items
                    if (sgPerson.DOB != DateTimeOffset.Now.MinSqlDateTime())
                        smsPerson.DateOfBirth = sgPerson.DOB;
                    //if (sgPerson.DATE1 != DateTimeOffset.Now.MinSqlDateTime())
                    //    smsPerson = sgPerson.DATE1;

                    smsPerson.PersonAccessControlProperty.AccessProfileUid = GalaxySMS.Common.Constants.AccessProfileIds.AccessProfileId_None;

                    var photo = sgPerson.CardholderImages.FirstOrDefault(o => o.TYPEID == 1);
                    if (photo != null)
                        smsPerson.Photo.PhotoImage = photo.IMAGE;

                    // Now do the active cards first. The Access Control properties and permissions will come from the first card
                    var bAccessControlAndPermissionsSet = false;
                    var bAccessGroupsSet = false;
                    var bIOGroupsSet = false;
                    foreach (var c in sgPerson.Cards.Where(o => !string.IsNullOrEmpty(o.FULLCARDCODE)).OrderBy(o => o.CARDID))
                    {
                        var smsPersonCredential = smsPerson.PersonCredentials.FirstOrDefault(o => o.Credential?.CardNumber == c.FULLCARDCODE);                        //smsPerson.PersonCredentials.Add(smsPersonCredential);

                        if (smsPersonCredential == null)
                        {
                            smsPersonCredential = new GalaxySMSEntities.PersonCredential()
                            {
                            };
                            smsPerson.PersonCredentials.Add(smsPersonCredential);
                        }
                        else
                            smsPersonCredential.CleanAll();

                        smsPersonCredential.SysGalCardId = (short)c.CARDID;
                        smsPersonCredential.PersonCredentialRoleUid = personCredentialRoleAccessControl.PersonCredentialRoleUid;
                        smsPersonCredential.PersonActivationModeUid = GalaxySMS.Common.Constants.PersonActivationModeIds.ImmediatelyActive;
                        smsPersonCredential.PersonExpirationModeUid = PersonExpirationModeIds.NeverExpires;
                        smsPersonCredential.BadgeTemplateUid = BadgeTemplateIds.BadgeTemplateUid_None;
                        smsPersonCredential.DossierBadgeTemplateUid = BadgeTemplateIds.BadgeTemplateUid_None;
                        smsPersonCredential.AccessPortalDeferToServerBehaviorUid = AccessPortalDeferToServerBehaviorIds.Never;
                        smsPersonCredential.AccessPortalNoServerReplyBehaviorUid = AccessPortalNoServerReplyBehaviorIds.FollowPanelDecision;
                        smsPersonCredential.CredentialDescription = c.DESCRIPTION;
                        smsPersonCredential.ActivationDateTime = c.ACTIVEDATE;
                        smsPersonCredential.ExpirationDateTime = c.EXPIREDATE;
                        smsPersonCredential.UsageCount = c.MAXSWIPES;
                        smsPersonCredential.TraceEnabled = smsPerson.Trace;
                        smsPersonCredential.DuressEnabled = c.DURESSENABLED != 0;
                        smsPersonCredential.ReverseBits = c.CARDREVERSED != 0;
                        smsPersonCredential.IsActive = c.CARDDISABLED == 0;
                        smsPersonCredential.BiometricEnrollmentStatus = c.BIOBRIDGEENROLLED;
                        smsPersonCredential.BadgePrintLimit = c.BADGEMAXPRINTS;
                        smsPersonCredential.BadgePrintCount = c.BADGEPRINTCOUNT;
                        smsPersonCredential.BadgeLastPrinted = c.BADGELASTPRINTED;
                        smsPersonCredential.DossierPrintLimit = c.DOSSIERMAXPRINTS;
                        smsPersonCredential.DossierPrintCount = c.DOSSIERPRINTCOUNT;
                        smsPersonCredential.DossierLastPrinted = c.DOSSIERLASTPRINTED;

                        if (bAccessControlAndPermissionsSet == false)
                        {
                            smsPerson.PersonAccessControlProperty.CanToggleLockState = c.CANDOUBLEPRESENT != 0;
                            smsPerson.PersonAccessControlProperty.IsActive = c.CARDDISABLED == 0;
                            smsPerson.PersonAccessControlProperty.PIN = c.PIN;
                            smsPerson.PersonAccessControlProperty.PINExempt = c.PINEXEMPT != 0;
                            smsPerson.PersonAccessControlProperty.PassbackExempt = c.PASSBACKEXEMPT != 0;
                            if (c.CARDCLASSID != 0)
                            {
                                var sgAccessProfile = obj.FullSgCustomerDataCustomers.AccessProfileIds.FirstOrDefault(o => o.Id == c.CARDCLASSID);
                                if (sgAccessProfile != null)
                                {
                                    var smsAccessProfile = personEditingData.AccessProfiles.FirstOrDefault(o => o.AccessProfileName == sgAccessProfile.Value);
                                    if (smsAccessProfile != null)
                                        smsPerson.PersonAccessControlProperty.AccessProfileUid = smsAccessProfile.AccessProfileUid;
                                }
                            }

                            bAccessControlAndPermissionsSet = true;
                        }

                        if (bAccessGroupsSet == false && c.Type_x == 0)
                        {   // Access Card
                            foreach (var cld in c.CardLoopDetails)
                            {

                                var clusterData = clusterSelectionItems.FirstOrDefault(o => o.ClusterNumber == cld.LOOPID);
                                if (clusterData != null)
                                {
                                    var clusterPermissions = smsPerson.PersonClusterPermissions.FirstOrDefault(o => o.ClusterUid == clusterData.ClusterUid);
                                    if (clusterPermissions == null)
                                    {
                                        clusterPermissions = new GalaxySMSEntities.PersonClusterPermission()
                                        {
                                            ClusterUid = clusterData.ClusterUid,
                                        };
                                        smsPerson.PersonClusterPermissions.Add(clusterPermissions);
                                    }

                                    var ag = clusterData.AccessGroups.FirstOrDefault(o => o.AccessGroupNumber == cld.ACCESSGROUPNUMBER);
                                    if (ag != null)
                                        clusterPermissions.AccessGroup1.AccessGroupUid = ag.AccessGroupUid;

                                    ag = clusterData.AccessGroups.FirstOrDefault(o => o.AccessGroupNumber == cld.GROUP2NUMBER);
                                    if (ag != null)
                                        clusterPermissions.AccessGroup2.AccessGroupUid = ag.AccessGroupUid;

                                    ag = clusterData.AccessGroups.FirstOrDefault(o => o.AccessGroupNumber == cld.GROUP3NUMBER);
                                    if (ag != null)
                                        clusterPermissions.AccessGroup3.AccessGroupUid = ag.AccessGroupUid;

                                    ag = clusterData.AccessGroups.FirstOrDefault(o => o.AccessGroupNumber == cld.GROUP4NUMBER);
                                    if (ag != null)
                                    {
                                        clusterPermissions.AccessGroup4.AccessGroupUid = ag.AccessGroupUid;
                                        if (ag.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup)
                                        {
                                            var ts = clusterData.TimeSchedules.FirstOrDefault(o => o.PanelScheduleNumber == cld.PersonalizedAccessGroup.SCHEDULENUMBER);
                                            clusterPermissions.PersonPersonalAccessGroup.TimeScheduleUid = ts != null ? ts.TimeScheduleUid : TimeScheduleIds.TimeSchedule_Never;
                                            foreach (var r in cld.PersonalizedAccessGroup.Readers)
                                            {
                                                GalaxySMSEntities.AccessPortal ap = null;
                                                if (r.SUB_SECTION_ID == 0)
                                                    ap = accessPortals.Items.FirstOrDefault(o => o.ClusterNumber == r.LOOP_ID &&
                                                                                         o.PanelNumber == r.UNIT_NUMBER &&
                                                                                         o.BoardNumber == r.BOARD_ID &&
                                                                                         o.SectionNumber == r.SECTION_ID &&
                                                                                         o.NodeNumber == 1);
                                                else
                                                {
                                                    ap = accessPortals.Items.FirstOrDefault(o => o.ClusterNumber == r.LOOP_ID &&
                                                                                         o.PanelNumber == r.UNIT_NUMBER &&
                                                                                         o.BoardNumber == r.BOARD_ID &&
                                                                                         o.SectionNumber == r.SECTION_ID &&
                                                                                         o.NodeNumber == r.SUB_SECTION_ID);
                                                }
                                                if (ap != null)
                                                    clusterPermissions.PersonPersonalAccessGroup.AccessPortals.Add(new GalaxySMSEntities.AccessPortalUidItem(){AccessPortalUid = ap.AccessPortalUid});
                                                //clusterPermissions.PersonPersonalAccessGroup.AccessPortalUids.Add(ap.AccessPortalUid);
                                            }

                                            foreach (var dag in cld.PersonalizedAccessGroup.DynamicAccessGroups)
                                            {
                                                var smsAg = clusterData.AccessGroups.FirstOrDefault(o => o.AccessGroupNumber == dag.ACCESSGROUPNUMBER);
                                                if (smsAg != null)
                                                    clusterPermissions.PersonPersonalAccessGroup.DynamicAccessGroups.Add(new GalaxySMSEntities.AccessGroupUidItem(){AccessGroupUid = smsAg.AccessGroupUid });
                                                //clusterPermissions.PersonPersonalAccessGroup.DynamicAccessGroupUids.Add(smsAg.AccessGroupUid);
                                            }
                                        }
                                    }

                                }
                            }

                            bAccessGroupsSet = true;
                        }

                        if (bIOGroupsSet == false && c.Type_x == 1)
                        {
                            foreach (var cld in c.CardLoopDetails)
                            {
                                var clusterData = clusterSelectionItems.FirstOrDefault(o => o.ClusterNumber == cld.LOOPID);
                                if (clusterData != null)
                                {
                                    var clusterPermissions = smsPerson.PersonClusterPermissions.FirstOrDefault(o => o.ClusterUid == clusterData.ClusterUid);
                                    if (clusterPermissions == null)
                                    {
                                        clusterPermissions = new GalaxySMSEntities.PersonClusterPermission()
                                        {
                                            ClusterUid = clusterData.ClusterUid,
                                        };
                                        smsPerson.PersonClusterPermissions.Add(clusterPermissions);
                                    }
                                    var iog = clusterData.InputOutputGroups.FirstOrDefault(o => o.InputOutputGroupNumber == cld.PART1NUMBER);
                                    if (iog != null)
                                        clusterPermissions.InputOutputGroup1.InputOutputGroupUid = iog.InputOutputGroupUid;

                                    iog = clusterData.InputOutputGroups.FirstOrDefault(o => o.InputOutputGroupNumber == cld.PART2NUMBER);
                                    if (iog != null)
                                        clusterPermissions.InputOutputGroup2.InputOutputGroupUid = iog.InputOutputGroupUid;

                                    iog = clusterData.InputOutputGroups.FirstOrDefault(o => o.InputOutputGroupNumber == cld.PART3NUMBER);
                                    if (iog != null)
                                        clusterPermissions.InputOutputGroup3.InputOutputGroupUid = iog.InputOutputGroupUid;

                                    iog = clusterData.InputOutputGroups.FirstOrDefault(o => o.InputOutputGroupNumber == cld.PART4NUMBER);
                                    if (iog != null)
                                        clusterPermissions.InputOutputGroup4.InputOutputGroupUid = iog.InputOutputGroupUid;

                                }
                            }
                            bIOGroupsSet = true;
                        }


                        //var smsPersonCredential = new GalaxySMSEntities.PersonCredential()
                        //{
                        //    SysGalCardId = (short)c.CARDID,
                        //    PersonCredentialRoleUid = personCredentialRoleAccessControl.PersonCredentialRoleUid,
                        //    PersonActivationModeUid = GalaxySMS.Common.Constants.PersonActivationModeIds.ImmediatelyActive,
                        //    PersonExpirationModeUid = PersonExpirationModeIds.NeverExpires,
                        //    BadgeTemplateUid = BadgeTemplateIds.BadgeTemplateUid_None,
                        //    DossierBadgeTemplateUid = BadgeTemplateIds.BadgeTemplateUid_None,
                        //    AccessPortalDeferToServerBehaviorUid = AccessPortalDeferToServerBehaviorIds.Never,
                        //    AccessPortalNoServerReplyBehaviorUid = AccessPortalNoServerReplyBehaviorIds.FollowPanelDecision,
                        //    CredentialDescription = c.DESCRIPTION,
                        //    ActivationDateTime = c.ACTIVEDATE,
                        //    ExpirationDateTime = c.EXPIREDATE,
                        //    UsageCount = c.MAXSWIPES,
                        //    TraceEnabled = smsPerson.Trace,
                        //    DuressEnabled = c.DURESSENABLED != 0,
                        //    ReverseBits = c.CARDREVERSED != 0,
                        //    IsActive = c.CARDDISABLED == 0,
                        //    BiometricEnrollmentStatus = c.BIOBRIDGEENROLLED,
                        //    BadgePrintLimit = c.BADGEMAXPRINTS,
                        //    BadgePrintCount = c.BADGEPRINTCOUNT,
                        //    BadgeLastPrinted = c.BADGELASTPRINTED,
                        //    DossierPrintLimit = c.DOSSIERMAXPRINTS,
                        //    DossierPrintCount = c.DOSSIERPRINTCOUNT,
                        //    DossierLastPrinted = c.DOSSIERLASTPRINTED
                        //};

                        if (c.Type_x != 0)   // 0 = access control, 1 = alarm control
                            smsPersonCredential.PersonCredentialRoleUid = personCredentialRoleAlarmControl.PersonCredentialRoleUid;

                        if (smsPersonCredential.ActivationDateTime.HasValue && smsPersonCredential.ActivationDateTime.Value != DateTimeOffset.Now.MinSqlDateTime())
                        {
                            if (smsPersonCredential.ActivationDateTime.Value.TimeOfDay > TimeSpan.Zero)
                                smsPersonCredential.PersonActivationModeUid = GalaxySMS.Common.Constants.PersonActivationModeIds.ActivateByDateAndTime;
                            else
                                smsPersonCredential.PersonActivationModeUid = GalaxySMS.Common.Constants.PersonActivationModeIds.ActivateByDate;
                        }
                        switch (c.EXPIREMODE)
                        {
                            case 1:
                                smsPersonCredential.PersonExpirationModeUid = PersonExpirationModeIds.ExpireByDate;
                                break;

                            case 2:
                                smsPersonCredential.PersonExpirationModeUid = PersonExpirationModeIds.ExpireByUsageCount;
                                break;

                            case 3:
                                smsPersonCredential.PersonExpirationModeUid = PersonExpirationModeIds.ExpireByDateAndTime;
                                break;

                            case 0:
                            default:
                                smsPersonCredential.PersonExpirationModeUid = PersonExpirationModeIds.NeverExpires;
                                break;
                        }

                        switch (c.ALLOWSERVEROVERRIDE)
                        {
                            case 64:
                                smsPersonCredential.AccessPortalDeferToServerBehaviorUid = AccessPortalDeferToServerBehaviorIds.WhenPanelWouldDenyAccess;
                                break;

                            case 128:
                                smsPersonCredential.AccessPortalDeferToServerBehaviorUid = AccessPortalDeferToServerBehaviorIds.WhenPanelWouldGrantAccess;
                                break;

                            case 192:
                                smsPersonCredential.AccessPortalDeferToServerBehaviorUid = AccessPortalDeferToServerBehaviorIds.Always;
                                break;

                            default:
                                smsPersonCredential.AccessPortalDeferToServerBehaviorUid = AccessPortalDeferToServerBehaviorIds.Never;
                                break;
                        }

                        switch (c.OVERRIDENOREPLY)
                        {
                            case 4:
                                smsPersonCredential.AccessPortalNoServerReplyBehaviorUid = AccessPortalNoServerReplyBehaviorIds.AlwaysGrantAccess;
                                break;

                            case 8:
                                smsPersonCredential.AccessPortalNoServerReplyBehaviorUid = AccessPortalNoServerReplyBehaviorIds.AlwaysDenyAccess;
                                break;

                            default:
                                smsPersonCredential.AccessPortalNoServerReplyBehaviorUid = AccessPortalNoServerReplyBehaviorIds.FollowPanelDecision;
                                break;
                        }

                        var sgBadgeTemplate = obj.FullSgCustomerDataCustomers.BadgeTemplates.FirstOrDefault(o => o.ID == c.BADGEID);
                        if (sgBadgeTemplate != null)
                        {
                            var smsBadgeTemplate = personEditingData.BadgeTemplates.FirstOrDefault(o => o.TemplateName == sgBadgeTemplate.BADGENAME);
                            if (smsBadgeTemplate != null)
                                smsPersonCredential.BadgeTemplateUid = smsBadgeTemplate.BadgeTemplateUid;
                        }

                        sgBadgeTemplate = obj.FullSgCustomerDataCustomers.BadgeTemplates.FirstOrDefault(o => o.ID == c.DOSSIERID);
                        if (sgBadgeTemplate != null)
                        {
                            var smsBadgeTemplate = personEditingData.BadgeTemplates.FirstOrDefault(o => o.TemplateName == sgBadgeTemplate.BADGENAME);
                            if (smsBadgeTemplate != null)
                                smsPersonCredential.DossierBadgeTemplateUid = smsBadgeTemplate.BadgeTemplateUid;
                        }

                        GalaxySMSEntities.CredentialFormat credentialFormat = null;

                        switch ((GCS.WebApi.SysGal.Entities.CardDataFormatBase.Formats)c.CARDTECHNOLOGY)
                        {
                            case CardDataFormatBase.Formats.Barcode:
                            case CardDataFormatBase.Formats.MagneticStripe:
                            case CardDataFormatBase.Formats.ABA:
                                credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.MagneticStripeBarcodeAba);
                                smsPersonCredential.Credential.CardNumber = c.FULLCARDCODE;
                                break;

                            case CardDataFormatBase.Formats.Wiegand26Bit:
                                credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.Standard26Bit);
                                smsPersonCredential.Credential.Standard26Bit.FacilityCode = c.FACILITYCODE26W;
                                smsPersonCredential.Credential.Standard26Bit.IdCode = c.IDCODE26W;
                                break;

                            case CardDataFormatBase.Formats.GalaxyKeypad:
                                credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.GalaxyKeypad);
                                smsPersonCredential.Credential.CardNumber = c.FULLCARDCODE;
                                break;

                            case CardDataFormatBase.Formats.HIDCorp1000:
                                credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.Corporate1K35Bit);
                                smsPersonCredential.Credential.Corporate1K35Bit.CompanyCode = c.HIDCORP1KCOMP;
                                smsPersonCredential.Credential.Corporate1K35Bit.IdCode = c.HIDCORP1KID;
                                break;

                            case CardDataFormatBase.Formats.PIV75Bit:
                                credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.PIV75Bit);
                                smsPersonCredential.Credential.PIV75Bit.AgencyCode = c.PIVAGENCY;
                                smsPersonCredential.Credential.PIV75Bit.SiteCode = c.PIVSITE;
                                smsPersonCredential.Credential.PIV75Bit.CredentialCode = c.PIVCREDENTIAL;
                                break;

                            case CardDataFormatBase.Formats.BQT36Bit:
                                credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.Bqt36Bit);
                                smsPersonCredential.Credential.Bqt36Bit.FacilityCode = c.BQT36BFACILITYCODE;
                                smsPersonCredential.Credential.Bqt36Bit.IdCode = c.BQT36BIDCODE;
                                smsPersonCredential.Credential.Bqt36Bit.IssueCode = c.BQT36BISSUE;
                                break;

                            case CardDataFormatBase.Formats.XceedID40Bit:
                                credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.XceedId40Bit);
                                smsPersonCredential.Credential.XceedId40Bit.SiteCode = (int)c.CUSTCARDF1;
                                smsPersonCredential.Credential.XceedId40Bit.IdCode = (int)c.CUSTCARDF2;
                                break;

                            case CardDataFormatBase.Formats.USGovernmentID:
                                credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.USGovernmentID);
                                smsPersonCredential.Credential.CardNumber = c.FULLCARDCODE;
                                smsPersonCredential.Credential.CardNumberIsHex = true;
                                break;

                            case CardDataFormatBase.Formats.HIDCorp1K48Bit:
                                credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.Corporate1K48Bit);
                                smsPersonCredential.Credential.Corporate1K48Bit.CompanyCode = (int)c.CUSTCARDF1;
                                smsPersonCredential.Credential.Corporate1K48Bit.IdCode = (int)c.CUSTCARDF2;
                                break;

                            case CardDataFormatBase.Formats.Cypress37Bit:
                                credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.Cypress37Bit);
                                smsPersonCredential.Credential.Cypress37Bit.FacilityCode = (int)c.CUSTCARDF1;
                                smsPersonCredential.Credential.Cypress37Bit.IdCode = (int)c.CUSTCARDF2;
                                break;

                            case CardDataFormatBase.Formats.HIDH1030437Bit:
                                credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.H1030437Bit);
                                smsPersonCredential.Credential.H1030437Bit.FacilityCode = (int)c.CUSTCARDF1;
                                smsPersonCredential.Credential.H1030437Bit.IdCode = (int)c.CUSTCARDF2;
                                break;

                            case CardDataFormatBase.Formats.HIDH1030237Bit:
                                credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.H1030237Bit);
                                smsPersonCredential.Credential.H1030237Bit.IdCode = c.CUSTCARDF1;
                                break;

                            case CardDataFormatBase.Formats.SoftwareHouse37Bit:
                                credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.SoftwareHouse37Bit);
                                smsPersonCredential.Credential.SoftwareHouse37Bit.FacilityCode = (int)c.CUSTCARDF1;
                                smsPersonCredential.Credential.SoftwareHouse37Bit.SiteCode = (short)c.CUSTCARDF2;
                                smsPersonCredential.Credential.SoftwareHouse37Bit.IdCode = (int)c.CUSTCARDF3;
                                break;

                            case CardDataFormatBase.Formats.GalaxyStandard:
                            case CardDataFormatBase.Formats.BasIpQr:
                            case CardDataFormatBase.Formats.BtFarpointeConektMobile:
                            case CardDataFormatBase.Formats.BtHidMobileAccess:
                            case CardDataFormatBase.Formats.BtStidMobileId:
                            case CardDataFormatBase.Formats.BtAllegion:
                            case CardDataFormatBase.Formats.BtBasIp:
                            default:
                                credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.NumericCardCode);
                                smsPersonCredential.Credential.CardNumber = c.FULLCARDCODE;
                                break;

                        }


                        if (credentialFormat != null)
                        {
                            smsPersonCredential.Credential.CredentialFormatUid = credentialFormat.CredentialFormatUid;
                            smsPersonCredential.Credential.BitCount = credentialFormat.BitLength;
                        }
                        else
                        {
                            smsPersonCredential.Credential.BitCount = (short)c.BitCount;
                        }

                        //smsPerson.PersonCredentials.Add(smsPersonCredential);
                    }

                    var saveParams = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.Person>
                    {
                        Data = smsPerson,
                        SavePhoto = smsPerson.Photo?.PhotoImage != null,
                    };
                    Globals.BusyContent = Properties.Resources.BusyContent_SavingPerson + $"{smsPerson.LastName}, {smsPerson.FirstName}";

                    var savedItem = await mgr.SavePersonAsync(saveParams);
                    if (mgr.HasErrors)
                    {
                        this.Log().Info($"Failed to create Person: {smsPerson.LastName}, {smsPerson.FirstName}, SysGalRecordID: {smsPerson.SysGalEmployeeId}");
                        LogErrors(mgr.Errors, false);
                    }
                    else
                    {
                        this.Log().Info($"Person created: {savedItem.LastName}, {savedItem.FirstName}, PersonUid: {savedItem.PersonUid},  EntityId: {savedItem.EntityId}");
                    }
                }
            }
            catch (Exception e)
            {
                this.Log().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {e.ToString()}");
            }
            Globals.IsBusy = false;
        }

        //private async void OnSyncPeopleCommandExecute(CompositeCustomerData obj)
        //{
        //    try
        //    {
        //        Globals.IsBusy = true;
        //        Globals.BusyContent = Properties.Resources.BusyContent_EnsurePeopleExist;

        //        await GetFullSgCustomerData(obj, true);
        //        if (obj.FullSgCustomerDataCustomers == null)
        //            return;

        //        Globals.CurrentUserEntity = Globals.CurrentUserEntities.FirstOrDefault(o => o.EntityId == obj.SmsEntity.EntityId);
        //        var mgr = Globals.GetManager<PersonManager>();
        //        var smsPeople = await mgr.SearchAsync(new GalaxySMSEntities.PersonSummarySearchParameters()
        //        {
        //            SearchType = PersonSearchType.AllRecords
        //        });
        //        if (mgr.HasErrors)
        //        {
        //            LogErrors(mgr.Errors, true);
        //        }

        //        var sgPersonClient = new PersonClient(Globals.SystemGalaxyConnectionData.WebApiUrl);
        //        Globals.BusyContent = Properties.Resources.BusyContent_GettingPersonEditingData;
        //        var personEditingData = await mgr.GetPersonEditingDataAsync(new GalaxySMSEntities.GetParametersWithPhoto()
        //        {

        //        });

        //        var personActiveStatusType = personEditingData.PersonActiveStatusTypes.FirstOrDefault(o => o.PersonInactiveState == false);
        //        var personInactiveStatusType = personEditingData.PersonActiveStatusTypes.FirstOrDefault(o => o.PersonInactiveState == true);
        //        var personCredentialRoleAccessControl = personEditingData.PersonCredentialRoles.FirstOrDefault(o => o.Code == GalaxySMS.Common.Enums.PersonCredentialRoles.AccessControl);
        //        var personCredentialRoleAlarmControl = personEditingData.PersonCredentialRoles.FirstOrDefault(o => o.Code == GalaxySMS.Common.Enums.PersonCredentialRoles.AlarmControl);
        //        var personActivationModeImmediately = personEditingData.PersonActivationModes.FirstOrDefault(o => o.Code == PersonActivationModes.ImmediatelyActive);
        //        var clusterSelectionItems = new List<GalaxySMSEntities.ClusterSelectionItem>();
        //        foreach (var r in personEditingData.AccessAndAlarmControlPermissionsEditingData.Regions)
        //        {
        //            foreach (var s in r.Sites)
        //            {
        //                clusterSelectionItems.AddRange(s.Clusters);
        //            }
        //        }

        //        var accessPortalMgr = Globals.GetManager<AccessPortalManager>();

        //        var accessPortals = await accessPortalMgr.GetAllAccessPortalsAsync(new GalaxySMSEntities.GetParametersWithPhoto()
        //        {
        //            CurrentEntityId = Globals.CurrentUserEntity.EntityId,
        //            IncludeHardwareAddress = true,
        //            IncludeMemberCollections = false,
        //        });

        //        foreach (var sgCh in obj.FullSgCustomerDataCustomers.CardholderIds)
        //        {
        //            var smsPerson = smsPeople.FirstOrDefault(o => o.SysGalEmployeeId == sgCh.Id);
        //            var sgPerson = await sgPersonClient.GetPersonData(sgCh.Id, Globals.SystemGalaxyConnectionData.UserToken.TokenGuid);
        //            if (smsPerson == null)
        //            {   // The person does not exist in Sms, so add it
        //                var newItem = new GalaxySMSEntities.Person()
        //                {
        //                    SysGalEmployeeId = sgPerson.EMPLOYEEID,
        //                    EntityId = obj.SmsEntity.EntityId,
        //                    PersonId = sgPerson.EMPLOYEEID.ToString(),
        //                    LastName = sgPerson.LASTNAME,
        //                    FirstName = sgPerson.FIRSTNAME,
        //                    MiddleName = sgPerson.MIDDLENAME,
        //                    TextData1 = sgPerson.DATA1,
        //                    TextData2 = sgPerson.DATA2,
        //                    TextData3 = sgPerson.DATA3,
        //                    TextData4 = sgPerson.DATA4,
        //                    TextData5 = sgPerson.DATA5,
        //                    TextData6 = sgPerson.DATA6,
        //                    TextData7 = sgPerson.DATA7,
        //                    TextData8 = sgPerson.DATA8,
        //                    TextData9 = sgPerson.DATA9,
        //                    TextData10 = sgPerson.DATA10,
        //                    TextData11 = sgPerson.DATA11,
        //                    TextData12 = sgPerson.DATA12,
        //                    TextData13 = sgPerson.DATA13,
        //                    TextData14 = sgPerson.DATA14,
        //                    TextData15 = sgPerson.DATA15,
        //                    TextData16 = sgPerson.DATA16,
        //                    TextData17 = sgPerson.DATA17,
        //                    TextData18 = sgPerson.DATA18,
        //                    TextData19 = sgPerson.DATA19,
        //                    TextData20 = sgPerson.DATA20,
        //                    TextData21 = sgPerson.DATA21,
        //                    TextData22 = sgPerson.DATA22,
        //                    TextData23 = sgPerson.DATA23,
        //                    TextData24 = sgPerson.DATA24,
        //                    TextData25 = sgPerson.DATA25,
        //                    TextData26 = sgPerson.DATA26,
        //                    TextData27 = sgPerson.DATA27,
        //                    TextData28 = sgPerson.DATA28,
        //                    TextData29 = sgPerson.DATA29,
        //                    TextData30 = sgPerson.DATA30,
        //                    TextData31 = sgPerson.DATA31,
        //                    TextData32 = sgPerson.DATA32,
        //                    TextData33 = sgPerson.DATA33,
        //                    TextData34 = sgPerson.DATA34,
        //                    TextData35 = sgPerson.DATA35,
        //                    TextData36 = sgPerson.DATA36,
        //                    TextData37 = sgPerson.DATA37,
        //                    TextData38 = sgPerson.DATA38,
        //                    TextData39 = sgPerson.DATA39,
        //                    TextData40 = sgPerson.DATA40,
        //                    TextData41 = sgPerson.DATA41,
        //                    TextData42 = sgPerson.DATA42,
        //                    TextData43 = sgPerson.DATA43,
        //                    TextData44 = sgPerson.DATA44,
        //                    TextData45 = sgPerson.DATA45,
        //                    TextData46 = sgPerson.DATA46,
        //                    TextData47 = sgPerson.DATA47,
        //                    TextData48 = sgPerson.DATA48,
        //                    TextData49 = sgPerson.DATA49,
        //                    TextData50 = sgPerson.DATA50,
        //                    VeryImportantPerson = sgPerson.VIP != 0,
        //                    HasPhysicalDisability = sgPerson.HASDISABILITY != 0,
        //                    HasVertigo = sgPerson.VERTIGO != 0,
        //                    Trace = sgPerson.TRACEENABLED != 0,
        //                };

        //                if (sgPerson.CARDDISABLED != 0 && personInactiveStatusType != null)
        //                    newItem.PersonActiveStatusTypeUid = personInactiveStatusType.PersonActiveStatusTypeUid;
        //                else if (personActiveStatusType != null)
        //                    newItem.PersonActiveStatusTypeUid = personActiveStatusType.PersonActiveStatusTypeUid;

        //                // Department
        //                if (sgPerson.DEPARTMENTNUMBER > 0)
        //                {   // Get the department from SG by number
        //                    var sgDept = obj.FullSgCustomerDataCustomers.Departments.FirstOrDefault(o => o.DEPARTMENTNUMBER == sgPerson.DEPARTMENTNUMBER);
        //                    if (sgDept != null)
        //                    {   // Get the SMS department by name
        //                        var smsDepartment = personEditingData.Departments.FirstOrDefault(o => o.DepartmentName == sgDept.NAME);
        //                        if (smsDepartment != null)
        //                            newItem.DepartmentUid = smsDepartment.DepartmentUid;
        //                    }
        //                }

        //                // Record type
        //                if (sgPerson.CARDHOLDERTYPEID != 0)
        //                {   // Get the record type from SG by number
        //                    var sgRecordType = obj.FullSgCustomerDataCustomers.CardholderTypes.FirstOrDefault(o => o.CARDHOLDERTYPEID == sgPerson.CARDHOLDERTYPEID);
        //                    if (sgRecordType != null)
        //                    {   // Get the SMS record type by name
        //                        var smsRecordType = personEditingData.PersonRecordTypes.FirstOrDefault(o => o.Display == sgRecordType.DESCRIPTION);
        //                        if (smsRecordType != null)
        //                            newItem.PersonRecordTypeUid = smsRecordType.PersonRecordTypeUid;
        //                    }
        //                }

        //                // Row Origin and OriginID for Active Directory
        //                if (sgPerson.CardholderActiveDir != null && !string.IsNullOrEmpty(sgPerson.CardholderActiveDir.ACTIVEDIRPATH))
        //                {
        //                    newItem.RowOrigin = RowOrigins.ActiveDirectory;
        //                    newItem.OriginId = sgPerson.CardholderActiveDir.ACTIVEDIRPATH;
        //                }

        //                //newItem.PersonAddresses.Add(new GalaxySMSEntities.PersonAddress()
        //                //    {
        //                //    });
        //                //// Address
        //                //var address = new GalaxySMSEntities.Address()
        //                //{

        //                //    StreetAddress = $"{sgPerson.ADDRESS1}{Environment.NewLine}{sgPerson.ADDRESS2}",
        //                //    City = sgPerson.CITY,
        //                //    PostalCode = sgPerson.POSTALCODE
        //                //};

        //                //if (!string.IsNullOrEmpty(address.StreetAddress))
        //                //    address.StreetAddress = "Main Street";
        //                //if (!string.IsNullOrEmpty(address.City))
        //                //    address.City = "Anytown";
        //                //if (!string.IsNullOrEmpty(address.PostalCode))
        //                //    address.PostalCode = "00000";
        //                //var country = personEditingData.Countries.FirstOrDefault(o => o.Iso3 == "USA");
        //                //if (country != null)
        //                //{
        //                //    var state = country.StateProvinces.FirstOrDefault(o => o.StateProvinceCode == "MD");
        //                //    if (state != null)
        //                //        address.StateProvinceUid = state.StateProvinceUid;
        //                //}

        //                //newItem.PersonAddresses.Add(address);

        //                // Phone #
        //                if (!string.IsNullOrEmpty(sgPerson.PHONE))
        //                    newItem.PersonPhoneNumbers.Add(new GalaxySMSEntities.PersonPhoneNumber()
        //                    {
        //                        PhoneNumber = sgPerson.PHONE,
        //                        Label = "Phone"
        //                    });

        //                if (!string.IsNullOrEmpty(sgPerson.HOMEPHONE))
        //                    newItem.PersonPhoneNumbers.Add(new GalaxySMSEntities.PersonPhoneNumber()
        //                    {
        //                        PhoneNumber = sgPerson.HOMEPHONE,
        //                        Label = "Home Phone"
        //                    });

        //                // Select items
        //                if (sgPerson.DOB != DateTimeOffset.Now.MinSqlDateTime())
        //                    newItem.DateOfBirth = sgPerson.DOB;
        //                //if (sgPerson.DATE1 != DateTimeOffset.Now.MinSqlDateTime())
        //                //    newItem = sgPerson.DATE1;

        //                newItem.PersonAccessControlProperty.AccessProfileUid = GalaxySMS.Common.Constants.AccessProfileIds.AccessProfileId_None;

        //                var photo = sgPerson.CardholderImages.FirstOrDefault(o => o.TYPEID == 1);
        //                if (photo != null)
        //                    newItem.Photo.PhotoImage = photo.IMAGE;

        //                // Now do the active cards first. The Access Control properties and permissions will come from the first card
        //                var bAccessControlAndPermissionsSet = false;
        //                var bAccessGroupsSet = false;
        //                var bIOGroupsSet = false;
        //                foreach (var c in sgPerson.Cards.Where(o => o.FULLCARDCODE != null && o.FULLCARDCODE.Length > 0).OrderBy(o => o.CARDID))
        //                {
        //                    if (bAccessControlAndPermissionsSet == false)
        //                    {
        //                        newItem.PersonAccessControlProperty.CanToggleLockState = c.CANDOUBLEPRESENT != 0;
        //                        newItem.PersonAccessControlProperty.IsActive = c.CARDDISABLED == 0;
        //                        newItem.PersonAccessControlProperty.PIN = c.PIN;
        //                        newItem.PersonAccessControlProperty.PINExempt = c.PINEXEMPT != 0;
        //                        newItem.PersonAccessControlProperty.PassbackExempt = c.PASSBACKEXEMPT != 0;
        //                        if (c.CARDCLASSID != 0)
        //                        {
        //                            var sgAccessProfile = obj.FullSgCustomerDataCustomers.AccessProfileIds.FirstOrDefault(o => o.Id == c.CARDCLASSID);
        //                            if (sgAccessProfile != null)
        //                            {
        //                                var smsAccessProfile = personEditingData.AccessProfiles.FirstOrDefault(o => o.AccessProfileName == sgAccessProfile.Value);
        //                                if (smsAccessProfile != null)
        //                                    newItem.PersonAccessControlProperty.AccessProfileUid = smsAccessProfile.AccessProfileUid;
        //                            }
        //                        }

        //                        bAccessControlAndPermissionsSet = true;
        //                    }

        //                    if (bAccessGroupsSet == false && c.Type_x == 0)
        //                    {   // Access Card
        //                        foreach (var cld in c.CardLoopDetails)
        //                        {

        //                            var clusterData = clusterSelectionItems.FirstOrDefault(o => o.ClusterNumber == cld.LOOPID);
        //                            if (clusterData != null)
        //                            {
        //                                var clusterPermissions = newItem.PersonClusterPermissions.FirstOrDefault(o => o.ClusterUid == clusterData.ClusterUid) ??
        //                                                         new GalaxySMSEntities.PersonClusterPermission()
        //                                                         {
        //                                                             ClusterUid = clusterData.ClusterUid,
        //                                                         };

        //                                var ag = clusterData.AccessGroups.FirstOrDefault(o => o.AccessGroupNumber == cld.ACCESSGROUPNUMBER);
        //                                if (ag != null)
        //                                    clusterPermissions.AccessGroup1.AccessGroupUid = ag.AccessGroupUid;

        //                                ag = clusterData.AccessGroups.FirstOrDefault(o => o.AccessGroupNumber == cld.GROUP2NUMBER);
        //                                if (ag != null)
        //                                    clusterPermissions.AccessGroup2.AccessGroupUid = ag.AccessGroupUid;

        //                                ag = clusterData.AccessGroups.FirstOrDefault(o => o.AccessGroupNumber == cld.GROUP3NUMBER);
        //                                if (ag != null)
        //                                    clusterPermissions.AccessGroup3.AccessGroupUid = ag.AccessGroupUid;

        //                                ag = clusterData.AccessGroups.FirstOrDefault(o => o.AccessGroupNumber == cld.GROUP4NUMBER);
        //                                if (ag != null)
        //                                {
        //                                    clusterPermissions.AccessGroup4.AccessGroupUid = ag.AccessGroupUid;
        //                                    if (ag.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup)
        //                                    {
        //                                        var ts = clusterData.TimeSchedules.FirstOrDefault(o => o.PanelScheduleNumber == cld.PersonalizedAccessGroup.SCHEDULENUMBER);
        //                                        clusterPermissions.PersonPersonalAccessGroup.TimeScheduleUid = ts != null ? ts.TimeScheduleUid : TimeScheduleIds.TimeSchedule_Never;
        //                                        foreach (var r in cld.PersonalizedAccessGroup.Readers)
        //                                        {
        //                                            GalaxySMSEntities.AccessPortal ap = null;
        //                                            if (r.SUB_SECTION_ID == 0)
        //                                                ap = accessPortals.FirstOrDefault(o => o.ClusterNumber == r.LOOP_ID &&
        //                                                                                     o.PanelNumber == r.UNIT_NUMBER &&
        //                                                                                     o.BoardNumber == r.BOARD_ID &&
        //                                                                                     o.SectionNumber == r.SECTION_ID &&
        //                                                                                     o.NodeNumber == 1);
        //                                            else
        //                                            {
        //                                                ap = accessPortals.FirstOrDefault(o => o.ClusterNumber == r.LOOP_ID &&
        //                                                                                     o.PanelNumber == r.UNIT_NUMBER &&
        //                                                                                     o.BoardNumber == r.BOARD_ID &&
        //                                                                                     o.SectionNumber == r.SECTION_ID &&
        //                                                                                     o.NodeNumber == r.SUB_SECTION_ID);
        //                                            }
        //                                            if (ap != null)
        //                                                clusterPermissions.PersonPersonalAccessGroup.AccessPortalUids.Add(ap.AccessPortalUid);
        //                                        }

        //                                        foreach (var dag in cld.PersonalizedAccessGroup.DynamicAccessGroups)
        //                                        {
        //                                            var smsAg = clusterData.AccessGroups.FirstOrDefault(o => o.AccessGroupNumber == dag.ACCESSGROUPNUMBER);
        //                                            if (smsAg != null)
        //                                                clusterPermissions.PersonPersonalAccessGroup.DynamicAccessGroupUids.Add(smsAg.AccessGroupUid);
        //                                        }
        //                                    }
        //                                }

        //                                newItem.PersonClusterPermissions.Add(clusterPermissions);
        //                            }
        //                        }

        //                        bAccessGroupsSet = true;
        //                    }

        //                    if (bIOGroupsSet == false && c.Type_x == 1)
        //                    {
        //                        foreach (var cld in c.CardLoopDetails)
        //                        {
        //                            var clusterData = clusterSelectionItems.FirstOrDefault(o => o.ClusterNumber == cld.LOOPID);
        //                            if (clusterData != null)
        //                            {
        //                                var clusterPermissions = newItem.PersonClusterPermissions.FirstOrDefault(o => o.ClusterUid == clusterData.ClusterUid) ??
        //                                                         new GalaxySMSEntities.PersonClusterPermission()
        //                                                         {
        //                                                             ClusterUid = clusterData.ClusterUid,
        //                                                         };
        //                                var iog = clusterData.InputOutputGroups.FirstOrDefault(o => o.InputOutputGroupNumber == cld.PART1NUMBER);
        //                                if (iog != null)
        //                                    clusterPermissions.InputOutputGroup1.InputOutputGroupUid = iog.InputOutputGroupUid;

        //                                iog = clusterData.InputOutputGroups.FirstOrDefault(o => o.InputOutputGroupNumber == cld.PART2NUMBER);
        //                                if (iog != null)
        //                                    clusterPermissions.InputOutputGroup2.InputOutputGroupUid = iog.InputOutputGroupUid;

        //                                iog = clusterData.InputOutputGroups.FirstOrDefault(o => o.InputOutputGroupNumber == cld.PART3NUMBER);
        //                                if (iog != null)
        //                                    clusterPermissions.InputOutputGroup3.InputOutputGroupUid = iog.InputOutputGroupUid;

        //                                iog = clusterData.InputOutputGroups.FirstOrDefault(o => o.InputOutputGroupNumber == cld.PART4NUMBER);
        //                                if (iog != null)
        //                                    clusterPermissions.InputOutputGroup4.InputOutputGroupUid = iog.InputOutputGroupUid;

        //                                newItem.PersonClusterPermissions.Add(clusterPermissions);
        //                            }
        //                        }
        //                        bIOGroupsSet = true;
        //                    }
        //                    var smsPersonCredential = new GalaxySMSEntities.PersonCredential()
        //                    {
        //                        SysGalCardId = (short)c.CARDID,
        //                        PersonCredentialRoleUid = personCredentialRoleAccessControl.PersonCredentialRoleUid,
        //                        PersonActivationModeUid = GalaxySMS.Common.Constants.PersonActivationModeIds.ImmediatelyActive,
        //                        PersonExpirationModeUid = PersonExpirationModeIds.NeverExpires,
        //                        BadgeTemplateUid = BadgeTemplateIds.BadgeTemplateUid_None,
        //                        DossierBadgeTemplateUid = BadgeTemplateIds.BadgeTemplateUid_None,
        //                        AccessPortalDeferToServerBehaviorUid = AccessPortalDeferToServerBehaviorIds.Never,
        //                        AccessPortalNoServerReplyBehaviorUid = AccessPortalNoServerReplyBehaviorIds.FollowPanelDecision,
        //                        CredentialDescription = c.DESCRIPTION,
        //                        ActivationDateTime = c.ACTIVEDATE,
        //                        ExpirationDateTime = c.EXPIREDATE,
        //                        UsageCount = c.MAXSWIPES,
        //                        TraceEnabled = newItem.Trace,
        //                        DuressEnabled = c.DURESSENABLED != 0,
        //                        ReverseBits = c.CARDREVERSED != 0,
        //                        IsActive = c.CARDDISABLED == 0,
        //                        BiometricEnrollmentStatus = c.BIOBRIDGEENROLLED,
        //                        BadgePrintLimit = c.BADGEMAXPRINTS,
        //                        BadgePrintCount = c.BADGEPRINTCOUNT,
        //                        BadgeLastPrinted = c.BADGELASTPRINTED,
        //                        DossierPrintLimit = c.DOSSIERMAXPRINTS,
        //                        DossierPrintCount = c.DOSSIERPRINTCOUNT,
        //                        DossierLastPrinted = c.DOSSIERLASTPRINTED
        //                    };

        //                    if (c.Type_x != 0)   // 0 = access control, 1 = alarm control
        //                        smsPersonCredential.PersonCredentialRoleUid = personCredentialRoleAlarmControl.PersonCredentialRoleUid;

        //                    if (smsPersonCredential.ActivationDateTime != DateTimeOffset.Now.MinSqlDateTime())
        //                        smsPersonCredential.PersonActivationModeUid = GalaxySMS.Common.Constants.PersonActivationModeIds.ActivateByDate;

        //                    switch (c.EXPIREMODE)
        //                    {
        //                        case 1:
        //                            smsPersonCredential.PersonExpirationModeUid = PersonExpirationModeIds.ExpireByDate;
        //                            break;

        //                        case 2:
        //                            smsPersonCredential.PersonExpirationModeUid = PersonExpirationModeIds.ExpireByUsageCount;
        //                            break;

        //                        case 3:
        //                            smsPersonCredential.PersonExpirationModeUid = PersonExpirationModeIds.ExpireByDateAndTime;
        //                            break;

        //                        case 0:
        //                        default:
        //                            smsPersonCredential.PersonExpirationModeUid = PersonExpirationModeIds.NeverExpires;
        //                            break;
        //                    }

        //                    switch (c.ALLOWSERVEROVERRIDE)
        //                    {
        //                        case 64:
        //                            smsPersonCredential.AccessPortalDeferToServerBehaviorUid = AccessPortalDeferToServerBehaviorIds.WhenPanelWouldDenyAccess;
        //                            break;

        //                        case 128:
        //                            smsPersonCredential.AccessPortalDeferToServerBehaviorUid = AccessPortalDeferToServerBehaviorIds.WhenPanelWouldGrantAccess;
        //                            break;

        //                        case 192:
        //                            smsPersonCredential.AccessPortalDeferToServerBehaviorUid = AccessPortalDeferToServerBehaviorIds.Always;
        //                            break;

        //                        default:
        //                            smsPersonCredential.AccessPortalDeferToServerBehaviorUid = AccessPortalDeferToServerBehaviorIds.Never;
        //                            break;
        //                    }

        //                    switch (c.OVERRIDENOREPLY)
        //                    {
        //                        case 4:
        //                            smsPersonCredential.AccessPortalNoServerReplyBehaviorUid = AccessPortalNoServerReplyBehaviorIds.AlwaysGrantAccess;
        //                            break;

        //                        case 8:
        //                            smsPersonCredential.AccessPortalNoServerReplyBehaviorUid = AccessPortalNoServerReplyBehaviorIds.AlwaysDenyAccess;
        //                            break;

        //                        default:
        //                            smsPersonCredential.AccessPortalNoServerReplyBehaviorUid = AccessPortalNoServerReplyBehaviorIds.FollowPanelDecision;
        //                            break;
        //                    }

        //                    var sgBadgeTemplate = obj.FullSgCustomerDataCustomers.BadgeTemplates.FirstOrDefault(o => o.ID == c.BADGEID);
        //                    if (sgBadgeTemplate != null)
        //                    {
        //                        var smsBadgeTemplate = personEditingData.BadgeTemplates.FirstOrDefault(o => o.TemplateName == sgBadgeTemplate.BADGENAME);
        //                        if (smsBadgeTemplate != null)
        //                            smsPersonCredential.BadgeTemplateUid = smsBadgeTemplate.BadgeTemplateUid;
        //                    }

        //                    sgBadgeTemplate = obj.FullSgCustomerDataCustomers.BadgeTemplates.FirstOrDefault(o => o.ID == c.DOSSIERID);
        //                    if (sgBadgeTemplate != null)
        //                    {
        //                        var smsBadgeTemplate = personEditingData.BadgeTemplates.FirstOrDefault(o => o.TemplateName == sgBadgeTemplate.BADGENAME);
        //                        if (smsBadgeTemplate != null)
        //                            smsPersonCredential.DossierBadgeTemplateUid = smsBadgeTemplate.BadgeTemplateUid;
        //                    }

        //                    GalaxySMSEntities.CredentialFormat credentialFormat = null;

        //                    switch ((GCS.WebApi.SysGal.Entities.CardDataFormatBase.Formats)c.CARDTECHNOLOGY)
        //                    {
        //                        case CardDataFormatBase.Formats.Barcode:
        //                        case CardDataFormatBase.Formats.MagneticStripe:
        //                        case CardDataFormatBase.Formats.ABA:
        //                            credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.MagneticStripeBarcodeAba);
        //                            smsPersonCredential.Credential.CardNumber = c.FULLCARDCODE;
        //                            break;

        //                        case CardDataFormatBase.Formats.Wiegand26Bit:
        //                            credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.Wiegand26Bit);
        //                            smsPersonCredential.Credential.Credential26BitStandard.FacilityCode = c.FACILITYCODE26W;
        //                            smsPersonCredential.Credential.Credential26BitStandard.IdCode = c.IDCODE26W;
        //                            break;

        //                        case CardDataFormatBase.Formats.GalaxyKeypad:
        //                            credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.GalaxyKeypad);
        //                            smsPersonCredential.Credential.CardNumber = c.FULLCARDCODE;
        //                            break;

        //                        case CardDataFormatBase.Formats.HIDCorp1000:
        //                            credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.HIDCorp1K35Bit);
        //                            smsPersonCredential.Credential.CredentialCorporate1K35Bit.CompanyCode = c.HIDCORP1KCOMP;
        //                            smsPersonCredential.Credential.CredentialCorporate1K35Bit.IdCode = c.HIDCORP1KID;
        //                            break;

        //                        case CardDataFormatBase.Formats.PIV75Bit:
        //                            credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.PIV75Bit);
        //                            smsPersonCredential.Credential.CredentialPIV75Bit.AgencyCode = c.PIVAGENCY;
        //                            smsPersonCredential.Credential.CredentialPIV75Bit.SiteCode = c.PIVSITE;
        //                            smsPersonCredential.Credential.CredentialPIV75Bit.CredentialCode = c.PIVCREDENTIAL;
        //                            break;

        //                        case CardDataFormatBase.Formats.BQT36Bit:
        //                            credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.BQT36Bit);
        //                            smsPersonCredential.Credential.CredentialBqt36Bit.FacilityCode = c.BQT36BFACILITYCODE;
        //                            smsPersonCredential.Credential.CredentialBqt36Bit.IdCode = c.BQT36BIDCODE;
        //                            smsPersonCredential.Credential.CredentialBqt36Bit.IssueCode = c.BQT36BISSUE;
        //                            break;

        //                        case CardDataFormatBase.Formats.XceedID40Bit:
        //                            credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.XceedID40Bit);
        //                            smsPersonCredential.Credential.CredentialXceedId40Bit.SiteCode = (int)c.CUSTCARDF1;
        //                            smsPersonCredential.Credential.CredentialXceedId40Bit.IdCode = (int)c.CUSTCARDF2;
        //                            break;

        //                        case CardDataFormatBase.Formats.USGovernmentID:
        //                            credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.USGovernmentID);
        //                            smsPersonCredential.Credential.CardNumber = c.FULLCARDCODE;
        //                            smsPersonCredential.Credential.CardNumberIsHex = true;
        //                            break;

        //                        case CardDataFormatBase.Formats.HIDCorp1K48Bit:
        //                            credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.HIDCorp1K48Bit);
        //                            smsPersonCredential.Credential.CredentialCorporate1K48Bit.CompanyCode = (int)c.CUSTCARDF1;
        //                            smsPersonCredential.Credential.CredentialCorporate1K48Bit.IdCode = (int)c.CUSTCARDF2;
        //                            break;

        //                        case CardDataFormatBase.Formats.Cypress37Bit:
        //                            credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.Cypress37Bit);
        //                            smsPersonCredential.Credential.CredentialCypress37Bit.FacilityCode = (int)c.CUSTCARDF1;
        //                            smsPersonCredential.Credential.CredentialCypress37Bit.IdCode = (int)c.CUSTCARDF2;
        //                            break;

        //                        case CardDataFormatBase.Formats.HIDH1030437Bit:
        //                            credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.HIDH1030437Bit);
        //                            smsPersonCredential.Credential.CredentialH1030437Bit.FacilityCode = (int)c.CUSTCARDF1;
        //                            smsPersonCredential.Credential.CredentialH1030437Bit.IdCode = (int)c.CUSTCARDF2;
        //                            break;

        //                        case CardDataFormatBase.Formats.HIDH1030237Bit:
        //                            credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.HIDH1030237Bit);
        //                            smsPersonCredential.Credential.CredentialH1030237Bit.IDCode = (ulong)c.CUSTCARDF1;
        //                            break;

        //                        case CardDataFormatBase.Formats.SoftwareHouse37Bit:
        //                            credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.SoftwareHouse37Bit);
        //                            smsPersonCredential.Credential.CredentialSoftwareHouse37Bit.FacilityCode = (int)c.CUSTCARDF1;
        //                            smsPersonCredential.Credential.CredentialSoftwareHouse37Bit.SiteCode = (ushort)c.CUSTCARDF2;
        //                            smsPersonCredential.Credential.CredentialSoftwareHouse37Bit.IDCode = (uint)c.CUSTCARDF3;
        //                            break;

        //                        case CardDataFormatBase.Formats.GalaxyStandard:
        //                        default:
        //                            credentialFormat = personEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.NumericCardCode);
        //                            smsPersonCredential.Credential.CardNumber = c.FULLCARDCODE;
        //                            break;

        //                    }


        //                    if (credentialFormat != null)
        //                    {
        //                        smsPersonCredential.Credential.CredentialFormatUid = credentialFormat.CredentialFormatUid;
        //                        smsPersonCredential.Credential.BitCount = credentialFormat.BitLength;
        //                    }
        //                    else
        //                    {
        //                        smsPersonCredential.Credential.BitCount = (short)c.BitCount;
        //                    }

        //                    newItem.PersonCredentials.Add(smsPersonCredential);
        //                }



        //                var saveParams = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.Person>
        //                {
        //                    Data = newItem,
        //                    SavePhoto = newItem.Photo?.PhotoImage != null,
        //                };
        //                Globals.BusyContent = Properties.Resources.BusyContent_SavingPerson + $"{newItem.LastName}, {newItem.FirstName}";

        //                var savedItem = await mgr.SavePersonAsync(saveParams);
        //                if (mgr.HasErrors)
        //                {
        //                    this.Log().Info($"Failed to create Person: {newItem.LastName}, {newItem.FirstName}, SysGalRecordID: {newItem.SysGalEmployeeId}");
        //                    LogErrors(mgr.Errors, false);
        //                }
        //                else
        //                {
        //                    this.Log().Info($"Person created: {savedItem.LastName}, {savedItem.FirstName}, PersonUid: {savedItem.PersonUid},  EntityId: {savedItem.EntityId}");
        //                }
        //            }

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        this.Log().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {e.ToString()}");
        //    }
        //    Globals.IsBusy = false;
        //}

        private async void OnSyncBadgeTemplatesCommandExecute(CompositeCustomerData obj)
        {
            try
            {
                Globals.IsBusy = true;
                Globals.BusyContent = Properties.Resources.BusyContent_EnsureBadgeTemplatesExist;

                await GetFullSgCustomerData(obj, true);
                if (obj.FullSgCustomerDataCustomers == null)
                    return;

                Globals.CurrentUserEntity = Globals.CurrentUserEntities.FirstOrDefault(o => o.EntityId == obj.SmsEntity.EntityId);
                var mgr = Globals.GetManager<BadgeTemplateManager>();
                var badgeTemplates = await mgr.GetBadgeTemplatesAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                {
                });
                if (mgr.HasErrors)
                {
                    LogErrors(mgr.Errors, true);
                }

                foreach (var bt in obj.FullSgCustomerDataCustomers.BadgeTemplates)
                {
                    var smsBadgeTemplate = badgeTemplates.FirstOrDefault(o => o.TemplateName == bt.BADGENAME);
                    if (smsBadgeTemplate != null) continue;
                    var saveParams = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.BadgeTemplate>()
                    {
                        Data = new GalaxySMSEntities.BadgeTemplate()
                        {
                            EntityId = obj.SmsEntity.EntityId,
                            TemplateName = bt.BADGENAME,
                            Description = bt.BADGENAME,
                            TemplateId = bt.ID.ToString()
                        }
                    };
                    Globals.BusyContent = Properties.Resources.BusyContent_SavingBadgeTemplate + saveParams.Data.TemplateName;
                    var savedItem = await mgr.SaveBadgeTemplateAsync(saveParams);
                    if (mgr.HasErrors)
                    {
                        LogErrors(mgr.Errors, false);
                    }
                    else
                    {
                        this.Log().Info($"Badge Template created: {savedItem.TemplateName}, EntityId:{savedItem.EntityId}");
                    }
                }
            }
            catch (Exception e)
            {
                this.Log().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {e.ToString()}");
            }
            Globals.IsBusy = false;
        }

        private async void OnSyncAccessProfilesCommandExecute(CompositeCustomerData obj)
        {
            try
            {
                Globals.IsBusy = true;
                Globals.BusyContent = Properties.Resources.BusyContent_EnsureAccessProfilesExist;

                await GetFullSgCustomerData(obj, true);
                if (obj.FullSgCustomerDataCustomers == null)
                {
                    Globals.IsBusy = false;
                    return;
                }

                Globals.CurrentUserEntity = Globals.CurrentUserEntities.FirstOrDefault(o => o.EntityId == obj.SmsEntity.EntityId);
                var mgr = Globals.GetManager<AccessProfileManager>();

                var accessProfileEditingData = await mgr.GetAccessProfileEditingDataAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                {
                });
                if (mgr.HasErrors)
                {
                    LogErrors(mgr.Errors, true);
                }
                var accessProfiles = await mgr.GetAllAccessProfilesListForEntityAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                {
                });
                if (mgr.HasErrors)
                {
                    LogErrors(mgr.Errors, false);
                }

                //await PopulateSmsClusterData();

                var sgAccessProfileClient = new AccessProfileClient(Globals.SystemGalaxyConnectionData.WebApiUrl);
                foreach (var sgAp in obj.FullSgCustomerDataCustomers.AccessProfileIds)
                {
                    var sgAccessProfileData = await sgAccessProfileClient.GetAccessProfileData(sgAp.Id, Globals.SystemGalaxyConnectionData.UserToken.TokenGuid);

                    var smsApLi = accessProfiles.Items.FirstOrDefault(o => o.Name == sgAp.Value);
                    GalaxySMSEntities.AccessProfile smsAp = null;

                    if (smsApLi != null)
                        smsAp = await mgr.GetAccessProfileAsync(new GalaxySMSEntities.GetParametersWithPhoto() { UniqueId = smsApLi.AccessProfileUid, IncludeMemberCollections = true, IncludePhoto = false });
                    if (smsAp == null)
                    {
                        smsAp = new GalaxySMSEntities.AccessProfile()
                        {
                            EntityId = obj.SmsEntity.EntityId,
                            AccessProfileName = sgAp.Value,
                        };
                    }
                    else
                        smsAp.CleanAll();

                    var saveParams = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.AccessProfile>()
                    {
                        Data = smsAp
                    };


                    foreach (var sgAccessProfileDetails in sgAccessProfileData.AccessProfileDetails)
                    {
                        var smsCluster = accessProfileEditingData.AccessAndAlarmControlPermissionsEditingData.GetClusterSelectionItem(0, sgAccessProfileDetails.LOOPID);

                        if (smsCluster == null) continue;
                        var s = accessProfileEditingData.AccessAndAlarmControlPermissionsEditingData.GetSiteSelectionItem(smsCluster.SiteUid);
                        GalaxySMSEntities.RegionSelectionItemBasic r = null;
                        if (s != null)
                            r = accessProfileEditingData.AccessAndAlarmControlPermissionsEditingData.GetRegionSelectionItem(s.RegionUid);

                        var accessProfileCluster = saveParams.Data.AccessProfileClusters.FirstOrDefault(o => o.ClusterUid == smsCluster.ClusterUid);
                        if (accessProfileCluster == null)
                        {
                            accessProfileCluster = new GalaxySMSEntities.AccessProfileCluster()
                            {
                                ClusterUid = smsCluster.ClusterUid
                            };
                            accessProfileCluster.Initialize(smsCluster, s, r);
                            saveParams.Data.AccessProfileClusters.Add(accessProfileCluster);
                        }

                        var smsAg = smsCluster.AccessGroups.FirstOrDefault(o => o.AccessGroupNumber == sgAccessProfileDetails.ACCESSGROUP1);
                        if (smsAg != null)
                            accessProfileCluster.AccessGroup1.AccessGroupUid = smsAg.AccessGroupUid;

                        smsAg = smsCluster.AccessGroups.FirstOrDefault(o => o.AccessGroupNumber == sgAccessProfileDetails.ACCESSGROUP2);
                        if (smsAg != null)
                            accessProfileCluster.AccessGroup2.AccessGroupUid = smsAg.AccessGroupUid;

                        smsAg = smsCluster.AccessGroups.FirstOrDefault(o => o.AccessGroupNumber == sgAccessProfileDetails.ACCESSGROUP3);
                        if (smsAg != null)
                            accessProfileCluster.AccessGroup3.AccessGroupUid = smsAg.AccessGroupUid;

                        smsAg = smsCluster.AccessGroups.FirstOrDefault(o => o.AccessGroupNumber == sgAccessProfileDetails.ACCESSGROUP4);
                        if (smsAg != null)
                            accessProfileCluster.AccessGroup4.AccessGroupUid = smsAg.AccessGroupUid;


                        //var sgCluster = Globals.SystemGalaxyData.ClusterList.FirstOrDefault(o => o.SgClusterData.ClusterId == sgAccessProfileDetails.LOOPID);

                        //if (sgCluster?.SmsCluster != null)
                        //{
                        //    var accessProfileCluster = new GalaxySMSEntities.AccessProfileCluster()
                        //    {
                        //        ClusterUid = sgCluster.SmsCluster.ClusterUid
                        //    };

                        //    var c = accessProfileEditingData.AccessAndAlarmControlPermissionsEditingData.GetClusterSelectionItem(sgCluster.SmsCluster.ClusterUid);
                        //    var s = accessProfileEditingData.AccessAndAlarmControlPermissionsEditingData.GetSiteSelectionItem(c.SiteUid);
                        //    GalaxySMSEntities.RegionSelectionItem r = null;
                        //    if (s != null)
                        //        r = accessProfileEditingData.AccessAndAlarmControlPermissionsEditingData.GetRegionSelectionItem(s.RegionUid);
                        //    accessProfileCluster.Initialize(c, s, r);



                        //    var smsAg = sgCluster.SmsCluster.AccessGroups.FirstOrDefault(o=>o.AccessGroupNumber == sgAccessProfileDetails.ACCESSGROUP1);
                        //    if( smsAg != null)
                        //        accessProfileCluster.AccessGroup1.AccessGroupUid = smsAg.AccessGroupUid;

                        //    smsAg = sgCluster.SmsCluster.AccessGroups.FirstOrDefault(o=>o.AccessGroupNumber == sgAccessProfileDetails.ACCESSGROUP2);
                        //    if( smsAg != null)
                        //        accessProfileCluster.AccessGroup2.AccessGroupUid = smsAg.AccessGroupUid;

                        //    smsAg = sgCluster.SmsCluster.AccessGroups.FirstOrDefault(o=>o.AccessGroupNumber == sgAccessProfileDetails.ACCESSGROUP3);
                        //    if( smsAg != null)
                        //        accessProfileCluster.AccessGroup3.AccessGroupUid = smsAg.AccessGroupUid;

                        //    smsAg = sgCluster.SmsCluster.AccessGroups.FirstOrDefault(o=>o.AccessGroupNumber == sgAccessProfileDetails.ACCESSGROUP4);
                        //    if( smsAg != null)
                        //        accessProfileCluster.AccessGroup4.AccessGroupUid = smsAg.AccessGroupUid;

                        //    saveParams.Data.AccessProfileClusters.Add(accessProfileCluster);
                        //}
                    }
                    Globals.BusyContent = Properties.Resources.BusyContent_SavingAccessProfile + saveParams.Data.AccessProfileName;
                    var savedAp = await mgr.SaveAccessProfileAsync(saveParams);
                    if (mgr.HasErrors)
                    {
                        LogErrors(mgr.Errors, false);
                    }
                    else
                    {
                        this.Log().Info($"AccessProfile created: {savedAp.AccessProfileName}, EntityId:{savedAp.EntityId}");
                    }
                }
            }
            catch (Exception e)
            {
                this.Log().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {e.ToString()}");
            }
            Globals.IsBusy = false;

        }

        private async Task GetFullSgCustomerData(CompositeCustomerData obj, bool bAlwaysRefresh)
        {
            // Force the CurrentUserEntity to match the entity of obj
            Globals.CurrentUserEntity = Globals.CurrentUserEntities.FirstOrDefault(o => o.EntityId == obj.SmsEntity.EntityId);

            if (obj.FullSgCustomerDataCustomers == null || bAlwaysRefresh == true)
            {
                Globals.BusyContent = Properties.Resources.BusyContent_ReadingFullSystemGalaxyCustomerData;

                var customerClient = new CustomerClient(Globals.SystemGalaxyConnectionData.WebApiUrl);
                var customers = await customerClient.GetCustomerData((int)obj.Customer.ID,
                    new SGWebApiRequestParameterBase(Globals.SystemGalaxyConnectionData.UserToken.TokenGuid));
                if (customers != null)
                    obj.FullSgCustomerDataCustomers = customers.FirstOrDefault(o => o.CUSTOMERID == obj.Customer.ID);
            }
        }

        private async void OnSyncDepartmentsCommandExecute(CompositeCustomerData obj)
        {
            try
            {
                Globals.IsBusy = true;
                Globals.BusyContent = Properties.Resources.BusyContent_EnsureDepartmentsExist;

                await GetFullSgCustomerData(obj, true);
                if (obj.FullSgCustomerDataCustomers == null)
                    return;

                Globals.CurrentUserEntity = Globals.CurrentUserEntities.FirstOrDefault(o => o.EntityId == obj.SmsEntity.EntityId);
                var mgr = Globals.GetManager<DepartmentManager>();
                var departments = await mgr.GetDepartmentsAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                {
                });
                if (mgr.HasErrors)
                {
                    LogErrors(mgr.Errors, true);
                }

                foreach (var d in obj.FullSgCustomerDataCustomers.Departments)
                {
                    var smsDept = departments.Items.FirstOrDefault(o => o.DepartmentName == d.NAME);
                    if (smsDept != null) continue;
                    var saveParams = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.Department>()
                    {
                        Data = new GalaxySMSEntities.Department()
                        {
                            EntityId = obj.SmsEntity.EntityId,
                            DepartmentName = d.NAME,
                            Description = d.NAME
                        }
                    };
                    Globals.BusyContent = Properties.Resources.BusyContent_SavingDepartment + d.NAME;
                    var savedDept = await mgr.SaveDepartmentAsync(saveParams);
                    if (mgr.HasErrors)
                    {
                        LogErrors(mgr.Errors, false);
                    }
                    else
                    {
                        this.Log().Info($"Department created: {savedDept.DepartmentName}, EntityId:{savedDept.EntityId}");
                    }
                }
            }
            catch (Exception e)
            {
                this.Log().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {e.ToString()}");
            }
            Globals.IsBusy = false;
        }

        private async void OnSyncCardholderPropertyItemsCommandExecute(CompositeCustomerData obj)
        {
            try
            {
                Globals.IsBusy = true;

                await GetFullSgCustomerData(obj, true);
                if (obj.FullSgCustomerDataCustomers == null)
                    return;

                Globals.CurrentUserEntity = Globals.CurrentUserEntities.FirstOrDefault(o => o.EntityId == obj.SmsEntity.EntityId);
                var userDefinedPropertyMgr = Globals.GetManager<UserDefinedPropertyManager>();

                Globals.BusyContent = Properties.Resources.BusyContent_ReadingSmsPersonFieldData;
                var personManager = Globals.GetManager<PersonManager>();
                var personEditorData = await personManager.GetPersonEditingDataAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                {
                    //CurrentEntityId = Globals.CurrentUserEntity.EntityId,
                    IncludePhoto = false,
                });

                var userInterfacePageControlData = await personManager.GetPersonUserInterfacePageControlDataAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                {
                    //CurrentEntityId = Globals.CurrentUserEntity.EntityId,
                    IncludePhoto = false,
                });

                Globals.BusyContent = Properties.Resources.BusyContent_ReadingSmsSensitivityLevelData;
                var propertySensitivityMgr = Globals.GetManager<PropertySensitivityLevelManager>();
                var sensitivityLevels = await propertySensitivityMgr.GetAllPropertySensitivityLevelsAsync(new GalaxySMSEntities.GetParametersWithPhoto() { });

                Globals.BusyContent = Properties.Resources.BusyContent_ReadingSmsUserDefinedPropertyData;
                var properties = await userDefinedPropertyMgr.GetAllUserDefinedPropertysForEntityAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                {
                });
                if (userDefinedPropertyMgr.HasErrors)
                {
                    LogErrors(userDefinedPropertyMgr.Errors, true);
                }

                foreach (var p in properties)
                {
                    p.CleanAll();
                }

                var sgDataFields = obj.FullSgCustomerDataCustomers.CardholderFieldTitles.Where(o => o.COLUMNNAME.StartsWith("CARDHOLDERS.DATA_ITEM_")).ToList();
                foreach (var sgDataField in sgDataFields)
                {
                    //var strNumber = sgDataField.COLUMNNAME.Replace("CARDHOLDERS.DATA_ITEM_", string.Empty);
                    var smsPropertyName = $"SelectItem{sgDataField.COLUMNNAME.Replace("CARDHOLDERS.DATA_ITEM_", string.Empty)}";
                    var smsProperty = properties.FirstOrDefault(o => o.PropertyName == smsPropertyName);
                    if (smsProperty != null)
                    {
                        smsProperty.Display = sgDataField.DBFIELD;
                        //if(sgDataField.VIEWONLY != 0)
                        //    smsProperty.s
                    }
                }

                sgDataFields = obj.FullSgCustomerDataCustomers.CardholderFieldTitles.Where(o => o.COLUMNNAME.StartsWith("CARDHOLDERS.DATA_")).ToList();
                foreach (var sgDataField in sgDataFields)
                {
                    //var strNumber = sgDataField.COLUMNNAME.Replace("CARDHOLDERS.DATA_ITEM_", string.Empty);
                    var smsPropertyName = $"TextData{sgDataField.COLUMNNAME.Replace("CARDHOLDERS.DATA_", string.Empty)}";
                    var smsProperty = properties.FirstOrDefault(o => o.PropertyName == smsPropertyName);
                    if (smsProperty != null)
                    {
                        smsProperty.Display = sgDataField.DBFIELD;
                        //if(sgDataField.VIEWONLY != 0)
                        //    smsProperty.s
                    }
                }

                var dirtyUserDefinedProperties = properties.Where(o => o.IsAnythingDirty()).ToList();

                var saveUserDefinedPropertiesParameters = new GalaxySMSEntities.SaveParameters<List<GalaxySMSEntities.UserDefinedProperty>>()
                {
                    Data = dirtyUserDefinedProperties,
                    CurrentEntityId = Globals.CurrentUserEntity.EntityId
                };
                Globals.BusyContent = Properties.Resources.BusyContent_SavingSmsUserDefinedPropertyData;
                var savedFieldTitles = await userDefinedPropertyMgr.SaveUserDefinedPropertiesAsync(saveUserDefinedPropertiesParameters);
                if (userDefinedPropertyMgr.HasErrors)
                {
                    LogErrors(userDefinedPropertyMgr.Errors, false);
                }
                else
                    this.Log().Info($"UserDefinedProperties saved: EntityId:{Globals.CurrentUserEntity.EntityId}");

                var personRecordTypeMgr = Globals.GetManager<PersonRecordTypeManager>();

                foreach (var p in obj.FullSgCustomerDataCustomers.CardholderTypes)
                {
                    var smsRecordType = personEditorData.PersonRecordTypes.FirstOrDefault(o => o.Display == p.DESCRIPTION);
                    if (smsRecordType == null)
                    {
                        var saveRecordTypeParams = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.PersonRecordType>()
                        {
                            Data = new GalaxySMSEntities.PersonRecordType()
                            {
                                //EntityId = 
                                Display = p.DESCRIPTION,
                                Description = p.DESCRIPTION,
                            }
                        };
                        Globals.BusyContent = Properties.Resources.BusyContent_SavingPersonRecordType + p.DESCRIPTION;
                        var savedRecordType = await personRecordTypeMgr.SavePersonRecordTypeAsync(saveRecordTypeParams);
                        if (personRecordTypeMgr.HasErrors)
                            LogErrors(personRecordTypeMgr.Errors, false);
                        else
                            this.Log().Info($"PersonRecordType created: {savedRecordType.Display}, EntityId:{savedRecordType.EntityId}");
                    }
                }

                for (int x = 1; x <= 10; x++)
                {
                    var sgItems = obj.FullSgCustomerDataCustomers.CardholderDataListItems.Where(o => o.COLUMNNAME == $"DATA_ITEM_{x}" && o.TABLENAME == "CARDHOLDERS").ToList();
                    var smsItem = userInterfacePageControlData.ControlProperties.FirstOrDefault(o => o.PropertyName == $"SelectItem{x}");

                    if (smsItem != null && sgItems.Any())
                    {
                        var smsItemList = smsItem.UserDefinedListPropertyItems.ToList();
                        var bAddedItems = false;
                        foreach (var p in sgItems)
                        {
                            var li = smsItemList.FirstOrDefault(o => o.Display == p.VALUE);
                            if (li == null)
                            {
                                var newItem = new GalaxySMSEntities.UserDefinedListPropertyItem()
                                {
                                    Display = p.VALUE,
                                    Description = p.VALUE,
                                    ItemValue = p.VALUE
                                };
                                smsItemList.Add(newItem);
                                bAddedItems = true;
                            }

                        }
                        if (bAddedItems)
                        {
                            smsItem.UserDefinedListPropertyItems = smsItemList;
                            var saveParams = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.UserDefinedProperty>()
                            {
                                Data = smsItem
                            };
                            var savedItem = await userDefinedPropertyMgr.SaveUserDefinedPropertyAsync(saveParams);
                            if (userDefinedPropertyMgr.HasErrors)
                            {
                                LogErrors(userDefinedPropertyMgr.Errors, false);
                            }
                            else
                            {
                                this.Log().Info($"Saved UserDefinedProperty: {smsItem.Display}");
                            }
                        }
                    }

                }

            }
            catch (Exception e)
            {
                this.Log().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {e.ToString()}");
            }
            Globals.IsBusy = false;
        }

        private void SetDayTypeTimePeriodDataFromScheduleBits(ICollection<GalaxySMSEntities.DayTypeTimePeriods> dayTypesTimePeriods, DayTypeCode dayTypeCode, byte[] scheduleBits)
        {
            var dayTypeTimePeriod = dayTypesTimePeriods.FirstOrDefault(o => o.DayTypeCode == dayTypeCode);
            if (dayTypeTimePeriod == null)
            {
                dayTypeTimePeriod = new GalaxySMSEntities.DayTypeTimePeriods()
                {
                    DayTypeCode = dayTypeCode,
                };
                dayTypesTimePeriods.Add(dayTypeTimePeriod);
            }
            dayTypeTimePeriod.FifteenMinuteTimePeriods = CreateTimePeriodsFromMinuteBinaryData(scheduleBits).ToObservableCollection();
        }


        private async void OnImportClusterIntoGalaxySMSCommandExecute(CompositeClusterData obj)
        {
            try
            {
                Globals.IsBusy = true;
                Globals.BusyContent = Properties.Resources.BusyContent_ImportingCluster_ReadingAllClusterDataFromSG;
                var clusterClient = new ClusterLoopClient(Globals.SystemGalaxyConnectionData.WebApiUrl);
                obj.FullSgClusterData = await clusterClient.GetClusterData((int)obj.SgClusterData.ClusterId, new RequestClusterParameters(Globals.SystemGalaxyConnectionData.UserToken.TokenGuid)
                {
                    IncludeControllers = true,
                    IncludeAllHardwareChildren = false
                });
                var clusterMgr = Globals.GetManager<ClusterManager>();

                Globals.BusyContent = "Getting cluster editing data";

                var clusterEditingData = await clusterMgr.GetClusterEditingDataAsync(new GalaxySMSEntities.GetParametersWithPhoto() { CurrentEntityId = Globals.CurrentUserEntity.EntityId });

                var tzs = TimeZoneInfo.GetSystemTimeZones();
                var timeZones = new List<GalaxySMS.Client.Entities.TimeZoneListItem>();
                foreach (var tz in tzs)
                {
                    timeZones.Add(new GalaxySMS.Client.Entities.TimeZoneListItem()
                    {
                        Id = tz.Id,
                        DisplayName = tz.DisplayName
                    });
                }
                clusterEditingData.TimeZones = new ReadOnlyCollection<GalaxySMS.Client.Entities.TimeZoneListItem>(timeZones);

                Globals.BusyContent = "Configuring cluster...";

                // Now create the cluster
                var newCluster = new GalaxySMSEntities.Cluster()
                {
                    EntityId = Globals.CurrentUserEntity.EntityId,
                    SiteUid = Globals.CurrentSite.SiteUid,
                    ClusterName = obj.FullSgClusterData.LOOPNAME,
                    ClusterNumber = obj.FullSgClusterData.LOOPID,
                    ClusterTypeUid = GalaxySMS.Common.Constants.GalaxyClusterTypeIds.GalaxyClusterType_Only635,
                    AbaFoldOption = obj.FullSgClusterData.ABAFOLDOPTION != 0,
                    AbaStartDigit = obj.FullSgClusterData.ABASTARTDIGIT,
                    AbaStopDigit = obj.FullSgClusterData.ABASTOPDIGIT,
                    ClusterGroupId = 0,
                    IsActive = true,
                    WiegandStartBit = obj.FullSgClusterData.WIEGANDSTARTBIT,
                    WiegandStopBit = obj.FullSgClusterData.WIEGANDSTOPBIT,
                    CardaxStartBit = obj.FullSgClusterData.CARDAXSTART,
                    CardaxStopBit = obj.FullSgClusterData.CARDAXSTOP,
                    LockoutAfterInvalidAttempts = obj.FullSgClusterData.MAXINVALIDATTEMPTS,
                    LockoutDurationSeconds = obj.FullSgClusterData.LOCKOUTTIME * 100,
                    AccessRuleOverrideTimeout = obj.FullSgClusterData.ACCESSOVERRIDETIMEOUT,
                    UnlimitedCredentialTimeout = obj.FullSgClusterData.UNLIMITEDCARDTIMEOUT,
                    TimeZoneId = obj.FullSgClusterData.TIMEZONE,
                    CrisisActivateInputOutputGroupUid = Guid.Empty,
                    CrisisResetInputOutputGroupUid = Guid.Empty,
                    AccessPortalTypeUid = Guid.Empty,
                    TemplateAccessPortalUid = Guid.Empty,
                    AccessPortalLockedLedBehaviorModeUid = Guid.Empty,
                    AccessPortalUnlockedLedBehaviorModeUid = Guid.Empty,
                };

                var tz1 = clusterEditingData.TimeZones.FirstOrDefault(o => o.Id == newCluster.TimeZoneId);
                if (tz1 == null)
                {
                    tz1 = clusterEditingData.TimeZones.FirstOrDefault(o => o.DisplayName == System.TimeZone.CurrentTimeZone.StandardName);
                    if (tz1 != null)
                        newCluster.TimeZoneId = tz1.Id;
                    else
                    {
                        newCluster.TimeZoneId = System.TimeZone.CurrentTimeZone.StandardName;
                    }
                }

                var lockedLedBehavior = clusterEditingData.LedBehaviorModes.FirstOrDefault(o => o.LedBehaviorCode == obj.FullSgClusterData.LEDLOCKED);

                if (lockedLedBehavior != null)
                    newCluster.AccessPortalLockedLedBehaviorModeUid = lockedLedBehavior.ClusterLedBehaviorModeUid;

                var unlockedLedBehavior = clusterEditingData.LedBehaviorModes.FirstOrDefault(o => o.LedBehaviorCode == obj.FullSgClusterData.LEDUNLOCKED);

                if (unlockedLedBehavior != null)
                    newCluster.AccessPortalUnlockedLedBehaviorModeUid = unlockedLedBehavior.ClusterLedBehaviorModeUid;

                var accessPortalType = clusterEditingData.AccessPortalTypes.FirstOrDefault(o => o.AccessPortalTypeDescription.Contains("Wiegand"));
                if (accessPortalType != null)
                    newCluster.AccessPortalTypeUid = accessPortalType.AccessPortalTypeUid;
                else
                {
                    accessPortalType = clusterEditingData.AccessPortalTypes.FirstOrDefault();
                    if (accessPortalType != null)
                        newCluster.AccessPortalTypeUid = accessPortalType.AccessPortalTypeUid;
                }

                if (obj.FullSgClusterData.CARDCODESIZE == 32)
                {
                    newCluster.CredentialDataLengthUid = GalaxySMS.Common.Constants.CredentialDataLengthIds.Extended256Bits;
                    newCluster.AbaClipOption = true;
                }
                else
                {
                    newCluster.CredentialDataLengthUid = GalaxySMS.Common.Constants.CredentialDataLengthIds.Standard48Bits;
                    newCluster.AbaClipOption = false;
                }

                if (obj.FullSgClusterData.MINUTEBASEDSCHEDULES != 0)
                    newCluster.TimeScheduleTypeUid = GalaxySMS.Common.Constants.TimeScheduleTypeIds.TimeScheduleType_GalaxyMinuteInterval;
                else
                    newCluster.TimeScheduleTypeUid = GalaxySMS.Common.Constants.TimeScheduleTypeIds.TimeScheduleType_GalaxyLegacy15MinuteInterval;

                Globals.BusyContent = "Getting day types for entity...";

                // Before saving the Cluster, create the DayTypes, TimePeriods and TimeSchedule items that are required at the entity level. Then fill in the cluster mapping data
                var dayTypeManager = Globals.GetManager<DayTypeManager>();
                var dayTypesForEntity = await dayTypeManager.GetDayTypesForEntityAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                {
                    CurrentEntityId = newCluster.EntityId,
                });

                Globals.BusyContent = "Getting time periods for entity...";
                var galaxyTimePeriodManager = Globals.GetManager<GalaxyTimePeriodManager>();
                var galaxyTimePeriodsForEntity = await galaxyTimePeriodManager.GetGalaxyTimePeriodsForEntityAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                {
                    CurrentEntityId = newCluster.EntityId,
                });

                if (newCluster.TimeScheduleTypeUid == GalaxySMS.Common.Constants.TimeScheduleTypeIds.TimeScheduleType_GalaxyLegacy15MinuteInterval)
                {
                    Globals.BusyContent = "Saving day types for entity...";
                    foreach (var sgHolidayType in obj.FullSgClusterData.HolidayTypes)
                    {
                        var smsDayType = dayTypesForEntity.Items.FirstOrDefault(o => o.DayTypeCode == (GalaxySMS.Common.Enums.DayTypeCode)sgHolidayType.ID);
                        if (smsDayType == null)
                        {
                            var newDayType = new GalaxySMSEntities.DayType()
                            {
                                EntityId = newCluster.EntityId,
                                DayTypeCode = (DayTypeCode)(sgHolidayType.ID),
                                Name = sgHolidayType.DESCRIPTION,
                                Notes = sgHolidayType.NOTES
                            };

                            var parameters = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.DayType>()
                            {
                                Data = newDayType,
                                //SessionId = _clientServices.UserSessionToken.SessionId,
                                CurrentEntityId = smsDayType.EntityId
                            };
                            Globals.BusyContent = $"Saving day type '{newDayType.Name}' ...";

                            smsDayType = await dayTypeManager.SaveDayTypeAsync(parameters);
                            if (dayTypeManager.HasErrors)
                            {
                                LogErrors(dayTypeManager.Errors, false);
                            }
                            else
                                this.Log().Info($"DayType created: {smsDayType.Name}, EntityId:{smsDayType.EntityId}");
                        }
                        else if (smsDayType.Name != sgHolidayType.DESCRIPTION)
                        {
                            smsDayType.Name = sgHolidayType.DESCRIPTION;
                            var parameters = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.DayType>()
                            {
                                Data = smsDayType,
                                //SessionId = _clientServices.UserSessionToken.SessionId,
                                CurrentEntityId = smsDayType.EntityId
                            };
                            Globals.BusyContent = $"Saving day type '{smsDayType.Name}' ...";

                            smsDayType = await dayTypeManager.SaveDayTypeAsync(parameters);
                            if (dayTypeManager.HasErrors)
                            {
                                LogErrors(dayTypeManager.Errors, false);
                            }
                            else
                                this.Log().Info($"DayType updated: {smsDayType.Name}, EntityId:{smsDayType.EntityId}");
                        }
                    }
                }
                else
                {
                    Globals.BusyContent = "Saving day types for entity...";
                    foreach (var sgDayType in obj.FullSgClusterData.DayTypes)
                    {
                        var smsDayType = dayTypesForEntity.Items.FirstOrDefault(o => o.DayTypeCode == (GalaxySMS.Common.Enums.DayTypeCode)sgDayType.DAYTYPEID - 1);
                        if (smsDayType == null)
                        {
                            var newDayType = new GalaxySMSEntities.DayType()
                            {
                                EntityId = newCluster.EntityId,
                                DayTypeCode = (DayTypeCode)sgDayType.DAYTYPEID - 1,
                                Name = sgDayType.NAME,
                                Notes = sgDayType.NOTES
                            };

                            var parameters = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.DayType>()
                            {
                                Data = newDayType,
                                //SessionId = _clientServices.UserSessionToken.SessionId,
                                CurrentEntityId = smsDayType.EntityId
                            };
                            Globals.BusyContent = $"Saving day type '{newDayType.Name}' ...";

                            smsDayType = await dayTypeManager.SaveDayTypeAsync(parameters);
                            if (dayTypeManager.HasErrors)
                            {
                                LogErrors(dayTypeManager.Errors, false);
                            }
                            else
                                this.Log().Info($"DayType created: {smsDayType.Name}, EntityId:{smsDayType.EntityId}");
                        }
                        else if (smsDayType.Name != sgDayType.NAME &&
                                 dayTypesForEntity.Items.FirstOrDefault(o => o.Name == sgDayType.NAME) == null)
                        {   // Only update if the name is different AND the name does not already exist for another day type
                            smsDayType.Name = sgDayType.NAME;
                            var parameters = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.DayType>()
                            {
                                Data = smsDayType,
                                //SessionId = _clientServices.UserSessionToken.SessionId,
                                CurrentEntityId = smsDayType.EntityId
                            };
                            Globals.BusyContent = $"Saving day type '{smsDayType.Name}' ...";

                            smsDayType = await dayTypeManager.SaveDayTypeAsync(parameters);
                            if (dayTypeManager.HasErrors)
                            {
                                LogErrors(dayTypeManager.Errors, false);
                            }
                            else
                                this.Log().Info($"DayType updated: {smsDayType.Name}, EntityId:{smsDayType.EntityId}");
                        }
                    }

                    Globals.BusyContent = "Saving time periods for entity...";
                    foreach (var sgTimePeriod in obj.FullSgClusterData.TimePeriods.Where(o => o.PERIODID != GalaxyTimePeriodLimits.Never && o.PERIODID != GalaxyTimePeriodLimits.Always))
                    {
                        var smsGalaxyTimePeriod = galaxyTimePeriodsForEntity.Items.FirstOrDefault(o => o.PanelTimePeriodNumber == sgTimePeriod.PERIODID);
                        if (smsGalaxyTimePeriod == null)
                        {
                            var newTimePeriod = new GalaxySMSEntities.GalaxyTimePeriod()
                            {
                                EntityId = newCluster.EntityId,
                                Display = sgTimePeriod.NAME,
                                Description = sgTimePeriod.NOTES,
                                PanelTimePeriodNumber = sgTimePeriod.PERIODID,
                                TimePeriods = CreateTimePeriodsFromMinuteBinaryData(sgTimePeriod.MINUTES).ToCollection()
                            };

                            if (string.IsNullOrEmpty(newTimePeriod.Description))
                                newTimePeriod.Description = sgTimePeriod.NAME;

                            var parameters = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.GalaxyTimePeriod>()
                            {
                                Data = newTimePeriod,
                                //SessionId = _clientServices.UserSessionToken.SessionId,
                                CurrentEntityId = newTimePeriod.EntityId
                            };
                            Globals.BusyContent = $"Saving time period '{newTimePeriod.Display}' ...";

                            smsGalaxyTimePeriod = await galaxyTimePeriodManager.SaveGalaxyTimePeriodAsync(parameters);
                            if (galaxyTimePeriodManager.HasErrors)
                            {
                                LogErrors(galaxyTimePeriodManager.Errors, false);
                            }
                            else
                                this.Log().Info($"Time Period created: {smsGalaxyTimePeriod.Display}, EntityId:{smsGalaxyTimePeriod.EntityId}");
                        }
                        //else if (smsDayType.Name != sgDayType.NAME)
                        //{
                        //    smsDayType.Name = sgDayType.NAME;
                        //    var parameters = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.DayType>()
                        //    {
                        //        Data = smsDayType,
                        //        //SessionId = _clientServices.UserSessionToken.SessionId,
                        //        CurrentEntityId = smsDayType.EntityId
                        //    };
                        //    Globals.BusyContent = $"Saving day type '{smsDayType.Name}' ...";

                        //    smsDayType = await dayTypeManager.SaveDayTypeAsync(parameters);
                        //    if (dayTypeManager.HasErrors)
                        //    {
                        //        LogErrors(dayTypeManager.Errors, false);
                        //    }
                        //    else
                        //        this.Log().Info($"DayType updated: {smsDayType.Name}, EntityId:{smsDayType.EntityId}");
                        //}
                    }
                    galaxyTimePeriodsForEntity = await galaxyTimePeriodManager.GetGalaxyTimePeriodsForEntityAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                    {
                        CurrentEntityId = newCluster.EntityId,
                    });
                }

                dayTypesForEntity = await dayTypeManager.GetDayTypesForEntityAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                {
                    CurrentEntityId = newCluster.EntityId,
                });

                Globals.BusyContent = "Getting schedules for entity...";

                var timeScheduleManager = Globals.GetManager<TimeScheduleManager>();
                var timeSchedulesForEntity = await timeScheduleManager.GetTimeSchedulesForEntityAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                {
                    CurrentEntityId = newCluster.EntityId,
                });


                Globals.BusyContent = "Saving schedules for entity...";

                foreach (var ts in obj.FullSgClusterData.TimeSchedules.Where(o => o.SCHEDULENUMBER != GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Never && o.SCHEDULENUMBER != GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Always))
                {
                    var smsTs = timeSchedulesForEntity.Items.FirstOrDefault(o => o.Display == ts.NAME);
                    if (smsTs == null)
                    {
                        var newTimeSchedule = await timeScheduleManager.GetTimeScheduleAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                        {
                            IncludeMemberCollections = true
                        });

                        newTimeSchedule.EntityId = newCluster.EntityId;
                        newTimeSchedule.Display = ts.NAME;
                        newTimeSchedule.Description = ts.NAME;

                        SetDayTypeTimePeriodDataFromScheduleBits(newTimeSchedule.DayTypesTimePeriods, DayTypeCode.Sunday, ts.SUNDAY);
                        SetDayTypeTimePeriodDataFromScheduleBits(newTimeSchedule.DayTypesTimePeriods, DayTypeCode.Monday, ts.MONDAY);
                        SetDayTypeTimePeriodDataFromScheduleBits(newTimeSchedule.DayTypesTimePeriods, DayTypeCode.Tuesday, ts.TUESDAY);
                        SetDayTypeTimePeriodDataFromScheduleBits(newTimeSchedule.DayTypesTimePeriods, DayTypeCode.Wednesday, ts.WEDNESDAY);
                        SetDayTypeTimePeriodDataFromScheduleBits(newTimeSchedule.DayTypesTimePeriods, DayTypeCode.Thursday, ts.THURSDAY);
                        SetDayTypeTimePeriodDataFromScheduleBits(newTimeSchedule.DayTypesTimePeriods, DayTypeCode.Friday, ts.FRIDAY);
                        SetDayTypeTimePeriodDataFromScheduleBits(newTimeSchedule.DayTypesTimePeriods, DayTypeCode.Saturday, ts.SATURDAY);
                        SetDayTypeTimePeriodDataFromScheduleBits(newTimeSchedule.DayTypesTimePeriods, DayTypeCode.DayType1, ts.HOLIDAY);
                        SetDayTypeTimePeriodDataFromScheduleBits(newTimeSchedule.DayTypesTimePeriods, DayTypeCode.DayType2, ts.HOLIDAY2);
                        SetDayTypeTimePeriodDataFromScheduleBits(newTimeSchedule.DayTypesTimePeriods, DayTypeCode.DayType3, ts.HOLIDAY3);
                        SetDayTypeTimePeriodDataFromScheduleBits(newTimeSchedule.DayTypesTimePeriods, DayTypeCode.DayType4, ts.HOLIDAY4);
                        SetDayTypeTimePeriodDataFromScheduleBits(newTimeSchedule.DayTypesTimePeriods, DayTypeCode.DayType5, ts.HOLIDAY5);
                        SetDayTypeTimePeriodDataFromScheduleBits(newTimeSchedule.DayTypesTimePeriods, DayTypeCode.DayType6, ts.HOLIDAY6);
                        SetDayTypeTimePeriodDataFromScheduleBits(newTimeSchedule.DayTypesTimePeriods, DayTypeCode.DayType7, ts.HOLIDAY7);
                        SetDayTypeTimePeriodDataFromScheduleBits(newTimeSchedule.DayTypesTimePeriods, DayTypeCode.DayType8, ts.HOLIDAY8);
                        SetDayTypeTimePeriodDataFromScheduleBits(newTimeSchedule.DayTypesTimePeriods, DayTypeCode.DayType9, ts.HOLIDAY9);

                        foreach (var sgDayTypeTimePeriod in ts.SchDayTypeTimePeriods)
                        {
                            var smsDayTypeTimePeriod = newTimeSchedule.DayTypesTimePeriods.FirstOrDefault(o => o.DayTypeCode == (DayTypeCode)sgDayTypeTimePeriod.DAYTYPEID - 1);
                            if (smsDayTypeTimePeriod != null)
                            {
                                var smsTimePeriod = galaxyTimePeriodsForEntity.Items.FirstOrDefault(o => o.PanelTimePeriodNumber == sgDayTypeTimePeriod.PERIODID);
                                if (smsTimePeriod != null)
                                    smsDayTypeTimePeriod.GalaxyTimePeriodUid = smsTimePeriod.GalaxyTimePeriodUid;
                                else if (sgDayTypeTimePeriod.PERIODID == GalaxyTimePeriodLimits.Always)
                                    smsDayTypeTimePeriod.GalaxyTimePeriodUid = GalaxyTimePeriodIds.TimePeriod_Always;
                                else smsDayTypeTimePeriod.GalaxyTimePeriodUid = GalaxyTimePeriodIds.TimePeriod_Never;
                            }
                        }

                        var parameters = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.TimeSchedule>()
                        {
                            Data = newTimeSchedule,
                            //SessionId = _clientServices.UserSessionToken.SessionId,
                            CurrentEntityId = newTimeSchedule.EntityId
                        };
                        Globals.BusyContent = $"Saving schedule '{newTimeSchedule.Display}' ...";

                        smsTs = await timeScheduleManager.SaveTimeScheduleAsync(parameters);
                        if (timeScheduleManager.HasErrors)
                        {
                            LogErrors(timeScheduleManager.Errors, false);
                        }
                        else
                            this.Log().Info($"TimeSchedule created: {smsTs.Display}, EntityId:{smsTs.EntityId}");
                    }
                    if (smsTs != null)
                    {
                        var tss = new GalaxySMSEntities.TimeScheduleSelect
                        {
                            Selected = true,
                            TimeScheduleUid = smsTs.TimeScheduleUid,
                            ClusterScheduleMap =
                            {
                                PanelScheduleNumber = ts.SCHEDULENUMBER,
                                FifteenMinuteFormatUsesHolidays = ts.USESHOLIDAYS != 0
                            },
                        };
                        newCluster.TimeSchedules.Add(tss);
                    }
                }


                timeSchedulesForEntity = await timeScheduleManager.GetTimeSchedulesForEntityAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                {
                    CurrentEntityId = newCluster.EntityId,
                });


                Globals.BusyContent = "Getting date types for entity...";

                var dateTypeManager = Globals.GetManager<DateTypeManager>();
                var dateTypesForEntity = await dateTypeManager.GetDateTypesForEntityAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                {
                    CurrentEntityId = newCluster.EntityId,
                });

                if (newCluster.TimeScheduleTypeUid == TimeScheduleTypeIds.TimeScheduleType_GalaxyLegacy15MinuteInterval)
                {
                    foreach (var sgHoliday in obj.FullSgClusterData.Holidays)
                    {
                        var smsDateType = dateTypesForEntity.Items.FirstOrDefault(o => o.Date == sgHoliday.HOLIDAYDATE);
                        var smsDayType = dayTypesForEntity.Items.FirstOrDefault(o => o.DayTypeCode == (DayTypeCode)sgHoliday.TYPEID);
                        if (smsDateType == null)
                        {
                            var newDateType = new GalaxySMSEntities.DateType()
                            {
                                EntityId = newCluster.EntityId,
                                DayTypeUid = smsDayType.DayTypeUid,
                                Date = sgHoliday.HOLIDAYDATE,
                                Title = sgHoliday.DESCRIPTION,
                            };

                            var parameters = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.DateType>()
                            {
                                Data = newDateType,
                                //SessionId = _clientServices.UserSessionToken.SessionId,
                                CurrentEntityId = smsDayType.EntityId
                            };
                            Globals.BusyContent = $"Saving date '{newDateType.Date.Date.ToShortDateString()}' ...";

                            smsDateType = await dateTypeManager.SaveDateTypeAsync(parameters);
                            if (dateTypeManager.HasErrors)
                            {
                                LogErrors(dateTypeManager.Errors, false);
                            }
                            else
                                this.Log().Info($"DateType created: {smsDateType.Date.Date.ToShortDateString()} as {smsDayType.DayTypeCode}, EntityId:{smsDateType.EntityId}");
                        }
                    }
                }
                else
                {
                    foreach (var sgDateType in obj.FullSgClusterData.DateTypes)
                    {
                        var smsDateType = dateTypesForEntity.Items.FirstOrDefault(o => o.Date == sgDateType.CALENDARDATE);
                        var smsDayType = dayTypesForEntity.Items.FirstOrDefault(o => o.DayTypeCode == (DayTypeCode)sgDateType.DAYTYPEID - 1);
                        if (smsDateType == null)
                        {
                            var newDateType = new GalaxySMSEntities.DateType()
                            {
                                EntityId = newCluster.EntityId,
                                DayTypeUid = smsDayType.DayTypeUid,
                                Date = sgDateType.CALENDARDATE,
                                Title = sgDateType.NOTES,
                            };

                            var parameters = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.DateType>()
                            {
                                Data = newDateType,
                                //SessionId = _clientServices.UserSessionToken.SessionId,
                                CurrentEntityId = smsDayType.EntityId
                            };
                            Globals.BusyContent = $"Saving date '{newDateType.Date.Date.ToShortDateString()}' ...";

                            smsDateType = await dateTypeManager.SaveDateTypeAsync(parameters);
                            if (dateTypeManager.HasErrors)
                            {
                                LogErrors(dateTypeManager.Errors, false);
                            }
                            else
                                this.Log().Info($"DateType created: {smsDateType.Date.Date.ToShortDateString()} as {smsDayType.DayTypeCode}, EntityId:{smsDateType.EntityId}");
                        }
                    }
                }

                Globals.BusyContent = $"Saving cluster '{newCluster.Name}' ...";

                var savedCluster = await clusterMgr.SaveClusterAsync(new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.Cluster>()
                {
                    SavePhoto = false,
                    CurrentEntityId = newCluster.EntityId,
                    Data = newCluster,
                });

                var ioGroupManager = Globals.GetManager<GalaxyInputOutputGroupManager>();
                GalaxySMSEntities.ArrayResponse<GalaxySMSEntities.InputOutputGroup> ioGroupsForCluster = null;
                if (clusterMgr.HasErrors)
                {
                    LogErrors(clusterMgr.Errors, true);
                }
                else
                {
                    this.Log().Info($"Cluster created: {savedCluster.ClusterName}, ClusterUid:{savedCluster.ClusterUid}, EntityId:{savedCluster.EntityId}");
                    // Now populate the IOGroup, Areas and Access Groups
                    Globals.BusyContent = $"Getting Input Output Groups...";

                    ioGroupsForCluster = await ioGroupManager.GetInputOutputGroupsForClusterAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                    {
                        UniqueId = savedCluster.ClusterUid,
                    });

                    Globals.BusyContent = $"Getting Areas...";
                    var areaManager = Globals.GetManager<GalaxyAreaManager>();
                    var areasForCluster = await areaManager.GetAreasForClusterAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                    {
                        UniqueId = savedCluster.ClusterUid,
                    });

                    Globals.BusyContent = $"Getting Access Groups...";
                    var accessGroupManager = Globals.GetManager<GalaxyAccessGroupManager>();
                    var accessGroupsForCluster = await accessGroupManager.GetAccessGroupsForClusterAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                    {
                        UniqueId = savedCluster.ClusterUid,
                    });


                    foreach (var iog in obj.FullSgClusterData.InputOutputGroups)
                    {
                        var smsIog = ioGroupsForCluster.Items.FirstOrDefault(o => o.IOGroupNumber == iog.PARTITIONNUMBER);
                        if (smsIog == null)
                        {
                            var armScheduleUid = Guid.Empty;

                            if (iog.SCHEDULENUMBER == GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Never)
                                armScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never;
                            else if (iog.SCHEDULENUMBER == GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Always)
                                armScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always;
                            else
                            {
                                var sgSchedule = obj.FullSgClusterData.TimeSchedules.FirstOrDefault(o => o.SCHEDULENUMBER == iog.SCHEDULENUMBER);
                                if (sgSchedule != null)
                                {
                                    var smsSchedule = timeSchedulesForEntity.Items.FirstOrDefault(o => o.Display == sgSchedule.NAME);
                                    if (smsSchedule != null)
                                        armScheduleUid = smsSchedule.TimeScheduleUid;
                                }
                            }
                            // If can't identify the schedule, then force to never
                            if (armScheduleUid == Guid.Empty)
                                armScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never;

                            var newIog = new GalaxySMSEntities.InputOutputGroup()
                            {
                                EntityId = newCluster.EntityId,
                                ClusterUid = savedCluster.ClusterUid,
                                IOGroupNumber = iog.PARTITIONNUMBER,
                                Display = iog.NAME,
                                Description = iog.DESCRIPTION,
                                TimeScheduleUid = armScheduleUid,
                            };
                            if (string.IsNullOrEmpty(newIog.Description))
                                newIog.Description = newIog.Display;
                            if (iog.LOCALONLY == 0)
                                newIog.LocalIOGroup = false;
                            else
                                newIog.LocalIOGroup = true;

                            Globals.BusyContent = $"Saving Input Output Group '{newIog.Display}'...";

                            var parameters = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.InputOutputGroup>()
                            {
                                Data = newIog,
                                //SessionId = _clientServices.UserSessionToken.SessionId,
                                CurrentEntityId = savedCluster.EntityId
                            };
                            newIog = await ioGroupManager.SaveInputOutputGroupAsync(parameters);
                            if (ioGroupManager.HasErrors)
                            {
                                LogErrors(ioGroupManager.Errors, false);
                            }
                            else
                            {
                                this.Log().Info($"InputOutputGroup created: {newIog.Display}, ClusterUid:{newIog.ClusterUid}, EntityId:{newIog.EntityId}");
                            }
                        }
                    }


                    foreach (var ag in obj.FullSgClusterData.AccessGroups.Where(o => o.ACCESSGROUPNUMBER <= GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup))
                    {
                        var smsAg = accessGroupsForCluster.Items.FirstOrDefault(o => o.AccessGroupNumber == ag.ACCESSGROUPNUMBER);
                        if (smsAg == null)
                        {
                            var newAg = new GalaxySMSEntities.AccessGroup()
                            {
                                EntityId = newCluster.EntityId,
                                ClusterUid = savedCluster.ClusterUid,
                                AccessGroupNumber = ag.ACCESSGROUPNUMBER,
                                Display = ag.NAME,
                                Description = ag.DESCRIPTION,
                                IsEnabled = true,
                                Comment = ag.COMMENTS,
                                ServiceComment = ag.SERVICECOMMENTS,
                                ActivationDate = ag.ACTIVEDT,
                                ExpirationDate = ag.EXPIREDT,
                                CrisisModeAccessGroupUid = Guid.Empty
                            };
                            if (string.IsNullOrEmpty(newAg.Description))
                                newAg.Description = newAg.Display;

                            if (ag.GROUPDISABLED != 0)
                                newAg.IsEnabled = false;

                            Globals.BusyContent = $"Saving Access Group '{newAg.Display}'...";
                            var parameters = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.AccessGroup>()
                            {
                                Data = newAg,
                                CurrentEntityId = savedCluster.EntityId
                            };
                            newAg = await accessGroupManager.SaveAccessGroupAsync(parameters);
                            if (accessGroupManager.HasErrors)
                            {
                                LogErrors(accessGroupManager.Errors, false);
                            }
                            else
                            {
                                this.Log().Info($"AccessGroup created: {newAg.Display}, ClusterUid:{newAg.ClusterUid}, EntityId:{newAg.EntityId}");
                            }
                        }
                    }

                    accessGroupsForCluster = await accessGroupManager.GetAccessGroupsForClusterAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                    {
                        UniqueId = savedCluster.ClusterUid,
                    });

                    foreach (var ag1 in obj.FullSgClusterData.AccessGroups.Where(o => o.AltAccessGroup != null && o.AltAccessGroup.ALTGROUPNUMBER != o.ACCESSGROUPNUMBER))
                    {
                        var smsAg = accessGroupsForCluster.Items.FirstOrDefault(o => o.AccessGroupNumber == ag1.ACCESSGROUPNUMBER);
                        var smsCrisisAg = accessGroupsForCluster.Items.FirstOrDefault(o => o.AccessGroupNumber == ag1.AltAccessGroup.ALTGROUPNUMBER);
                        if (smsAg != null && smsCrisisAg != null && smsAg.AccessGroupUid != smsCrisisAg.AccessGroupUid)
                        {
                            smsAg.CrisisModeAccessGroupUid = smsCrisisAg.AccessGroupUid;
                            Globals.BusyContent = $"Saving Access Group '{smsAg.Display}' crisis mode data...";

                            var savedAg = await accessGroupManager.SaveAccessGroupAsync(new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.AccessGroup>()
                            {
                                Data = smsAg,
                                CurrentEntityId = savedCluster.EntityId
                            });
                            if (accessGroupManager.HasErrors)
                            {
                                LogErrors(accessGroupManager.Errors, false);
                            }
                            else
                            {
                                this.Log().Info($"AccessGroup crisis data saved: {savedAg.Display}, ClusterUid:{savedAg.ClusterUid}, EntityId:{savedAg.EntityId}");
                            }
                        }
                    }

                    foreach (var area in obj.FullSgClusterData.Areas)
                    {
                        var smsArea = areasForCluster.Items.FirstOrDefault(o => o.AreaNumber == area.AreaNumber);
                        if (smsArea == null)
                        {
                            var newArea = new GalaxySMSEntities.Area()
                            {
                                EntityId = newCluster.EntityId,
                                ClusterUid = savedCluster.ClusterUid,
                                AreaNumber = area.AreaNumber,
                                Display = area.Name,
                                Description = area.Notes,
                                AreaName = area.Name,
                            };
                            if (string.IsNullOrEmpty(newArea.Description))
                                newArea.Description = newArea.Display;

                            Globals.BusyContent = $"Saving Area '{newArea.Display}'...";
                            var parameters = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.Area>()
                            {
                                Data = newArea,
                                //SessionId = _clientServices.UserSessionToken.SessionId,
                                CurrentEntityId = savedCluster.EntityId
                            };
                            newArea = await areaManager.SaveAreaAsync(parameters);
                            if (areaManager.HasErrors)
                            {
                                LogErrors(areaManager.Errors, false);
                            }
                            else
                            {
                                this.Log().Info($"Area created: {newArea.Display}, ClusterUid:{newArea.ClusterUid}, EntityId:{newArea.EntityId}");
                            }
                        }
                    }

                }

                //if (obj.FullSgClusterData.CRISISPARTNUMBER != GalaxySMS.Common.Constants.InputOutputGroupLimits.None ||
                //    obj.FullSgClusterData.CRISISRESETPARTNUMBER != GalaxySMS.Common.Constants.InputOutputGroupLimits.None)
                //{
                //var ioGroupManager = Globals.GetManager<GalaxyInputOutputGroupManager>();
                ioGroupsForCluster = await ioGroupManager.GetInputOutputGroupsForClusterAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                {
                    UniqueId = savedCluster.ClusterUid,
                });

                var noIog = ioGroupsForCluster.Items.FirstOrDefault(o => o.IOGroupNumber == GalaxySMS.Common.Constants.InputOutputGroupLimits.None);
                var activateCrisisIog = ioGroupsForCluster.Items.FirstOrDefault(o => o.IOGroupNumber == obj.FullSgClusterData.CRISISPARTNUMBER);
                var resetCrisisIog = ioGroupsForCluster.Items.FirstOrDefault(o => o.IOGroupNumber == obj.FullSgClusterData.CRISISRESETPARTNUMBER);

                if (activateCrisisIog != null)
                    savedCluster.CrisisActivateInputOutputGroupUid = activateCrisisIog.InputOutputGroupUid;
                else
                    savedCluster.CrisisActivateInputOutputGroupUid = noIog.InputOutputGroupUid;

                if (resetCrisisIog != null)
                    savedCluster.CrisisResetInputOutputGroupUid = resetCrisisIog.InputOutputGroupUid;
                else
                    savedCluster.CrisisResetInputOutputGroupUid = noIog.InputOutputGroupUid;

                Globals.BusyContent = $"Saving Cluster crisis mode data...";

                savedCluster = await clusterMgr.SaveClusterAsync(new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.Cluster>()
                {
                    SavePhoto = false,
                    CurrentEntityId = newCluster.EntityId,
                    Data = savedCluster,
                });
                if (clusterMgr.HasErrors)
                {
                    LogErrors(clusterMgr.Errors, false);
                }
                else
                {
                    this.Log().Info($"Cluster crisis data saved: {savedCluster.ClusterName}, ClusterUid:{savedCluster.ClusterUid}, EntityId:{savedCluster.EntityId}");
                }
                //}


                var sgc = Globals.SystemGalaxyData.ClusterList.FirstOrDefault(o => o.SgClusterData.ClusterName == savedCluster.Name);
                if (sgc != null)
                    sgc.SmsCluster = savedCluster;

            }
            catch (Exception e)
            {
                this.Log().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {e.ToString()}");
            }
            Globals.IsBusy = false;
        }

        private IEnumerable<GalaxySMSEntities.TimePeriod> CreateTimePeriodsFromMinuteBinaryData(byte[] data)
        {
            var returnData = new List<GalaxySMSEntities.TimePeriod>();
            if (data == null)
                return returnData;
            var minuteResolution = 0;

            if (data.Length == 12)
                minuteResolution = 15;
            else if (data.Length == 180)
                minuteResolution = 1;
            if (minuteResolution == 0)
                return returnData;

            int hour = 0;
            int minute = 0;
            GalaxySMSEntities.TimePeriod tp = null;
            foreach (var bits in data)
            {
                byte mask = 0x80;
                for (int x = 0; x < 8; x++)
                {
                    if ((bits & mask) != 0)
                    {   // the bit is on
                        if (tp == null)
                        {
                            tp = new GalaxySMSEntities.TimePeriod();
                            tp.StartTime = new TimeSpan(hour, minute, 0);
                        }
                    }
                    else
                    {   // the bit is off
                        if (tp != null)
                        {   // if tp is not null, then this marks the end time of the current TP
                            tp.EndTime = new TimeSpan(0, hour, minute, 59, 999);
                            returnData.Add(tp.Clone());
                            tp = null;
                        }
                    }
                    minute += minuteResolution;
                    if (minute == 60)
                    {
                        hour++;
                        minute = 0;
                    }
                    mask /= 2;
                }
            }
            if (tp != null)
                returnData.Add(tp.Clone());


            return returnData;
        }

        private bool OnImportControlPanelCommandCanExecute(ControlPanelEx obj)
        {
            if (obj == null)
                return false;
            return !obj.HasBeenImported;
        }

        private async void OnImportControlPanelCommandExecute(ControlPanelEx obj)
        {
            if (obj == null)
                return;
            try
            {
                Globals.IsBusy = true;
                Globals.BusyContent = Properties.Resources.BusyContent_ImportingPanel_ReadingPanelDataFromSG;
                var clusterClient = new ClusterLoopClient(Globals.SystemGalaxyConnectionData.WebApiUrl);
                var fullSgPanelData = await clusterClient.GetPanelData((int)obj.LoopClusterId, (int)obj.UnitNumber, new RequestControllerParameters(Globals.SystemGalaxyConnectionData.UserToken.TokenGuid) { IncludeAllHardwareChildren = true });
                var fullSgPanel = fullSgPanelData.FirstOrDefault();
                if (fullSgPanel == null)
                {
                    Globals.IsBusy = false;
                    return;
                }

                var clusterMgr = Globals.GetManager<ClusterManager>();

                var getClusterParameters = new GalaxySMSEntities.GetParametersWithPhoto()
                {
                    CurrentEntityId = Globals.CurrentUserEntity.EntityId,
                    IncludeMemberCollections = true,
                    UniqueId = obj.ClusterUid,
                };
                getClusterParameters.AddOption(nameof(GalaxySMSEntities.InputOutputGroupAssignment), true);
                var clusterData = await clusterMgr.GetClusterAsync(getClusterParameters);

                var panelMgr = Globals.GetManager<GalaxyPanelManager>();
                var parameters = new GalaxySMSEntities.GetParametersWithPhoto()
                {
                    CurrentEntityId = Globals.CurrentUserEntity.EntityId,
                    IncludeMemberCollections = true,
                    UniqueId = obj.ClusterUid
                };

                Globals.BusyContent = Properties.Resources.BusyContent_ImportingPanel_ReadingPanelEditingData;
                var panelEditingData = await panelMgr.GetGalaxyPanelEditingDataAsync(parameters);

                if (panelMgr.HasErrors)
                {
                    LogErrors(panelMgr.Errors, true);
                }
                else
                    panelEditingData.BuildBoardTypeBoardSectionModes();

                var newPanel = new GalaxySMSEntities.GalaxyPanel()
                {
                    GalaxyPanelUid = Guid.Empty,
                    ClusterGroupId = 0,
                    ClusterUid = obj.ClusterUid,
                    ClusterNumber = fullSgPanel.LOOPID,
                    PanelName = fullSgPanel.NAME,
                    PanelNumber = fullSgPanel.UNITNUMBER,
                    Location = fullSgPanel.NAME,
                };

                var panelModel600 = panelEditingData.PanelModels.FirstOrDefault(o => o.TypeCode == GalaxySMS.Common.Enums.GalaxyPanelModel.GalaxyPanel600.ToString());
                var panelModel635 = panelEditingData.PanelModels.FirstOrDefault(o => o.TypeCode == GalaxySMS.Common.Enums.GalaxyPanelModel.GalaxyPanel635.ToString());
                var panelModel708 = panelEditingData.PanelModels.FirstOrDefault(o => o.TypeCode == GalaxySMS.Common.Enums.GalaxyPanelModel.GalaxyPanel708.ToString());
                var cpuModel600 = panelEditingData.CpuModels.FirstOrDefault(o => o.TypeCode == GalaxySMS.Common.Enums.CpuModel.Cpu600.ToString());
                var cpuModel635 = panelEditingData.CpuModels.FirstOrDefault(o => o.TypeCode == GalaxySMS.Common.Enums.CpuModel.Cpu635.ToString());
                var cpuModel708 = panelEditingData.CpuModels.FirstOrDefault(o => o.TypeCode == GalaxySMS.Common.Enums.CpuModel.Cpu708.ToString());

                switch (fullSgPanel.MODEL)
                {
                    case 600:
                        if (panelModel600 != null)
                            newPanel.GalaxyPanelModelUid = panelModel600.GalaxyPanelModelUid;
                        break;

                    case 708:
                        if (panelModel708 != null)
                            newPanel.GalaxyPanelModelUid = panelModel708.GalaxyPanelModelUid;
                        break;

                    default:
                        if (panelModel635 != null)
                            newPanel.GalaxyPanelModelUid = panelModel635.GalaxyPanelModelUid;
                        break;
                }

                foreach (var cpu in fullSgPanel.Cpus)
                {
                    var newCpu = new GalaxySMSEntities.GalaxyCpu()
                    {
                        CpuUid = Guid.Empty,
                        GalaxyPanelUid = Guid.Empty,
                        ClusterGroupId = newPanel.ClusterGroupId,
                        ClusterNumber = newPanel.ClusterNumber,
                        PanelNumber = newPanel.PanelNumber,
                        CpuNumber = (short)cpu.CPUNUMBER,
                        SerialNumber = cpu.SN,
                        IpAddress = cpu.LASTIPADDRESS,
                        Model = cpu.MODEL,
                        IsActive = cpu.UNUSED == 0,
                        PreventDataLoading = fullSgPanel.BYPASS != 0,
                        PreventFlashLoading = fullSgPanel.BYPASSFLASHLOADING != 0,
                        DefaultEventLoggingOn = true,
                    };

                    switch (cpu.MODEL)
                    {
                        case 600:
                            if (cpuModel600 != null)
                            {
                                newCpu.GalaxyCpuModelUid = cpuModel600.GalaxyCpuModelUid;
                            }
                            break;

                        case 708:
                            if (cpuModel708 != null)
                            {
                                newCpu.GalaxyCpuModelUid = cpuModel708.GalaxyCpuModelUid;
                            }
                            break;

                        default:
                            if (cpuModel635 != null)
                            {
                                newCpu.GalaxyCpuModelUid = cpuModel635.GalaxyCpuModelUid;
                            }
                            break;
                    }

                    if (newCpu.IsActive)
                    {
                        //if (newCpu.GalaxyCpuModelUid == GalaxySMS.Common.Constants.GalaxyCpuTypeIds.GalaxyCpuType_600)
                        //    newPanel.GalaxyPanelModelUid = GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_600;
                        if (newCpu.GalaxyCpuModelUid == GalaxySMS.Common.Constants.GalaxyCpuTypeIds.GalaxyCpuType_635)
                            newPanel.GalaxyPanelModelUid = GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_635;
                        else if (newCpu.GalaxyCpuModelUid == GalaxySMS.Common.Constants.GalaxyCpuTypeIds.GalaxyCpuType_708)
                            newPanel.GalaxyPanelModelUid = GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_708;
                        else
                            newPanel.GalaxyPanelModelUid = GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_635;
                    }
                    newPanel.Cpus.Add(newCpu);
                }

                foreach (var b in fullSgPanel.Boards)
                {
                    var newBoard = new GalaxySMSEntities.GalaxyInterfaceBoard
                    {
                        BoardNumber = (short)b.BOARDID,
                    };
                    switch ((GalaxySMS.Common.Enums.GalaxyInterfaceBoardType)b.BOARDTYPEID)
                    {
                        case GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
                            newBoard.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface600;
                            foreach (var s in b.Sections)
                            {
                                var newSection = new GalaxySMSEntities.GalaxyInterfaceBoardSection()
                                {
                                    SectionNumber = (short)s.SECTIONID
                                };
                                switch (s.Type_x)
                                {
                                    case 0: // Not In Use
                                        newSection.IsSectionActive = false;
                                        newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualReaderInterface600ModeIds.ReaderInterfaceMode_Unused;
                                        break;
                                    case 1: // ReaderPort
                                        newSection.IsSectionActive = true;
                                        newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualReaderInterface600ModeIds.ReaderInterfaceMode_AccessPortal;
                                        break;
                                    default:
                                        break;
                                }
                                newBoard.InterfaceBoardSections.Add(newSection);
                            }
                            break;
                        case GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
                            newBoard.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635;
                            foreach (var s in b.Sections)
                            {
                                var newSection = new GalaxySMSEntities.GalaxyInterfaceBoardSection()
                                {
                                    SectionNumber = (short)s.SECTIONID
                                };
                                switch (s.Type_x)
                                {
                                    case 0: // Not In Use
                                        newSection.IsSectionActive = false;
                                        newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualReaderInterface635ModeIds.ReaderInterfaceMode_Unused;
                                        break;
                                    case 1: // ReaderPort
                                        newSection.IsSectionActive = true;
                                        newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualReaderInterface635ModeIds.ReaderInterfaceMode_AccessPortal;
                                        break;
                                    default:
                                        break;
                                }
                                newBoard.InterfaceBoardSections.Add(newSection);
                            }
                            break;
                        case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                        case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                            newBoard.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface635;
                            foreach (var s in b.Sections)
                            {
                                var serialChannelData = fullSgPanel.SerialChannels.FirstOrDefault(o => o.BOARDID == s.BOARDID && o.SECTIONID == s.SECTIONID);
                                var newSection = new GalaxySMSEntities.GalaxyInterfaceBoardSection()
                                {
                                    SectionNumber = (short)s.SECTIONID
                                };

                                newSection.IsSectionActive = true;
                                newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Unused;
                                if (serialChannelData != null)
                                {
                                    switch ((DualSerialChannelMode)serialChannelData.CHANNELMODE)
                                    {
                                        case DualSerialChannelMode.Unused:
                                            newSection.IsSectionActive = false;
                                            newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Unused;
                                            break;
                                        case DualSerialChannelMode.Shell:
                                            newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Shell;
                                            break;
                                        case DualSerialChannelMode.ElevatorRelays:
                                            newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_ElevatorRelays;
                                            break;
                                        case DualSerialChannelMode.CypressClockDisplay:
                                            newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_CypressClockDisplay;
                                            break;
                                        case DualSerialChannelMode.OutputRelays:
                                            newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_OutputRelays;
                                            break;
                                        case DualSerialChannelMode.AllegionPimWiegand:
                                            newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand;
                                            break;
                                        case DualSerialChannelMode.AllegionPimAba:
                                            newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimAba;
                                            break;
                                        case DualSerialChannelMode.LCD_4x20Display:
                                            newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_LCD_4x20Display;
                                            break;
                                        case DualSerialChannelMode.RS485DoorModule:
                                            newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485DoorModule;
                                            break;
                                        case DualSerialChannelMode.AssaAbloyAperio:
                                            newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio;
                                            break;
                                        case DualSerialChannelMode.SaltoSallis:
                                            newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_SaltoSallis;
                                            break;
                                        case DualSerialChannelMode.RS485InputModule:
                                            newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485InputModule;
                                            break;
                                        case DualSerialChannelMode.VeridtCac:
                                            newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_VeridtCac;
                                            break;
                                        default:
                                            newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Unused;
                                            break;
                                    }
                                }

                                var boardSectionMode = panelEditingData.InterfaceBoardSectionModes.FirstOrDefault(o => o.InterfaceBoardSectionModeUid == newSection.InterfaceBoardSectionModeUid);
                                if (boardSectionMode != null)
                                {
                                    newSection.CreateModules(boardSectionMode);
                                    if (serialChannelData != null)
                                    {
                                        switch ((DualSerialChannelMode)serialChannelData.CHANNELMODE)
                                        {
                                            case DualSerialChannelMode.RS485DoorModule:
                                                foreach (var n in newSection.GalaxyInterfaceBoardSectionNodes)
                                                {
                                                    var reader = fullSgPanel.Readers.FirstOrDefault(o => o.BOARDID == newBoard.BoardNumber && o.SECTIONID == newSection.SectionNumber && o.SUBSECTIONID == n.NodeNumber);
                                                    n.IsNodeActive = reader != null;
                                                }
                                                break;
                                            case DualSerialChannelMode.ElevatorRelays:
                                                break;
                                            case DualSerialChannelMode.CypressClockDisplay:
                                                break;
                                            case DualSerialChannelMode.OutputRelays:
                                                break;
                                            case DualSerialChannelMode.AllegionPimWiegand:
                                                break;
                                            case DualSerialChannelMode.AllegionPimAba:
                                                break;
                                            case DualSerialChannelMode.LCD_4x20Display:
                                                break;
                                            case DualSerialChannelMode.AssaAbloyAperio:
                                                break;
                                            case DualSerialChannelMode.SaltoSallis:
                                                break;
                                            case DualSerialChannelMode.RS485InputModule:
                                                break;
                                            case DualSerialChannelMode.VeridtCac:
                                                break;
                                            case DualSerialChannelMode.Unused:
                                            case DualSerialChannelMode.Shell:
                                            default:
                                                break;
                                        }
                                    }

                                }

                                newBoard.InterfaceBoardSections.Add(newSection);
                            }
                            break;
                        //case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                        //    newBoard.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface600;
                        //    foreach (var s in b.Sections)
                        //    {
                        //        var serialChannelData = fullSgPanel.SerialChannels.FirstOrDefault(o => o.BOARDID == s.BOARDID && o.SECTIONID == s.SECTIONID);
                        //        var newSection = new GalaxySMSEntities.GalaxyInterfaceBoardSection()
                        //        {
                        //            SectionNumber = (short)s.SECTIONID
                        //        };

                        //        newSection.IsSectionActive = true;
                        //        newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Unused;
                        //        if (serialChannelData != null)
                        //        {
                        //            switch ((DualSerialChannelMode)serialChannelData.CHANNELMODE)
                        //            {
                        //                case DualSerialChannelMode.Shell:
                        //                    newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Shell;
                        //                    break;
                        //                case DualSerialChannelMode.ElevatorRelays:
                        //                    newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_ElevatorRelays;
                        //                    break;
                        //                case DualSerialChannelMode.CypressClockDisplay:
                        //                    newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_CypressClockDisplay;
                        //                    break;
                        //                case DualSerialChannelMode.OutputRelays:
                        //                    newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_OutputRelays;
                        //                    break;
                        //                case DualSerialChannelMode.AllegionPimWiegand:
                        //                    newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand;
                        //                    break;
                        //                case DualSerialChannelMode.AllegionPimAba:
                        //                    newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimAba;
                        //                    break;
                        //                case DualSerialChannelMode.LCD_4x20Display:
                        //                    newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_LCD_4x20Display;
                        //                    break;
                        //                case DualSerialChannelMode.AssaAbloyAperio:
                        //                    newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio;
                        //                    break;
                        //                case DualSerialChannelMode.SaltoSallis:
                        //                    newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_SaltoSallis;
                        //                    break;
                        //                case DualSerialChannelMode.VeridtCac:
                        //                    newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_VeridtCac;
                        //                    break;
                        //                case DualSerialChannelMode.Unused:
                        //                default:
                        //                    newSection.IsSectionActive = false;
                        //                    newSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Unused;
                        //                    break;
                        //            }
                        //        }

                        //        var boardSectionMode = panelEditingData.InterfaceBoardSectionModes.FirstOrDefault(o => o.InterfaceBoardSectionModeUid == newSection.InterfaceBoardSectionModeUid);
                        //        if (boardSectionMode != null)
                        //        {
                        //            newSection.CreateModules(boardSectionMode);
                        //            if (serialChannelData != null)
                        //            {
                        //                switch ((DualSerialChannelMode)serialChannelData.CHANNELMODE)
                        //                {
                        //                    case DualSerialChannelMode.RS485DoorModule:
                        //                        foreach (var n in newSection.GalaxyInterfaceBoardSectionNodes)
                        //                        {
                        //                            var reader = fullSgPanel.Readers.FirstOrDefault(o => o.BOARDID == newBoard.BoardNumber && o.SECTIONID == newSection.SectionNumber && o.SUBSECTIONID == n.NodeNumber);
                        //                            n.IsNodeActive = reader != null;
                        //                        }
                        //                        break;
                        //                    case DualSerialChannelMode.ElevatorRelays:
                        //                        break;
                        //                    case DualSerialChannelMode.CypressClockDisplay:
                        //                        break;
                        //                    case DualSerialChannelMode.OutputRelays:
                        //                        break;
                        //                    case DualSerialChannelMode.AllegionPimWiegand:
                        //                        break;
                        //                    case DualSerialChannelMode.AllegionPimAba:
                        //                        break;
                        //                    case DualSerialChannelMode.LCD_4x20Display:
                        //                        break;
                        //                    case DualSerialChannelMode.AssaAbloyAperio:
                        //                        break;
                        //                    case DualSerialChannelMode.SaltoSallis:
                        //                        break;
                        //                    case DualSerialChannelMode.RS485InputModule:
                        //                        break;
                        //                    case DualSerialChannelMode.VeridtCac:
                        //                        break;
                        //                    case DualSerialChannelMode.Unused:
                        //                    case DualSerialChannelMode.Shell:
                        //                    default:
                        //                        break;
                        //                }
                        //            }

                        //        }

                        //        newBoard.InterfaceBoardSections.Add(newSection);
                        //    }
                        //    break;
                        case GalaxyInterfaceBoardType.DigitalInputOutputBoard600:
                            newBoard.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DigitalInputOutput600;
                            break;
                        case GalaxyInterfaceBoardType.OtisElevatorInterface:
                            newBoard.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_OtisElevatorInterface;
                            break;
                        case GalaxyInterfaceBoardType.KoneElevatorInterface:
                            newBoard.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_KoneElevatorInterface;
                            break;
                        case GalaxyInterfaceBoardType.Veridt_ReaderModule:
                            newBoard.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_ReaderModule;
                            break;
                        case GalaxyInterfaceBoardType.Veridt_Cpu:
                            newBoard.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_Cpu;
                            break;
                        case GalaxyInterfaceBoardType.None:
                        case GalaxyInterfaceBoardType.DualPortInterfaceBoard500:
                        case GalaxyInterfaceBoardType.Cpu600:
                        case GalaxyInterfaceBoardType.Cpu635:
                        default:
                            break;
                    }

                    if (newBoard.InterfaceBoardTypeUid != Guid.Empty)
                        newPanel.InterfaceBoards.Add(newBoard);
                }
                var saveParameters = new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.GalaxyPanel>()
                {
                    CurrentEntityId = Globals.CurrentUserEntity.EntityId,
                    Data = newPanel,
                };
                Globals.BusyContent = Properties.Resources.BusyContent_ImportingPanel_SavingPanelData;
                var savedPanel = await panelMgr.SaveGalaxyPanelAsync(saveParameters);
                if (panelMgr.HasErrors)
                {
                    LogErrors(panelMgr.Errors, true);
                }
                else
                {
                    this.Log().Info($"GalaxyPanel created:{savedPanel.PanelName}, Cluster:{savedPanel.ClusterNumber}, PanelNumber:{savedPanel.PanelNumber}, GalaxyPanelUid:{savedPanel.GalaxyPanelUid}");

                    obj.SmsPanel = savedPanel;
                    // Now update the access portals, input, output, etc. data 
                    var accessPortalMgr = Globals.GetManager<AccessPortalManager>();
                    var accessPortals = await accessPortalMgr.GetAccessPortalsForGalaxyPanelAsync(new GalaxySMSEntities.GetParametersWithPhoto()
                    {
                        CurrentEntityId = Globals.CurrentUserEntity.EntityId,
                        IncludeHardwareAddress = true,
                        UniqueId = savedPanel.GalaxyPanelUid,
                        IncludeMemberCollections = true,
                    });

                    GalaxySMSEntities.AccessPortalGalaxyPanelSpecificEditingData apEditingData = null;
                    var apCommonEditingData = await accessPortalMgr.GetAccessPortalGalaxyCommonEditingDataAsync(new GalaxySMSEntities.GetParametersWithPhoto());
                    // The default access portals should already exists in the DB (they were created when the panel was saved based on the boards and section data 
                    foreach (var r in fullSgPanel.Readers)
                    {
                        GalaxySMSEntities.AccessPortal ap = null;
                        if (r.SUBSECTIONID == 0)
                            ap = accessPortals.Items.FirstOrDefault(o => o.BoardNumber == r.BOARDID && o.SectionNumber == r.SECTIONID);
                        else
                            ap = accessPortals.Items.FirstOrDefault(o => o.BoardNumber == r.BOARDID && o.SectionNumber == r.SECTIONID && o.NodeNumber == r.SUBSECTIONID);
                        if (ap != null)
                        {
                            if (apEditingData == null)
                                apEditingData = await accessPortalMgr.GetAccessPortalGalaxyPanelSpecificEditingDataAsync(new GalaxySMSEntities.GetParametersWithPhoto() { UniqueId = ap.AccessPortalUid });

                            ap.Name = r.READERNAME;
                            ap.ServiceComment = r.SERVICENOTES;
                            ap.Comment = r.COMMENTS;
                            ap.CriticalityComment = r.CRITICALITYNOTES;
                            switch (r.ReaderType.TYPECODE)
                            {
                                case 2: // Wiegand
                                    ap.AccessPortalTypeUid = apCommonEditingData.AccessPortalTypes.FirstOrDefault(o => o.Name.Contains("Wiegand")).AccessPortalTypeUid;
                                    break;

                                case 4:
                                case 5:
                                    ap.AccessPortalTypeUid = apCommonEditingData.AccessPortalTypes.FirstOrDefault(o => o.Name.Contains("Clock")).AccessPortalTypeUid;
                                    break;

                                case 0: // Galaxy Format
                                default:
                                    ap.AccessPortalTypeUid = apCommonEditingData.AccessPortalTypes.FirstOrDefault(o => o.Name.Contains("Wiegand")).AccessPortalTypeUid;
                                    break;
                            }
                            if (ap.Properties != null)
                            {
                                switch ((AutomaticForgivePassbackFrequency)r.AUTOFORGIVEPASSBACK)
                                {
                                    case AutomaticForgivePassbackFrequency.Never:
                                        ap.Properties.AutomaticForgivePassbackFrequencyUid = GalaxySMS.Common.Constants.AutomaticForgivePassbackFrequencyIds.Never;
                                        break;
                                    case AutomaticForgivePassbackFrequency.OncePerDay:
                                        ap.Properties.AutomaticForgivePassbackFrequencyUid = GalaxySMS.Common.Constants.AutomaticForgivePassbackFrequencyIds.OncePerDay;
                                        break;
                                    case AutomaticForgivePassbackFrequency.TwicePerDay:
                                        ap.Properties.AutomaticForgivePassbackFrequencyUid = GalaxySMS.Common.Constants.AutomaticForgivePassbackFrequencyIds.TwicePerDay;
                                        break;
                                    case AutomaticForgivePassbackFrequency.FourTimesPerDay:
                                        ap.Properties.AutomaticForgivePassbackFrequencyUid = GalaxySMS.Common.Constants.AutomaticForgivePassbackFrequencyIds.FourTimesPerDay;
                                        break;
                                    case AutomaticForgivePassbackFrequency.EveryTwoHours:
                                        ap.Properties.AutomaticForgivePassbackFrequencyUid = GalaxySMS.Common.Constants.AutomaticForgivePassbackFrequencyIds.EveryTwoHours;
                                        break;
                                    case AutomaticForgivePassbackFrequency.EveryHour:
                                        ap.Properties.AutomaticForgivePassbackFrequencyUid = GalaxySMS.Common.Constants.AutomaticForgivePassbackFrequencyIds.EveryHour;
                                        break;
                                    case AutomaticForgivePassbackFrequency.EveryThirtyMinutes:
                                        ap.Properties.AutomaticForgivePassbackFrequencyUid = GalaxySMS.Common.Constants.AutomaticForgivePassbackFrequencyIds.EveryThirtyMinutes;
                                        break;
                                }

                                switch (r.PINMODE)
                                {
                                    case 0:
                                        ap.Properties.PinRequiredModeUid = GalaxySMS.Common.Constants.PinRequiredModeIds.RequiredForAccessDecision;
                                        break;
                                    case 1:
                                        ap.Properties.PinRequiredModeUid = GalaxySMS.Common.Constants.PinRequiredModeIds.InformationalOnly;
                                        break;
                                }

                                if (r.PINRECLOSETIME != 0)
                                    ap.Properties.PinRequiredModeUid = GalaxySMS.Common.Constants.PinRequiredModeIds.SpecifiesRecloseTime;

                                // The SG database stores the DCSUPERVISE value as the actual # value that must be sent to the panel
                                switch (r.DCSUPERVISE)
                                {
                                    case 0:
                                        ap.Properties.AccessPortalContactSupervisionTypeUid = GalaxySMS.Common.Constants.AccessPortalContactSupervisionTypeIds.None;
                                        break;
                                    case 4:
                                        ap.Properties.AccessPortalContactSupervisionTypeUid = GalaxySMS.Common.Constants.AccessPortalContactSupervisionTypeIds.SeriesInLine;
                                        break;
                                    case 2:
                                        ap.Properties.AccessPortalContactSupervisionTypeUid = GalaxySMS.Common.Constants.AccessPortalContactSupervisionTypeIds.ParallelEndOfLine;
                                        break;
                                    case 6:
                                        ap.Properties.AccessPortalContactSupervisionTypeUid = GalaxySMS.Common.Constants.AccessPortalContactSupervisionTypeIds.SeriesAndParallel;
                                        break;
                                }

                                switch ((AccessPortalDeferToServerBehavior)r.ALLOWSERVEROVERRIDE)
                                {
                                    case AccessPortalDeferToServerBehavior.Never:
                                        ap.Properties.AccessPortalDeferToServerBehaviorUid = GalaxySMS.Common.Constants.AccessPortalDeferToServerBehaviorIds.Never;
                                        break;
                                    case AccessPortalDeferToServerBehavior.WhenPanelWouldDenyAccess:
                                        ap.Properties.AccessPortalDeferToServerBehaviorUid = GalaxySMS.Common.Constants.AccessPortalDeferToServerBehaviorIds.WhenPanelWouldDenyAccess;
                                        break;
                                    case AccessPortalDeferToServerBehavior.WhenPanelWouldGrantAccess:
                                        ap.Properties.AccessPortalDeferToServerBehaviorUid = GalaxySMS.Common.Constants.AccessPortalDeferToServerBehaviorIds.WhenPanelWouldGrantAccess;
                                        break;
                                    case AccessPortalDeferToServerBehavior.Always:
                                        ap.Properties.AccessPortalDeferToServerBehaviorUid = GalaxySMS.Common.Constants.AccessPortalDeferToServerBehaviorIds.Always;
                                        break;
                                }

                                switch ((AccessPortalNoServerReplyBehavior)r.OVERRIDENOREPLY)
                                {
                                    case AccessPortalNoServerReplyBehavior.FollowPanelDecision:
                                        ap.Properties.AccessPortalNoServerReplyBehaviorUid = GalaxySMS.Common.Constants.AccessPortalNoServerReplyBehaviorIds.FollowPanelDecision;
                                        break;
                                    case AccessPortalNoServerReplyBehavior.AlwaysGrantAccess:
                                        ap.Properties.AccessPortalNoServerReplyBehaviorUid = GalaxySMS.Common.Constants.AccessPortalNoServerReplyBehaviorIds.AlwaysGrantAccess;
                                        break;
                                    case AccessPortalNoServerReplyBehavior.AlwaysDenyAccess:
                                        ap.Properties.AccessPortalNoServerReplyBehaviorUid = GalaxySMS.Common.Constants.AccessPortalNoServerReplyBehaviorIds.AlwaysDenyAccess;
                                        break;
                                }

                                switch ((AccessPortalLockPushButtonBehavior)r.IRIPBMODE)
                                {
                                    case AccessPortalLockPushButtonBehavior.None:
                                        ap.Properties.AccessPortalLockPushButtonBehaviorUid = AccessPortalLockPushButtonBehaviorIds.None;
                                        break;
                                    case AccessPortalLockPushButtonBehavior.Privacy:
                                        ap.Properties.AccessPortalLockPushButtonBehaviorUid = AccessPortalLockPushButtonBehaviorIds.Privacy;
                                        break;
                                    case AccessPortalLockPushButtonBehavior.Office:
                                        ap.Properties.AccessPortalLockPushButtonBehaviorUid = AccessPortalLockPushButtonBehaviorIds.Office;
                                        break;
                                }

                                switch ((AccessPortalMultiFactorModeCode)r.MULTIFACTORMODE)
                                {
                                    case AccessPortalMultiFactorModeCode.SingleFactor:
                                        ap.Properties.AccessPortalMultiFactorModeUid = GalaxySMS.Common.Constants.AccessPortalMultiFactorModeIds.SingleFactor;
                                        break;
                                    case AccessPortalMultiFactorModeCode.TwoFactor:
                                        ap.Properties.AccessPortalMultiFactorModeUid = GalaxySMS.Common.Constants.AccessPortalMultiFactorModeIds.TwoFactor;
                                        break;
                                    case AccessPortalMultiFactorModeCode.ThreeFactor:
                                        ap.Properties.AccessPortalMultiFactorModeUid = GalaxySMS.Common.Constants.AccessPortalMultiFactorModeIds.ThreeFactor;
                                        break;
                                }

                                ap.Properties.UnlockDelay = r.UNLOCKDELAY;
                                ap.Properties.UnlockDuration = r.UNLOCKTIME;
                                ap.Properties.RecloseDuration = r.RECLOSETIME;
                                ap.Properties.AllowPassbackAccess = r.ALLOWPASSBACKACCESS != 0;
                                ap.Properties.RequireTwoValidCredentials = r.TWOPERSONRULE != 0;
                                ap.Properties.UnlockOnREX = r.UNLOCKONREX != 0;
                                ap.Properties.SuppressIllegalOpenLog = r.DISABLEFORCEDOPENMESSAGE != 0;
                                ap.Properties.SuppressOpenTooLongLog = r.DISABLEOPENTOOLONGMESSAGE != 0;
                                ap.Properties.SuppressClosedLog = r.DISABLECLOSEDMESSAGE != 0;
                                ap.Properties.SuppressREXLog = r.DISABLEREXMESSAGE != 0;
                                ap.Properties.GenerateDoorContactChangeLogs = r.GENERATEDOORCONTACTCHANGEMESSAGES != 0;
                                ap.Properties.LockWhenDoorCloses = r.LOCKONDCCLOSE != 0;
                                ap.Properties.EnableDuress = r.ENABLEDURESS != 0;
                                ap.Properties.DoorGroupNotify = r.NOTIFYGROUP != 0;
                                ap.Properties.DoorGroupCanDisable = r.DISABLEDBYGROUP != 0;
                                ap.Properties.RelayOneOnDuringArmDelay = r.RELAY1PREARM != 0;
                                ap.Properties.RequireValidAccessForAutoUnlock = r.SNOWDAY != 0;
//                                ap.Properties.PINSpecifiesRecloseDuration = r.PINRECLOSETIME != 0;
                                ap.Properties.ValidAccessRequiresDoorOpen = r.VALIDACCESSREQSDOORTOOPEN != 0;
                                ap.Properties.DontDecrementLimitedSwipeExpireCount = r.DONTDECLIMITEDSWIPE != 0;
                                ap.Properties.IgnoreNotInSystem = r.IGNORENOTINSYS != 0;
                                ap.Properties.ReaderSendsHeartbeat = r.HEARTBEATENABLED != 0;
                                ap.Properties.PhotoVerificationEnabled = r.VIDEOVERIFICATION != 0;
                                ap.Properties.TimeAttendancePortal = r.TAREADER != 0;
                                ap.Properties.EMailEventsEnabled = r.LOGEMAILENABLED != 0;
                                ap.Properties.TransmitEventsEnabled = r.LOGXMITENABLED != 0;
                                ap.Properties.FileOutputEnabled = r.LOGFILEENABLED != 0;
                            }

                            // Time Schedules
                            var autoUnlockSch = ap.Schedules.FirstOrDefault(o => o.AccessPortalScheduleTypeUid == AccessPortalScheduleTypeIds.AutomaticUnlock);

                            if (autoUnlockSch != null)
                            {
                                if (r.UNLOCKSCHNUMBER == GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Always)
                                    autoUnlockSch.TimeScheduleUid = TimeScheduleIds.TimeSchedule_Always;
                                else if (r.UNLOCKSCHNUMBER == GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Never)
                                    autoUnlockSch.TimeScheduleUid = TimeScheduleIds.TimeSchedule_Never;
                                else
                                {
                                    var sch = clusterData.TimeSchedules.FirstOrDefault(o => o.ClusterScheduleMap.PanelScheduleNumber == r.UNLOCKSCHNUMBER);
                                    autoUnlockSch.TimeScheduleUid = sch?.TimeScheduleUid ?? TimeScheduleIds.TimeSchedule_Never;
                                }

                            }

                            var pinRequiredSch = ap.Schedules.FirstOrDefault(o => o.AccessPortalScheduleTypeUid == AccessPortalScheduleTypeIds.PinRequired);
                            if (pinRequiredSch != null)
                            {
                                if (r.PINREQDSCHNUMBER == GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Always)
                                    pinRequiredSch.TimeScheduleUid = TimeScheduleIds.TimeSchedule_Always;
                                else if (r.PINREQDSCHNUMBER == GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Never)
                                    pinRequiredSch.TimeScheduleUid = TimeScheduleIds.TimeSchedule_Never;
                                else
                                {
                                    var sch = clusterData.TimeSchedules.FirstOrDefault(o => o.ClusterScheduleMap.PanelScheduleNumber == r.PINREQDSCHNUMBER);
                                    pinRequiredSch.TimeScheduleUid = sch?.TimeScheduleUid ?? TimeScheduleIds.TimeSchedule_Never;
                                }
                            }

                            var crisisModeUnlockSch = ap.Schedules.FirstOrDefault(o => o.AccessPortalScheduleTypeUid == AccessPortalScheduleTypeIds.CrisisUnlock);
                            if (crisisModeUnlockSch != null)
                            {
                                if (r.CRISISUNLOCKSCHNUMBER == GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Always)
                                    crisisModeUnlockSch.TimeScheduleUid = TimeScheduleIds.TimeSchedule_Always;
                                else if (r.CRISISUNLOCKSCHNUMBER == GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Never)
                                    crisisModeUnlockSch.TimeScheduleUid = TimeScheduleIds.TimeSchedule_Never;
                                else
                                {
                                    var sch = clusterData.TimeSchedules.FirstOrDefault(o => o.ClusterScheduleMap.PanelScheduleNumber == r.CRISISUNLOCKSCHNUMBER);
                                    crisisModeUnlockSch.TimeScheduleUid = sch?.TimeScheduleUid ?? TimeScheduleIds.TimeSchedule_Never;
                                }
                            }

                            var auxOutputSch = ap.Schedules.FirstOrDefault(o => o.AccessPortalScheduleTypeUid == AccessPortalScheduleTypeIds.AuxiliaryOutput);
                            if (auxOutputSch != null)
                            {
                                if (r.R2SCHEDULENUMBER == GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Always)
                                    auxOutputSch.TimeScheduleUid = TimeScheduleIds.TimeSchedule_Always;
                                else if (r.R2SCHEDULENUMBER == GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Never)
                                    auxOutputSch.TimeScheduleUid = TimeScheduleIds.TimeSchedule_Never;
                                else
                                {
                                    var sch = clusterData.TimeSchedules.FirstOrDefault(o => o.ClusterScheduleMap.PanelScheduleNumber == r.R2SCHEDULENUMBER);
                                    auxOutputSch.TimeScheduleUid = sch?.TimeScheduleUid ?? TimeScheduleIds.TimeSchedule_Never;
                                }
                            }

                            var disableForcedOpenSch = ap.Schedules.FirstOrDefault(o => o.AccessPortalScheduleTypeUid == AccessPortalScheduleTypeIds.DisableForcedOpen);
                            if (disableForcedOpenSch != null)
                            {
                                if (r.FORCEDOPENSCHNUMBER == GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Always)
                                    disableForcedOpenSch.TimeScheduleUid = TimeScheduleIds.TimeSchedule_Always;
                                else if (r.FORCEDOPENSCHNUMBER == GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Never)
                                    disableForcedOpenSch.TimeScheduleUid = TimeScheduleIds.TimeSchedule_Never;
                                else
                                {
                                    var sch = clusterData.TimeSchedules.FirstOrDefault(o => o.ClusterScheduleMap.PanelScheduleNumber == r.FORCEDOPENSCHNUMBER);
                                    disableForcedOpenSch.TimeScheduleUid = sch?.TimeScheduleUid ?? TimeScheduleIds.TimeSchedule_Never;
                                }
                            }

                            var disableLeftOpenSch = ap.Schedules.FirstOrDefault(o => o.AccessPortalScheduleTypeUid == AccessPortalScheduleTypeIds.DisableOpenTooLong);
                            if (disableLeftOpenSch != null)
                            {
                                if (r.STILLOPENSCHNUMBER == GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Always)
                                    disableLeftOpenSch.TimeScheduleUid = TimeScheduleIds.TimeSchedule_Always;
                                else if (r.STILLOPENSCHNUMBER == GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Never)
                                    disableLeftOpenSch.TimeScheduleUid = TimeScheduleIds.TimeSchedule_Never;
                                else
                                {
                                    var sch = clusterData.TimeSchedules.FirstOrDefault(o => o.ClusterScheduleMap.PanelScheduleNumber == r.STILLOPENSCHNUMBER);
                                    disableLeftOpenSch.TimeScheduleUid = sch?.TimeScheduleUid ?? TimeScheduleIds.TimeSchedule_Never;
                                }
                            }

                            // Auxiliary Output (Relay 2)
                            switch ((AccessPortalAuxiliaryOutputMode)r.RELAY2MODE)
                            {
                                case AccessPortalAuxiliaryOutputMode.Follows:
                                    ap.AuxiliaryOutputRelay2.AccessPortalAuxiliaryOutputModeUid = GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Follows;
                                    ap.AuxiliaryOutputRelay2.IllegalOpen = r.RELAY2FORCEDOPEN != 0;
                                    ap.AuxiliaryOutputRelay2.OpenTooLong = r.RELAY2OPENTOOLONG != 0;
                                    break;

                                case AccessPortalAuxiliaryOutputMode.Timeout:
                                    ap.AuxiliaryOutputRelay2.AccessPortalAuxiliaryOutputModeUid = GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Timeout;
                                    ap.AuxiliaryOutputRelay2.IllegalOpen = r.RELAY2FORCEDOPEN != 0;
                                    ap.AuxiliaryOutputRelay2.OpenTooLong = r.RELAY2OPENTOOLONG != 0;
                                    ap.AuxiliaryOutputRelay2.InvalidAttempt = r.RELAY2INVALIDATTEMPT != 0;
                                    ap.AuxiliaryOutputRelay2.AccessGranted = r.RELAY2ACCESSGRANTED != 0;
                                    ap.AuxiliaryOutputRelay2.Duress = r.RELAY2DURESS != 0;
                                    ap.AuxiliaryOutputRelay2.PassbackViolation = r.RELAY2PASSBACK != 0;
                                    ap.AuxiliaryOutputRelay2.ActivationDelay = r.RELAY2DELAY;
                                    ap.AuxiliaryOutputRelay2.ActivationDuration = r.RELAY2DURATION;
                                    break;

                                case AccessPortalAuxiliaryOutputMode.Scheduled:
                                    ap.AuxiliaryOutputRelay2.AccessPortalAuxiliaryOutputModeUid = GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Scheduled;
                                    var sch = clusterData.TimeSchedules.FirstOrDefault(o => o.ClusterScheduleMap.PanelScheduleNumber == r.R2SCHEDULENUMBER);
                                    ap.AuxiliaryOutputRelay2.TimeScheduleUid = sch?.TimeScheduleUid ?? TimeScheduleIds.TimeSchedule_Never;
                                    break;
                                case AccessPortalAuxiliaryOutputMode.Latching:
                                    ap.AuxiliaryOutputRelay2.AccessPortalAuxiliaryOutputModeUid = GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Latching;
                                    ap.AuxiliaryOutputRelay2.IllegalOpen = r.RELAY2FORCEDOPEN != 0;
                                    ap.AuxiliaryOutputRelay2.OpenTooLong = r.RELAY2OPENTOOLONG != 0;
                                    ap.AuxiliaryOutputRelay2.InvalidAttempt = r.RELAY2INVALIDATTEMPT != 0;
                                    ap.AuxiliaryOutputRelay2.AccessGranted = r.RELAY2ACCESSGRANTED != 0;
                                    ap.AuxiliaryOutputRelay2.Duress = r.RELAY2DURESS != 0;
                                    ap.AuxiliaryOutputRelay2.PassbackViolation = r.RELAY2PASSBACK != 0;
                                    break;
                            }

                            // Access Rules
                            foreach (var ar in r.ReaderAccessRules.Where(o => o.ACCESSGROUPNUMBER != GalaxySMS.Common.Constants.AccessGroupLimits.None &&
                                                                            o.ACCESSGROUPNUMBER != GalaxySMS.Common.Constants.AccessGroupLimits.UnlimitedAccess))
                            {
                                var agap = ap.AccessGroups.FirstOrDefault(o => o.AccessGroupNumber == ar.ACCESSGROUPNUMBER);
                                if (agap == null)
                                {
                                    var ag = clusterData.AccessGroups.FirstOrDefault(o => o.AccessGroupNumber == ar.ACCESSGROUPNUMBER);
                                    agap = new GalaxySMSEntities.AccessGroupAccessPortal()
                                    {
                                        AccessGroupUid = ag.AccessGroupUid,
                                    };

                                    ap.AccessGroups.Add(agap);
                                }

                                var sch = clusterData.TimeSchedules.FirstOrDefault(o => o.ClusterScheduleMap.PanelScheduleNumber == ar.SCHEDULENUMBER);
                                if (sch != null)
                                {
                                    agap.TimeScheduleUid = sch.TimeScheduleUid;
                                }
                                else if (ar.SCHEDULENUMBER == GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Always)
                                    agap.TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always;
                            }

                            // Alert Events
                            ProcessAlertEventData(new ProcessAlertEventData()
                            {
                                InputOutputGroups = clusterData.InputOutputGroups,
                                TimeSchedules = clusterData.TimeSchedules,
                                InputOutputGroupNumber = r.FORCEDOPENPARTNUMBER,
                                InputOutputGroupOffsetNumber = r.FORCEDOPENOFFSET,
                                AlertEvent = ap.AlertEventForcedOpen,
                                AckScheduleNumber = r.ACKFORCEDOPENSCH,
                                Priority = r.FORCEDOPENPRIORITY,
                                InstructionText = r.ReaderPortInstructions.FORCEDOPEN,
                                AudioFilename = r.ReaderPortAudio.FORCEDOPEN,
                                ResponseRequired = false
                            });

                            ProcessAlertEventData(new ProcessAlertEventData()
                            {
                                InputOutputGroups = clusterData.InputOutputGroups,
                                TimeSchedules = clusterData.TimeSchedules,
                                InputOutputGroupNumber = r.OPENTOOLONGPARTNUMBER,
                                InputOutputGroupOffsetNumber = r.OPENTOOLONGOFFSET,
                                AlertEvent = ap.AlertEventOpenTooLong,
                                AckScheduleNumber = r.ACKOPENTOOLONGSCH,
                                Priority = r.OPENTOOLONGPRIORITY,
                                InstructionText = r.ReaderPortInstructions.OPENTOOLONG,
                                AudioFilename = r.ReaderPortAudio.STILLOPEN,
                                ResponseRequired = false
                            });

                            ProcessAlertEventData(new ProcessAlertEventData()
                            {
                                InputOutputGroups = clusterData.InputOutputGroups,
                                TimeSchedules = clusterData.TimeSchedules,
                                InputOutputGroupNumber = r.INVALIDPARTNUMBER,
                                InputOutputGroupOffsetNumber = r.INVALIDOFFSET,
                                AlertEvent = ap.AlertEventInvalidAccessAttempt,
                                AckScheduleNumber = r.ACKINVALIDSCH,
                                Priority = r.INVALIDATTEMPTPRIORITY,
                                InstructionText = r.ReaderPortInstructions.INVALIDATTEMPT,
                                AudioFilename = r.ReaderPortAudio.INVALIDATTEMPT,
                                ResponseRequired = false
                            });

                            ProcessAlertEventData(new ProcessAlertEventData()
                            {
                                InputOutputGroups = clusterData.InputOutputGroups,
                                TimeSchedules = clusterData.TimeSchedules,
                                InputOutputGroupNumber = r.DURESSPARTNUMBER,
                                InputOutputGroupOffsetNumber = r.DURESSOFFSET,
                                AlertEvent = ap.AlertEventDuress,
                                AckScheduleNumber = r.ACKDURESSSCH,
                                Priority = r.DURESSPRIORITY,
                                InstructionText = r.ReaderPortInstructions.DURESS,
                                AudioFilename = r.ReaderPortAudio.DURESS,
                                ResponseRequired = false
                            });

                            ProcessAlertEventData(new ProcessAlertEventData()
                            {
                                InputOutputGroups = clusterData.InputOutputGroups,
                                TimeSchedules = clusterData.TimeSchedules,
                                InputOutputGroupNumber = r.PASSBACKPARTNUMBER,
                                InputOutputGroupOffsetNumber = r.PASSBACKOFFSET,
                                AlertEvent = ap.AlertEventPassbackViolation,
                                AckScheduleNumber = r.ACKPASSBACKSCH,
                                Priority = r.PASSBACKPRIORITY,
                                InstructionText = r.ReaderPortInstructions.PASSBACK,
                                AudioFilename = r.ReaderPortAudio.PASSBACK,
                                ResponseRequired = false
                            });

                            ProcessAlertEventData(new ProcessAlertEventData()
                            {
                                InputOutputGroups = clusterData.InputOutputGroups,
                                TimeSchedules = clusterData.TimeSchedules,
                                InputOutputGroupNumber = r.HEARTBEATPARTNUMBER,
                                InputOutputGroupOffsetNumber = r.HEARTBEATOFFSET,
                                AlertEvent = ap.AlertEventReaderHeartbeat,
                                AckScheduleNumber = r.ACKHEARTBEATSCH,
                                Priority = r.HEARTBEATPRIORITY,
                                InstructionText = r.ReaderPortInstructions.HEARTBEAT,
                                AudioFilename = r.ReaderPortAudio.HEARTBEAT,
                                ResponseRequired = false
                            });


                            ProcessAlertEventData(new ProcessAlertEventData()
                            {
                                InputOutputGroups = clusterData.InputOutputGroups,
                                TimeSchedules = clusterData.TimeSchedules,
                                InputOutputGroupNumber = r.ACCESSPARTNUMBER,
                                InputOutputGroupOffsetNumber = r.ACCESSOFFSET,
                                AlertEvent = ap.AlertEventAccessGranted,
                                AckScheduleNumber = TimeScheduleNumber.TimeSchedule_Never,
                                Priority = 0,
                                InstructionText = string.Empty,
                                AudioFilename = string.Empty,
                                ResponseRequired = false
                            });

                            ProcessAlertEventData(new ProcessAlertEventData()
                            {
                                InputOutputGroups = clusterData.InputOutputGroups,
                                TimeSchedules = clusterData.TimeSchedules,
                                InputOutputGroupNumber = r.DISARMPART1,
                                InputOutputGroupOffsetNumber = 0,
                                AlertEvent = ap.AlertEventAccessGrantedDisarmIoGroup1,
                                AckScheduleNumber = TimeScheduleNumber.TimeSchedule_Never,
                                Priority = 0,
                                InstructionText = string.Empty,
                                AudioFilename = string.Empty,
                                ResponseRequired = false
                            });

                            ProcessAlertEventData(new ProcessAlertEventData()
                            {
                                InputOutputGroups = clusterData.InputOutputGroups,
                                TimeSchedules = clusterData.TimeSchedules,
                                InputOutputGroupNumber = r.DISARMPART2,
                                InputOutputGroupOffsetNumber = 0,
                                AlertEvent = ap.AlertEventAccessGrantedDisarmIoGroup2,
                                AckScheduleNumber = TimeScheduleNumber.TimeSchedule_Never,
                                Priority = 0,
                                InstructionText = string.Empty,
                                AudioFilename = string.Empty,
                                ResponseRequired = false
                            });

                            ProcessAlertEventData(new ProcessAlertEventData()
                            {
                                InputOutputGroups = clusterData.InputOutputGroups,
                                TimeSchedules = clusterData.TimeSchedules,
                                InputOutputGroupNumber = r.DISARMPART3,
                                InputOutputGroupOffsetNumber = 0,
                                AlertEvent = ap.AlertEventAccessGrantedDisarmIoGroup3,
                                AckScheduleNumber = TimeScheduleNumber.TimeSchedule_Never,
                                Priority = 0,
                                InstructionText = string.Empty,
                                AudioFilename = string.Empty,
                                ResponseRequired = false
                            });

                            ProcessAlertEventData(new ProcessAlertEventData()
                            {
                                InputOutputGroups = clusterData.InputOutputGroups,
                                TimeSchedules = clusterData.TimeSchedules,
                                InputOutputGroupNumber = r.DISARMPART4,
                                InputOutputGroupOffsetNumber = 0,
                                AlertEvent = ap.AlertEventAccessGrantedDisarmIoGroup4,
                                AckScheduleNumber = TimeScheduleNumber.TimeSchedule_Never,
                                Priority = 0,
                                InstructionText = string.Empty,
                                AudioFilename = string.Empty,
                                ResponseRequired = false
                            });


                            ProcessAlertEventData(new ProcessAlertEventData()
                            {
                                InputOutputGroups = clusterData.InputOutputGroups,
                                TimeSchedules = clusterData.TimeSchedules,
                                InputOutputGroupNumber = r.DOORGROUPNUMBER,
                                InputOutputGroupOffsetNumber = r.DOORGROUPOFFSET,
                                AlertEvent = ap.AlertEventDoorGroup,
                                AckScheduleNumber = TimeScheduleNumber.TimeSchedule_Never,
                                Priority = 0,
                                InstructionText = string.Empty,
                                AudioFilename = string.Empty,
                                ResponseRequired = false
                            });


                            ProcessAlertEventData(new ProcessAlertEventData()
                            {
                                InputOutputGroups = clusterData.InputOutputGroups,
                                TimeSchedules = clusterData.TimeSchedules,
                                InputOutputGroupNumber = r.LOCKPART,
                                InputOutputGroupOffsetNumber = 0,
                                AlertEvent = ap.AlertEventLockedBy,
                                AckScheduleNumber = TimeScheduleNumber.TimeSchedule_Never,
                                Priority = 0,
                                InstructionText = string.Empty,
                                AudioFilename = string.Empty,
                                ResponseRequired = false
                            });

                            ProcessAlertEventData(new ProcessAlertEventData()
                            {
                                InputOutputGroups = clusterData.InputOutputGroups,
                                TimeSchedules = clusterData.TimeSchedules,
                                InputOutputGroupNumber = r.UNLOCKPART,
                                InputOutputGroupOffsetNumber = 0,
                                AlertEvent = ap.AlertEventUnlockedBy,
                                AckScheduleNumber = TimeScheduleNumber.TimeSchedule_Never,
                                Priority = 0,
                                InstructionText = string.Empty,
                                AudioFilename = string.Empty,
                                ResponseRequired = false
                            });

                            // Areas
                            var area = clusterData.Areas.FirstOrDefault(o => o.AreaNumber == r.PASSBACKAREANUMBER);
                            if (area != null)
                                ap.PassbackToAreaUid = area.AreaUid;

                            area = clusterData.Areas.FirstOrDefault(o => o.AreaNumber == r.FROMAREANUMBER);
                            if (area != null)
                                ap.PassbackFromAreaUid = area.AreaUid;

                            area = clusterData.Areas.FirstOrDefault(o => o.AreaNumber == r.WHOSINAREANUMBER);
                            if (area != null)
                                ap.WhosInAreaUid = area.AreaUid;

                            // Elevator
                            //ap.Properties.LiquidCrystalDisplayUid = e.LiquidCrystalDisplayUid;
                            //ap.Properties.AccessPortalElevatorControlTypeUid = e.AccessPortalElevatorControlTypeUid;
                            //ap.Properties.OtisElevatorDecUid = e.OtisElevatorDecUid;
                            //ap.Properties.ElevatorRelayInterfaceBoardSectionUid = e.ElevatorRelayInterfaceBoardSectionUid;


                            Globals.BusyContent = $"Saving AccessPortal: {ap.Name}";
                            var savedAccessPortal = await accessPortalMgr.SaveAccessPortalAsync(new GalaxySMSEntities.SaveParameters<GalaxySMSEntities.AccessPortal>() { Data = ap });
                            if (accessPortalMgr.HasErrors)
                            {
                                LogErrors(accessPortalMgr.Errors, false);
                            }
                            else
                            {
                                this.Log().Info($"AccessPortal saved: {savedAccessPortal.Name}, AccessPortalUid: {savedAccessPortal.AccessPortalUid}, HardwareAddress: {savedAccessPortal.ClusterNumber}:{savedAccessPortal.PanelNumber}:{savedAccessPortal.BoardNumber}:{savedAccessPortal.SectionNumber}:{savedAccessPortal.NodeNumber}");
                            }
                        }
                    }
                    obj.HasBeenImported = true;
                }
            }
            catch (Exception e)
            {
                this.Log().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {e.ToString()}");
            }
            Globals.IsBusy = false;
        }

        private void ProcessAlertEventData(ProcessAlertEventData data)
        {
            var iog = data.InputOutputGroups.FirstOrDefault(o => o.IOGroupNumber == data.InputOutputGroupNumber);
            if (iog != null)
            {
                data.AlertEvent.InputOutputGroupUid = iog.InputOutputGroupUid;
                data.AlertEvent.AcknowledgePriority = data.Priority;
                data.AlertEvent.ResponseRequired = false;
                data.AlertEvent.IsActive = true;
                if (!string.IsNullOrEmpty(data.InstructionText))
                    data.AlertEvent.Note.NoteText = data.InstructionText;

                var assignment = iog.InputOutputGroupAssignments.FirstOrDefault(o => o.OffsetIndex == data.InputOutputGroupOffsetNumber);
                if (assignment != null)
                    data.AlertEvent.InputOutputGroupAssignmentUid = assignment.InputOutputGroupAssignmentUid;

                if (data.AckScheduleNumber == GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Never)
                    data.AlertEvent.AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never;
                else if (data.AckScheduleNumber == GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Always)
                    data.AlertEvent.AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always;
                else
                {
                    var sch = data.TimeSchedules.FirstOrDefault(o => o.ClusterScheduleMap.PanelScheduleNumber == data.AckScheduleNumber);
                    if (sch != null)
                    {
                        data.AlertEvent.AcknowledgeTimeScheduleUid = sch.TimeScheduleUid;
                    }
                }
            }

        }
        #endregion
    }
}

//this.GalaxyPanelUid = e.GalaxyPanelUid;
//this.GalaxyPanelModelUid = e.GalaxyPanelModelUid;
//this.Cpus = e.Cpus.ToObservableCollection();
//this.InterfaceBoards = e.InterfaceBoards.ToObservableCollection();
//this.AlertEvents = e.AlertEvents.ToCollection();

//CPU
//this.DefaultEventLoggingOn = e.DefaultEventLoggingOn;
