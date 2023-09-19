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

namespace GalaxySMS.MonitoredDevice.ViewModels
{
    [Export(typeof(MonitoredDeviceViewModel))]
    public class MonitoredDeviceViewModel : GCS.Core.Common.UI.Core.ViewModelBase, IPartImportsSatisfiedNotification,
        INavigationAware
    {
        #region Private fields

        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        EditMonitoredDeviceViewModel _CurrentItemViewModel;
        private Entities.InputDevice _deleteThisMonitoredDevice = null;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public MonitoredDeviceViewModel(IEventAggregator eventAggregator, IClientServices clientServices)
        {
            _eventAggregator = eventAggregator;
            _clientServices = clientServices;
            ViewTitle = CommonResources.Resources.MonitoredDeviceView_ViewTitle;

            _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.InputDevice>>>()
                .Subscribe(EntitySaved, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.InputDevice>>>()
                .Subscribe(OperationCanceled, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>()
                .Subscribe(OnCurrentEntityForSessionChanged, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentSiteForSessionChanged>>()
                .Subscribe(CurrentSiteChanged, ThreadOption.UIThread);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            EditCommand = new DelegateCommand<Entities.InputDevice>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<Entities.InputDevice>(OnDeleteCommand, OnDeleteCommandCanExecute);
            RefreshCommand = new DelegateCommand<object>(OnRefreshCommand, OnRefreshCommandCanExecute);
            RefreshInactiveCommand = new DelegateCommand<object>(OnRefreshInactiveCommand, OnRefreshInactiveCommandCanExecute);

            UnshuntCommand = new DelegateCommand<Entities.InputDevice>(OnUnshuntCommand, OnUnshuntCommandCanExecute);
            ShuntCommand = new DelegateCommand<Entities.InputDevice>(OnShuntCommand, OnShuntCommandCanExecute);
            EnableCommand = new DelegateCommand<Entities.InputDevice>(OnEnableCommand, OnEnableCommandCanExecute);
            DisableCommand = new DelegateCommand<Entities.InputDevice>(OnDisableCommand, OnDisableCommandCanExecute);
            RequestStatusCommand = new DelegateCommand<Entities.InputDevice>(OnRequestStatusCommand, OnRequestStatusCommandCanExecute);
            SendMonitoredDeviceCommand = new DelegateCommand<MenuItem>(OnSendMonitoredDeviceCommand);

            CreateGridPageSizes();
            IsAddNewControlVisible = true;
            IsRefreshControlVisible = true;
            IsShuntVisible = true;
            IsUnshuntVisible = true;
            IsEnableVisible = true;
            IsDisableVisible = true;
            IsRequestStatusVisible = true;
        }
        private async void OnSendMonitoredDeviceCommand(MenuItem obj)
        {
            BusyContent = string.Empty;

            IsBusy = true;
            var manager = _clientServices.GetManager<InputDeviceManager>();

            var parameters = new Entities.CommandParameters<Entities.InputDeviceCommandAction>()
            {
                Data = new Entities.InputDeviceCommandAction()
                {
                    CommandUid = obj.CommandUid,
                    InputDeviceUid = obj.DeviceUid
                },
                SessionId = _clientServices.UserSessionToken.SessionId,
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId,
            };


            CommandResponse<InputDeviceCommandAction> bResult = null;
            if (UseAsyncServiceCalls == false)
            {
                bResult = manager.ExecuteCommand(parameters);
            }
            else
            {
                bResult = await manager.ExecuteCommandAsync(parameters);
            }

            if (bResult != null && manager.HasErrors == false)
            {

            }
            else if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
            IsBusy = false;

        }

        private bool OnDisableCommandCanExecute(Entities.InputDevice obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSInputCommandPermission.Disable);
        }

        private bool OnEnableCommandCanExecute(Entities.InputDevice obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSInputCommandPermission.Enable);
        }

        private bool OnShuntCommandCanExecute(Entities.InputDevice obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSInputCommandPermission.Shunt);
        }

        private bool OnUnshuntCommandCanExecute(Entities.InputDevice obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSInputCommandPermission.Unshunt);
        }


        private async Task ExecuteMonitoredDeviceCommand(Entities.InputDevice device, InputDeviceCommandActionCode cmdCode)
        {
            BusyContent = string.Empty;

            IsBusy = true;
            var manager = _clientServices.GetManager<InputDeviceManager>();

            var parameters = new Entities.CommandParameters<Entities.InputDeviceCommandAction>()
            {
                Data = new Entities.InputDeviceCommandAction()
                {
                    CommandAction = cmdCode,
                    InputDeviceUid = device.InputDeviceUid
                },
                SessionId = _clientServices.UserSessionToken.SessionId,
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId,
            };


            CommandResponse<InputDeviceCommandAction> bResult = null;
            if (UseAsyncServiceCalls == false)
            {
                bResult = manager.ExecuteCommand(parameters);
            }
            else
            {
                bResult = await manager.ExecuteCommandAsync(parameters);
            }

            if (bResult != null && manager.HasErrors == false)
            {

            }
            else if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
            IsBusy = false;

        }

