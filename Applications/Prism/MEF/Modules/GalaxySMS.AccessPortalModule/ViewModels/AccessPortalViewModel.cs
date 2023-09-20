using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Client.UI;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using GalaxySMS.Prism.Infrastructure;
using GalaxySMS.Prism.Infrastructure.Events;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;
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

namespace GalaxySMS.AccessPortal.ViewModels
{
    [Export(typeof(AccessPortalViewModel))]
    public class AccessPortalViewModel : GCS.Core.Common.UI.Core.ViewModelBase, IPartImportsSatisfiedNotification,
        INavigationAware
    {
        #region Private fields

        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        EditAccessPortalViewModel _CurrentItemViewModel;
        private Entities.AccessPortal _deleteThisAccessPortal = null;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public AccessPortalViewModel(IEventAggregator eventAggregator, IClientServices clientServices)
        {
            _eventAggregator = eventAggregator;
            _clientServices = clientServices;
            ViewTitle = CommonResources.Resources.AccessPortalView_ViewTitle;

            _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.AccessPortal>>>()
                .Subscribe(EntitySaved, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.AccessPortal>>>()
                .Subscribe(OperationCanceled, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>()
                .Subscribe(OnCurrentEntityForSessionChanged, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentSiteForSessionChanged>>()
                .Subscribe(CurrentSiteChanged, ThreadOption.UIThread);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            EditCommand = new DelegateCommand<Entities.AccessPortal>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<Entities.AccessPortal>(OnDeleteCommand, OnDeleteCommandCanExecute);
            RefreshCommand = new DelegateCommand<object>(OnRefreshCommand, OnRefreshCommandCanExecute);

            PulseCommand = new DelegateCommand<Entities.AccessPortal>(OnPulseCommand, OnPulseCommandCanExecute);
            UnlockCommand = new DelegateCommand<Entities.AccessPortal>(OnUnlockCommand, OnUnlockCommandCanExecute);
            LockCommand = new DelegateCommand<Entities.AccessPortal>(OnLockCommand, OnLockCommandCanExecute);
            EnableCommand = new DelegateCommand<Entities.AccessPortal>(OnEnableCommand, OnEnableCommandCanExecute);
            DisableCommand = new DelegateCommand<Entities.AccessPortal>(OnDisableCommand, OnDisableCommandCanExecute);
            Relay2OnCommand = new DelegateCommand<Entities.AccessPortal>(OnRelay2OnCommand, OnRelay2OnCommandCanExecute);
            Relay2OffCommand = new DelegateCommand<Entities.AccessPortal>(OnRelay2OffCommand, OnRelay2OffCommandCanExecute);
            SendAccessPortalCommand = new DelegateCommand<MenuItem>(OnSendAccessPortalCommand);

            CreateGridPageSizes();
            IsAddNewControlVisible = true;
            IsRefreshControlVisible = true;
            IsPulseVisible = true;
            IsLockVisible = true;
            IsUnlockVisible = true;
            IsEnableVisible = true;
            IsDisableVisible = true;
            IsRelay2OnVisible = true;
            IsRelay2OffVisible = true;
        }

        private async void OnSendAccessPortalCommand(MenuItem obj)
        {
            BusyContent = string.Empty;

            IsBusy = true;
            var manager = _clientServices.GetManager<AccessPortalManager>();

            var parameters = new Entities.CommandParameters<Entities.AccessPortalCommandAction>()
            {
                Data = new Entities.AccessPortalCommandAction()
                {
                    CommandUid = obj.CommandUid,
                    AccessPortalUid = obj.DeviceUid
                },
                SessionId = _clientServices.UserSessionToken.SessionId,
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId,
            };


            CommandResponse<AccessPortalCommandAction> result = null;
            if (UseAsyncServiceCalls == false)
            {
                result = manager.ExecuteCommand(parameters);
            }
            else
            {
                result = await manager.ExecuteCommandAsync(parameters);
            }

            if (result != null && manager.HasErrors == false)
            {

            }
            else if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
            IsBusy = false;

        }

        private bool OnRelay2OffCommandCanExecute(Entities.AccessPortal obj)
        {
            if (obj == null)
                return false;

            return !obj.DisabledCommandIds.Contains(GalaxySMS.Common.Constants.AccessPortalCommandIds.AuxRelayOff);
            //return obj?.Commands.FirstOrDefault(o => o.AccessPortalCommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.AuxRelayOff) != null;
        }

        private bool OnRelay2OnCommandCanExecute(Entities.AccessPortal obj)
        {
            if (obj == null)
                return false;
            return !obj.DisabledCommandIds.Contains(GalaxySMS.Common.Constants.AccessPortalCommandIds.AuxRelayOn);
            //return obj?.Commands.FirstOrDefault(o => o.AccessPortalCommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.AuxRelayOn) != null;
        }

        private bool OnDisableCommandCanExecute(Entities.AccessPortal obj)
        {
            if (obj == null)
                return false;
            return !obj.DisabledCommandIds.Contains(GalaxySMS.Common.Constants.AccessPortalCommandIds.Disable);
            //return obj?.Commands.FirstOrDefault(o => o.AccessPortalCommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.Disable) != null;
        }

        private bool OnEnableCommandCanExecute(Entities.AccessPortal obj)
        {
            if (obj == null)
                return false;
            return !obj.DisabledCommandIds.Contains(GalaxySMS.Common.Constants.AccessPortalCommandIds.Enable);
            //return obj?.Commands.FirstOrDefault(o => o.AccessPortalCommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.Enable) != null;
        }

        private bool OnLockCommandCanExecute(Entities.AccessPortal obj)
        {
            if (obj == null)
                return false;
            return !obj.DisabledCommandIds.Contains(GalaxySMS.Common.Constants.AccessPortalCommandIds.Lock);
            //return obj?.Commands.FirstOrDefault(o => o.AccessPortalCommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.Lock) != null;
        }

        private bool OnUnlockCommandCanExecute(Entities.AccessPortal obj)
        {
            if (obj == null)
                return false;
            return !obj.DisabledCommandIds.Contains(GalaxySMS.Common.Constants.AccessPortalCommandIds.Unlock);
            //return obj?.Commands.FirstOrDefault(o => o.AccessPortalCommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.Unlock) != null;
        }

        private bool OnPulseCommandCanExecute(Entities.AccessPortal obj)
        {
            if (obj == null)
                return false;
            return !obj.DisabledCommandIds.Contains(GalaxySMS.Common.Constants.AccessPortalCommandIds.Pulse);
            //return obj?.Commands.FirstOrDefault(o => o.AccessPortalCommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.Pulse) != null;
        }

        private async Task ExecuteAccessPortalCommand(Entities.AccessPortal ap, AccessPortalCommandActionCode cmdCode)
        {
            BusyContent = string.Empty;

            IsBusy = true;
            var manager = _clientServices.GetManager<AccessPortalManager>();

            var parameters = new Entities.CommandParameters<Entities.AccessPortalCommandAction>()
            {
                Data = new Entities.AccessPortalCommandAction()
                {
                    CommandAction = cmdCode,
                    AccessPortalUid = ap.AccessPortalUid
                },
                SessionId = _clientServices.UserSessionToken.SessionId,
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId,
            };


            CommandResponse<AccessPortalCommandAction> result = null;
            if (UseAsyncServiceCalls == false)
            {
                result = manager.ExecuteCommand(parameters);
            }
            else
            {
                result = await manager.ExecuteCommandAsync(parameters);
            }

            if (result != null && manager.HasErrors == false)
            {

            }
            else if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
            IsBusy = false;

        }

        private async void OnRelay2OffCommand(Entities.AccessPortal obj)
        {
            await ExecuteAccessPortalCommand(obj, AccessPortalCommandActionCode.AuxRelayOff);
        }

        private async void OnRelay2OnCommand(Entities.AccessPortal obj)
        {
            await ExecuteAccessPortalCommand(obj, AccessPortalCommandActionCode.AuxRelayOn);
        }

        private async void OnDisableCommand(Entities.AccessPortal obj)
        {
            await ExecuteAccessPortalCommand(obj, AccessPortalCommandActionCode.Disable);
        }

        private async void OnEnableCommand(Entities.AccessPortal obj)
        {
            await ExecuteAccessPortalCommand(obj, AccessPortalCommandActionCode.Enable);
        }

        private async void OnLockCommand(Entities.AccessPortal obj)
        {
            await ExecuteAccessPortalCommand(obj, AccessPortalCommandActionCode.Lock);
        }

        private async void OnUnlockCommand(Entities.AccessPortal obj)
        {
            await ExecuteAccessPortalCommand(obj, AccessPortalCommandActionCode.Unlock);
        }

        private async void OnPulseCommand(Entities.AccessPortal obj)
        {
            await ExecuteAccessPortalCommand(obj, AccessPortalCommandActionCode.Pulse);
        }
        #endregion

        #region Private Methods

        private void CreateGridPageSizes()
        {
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
        }


        private bool OnRefreshCommandCanExecute(object obj)
        {
            if (_clientServices.UserSessionToken == null)
                return false;
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.RegionCanViewId);
        }

        private async void OnRefreshCommand(object obj)
        {
            await RefreshFromServer();
        }

        private async void OnCurrentEntityForSessionChanged(CurrentEntityForSessionChanged obj)
        {
            await RefreshFromServer();
        }

        private async void CurrentSiteChanged(CurrentSiteForSessionChanged obj)
        {
            await RefreshFromServer();
        }

        private void OperationCanceled(OperationCanceledEventArgs<Entities.AccessPortal> obj)
        {
            if (CurrentItemViewModel?.InstanceId == obj.OperationId)
                CurrentItemViewModel = null;
        }

        private void EntitySaved(EntitySavedEventArgs<Entities.AccessPortal> obj)
        {
            if (!obj.IsNew)
            {
                var entity = AccessPortals.FirstOrDefault(item => item.AccessPortalUid == obj.Entity.AccessPortalUid);
                if (entity == null)
                    entity = AccessPortalsInactive.FirstOrDefault(item => item.AccessPortalUid == obj.Entity.AccessPortalUid);
                entity?.Initialize(obj.Entity);
            }
            else
                AccessPortals.Add(obj.Entity);

            if (obj.CloseEditor)
                CurrentItemViewModel = null;
        }

        private bool OnEditCommandCanExecute(Entities.AccessPortal obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.AccessPortalCanUpdateId) &&
                obj?.EntityId == _clientServices.CurrentEntityId;
            ;
        }

        private async void OnEditCommand(Entities.AccessPortal obj)
        {
            ClearCustomErrors();
            if (obj != null)
            {
                IsBusy = true;
                var parameters = new Entities.GetParametersWithPhoto();
                parameters.UniqueId = obj.AccessPortalUid;
                parameters.IncludeMemberCollections = true;
                parameters.IncludePhoto = true;
                parameters.IncludeHardwareAddress = true;
                var accessPortalManager = _clientServices.GetManager<AccessPortalManager>();
                var ap = await accessPortalManager.GetAccessPortalAsync(parameters);

                if (accessPortalManager.HasErrors)
                {
                    base.AddCustomErrors(accessPortalManager.Errors, true);
                }
                else
                {
                    CurrentItemViewModel = new EditAccessPortalViewModel(_eventAggregator, _clientServices, ap, Guid.Empty, CommonEditingData);
                }
                IsBusy = false;



            }
        }

        private bool OnAddNewCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.AccessPortalCanUpdateId);
        }

