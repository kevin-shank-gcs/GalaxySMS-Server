using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using GalaxySMS.Client.Contracts.ViewModelContracts;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
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

namespace GalaxySMS.AccessPortal.ViewModels
{
    [Export(typeof(EditAccessPortalViewModel))]
    public class EditAccessPortalViewModel : ViewModelBase, ISupportsUserEntitySelection
    {
        #region Private Fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        private Entities.AccessPortal _AccessPortal;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public EditAccessPortalViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.AccessPortal entity, Guid instanceId, AccessPortalGalaxyCommonEditingData commonEditingData)
        {
            if (instanceId == Guid.Empty)
                InstanceId = Guid.NewGuid();
            else
                InstanceId = instanceId;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            CommonEditingData = commonEditingData;

            SelectedAccessGroupAccessPortalItems = new CollectionBase<AccessGroupAccessPortal>();
            _AccessPortal = new Entities.AccessPortal(entity);
            _AccessPortal.SiteUid = _clientServices.CurrentSite.SiteUid;

            foreach(var evt in AccessPortal.AlertEvents)
            {
                evt.AccessPortalAlertEventType = CommonEditingData.AlertEventTypes.FirstOrDefault(t => t.AccessPortalAlertEventTypeUid == evt.AccessPortalAlertEventTypeUid);
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
            InputOutputGroupChanged = new DelegateCommand<AccessPortalAlertEvent>(OnInputOutputGroupChanged);
            InputOutputGroupAssignmentChanged = new DelegateCommand<AccessPortalAlertEvent>(OnInputOutputGroupAssignmentChanged);

            AccessGroupScheduleChanged = new DelegateCommand<AccessGroupAccessPortal>(OnAccessGroupScheduleChangedChanged);

            BusyContent = CommonResources.Resources.Common_PleaseWait;
            ViewTitle = CommonResources.Resources.EditAccessPortalView_ViewTitle;

            IsLockControlExpanded = true;
            IsRelay2ControlExpanded = true;
            IsAlertEventControlExpanded = true;
            IsPassbackControlExpanded = true;
            IsDoorGroupControlExpanded = true;
            IsPinRequiredControlExpanded = true;
            IsDoorContactControlExpanded = true;
            IsAccessRuleOverrideControlExpanded = true;
            IsEventLogControlExpanded = true;
            IsElevatorControlControlExpanded = true;
            IsLiquidCrystalDisplayControlExpanded = true;
            IsPanelOptionsControlExpanded = true;
            IsGeneralOptionsControlExpanded = true;

            if (UserSessionToken != null)
            {
                UserEntitiesSelectionList = UserSessionToken.GetUserEntitySelectCollection();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (_AccessPortal.EntityIds.Contains(ue.EntityId))
                        ue.Selected = true;
                }
            }

            this.SelectEntityHeaderText = string.Format(
                CommonResources.Resources.EditAccessPortalView_EntityMappingTabHeader, EntityAlias);

            this.SelectEntityHeaderToolTip = string.Format(
                CommonResources.Resources.EditAccessPortalView_EntityMappingTabHeaderToolTip, EntityAliasPlural);
            _AccessPortal.CleanAll();
        }

        private void OnAccessGroupScheduleChangedChanged(AccessGroupAccessPortal obj)
        {
            foreach( var i in SelectedAccessGroupAccessPortalItems)
            {
                if( i.AccessGroupUid != obj.AccessGroupUid)
                    i.TimeScheduleUid = obj.TimeScheduleUid;
            }
        }

        private void OnInputOutputGroupChanged(AccessPortalAlertEvent obj)
        {
            if (obj != null)
            {
                var iog = this.PanelSpecificEditingData.InputOutputGroups.FirstOrDefault(g => g.InputOutputGroupUid == obj.InputOutputGroupUid);
                if (iog != null)
                {
                    if( obj.AccessPortalAlertEventType.CanHaveInputOutputGroupOffset && obj.InputOutputGroupAssignmentUid.HasValue == false)
                    {
                        obj.InputOutputGroupAssignmentUid = Guid.Empty;
                    }
                }
            }
        }

