using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using GalaxySMS.Client.Contracts.ViewModelContracts;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Prism.Infrastructure;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI.Core;
using GCS.Core.Common.UI.Interfaces;
using GCS.Framework.Geography;
using GCS.Framework.Geography.DataClasses;
using GCS.Framework.Imaging;
using Prism.Events;
using Entities = GalaxySMS.Client.Entities;
using CommonResources = GalaxySMS.Resources;

namespace GalaxySMS.Site.ViewModels
{
    [Export(typeof(EditSiteViewModel))]
    public class EditSiteViewModel : ViewModelBase, IAddressViewModel, ISupportsUserEntitySelection
    {
        #region Private Fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        private Entities.Site _Site;
        private Region _selectedRegion;
        private ReadOnlyCollection<Region> _regions;
        private bool _isBasicInfoExpanded = true;

        #endregion

        #region Constructors
        [ImportingConstructor]
        public EditSiteViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.Site entity, Guid instanceId)
        {
            if (instanceId == Guid.Empty)
                InstanceId = Guid.NewGuid();
            else
                InstanceId = instanceId;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            _Site = new Entities.Site(entity);
            _Site.CleanAll();

            FillRegions();
            FillCountries();

            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);
            SelectImageCommand = new DelegateCommand<object>(OnSelectImageCommandExecute);
            LookupZipCodeCommand = new DelegateCommand<string>(OnLookupZipCodeCommandExecute, CanLookupZipCodeCommand);
            EntityMapChecked = new DelegateCommand<UserEntitySelect>(OnEntityMapChecked);

            IsSaveControlVisible = true;
            IsCancelControlVisible = true;

            BusyContent = CommonResources.Resources.Common_PleaseWait;
            ViewTitle = CommonResources.Resources.EditSiteView_ViewTitle;
            CurrentItemTitle = _Site.Name;

            UserEntitiesSelectionList = _clientServices.BuildUserEntitiesSelectionList(_Site, _Site.EntityId);

