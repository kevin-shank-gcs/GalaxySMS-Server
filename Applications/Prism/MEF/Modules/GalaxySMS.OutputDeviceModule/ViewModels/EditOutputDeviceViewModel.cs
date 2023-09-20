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
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI.Collections;
using GCS.Core.Common.UI.Core;
using GCS.Core.Common.UI.Interfaces;
using GCS.Framework.Imaging;
using Prism.Events;
using Telerik.Windows.Controls.Map;
using Entities = GalaxySMS.Client.Entities;
using CommonResources = GalaxySMS.Resources;

namespace GalaxySMS.OutputDevice.ViewModels
{
    [Export(typeof(EditOutputDeviceViewModel))]
    public class EditOutputDeviceViewModel : ViewModelBase, ISupportsUserEntitySelection
    {
        #region Private Fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        private Entities.OutputDevice _outputDevice;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public EditOutputDeviceViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.OutputDevice entity, Guid instanceId, OutputDeviceGalaxyCommonEditingData commonEditingData)
        {
            IsBusy = true;
            if (instanceId == Guid.Empty)
                InstanceId = Guid.NewGuid();
            else
                InstanceId = instanceId;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            CommonEditingData = commonEditingData;

            _outputDevice = new Entities.OutputDevice(entity) { SiteUid = _clientServices.CurrentSite.SiteUid };

            foreach (var s in OutputDevice.GalaxyOutputDevice.GalaxyOutputDeviceInputSources)
            {
                s.HeaderTitle = $"{s.SourceNumber}";
            }


            //foreach(var props in OutputDevice.OutputDeviceEventProperties)
            //{
            //    props.OutputDeviceAlertEventType = CommonEditingData.AlertEventTypes.FirstOrDefault(t => t.OutputDeviceAlertEventTypeUid == props.OutputDeviceAlertEventTypeUid);
            //}

            Task.Run(async () =>
            {
                //await FillCommonEditorData();
                await FillPanelSpecificEditorData();
            }).Wait();

            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);
            SelectImageCommand = new DelegateCommand<object>(OnSelectImageCommandExecute);
            EntityMapChecked = new DelegateCommand<UserEntitySelect>(OnEntityMapChecked);
            InputOutputGroupChanged = new DelegateCommand<GalaxyOutputDeviceInputSource>(OnInputOutputGroupChanged);
            InputOutputGroupModeChanged = new DelegateCommand<GalaxyOutputDeviceInputSource>(OnInputOutputGroupModeChanged);
            //InputOutputGroupAssignmentChanged = new DelegateCommand<OutputDeviceAlertEvent>(OnInputOutputGroupAssignmentChanged);
            OutputModeChanged = new DelegateCommand<Guid>(OnOutputModeChanged);
            AssignmentSourceIsSelected = new DelegateCommand<object>(OnAssignmentSourceIsSelected);
            ToNotIncludedCommand = new DelegateCommand<GalaxyOutputDeviceInputSource>(OnToNotIncludedCommand, CanExecuteOnToNotIncludedCommand);
            ToIncludedCommand = new DelegateCommand<GalaxyOutputDeviceInputSource>(OnToIncludedCommand, CanExecuteOnToIncludedCommand);
            ToNotIncludedIOGroupCommand = new DelegateCommand<GalaxyOutputDeviceInputSource>(OnToNotIncludedIOGroupCommand, CanExecuteOnToNotIncludedIOGroupCommand);
            ToIncludedIOGroupCommand = new DelegateCommand<GalaxyOutputDeviceInputSource>(OnToIncludedIOGroupCommand, CanExecuteOnToIncludedIOGroupCommand);

            BusyContent = CommonResources.Resources.Common_PleaseWait;
            ViewTitle = CommonResources.Resources.EditOutputDeviceView_ViewTitle;

            IsGalaxyOutputDeviceControlExpanded = true;
            IsEventLogControlExpanded = true;
            IsInputSource1Expanded = true;
            IsInputSource2Expanded = true;
            IsInputSource3Expanded = true;
            IsInputSource4Expanded = true;
            if (UserSessionToken != null)
            {
                UserEntitiesSelectionList = UserSessionToken.GetUserEntitySelectCollection();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (_outputDevice.EntityIds.Contains(ue.EntityId))
                        ue.Selected = true;
                }
            }