        private void OnInputOutputGroupAssignmentChanged(AccessPortalAlertEvent obj)
        {
            if (obj != null)
            {
                var iog = this.PanelSpecificEditingData.InputOutputGroups.FirstOrDefault(g => g.InputOutputGroupUid == obj.InputOutputGroupUid);
                if (iog != null)
                {
                    // Mark the newly selected Assignment as Earmarked so that it cannot be selected for another event
                    var iogass = iog.InputOutputGroupAssignments.FirstOrDefault(i => i.InputOutputGroupAssignmentUid == obj.InputOutputGroupAssignmentUid && i.AccessPortalAlertEventUid != obj.AccessPortalAlertEventUid);
                    if (iogass != null)
                    {
                        iogass.IsEarmarked = true;
                        iogass.AccessPortalAlertEventUid = obj.AccessPortalAlertEventUid;
                        iog.NotifyAvailableInputOutputGroupAssignments();
                    }

                    var previousIogass = iog.InputOutputGroupAssignments.FirstOrDefault(i => i.AccessPortalAlertEventUid == obj.AccessPortalAlertEventUid && i.InputOutputGroupAssignmentUid != obj.InputOutputGroupAssignmentUid);
                    if (previousIogass != null)
                    {
                        previousIogass.IsEarmarked = false;
                        previousIogass.AccessPortalAlertEventUid = Guid.Empty;
                        iog.NotifyAvailableInputOutputGroupAssignments();
                    }

                    //var iogass = iog.AvailableInputOutputGroupAssignments.FirstOrDefault(i => i.InputOutputGroupAssignmentUid == obj.InputOutputGroupAssignmentUid);
                    //if (iogass != null)
                    //{
                    //    iogass.IsEarmarked = true;
                    //    iog.NotifyAvailableInputOutputGroupAssignments();
                    //}

                    //// Mark the previously selected Assignment as available so that it can be selected for another event
                    //iogass = iog.InputOutputGroupAssignments.FirstOrDefault(i => i.InputOutputGroupAssignmentUid == obj.OriginalInputOutputGroupAssignmentUid || i.InputOutputGroupAssignmentUid == obj.LastSelectedInputOutputGroupAssignmentUid);
                    ////iogass = iog.InputOutputGroupAssignments.FirstOrDefault(i => i.AccessPortalAlertEventUid == obj.AccessPortalAlertEventUid );
                    //if (iogass != null)
                    //{
                    //    iogass.IsEarmarked = false;
                    //    iogass.AccessPortalAlertEventUid = Guid.Empty;
                    //    iogass.InputDeviceAlertEventUid = Guid.Empty;
                    //    iog.NotifyAvailableInputOutputGroupAssignments();
                    //}
                    ////iog.NotifyAvailableInputOutputGroupAssignments();
                }
            }
        }

        #endregion

        #region Public Commands
        public DelegateCommand<object> SaveCommand { get; private set; }

        public DelegateCommand<object> CancelCommand { get; private set; }

        public DelegateCommand<object> SelectImageCommand { get; private set; }

        public DelegateCommand<UserEntitySelect> EntityMapChecked { get; set; }

        public DelegateCommand<AccessPortalAlertEvent> InputOutputGroupChanged { get; set; }

        public DelegateCommand<AccessPortalAlertEvent> InputOutputGroupAssignmentChanged { get; set; }

        public DelegateCommand<AccessGroupAccessPortal> AccessGroupScheduleChanged { get; set; }
        #endregion

        #region Public Properties
        public Entities.AccessPortal AccessPortal
        {
            get { return _AccessPortal; }
        }

        public Guid InstanceId { get; }

        private AccessPortalGalaxyCommonEditingData _commonEditingData;

