using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using GalaxySMS.Common.Shared.Enums;
using GalaxySMS.PersonCredential.Properties;
using GalaxySMS.Prism.Infrastructure;
using GalaxySMS.Prism.Infrastructure.Events;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.UI.Core;
using GCS.Framework.CredentialProcessor;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Windows.Controls;
using CommonResources = GalaxySMS.Resources;
using Entities = GalaxySMS.Client.Entities;
using SDK = GalaxySMS.Client.SDK;

namespace GalaxySMS.PersonCredential.ViewModels
{
    [Export(typeof(PersonViewModel))]
    public class PersonViewModel : GCS.Core.Common.UI.Core.ViewModelBase, IPartImportsSatisfiedNotification,
        INavigationAware
    {
        #region Private fields

        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        EditPersonViewModel _CurrentItemViewModel;
        private Entities.PersonSummary _deleteThisPerson = null;
        private CredentialEnroller _credentialEnroller = null;
        private CardWerkManager _cardWerkManager = null;
        private bool _isSearchControlExpanded;
        private KeyValuePair<int, string> _gridPageSize;
        private ObservableCollection<KeyValuePair<int, string>> _gridPageSizes;
        private ObservableCollection<Entities.PersonSearchTypeData> _searchTypes;
        private ObservableCollection<Entities.TextSearchTypeData> _textSearchTypes;
        private ObservableCollection<Entities.AndOrData> _multipleFieldSearchAndOrRelationships;
        private ObservableCollection<GalaxySMS.Client.Entities.PersonSummary> _Persons;
        private Entities.PersonEditingData _personEditingData;
        private Entities.UserInterfacePageControlData _uiPageControlData;
        private bool _IsSearchControlVisible;
        private Entities.PersonSearchData _searchData;
        private bool _bOnViewLoadedAlreadyCalled;
        private ObservableCollection<Entities.DateComparisonType> _dateComparisonTypes;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public PersonViewModel(IEventAggregator eventAggregator, IClientServices clientServices)
        {
            _eventAggregator = eventAggregator;
            _clientServices = clientServices;
            ViewTitle = Properties.Resources.PersonView_ViewTitle;

            _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.Person>>>()
                .Subscribe(EntitySaved, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.Person>>>()
                .Subscribe(OperationCanceled, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>()
                .Subscribe(OnCurrentEntityForSessionChanged, ThreadOption.UIThread);
            //_eventAggregator.GetEvent<PubSubEvent<CurrentSiteForSessionChanged>>()
            //    .Subscribe(CurrentSiteChanged, ThreadOption.UIThread);

            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            EditCommand = new DelegateCommand<Entities.PersonSummary>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<Entities.PersonSummary>(OnDeleteCommand, OnDeleteCommandCanExecute);
            RefreshCommand = new DelegateCommand<object>(OnRefreshCommand, OnRefreshCommandCanExecute);
            SearchCommand = new DelegateCommand<object>(OnSearchCommand, OnSearchCommandCanExecute);

            GridPageSizes = new ObservableCollection<KeyValuePair<int, string>>();

            for (int key = 0; key < 50; key += 10)
            {
                if (key == 0)
                {
                    GridPageSizes.Add(new KeyValuePair<int, string>(key, CommonResources.Resources.PageSize_AllText));
                }
                else
                {
                    GridPageSizes.Add(new KeyValuePair<int, string>(key, key.ToString()));
                }
            }

            foreach (var s in GridPageSizes)
            {
                if (s.Key == 20)
                {
                    GridPageSize = s;
                    break;
                }
            }

            IsAddNewControlVisible = true;
            IsRefreshControlVisible = true;
            IsSearchControlVisible = true;
            IsSearchControlExpanded = false;
        }

        #endregion

        #region Private Methods

        private bool OnSearchCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.PersonnelCanViewId) && SearchData?.SelectedSearchType != null;
        }

        private async void OnSearchCommand(object obj)
        {
            IsBusy = true;
            base.ClearCustomErrors();
            Persons = new ObservableCollection<Client.Entities.PersonSummary>();
            var parameters = new Entities.PersonSummarySearchParameters
            {
                SearchType = SearchData.SelectedSearchType.SearchType,
                IncludeMemberCollections = false,
                IncludePhoto = true,
                PhotoPixelWidth = _clientServices.ThumbnailPixelWidth,
                TextSearchType = SearchData.SelectedTextSearchType.SearchType,
                MultipleFieldSearchRelationship = SearchData.SelectedAndOrOperationType.Operation,
                IncludeScaledPhotos = true,
                OmitPhotoBinaryData = true
            };

            switch (parameters.SearchType)
            {
                case PersonSearchType.AllRecords:
                    break;
                case PersonSearchType.ByPersonUid:
                    parameters.PersonUid = SearchData.SearchGuidValue;
                    break;
                case PersonSearchType.ByPersonId:
                case PersonSearchType.ByOriginId:
                    parameters.GetString = SearchData.SearchStringValue;
                    break;
                case PersonSearchType.ByPersonActiveStatusTypeUid:
                case PersonSearchType.ByDepartmentUid:
                case PersonSearchType.ByPersonRecordTypeUid:
                case PersonSearchType.ByAccessProfileUid:
                    parameters.GetGuid = SearchData.SearchGuidValue;
                    break;
                case PersonSearchType.ByLastFirstName:
                    parameters.FirstName = SearchData.FirstName;
                    parameters.LastName = SearchData.LastName;
                    break;
                case PersonSearchType.ByAnyNameField:
                    parameters.GetString = SearchData.SearchStringValue;
                    break;

                case PersonSearchType.ByFields:
                    parameters.PropertyName = $"{SearchData.SelectedSearchProperty.SchemaName}.{SearchData.SelectedSearchProperty.TableName}.{SearchData.SelectedSearchProperty.ColumnName}";
                    if (SearchData.SelectedSearchProperty.PropertyTypeUid == GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Text)
                    {
                        parameters.GetString = SearchData.SearchStringValue;
                    }
                    else if (SearchData.SelectedSearchProperty.PropertyTypeUid == GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Boolean)
                    {
                        if (SearchData.SearchBoolValue)
                            parameters.GetString = "1";
                        else
                            parameters.GetString = "0";
                    }
                    else if (SearchData.SelectedSearchProperty.PropertyTypeUid == GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Date)
                    {
                        parameters.GetString = SearchData.SearchDateTimeValue.ToSqlDateFormat();
                        parameters.DateComparisonOperator = SearchData.SelectedDateComparisonType.ComparisonOperator;
                    }
                    else if (SearchData.SelectedSearchProperty.PropertyTypeUid == GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number)
                    {
                        parameters.GetString = SearchData.SearchUInt32Value.ToString();
                    }
                    else if (SearchData.SelectedSearchProperty.PropertyTypeUid == GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Guid)
                    {
                        parameters.GetString = SearchData.SearchGuidValue.ToString();
                    }
                    break;
                case PersonSearchType.ByCredentialNumber:
                    break;
                case PersonSearchType.ByCredentialFieldValue:
                    parameters.SearchUInt64Value = SearchData.SearchUInt64Value;
                    break;

                case PersonSearchType.ByCredentialFieldValues:
                    if (SearchData.SearchCredential.CredentialFormat != null)
                    {
                        parameters.SearchCredential = SearchData.SearchCredential;

                        switch (SearchData.SearchCredential.CredentialFormat.CredentialFormatCode)
                        {
                            case CredentialFormatCodes.NumericCardCode:
                            case CredentialFormatCodes.MagneticStripeBarcodeAba:
                            case CredentialFormatCodes.GalaxyKeypad:
                            case CredentialFormatCodes.BasIpQr:
                            case CredentialFormatCodes.BtFarpointeConektMobile:
                            case CredentialFormatCodes.BtHidMobileAccess:
                            case CredentialFormatCodes.BtStidMobileId:
                            case CredentialFormatCodes.BtAllegion:
                            case CredentialFormatCodes.BtBasIp:
                                parameters.SearchCredential.CardNumber = SearchData.SearchCredential.CardNumber;
                                break;

                            case CredentialFormatCodes.Standard26Bit:
                                parameters.SearchCredential.Standard26Bit.FacilityCode =
                                    SearchData.SearchCredential.Standard26Bit.FacilityCode;
                                parameters.SearchCredential.Standard26Bit.IdCode = SearchData.SearchCredential.Standard26Bit.IdCode;
                                break;

                            case CredentialFormatCodes.Corporate1K35Bit:
                                parameters.SearchCredential.Corporate1K35Bit.CompanyCode =
                                    SearchData.SearchCredential.Corporate1K35Bit.CompanyCode;
                                parameters.SearchCredential.Corporate1K35Bit.IdCode =
                                    SearchData.SearchCredential.Corporate1K35Bit.IdCode;
                                break;

                            case CredentialFormatCodes.Corporate1K48Bit:
                                parameters.SearchCredential.Corporate1K48Bit.CompanyCode =
                                    SearchData.SearchCredential.Corporate1K48Bit.CompanyCode;
                                parameters.SearchCredential.Corporate1K48Bit.IdCode =
                                    SearchData.SearchCredential.Corporate1K48Bit.IdCode;
                                break;

                            case CredentialFormatCodes.USGovernmentID:
                                parameters.SearchCredential.CardNumber = SearchData.SearchCredential.CardNumber;
                                break;

                            case CredentialFormatCodes.XceedId40Bit:
                                parameters.SearchCredential.XceedId40Bit.SiteCode = SearchData.SearchCredential.XceedId40Bit.SiteCode;
                                parameters.SearchCredential.XceedId40Bit.IdCode =
                                    SearchData.SearchCredential.XceedId40Bit.IdCode;
                                break;

                            case CredentialFormatCodes.Cypress37Bit:
                                parameters.SearchCredential.Cypress37Bit.FacilityCode =
                                    SearchData.SearchCredential.Cypress37Bit.FacilityCode;
                                parameters.SearchCredential.Cypress37Bit.IdCode =
                                    SearchData.SearchCredential.Cypress37Bit.IdCode;
                                break;

                            case CredentialFormatCodes.H1030437Bit:
                                parameters.SearchCredential.H1030437Bit.FacilityCode =
                                    SearchData.SearchCredential.H1030437Bit.FacilityCode;
                                parameters.SearchCredential.H1030437Bit.IdCode =
                                    SearchData.SearchCredential.H1030437Bit.IdCode;
                                break;

                            case CredentialFormatCodes.H1030237Bit:
                                parameters.SearchCredential.H1030237Bit.IdCode =
                                    SearchData.SearchCredential.H1030237Bit.IdCode;
                                break;

                            case CredentialFormatCodes.PIV75Bit:
                                parameters.SearchCredential.PIV75Bit.AgencyCode = SearchData.SearchCredential.PIV75Bit.AgencyCode;
                                parameters.SearchCredential.PIV75Bit.SiteCode = SearchData.SearchCredential.PIV75Bit.SiteCode;
                                parameters.SearchCredential.PIV75Bit.CredentialCode =
                                    SearchData.SearchCredential.PIV75Bit.CredentialCode;
                                break;

                            case CredentialFormatCodes.SoftwareHouse37Bit:
                                parameters.SearchCredential.SoftwareHouse37Bit.FacilityCode = SearchData.SearchCredential.SoftwareHouse37Bit.FacilityCode;
                                parameters.SearchCredential.SoftwareHouse37Bit.SiteCode = SearchData.SearchCredential.SoftwareHouse37Bit.SiteCode;
                                parameters.SearchCredential.SoftwareHouse37Bit.FacilityCode =
                                    SearchData.SearchCredential.SoftwareHouse37Bit.FacilityCode;
                                break;

                            case CredentialFormatCodes.Bqt36Bit:
                                parameters.SearchCredential.Bqt36Bit.FacilityCode =
                                    SearchData.SearchCredential.Bqt36Bit.FacilityCode;
                                parameters.SearchCredential.Bqt36Bit.IdCode = SearchData.SearchCredential.Bqt36Bit.IdCode;
                                parameters.SearchCredential.Bqt36Bit.IssueCode = SearchData.SearchCredential.Bqt36Bit.IssueCode;
                                break;

                            case CredentialFormatCodes.None:
                                break;
                        }

                    }
                    break;
                case PersonSearchType.ByLastUpdatedDate:
                    parameters.SearchDateTimeValue = SearchData.SearchDateTimeValue;
                    parameters.DateComparisonOperator = SearchData.SelectedDateComparisonType.ComparisonOperator;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var mgr = _clientServices.GetManager<SDK.Managers.PersonManager>();
            var persons = await mgr.SearchAsync(parameters);

            if (mgr.HasErrors)
            {
                base.AddCustomErrors(mgr.Errors, true);
            }
            else
            {
                if (persons != null)
                {
                    try
                    {
                        CollectionExtensions.AddRange(Persons, persons);
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Trace.WriteLine(e.ToString());
                    }
                }
            }

            OnPropertyChanged(() => TotalRecordCount, false);
            IsBusy = false;
        }

        private bool OnRefreshCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.PersonnelCanViewId);
        }