            OnOutputModeChanged(entity.GalaxyOutputDevice.GalaxyOutputModeUid);
            foreach (var inputSource in OutputDevice.GalaxyOutputDevice.GalaxyOutputDeviceInputSources)
            {
                OnInputOutputGroupChanged(inputSource);
            }

            this.SelectEntityHeaderText = string.Format(
                CommonResources.Resources.EditOutputDeviceView_EntityMappingTabHeader, EntityAlias);

            this.SelectEntityHeaderToolTip = string.Format(
                CommonResources.Resources.EditOutputDeviceView_EntityMappingTabHeaderToolTip, EntityAliasPlural);
            _outputDevice.CleanAll();
            IsBusy = false;

        }


        private bool CanExecuteOnToIncludedCommand(GalaxyOutputDeviceInputSource obj)
        {
            if (obj == null || obj.SelectedNotIncludedAssignmentSources == null)
            {
                return false;
            }

            return obj.SelectedNotIncludedAssignmentSources.Count != 0;
        }

        private void OnToIncludedCommand(GalaxyOutputDeviceInputSource obj)
        {
            if (obj == null)
                return;

            foreach (var i in obj.SelectedNotIncludedAssignmentSources.ToList())
            {
                obj.InputOutputGroupAssignmentSourcesUsed.Add(i);
                obj.InputOutputGroupAssignmentSourcesNotUsed.Remove(i);
            }
        }

        private bool CanExecuteOnToNotIncludedCommand(GalaxyOutputDeviceInputSource obj)
        {
            if (obj == null || obj.SelectedIncludedAssignmentSources == null)
            {
                return false;
            }
            return obj.SelectedIncludedAssignmentSources.Count != 0;
        }

        private void OnToNotIncludedCommand(GalaxyOutputDeviceInputSource obj)
        {
            if (obj == null)
                return;
            foreach (var i in obj.SelectedIncludedAssignmentSources.ToList())
            {
                obj.InputOutputGroupAssignmentSourcesNotUsed.Add(i);
                obj.InputOutputGroupAssignmentSourcesUsed.Remove(i);
            }
        }

        private bool CanExecuteOnToIncludedIOGroupCommand(GalaxyOutputDeviceInputSource obj)
        {
            if (obj?.SelectedNotIncludedInputOutputGroups == null)
            {
                return false;
            }

            return obj.SelectedNotIncludedInputOutputGroups.Count != 0;
        }

        private void OnToIncludedIOGroupCommand(GalaxyOutputDeviceInputSource obj)
        {
            if (obj == null)
                return;

            foreach (var i in obj.SelectedNotIncludedInputOutputGroups.ToList())
            {
                obj.InputOutputGroupInputOutputGroupsUsed.Add(i);
                obj.InputOutputGroupInputOutputGroupsNotUsed.Remove(i);
            }
        }

        private bool CanExecuteOnToNotIncludedIOGroupCommand(GalaxyOutputDeviceInputSource obj)
        {
            if (obj?.SelectedIncludedInputOutputGroups == null)
            {
                return false;
            }
            return obj.SelectedIncludedInputOutputGroups.Count != 0;
        }

        private void OnToNotIncludedIOGroupCommand(GalaxyOutputDeviceInputSource obj)
        {
            if (obj == null)
                return;
            foreach (var i in obj.SelectedIncludedInputOutputGroups.ToList())
            {
                obj.InputOutputGroupInputOutputGroupsNotUsed.Add(i);
                obj.InputOutputGroupInputOutputGroupsUsed.Remove(i);
            }
        }

        private void OnAssignmentSourceIsSelected(object obj)
        {

        }

        private void OnOutputModeChanged(Guid modeGuid)
        {
            if (modeGuid == GalaxySMS.Common.Constants.GalaxyOutputModeIds.Counter)
            {
                OutputDevice.GalaxyOutputDevice.InputSource1.HeaderTitle = GalaxySMS.Resources.Resources.GalaxyOutput_Counter_IncrementSource_Title;
                OutputDevice.GalaxyOutputDevice.InputSource1.HeaderToolTip = GalaxySMS.Resources.Resources.GalaxyOutput_Counter_IncrementSource_ToolTip;
                OutputDevice.GalaxyOutputDevice.InputSource2.HeaderTitle = GalaxySMS.Resources.Resources.GalaxyOutput_Counter_DecrementSource_Title;
                OutputDevice.GalaxyOutputDevice.InputSource2.HeaderToolTip = GalaxySMS.Resources.Resources.GalaxyOutput_Counter_DecrementSource_ToolTip;
                OutputDevice.GalaxyOutputDevice.InputSource3.HeaderTitle = GalaxySMS.Resources.Resources.GalaxyOutput_Counter_ForceMaxCountSource_Title;
                OutputDevice.GalaxyOutputDevice.InputSource3.HeaderToolTip = GalaxySMS.Resources.Resources.GalaxyOutput_Counter_ForceMaxCountSource_ToolTip;
                OutputDevice.GalaxyOutputDevice.InputSource4.HeaderTitle = GalaxySMS.Resources.Resources.GalaxyOutput_Counter_ResetCountSource_Title;
                OutputDevice.GalaxyOutputDevice.InputSource4.HeaderToolTip = GalaxySMS.Resources.Resources.GalaxyOutput_Counter_ResetCountSource_ToolTip;
            }
            else
            {
                foreach (var s in OutputDevice.GalaxyOutputDevice.GalaxyOutputDeviceInputSources)
                {
                    s.HeaderTitle = $"{Resources.Resources.GalaxyOutput_InputSource_Title} {s.SourceNumber}";
                    s.HeaderToolTip = string.Format(Resources.Resources.GalaxyOutput_InputSource_ToolTip);
                }
            }
        }

        private async void OnInputOutputGroupChanged(GalaxyOutputDeviceInputSource obj)
        {
            if (obj != null)
            {
                BusyContent = string.Empty;//string.Format(CommonResources.Resources.EditOutputDeviceView_PleaseWaitWhileISave, OutputDevice.OutputName);

                IsBusy = true;
                //if (obj.InputOutputGroupMode == false)
                //{
                    var manager = _clientServices.GetManager<GalaxyInputOutputGroupManager>();

                    obj.SelectedIncludedAssignmentSources = new ObservableCollection<InputOutputGroupAssignmentSource>();
                    obj.SelectedNotIncludedAssignmentSources = new ObservableCollection<InputOutputGroupAssignmentSource>();

                    obj.InputOutputGroupAssignmentSourcesNotUsed = new ObservableCollection<InputOutputGroupAssignmentSource>();
                    obj.InputOutputGroupAssignmentSourcesUsed = new ObservableCollection<InputOutputGroupAssignmentSource>();
                    var noIoGroup = this.DeviceSpecificEditingData.InputOutputGroups.FirstOrDefault(o => o.IOGroupNumber == InputOutputGroupLimits.None);
                    if (noIoGroup != null && obj.InputOutputGroupUid != noIoGroup.InputOutputGroupUid)
                    {
                        var parameters = new GetParametersWithPhoto() { UniqueId = obj.InputOutputGroupUid, GetGuid = OutputDevice.GalaxyPanelUid};
                        if (UseAsyncServiceCalls == false)
                        {
                            obj.InputOutputGroupAssignmentSourcesNotUsed = manager.GetInputOutputGroupAssignmentSourcesForInputOutputGroup(parameters).ToObservableCollection();
                        }
                        else
                        {
                            var t = await manager.GetInputOutputGroupAssignmentSourcesForInputOutputGroupAsync(parameters);
                            obj.InputOutputGroupAssignmentSourcesNotUsed = t.ToObservableCollection();
                        }

                        if (manager.HasErrors)
                        {
                            AddCustomErrors(manager.Errors, true);
                        }
                        else
                        {
                            var usedItems = obj.InputOutputGroupAssignmentSourcesNotUsed.Where(a => obj.GalaxyOutputDeviceInputSourceAssignments.Any(b => b.InputOutputGroupAssignmentUid == a.InputOutputGroupAssignmentUid));
                            obj.InputOutputGroupAssignmentSourcesUsed = usedItems.ToObservableCollection();
                            foreach(var o in obj.InputOutputGroupAssignmentSourcesUsed)
                                obj.InputOutputGroupAssignmentSourcesNotUsed.Remove(o);
                        }
                    }
                //}
                //else
                //{   // Input-Output Group Mode == true
                    obj.SelectedIncludedInputOutputGroups = new ObservableCollection<InputOutputGroup>();
                    obj.SelectedNotIncludedInputOutputGroups = new ObservableCollection<InputOutputGroup>();

                    obj.InputOutputGroupInputOutputGroupsNotUsed = new ObservableCollection<InputOutputGroup>();
                    obj.InputOutputGroupInputOutputGroupsUsed = new ObservableCollection<InputOutputGroup>();
                    var noIOGroup = this.DeviceSpecificEditingData.InputOutputGroups.FirstOrDefault(o => o.IOGroupNumber == InputOutputGroupLimits.None);
                    var selectedIOGroup = this.DeviceSpecificEditingData.InputOutputGroups.FirstOrDefault(o => o.InputOutputGroupUid == obj.InputOutputGroupUid);
                    if (noIOGroup != null && obj.InputOutputGroupUid != noIOGroup.InputOutputGroupUid && selectedIOGroup != null)
                    {
                        obj.InputOutputGroupInputOutputGroupsNotUsed = DeviceSpecificEditingData.InputOutputGroups.Where(o => o.IOGroupNumber >= selectedIOGroup.IOGroupNumber && o.IOGroupNumber < (selectedIOGroup.IOGroupNumber + 32)).ToObservableCollection();

                        var usedItems = obj.InputOutputGroupInputOutputGroupsNotUsed.Where(a => obj.GalaxyOutputDeviceInputSourceInputOutputGroups.Any(b => b.InputOutputGroupUid == a.InputOutputGroupUid));
                        obj.InputOutputGroupInputOutputGroupsUsed = usedItems.ToObservableCollection();
                        foreach (var o in obj.InputOutputGroupInputOutputGroupsUsed)
                            obj.InputOutputGroupInputOutputGroupsNotUsed.Remove(o);
                    }

                //}
                IsBusy = false;
            }
        }

        private async void OnInputOutputGroupModeChanged(GalaxyOutputDeviceInputSource obj)
        {
            if (obj != null)
            {
                //var iog = this.DeviceSpecificEditingData.InputOutputGroups.FirstOrDefault(g => g.InputOutputGroupUid == obj.InputOutputGroupUid);
                //if (iog != null)
                //{
                //    if (obj.OutputDeviceAlertEventType.CanHaveInputOutputGroupOffset && obj.InputOutputGroupAssignmentUid.HasValue == false)
                //    {
                //        obj.InputOutputGroupAssignmentUid = Guid.Empty;
                //    }
                //}
            }
        }

        //private void OnInputOutputGroupAssignmentChanged(OutputDeviceAlertEvent obj)
        //{
        //    if (obj != null)
        //    {
        //        var iog = this.DeviceSpecificEditingData.InputOutputGroups.FirstOrDefault(g => g.InputOutputGroupUid == obj.InputOutputGroupUid);
        //        if (iog != null)
        //        {
        //            // Mark the newly selected Assignment as Earmarked so that it cannot be selected for another event
        //            var iogass = iog.InputOutputGroupAssignments.FirstOrDefault(i => i.InputOutputGroupAssignmentUid == obj.InputOutputGroupAssignmentUid && i.OutputDeviceAlertEventUid != obj.OutputDeviceAlertEventUid);
        //            if (iogass != null)
        //            {
        //                iogass.IsEarmarked = true;
        //                iogass.OutputDeviceAlertEventUid = obj.OutputDeviceAlertEventUid;
        //                iog.NotifyAvailableInputOutputGroupAssignments();
        //            }

        //            var previousIogass = iog.InputOutputGroupAssignments.FirstOrDefault(i => i.OutputDeviceAlertEventUid == obj.OutputDeviceAlertEventUid && i.InputOutputGroupAssignmentUid != obj.InputOutputGroupAssignmentUid);
        //            if (previousIogass != null)
        //            {
        //                previousIogass.IsEarmarked = false;
        //                previousIogass.OutputDeviceAlertEventUid = Guid.Empty;
        //                iog.NotifyAvailableInputOutputGroupAssignments();
        //            }
        //        }
        //    }
        //}


        #endregion

        #region Public Commands
        public DelegateCommand<object> SaveCommand { get; private set; }

        public DelegateCommand<object> CancelCommand { get; private set; }

        public DelegateCommand<object> SelectImageCommand { get; private set; }
        public DelegateCommand<UserEntitySelect> EntityMapChecked { get; set; }

        public DelegateCommand<Guid> OutputModeChanged { get; set; }

        public DelegateCommand<object> AssignmentSourceIsSelected { get; set; }

        public DelegateCommand<GalaxyOutputDeviceInputSource> InputOutputGroupChanged { get; set; }
        public DelegateCommand<GalaxyOutputDeviceInputSource> InputOutputGroupModeChanged { get; set; }
        //public DelegateCommand<GalaxyOutputDeviceInputSource> InputOutputGroupAssignmentChanged { get; set; }
        public DelegateCommand<GalaxyOutputDeviceInputSource> ToNotIncludedCommand { get; set; }
        public DelegateCommand<GalaxyOutputDeviceInputSource> ToIncludedCommand { get; set; }
        public DelegateCommand<GalaxyOutputDeviceInputSource> ToNotIncludedIOGroupCommand { get; set; }
        public DelegateCommand<GalaxyOutputDeviceInputSource> ToIncludedIOGroupCommand { get; set; }

        #endregion

        #region Public Properties
        public Entities.OutputDevice OutputDevice
        {
            get { return _outputDevice; }
        }

        public Guid InstanceId { get; }

        private OutputDeviceGalaxyCommonEditingData _commonEditingData;

        public OutputDeviceGalaxyCommonEditingData CommonEditingData
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

        private OutputDeviceHardwareSpecificEditingData _deviceSpecificEditingData;

        public OutputDeviceHardwareSpecificEditingData DeviceSpecificEditingData
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

        private bool _IsGalaxyOutputDeviceControlExpanded;

        public bool IsGalaxyOutputDeviceControlExpanded
        {
            get { return _IsGalaxyOutputDeviceControlExpanded; }
            set
            {
                if (_IsGalaxyOutputDeviceControlExpanded != value)
                {
                    _IsGalaxyOutputDeviceControlExpanded = value;
                    OnPropertyChanged(() => IsGalaxyOutputDeviceControlExpanded, false);
                }
            }
        }


        private bool _IsInputSource1Expanded;

        public bool IsInputSource1Expanded
        {
            get { return _IsInputSource1Expanded; }
            set
            {
                if (_IsInputSource1Expanded != value)
                {
                    _IsInputSource1Expanded = value;
                    OnPropertyChanged(() => IsInputSource1Expanded, false);
                }
            }
        }

        private bool _IsInputSource2Expanded;

        public bool IsInputSource2Expanded
        {
            get { return _IsInputSource2Expanded; }
            set
            {
                if (_IsInputSource2Expanded != value)
                {
                    _IsInputSource2Expanded = value;
                    OnPropertyChanged(() => IsInputSource2Expanded, false);
                }
            }
        }


        private bool _IsInputSource3Expanded;

        public bool IsInputSource3Expanded
        {
            get { return _IsInputSource3Expanded; }
            set
            {
                if (_IsInputSource3Expanded != value)
                {
                    _IsInputSource3Expanded = value;
                    OnPropertyChanged(() => IsInputSource3Expanded, false);
                }
            }
        }


        private bool _IsInputSource4Expanded;

        public bool IsInputSource4Expanded
        {
            get { return _IsInputSource4Expanded; }
            set
            {
                if (_IsInputSource4Expanded != value)
                {
                    _IsInputSource4Expanded = value;
                    OnPropertyChanged(() => IsInputSource4Expanded, false);
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

        #endregion

        #region Protected Methods
        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(OutputDevice);
        }
        #endregion

        #region Private Methods

        //private async Task FillCommonEditorData()
        //{
        //    IsBusy = true;
        //    var manager = _clientServices.GetManager<OutputDeviceManager>();
        //    var parameters = new GetParametersWithPhoto() { UniqueId = OutputDevice.OutputDeviceUid, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
        //    if (UseAsyncServiceCalls == false)
        //    {
        //        Task.Run(() =>
        //        {
        //            CommonEditingData = manager.GetOutputDeviceGalaxyCommonEditingData(parameters);
        //        }).Wait();
        //    }
        //    else
        //    {
        //        CommonEditingData = await manager.GetOutputDeviceGalaxyCommonEditingDataAsync(parameters);
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
            var manager = _clientServices.GetManager<OutputDeviceManager>();
            var parameters = new GetParametersWithPhoto()
            {
                UniqueId = OutputDevice.OutputDeviceUid,
                //SessionId = _clientServices.UserSessionToken.SessionId,
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId,
                IncludePhoto = true
            };
            parameters.Options.Add(new KeyValuePair<string, bool>(Common.Constants.GetOptions.IncludeNoSelectionEntry, true));

            if (UseAsyncServiceCalls == false)
            {
                Task.Run(() =>
                {
                    DeviceSpecificEditingData = manager.GetOutputDeviceHardwareSpecificEditingData(parameters);
                }).Wait();
            }
            else
            {
                DeviceSpecificEditingData = await manager.GetOutputDeviceHardwareSpecificEditingDataAsync(parameters);
            }

            if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
            else
            {
                //var lcds = DeviceSpecificEditingData.LiquidCrystalDisplays.ToList();
                //lcds.Add(new LiquidCrystalDisplay() { LiquidCrystalDisplayUid = Guid.Empty, LcdName = CommonResources.Resources.OutputDeviceProperties_LiquidCrystalDisplay_None_Text });
                //DeviceSpecificEditingData.LiquidCrystalDisplays = lcds.OrderBy(i=>i.LcdName).ToList();

                //var elevatorRelayChannels = DeviceSpecificEditingData.ElevatorRelaysInterfaceBoardSections.ToList();
                //elevatorRelayChannels.Add(new GalaxyInterfaceBoardSection() { GalaxyInterfaceBoardSectionUid = Guid.Empty, BoardSectionDescription = CommonResources.Resources.OutputDeviceProperties_ElevatorOutputRelayChannel_None_Text });
                //DeviceSpecificEditingData.ElevatorRelaysInterfaceBoardSections = elevatorRelayChannels.OrderBy(i => i.BoardSectionDescription).ToList();

                //foreach (var alertEvent in OutputDevice.GalaxyOutputDevice.AlertEvents)
                //    alertEvent.PanelSpecificEditingData = DeviceSpecificEditingData;

                //foreach (var props in OutputDevice.OutputDeviceEventProperties)
                //    props.PanelSpecificEditingData = DeviceSpecificEditingData;
            }
            IsBusy = false;
        }

        private async void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                BusyContent = string.Format(CommonResources.Resources.EditOutputDeviceView_PleaseWaitWhileISave, OutputDevice.OutputName);

                OutputDevice.EntityIds.Clear();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (ue.Selected || ue.EntityId == OutputDevice.EntityId)
                        OutputDevice.EntityIds.Add(ue.EntityId);
                }

                foreach (var inputSource in OutputDevice.GalaxyOutputDevice.GalaxyOutputDeviceInputSources)
                {
                    if (!inputSource.InputOutputGroupMode)
                    {
                        inputSource.GalaxyOutputDeviceInputSourceInputOutputGroups.RemoveAll();

                        // Start by removing all that are in the not in the inputSource.InputOutputGroupAssignmentSourcesUsed collection
                        foreach (var existingAssignment in inputSource.GalaxyOutputDeviceInputSourceAssignments.ToList())
                        {
                            var existingInputSourceAssignment = inputSource.InputOutputGroupAssignmentSourcesUsed.FirstOrDefault(o => o.InputOutputGroupAssignmentUid == existingAssignment.InputOutputGroupAssignmentUid);
                            if (existingInputSourceAssignment == null)
                                inputSource.GalaxyOutputDeviceInputSourceAssignments.Remove(existingAssignment);
                        }

                        // Now make sure that all the ones from the used collection are in the inputSource.GalaxyOutputDeviceInputSourceAssignments collection
                        foreach (var usedAssignment in inputSource.InputOutputGroupAssignmentSourcesUsed)
                        {
                            var existingAssignment = inputSource.GalaxyOutputDeviceInputSourceAssignments.FirstOrDefault(o => o.InputOutputGroupAssignmentUid == usedAssignment.InputOutputGroupAssignmentUid);
                            if (existingAssignment == null)
                            {
                                inputSource.GalaxyOutputDeviceInputSourceAssignments.Add(new GalaxyOutputDeviceInputSourceAssignment()
                                {
                                    InputOutputGroupAssignmentUid = usedAssignment.InputOutputGroupAssignmentUid,
                                });
                            }
                        }
                    }
                    else
                    {
                        inputSource.GalaxyOutputDeviceInputSourceAssignments.RemoveAll();

                        // Start by removing all that are in the not in the inputSource.InputOutputGroupInputOutputGroupsUsed collection
                        foreach (var existingIoGroup in inputSource.GalaxyOutputDeviceInputSourceInputOutputGroups.ToList())
                        {
                            var existingInputOutputGroup = inputSource.InputOutputGroupInputOutputGroupsUsed.FirstOrDefault(o => o.InputOutputGroupUid == existingIoGroup.InputOutputGroupUid);
                            if (existingInputOutputGroup == null)
                            {
                                var godisiog = inputSource.GalaxyOutputDeviceInputSourceInputOutputGroups.FirstOrDefault(o => o.InputOutputGroupUid == existingIoGroup.InputOutputGroupUid);
                                if (godisiog != null)
                                    inputSource.GalaxyOutputDeviceInputSourceInputOutputGroups.Remove(godisiog);
                            }
                        }

                        // Now make sure that all the ones from the used collection are in the inputSource.GalaxyOutputDeviceInputSourceInputOutputGroups collection
                        foreach (var usedInputOutputGroup in inputSource.InputOutputGroupInputOutputGroupsUsed)
                        {
                            var existingInputOutputGroup = inputSource.GalaxyOutputDeviceInputSourceInputOutputGroups.FirstOrDefault(o => o.InputOutputGroupUid == usedInputOutputGroup.InputOutputGroupUid);
                            if (existingInputOutputGroup == null)
                            {
                                inputSource.GalaxyOutputDeviceInputSourceInputOutputGroups.Add(new GalaxyOutputDeviceInputSourceInputOutputGroup()
                                {
                                    InputOutputGroupUid = usedInputOutputGroup.InputOutputGroupUid,
                                });
                            }
                        }

                    }
                }


                IsBusy = true;
                var manager = _clientServices.GetManager<OutputDeviceManager>();
                bool isNew = (OutputDevice.OutputDeviceUid == Guid.Empty);
                Entities.OutputDevice savedEntity;
                var parameters = new SaveParameters<Entities.OutputDevice>()
                {
                    SavePhoto = true,
                    Data = OutputDevice,
                    //SessionId = _clientServices.UserSessionToken.SessionId,
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                };
                if (UseAsyncServiceCalls == false)
                {
                    savedEntity = manager.SaveOutputDevice(parameters);
                }
                else
                {
                    savedEntity = await manager.SaveOutputDeviceAsync(parameters);
                }

                if (savedEntity != null && manager.HasErrors == false)
                {
                    _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.OutputDevice>>>()
                        .Publish(new EntitySavedEventArgs<Entities.OutputDevice>()
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
            return _outputDevice.IsAnythingDirty();
            //return _OutputDevice.IsDirty;
        }

        private void OnCancelCommandExecute(object arg)
        {
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.OutputDevice>>>().Publish(new OperationCanceledEventArgs<Entities.OutputDevice>()
            {
                Entity = OutputDevice,
                OperationId = InstanceId
            });
        }
        private void OnSelectImageCommandExecute(object obj)
        {
            try
            {
                IDialogService dlgService = new DialogService();
                ImageCaptureControl captureControl = new ImageCaptureControl();
                captureControl.Image = ByteArrayToFromImage.ByteArrayToImage(_outputDevice.gcsBinaryResource?.BinaryResource);
                captureControl.AutomaticallyScaleDownImage = true;
                captureControl.ScaleToMaximumHeight = 600;
                captureControl.AspectRatio = ImageAspectRatio.Square1X1;
                SetBackgroundSubdued();
                dlgService.ShowRadDialog(captureControl, null, CommonResources.Resources.Dialog_SelectSiteImageTitle);
                ClearBackgroundSubdued();
                if (captureControl.DialogResult == true && captureControl.ImageCroppedAndScaled != null)
                {
                    if (_outputDevice.gcsBinaryResource == null)
                        _outputDevice.gcsBinaryResource = new gcsBinaryResource();
                    _outputDevice.gcsBinaryResource.BinaryResource =
                        ByteArrayToFromImage.ImageToByteArray(captureControl.ImageCroppedAndScaled);
                    _outputDevice.MakeDirty();
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
            _outputDevice.MakeDirty();
        }

        #region Implementation of ISupportsUserEntitySelection

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