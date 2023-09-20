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

namespace GalaxySMS.OutputDevice.ViewModels
{
    [Export(typeof(OutputDeviceViewModel))]
    public class OutputDeviceViewModel : GCS.Core.Common.UI.Core.ViewModelBase, IPartImportsSatisfiedNotification,
        INavigationAware
    {
        #region Private fields

        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        EditOutputDeviceViewModel _CurrentItemViewModel;
        private Entities.OutputDevice _deleteThisOutputDevice = null;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public OutputDeviceViewModel(IEventAggregator eventAggregator, IClientServices clientServices)
        {
            _eventAggregator = eventAggregator;
            _clientServices = clientServices;
            ViewTitle = CommonResources.Resources.OutputDeviceView_ViewTitle;

            _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.OutputDevice>>>()
                .Subscribe(EntitySaved, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.OutputDevice>>>()
                .Subscribe(OperationCanceled, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>()
                .Subscribe(OnCurrentEntityForSessionChanged, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentSiteForSessionChanged>>()
                .Subscribe(CurrentSiteChanged, ThreadOption.UIThread);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            EditCommand = new DelegateCommand<Entities.OutputDevice>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<Entities.OutputDevice>(OnDeleteCommand, OnDeleteCommandCanExecute);
            RefreshCommand = new DelegateCommand<object>(OnRefreshCommand, OnRefreshCommandCanExecute);
            RefreshInactiveCommand = new DelegateCommand<object>(OnRefreshInactiveCommand, OnRefreshInactiveCommandCanExecute);

            OnCommand = new DelegateCommand<Entities.OutputDevice>(OnOnCommand, OnOnCommandCanExecute);
            OffCommand = new DelegateCommand<Entities.OutputDevice>(OnOffCommand, OnOffCommandCanExecute);
            EnableCommand = new DelegateCommand<Entities.OutputDevice>(OnEnableCommand, OnEnableCommandCanExecute);
            DisableCommand = new DelegateCommand<Entities.OutputDevice>(OnDisableCommand, OnDisableCommandCanExecute);
            RequestStatusCommand = new DelegateCommand<Entities.OutputDevice>(OnRequestStatusCommand, OnRequestStatusCommandCanExecute);
            SendOutputDeviceCommand = new DelegateCommand<MenuItem>(OnSendOutputDeviceCommand);

            CreateGridPageSizes();
            IsAddNewControlVisible = true;
            IsRefreshControlVisible = true;
            IsOffVisible = true;
            IsOnVisible = true;
            IsEnableVisible = true;
            IsDisableVisible = true;
            IsRequestStatusVisible = true;
        }
        private async void OnSendOutputDeviceCommand(MenuItem obj)
        {
            BusyContent = string.Empty;

            IsBusy = true;
            var manager = _clientServices.GetManager<OutputDeviceManager>();

            var parameters = new Entities.CommandParameters<Entities.OutputDeviceCommandAction>()
            {
                Data = new Entities.OutputDeviceCommandAction()
                {
                    CommandUid = obj.CommandUid,
                    OutputDeviceUid = obj.DeviceUid
                },
                SessionId = _clientServices.UserSessionToken.SessionId,
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId,
            };


            CommandResponse<OutputDeviceCommandAction> bResult = null;
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

        private bool OnDisableCommandCanExecute(Entities.OutputDevice obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSOutputCommandPermission.Disable);
        }

        private bool OnEnableCommandCanExecute(Entities.OutputDevice obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSOutputCommandPermission.Enable);
        }

        private bool OnOffCommandCanExecute(Entities.OutputDevice obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSOutputCommandPermission.Off);
        }

        private bool OnOnCommandCanExecute(Entities.OutputDevice obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSOutputCommandPermission.On);
        }


        private async Task ExecuteOutputDeviceCommand(Entities.OutputDevice device, OutputDeviceCommandActionCode cmdCode)
        {
            BusyContent = string.Empty;

            IsBusy = true;
            var manager = _clientServices.GetManager<OutputDeviceManager>();

            var parameters = new Entities.CommandParameters<Entities.OutputDeviceCommandAction>()
            {
                Data = new Entities.OutputDeviceCommandAction()
                {
                    CommandAction = cmdCode,
                    OutputDeviceUid = device.OutputDeviceUid
                },
                SessionId = _clientServices.UserSessionToken.SessionId,
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId,
            };


            CommandResponse<OutputDeviceCommandAction> bResult = null;
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

        private bool OnRequestStatusCommandCanExecute(Entities.OutputDevice obj)
        {
            return true;//_clientServices.UserSessionToken.HasPermission(PermissionIds.GalaxySMSOutputCommandPermission.RequestStatus);
        }

        private async void OnRequestStatusCommand(Entities.OutputDevice obj)
        {
            await ExecuteOutputDeviceCommand(obj, OutputDeviceCommandActionCode.RequestStatus);
        }


        private async void OnDisableCommand(Entities.OutputDevice obj)
        {
            await ExecuteOutputDeviceCommand(obj, OutputDeviceCommandActionCode.Disable);
        }

        private async void OnEnableCommand(Entities.OutputDevice obj)
        {
            await ExecuteOutputDeviceCommand(obj, OutputDeviceCommandActionCode.Enable);
        }

        private async void OnOffCommand(Entities.OutputDevice obj)
        {
            await ExecuteOutputDeviceCommand(obj, OutputDeviceCommandActionCode.Off);
        }

        private async void OnOnCommand(Entities.OutputDevice obj)
        {
            await ExecuteOutputDeviceCommand(obj, OutputDeviceCommandActionCode.On);
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
                    PermissionIds.GalaxySMSDataAccessPermission.OutputDeviceCanViewId);
        }

        private async void OnRefreshCommand(object obj)
        {
            await RefreshFromServer(true);
        }

        private bool OnRefreshInactiveCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.OutputDeviceCanViewId);
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