        private bool OnRequestStatusCommandCanExecute(Entities.InputDevice obj)
        {
            return true;//_clientServices.UserSessionToken.HasPermission(PermissionIds.GalaxySMSInputCommandPermission.RequestStatus);
        }

        private async void OnRequestStatusCommand(Entities.InputDevice obj)
        {
            await ExecuteMonitoredDeviceCommand(obj, InputDeviceCommandActionCode.RequestStatus);
        }


        private async void OnDisableCommand(Entities.InputDevice obj)
        {
            await ExecuteMonitoredDeviceCommand(obj, InputDeviceCommandActionCode.Disable);
        }

        private async void OnEnableCommand(Entities.InputDevice obj)
        {
            await ExecuteMonitoredDeviceCommand(obj, InputDeviceCommandActionCode.Enable);
        }

        private async void OnShuntCommand(Entities.InputDevice obj)
        {
            await ExecuteMonitoredDeviceCommand(obj, InputDeviceCommandActionCode.Shunt);
        }

        private async void OnUnshuntCommand(Entities.InputDevice obj)
        {
            await ExecuteMonitoredDeviceCommand(obj, InputDeviceCommandActionCode.Unshunt);
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
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.InputDeviceCanViewId);
        }

        private async void OnRefreshCommand(object obj)
        {
            await RefreshFromServer(true);
        }

        private bool OnRefreshInactiveCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.InputDeviceCanViewId);
        }

        private async void OnRefreshInactiveCommand(object obj)
        {
            await RefreshFromServer(false);
        }


        private async void OnCurrentEntityForSessionChanged(CurrentEntityForSessionChanged obj)
        {
            await RefreshFromServer(true);
        }

        private async void CurrentSiteChanged(CurrentSiteForSessionChanged obj)
        {
            await RefreshFromServer(true);
        }

        private void OperationCanceled(OperationCanceledEventArgs<Entities.InputDevice> obj)
        {
            if (CurrentItemViewModel?.InstanceId == obj.OperationId)
                CurrentItemViewModel = null;
        }

        private void EntitySaved(EntitySavedEventArgs<Entities.InputDevice> obj)
        {
            if (!obj.IsNew)
            {
                var entity = InputDevices.FirstOrDefault(item => item.InputDeviceUid == obj.Entity.InputDeviceUid);
                if (entity == null)
                    entity = MonitoredDevicesInactive.FirstOrDefault(item => item.InputDeviceUid == obj.Entity.InputDeviceUid);
                entity?.Initialize(obj.Entity);
            }
            else
                InputDevices.Add(obj.Entity);

            if (obj.CloseEditor)
                CurrentItemViewModel = null;
        }

        private bool OnEditCommandCanExecute(Entities.InputDevice obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.InputDeviceCanUpdateId) &&
                obj?.EntityId == _clientServices.CurrentEntityId;
            ;
        }

        private async void OnEditCommand(Entities.InputDevice obj)
        {
            ClearCustomErrors();
            if (obj != null)
            {
                IsBusy = true;
                var parameters = new Entities.GetParametersWithPhoto
                {
                    UniqueId = obj.InputDeviceUid,
                    IncludeMemberCollections = true,
                    IncludeHardwareAddress = true,
                    IncludePhoto = true
                };
                var inputDeviceManager = _clientServices.GetManager<InputDeviceManager>();
                var item = await inputDeviceManager.GetInputDeviceAsync(parameters);

                if (inputDeviceManager.HasErrors)
                {
                    base.AddCustomErrors(inputDeviceManager.Errors, true);
                }
                else
                {
                    CurrentItemViewModel = new EditMonitoredDeviceViewModel(_eventAggregator, _clientServices, item, Guid.Empty, CommonEditingData);
                }
                IsBusy = false;



            }
        }

        private bool OnAddNewCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.InputDeviceCanUpdateId);
        }

        private void OnAddNewCommand(object obj)
        {
            ClearCustomErrors();
            var o = new Entities.InputDevice();
            CurrentItemViewModel = new EditMonitoredDeviceViewModel(_eventAggregator, _clientServices, o, Guid.Empty, CommonEditingData);
        }

        private bool OnDeleteCommandCanExecute(Entities.InputDevice obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.InputDeviceCanDeleteId) &&
                obj?.EntityId == _clientServices.CurrentEntityId;
        }

        //private async void OnDeleteCommand(Entities.MonitoredDevice entity)
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
        private void OnDeleteCommand(Entities.InputDevice entity)
        {
            ClearCustomErrors();
            _deleteThisMonitoredDevice = entity;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content =
                string.Format(CommonResources.Resources.MaintainMonitoredDevices_AreYouSureDeleteMonitoredDevice,
                    _deleteThisMonitoredDevice.Name);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainRegions_YesDeleteRegion,
                _deleteThisMonitoredDevice.Name);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainRegions_NoDeleteRegion,
                _deleteThisMonitoredDevice.Name);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                IsBusy = true;
                int numberDeleted = 0;
                var inputDeviceManager = _clientServices.GetManager<SDK.Managers.InputDeviceManager>();
                var parameters = new Entities.DeleteParameters<Entities.InputDevice>()
                {
                    Data = _deleteThisMonitoredDevice,
                    SessionId = _clientServices.UserSessionToken.SessionId,
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                };
                if (UseAsyncServiceCalls == false)
                {
                    numberDeleted = inputDeviceManager.DeleteInputDevice(parameters);
                }
                else
                {
                    //await Task.Run(() => regionManager.DeleteRegion(parameters));
                    numberDeleted = await inputDeviceManager.DeleteInputDeviceAsync(parameters);
                }
                if (inputDeviceManager.HasErrors == false)
                    InputDevices.Remove(_deleteThisMonitoredDevice);
                else
                {
                    base.AddCustomErrors(inputDeviceManager.Errors, true);
                }
            }
            else
                _deleteThisMonitoredDevice = null;
            IsBusy = false;
        }

        #endregion

        #region Public Properties

        public EditMonitoredDeviceViewModel CurrentItemViewModel
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

        private ObservableCollection<GalaxySMS.Client.Entities.InputDevice> _inputDevices;

        public ObservableCollection<GalaxySMS.Client.Entities.InputDevice> InputDevices
        {
            get { return _inputDevices; }
            set
            {
                if (_inputDevices != value)
                {
                    _inputDevices = value;
                    OnPropertyChanged(() => InputDevices, false);
                }
            }
        }

        private ObservableCollection<GalaxySMS.Client.Entities.InputDevice> _MonitoredDevicesInactive;

        public ObservableCollection<GalaxySMS.Client.Entities.InputDevice> MonitoredDevicesInactive
        {
            get { return _MonitoredDevicesInactive; }
            set
            {
                if (_MonitoredDevicesInactive != value)
                {
                    _MonitoredDevicesInactive = value;
                    OnPropertyChanged(() => MonitoredDevicesInactive, false);
                }
            }
        }

        private Entities.InputDeviceGalaxyCommonEditingData _commonEditingData;

        public Entities.InputDeviceGalaxyCommonEditingData CommonEditingData
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
                if (InputDevices == null)
                    return 0;
                return InputDevices.Count;
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
                if (MonitoredDevicesInactive == null)
                    return 0;
                return MonitoredDevicesInactive.Count;
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

        private bool _isUnshuntVisible;

        public bool IsUnshuntVisible
        {
            get { return _isUnshuntVisible; }
            set
            {
                if (_isUnshuntVisible != value)
                {
                    _isUnshuntVisible = value;
                    OnPropertyChanged(() => IsUnshuntVisible, false);
                }
            }
        }

        private bool _isShuntVisible;

        public bool IsShuntVisible
        {
            get { return _isShuntVisible; }
            set
            {
                if (_isShuntVisible != value)
                {
                    _isShuntVisible = value;
                    OnPropertyChanged(() => IsShuntVisible, false);
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

        private bool _isRequestStatusVisible;

        public bool IsRequestStatusVisible
        {
            get { return _isRequestStatusVisible; }
            set
            {
                if (_isRequestStatusVisible != value)
                {
                    _isRequestStatusVisible = value;
                    OnPropertyChanged(() => IsRequestStatusVisible, false);
                }
            }
        }

        #endregion

        #region Public Events

        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccured;

        #endregion

        #region Public Commands

        public DelegateCommand<Entities.InputDevice> EditCommand { get; private set; }
        public DelegateCommand<Entities.InputDevice> DeleteCommand { get; private set; }
        public DelegateCommand<object> AddNewCommand { get; private set; }
        public DelegateCommand<object> RefreshCommand { get; private set; }
        public DelegateCommand<object> RefreshInactiveCommand { get; private set; }
        public DelegateCommand<Entities.InputDevice> UnshuntCommand { get; private set; }
        public DelegateCommand<Entities.InputDevice> ShuntCommand { get; private set; }
        public DelegateCommand<Entities.InputDevice> EnableCommand { get; private set; }
        public DelegateCommand<Entities.InputDevice> DisableCommand { get; private set; }
        public DelegateCommand<Entities.InputDevice> RequestStatusCommand { get; private set; }
        public DelegateCommand<MenuItem> SendMonitoredDeviceCommand { get; private set; }

        #endregion

        #region Protected Methods

        protected override void OnViewLoaded()
        {
            IsBusy = true;
            System.Diagnostics.Trace.WriteLine("MonitoredDeviceViewModel.OnViewLoaded");
            Task.Run(async () =>
           {
               await RefreshFromServer(true);
           }).Wait();
        }

        private async Task RefreshFromServer(bool isNodeActive)
        {
            base.ClearCustomErrors();
            if (isNodeActive)
                InputDevices = new ObservableCollection<Client.Entities.InputDevice>();
            else
                MonitoredDevicesInactive = new ObservableCollection<Client.Entities.InputDevice>();
            if (_clientServices.CurrentSite != null)
            {
                IsBusy = true;

                var parameters = new Entities.GetParametersWithPhoto
                {
                    UniqueId = _clientServices.CurrentSite.SiteUid,
                    IncludeMemberCollections = false,
                    IncludePhoto = true,
                    IncludeCommands = true,
                    IncludeHardwareAddress = false,
                    PhotoPixelWidth = _clientServices.ThumbnailPixelWidth
                };
                parameters.ExcludeMemberCollectionSettings.Add(nameof(Entities.InputDevice.GalaxyInputDevice));
                parameters.ExcludeMemberCollectionSettings.Add(nameof(Entities.InputDevice.InputDeviceEventProperties));
                parameters.AddOption(GetInputDeviceOption.IsNodeActiveValue.ToString(), isNodeActive);
                //parameters.AddOption(GalaxySMS.Common.Constants.GetOptions_MonitoredDevice.IsNodeActive, true);
                var inputDeviceManager = _clientServices.GetManager<InputDeviceManager>();
                var inputDevices = await inputDeviceManager.GetInputDevicesForSiteAsync(parameters);

                System.Diagnostics.Trace.WriteLine(string.Format("{0} input devices read", inputDevices.Items.Length));

                if (inputDeviceManager.HasErrors)
                {
                    base.AddCustomErrors(inputDeviceManager.Errors, true);
                }
                else
                {
                    if (isNodeActive)
                    {
                        foreach (var id in inputDevices.Items)
                        {
                            id.CommandMenu = MenuBuilder.GetMenu(id.Commands, id.InputDeviceUid, GalaxySMS.Resources.Resources.MonitoredDeviceView_MonitoredDevice_CommandHeader_Text,
                                Resources.Resources.MonitoredDeviceView_MonitoredDevice_CommandHeader_ToolTip);
                            foreach (var c in id.CommandMenu)
                            {
                                foreach (var i in c.SubItems)
                                {
                                    if (i.CommandUid == GalaxySMS.Common.Constants.InputCommandIds.Shunt)
                                        i.IconUrl = new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Inputs/32x32/alarm_detector-gray.png", UriKind.RelativeOrAbsolute);
                                    else if (i.CommandUid == GalaxySMS.Common.Constants.InputCommandIds.Unshunt)
                                        i.IconUrl = new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Inputs/32x32/alarm_detector.png", UriKind.RelativeOrAbsolute);
                                    else if (i.CommandUid == GalaxySMS.Common.Constants.InputCommandIds.Enable)
                                        i.IconUrl = new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Inputs/32x32/alarm_detector_green-check2.png", UriKind.RelativeOrAbsolute);
                                    else if (i.CommandUid == GalaxySMS.Common.Constants.InputCommandIds.Disable)
                                        i.IconUrl = new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Inputs/32x32/alarm_detector_red-x2.png", UriKind.RelativeOrAbsolute);
                                }
                            }
                            InputDevices.Add(id);
                        }
                        OnPropertyChanged(() => TotalRecordCount, false);
                    }
                    else
                    {
                        MonitoredDevicesInactive.AddRange(inputDevices.Items);
                        OnPropertyChanged(() => TotalInactiveRecordCount, false);
                    }

                    await FillCommonEditorData();

                    IsBusy = false;
                }
            }
        }

        private async Task FillCommonEditorData()
        {
            var manager = _clientServices.GetManager<InputDeviceManager>();
            var parameters = new Entities.GetParametersWithPhoto()
            { //SessionId = _clientServices.UserSessionToken.SessionId, 
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
            };
            if (UseAsyncServiceCalls == false)
            {
                Task.Run(() =>
                {
                    CommonEditingData = manager.GetInputDeviceGalaxyCommonEditingData(parameters);
                }).Wait();
            }
            else
            {
                CommonEditingData = await manager.GetInputDeviceGalaxyCommonEditingDataAsync(parameters);
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