        public AccessPortalGalaxyCommonEditingData CommonEditingData
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

        private ObservableCollection<AccessGroupAccessPortal> _selectedAccessGroupAccessPortalItemsAccessGroupAccessPortals;

        public ObservableCollection<AccessGroupAccessPortal> SelectedAccessGroupAccessPortalItems
        {
            get { return _selectedAccessGroupAccessPortalItemsAccessGroupAccessPortals; }
            set
            {
                if (_selectedAccessGroupAccessPortalItemsAccessGroupAccessPortals != value)
                {
                    _selectedAccessGroupAccessPortalItemsAccessGroupAccessPortals = value;
                    OnPropertyChanged(() => SelectedAccessGroupAccessPortalItems, false);
                }
            }
        }


        private AccessPortalGalaxyPanelSpecificEditingData _panelSpecificEditingData;

        public AccessPortalGalaxyPanelSpecificEditingData PanelSpecificEditingData
        {
            get { return _panelSpecificEditingData; }
            set
            {
                if (_panelSpecificEditingData != value)
                {
                    _panelSpecificEditingData = value;
                    OnPropertyChanged(() => PanelSpecificEditingData, false);
                }
            }
        }

        private bool _IsLockControlExpanded;

        public bool IsLockControlExpanded
        {
            get { return _IsLockControlExpanded; }
            set
            {
                if (_IsLockControlExpanded != value)
                {
                    _IsLockControlExpanded = value;
                    OnPropertyChanged(() => IsLockControlExpanded, false);
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

        private bool _IsRelay2ControlExpanded;

        public bool IsRelay2ControlExpanded
        {
            get { return _IsRelay2ControlExpanded; }
            set
            {
                if (_IsRelay2ControlExpanded != value)
                {
                    _IsRelay2ControlExpanded = value;
                    OnPropertyChanged(() => IsRelay2ControlExpanded, false);
                }
            }
        }

        private bool _IsPassbackControlExpanded;

        public bool IsPassbackControlExpanded
        {
            get { return _IsPassbackControlExpanded; }
            set
            {
                if (_IsPassbackControlExpanded != value)
                {
                    _IsPassbackControlExpanded = value;
                    OnPropertyChanged(() => IsPassbackControlExpanded, false);
                }
            }
        }

        private bool _IsDoorGroupControlExpanded;

        public bool IsDoorGroupControlExpanded
        {
            get { return _IsDoorGroupControlExpanded; }
            set
            {
                if (_IsDoorGroupControlExpanded != value)
                {
                    _IsDoorGroupControlExpanded = value;
                    OnPropertyChanged(() => IsDoorGroupControlExpanded, false);
                }
            }
        }

        private bool _IsPinRequiredControlExpanded;

        public bool IsPinRequiredControlExpanded
        {
            get { return _IsPinRequiredControlExpanded; }
            set
            {
                if (_IsPinRequiredControlExpanded != value)
                {
                    _IsPinRequiredControlExpanded = value;
                    OnPropertyChanged(() => IsPinRequiredControlExpanded, false);
                }
            }
        }

        private bool _IsDoorContactControlExpanded;

        public bool IsDoorContactControlExpanded
        {
            get { return _IsDoorContactControlExpanded; }
            set
            {
                if (_IsDoorContactControlExpanded != value)
                {
                    _IsDoorContactControlExpanded = value;
                    OnPropertyChanged(() => IsDoorContactControlExpanded, false);
                }
            }
        }

        private bool _IsAccessRuleOverrideControlExpanded;

        public bool IsAccessRuleOverrideControlExpanded
        {
            get { return _IsAccessRuleOverrideControlExpanded; }
            set
            {
                if (_IsAccessRuleOverrideControlExpanded != value)
                {
                    _IsAccessRuleOverrideControlExpanded = value;
                    OnPropertyChanged(() => IsAccessRuleOverrideControlExpanded, false);
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

        private bool _IsElevatorControlControlExpanded;

        public bool IsElevatorControlControlExpanded
        {
            get { return _IsElevatorControlControlExpanded; }
            set
            {
                if (_IsElevatorControlControlExpanded != value)
                {
                    _IsElevatorControlControlExpanded = value;
                    OnPropertyChanged(() => IsElevatorControlControlExpanded, false);
                }
            }
        }

        private bool _IsLiquidCrystalDisplayControlExpanded;

        public bool IsLiquidCrystalDisplayControlExpanded
        {
            get { return _IsLiquidCrystalDisplayControlExpanded; }
            set
            {
                if (_IsLiquidCrystalDisplayControlExpanded != value)
                {
                    _IsLiquidCrystalDisplayControlExpanded = value;
                    OnPropertyChanged(() => IsLiquidCrystalDisplayControlExpanded, false);
                }
            }
        }

        private bool _IsPanelOptionsControlExpanded;

        public bool IsPanelOptionsControlExpanded
        {
            get { return _IsPanelOptionsControlExpanded; }
            set
            {
                if (_IsPanelOptionsControlExpanded != value)
                {
                    _IsPanelOptionsControlExpanded = value;
                    OnPropertyChanged(() => IsPanelOptionsControlExpanded, false);
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
        #endregion

        #region Protected Methods
        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(AccessPortal);
        }
        #endregion

        #region Private Methods

        //private async Task FillCommonEditorData()
        //{
        //    IsBusy = true;
        //    var manager = _clientServices.GetManager<AccessPortalManager>();
        //    var parameters = new GetParametersWithPhoto() { UniqueId = AccessPortal.AccessPortalUid, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
        //    if (UseAsyncServiceCalls == false)
        //    {
        //        Task.Run(() =>
        //        {
        //            CommonEditingData = manager.GetAccessPortalGalaxyCommonEditingData(parameters);
        //        }).Wait();
        //    }
        //    else
        //    {
        //        CommonEditingData = await manager.GetAccessPortalGalaxyCommonEditingDataAsync(parameters);
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
            var manager = _clientServices.GetManager<AccessPortalManager>();
            var parameters = new GetParametersWithPhoto() { UniqueId = AccessPortal.AccessPortalUid, 
                //SessionId = _clientServices.UserSessionToken.SessionId,
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId,
            IncludePhoto = true};
            parameters.Options.Add(new KeyValuePair<string, bool>(Common.Constants.GetOptions.IncludeNoSelectionEntry, true));
            //parameters.Options.Add( new KeyValuePair<string, bool>(GetOptions_TimeSchedule.IncludeBlankSchedule, true));
            if (UseAsyncServiceCalls == false)
            {
                Task.Run(() =>
                {
                    PanelSpecificEditingData = manager.GetAccessPortalGalaxyPanelSpecificEditingData(parameters);
                }).Wait();
            }
            else
            {
                PanelSpecificEditingData = await manager.GetAccessPortalGalaxyPanelSpecificEditingDataAsync(parameters);
            }

            if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
            else
            {
                var lcds = PanelSpecificEditingData.LiquidCrystalDisplays.ToList();
                lcds.Add(new LiquidCrystalDisplay() { LiquidCrystalDisplayUid = Guid.Empty, LcdName = CommonResources.Resources.AccessPortalProperties_LiquidCrystalDisplay_None_Text });
                PanelSpecificEditingData.LiquidCrystalDisplays = lcds.OrderBy(i=>i.LcdName).ToList();

                var elevatorRelayChannels = PanelSpecificEditingData.ElevatorRelaysInterfaceBoardSections.ToList();
                elevatorRelayChannels.Add(new GalaxyInterfaceBoardSection() { GalaxyInterfaceBoardSectionUid = Guid.Empty, BoardSectionDescription = CommonResources.Resources.AccessPortalProperties_ElevatorOutputRelayChannel_None_Text });
                PanelSpecificEditingData.ElevatorRelaysInterfaceBoardSections = elevatorRelayChannels.OrderBy(i => i.BoardSectionDescription).ToList();

                foreach (var alertEvent in AccessPortal.AlertEvents)
                    alertEvent.PanelSpecificEditingData = PanelSpecificEditingData;

                PanelSpecificEditingData.TimeSchedulesWithEmpty = PanelSpecificEditingData.TimeSchedules.ToList();
                PanelSpecificEditingData.TimeSchedulesWithEmpty.Insert(0, new TimeSchedule());
            }
            IsBusy = false;
        }

        private async void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                BusyContent = string.Format(CommonResources.Resources.EditAccessPortalView_PleaseWaitWhileISave, AccessPortal.PortalName);

                AccessPortal.EntityIds.Clear();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (ue.Selected || ue.EntityId == AccessPortal.EntityId)
                        AccessPortal.EntityIds.Add(ue.EntityId);
                }

                foreach( var ae in AccessPortal.AlertEvents)
                {
                    if (ae.AccessPortalAlertEventType.CanHaveInputOutputGroupOffset == false && ae.InputOutputGroupAssignmentUid != null)
                        ae.InputOutputGroupAssignmentUid = null;
                }

                IsBusy = true;
                var manager = _clientServices.GetManager<AccessPortalManager>();
                bool isNew = (AccessPortal.AccessPortalUid == Guid.Empty);
                Entities.AccessPortal savedEntity;
                var parameters = new SaveParameters<Entities.AccessPortal>()
                {
                    SavePhoto = true,
                    Data = AccessPortal,
                    //SessionId = _clientServices.UserSessionToken.SessionId,
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                };
                parameters.Options.Add(new KeyValuePair<string,string>(nameof(GalaxySMS.Common.Enums.SaveAccessGroupAccessPortalsOption).ToString(), SaveAccessGroupAccessPortalsOption.CreateMissingItems.ToString()));
                if (UseAsyncServiceCalls == false)
                {
                    savedEntity = manager.SaveAccessPortal(parameters);
                }
                else
                {
                    savedEntity = await manager.SaveAccessPortalAsync(parameters);
                }

                if (savedEntity != null && manager.HasErrors == false)
                {
                    _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.AccessPortal>>>()
                        .Publish(new EntitySavedEventArgs<Entities.AccessPortal>()
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
            return _AccessPortal.IsAnythingDirty();
            //return _AccessPortal.IsDirty;
        }

        private void OnCancelCommandExecute(object arg)
        {
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.AccessPortal>>>().Publish(new OperationCanceledEventArgs<Entities.AccessPortal>()
            {
                Entity = AccessPortal,
                OperationId = InstanceId
            });
        }
        private void OnSelectImageCommandExecute(object obj)
        {
            try
            {
                IDialogService dlgService = new DialogService();
                ImageCaptureControl captureControl = new ImageCaptureControl();
                captureControl.Image = ByteArrayToFromImage.ByteArrayToImage(_AccessPortal.gcsBinaryResource?.BinaryResource);
                captureControl.AutomaticallyScaleDownImage = true;
                captureControl.ScaleToMaximumHeight = 600;
                captureControl.AspectRatio = ImageAspectRatio.Square1X1;
                SetBackgroundSubdued();
                dlgService.ShowRadDialog(captureControl, null, CommonResources.Resources.Dialog_SelectSiteImageTitle);
                ClearBackgroundSubdued();
                if (captureControl.DialogResult == true && captureControl.ImageCroppedAndScaled != null)
                {
                    if (_AccessPortal.gcsBinaryResource == null)
                        _AccessPortal.gcsBinaryResource = new gcsBinaryResource();
                    _AccessPortal.gcsBinaryResource.BinaryResource =
                        ByteArrayToFromImage.ImageToByteArray(captureControl.ImageCroppedAndScaled);
                    _AccessPortal.MakeDirty();
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
            _AccessPortal.MakeDirty();
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