            ////           CanPingGeoNames = false;
            //if (UserSessionToken != null)
            //{
            //    UserEntitiesSelectionList = UserSessionToken.GetUserEntitySelectCollection();
            //    foreach (var ue in UserEntitiesSelectionList)
            //    {
            //        if (_Site.EntityIds.Contains(ue.EntityId))
            //            ue.Selected = true;
            //    }
            //}
        }

        //private bool _canPinGeoNames;

        //public bool CanPingGeoNames
        //{
        //    get { return _canPinGeoNames; }
        //    set
        //    {
        //        if (_canPinGeoNames != value)
        //        {
        //            _canPinGeoNames = value;
        //            OnPropertyChanged(() => CanPingGeoNames, false);
        //        }
        //    }
        //}


        private bool CanLookupZipCodeCommand(string obj)
        {
            if (SelectedCountry == null)
                return false;
            return !string.IsNullOrEmpty(Site?.Address?.PostalCode);
        }

        private async void OnLookupZipCodeCommandExecute(string obj)
        {
            BusyContent = string.Format(CommonResources.Resources.ZipCodeSearch_PleaseWaitSearching, Site?.Address?.PostalCode,
                SelectedCountry?.CountryName);
            IsBusy = true;
            ClearCustomErrors();
            var geoController = new GeoNamesClient();
            var parameters = new LookupPostalCodeParameters();
            if (SelectedCountry != null)
            {
                parameters.CountryCode = SelectedCountry.Iso3;
                parameters.PostalCode = Site?.Address?.PostalCode;
                var result = await geoController.LookupPostalCode(parameters);
                if (result != null && result.PostalCodes.Count > 0)
                {
                    var data = result.PostalCodes[0];
                    SelectedCountry = (from c in Countries where c.CountryIso == data.CountryCode select c).FirstOrDefault();

                    if (SelectedCountry != null)
                    {
                        SelectedStateProvince =
                            (from sp in StatesProvinces where sp.StateProvinceCode == data.AdminCode1 select sp)
                                .FirstOrDefault();
                    }
                    Address.City = result.PostalCodes[0].PlaceName;
                    Address.Latitude = result.PostalCodes[0].Lat;
                    Address.Longitude = result.PostalCodes[0].Lng;
                }
                else
                {
                    AddCustomError(new CustomError(string.Format(CommonResources.Resources.ZipCodeSearch_NotFound, Site?.Address?.PostalCode,
                        SelectedCountry?.CountryName)));
                }
            }
            IsBusy = false;
        }

        private void FillRegions()
        {
            IsBusy = true;
            Task.Run(() => { Regions = _clientServices.GetRegions(); }).Wait();
            IsBusy = false;
        }

        private void FillCountries()
        {
            IsBusy = true;
            //          CanPingGeoNames = false;
            //Task.Run(async () =>
            //{

            //    var geoController = new GeoNamesClient();
            //    var pingReply = await geoController.Ping();
            //    if (pingReply.Status == IPStatus.Success)
            //    {
            //        CanPingGeoNames = true;
            //    }
            //}).Wait();

            Task.Run(() => { Countries = _clientServices.GetCountries(false); }).Wait();
            if (Address?.StateProvince?.CountryUid != Guid.Empty)
                SelectedCountry = (from c in Countries where c.CountryUid == Address.StateProvince.CountryUid select c).FirstOrDefault();
            IsBusy = false;
        }

        private async Task FillStatesProvinces()
        {
            IsBusy = true;
            StatesProvinces = await _clientServices.GetStatesProvincesForCountryAsync(SelectedCountry);
            IsBusy = false;
        }
        #endregion

        #region Public Commands
        public DelegateCommand<object> SaveCommand { get; private set; }

        public DelegateCommand<object> CancelCommand { get; private set; }

        public DelegateCommand<object> SelectImageCommand { get; private set; }
        public DelegateCommand<string> LookupZipCodeCommand { get; set; }
        public DelegateCommand<UserEntitySelect> EntityMapChecked { get; set; }
        #endregion

        #region Public Properties
        public Entities.Site Site
        {
            get { return _Site; }
            set
            {
                if (_Site != value)
                {
                    _Site = value;
                    OnPropertyChanged(() => Site, false);
                }
            }
        }

        public ReadOnlyCollection<Entities.Region> Regions
        {
            get { return _regions; }
            set
            {
                if (_regions != value)
                {
                    _regions = value;
                    OnPropertyChanged(() => Regions, false);
                }
            }
        }

        public Entities.Region SelectedRegion
        {
            get { return _selectedRegion; }
            set {
                if (_selectedRegion != value)
                {
                    _selectedRegion = value;
                    OnPropertyChanged(() => SelectedRegion, true);
                    //Site.RegionUid = _selectedRegion.RegionUid;
                }
            }
        }

        public Guid InstanceId { get; }

        public bool IsBasicInfoExpanded
        {
            get { return _isBasicInfoExpanded; }
            set
            {
                if (_isBasicInfoExpanded != value)
                {
                    _isBasicInfoExpanded = value;
                    OnPropertyChanged(() => IsBasicInfoExpanded, false);
                }
            }
        }

        #endregion

        #region Protected Methods
        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(Site);
            models.Add(Site.Address);
        }
        #endregion

        #region Private Methods

        private async void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                BusyContent = string.Format(CommonResources.Resources.EditSiteView_PleaseWaitWhileISave, Site.SiteName);

                Site.EntityIds.Clear();
                Site.MappedEntitiesPermissionLevels.Clear();

                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (ue.Selected || ue.EntityId == Site.Region.EntityId || ue.EntityId == Site.EntityId)
                    {
                        Site.EntityIds.Add(ue.EntityId);
                    }
                }

                IsBusy = true;
                var manager = _clientServices.GetManager<SiteManager>();
                bool isNew = (Site.SiteUid == Guid.Empty);
                Entities.Site savedEntity;
                var parameters = new SaveParameters<Entities.Site>() { SavePhoto = true, Data = Site, 
                    //SessionId = _clientServices.UserSessionToken.SessionId, 
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
                if (UseAsyncServiceCalls == false)
                {
                    savedEntity = manager.SaveSite(parameters);
                }
                else
                {
                    savedEntity = await manager.SaveSiteAsync(parameters);
                }

                if (savedEntity != null && manager.HasErrors == false)
                {
                    _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.Site>>>().Publish(new EntitySavedEventArgs<Entities.Site>()
                    {
                        Entity = savedEntity,
                        IsNew = isNew
                    });
                }
                else if (manager.HasErrors)
                {
                    AddCustomErrors(manager.Errors, true);
                }
                IsBusy = false;
            }
        }

        private bool OnSaveCommandCanExecute(object arg)
        {
            return _Site.IsDirty || _Site.Address.IsDirty;
        }

        private void OnCancelCommandExecute(object arg)
        {
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.Site>>>().Publish(new OperationCanceledEventArgs<Entities.Site>()
            {
                Entity = Site,
                OperationId = InstanceId
            });
        }

        private void OnSelectImageCommandExecute(object obj)
        {
            try
            {
                IDialogService dlgService = new DialogService();
                ImageCaptureControl captureControl = new ImageCaptureControl();
                captureControl.Image = ByteArrayToFromImage.ByteArrayToImage(_Site.gcsBinaryResource?.BinaryResource);
                captureControl.AutomaticallyScaleDownImage = true;
                captureControl.ScaleToMaximumHeight = 600;
                captureControl.AspectRatio = ImageAspectRatio.Square1X1;
                SetBackgroundSubdued();
                dlgService.ShowRadDialog(captureControl, null, CommonResources.Resources.Dialog_SelectSiteImageTitle);
                ClearBackgroundSubdued();
                if (captureControl.DialogResult == true && captureControl.ImageCroppedAndScaled != null)
                {
                    if (_Site.gcsBinaryResource == null)
                        _Site.gcsBinaryResource = new gcsBinaryResource();
                    _Site.gcsBinaryResource.BinaryResource =
                        ByteArrayToFromImage.ImageToByteArray(captureControl.ImageCroppedAndScaled);
                    _Site.MakeDirty();
                }
            }
            catch (Exception ex)
            {
                this.Log().DebugFormat("OnSelectEntityImageCommandExecute: {0}", ex.Message);
            }
        }
        #endregion

        private ReadOnlyCollection<Entities.Country> _countries;

        public ReadOnlyCollection<Entities.Country> Countries
        {
            get { return _countries; }
            set
            {
                if (_countries != value)
                {
                    _countries = value;
                    OnPropertyChanged(() => Countries, false);
                }
            }
        }

        private Entities.Country _selectedCountry;

        public Entities.Country SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                if (_selectedCountry != value)
                {
                    _selectedCountry = value;
                    OnPropertyChanged(() => SelectedCountry);
                    Task.Run(async () => { await FillStatesProvinces(); }).Wait();
                }
            }
        }

        private ReadOnlyCollection<StateProvince> _statesProvinces;

        public ReadOnlyCollection<StateProvince> StatesProvinces
        {
            get { return _statesProvinces; }
            set
            {
                if (_statesProvinces != value)
                {
                    _statesProvinces = value;
                    OnPropertyChanged(() => StatesProvinces, false);
                }
            }
        }

        //private StateProvince _selectedStateProvince;

        public StateProvince SelectedStateProvince
        {
            get { return Address.StateProvince; }
            set
            {
                if (Address.StateProvince != value)
                {
                    Address.StateProvince = value;
                    OnPropertyChanged(() => SelectedStateProvince, true);
                    Site.Address.StateProvinceUid = Address.StateProvince.StateProvinceUid;
                }
            }
        }


        public Address Address
        {
            get { return Site.Address; }
            set
            {
                if (Site.Address != value)
                {
                    Site.Address = value;
                    OnPropertyChanged(() => Address);
                }
            }
        }

        #region Implementation of ISupportsUserEntitySelection
        public void OnEntityMapChecked(UserEntitySelect obj)
        {
            _Site.MakeDirty();
        }

        public UserSessionToken UserSessionToken
        {
            get { return _clientServices?.UserSessionToken; }
        }

        public string EntityAlias
        {
            get { return _clientServices.EntityAlias; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    value = CommonResources.Resources.DefaultEntityAlias;
                if (_clientServices.EntityAlias != value)
                {
                    _clientServices.EntityAlias = value;
                    OnPropertyChanged(() => EntityAlias, false);
                }
            }
        }

        public string EntityAliasPlural
        {
            get { return _clientServices.EntityAliasPlural; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    value = CommonResources.Resources.DefaultEntityAliasPlural;
                if (_clientServices.EntityAliasPlural != value)
                {
                    _clientServices.EntityAliasPlural = value;
                    OnPropertyChanged(() => EntityAliasPlural, false);
                }
            }
        }

        private string _selectEntityHeaderText;

        public string SelectEntityHeaderText
        {
            get { return _selectEntityHeaderText; }
            set
            {
                if (_selectEntityHeaderText != value)
                {
                    _selectEntityHeaderText = value;
                    OnPropertyChanged(() => SelectEntityHeaderText, false);
                }
            }
        }

        private string _selectEntityHeaderToolTip;

        public string SelectEntityHeaderToolTip
        {
            get { return _selectEntityHeaderToolTip; }
            set
            {
                if (_selectEntityHeaderToolTip != value)
                {
                    _selectEntityHeaderToolTip = value;
                    OnPropertyChanged(() => SelectEntityHeaderToolTip, false);
                }
            }
        }

        private ICollection<UserEntitySelect> _userEntitiesSelectionList;
        public ICollection<UserEntitySelect> UserEntitiesSelectionList
        {
            get { return _userEntitiesSelectionList; }
            internal set
            {
                _userEntitiesSelectionList = value;
                OnPropertyChanged(() => UserEntitiesSelectionList, false);
            }
        }
        #endregion
    }
}
