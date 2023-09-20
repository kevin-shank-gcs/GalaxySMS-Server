using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using GalaxySMS.Client.Contracts.ViewModelContracts;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Enums;
using GalaxySMS.Prism.Infrastructure;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI.Core;
using GCS.Core.Common.UI.Interfaces;
using GCS.Framework.Imaging;
using Prism.Events;
using Entities = GalaxySMS.Client.Entities;
using CommonResources = GalaxySMS.Resources;

namespace GalaxySMS.MonitoredDevice.ViewModels
{
    [Export(typeof(EditMonitoredDeviceViewModel))]
    public class EditMonitoredDeviceViewModel : ViewModelBase, ISupportsUserEntitySelection
    {
        #region Private Fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        private Entities.InputDevice _inputDevice;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public EditMonitoredDeviceViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.InputDevice entity, Guid instanceId, InputDeviceGalaxyCommonEditingData commonEditingData)
        {
            IsBusy = true;
            if (instanceId == Guid.Empty)
                InstanceId = Guid.NewGuid();
            else
                InstanceId = instanceId;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            CommonEditingData = commonEditingData;

            _inputDevice = new Entities.InputDevice(entity) {SiteUid = _clientServices.CurrentSite.SiteUid};

            foreach(var evt in InputDevice.GalaxyInputDevice.AlertEvents)
            {
                evt.InputDeviceAlertEventType = CommonEditingData.AlertEventTypes.FirstOrDefault(t => t.InputDeviceAlertEventTypeUid == evt.InputDeviceAlertEventTypeUid);
            }

 
            foreach(var props in InputDevice.InputDeviceEventProperties)
            {
                props.InputDeviceAlertEventType = CommonEditingData.AlertEventTypes.FirstOrDefault(t => t.InputDeviceAlertEventTypeUid == props.InputDeviceAlertEventTypeUid);
            }

            Task.Run(async () =>
            {
                //await FillCommonEditorData();
                await FillPanelSpecificEditorData();
            }).Wait();

            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);
            SelectImageCommand = new DelegateCommand<object>(OnSelectImageCommandExecute);
            EntityMapChecked = new DelegateCommand<UserEntitySelect>(OnEntityMapChecked);
            InputOutputGroupChanged = new DelegateCommand<InputDeviceAlertEvent>(OnInputOutputGroupChanged);
            InputOutputGroupAssignmentChanged = new DelegateCommand<InputDeviceAlertEvent>(OnInputOutputGroupAssignmentChanged);
            SupervisionTypeSelectionChanged = new DelegateCommand<Entities.InputDeviceSupervisionType>(OnSupervisionTypeSelectionChanged);
            ReadVoltagesCommand = new DelegateCommand<object>(OnReadVoltagesCommandExecute, OnReadVoltagesCommandCanExecute);
            //AcknowledgeScheduleChanged = new DelegateCommand<object>(OnAcknowledgeScheduleChangedChanged);

            BusyContent = CommonResources.Resources.Common_PleaseWait;
            ViewTitle = CommonResources.Resources.EditMonitoredDeviceView_ViewTitle;


            _eventAggregator.GetEvent<PubSubEvent<InputDeviceVoltagesReply>>().Subscribe(InputDeviceVoltagesReplyReceived);

            IsAlertEventControlExpanded = true;
            IsSupervisionControlExpanded = true;
            IsEventLogControlExpanded = true;
            IsDelaySettingsControlExpanded = true;
            IsGeneralOptionsControlExpanded = true;
            IsVoltageSettingsControlExpanded = true;
            IsArmingControlExpanded = true;

            if (UserSessionToken != null)
            {
                UserEntitiesSelectionList = UserSessionToken.GetUserEntitySelectCollection();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (_inputDevice.EntityIds.Contains(ue.EntityId))
                        ue.Selected = true;
                }
            }

            this.SelectEntityHeaderText = string.Format(
                CommonResources.Resources.EditMonitoredDeviceView_EntityMappingTabHeader, EntityAlias);