        private async void OnRefreshCommand(object obj)
        {
            await RefreshFromServer();
        }

        private async void OnCurrentEntityForSessionChanged(CurrentEntityForSessionChanged obj)
        {
            await RefreshFromServer();
        }

        //private async void CurrentSiteChanged(CurrentSiteForSessionChanged obj)
        //{
        //    await RefreshFromServer();
        //}

        private void OperationCanceled(OperationCanceledEventArgs<Entities.Person> obj)
        {
            if (CurrentItemViewModel?.InstanceId == obj.OperationId)
                CurrentItemViewModel = null;
        }

        private void EntitySaved(EntitySavedEventArgs<Entities.Person> obj)
        {
            if (Persons == null)
                Persons = new ObservableCollection<Client.Entities.PersonSummary>();
            if (!obj.IsNew)
            {
                var entity = Persons.FirstOrDefault(item => item.PersonUid == obj.Entity.PersonUid);
                entity?.Initialize(obj.Entity);
            }
            else
                Persons.Add(obj.Entity.GetPersonSummary());

            CurrentItemViewModel = null;
        }

        private bool OnEditCommandCanExecute(Entities.PersonSummary obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.PersonnelCanUpdateId) &&
                obj?.EntityId == _clientServices.CurrentEntityId;
            ;
        }

        private async void OnEditCommand(Entities.PersonSummary obj)
        {
            ClearCustomErrors();
            if (obj != null)
            {
                IsBusy = true;
                base.ClearCustomErrors();
                var parameters = new Entities.GetParametersWithPhoto();
                parameters.IncludeMemberCollections = true;
                parameters.IncludePhoto = true;
                parameters.UniqueId = obj.PersonUid;
                //parameters.OmitPhotoBinaryData = true;
                var mgr = _clientServices.GetManager<SDK.Managers.PersonManager>();
                var person = await mgr.GetPersonAsync(parameters);

                if (mgr.HasErrors)
                {
                    base.AddCustomErrors(mgr.Errors, true);
                }
                else
                {
                }

                IsBusy = false;
                CurrentItemViewModel = new EditPersonViewModel(_eventAggregator, _clientServices, person, Guid.Empty,
                    PersonEditingData, UserInterfacePageControlData);
            }
        }

        private bool OnAddNewCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.PersonnelCanUpdateId);
        }

        private void OnAddNewCommand(object obj)
        {
            ClearCustomErrors();
            var o = CreateNewPerson();
            CurrentItemViewModel = new EditPersonViewModel(_eventAggregator, _clientServices, o, Guid.Empty,
                PersonEditingData, UserInterfacePageControlData);
        }

        private Entities.Person CreateNewPerson()
        {
            var o = new Entities.Person
            {
                EntityId = _clientServices.CurrentEntityId
            };
            o.PersonAccessControlProperty.IsActive = true;
            o.PersonAccessControlProperty.AccessProfileUid =
                GalaxySMS.Common.Constants.AccessProfileIds.AccessProfileId_None;
            return o;
        }

        private bool OnDeleteCommandCanExecute(Entities.PersonSummary obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.PersonnelCanDeleteId) &&
                obj?.EntityId == _clientServices.CurrentEntityId;
        }

        //private async void OnDeleteCommand(Entities.Person entity)
        //{
        //    ClearCustomErrors();

        //    var args = new CancelMessageEventArgs(entity.PortalName);
        //    if (ConfirmDelete != null)
        //        ConfirmDelete(this, args);
        //    if (!args.Cancel)
        //    {
        //        var regionManager = _clientServices.GetManager<SDK.Managers.RegionManager>();
        //        var parameters = new Entities.DeleteParameters<Entities.Region>() { Data = entity, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
        //        if (UseAsyncServiceCalls == false)
        //        {
        //            regionManager.DeleteRegion(parameters);
        //            //Globals.Instance.RefreshEntities();
        //        }
        //        else
        //        {
        //            await regionManager.DeleteRegionAsync(parameters);
        //        }
        //        if (regionManager.HasErrors == false)
        //            GalaxySMSRegions.Remove(entity);
        //    }
        //}
        private void OnDeleteCommand(Entities.PersonSummary entity)
        {
            ClearCustomErrors();
            _deleteThisPerson = entity;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainPersons_AreYouSureDeletePerson,
                _deleteThisPerson);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainPersons_YesDeletePerson,
                _deleteThisPerson);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainPersons_NoDeletePerson,
                _deleteThisPerson);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                int numberDeleted = 0;
                var personManager = _clientServices.GetManager<SDK.Managers.PersonManager>();
                //var parameters = new Entities.DeleteParameters<Entities.Person>() { Data = _deleteThisPerson, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
                //if (UseAsyncServiceCalls == false)
                //{
                //    numberDeleted = PersonManager.DeletePerson(parameters);
                //    numberDeleted = PersonManager.DeletePersonByUniqueId();
                //}
                //else
                //{
                //    //await Task.Run(() => regionManager.DeleteRegion(parameters));
                //    numberDeleted = await PersonManager.DeletePersonAsync(parameters);
                //}
                var parameters = new Entities.DeleteParameters()
                {
                    UniqueId = _deleteThisPerson.PersonUid,
                    SessionId = _clientServices.UserSessionToken.SessionId,
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                };
                if (UseAsyncServiceCalls == false)
                {
                    numberDeleted = personManager.DeletePersonByUniqueId(parameters);
                }
                else
                {
                    numberDeleted = await personManager.DeletePersonByUniqueIdAsync(parameters);
                }

                if (personManager.HasErrors == false)
                {
                    var p = Persons.FirstOrDefault(o => o.PersonUid == _deleteThisPerson.PersonUid);
                    if (p != null)
                        Persons.Remove(p);
                }
            }
            else
                _deleteThisPerson = null;
        }

        #endregion

        #region Public Properties

        public EditPersonViewModel CurrentItemViewModel
        {
            get { return _CurrentItemViewModel; }
            set
            {
                if (_CurrentItemViewModel != value)
                {
                    _CurrentItemViewModel = value;
                    OnPropertyChanged(() => CurrentItemViewModel, false);
                }
            }
        }


        public ObservableCollection<GalaxySMS.Client.Entities.PersonSummary> Persons
        {
            get { return _Persons; }
            set
            {
                if (_Persons != value)
                {
                    _Persons = value;
                    OnPropertyChanged(() => Persons, false);
                }
            }
        }


        public Entities.PersonEditingData PersonEditingData
        {
            get { return _personEditingData; }
            set
            {
                if (_personEditingData != value)
                {
                    _personEditingData = value;
                    OnPropertyChanged(() => PersonEditingData, false);
                }
            }
        }



        public Entities.UserInterfacePageControlData UserInterfacePageControlData
        {
            get { return _uiPageControlData; }
            set
            {
                if (_uiPageControlData != value)
                {
                    _uiPageControlData = value;
                    OnPropertyChanged(() => UserInterfacePageControlData, false);
                }
            }
        }


        public ObservableCollection<Entities.PersonSearchTypeData> SearchTypes
        {
            get { return _searchTypes; }
            set
            {
                if (_searchTypes != value)
                {
                    _searchTypes = value;
                    OnPropertyChanged(() => SearchTypes, false);
                }
            }
        }


        public ObservableCollection<Entities.DateComparisonType> DateComparisonTypes
        {
            get { return _dateComparisonTypes; }
            set
            {
                if (_dateComparisonTypes != value)
                {
                    _dateComparisonTypes = value;
                    OnPropertyChanged(() => DateComparisonTypes, false);
                }
            }
        }

        public ObservableCollection<Entities.TextSearchTypeData> TextSearchTypes
        {
            get { return _textSearchTypes; }
            set
            {
                if (_textSearchTypes != value)
                {
                    _textSearchTypes = value;
                    OnPropertyChanged(() => TextSearchTypes, false);
                }
            }
        }

        public ObservableCollection<Entities.AndOrData> MultipleFieldSearchAndOrRelationships
        {
            get { return _multipleFieldSearchAndOrRelationships; }
            set
            {
                if (_multipleFieldSearchAndOrRelationships != value)
                {
                    _multipleFieldSearchAndOrRelationships = value;
                    OnPropertyChanged(() => MultipleFieldSearchAndOrRelationships, false);
                }
            }
        }

        //public ObservableCollection<Entities.UserDefinedProperty> PersonSearchProperties
        //{
        //    get { return _personSearchProperties; }
        //    set
        //    {
        //        if (_personSearchProperties != value)
        //        {
        //            _personSearchProperties = value;
        //            OnPropertyChanged(() => PersonSearchProperties, false);
        //        }
        //    }
        //}

        public Entities.PersonSearchData SearchData
        {
            get { return _searchData; }
            set
            {
                if (_searchData != value)
                {
                    _searchData = value;
                    OnPropertyChanged(() => SearchData, false);
                }
            }
        }


        public bool IsSearchControlVisible
        {
            get { return _IsSearchControlVisible; }
            set
            {
                if (_IsSearchControlVisible != value)
                {
                    _IsSearchControlVisible = value;
                    OnPropertyChanged(() => IsSearchControlVisible, false);
                }
            }
        }


        public bool IsSearchControlExpanded
        {
            get { return _isSearchControlExpanded; }
            set
            {
                if (_isSearchControlExpanded != value)
                {
                    _isSearchControlExpanded = value;
                    OnPropertyChanged(() => IsSearchControlExpanded, false);
                }
            }
        }

        public KeyValuePair<int, string> GridPageSize
        {
            get { return _gridPageSize; }
            set
            {
                _gridPageSize = value;
                OnPropertyChanged(() => GridPageSize, false);
            }
        }

        public ObservableCollection<KeyValuePair<int, string>> GridPageSizes
        {
            get { return _gridPageSizes; }
            set
            {
                if (_gridPageSizes != value)
                {
                    _gridPageSizes = value;
                    OnPropertyChanged(() => GridPageSizes, false);
                }
            }
        }

        public int TotalRecordCount
        {
            get
            {
                if (Persons == null)
                    return 0;
                return Persons.Count;
            }
            set { OnPropertyChanged(() => TotalRecordCount, false); }
        }

        #endregion

        #region Public Events

        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccured;

        #endregion

        #region Public Commands

        public DelegateCommand<Entities.PersonSummary> EditCommand { get; private set; }
        public DelegateCommand<Entities.PersonSummary> DeleteCommand { get; private set; }
        public DelegateCommand<object> AddNewCommand { get; private set; }
        public DelegateCommand<object> RefreshCommand { get; private set; }
        public DelegateCommand<object> SearchCommand { get; private set; }

        #endregion

        #region Protected Methods

        protected override void OnViewLoaded()
        {
            if (_bOnViewLoadedAlreadyCalled == false)
            {
                _bOnViewLoadedAlreadyCalled = true;

                //Task.Run(async () => { await RefreshFromServer(); }).Wait();
                RefreshFromServer();

                if (Settings.Default.EnrollmentReaderEnabled &&
                    !string.IsNullOrEmpty(Settings.Default.EnrollmentReaderCommPort))
                {
                    _credentialEnroller = new CredentialEnroller();
                    _credentialEnroller.CredentialDataReceived += _credentialEnroller_CredentialDataReceived;
                    _credentialEnroller.Open(Settings.Default.EnrollmentReaderCommPort);
                }

                if (Settings.Default.CardWerkEnrollmentEnabled)
                {
                    _cardWerkManager = new CardWerkManager();
                    _cardWerkManager.ExpectedICLASSDataFormat =
                        EnumExtensions.GetOne<CredentialFormatCodes>(Settings.Default.CardWerkiClassDataFormat);
                    _cardWerkManager.CredentialDataReceived += _cardWerkManager_CredentialDataReceived;
                }
            }
        }

        private async void _credentialEnroller_CredentialDataReceived(object sender, CredentialDataEventArgs e)
        {
            await ProcessCredentialDataEventArgs(e);
        }

        private async Task ProcessCredentialDataEventArgs(CredentialDataEventArgs e)
        {
            // Send to Current Person Editor if one exists
            if (CurrentItemViewModel != null)
                CurrentItemViewModel?.ProcessCredentialDataEventArgs(e);
            else
            {   // Otherwise, send to Search Fields
                UpdateSearchFieldsFromCredentialDataEventArgs(e);
            }
        }

        private void UpdateSearchFieldsFromCredentialDataEventArgs(CredentialDataEventArgs e)
        {
            switch (SearchData?.SelectedSearchType.SearchType)
            {
                case PersonSearchType.ByCredentialFieldValues:
                case PersonSearchType.ByCredentialNumber:
                    break;

                default:
                    return;

            }
            var df = EnumExtensions.GetOne<CredentialFormatCodes>(e.Data.DataFormat);

            var f = PersonEditingData?.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == df);
            if (f == null)
                return;

            SearchData.SearchCredential.CredentialFormatUid = f.CredentialFormatUid;
            SearchData.SearchCredential.CredentialFormat = f;

            if (SearchData.SearchCredential.CredentialFormat != null)
            {
                switch (SearchData.SearchCredential.CredentialFormat.CredentialFormatCode)
                {
                    case CredentialFormatCodes.NumericCardCode:
                    case CredentialFormatCodes.MagneticStripeBarcodeAba:
                    case CredentialFormatCodes.GalaxyKeypad:
                    case CredentialFormatCodes.BasIpQr:
                    case CredentialFormatCodes.BtFarpointeConektMobile:
                    case CredentialFormatCodes.BtHidMobileAccess:
                    case CredentialFormatCodes.BtStidMobileId:
                    case CredentialFormatCodes.BtAllegion:
                    case CredentialFormatCodes.BtBasIp:
                        SearchData.SearchCredential.CardNumber = e.Data.FullCardCode;
                        break;

                    case CredentialFormatCodes.Standard26Bit:
                        SearchData.SearchCredential.CardNumber = e.Data.Wiegand26Data.FCC;
                        SearchData.SearchCredential.Standard26Bit.FacilityCode =
                            (short)e.Data.Wiegand26Data.FacilityCode;
                        SearchData.SearchCredential.Standard26Bit.IdCode = e.Data.Wiegand26Data.IDCode;
                        break;

                    case CredentialFormatCodes.Corporate1K35Bit:
                        SearchData.SearchCredential.CardNumber = e.Data.Wiegand35HIDCorporate1000Data.FCC;
                        SearchData.SearchCredential.Corporate1K35Bit.CompanyCode =
                            (int)e.Data.Wiegand35HIDCorporate1000Data.CompanyCode;
                        SearchData.SearchCredential.Corporate1K35Bit.IdCode =
                            (int)e.Data.Wiegand35HIDCorporate1000Data.IDCode;
                        break;

                    case CredentialFormatCodes.Corporate1K48Bit:
                        SearchData.SearchCredential.CardNumber = e.Data.Wiegand48HIDCorporate1000Data.FCC;
                        SearchData.SearchCredential.Corporate1K48Bit.CompanyCode =
                            (int)e.Data.Wiegand48HIDCorporate1000Data.CompanyCode;
                        SearchData.SearchCredential.Corporate1K48Bit.IdCode =
                            (int)e.Data.Wiegand48HIDCorporate1000Data.IDCode;
                        break;

                    case CredentialFormatCodes.USGovernmentID:
                        SearchData.SearchCredential.CardNumber = e.Data.RawData;
                        break;

                    case CredentialFormatCodes.XceedId40Bit:
                        SearchData.SearchCredential.CardNumber = e.Data.XceedId40BitData.FCC;
                        SearchData.SearchCredential.XceedId40Bit.SiteCode = e.Data.XceedId40BitData.SiteCode;
                        SearchData.SearchCredential.XceedId40Bit.IdCode =
                            (int)e.Data.XceedId40BitData.IDCode;
                        break;

                    case CredentialFormatCodes.Cypress37Bit:
                        SearchData.SearchCredential.CardNumber = e.Data.Cypress37BitData.FCC;
                        SearchData.SearchCredential.Cypress37Bit.FacilityCode =
                            e.Data.Cypress37BitData.FacilityCode;
                        SearchData.SearchCredential.Cypress37Bit.IdCode =
                            (int)e.Data.Cypress37BitData.IDCode;
                        break;

                    case CredentialFormatCodes.H1030437Bit:
                        SearchData.SearchCredential.CardNumber = e.Data.HIDH1030437BitData.FCC;
                        SearchData.SearchCredential.H1030437Bit.FacilityCode =
                            (int)e.Data.HIDH1030437BitData.FacilityCode;
                        SearchData.SearchCredential.H1030437Bit.IdCode =
                            (int)e.Data.HIDH1030437BitData.IDCode;
                        break;

                    case CredentialFormatCodes.H1030237Bit:
                        SearchData.SearchCredential.CardNumber = e.Data.HIDH1030237BitData.FCC;
                        SearchData.SearchCredential.H1030237Bit.IdCode = e.Data.HIDH1030237BitData.IdCode;
                        break;

                    case CredentialFormatCodes.SoftwareHouse37Bit:
                        SearchData.SearchCredential.CardNumber = e.Data.SoftwareHouse37BitData.FCC;
                        SearchData.SearchCredential.SoftwareHouse37Bit.FacilityCode =
                            e.Data.SoftwareHouse37BitData.FacilityCode;
                        SearchData.SearchCredential.SoftwareHouse37Bit.SiteCode =
                            e.Data.SoftwareHouse37BitData.SiteCode;
                        SearchData.SearchCredential.SoftwareHouse37Bit.IdCode =
                            e.Data.SoftwareHouse37BitData.IdCode;
                        break;

                    case CredentialFormatCodes.PIV75Bit:
                        SearchData.SearchCredential.CardNumber = e.Data.PIV75Data.FCC;
                        SearchData.SearchCredential.PIV75Bit.AgencyCode = (int)e.Data.PIV75Data.AgencyCode;
                        SearchData.SearchCredential.PIV75Bit.SiteCode = (int)e.Data.PIV75Data.SiteCode;
                        SearchData.SearchCredential.PIV75Bit.CredentialCode =
                            (int)e.Data.PIV75Data.Credential;
                        break;

                    case CredentialFormatCodes.Bqt36Bit:
                        SearchData.SearchCredential.CardNumber = e.Data.BQT36Data.FCC;
                        SearchData.SearchCredential.Bqt36Bit.FacilityCode =
                            (short)e.Data.BQT36Data.FacilityCode;
                        SearchData.SearchCredential.Bqt36Bit.IdCode = (int)e.Data.BQT36Data.IDCode;
                        SearchData.SearchCredential.Bqt36Bit.IssueCode = (short)e.Data.BQT36Data.IssueNumber;
                        break;

                    case CredentialFormatCodes.None:
                        break;
                }
            }
        }
        private async void _cardWerkManager_CredentialDataReceived(object sender, CredentialDataEventArgs e)
        {
            await ProcessCredentialDataEventArgs(e);
        }

        private async Task RefreshFromServer()
        {
            IsBusy = true;
            base.ClearCustomErrors();

            await FillPersonEditorData();
            await FillUserInterfacePageControlData();
            IsSearchControlExpanded = true;
            IsBusy = false;
        }

        private async Task FillPersonEditorData()
        {
            var manager = _clientServices.GetManager<PersonManager>();
            var parameters = new Entities.GetParametersWithPhoto()
            {
                //SessionId = _clientServices.UserSessionToken.SessionId,
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId,
                IncludePhoto = true,
                PhotoPixelWidth = _clientServices.ThumbnailPixelWidth,
            };
            parameters.ExcludeMemberCollectionSettings.Add(nameof(ClusterSelectionItemBasic.InputDevices));
            parameters.ExcludeMemberCollectionSettings.Add(nameof(ClusterSelectionItemBasic.OutputDevices));
            if (UseAsyncServiceCalls == false)
            {
                Task.Run(() => { PersonEditingData = manager.GetPersonEditingData(parameters); }).Wait();
            }
            else
            {
                PersonEditingData = await manager.GetPersonEditingDataAsync(parameters);
            }

            if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
        }

        private async Task FillUserInterfacePageControlData()
        {
            var manager = _clientServices.GetManager<PersonManager>();
            var parameters = new Entities.GetParametersWithPhoto()
            {
                //SessionId = _clientServices.UserSessionToken.SessionId,
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId,
                IncludeMemberCollections = true
            };
            if (UseAsyncServiceCalls == false)
            {
                Task.Run(() =>
                {
                    UserInterfacePageControlData = manager.GetPersonUserInterfacePageControlData(parameters);
                }).Wait();
            }
            else
            {
                UserInterfacePageControlData = await manager.GetPersonUserInterfacePageControlDataAsync(parameters);
            }

            if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
            else
            {
                CreateSearchTypes();
            }
        }

        private void CreateSearchTypes()
        {
            SearchData = new Entities.PersonSearchData();

            //SearchByProperties = new ObservableCollection<Entities.UserDefinedProperty>();
            SearchTypes = new ObservableCollection<Entities.PersonSearchTypeData>();

            foreach (var searchtype in Enum.GetValues(typeof(PersonSearchType)))
            {
                if ((PersonSearchType)searchtype == PersonSearchType.ByCredentialNumber)
                    continue;

                var pstd = new Entities.PersonSearchTypeData()
                {
                    SearchType = (PersonSearchType)searchtype,
                };

                Entities.UserDefinedProperty udf = null;
                switch (pstd.SearchType)
                {
                    case PersonSearchType.AllRecords:
                        pstd.Title = GalaxySMS.Resources.Resources.PersonSearchType_AllRecords_Title;
                        pstd.ToolTip = GalaxySMS.Resources.Resources.PersonSearchType_AllRecords_ToolTip;
                        break;

                    case PersonSearchType.ByPersonUid:
                        pstd.Title = GalaxySMS.Resources.Resources.PersonSearchType_ByPersonUid_Title;
                        pstd.ToolTip = GalaxySMS.Resources.Resources.PersonSearchType_ByPersonUid_ToolTip;
                        break;

                    case PersonSearchType.ByPersonId:
                        udf = UserInterfacePageControlData.ControlProperties.FirstOrDefault(o => o.ColumnName == "PersonId" && o.TableName == "Person");
                        if (udf != null)
                        {
                            pstd.Title = udf.Display;
                            pstd.ToolTip = udf.Description;
                        }
                        pstd.ToolTip = GalaxySMS.Resources.Resources.PersonSearchType_ByPersonId_ToolTip;
                        break;

                    case PersonSearchType.ByPersonActiveStatusTypeUid:
                        udf = UserInterfacePageControlData.ControlProperties.FirstOrDefault(o => o.ColumnName == "PersonActiveStatusTypeUid" && o.TableName == "Person");
                        if (udf != null)
                        {
                            pstd.Title = udf.Display;
                            pstd.ToolTip = udf.Description;
                        }
                        pstd.ToolTip = GalaxySMS.Resources.Resources.PersonSearchType_PersonActiveStatusTypeUid_ToolTip;
                        break;

                    case PersonSearchType.ByDepartmentUid:
                        udf = UserInterfacePageControlData.ControlProperties.FirstOrDefault(o => o.ColumnName == "DepartmentUid" && o.TableName == "Person");
                        if (udf != null)
                        {
                            pstd.Title = udf.Display;
                            pstd.ToolTip = udf.Description;
                        }
                        pstd.ToolTip = GalaxySMS.Resources.Resources.PersonSearchType_DepartmentUid_ToolTip;
                        break;

                    case PersonSearchType.ByPersonRecordTypeUid:
                        udf = UserInterfacePageControlData.ControlProperties.FirstOrDefault(o => o.ColumnName == "PersonRecordTypeUid" && o.TableName == "Person");
                        if (udf != null)
                        {
                            pstd.Title = udf.Display;
                            pstd.ToolTip = udf.Description;
                        }
                        pstd.ToolTip = GalaxySMS.Resources.Resources.PersonSearchType_ByPersonRecordTypeUid_ToolTip;
                        break;
                    case PersonSearchType.ByLastFirstName:
                        pstd.Title = GalaxySMS.Resources.Resources.PersonSearchType_ByFirstAndLastName_Title;
                        pstd.ToolTip = GalaxySMS.Resources.Resources.PersonSearchType_ByFirstAndLastName_ToolTip;
                        break;
                    case PersonSearchType.ByAnyNameField:
                        pstd.Title = GalaxySMS.Resources.Resources.PersonSearchType_ByAnyNameField_Title;
                        pstd.ToolTip = GalaxySMS.Resources.Resources.PersonSearchType_ByAnyNameField_ToolTip;
                        break;

                    case PersonSearchType.ByFields:
                        pstd.Title = GalaxySMS.Resources.Resources.PersonSearchType_ByFields_Title;
                        pstd.ToolTip = GalaxySMS.Resources.Resources.PersonSearchType_ByFields_ToolTip;
                        break;
                    case PersonSearchType.ByCredentialNumber:
                        pstd.Title = GalaxySMS.Resources.Resources.PersonSearchType_ByCredentialNumber_Title;
                        pstd.ToolTip = GalaxySMS.Resources.Resources.PersonSearchType_ByCredentialNumber_ToolTip;
                        break;
                    case PersonSearchType.ByCredentialFieldValues:
                        pstd.Title = GalaxySMS.Resources.Resources.PersonSearchType_ByCredentialFieldValues_Title;
                        pstd.ToolTip = GalaxySMS.Resources.Resources.PersonSearchType_ByCredentialFieldValues_ToolTip;
                        break;
                    case PersonSearchType.ByCredentialFieldValue:
                        pstd.Title = GalaxySMS.Resources.Resources.PersonSearchType_ByCredentialFieldValue_Title;
                        pstd.ToolTip = GalaxySMS.Resources.Resources.PersonSearchType_ByCredentialFieldValue_ToolTip;
                        break;

                    case PersonSearchType.ByOriginId:
                        udf = UserInterfacePageControlData.ControlProperties.FirstOrDefault(o => o.ColumnName == "OriginId" && o.TableName == "Person");
                        if (udf != null)
                        {
                            pstd.Title = udf.Display;
                            pstd.ToolTip = udf.Description;
                        }
                        pstd.ToolTip = GalaxySMS.Resources.Resources.PersonSearchType_ByOriginId_ToolTip;
                        break;
                    case PersonSearchType.ByLastUpdatedDate:
                        pstd.Title = GalaxySMS.Resources.Resources.PersonSearchType_ByLastUpdatedDate_Title;
                        pstd.ToolTip = GalaxySMS.Resources.Resources.PersonSearchType_ByLastUpdatedDate_ToolTip;
                        break;

                    case PersonSearchType.ByAccessProfileUid:
                        udf = UserInterfacePageControlData.ControlProperties.FirstOrDefault(o => o.ColumnName == "AccessProfileUid" && o.TableName == "PersonAccessControlProperties");
                        pstd.Title = GalaxySMS.Resources.Resources.PersonSearchType_AllRecords_Title;
                        if (udf != null)
                        {
                            pstd.Title = udf.Display;
                            pstd.ToolTip = udf.Description;
                        }
                        pstd.ToolTip = GalaxySMS.Resources.Resources.PersonSearchType_ByAccessProfile_ToolTip;
                        break;

                    case PersonSearchType.AdvancedSearch:
                        continue;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                SearchTypes.Add(pstd);
            }

            //
            //SearchCredentialDataParts = new CredentialDataParts();
            //SearchFieldsKeyNameValues = new ObservableCollection<FieldNameValuePair>();
            SearchData.PersonSearchProperties = UserInterfacePageControlData.ControlProperties.Where(p => p.TableName == "Person" || p.TableName == "PersonCredential" || p.TableName == "PersonAccessControlProperties").OrderBy(p => p.Display).ToObservableCollection();

            var propertiesToRemove = new List<string>();
            propertiesToRemove.Add("ConcurrencyValue");
            propertiesToRemove.Add("EntityId");
            propertiesToRemove.Add("InsertName");
            propertiesToRemove.Add("UpdateName");

            foreach (var s in propertiesToRemove)
            {
                var p = SearchData.PersonSearchProperties.FirstOrDefault(o => o.PropertyName == s);
                if (p != null)
                    SearchData.PersonSearchProperties.Remove(p);
            }

            DateComparisonTypes = new ObservableCollection<Entities.DateComparisonType>();

            DateComparisonTypes.Add(new Entities.DateComparisonType() { Display = GalaxySMS.Resources.Resources.PersonView_SearchByDate_ComparisonType_Equal_Title, ComparisonOperator = ComparisonOperatorsSql.Equals });
            DateComparisonTypes.Add(new Entities.DateComparisonType() { Display = GalaxySMS.Resources.Resources.PersonView_SearchByDate_ComparisonType_GreaterThanOrEqual_Title, ComparisonOperator = ComparisonOperatorsSql.GreaterOrEqual });
            DateComparisonTypes.Add(new Entities.DateComparisonType() { Display = GalaxySMS.Resources.Resources.PersonView_SearchByDate_ComparisonType_GreaterThan_Title, ComparisonOperator = ComparisonOperatorsSql.Greater });
            DateComparisonTypes.Add(new Entities.DateComparisonType() { Display = GalaxySMS.Resources.Resources.PersonView_SearchByDate_ComparisonType_LessThan_Title, ComparisonOperator = ComparisonOperatorsSql.Less });
            DateComparisonTypes.Add(new Entities.DateComparisonType() { Display = GalaxySMS.Resources.Resources.PersonView_SearchByDate_ComparisonType_LessThanOrEqual_Title, ComparisonOperator = ComparisonOperatorsSql.LessOrEqual });
            DateComparisonTypes.Add(new Entities.DateComparisonType() { Display = GalaxySMS.Resources.Resources.PersonView_SearchByDate_ComparisonType_NotEqual_Title, ComparisonOperator = ComparisonOperatorsSql.NotEquals });

            SearchData.SelectedSearchType = SearchTypes.FirstOrDefault(o => o.SearchType == PersonSearchType.ByLastFirstName);
            SearchData.SelectedSearchProperty = SearchData.PersonSearchProperties.FirstOrDefault(o => o.PropertyName == PersonStandardPropertyNames.PersonId.ToString());
            SearchData.SelectedDateComparisonType = DateComparisonTypes.FirstOrDefault(o => o.ComparisonOperator == ComparisonOperatorsSql.GreaterOrEqual);
            var cf = PersonEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.Standard26Bit);
            if (cf != null)
                SearchData.SearchCredential.CredentialFormatUid = PersonEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.Standard26Bit).CredentialFormatUid;

            TextSearchTypes = new ObservableCollection<Entities.TextSearchTypeData>();
            TextSearchTypes.Add(new Entities.TextSearchTypeData()
            {
                SearchType = TextSearchType.Equals,
                Title = GalaxySMS.Resources.Resources.PersonView_TextSearchType_Equals_Title,
                ToolTip = GalaxySMS.Resources.Resources.PersonView_TextSearchType_Equals_ToolTip
            });
            TextSearchTypes.Add(new Entities.TextSearchTypeData()
            {
                SearchType = TextSearchType.StartsWith,
                Title = GalaxySMS.Resources.Resources.PersonView_TextSearchType_StartsWith_Title,
                ToolTip = GalaxySMS.Resources.Resources.PersonView_TextSearchType_StartsWith_ToolTip
            });
            TextSearchTypes.Add(new Entities.TextSearchTypeData()
            {
                SearchType = TextSearchType.Contains,
                Title = GalaxySMS.Resources.Resources.PersonView_TextSearchType_Contains_Title,
                ToolTip = GalaxySMS.Resources.Resources.PersonView_TextSearchType_Contains_ToolTip
            });

            SearchData.SelectedTextSearchType = TextSearchTypes.FirstOrDefault(o => o.SearchType == TextSearchType.StartsWith);

            MultipleFieldSearchAndOrRelationships = new ObservableCollection<Entities.AndOrData>();
            MultipleFieldSearchAndOrRelationships.Add(new Entities.AndOrData() { Operation = AndOr.AND, Title = AndOr.AND.ToString() });
            MultipleFieldSearchAndOrRelationships.Add(new Entities.AndOrData() { Operation = AndOr.OR, Title = AndOr.OR.ToString() });
            SearchData.SelectedAndOrOperationType = MultipleFieldSearchAndOrRelationships.FirstOrDefault(o => o.Operation == AndOr.AND);
        }

        #endregion

        #region IPartImportsSatisfiedNotification Implementation

        public void OnImportsSatisfied()
        {
        }

        #endregion

        #region INavigationAware Implementation

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #endregion
    }
}