        private void OnAddNewCommand(object obj)
        {
            ClearCustomErrors();
            var o = new Entities.AccessPortal();
            CurrentItemViewModel = new EditAccessPortalViewModel(_eventAggregator, _clientServices, o, Guid.Empty, CommonEditingData);
        }

        private bool OnDeleteCommandCanExecute(Entities.AccessPortal obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.AccessPortalCanDeleteId) &&
                obj?.EntityId == _clientServices.CurrentEntityId;
        }

        //private async void OnDeleteCommand(Entities.AccessPortal entity)
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
        private void OnDeleteCommand(Entities.AccessPortal entity)
        {
            ClearCustomErrors();
            _deleteThisAccessPortal = entity;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content =
                string.Format(CommonResources.Resources.MaintainAccessPortals_AreYouSureDeleteAccessPortal,
                    _deleteThisAccessPortal.PortalName);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainRegions_YesDeleteRegion,
                _deleteThisAccessPortal.PortalName);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainRegions_NoDeleteRegion,
                _deleteThisAccessPortal.PortalName);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                IsBusy = true;
                int numberDeleted = 0;
                var accessPortalManager = _clientServices.GetManager<SDK.Managers.AccessPortalManager>();
                var parameters = new Entities.DeleteParameters<Entities.AccessPortal>()
                {
                    Data = _deleteThisAccessPortal,
                    SessionId = _clientServices.UserSessionToken.SessionId,
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                };
                if (UseAsyncServiceCalls == false)
                {
                    numberDeleted = accessPortalManager.DeleteAccessPortal(parameters);
                }
                else
                {
                    //await Task.Run(() => regionManager.DeleteRegion(parameters));
                    numberDeleted = await accessPortalManager.DeleteAccessPortalAsync(parameters);
                }
                if (accessPortalManager.HasErrors == false)
                    AccessPortals.Remove(_deleteThisAccessPortal);
                else
                {
                    base.AddCustomErrors(accessPortalManager.Errors, true);
                }
            }
            else
                _deleteThisAccessPortal = null;
            IsBusy = false;
        }

        #endregion

        #region Public Properties

        public EditAccessPortalViewModel CurrentItemViewModel
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

        private ObservableCollection<GalaxySMS.Client.Entities.AccessPortal> _accessPortals;

        public ObservableCollection<GalaxySMS.Client.Entities.AccessPortal> AccessPortals
        {
            get { return _accessPortals; }
            set
            {
                if (_accessPortals != value)
                {
                    _accessPortals = value;
                    OnPropertyChanged(() => AccessPortals, false);
                }
            }
        }

        private ObservableCollection<GalaxySMS.Client.Entities.AccessPortal> _accessPortalsInactive;

        public ObservableCollection<GalaxySMS.Client.Entities.AccessPortal> AccessPortalsInactive
        {
            get { return _accessPortalsInactive; }
            set
            {
                if (_accessPortalsInactive != value)
                {
                    _accessPortalsInactive = value;
                    OnPropertyChanged(() => AccessPortalsInactive, false);
                }
            }
        }

        private Entities.AccessPortalGalaxyCommonEditingData _commonEditingData;

        public Entities.AccessPortalGalaxyCommonEditingData CommonEditingData
        {
            get { return _commonEditingData; }
            set
            {
                if (_commonEditingData != value)
                {
                    _commonEditingData = value;
                    OnPropertyChanged(() => CommonEditingData, false);
                }
            }
        }

        private KeyValuePair<int, string> _gridPageSize;

        public KeyValuePair<int, string> GridPageSize
        {
            get { return _gridPageSize; }
            set
            {
                _gridPageSize = value;
                OnPropertyChanged(() => GridPageSize, false);
            }
        }

        private ObservableCollection<KeyValuePair<int, string>> _gridPageSizes;

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
                if (AccessPortals == null)
                    return 0;
                return AccessPortals.Count;
            }
            set
            {
                OnPropertyChanged(() => TotalRecordCount, false);
            }
        }

        public int TotalInactiveRecordCount
        {
            get
            {
                if (AccessPortalsInactive == null)
                    return 0;
                return AccessPortalsInactive.Count;
            }
            set
            {
                OnPropertyChanged(() => TotalInactiveRecordCount, false);
            }
        }



        private bool _isPulseVisible;

        public bool IsPulseVisible
        {
            get { return _isPulseVisible; }
            set
            {
                if (_isPulseVisible != value)
                {
                    _isPulseVisible = value;
                    OnPropertyChanged(() => IsPulseVisible, false);
                }
            }
        }

        private bool _isUnlockVisible;

        public bool IsUnlockVisible
        {
            get { return _isUnlockVisible; }
            set
            {
                if (_isUnlockVisible != value)
                {
                    _isUnlockVisible = value;
                    OnPropertyChanged(() => IsUnlockVisible, false);
                }
            }
        }

        private bool _isLockVisible;

        public bool IsLockVisible
        {
            get { return _isLockVisible; }
            set
            {
                if (_isLockVisible != value)
                {
                    _isLockVisible = value;
                    OnPropertyChanged(() => IsLockVisible, false);
                }
            }
        }

        private bool _isDisableVisible;

        public bool IsDisableVisible
        {
            get { return _isDisableVisible; }
            set
            {
                if (_isDisableVisible != value)
                {
                    _isDisableVisible = value;
                    OnPropertyChanged(() => IsDisableVisible, false);
                }
            }
        }

        private bool _isEnableVisible;

        public bool IsEnableVisible
        {
            get { return _isEnableVisible; }
            set
            {
                if (_isEnableVisible != value)
                {
                    _isEnableVisible = value;
                    OnPropertyChanged(() => IsEnableVisible, false);
                }
            }
        }

        private bool _isRelay2OnVisible;

        public bool IsRelay2OnVisible
        {
            get { return _isRelay2OnVisible; }
            set
            {
                if (_isRelay2OnVisible != value)
                {
                    _isRelay2OnVisible = value;
                    OnPropertyChanged(() => IsRelay2OnVisible, false);
                }
            }
        }

        private bool _isRelay2OffVisible;

        public bool IsRelay2OffVisible
        {
            get { return _isRelay2OffVisible; }
            set
            {
                if (_isRelay2OffVisible != value)
                {
                    _isRelay2OffVisible = value;
                    OnPropertyChanged(() => IsRelay2OffVisible, false);
                }
            }
        }

        #endregion

        #region Public Events

        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccured;

        #endregion

        #region Public Commands

        public DelegateCommand<Entities.AccessPortal> EditCommand { get; private set; }
        public DelegateCommand<Entities.AccessPortal> DeleteCommand { get; private set; }
        public DelegateCommand<object> AddNewCommand { get; private set; }
        public DelegateCommand<object> RefreshCommand { get; private set; }
        public DelegateCommand<Entities.AccessPortal> PulseCommand { get; private set; }
        public DelegateCommand<Entities.AccessPortal> UnlockCommand { get; private set; }
        public DelegateCommand<Entities.AccessPortal> LockCommand { get; private set; }
        public DelegateCommand<Entities.AccessPortal> EnableCommand { get; private set; }
        public DelegateCommand<Entities.AccessPortal> DisableCommand { get; private set; }
        public DelegateCommand<Entities.AccessPortal> Relay2OnCommand { get; private set; }
        public DelegateCommand<Entities.AccessPortal> Relay2OffCommand { get; private set; }
        public DelegateCommand<MenuItem> SendAccessPortalCommand { get; private set; }

        #endregion

        #region Protected Methods

        protected override void OnViewLoaded()
        {
            IsBusy = true;
            System.Diagnostics.Trace.WriteLine("AccessPortalViewModel.OnViewLoaded");
            Task.Run(async () =>
           {
               await RefreshFromServer();
           }).Wait();
        }

        private async Task RefreshFromServer()
        {
            base.ClearCustomErrors();
            AccessPortals = new ObservableCollection<Client.Entities.AccessPortal>();
            AccessPortalsInactive = new ObservableCollection<Client.Entities.AccessPortal>();
            if (_clientServices.CurrentSite != null)
            {
                IsBusy = true;

                await FillCommonEditorData();

                var parameters = new Entities.GetParametersWithPhoto();
                parameters.UniqueId = _clientServices.CurrentSite.SiteUid;
                parameters.IncludeMemberCollections = false;
                parameters.IncludePhoto = true;
                parameters.IncludeCommands = true;
                parameters.IncludeHardwareAddress = true;
                parameters.PhotoPixelWidth = _clientServices.ThumbnailPixelWidth;
                //parameters.AddOption(GalaxySMS.Common.Constants.GetOptions_AccessPortal.IsNodeActive, true);
                var accessPortalManager = _clientServices.GetManager<AccessPortalManager>();
                var accessPortals = await accessPortalManager.GetAccessPortalsForSiteAsync(parameters);

                System.Diagnostics.Trace.WriteLine(string.Format("{0} access portals read", accessPortals.Items.Length));

                if (accessPortalManager.HasErrors)
                {
                    base.AddCustomErrors(accessPortalManager.Errors, true);
                }
                else
                {
                    if (accessPortals != null)
                    {
                        foreach (var ap in accessPortals.Items.Where(o => o.IsNodeActive == true).ToList())
                        {
                            //ap.CommandMenu = MenuBuilder.GetMenu(ap.Commands, ap.AccessPortalUid, GalaxySMS.Resources.Resources.AccessPortalView_AccessPortal_CommandHeader_Text,
                            //    Resources.Resources.AccessPortalView_AccessPortal_CommandHeader_ToolTip);
                            ap.CommandMenu = MenuBuilder.GetMenu(CommonEditingData.Commands, ap.AccessPortalUid, GalaxySMS.Resources.Resources.AccessPortalView_AccessPortal_CommandHeader_Text,
                                Resources.Resources.AccessPortalView_AccessPortal_CommandHeader_ToolTip); 
                            
                            foreach (var c in ap.CommandMenu)
                            {
                                foreach (var i in c.SubItems)
                                {
                                    if (i.CommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.Pulse)
                                        i.IconUrl = new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Locks/32x32/unlocked_padlock_green_timer.png", UriKind.RelativeOrAbsolute);
                                    else if (i.CommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.Unlock)
                                        i.IconUrl = new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Locks/32x32/unlocked_padlock_green.png", UriKind.RelativeOrAbsolute);
                                    else if (i.CommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.Lock)
                                        i.IconUrl = new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Locks/32x32/locked_padlock_red.png", UriKind.RelativeOrAbsolute);
                                    else if (i.CommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.Enable)
                                        i.IconUrl = new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Locks/32x32/locked_padlock_pale_blue.png", UriKind.RelativeOrAbsolute);
                                    else if (i.CommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.Disable)
                                        i.IconUrl = new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Locks/32x32/locked_padlock_dark_gray.png", UriKind.RelativeOrAbsolute);
                                    else if (i.CommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.AuxRelayOff)
                                        i.IconUrl = new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/BulbOff.png", UriKind.RelativeOrAbsolute);
                                    else if (i.CommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.AuxRelayOn)
                                        i.IconUrl = new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/BulbOn.png", UriKind.RelativeOrAbsolute);
                                }
                            }
                            AccessPortals.Add(ap);
                        }
                        //try
                        //{
                        //    AccessPortals.AddRange(accessPortals);
                        //}
                        //catch (Exception e)
                        //{
                        //    System.Diagnostics.Trace.WriteLine(e.ToString());
                        //}

                        AccessPortalsInactive.AddRange(accessPortals.Items.Where(o => o.IsNodeActive == false).ToList());
                    }

                    OnPropertyChanged(() => TotalRecordCount, false);
                    OnPropertyChanged(() => TotalInactiveRecordCount, false);

                    IsBusy = false;
                }
            }
        }

        private async Task FillCommonEditorData()
        {
            var manager = _clientServices.GetManager<AccessPortalManager>();
            var parameters = new Entities.GetParametersWithPhoto()
            { //SessionId = _clientServices.UserSessionToken.SessionId, 
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
            };
            if (UseAsyncServiceCalls == false)
            {
                Task.Run(() =>
                {
                    CommonEditingData = manager.GetAccessPortalGalaxyCommonEditingData(parameters);
                }).Wait();
            }
            else
            {
                CommonEditingData = await manager.GetAccessPortalGalaxyCommonEditingDataAsync(parameters);
            }

            if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
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