            this.SelectEntityHeaderToolTip = string.Format(
                CommonResources.Resources.EditMonitoredDeviceView_EntityMappingTabHeaderToolTip, EntityAliasPlural);
            _inputDevice.CleanAll();
            IsBusy = false;

        }

        private void OnSupervisionTypeSelectionChanged(Entities.InputDeviceSupervisionType obj)
        {
            if( obj != null)
            {
                this.InputDevice.GalaxyInputDevice.AlternateNormalChangeThreshold = obj.AlternateNormalChangeThreshold;
                this.InputDevice.GalaxyInputDevice.AlternateTroubleOpenThreshold = obj.AlternateTroubleOpenThreshold;
                this.InputDevice.GalaxyInputDevice.AlternateTroubleShortThreshold = obj.AlternateTroubleShortThreshold;
                this.InputDevice.GalaxyInputDevice.NormalChangeThreshold = obj.NormalChangeThreshold;
                this.InputDevice.GalaxyInputDevice.TroubleOpenThreshold = obj.TroubleOpenThreshold;
                this.InputDevice.GalaxyInputDevice.TroubleShortThreshold = obj.TroubleShortThreshold;
                this.InputDevice.GalaxyInputDevice.AlternateVoltagesEnabled = obj.AlternateVoltagesEnabled;
            }
        }


        //private void OnAcknowledgeScheduleChangedChanged(object obj)
        //{
        //    //foreach (var i in SelectedAccessGroupMonitoredDeviceItems)
        //    //{
        //    //    if (i.AccessGroupUid != obj.AccessGroupUid)
        //    //        i.TimeScheduleUid = obj.TimeScheduleUid;
        //    //}
        //}

        private void OnInputOutputGroupChanged(InputDeviceAlertEvent obj)
        {
            if (obj != null)
            {
                var iog = this.DeviceSpecificEditingData.InputOutputGroups.FirstOrDefault(g => g.InputOutputGroupUid == obj.InputOutputGroupUid);
                if (iog != null)
                {
                    if (obj.InputDeviceAlertEventType.CanHaveInputOutputGroupOffset && obj.InputOutputGroupAssignmentUid.HasValue == false)
                    {
                        obj.InputOutputGroupAssignmentUid = Guid.Empty;
                    }
                }
            }
        }

        private void OnInputOutputGroupAssignmentChanged(InputDeviceAlertEvent obj)
        {
            if (obj != null)
            {
                var iog = this.DeviceSpecificEditingData.InputOutputGroups.FirstOrDefault(g => g.InputOutputGroupUid == obj.InputOutputGroupUid);
                if (iog != null)
                {
                    // Mark the newly selected Assignment as Earmarked so that it cannot be selected for another event
                    var iogass = iog.InputOutputGroupAssignments.FirstOrDefault(i => i.InputOutputGroupAssignmentUid == obj.InputOutputGroupAssignmentUid && i.InputDeviceAlertEventUid != obj.InputDeviceAlertEventUid);
                    if (iogass != null)
                    {
                        iogass.IsEarmarked = true;
                        iogass.InputDeviceAlertEventUid = obj.InputDeviceAlertEventUid;
                        iog.NotifyAvailableInputOutputGroupAssignments();
                    }

                    var previousIogass = iog.InputOutputGroupAssignments.FirstOrDefault(i => i.InputDeviceAlertEventUid == obj.InputDeviceAlertEventUid && i.InputOutputGroupAssignmentUid != obj.InputOutputGroupAssignmentUid);
                    if (previousIogass != null)
                    {
                        previousIogass.IsEarmarked = false;
                        previousIogass.InputDeviceAlertEventUid = Guid.Empty;
                        iog.NotifyAvailableInputOutputGroupAssignments();
                    }
                }
            }
        }

        
        private void InputDeviceVoltagesReplyReceived(InputDeviceVoltagesReply obj)
        {
            if (obj == null ||
                obj.InputDeviceUid != InputDevice.InputDeviceUid)
                return;
            InputDevice.GalaxyInputDevice.VoltagesReply = obj;
        }

        private bool OnReadVoltagesCommandCanExecute(object obj)
        {
            return true;
        }

        private async void OnReadVoltagesCommandExecute(object obj)
        {
            await ExecuteMonitoredDeviceCommand(this.InputDevice, InputDeviceCommandActionCode.ReadVoltages);
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

        #endregion

        #region Public Commands
        public DelegateCommand<object> SaveCommand { get; private set; }

        public DelegateCommand<object> CancelCommand { get; private set; }

        public DelegateCommand<object> SelectImageCommand { get; private set; }
        public DelegateCommand<object> ReadVoltagesCommand {get; private set;}
        public DelegateCommand<UserEntitySelect> EntityMapChecked { get; set; }

        public DelegateCommand<InputDeviceAlertEvent> InputOutputGroupChanged { get; set; }

        public DelegateCommand<InputDeviceAlertEvent> InputOutputGroupAssignmentChanged { get; set; }

        public DelegateCommand<Entities.InputDeviceSupervisionType> SupervisionTypeSelectionChanged {get;set;}
        //public DelegateCommand<object> AcknowledgeScheduleChanged { get; set; }
        #endregion

        #region Public Properties
        public Entities.InputDevice InputDevice
        {
            get { return _inputDevice; }
        }

        public Guid InstanceId { get; }

        private InputDeviceGalaxyCommonEditingData _commonEditingData;

        public InputDeviceGalaxyCommonEditingData CommonEditingData
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

        private InputDeviceHardwareSpecificEditingData _deviceSpecificEditingData;

        public InputDeviceHardwareSpecificEditingData DeviceSpecificEditingData
        {
            get { return _deviceSpecificEditingData; }
            set
            {
                if (_deviceSpecificEditingData != value)
                {
                    _deviceSpecificEditingData = value;
                    OnPropertyChanged(() => DeviceSpecificEditingData, false);
                }
            }
        }

        public bool AreVoltageSettingVisible => InputDevice.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs;

        private bool _IsArmingControlExpanded;

        public bool IsArmingControlExpanded
        {
            get { return _IsArmingControlExpanded; }
            set
            {
                if (_IsArmingControlExpanded != value)
                {
                    _IsArmingControlExpanded = value;
                    OnPropertyChanged(() => IsArmingControlExpanded, false);
                }
            }
        }


        private bool _IsAlertEventControlExpanded;

        public bool IsAlertEventControlExpanded
        {
            get { return _IsAlertEventControlExpanded; }
            set
            {
                if (_IsAlertEventControlExpanded != value)
                {
                    _IsAlertEventControlExpanded = value;
                    OnPropertyChanged(() => IsAlertEventControlExpanded, false);
                }
            }
        }

        private bool _isSupervisionControlExpanded;

        public bool IsSupervisionControlExpanded
        {
            get { return _isSupervisionControlExpanded; }
            set
            {
                if (_isSupervisionControlExpanded != value)
                {
                    _isSupervisionControlExpanded = value;
                    OnPropertyChanged(() => IsSupervisionControlExpanded, false);
                }
            }
        }


        private bool _IsEventLogControlExpanded;

        public bool IsEventLogControlExpanded
        {
            get { return _IsEventLogControlExpanded; }
            set
            {
                if (_IsEventLogControlExpanded != value)
                {
                    _IsEventLogControlExpanded = value;
                    OnPropertyChanged(() => IsEventLogControlExpanded, false);
                }
            }
        }

        private bool _IsDelaySettingsControlExpanded;

        public bool IsDelaySettingsControlExpanded
        {
            get { return _IsDelaySettingsControlExpanded; }
            set
            {
                if (_IsDelaySettingsControlExpanded != value)
                {
                    _IsDelaySettingsControlExpanded = value;
                    OnPropertyChanged(() => IsDelaySettingsControlExpanded, false);
                }
            }
        }

        
        private bool _IsGeneralOptionsControlExpanded;

        public bool IsGeneralOptionsControlExpanded
        {
            get { return _IsGeneralOptionsControlExpanded; }
            set
            {
                if (_IsGeneralOptionsControlExpanded != value)
                {
                    _IsGeneralOptionsControlExpanded = value;
                    OnPropertyChanged(() => IsGeneralOptionsControlExpanded, false);
                }
            }
        }

        private bool _IsVoltageSettingsControlExpanded;

        public bool IsVoltageSettingsControlExpanded
        {
            get { return _IsVoltageSettingsControlExpanded; }
            set
            {
                if (_IsVoltageSettingsControlExpanded != value)
                {
                    _IsVoltageSettingsControlExpanded = value;
                    OnPropertyChanged(() => IsVoltageSettingsControlExpanded, false);
                }
            }
        }

        #endregion

        #region Protected Methods
        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(InputDevice);
        }
        #endregion

        #region Private Methods

        //private async Task FillCommonEditorData()
        //{
        //    IsBusy = true;
        //    var manager = _clientServices.GetManager<MonitoredDeviceManager>();
        //    var parameters = new GetParametersWithPhoto() { UniqueId = MonitoredDevice.MonitoredDeviceUid, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
        //    if (UseAsyncServiceCalls == false)
        //    {
        //        Task.Run(() =>
        //        {
        //            CommonEditingData = manager.GetMonitoredDeviceGalaxyCommonEditingData(parameters);
        //        }).Wait();
        //    }
        //    else
        //    {
        //        CommonEditingData = await manager.GetMonitoredDeviceGalaxyCommonEditingDataAsync(parameters);
        //    }

        //    if (manager.HasErrors)
        //    {
        //        AddCustomErrors(manager.Errors, true);
        //    }
        //    IsBusy = false;
        //}


        private async Task FillPanelSpecificEditorData()
        {
            IsBusy = true;
            var manager = _clientServices.GetManager<InputDeviceManager>();
            var parameters = new GetParametersWithPhoto() { UniqueId = InputDevice.InputDeviceUid, 
                //SessionId = _clientServices.UserSessionToken.SessionId,
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId,
            IncludePhoto = true};
            parameters.Options.Add(new KeyValuePair<string, bool>(Common.Constants.GetOptions.IncludeNoSelectionEntry, true));

            if (UseAsyncServiceCalls == false)
            {
                Task.Run(() =>
                {
                    DeviceSpecificEditingData = manager.GetInputDeviceHardwareSpecificEditingData(parameters);
                }).Wait();
            }
            else
            {
                DeviceSpecificEditingData = await manager.GetInputDeviceHardwareSpecificEditingDataAsync(parameters);
            }

            if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
            else
            {
                //var lcds = DeviceSpecificEditingData.LiquidCrystalDisplays.ToList();
                //lcds.Add(new LiquidCrystalDisplay() { LiquidCrystalDisplayUid = Guid.Empty, LcdName = CommonResources.Resources.MonitoredDeviceProperties_LiquidCrystalDisplay_None_Text });
                //DeviceSpecificEditingData.LiquidCrystalDisplays = lcds.OrderBy(i=>i.LcdName).ToList();

                //var elevatorRelayChannels = DeviceSpecificEditingData.ElevatorRelaysInterfaceBoardSections.ToList();
                //elevatorRelayChannels.Add(new GalaxyInterfaceBoardSection() { GalaxyInterfaceBoardSectionUid = Guid.Empty, BoardSectionDescription = CommonResources.Resources.MonitoredDeviceProperties_ElevatorOutputRelayChannel_None_Text });
                //DeviceSpecificEditingData.ElevatorRelaysInterfaceBoardSections = elevatorRelayChannels.OrderBy(i => i.BoardSectionDescription).ToList();

                foreach (var alertEvent in InputDevice.GalaxyInputDevice.AlertEvents)
                    alertEvent.PanelSpecificEditingData = DeviceSpecificEditingData;

                foreach (var props in InputDevice.InputDeviceEventProperties)
                    props.PanelSpecificEditingData = DeviceSpecificEditingData;
            }
            IsBusy = false;
        }

        private async void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                BusyContent = string.Format(CommonResources.Resources.EditMonitoredDeviceView_PleaseWaitWhileISave, InputDevice.InputName);

                InputDevice.EntityIds.Clear();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (ue.Selected || ue.EntityId == InputDevice.EntityId)
                        InputDevice.EntityIds.Add(ue.EntityId);
                }

                foreach( var ae in InputDevice.GalaxyInputDevice.AlertEvents)
                {
                    if (ae.InputDeviceAlertEventType?.CanHaveInputOutputGroupOffset == false && ae.InputOutputGroupAssignmentUid != null)
                        ae.InputOutputGroupAssignmentUid = null;
                }

                IsBusy = true;
                var manager = _clientServices.GetManager<InputDeviceManager>();
                bool isNew = (InputDevice.InputDeviceUid == Guid.Empty);
                Entities.InputDevice savedEntity;
                var parameters = new SaveParameters<Entities.InputDevice>()
                {
                    SavePhoto = true,
                    Data = InputDevice,
                    //SessionId = _clientServices.UserSessionToken.SessionId,
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                };
                if (UseAsyncServiceCalls == false)
                {
                    savedEntity = manager.SaveInputDevice(parameters);
                }
                else
                {
                    savedEntity = await manager.SaveInputDeviceAsync(parameters);
                }

                if (savedEntity != null && manager.HasErrors == false)
                {
                    _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.InputDevice>>>()
                        .Publish(new EntitySavedEventArgs<Entities.InputDevice>()
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
            return _inputDevice.IsAnythingDirty();
            //return _InputDevice.IsDirty;
        }

        private void OnCancelCommandExecute(object arg)
        {
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.InputDevice>>>().Publish(new OperationCanceledEventArgs<Entities.InputDevice>()
            {
                Entity = InputDevice,
                OperationId = InstanceId
            });
        }
        private void OnSelectImageCommandExecute(object obj)
        {
            try
            {
                IDialogService dlgService = new DialogService();
                ImageCaptureControl captureControl = new ImageCaptureControl();
                captureControl.Image = ByteArrayToFromImage.ByteArrayToImage(_inputDevice.gcsBinaryResource?.BinaryResource);
                captureControl.AutomaticallyScaleDownImage = true;
                captureControl.ScaleToMaximumHeight = 600;
                captureControl.AspectRatio = ImageAspectRatio.Square1X1;
                SetBackgroundSubdued();
                dlgService.ShowRadDialog(captureControl, null, CommonResources.Resources.Dialog_SelectSiteImageTitle);
                ClearBackgroundSubdued();
                if (captureControl.DialogResult == true && captureControl.ImageCroppedAndScaled != null)
                {
                    if (_inputDevice.gcsBinaryResource == null)
                        _inputDevice.gcsBinaryResource = new gcsBinaryResource();
                    _inputDevice.gcsBinaryResource.BinaryResource =
                        ByteArrayToFromImage.ImageToByteArray(captureControl.ImageCroppedAndScaled);
                    _inputDevice.MakeDirty();
                }
            }
            catch (Exception ex)
            {
                this.Log().DebugFormat("OnSelectEntityImageCommandExecute: {0}", ex.Message);
            }
        }

        //private void OnSelectEntityImageCommandExecute(object obj)
        //{
        //    try
        //    {
        //        IDialogService dlgService = new DialogService();
        //        ImageCaptureControl captureControl = new ImageCaptureControl();
        //        captureControl.Image = ByteArrayToFromImage.ByteArrayToImage(_Entity.gcsBinaryResource.BinaryResource);
        //        captureControl.AutomaticallyScaleDownImage = true;
        //        captureControl.ScaleToMaximumHeight = 600;
        //        captureControl.AspectRatio = ImageAspectRatio.Square1X1;
        //        SetBackgroundSubdued();
        //        dlgService.ShowRadDialog(captureControl, null, Resources.Dialog_SelectCapturePhotoTitle);
        //        ClearBackgroundSubdued();
        //        if (captureControl.DialogResult == true && captureControl.ImageCroppedAndScaled != null)
        //        {
        //            _Entity.gcsBinaryResource.BinaryResource =
        //                ByteArrayToFromImage.ImageToByteArray(captureControl.ImageCroppedAndScaled);
        //            _Entity.MakeDirty();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().DebugFormat("OnSelectEntityImageCommandExecute: {0}", ex.Message);
        //    }
        //}
        #endregion


        public void OnEntityMapChecked(UserEntitySelect obj)
        {
            _inputDevice.MakeDirty();
        }

        #region Implementation of ISupportsUserEntitySelection

        public string EntityAlias { get { return _clientServices.EntityAlias; }
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

        public UserSessionToken UserSessionToken
        {
            get { return _clientServices?.UserSessionToken; }
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