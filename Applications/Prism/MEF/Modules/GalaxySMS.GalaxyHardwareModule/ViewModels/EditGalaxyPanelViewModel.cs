using GalaxySMS.Client.Contracts.ViewModelContracts;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using GalaxySMS.Prism.Infrastructure;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.Logger;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Windows.Controls;
using CommonResources = GalaxySMS.Resources;
using Entities = GalaxySMS.Client.Entities;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;

namespace GalaxySMS.GalaxyHardware.ViewModels
{
    [Export(typeof(EditGalaxyPanelViewModel))]
    public class EditGalaxyPanelViewModel : ViewModelBase, ISupportsUserEntitySelection
    {
        #region Private Fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        private GalaxyPanel _galaxyPanel;
        private ObservableCollection<GalaxyPanel> _galaxyPanels;
        private GalaxyPanelEditingData _galaxyPanelEditingData;
        private GalaxyInterfaceBoard _deleteThisGalaxyInterfaceBoard;

        private bool _isBasicInfoExpanded = true;

        #endregion

        #region Constructors
        [ImportingConstructor]
        public EditGalaxyPanelViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.GalaxyPanel entity, Guid instanceId)
        {
            IsBusy = true;
            if (instanceId == Guid.Empty)
                InstanceId = Guid.NewGuid();
            else
                InstanceId = instanceId;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            _galaxyPanel = new Entities.GalaxyPanel(entity);

            Task.Run(async () =>
            {
                await FillEditorData();
            }).Wait();
            _galaxyPanel.CleanAll();

            SaveCommand = new GCS.Core.Common.UI.Core.DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new GCS.Core.Common.UI.Core.DelegateCommand<object>(OnCancelCommandExecute);
            EntityMapChecked = new GCS.Core.Common.UI.Core.DelegateCommand<UserEntitySelect>(OnEntityMapChecked);
            AddNewInterfaceBoardCommand = new GCS.Core.Common.UI.Core.DelegateCommand<object>(OnAddNewInterfaceBoardCommandExecute, OnAddNewInterfaceBoardCommandCanExecute);
            RefreshInterfaceBoardsCommand = new GCS.Core.Common.UI.Core.DelegateCommand<object>(OnRefreshInterfaceBoardsCommandExecute, OnRefreshInterfaceBoardsCommandCanExecute);
            RequestInterfaceBoardsFromPanelCommand = new GCS.Core.Common.UI.Core.DelegateCommand<object>(OnRequestInterfaceBoardsFromPanelCommandExecute, OnRequestInterfaceBoardsFromPanelCommandCanExecute);
            RequestRS485BusDeviceInfoFromPanelCommand = new GCS.Core.Common.UI.Core.DelegateCommand<GalaxyInterfaceBoardSection>(OnRequestRS485BusDeviceInfoFromPanelCommand, OnRequestRS485BusDeviceInfoFromPanelCommandCanExecute);

            DeleteInterfaceBoardCommand = new GCS.Core.Common.UI.Core.DelegateCommand<GalaxyInterfaceBoard>(OnDeleteInterfaceBoardsCommandExecute, OnDeleteInterfaceBoardsCommandCanExecute);
            PanelModelSelectionChangedCommand = new GCS.Core.Common.UI.Core.DelegateCommand<Entities.GalaxyPanelModel>(OnPanelModelSelectionChangedCommandExecute);
            //            InterfaceBoardTypeSelectionChangedCommand = new DelegateCommand<InterfaceBoardType>(OnInterfaceBoardTypeSelectionChangedCommandExecute);
            InterfaceBoardTypeSelectionChangedCommand = new GCS.Core.Common.UI.Core.DelegateCommand<GalaxyInterfaceBoard>(OnInterfaceBoardTypeSelectionChangedCommandExecute);
            InterfaceBoardSectionModeSelectionChangedCommand = new GCS.Core.Common.UI.Core.DelegateCommand<GalaxyInterfaceBoardSection>(OnInterfaceBoardSectionModeSelectionChangedCommandExecute);

            IsNodeActiveHeaderUnCheckedCommand = new GCS.Core.Common.UI.Core.DelegateCommand<IEnumerable<GalaxyInterfaceBoardSectionNode>>(OnIsNodeActiveHeaderUnCheckedCommandExecute);
            IsNodeActiveHeaderCheckedCommand = new GCS.Core.Common.UI.Core.DelegateCommand<IEnumerable<GalaxyInterfaceBoardSectionNode>>(OnIsNodeActiveHeaderCheckedCommandExecute);

            IsNodeActiveCheckedCommand = new GCS.Core.Common.UI.Core.DelegateCommand<GalaxyInterfaceBoardSectionNode>(OnIsNodeActiveCheckedCommandExecute);

            IsModuleActiveHeaderUnCheckedCommand = new GCS.Core.Common.UI.Core.DelegateCommand<IEnumerable<GalaxySMS.Client.Entities.GalaxyHardwareModule>>(OnIsModuleActiveHeaderUnCheckedCommandExecute);
            IsModuleActiveHeaderCheckedCommand = new GCS.Core.Common.UI.Core.DelegateCommand<IEnumerable<GalaxySMS.Client.Entities.GalaxyHardwareModule>>(OnIsModuleActiveHeaderCheckedCommandExecute);

            IsModuleActiveCheckedCommand = new GCS.Core.Common.UI.Core.DelegateCommand<GalaxySMS.Client.Entities.GalaxyHardwareModule>(OnIsModuleActiveCheckedCommandExecute);

            LoadInterfaceBoardSectionCommand = new GCS.Core.Common.UI.Core.DelegateCommand<GalaxyInterfaceBoardSection>(OnLoadInterfaceBoardSectionCommandExecute, OnLoadInterfaceBoardSectionCommandCanExecute);

            InputOutputGroupChanged = new GCS.Core.Common.UI.Core.DelegateCommand<GalaxyPanelAlertEvent>(OnInputOutputGroupChanged);
            InputOutputGroupAssignmentChanged = new GCS.Core.Common.UI.Core.DelegateCommand<GalaxyPanelAlertEvent>(OnInputOutputGroupAssignmentChanged);

            _eventAggregator.GetEvent<PubSubEvent<PanelBoardInformationCollection>>().Subscribe(PanelBoardInformationCollectionReceived);
            _eventAggregator.GetEvent<PubSubEvent<SerialChannelGalaxyDoorModuleDataCollection>>().Subscribe(SerialChannelGalaxyDoorModuleDataCollectionReceived);
            _eventAggregator.GetEvent<PubSubEvent<SerialChannelGalaxyInputModuleDataCollection>>().Subscribe(SerialChannelGalaxyInputModuleDataCollectionReceived);

            IsSaveControlVisible = true;
            IsCancelControlVisible = true;
            IsAddNewInterfaceBoardControlVisible = true;
            IsRefreshInterfaceBoardsControlVisible = true;
            IsDeleteInterfaceBoardControlVisible = true;
            IsLoadInterfaceBoardSectionControlVisible = true;
            IsRequestInterfaceBoardsFromPanelControlVisible = true;
            IsRequestRS485BusDeviceInfoFromPanelControlVisible = true;

            BusyContent = CommonResources.Resources.Common_PleaseWait;
            ViewTitle = CommonResources.Resources.EditGalaxyPanelView_ViewTitle;
            CurrentItemTitle = _galaxyPanel.PanelName;

            IsBusy = false;
        }