        private void OperationCanceled(OperationCanceledEventArgs<Entities.OutputDevice> obj)
        {
            if (CurrentItemViewModel?.InstanceId == obj.OperationId)
                CurrentItemViewModel = null;
        }

        private void EntitySaved(EntitySavedEventArgs<Entities.OutputDevice> obj)
        {
            if (!obj.IsNew)
            {
                var entity = OutputDevices.FirstOrDefault(item => item.OutputDeviceUid == obj.Entity.OutputDeviceUid);
                if (entity == null)
                    entity = OutputDevicesInactive.FirstOrDefault(item => item.OutputDeviceUid == obj.Entity.OutputDeviceUid);
                entity?.Initialize(obj.Entity);
            }
            else
                OutputDevices.Add(obj.Entity);

            if (obj.CloseEditor)
                CurrentItemViewModel = null;
        }

        private bool OnEditCommandCanExecute(Entities.OutputDevice obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.OutputDeviceCanUpdateId) &&
                obj?.EntityId == _clientServices.CurrentEntityId;
            ;
        }

        private async void OnEditCommand(Entities.OutputDevice obj)
        {
            ClearCustomErrors();
            if (obj != null)
            {
                IsBusy = true;
                var parameters = new Entities.GetParametersWithPhoto
                {
                    UniqueId = obj.OutputDeviceUid,
                    IncludeMemberCollections = true,
                    IncludeHardwareAddress = true,
                    IncludePhoto = true
                };
                var outputDeviceManager = _clientServices.GetManager<OutputDeviceManager>();
                var item = await outputDeviceManager.GetOutputDeviceAsync(parameters);

                if (outputDeviceManager.HasErrors)
                {
                    base.AddCustomErrors(outputDeviceManager.Errors, true);
                }
                else
                {
                    CurrentItemViewModel = new EditOutputDeviceViewModel(_eventAggregator, _clientServices, item, Guid.Empty, CommonEditingData);
                }
                IsBusy = false;



            }
        }

        private bool OnAddNewCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.OutputDeviceCanUpdateId);
        }

        private void OnAddNewCommand(object obj)
        {
            ClearCustomErrors();
            var o = new Entities.OutputDevice();
            CurrentItemViewModel = new EditOutputDeviceViewModel(_eventAggregator, _clientServices, o, Guid.Empty, CommonEditingData);
        }

        private bool OnDeleteCommandCanExecute(Entities.OutputDevice obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.OutputDeviceCanDeleteId) &&
                obj?.EntityId == _clientServices.CurrentEntityId;
        }

        //private async void OnDeleteCommand(Entities.OutputDevice entity)
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
        private void OnDeleteCommand(Entities.OutputDevice entity)
        {
            ClearCustomErrors();
            _deleteThisOutputDevice = entity;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content =
                string.Format(CommonResources.Resources.MaintainOutputDevices_AreYouSureDeleteOutputDevice,
                    _deleteThisOutputDevice.Name);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainRegions_YesDeleteRegion,
                _deleteThisOutputDevice.Name);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainRegions_NoDeleteRegion,
                _deleteThisOutputDevice.Name);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                IsBusy = true;
                int numberDeleted = 0;
                var inputDeviceManager = _clientServices.GetManager<SDK.Managers.OutputDeviceManager>();
                var parameters = new Entities.DeleteParameters<Entities.OutputDevice>()
                {
                    Data = _deleteThisOutputDevice,
                    SessionId = _clientServices.UserSessionToken.SessionId,
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                };
                if (UseAsyncServiceCalls == false)
                {
                    numberDeleted = inputDeviceManager.DeleteOutputDevice(parameters);
                }
                else
                {
                    //await Task.Run(() => regionManager.DeleteRegion(parameters));
                    numberDeleted = await inputDeviceManager.DeleteOutputDeviceAsync(parameters);
                }
                if (inputDeviceManager.HasErrors == false)
                    OutputDevices.Remove(_deleteThisOutputDevice);
                else
                {
                    base.AddCustomErrors(inputDeviceManager.Errors, true);
                }
            }
            else
                _deleteThisOutputDevice = null;
            IsBusy = false;
        }

        #endregion

        #region Public Properties

        public EditOutputDeviceViewModel CurrentItemViewModel
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

        private ObservableCollection<GalaxySMS.Client.Entities.OutputDevice> _inputDevices;

        public ObservableCollection<GalaxySMS.Client.Entities.OutputDevice> OutputDevices
        {
            get { return _inputDevices; }
            set
            {
                if (_inputDevices != value)
                {
                    _inputDevices = value;
                    OnPropertyChanged(() => OutputDevices, false);
                }
            }
        }

        private ObservableCollection<GalaxySMS.Client.Entities.OutputDevice> _OutputDevicesInactive;

        public ObservableCollection<GalaxySMS.Client.Entities.OutputDevice> OutputDevicesInactive
        {
            get { return _OutputDevicesInactive; }
            set
            {
                if (_OutputDevicesInactive != value)
                {
                    _OutputDevicesInactive = value;
                    OnPropertyChanged(() => OutputDevicesInactive, false);
                }
            }
        }

        private Entities.OutputDeviceGalaxyCommonEditingData _commonEditingData;

        public Entities.OutputDeviceGalaxyCommonEditingData CommonEditingData
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
                if (OutputDevices == null)
                    return 0;
                return OutputDevices.Count;
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
                if (OutputDevicesInactive == null)
                    return 0;
                return OutputDevicesInactive.Count;
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

        private bool _isOnVisible;

        public bool IsOnVisible
        {
            get { return _isOnVisible; }
            set
            {
                if (_isOnVisible != value)
                {
                    _isOnVisible = value;
                    OnPropertyChanged(() => IsOnVisible, false);
                }
            }
        }

        private bool _isOffVisible;

        public bool IsOffVisible
        {
            get { return _isOffVisible; }
            set
            {
                if (_isOffVisible != value)
                {
                    _isOffVisible = value;
                    OnPropertyChanged(() => IsOffVisible, false);
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

        public DelegateCommand<Entities.OutputDevice> EditCommand { get; private set; }
        public DelegateCommand<Entities.OutputDevice> DeleteCommand { get; private set; }
        public DelegateCommand<object> AddNewCommand { get; private set; }
        public DelegateCommand<object> RefreshCommand { get; private set; }
        public DelegateCommand<object> RefreshInactiveCommand { get; private set; }
        public DelegateCommand<Entities.OutputDevice> OnCommand { get; private set; }
        public DelegateCommand<Entities.OutputDevice> OffCommand { get; private set; }
        public DelegateCommand<Entities.OutputDevice> EnableCommand { get; private set; }
        public DelegateCommand<Entities.OutputDevice> DisableCommand { get; private set; }
        public DelegateCommand<Entities.OutputDevice> RequestStatusCommand { get; private set; }
        public DelegateCommand<MenuItem> SendOutputDeviceCommand { get; private set; }

        #endregion

        #region Protected Methods

        protected override void OnViewLoaded()
        {
            IsBusy = true;
            System.Diagnostics.Trace.WriteLine("OutputDeviceViewModel.OnViewLoaded");
            Task.Run(async () =>
           {
               await RefreshFromServer(true);
           }).Wait();
        }

        private async Task RefreshFromServer(bool isNodeActive)
        {
            base.ClearCustomErrors();
            if (isNodeActive)
                OutputDevices = new ObservableCollection<Client.Entities.OutputDevice>();
            else
                OutputDevicesInactive = new ObservableCollection<Client.Entities.OutputDevice>();
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
                parameters.ExcludeMemberCollectionSettings.Add(nameof(Entities.OutputDevice.GalaxyOutputDevice));
                parameters.ExcludeMemberCollectionSettings.Add(nameof(Entities.OutputDevice.GalaxyOutputDevice.GalaxyOutputDeviceInputSources));
                parameters.AddOption(GetOutputDeviceOption.IsNodeActiveValue.ToString(), isNodeActive);
                //parameters.AddOption(GalaxySMS.Common.Constants.GetOptions_OutputDevice.IsNodeActive, true);
                var outputDeviceManager = _clientServices.GetManager<OutputDeviceManager>();
                var outputDevices = await outputDeviceManager.GetOutputDevicesForSiteAsync(parameters);

                System.Diagnostics.Trace.WriteLine(string.Format("{0} input devices read", outputDevices.Items.Length));

                if (outputDeviceManager.HasErrors)
                {
                    base.AddCustomErrors(outputDeviceManager.Errors, true);
                }
                else
                {
                    if (isNodeActive)
                    {
                        foreach (var id in outputDevices.Items)
                        {
                            id.CommandMenu = MenuBuilder.GetMenu(id.Commands, id.OutputDeviceUid, GalaxySMS.Resources.Resources.OutputDeviceView_OutputDevice_CommandHeader_Text,
                                Resources.Resources.OutputDeviceView_OutputDevice_CommandHeader_ToolTip);
                            foreach (var c in id.CommandMenu)
                            {
                                foreach (var i in c.SubItems)
                                {
                                    if (i.CommandUid == GalaxySMS.Common.Constants.OutputCommandIds.Off)
                                        i.IconUrl = new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/light_off-gray.png", UriKind.RelativeOrAbsolute);
                                    else if (i.CommandUid == GalaxySMS.Common.Constants.OutputCommandIds.On)
                                        i.IconUrl = new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/light_on.png", UriKind.RelativeOrAbsolute);
                                    else if (i.CommandUid == GalaxySMS.Common.Constants.OutputCommandIds.Enable)
                                        i.IconUrl = new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/light_off-check.png", UriKind.RelativeOrAbsolute);
                                    else if (i.CommandUid == GalaxySMS.Common.Constants.OutputCommandIds.Disable)
                                        i.IconUrl = new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/light_off-gray-red-circle.png", UriKind.RelativeOrAbsolute);
                                }
                            }
                            OutputDevices.Add(id);
                        }
                        OnPropertyChanged(() => TotalRecordCount, false);
                    }
                    else
                    {
                        OutputDevicesInactive.AddRange(outputDevices.Items);
                        OnPropertyChanged(() => TotalInactiveRecordCount, false);
                    }

                    await FillCommonEditorData();

                    IsBusy = false;
                }
            }
        }

        private async Task FillCommonEditorData()
        {
            var manager = _clientServices.GetManager<OutputDeviceManager>();
            var parameters = new Entities.GetParametersWithPhoto()
            { //SessionId = _clientServices.UserSessionToken.SessionId, 
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId,
                IncludePhoto = true,
            };
            if (UseAsyncServiceCalls == false)
            {
                Task.Run(() =>
                {
                    CommonEditingData = manager.GetOutputDeviceGalaxyCommonEditingData(parameters);
                }).Wait();
            }
            else
            {
                CommonEditingData = await manager.GetOutputDeviceGalaxyCommonEditingDataAsync(parameters);
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