        private void PanelBoardInformationCollectionReceived(PanelBoardInformationCollection obj)
        {
            if (obj == null || obj.PanelUid != GalaxyPanel.GalaxyPanelUid)
                return;

            foreach (var b in obj.Boards)
            {
                var boardTypeUid = Guid.Empty;
                switch (b.FlashPackage)
                {
                    case GalaxyInterfaceBoardType.None:
                    case GalaxyInterfaceBoardType.DualPortInterfaceBoard500:
                    case GalaxyInterfaceBoardType.Cpu600:
                    case GalaxyInterfaceBoardType.Cpu635:
                        boardTypeUid = Guid.Empty;
                        break;

                    case GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
                        boardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface600;
                        break;

                    case GalaxyInterfaceBoardType.DigitalInputOutputBoard600:
                        boardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DigitalInputOutput600;
                        break;

                    //case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                    //    boardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface600;
                    //    break;

                    case GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
                        boardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635;
                        break;

                    case GalaxyInterfaceBoardType.OtisElevatorInterface:
                        boardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_OtisElevatorInterface;
                        break;

                    //case GalaxyInterfaceBoardType.CardTourManagerCpu:
                    //    boardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_CardTourManager;
                    //    break;

                    case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                        boardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface635;
                        break;

                    case GalaxyInterfaceBoardType.KoneElevatorInterface:
                        boardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_KoneElevatorInterface;
                        break;


                    case GalaxyInterfaceBoardType.Veridt_Cpu:
                        boardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_Cpu;
                        break;


                    case GalaxyInterfaceBoardType.Veridt_ReaderModule:
                        boardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_ReaderModule;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                var existingBoard = GalaxyPanel.InterfaceBoards.FirstOrDefault(o => o.BoardNumber == b.BoardNumber);
                if (existingBoard == null)
                {
                    var o = new Entities.GalaxyInterfaceBoard
                    {
                        GalaxyPanelUid = this.GalaxyPanel.GalaxyPanelUid,
                        BoardNumber = b.BoardNumber,
                        InterfaceBoardTypeUid = boardTypeUid,
                    };
                    OnInterfaceBoardTypeSelectionChangedCommandExecute(o);
                    GalaxyPanel.InterfaceBoards.Add(o);
                }
                else if (existingBoard.InterfaceBoardTypeUid != boardTypeUid)
                {

                }

            }
        }


        private void SerialChannelGalaxyDoorModuleDataCollectionReceived(SerialChannelGalaxyDoorModuleDataCollection obj)
        {
            if (obj == null ||
                obj.PanelUid != GalaxyPanel.GalaxyPanelUid ||
                SelectedInterfaceBoardSection == null ||
                !SelectedInterfaceBoardSection.DoesHardwareAddressMatch(obj.ClusterGroupId, obj.ClusterNumber, obj.PanelNumber, obj.BoardNumber, obj.SectionNumber))
                return;

            foreach (var m in obj.Modules)
            {
                var n = SelectedInterfaceBoardSection.GalaxyInterfaceBoardSectionNodes.FirstOrDefault(o => o.NodeNumber == m.NodeNumber);
                if (n != null)
                    n.SerialChannelDoorModuleData = m;
            }
        }

        private void SerialChannelGalaxyInputModuleDataCollectionReceived(SerialChannelGalaxyInputModuleDataCollection obj)
        {
            if (obj == null ||
                obj.PanelUid != GalaxyPanel.GalaxyPanelUid ||
                SelectedInterfaceBoardSection == null ||
                !SelectedInterfaceBoardSection.DoesHardwareAddressMatch(obj.ClusterGroupId, obj.ClusterNumber, obj.PanelNumber, obj.BoardNumber, obj.SectionNumber))
                return;

            foreach (var m in obj.Modules)
            {
                var n = SelectedInterfaceBoardSection.GalaxyHardwareModules.FirstOrDefault(o => o.ModuleNumber == m.ModuleNumber);
                if (n != null)
                    n.SerialChannelInputModuleData = m;
            }

        }
        private void OnIsModuleActiveHeaderCheckedCommandExecute(IEnumerable<GalaxySMS.Client.Entities.GalaxyHardwareModule> modules)//InterfaceBoardType obj)
        {
            foreach (var m in modules)
                m.IsModuleActive = true;
        }

        private void OnIsModuleActiveHeaderUnCheckedCommandExecute(IEnumerable<GalaxySMS.Client.Entities.GalaxyHardwareModule> modules)//InterfaceBoardType obj)
        {
            foreach (var m in modules)
                m.IsModuleActive = false;
        }

        private void OnIsModuleActiveCheckedCommandExecute(Entities.GalaxyHardwareModule obj)
        {
            if (obj == null)
                return;
            if (obj.GalaxyHardwareModuleTypeUid == GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_InputModule16)
            {
                foreach (var n in obj.GalaxyInterfaceBoardSectionNodes)
                    n.IsNodeActive = obj.IsModuleActive;
            }
        }

        private void OnIsNodeActiveCheckedCommandExecute(GalaxyInterfaceBoardSectionNode node)
        {

        }

        private void OnIsNodeActiveHeaderCheckedCommandExecute(IEnumerable<GalaxyInterfaceBoardSectionNode> nodes)//InterfaceBoardType obj)
        {
            foreach (var n in nodes)
                n.IsNodeActive = true;
        }

        private void OnIsNodeActiveHeaderUnCheckedCommandExecute(IEnumerable<GalaxyInterfaceBoardSectionNode> nodes)//InterfaceBoardType obj)
        {
            foreach (var n in nodes)
                n.IsNodeActive = false;
        }

        private void OnInterfaceBoardTypeSelectionChangedCommandExecute(GalaxyInterfaceBoard obj)//InterfaceBoardType obj)
        {
            try
            {
                var boardType = this.GalaxyPanelEditingData.InterfaceBoardTypes.FirstOrDefault(o => o.InterfaceBoardTypeUid == obj.InterfaceBoardTypeUid);
                if (boardType == null)
                    return;


                if (obj != null)
                {
                    var copyOfOriginal = obj.Clone(obj);
                    obj.CreateSections(boardType);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }
        }

        private void OnInterfaceBoardSectionModeSelectionChangedCommandExecute(GalaxyInterfaceBoardSection obj)
        {
            try
            {
                var boardSectionMode = this.GalaxyPanelEditingData.InterfaceBoardSectionModes.FirstOrDefault(o => o.InterfaceBoardSectionModeUid == obj.InterfaceBoardSectionModeUid);
                if (boardSectionMode == null)
                    return;

                if (obj != null)
                {
                    var copyOfOriginal = obj.Clone(obj);
                    obj.CreateModules(boardSectionMode);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }

        }

        private void OnPanelModelSelectionChangedCommandExecute(Entities.GalaxyPanelModel obj)
        {
            if (obj != null)
                this.GalaxyPanelEditingData.ShowDataForPanelModel = obj.GalaxyPanelModelUid;
        }



        private void OnInputOutputGroupChanged(GalaxyPanelAlertEvent obj)
        {
            if (obj != null && obj.GalaxyPanelAlertEventType != null)
            {
                var iog = this.GalaxyPanelEditingData.InputOutputGroups.FirstOrDefault(g => g.InputOutputGroupUid == obj.InputOutputGroupUid);
                if (iog != null)
                {
                    if (obj.GalaxyPanelAlertEventType.CanHaveInputOutputGroupOffset && obj.InputOutputGroupAssignmentUid.HasValue == false)
                    {
                        obj.InputOutputGroupAssignmentUid = Guid.Empty;
                    }
                }
            }
        }

        private void OnInputOutputGroupAssignmentChanged(GalaxyPanelAlertEvent obj)
        {
            if (obj != null)
            {
                var iog = this.GalaxyPanelEditingData.InputOutputGroups.FirstOrDefault(g => g.InputOutputGroupUid == obj.InputOutputGroupUid);
                if (iog != null)
                {
                    // Mark the newly selected Assignment as Earmarked so that it cannot be selected for another event
                    var iogass = iog.InputOutputGroupAssignments.FirstOrDefault(i => i.InputOutputGroupAssignmentUid == obj.InputOutputGroupAssignmentUid && i.GalaxyPanelAlertEventUid != obj.GalaxyPanelAlertEventUid);
                    if (iogass != null)
                    {
                        iogass.IsEarmarked = true;
                        iogass.GalaxyPanelAlertEventUid = obj.GalaxyPanelAlertEventUid;
                        iog.NotifyAvailableInputOutputGroupAssignments();
                    }

                    var previousIogass = iog.InputOutputGroupAssignments.FirstOrDefault(i => i.GalaxyPanelAlertEventUid == obj.GalaxyPanelAlertEventUid && i.InputOutputGroupAssignmentUid != obj.InputOutputGroupAssignmentUid);
                    if (previousIogass != null)
                    {
                        previousIogass.IsEarmarked = false;
                        previousIogass.GalaxyPanelAlertEventUid = Guid.Empty;
                        iog.NotifyAvailableInputOutputGroupAssignments();
                    }
                }
            }
        }



        private bool OnDeleteInterfaceBoardsCommandCanExecute(GalaxyInterfaceBoard obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanDeleteId) &&
                    obj != null &&
                //obj?.Region.EntityId == _clientServices.CurrentEntityId; 
                //obj?.EntityId == _clientServices.CurrentEntityId && 
                IsDeleteInterfaceBoardControlVisible;
        }

        private async void OnLoadInterfaceBoardSectionCommandExecute(GalaxyInterfaceBoardSection obj)
        {
            //BusyContent = string.Format(CommonResources.Resources.EditGalaxyPanelView_PleaseWaitWhileISave, GalaxyPanel.PanelName);

            IsBusy = true;
            var manager = _clientServices.GetManager<GalaxyPanelCommunicationManager>();
            var parameters = new SendDataParameters<GalaxyInterfaceBoardSection_PanelLoadData>()
            {
                PopulateDataFromDatabase = true,
                //SessionId = _clientServices.UserSessionToken.SessionId,
            };
            parameters.Data.GalaxyInterfaceBoardSectionUid = obj.GalaxyInterfaceBoardSectionUid;
            SendDataResponse<GalaxyInterfaceBoardSection_PanelLoadData> response = null;
            if (UseAsyncServiceCalls == false)
            {
                response = manager.SendInterfaceBoardSectionData(parameters);
            }
            else
            {
                response = await manager.SendInterfaceBoardSectionDataAsync(parameters);
            }

            if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
            IsBusy = false;
        }

        private bool OnLoadInterfaceBoardSectionCommandCanExecute(GalaxyInterfaceBoardSection obj)
        {
            return obj != null &&
                obj.IsAnythingDirty() == false &&
                this.IsLoadInterfaceBoardSectionControlVisible;
        }

        private void OnDeleteInterfaceBoardsCommandExecute(GalaxyInterfaceBoard entity)
        {
            base.ClearCustomErrors();
            _deleteThisGalaxyInterfaceBoard = entity;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainGalaxyPanels_AreYouSureDeleteGalaxyInterfaceBoard,
                _deleteThisGalaxyInterfaceBoard.BoardNumber);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainGalaxyPanels_YesDeleteGalaxyInterfaceBoard, _deleteThisGalaxyInterfaceBoard.BoardNumber);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainGalaxyPanels_NoDeleteGalaxyInterfaceBoard, _deleteThisGalaxyInterfaceBoard.BoardNumber);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            IsBusy = true;
            if (e.DialogResult == true)
            {
                this.GalaxyPanel.InterfaceBoards.Remove(_deleteThisGalaxyInterfaceBoard);
                this.GalaxyPanel.MakeDirty();
            }
            else
                _deleteThisGalaxyInterfaceBoard = null;
            IsBusy = false;
        }
        private bool OnRefreshInterfaceBoardsCommandCanExecute(object obj)
        {
            return GalaxyPanel.GalaxyPanelUid != Guid.Empty &&
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId) && this.IsRefreshInterfaceBoardsControlVisible;
        }


        private async void OnRequestInterfaceBoardsFromPanelCommandExecute(object obj)
        {
            BusyContent = string.Empty;

            IsBusy = true;
            var manager = _clientServices.GetManager<GalaxyPanelCommunicationManager>();

            var parameters = new CommandParameters<GalaxyCpuCommandAction>()
            {
                Data = new GalaxyCpuCommandAction()
                {
                    CommandAction = GalaxyCpuCommandActionCode.RequestBoardInformation
                },
                SessionId = _clientServices.UserSessionToken.SessionId,
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
            };
            if (this.GalaxyPanel.GalaxyPanelUid != Guid.Empty)
                parameters.Data.GalaxyPanelUid = GalaxyPanel.GalaxyPanelUid;

            bool bResult = false;
            if (UseAsyncServiceCalls == false)
            {
                bResult = manager.ExecuteGalaxyCpuCommand(parameters);
            }
            else
            {
                bResult = await manager.ExecuteGalaxyCpuCommandAsync(parameters);
            }

            if (bResult == true && manager.HasErrors == false)
            {

            }
            else if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
            IsBusy = false;
        }

        private bool OnRequestInterfaceBoardsFromPanelCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId) && this.IsRefreshInterfaceBoardsControlVisible;
        }

        private void OnRefreshInterfaceBoardsCommandExecute(object obj)
        {
        }


        private async void OnRequestRS485BusDeviceInfoFromPanelCommand(GalaxyInterfaceBoardSection obj)
        {
            BusyContent = string.Empty;

            IsBusy = true;
            var manager = _clientServices.GetManager<GalaxyPanelCommunicationManager>();

            var parameters = new CommandParameters<GalaxyInterfaceBoardSectionCommandAction>()
            {
                Data = new GalaxyInterfaceBoardSectionCommandAction()
                {
                    CommandAction = GalaxyInterfaceBoardSectionCommandActionCode.RequestSerialChannelRS485DeviceInfo,
                    GalaxyInterfaceBoardSectionUid = obj.GalaxyInterfaceBoardSectionUid,
                },
                SessionId = _clientServices.UserSessionToken.SessionId,
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
            };

            bool bResult = false;
            if (UseAsyncServiceCalls == false)
            {
                bResult = manager.ExecuteGalaxyInterfaceBoardSectionCommand(parameters);
            }
            else
            {
                bResult = await manager.ExecuteGalaxyInterfaceBoardSectionCommandAsync(parameters);
            }

            if (bResult == true && manager.HasErrors == false)
            {

            }
            else if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
            IsBusy = false;
        }

        private bool OnRequestRS485BusDeviceInfoFromPanelCommandCanExecute(GalaxyInterfaceBoardSection obj)
        {
            return obj.GalaxyInterfaceBoardSectionUid != Guid.Empty &&
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId) && this.IsRequestRS485BusDeviceInfoFromPanelControlVisible;
        }



        private bool OnAddNewInterfaceBoardCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanAddId) &&
                    GalaxyPanel.InterfaceBoards.Count < GalaxyInterfaceBoardLimits.MaximumInterfaceBoardsPerPanel &&
                    IsAddNewInterfaceBoardControlVisible;
        }

        private void OnAddNewInterfaceBoardCommandExecute(object obj)
        {
            ClearCustomErrors();
            var o = new Entities.GalaxyInterfaceBoard();
            o.GalaxyPanelUid = this.GalaxyPanel.GalaxyPanelUid;

            var definedNumbers = GalaxyPanel.InterfaceBoards.Select(i => i.BoardNumber).ToList();
            var allNumbers = Enumerable.Range(GalaxyInterfaceBoardLimits.LowestDefinableBoardNumber, GalaxyInterfaceBoardLimits.HighestDefinableBoardNumber).ToArray();
            var availableNumbers = new List<short>();
            foreach (var n in allNumbers)
            {
                if (!definedNumbers.Contains((short)n))
                {
                    availableNumbers.Add((short)n);
                }
            }

            if (availableNumbers.Count() == 0)
                return;

            o.BoardNumber = availableNumbers.FirstOrDefault();
            o.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635;
            OnInterfaceBoardTypeSelectionChangedCommandExecute(o);
            GalaxyPanel.InterfaceBoards.Add(o);
        }
        #endregion

        #region Public Commands
        public GCS.Core.Common.UI.Core.DelegateCommand<object> SaveCommand { get; private set; }
        public GCS.Core.Common.UI.Core.DelegateCommand<object> CancelCommand { get; private set; }
        public GCS.Core.Common.UI.Core.DelegateCommand<UserEntitySelect> EntityMapChecked { get; set; }
        public GCS.Core.Common.UI.Core.DelegateCommand<object> AddNewInterfaceBoardCommand { get; private set; }
        public GCS.Core.Common.UI.Core.DelegateCommand<object> RefreshInterfaceBoardsCommand { get; private set; }
        public GCS.Core.Common.UI.Core.DelegateCommand<object> RequestInterfaceBoardsFromPanelCommand { get; private set; }
        public GCS.Core.Common.UI.Core.DelegateCommand<GalaxyInterfaceBoardSection> RequestRS485BusDeviceInfoFromPanelCommand { get; private set; }


        public GCS.Core.Common.UI.Core.DelegateCommand<GalaxyInterfaceBoard> DeleteInterfaceBoardCommand { get; private set; }
        public GCS.Core.Common.UI.Core.DelegateCommand<Entities.GalaxyPanelModel> PanelModelSelectionChangedCommand { get; private set; }
        //        public DelegateCommand<InterfaceBoardType> InterfaceBoardTypeSelectionChangedCommand { get; private set; }
        public GCS.Core.Common.UI.Core.DelegateCommand<GalaxyInterfaceBoard> InterfaceBoardTypeSelectionChangedCommand { get; private set; }
        public GCS.Core.Common.UI.Core.DelegateCommand<GalaxyInterfaceBoardSection> InterfaceBoardSectionModeSelectionChangedCommand { get; private set; }
        public GCS.Core.Common.UI.Core.DelegateCommand<GalaxyPanelAlertEvent> InputOutputGroupChanged { get; set; }

        public GCS.Core.Common.UI.Core.DelegateCommand<GalaxyPanelAlertEvent> InputOutputGroupAssignmentChanged { get; set; }
        public GCS.Core.Common.UI.Core.DelegateCommand<GalaxyInterfaceBoardSectionNode> IsNodeActiveCheckedCommand { get; private set; }

        public GCS.Core.Common.UI.Core.DelegateCommand<IEnumerable<GalaxyInterfaceBoardSectionNode>> IsNodeActiveHeaderCheckedCommand { get; private set; }
        public GCS.Core.Common.UI.Core.DelegateCommand<IEnumerable<GalaxyInterfaceBoardSectionNode>> IsNodeActiveHeaderUnCheckedCommand { get; private set; }
        public GCS.Core.Common.UI.Core.DelegateCommand<IEnumerable<GalaxySMS.Client.Entities.GalaxyHardwareModule>> IsModuleActiveHeaderCheckedCommand { get; private set; }
        public GCS.Core.Common.UI.Core.DelegateCommand<GalaxySMS.Client.Entities.GalaxyHardwareModule> IsModuleActiveCheckedCommand { get; private set; }
        public GCS.Core.Common.UI.Core.DelegateCommand<IEnumerable<GalaxySMS.Client.Entities.GalaxyHardwareModule>> IsModuleActiveHeaderUnCheckedCommand { get; private set; }

        public GCS.Core.Common.UI.Core.DelegateCommand<GalaxyInterfaceBoardSection> LoadInterfaceBoardSectionCommand { get; private set; }

        #endregion

        #region Public Properties
        public Entities.GalaxyPanel GalaxyPanel
        {
            get { return _galaxyPanel; }
            set
            {
                if (_galaxyPanel != value)
                {
                    _galaxyPanel = value;
                    OnPropertyChanged(() => GalaxyPanel, false);
                }
            }
        }

        public ObservableCollection<GalaxyPanel> GalaxyPanels
        {
            get { return _galaxyPanels; }
            set
            {
                if (_galaxyPanels != value)
                {
                    _galaxyPanels = value;
                    OnPropertyChanged(() => GalaxyPanels, false);
                }
            }
        }

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

        public Guid InstanceId { get; }

        public GalaxyPanelEditingData GalaxyPanelEditingData
        {
            get { return _galaxyPanelEditingData; }
            set
            {
                if (_galaxyPanelEditingData != value)
                {
                    _galaxyPanelEditingData = value;
                    _galaxyPanelEditingData.BuildBoardTypeBoardSectionModes();
                    OnPropertyChanged(() => GalaxyPanelEditingData, false);
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

        private bool _IsAddNewInterfaceBoardControlVisible;

        public bool IsAddNewInterfaceBoardControlVisible
        {
            get { return _IsAddNewInterfaceBoardControlVisible; }
            set
            {
                if (_IsAddNewInterfaceBoardControlVisible != value)
                {
                    _IsAddNewInterfaceBoardControlVisible = value;
                    OnPropertyChanged(() => IsAddNewInterfaceBoardControlVisible, false);
                }
            }
        }

        private bool _IsRefreshInterfaceBoardsControlVisible;

        public bool IsRefreshInterfaceBoardsControlVisible
        {
            get { return _IsRefreshInterfaceBoardsControlVisible; }
            set
            {
                if (_IsRefreshInterfaceBoardsControlVisible != value)
                {
                    _IsRefreshInterfaceBoardsControlVisible = value;
                    OnPropertyChanged(() => IsRefreshInterfaceBoardsControlVisible, false);
                }
            }
        }

        private bool _IsRequestInterfaceBoardsFromPanelControlVisible;

        public bool IsRequestInterfaceBoardsFromPanelControlVisible
        {
            get { return _IsRequestInterfaceBoardsFromPanelControlVisible; }
            set
            {
                if (_IsRequestInterfaceBoardsFromPanelControlVisible != value)
                {
                    _IsRequestInterfaceBoardsFromPanelControlVisible = value;
                    OnPropertyChanged(() => IsRequestInterfaceBoardsFromPanelControlVisible, false);
                }
            }
        }

        private bool _IsRequestRS485BusDeviceInfoFromPanelControlVisible;

        public bool IsRequestRS485BusDeviceInfoFromPanelControlVisible
        {
            get { return _IsRequestRS485BusDeviceInfoFromPanelControlVisible; }
            set
            {
                if (_IsRequestRS485BusDeviceInfoFromPanelControlVisible != value)
                {
                    _IsRequestRS485BusDeviceInfoFromPanelControlVisible = value;
                    OnPropertyChanged(() => IsRequestRS485BusDeviceInfoFromPanelControlVisible, false);
                }
            }
        }


        private bool _IsDeleteInterfaceBoardControlVisible;

        public bool IsDeleteInterfaceBoardControlVisible
        {
            get { return _IsDeleteInterfaceBoardControlVisible; }
            set
            {
                if (_IsDeleteInterfaceBoardControlVisible != value)
                {
                    _IsDeleteInterfaceBoardControlVisible = value;
                    OnPropertyChanged(() => IsDeleteInterfaceBoardControlVisible, false);
                }
            }
        }

        private bool _IsLoadInterfaceBoardSectionControlVisible;

        public bool IsLoadInterfaceBoardSectionControlVisible
        {
            get { return _IsLoadInterfaceBoardSectionControlVisible; }
            set
            {
                if (_IsLoadInterfaceBoardSectionControlVisible != value)
                {
                    _IsLoadInterfaceBoardSectionControlVisible = value;
                    OnPropertyChanged(() => IsLoadInterfaceBoardSectionControlVisible, false);
                }
            }
        }

        private GalaxyInterfaceBoardSection _selectedInterfaceBoardSection;

        public GalaxyInterfaceBoardSection SelectedInterfaceBoardSection
        {
            get { return _selectedInterfaceBoardSection; }
            set
            {
                if (_selectedInterfaceBoardSection != value)
                {
                    _selectedInterfaceBoardSection = value;
                    OnPropertyChanged(() => SelectedInterfaceBoardSection, false);
                    OnPropertyChanged(() => SelectedInterfaceBoardSectionMode, false);
                }
            }
        }

        private InterfaceBoardSectionMode _selectedInterfaceBoardSectionMode;

        public InterfaceBoardSectionMode SelectedInterfaceBoardSectionMode
        {
            get
            {
                if (SelectedInterfaceBoardSection == null)
                    return null;

                return this.GalaxyPanelEditingData.InterfaceBoardSectionModes.Where(m => m.InterfaceBoardSectionModeUid == SelectedInterfaceBoardSection.InterfaceBoardSectionModeUid).FirstOrDefault();
            }
            set
            {
                OnPropertyChanged(() => SelectedInterfaceBoardSectionMode, false);
            }
        }

        private GalaxyInterfaceBoardSectionNode _SelectedHardwareNode;

        public GalaxyInterfaceBoardSectionNode SelectedHardwareNode
        {
            get { return _SelectedHardwareNode; }
            set
            {
                if (_SelectedHardwareNode != value)
                {
                    _SelectedHardwareNode = value;
                    OnPropertyChanged(() => SelectedHardwareNode, false);
                }
                SelectedItem = SelectedHardwareNode;
            }
        }

        private GalaxySMS.Client.Entities.GalaxyHardwareModule _selectedHardwareModule;

        public GalaxySMS.Client.Entities.GalaxyHardwareModule SelectedHardwareModule
        {
            get { return _selectedHardwareModule; }
            set
            {
                if (_selectedHardwareModule != value)
                {
                    _selectedHardwareModule = value;
                    OnPropertyChanged(() => SelectedHardwareModule, false);
                }
                SelectedItem = SelectedHardwareModule;
            }
        }

        private GalaxyInterfaceBoard _selectedInterfaceBoard;

        public GalaxyInterfaceBoard SelectedInterfaceBoard
        {
            get { return _selectedInterfaceBoard; }
            set
            {
                if (_selectedInterfaceBoard != value)
                {
                    _selectedInterfaceBoard = value;
                    OnPropertyChanged(() => SelectedInterfaceBoard, false);
                }
                SelectedItem = SelectedInterfaceBoard;
            }
        }

        private object _selectedItem;

        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged(() => SelectedItem, false);
                }
            }
        }

        #endregion

        #region Protected Methods
        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(GalaxyPanel);
            //models.Add(Cluster.Address);
        }
        #endregion

        #region Private Methods

        private async void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                BusyContent = string.Format(CommonResources.Resources.EditGalaxyPanelView_PleaseWaitWhileISave, GalaxyPanel.PanelName);

                foreach (var ae in GalaxyPanel.AlertEvents)
                {
                    if (ae.GalaxyPanelAlertEventType.CanHaveInputOutputGroupOffset == false && ae.InputOutputGroupAssignmentUid != null)
                        ae.InputOutputGroupAssignmentUid = null;
                }

                IsBusy = true;
                var manager = _clientServices.GetManager<GalaxyPanelManager>();
                bool isNew = (GalaxyPanel.GalaxyPanelUid == Guid.Empty);
                Entities.GalaxyPanel savedEntity;
                var parameters = new SaveParameters<Entities.GalaxyPanel>()
                {
                    Data = GalaxyPanel,
                    //SessionId = _clientServices.UserSessionToken.SessionId,
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                };
                if (UseAsyncServiceCalls == false)
                {
                    savedEntity = manager.SaveGalaxyPanel(parameters);
                }
                else
                {
                    savedEntity = await manager.SaveGalaxyPanelAsync(parameters);
                }

                if (savedEntity != null && manager.HasErrors == false)
                {
                    _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.GalaxyPanel>>>().Publish(new EntitySavedEventArgs<Entities.GalaxyPanel>()
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
            return _galaxyPanel.IsDirty || _galaxyPanel.IsAnythingDirty();// || _Cluster.Address.IsDirty;
        }

        private void OnCancelCommandExecute(object arg)
        {
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.GalaxyPanel>>>().Publish(new OperationCanceledEventArgs<Entities.GalaxyPanel>()
            {
                Entity = GalaxyPanel,
                OperationId = InstanceId
            });
        }

        //private void OnSelectImageCommandExecute(object obj)
        //{
        //    try
        //    {
        //        IDialogService dlgService = new DialogService();
        //        ImageCaptureControl captureControl = new ImageCaptureControl();
        //        captureControl.Image = ByteArrayToFromImage.ByteArrayToImage(_Cluster.gcsBinaryResource?.BinaryResource);
        //        captureControl.AutomaticallyScaleDownImage = true;
        //        captureControl.ScaleToMaximumHeight = 600;
        //        captureControl.AspectRatio = ImageAspectRatio.Square1X1;
        //        SetBackgroundSubdued();
        //        dlgService.ShowRadDialog(captureControl, null, CommonResources.Resources.Dialog_SelectClusterImageTitle);
        //        ClearBackgroundSubdued();
        //        if (captureControl.DialogResult == true && captureControl.ImageCroppedAndScaled != null)
        //        {
        //            if (_Cluster.gcsBinaryResource == null)
        //                _Cluster.gcsBinaryResource = new gcsBinaryResource();
        //            _Cluster.gcsBinaryResource.BinaryResource =
        //                ByteArrayToFromImage.ImageToByteArray(captureControl.ImageCroppedAndScaled);
        //            _Cluster.MakeDirty();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().DebugFormat("OnSelectImageCommandExecute: {0}", ex.Message);
        //    }
        //}
        #endregion

        #region Implementation of ISupportsUserEntitySelection
        public void OnEntityMapChecked(UserEntitySelect obj)
        {
            _galaxyPanel.MakeDirty();
        }

        async Task FillEditorData()
        {
            try
            {
                IsBusy = true;
                var manager = _clientServices.GetManager<GalaxyPanelManager>();
                var parameters = new GetParametersWithPhoto()
                {
                    //            SessionId = _clientServices.UserSessionToken.SessionId,
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId,
                    IncludeMemberCollections = true,
                    UniqueId = GalaxyPanel.ClusterUid
                };
                if (UseAsyncServiceCalls == false)
                {
                    GalaxyPanelEditingData = manager.GetGalaxyPanelEditingData(parameters);
                }
                else
                {
                    GalaxyPanelEditingData = await manager.GetGalaxyPanelEditingDataAsync(parameters);
                }

                if (manager.HasErrors)
                {
                    AddCustomErrors(manager.Errors, true);
                }
                else
                {
                    //var noneIOGroup = GalaxyPanelEditingData?.InputOutputGroups.FirstOrDefault(o=>o.IOGroupNumber == GalaxySMS.Common.Constants.InputOutputGroupLimits.None);
                    foreach (var evt in GalaxyPanel.AlertEvents)
                    {
                        evt.GalaxyPanelAlertEventType = GalaxyPanelEditingData.AlertEventTypes.FirstOrDefault(t => t.GalaxyPanelAlertEventTypeUid == evt.GalaxyPanelAlertEventTypeUid);
                        //if( evt.InputOutputGroupUid == Guid.Empty && noneIOGroup != null)
                        //    evt.InputOutputGroupUid = noneIOGroup.InputOutputGroupUid;

                    }
                }
            }
            catch (Exception ex)
            {
                this.Log().ErrorFormat($"Error occurred. {ex.ToString()}");
            }
            IsBusy = false;
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

