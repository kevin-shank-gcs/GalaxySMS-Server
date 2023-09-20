using System.Diagnostics;
using GCS.Core.Common.Config;
using GCS.Core.Common.Logger;
using GCS.PanelCommunication.PanelCommunicationServerAsync;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Contracts;
using GalaxySMS.Business.Entities;
using GalaxySMS.Data.Contracts;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.ServiceModel.Extensions;
using GCS.Core.Common.Utils;
using PDSA.MessageBroker;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Extensions;
using System.Threading;
using GalaxySMS.Common.Constants;
using System.Security.Cryptography;
using GalaxySMS.Data;
using System.Collections.ObjectModel;
using GCS.PanelDataProcessors.Interfaces;
using GCS.PanelProtocols.Series5xx;
using CpuHardwareAddressSimple = GalaxySMS.Business.Entities.CpuHardwareAddressSimple;

namespace GalaxySMS.Business.Managers
{
    [Export(typeof(IGalaxyPanelCommunicationManagerService))]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
                    ConcurrencyMode = ConcurrencyMode.Multiple
                    //,ReleaseServiceInstanceOnTransactionComplete = false
                    )]
    //[ApplicationUserSessionHeaderInspectorBehavior]
    public class GalaxyPanelCommunicationManager : ManagerBase, IGalaxyPanelCommunicationManagerService, IGalaxyPanelCommunicationEventService
    {
        public GalaxyPanelCommunicationManager()
        {
            Globals.Instance.MessageBroker.MessageReceived += MessageBrokerOnMessageReceived;
        }

        private void MessageBrokerOnMessageReceived(object sender, PDSAMessageBrokerEventArgs pdsaMessageBrokerEventArgs)
        {
            try
            {
                switch (pdsaMessageBrokerEventArgs.MessageName)
                {
                    case MessageBrokerMessageNames.SendClusterSettingsToHardware:
                        var clusterData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<Cluster_CommonPanelLoadData>;
                        if (clusterData != null)
                            SendClusterCommonSettingsToPanels(clusterData);
                        break;

                    case MessageBrokerMessageNames.SendAccessPortalSettingsToHardware:
                        var apData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<AccessPortal_PanelLoadData>;
                        if (apData != null)
                            SendAccessPortalSettingsToPanel(apData);
                        break;
                    case MessageBrokerMessageNames.SendInputDeviceSettingsToHardware:
                        var idData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<InputDevice_PanelLoadData>;
                        if (idData != null)
                            SendInputDeviceSettingsToPanel(idData);
                        break;

                    case MessageBrokerMessageNames.SendOutputDeviceSettingsToHardware:
                        var odData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<OutputDevice_PanelLoadData>;
                        if (odData != null)
                            SendOutputDeviceSettingsToPanel(odData);
                        break;

                    case MessageBrokerMessageNames.SendAccessGroupSettingsToHardware:
                        var agData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<AccessGroup_PanelLoadData>;
                        if (agData != null)
                            SendAccessGroupSettingsToPanels(agData);
                        break;

                    case MessageBrokerMessageNames.SendInterfaceBoardSectionDataToHardware:
                        var dataInterfaceBoard = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<GalaxyInterfaceBoardSection_PanelLoadData>;
                        if (dataInterfaceBoard != null)
                            SendInterfaceBoardSectionData(dataInterfaceBoard);
                        break;

                    // A DateType has been saved, so send the updated data to the hardware
                    case MessageBrokerMessageNames.SendSavedDateTypeDataToHardware:
                        var dateTypeData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<DateType_PanelLoadData>;
                        if (dateTypeData != null)
                            SendDateTypeData(dateTypeData);
                        break;

                    // A DateType has been removed, so send the updated data to the hardware
                    case MessageBrokerMessageNames.SendDateTypeDataToClusters:
                        var dateTypeClusterData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<DateType_GetClustersThatUseDateType>;
                        if (dateTypeClusterData != null)
                            SendDateTypeData(dateTypeClusterData);
                        break;

                    case MessageBrokerMessageNames.SendTimeScheduleToHardware:
                        var timeScheduleData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<TimeSchedule_PanelLoadData>;
                        if (timeScheduleData != null)
                            SendTimeScheduleData(timeScheduleData);
                        break;

                    case MessageBrokerMessageNames.SendGalaxyTimePeriodToHardware:
                        var timePeriodData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<GalaxyTimePeriod_PanelLoadData>;
                        if (timePeriodData != null)
                            SendGalaxyTimePeriodData(timePeriodData);
                        break;

                    case MessageBrokerMessageNames.SendPersonCredentialDataToHardware:
                        var credentialData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<Credential_PanelLoadData>;
                        if (credentialData != null)
                            SendCredentialData(credentialData);
                        break;

                    case MessageBrokerMessageNames.SendCpuCommandToHardware:
                        var cpuCommandData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<GalaxyCpuCommandAction>;
                        if (cpuCommandData != null)
                            SendCpuCommandToPanels(cpuCommandData);
                        break;

                    case MessageBrokerMessageNames.SendClusterCommandToHardware:
                        var clusterCommandData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<GalaxyCpuCommandAction>;
                        if (clusterCommandData != null)
                            SendClusterCommandToPanels(clusterCommandData);
                        break;

                    case MessageBrokerMessageNames.SendGalaxyFlashCommandToHardware:
                        var flashCommandData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<GalaxyLoadFlashCommandAction>;
                        if (flashCommandData != null)
                            SendGalaxyLoadFlashCommandToPanels(flashCommandData);
                        break;

                    case MessageBrokerMessageNames.SendAccessPortalCommandToHardware:
                        var apCommandData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<AccessPortalCommandAction>;
                        if (apCommandData != null)
                            SendAccessPortalCommandToPanels(apCommandData);
                        break;

                    case MessageBrokerMessageNames.SendInputOutputGroupCommandToHardware:
                        var iogCommandData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<InputOutputGroupCommandAction>;
                        if (iogCommandData != null)
                            SendInputOutputGroupCommandToPanels(iogCommandData);
                        break;

                    case MessageBrokerMessageNames.SendGalaxyInterfaceBoardSectionCommandToHardware:
                        var bsCommandData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<GalaxyInterfaceBoardSectionCommandAction>;
                        if (bsCommandData != null)
                            SendGalaxyBoardSectionCommandToPanels(bsCommandData);
                        break;

                    case MessageBrokerMessageNames.SendInputDeviceCommandToHardware:
                        var idCommandData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<InputDeviceCommandAction>;
                        if (idCommandData != null)
                            SendInputDeviceCommandToPanels(idCommandData);
                        break;

                    case MessageBrokerMessageNames.SendOutputDeviceCommandToHardware:
                        var odCommandData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<OutputDeviceCommandAction>;
                        if (odCommandData != null)
                            SendOutputDeviceCommandToPanels(odCommandData);
                        break;

                    case MessageBrokerMessageNames.SendPanelAlarmsToHardware:
                        var panelAlarmData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<GalaxyPanelAlarmSettings_PanelLoadData>;
                        if (panelAlarmData != null)
                            SendGalaxyPanelAlarmDataToPanels(panelAlarmData);
                        break;

                    case MessageBrokerMessageNames.SendAllTimeSchedulesToHardware:
                        // Load all schedule related data to specific cluster or panel, regardless of schedule format (15 or 1 minute based). This includes date types and holidays, time periods and schedules
                        var scheduleData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<TimeSchedule_PanelLoadData>;
                        if (scheduleData != null)
                            SendAllScheduleData(scheduleData);
                        break;

                    case MessageBrokerMessageNames.SendAllCredentialDataToHardware:
                        var allCredentialData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<Credential_PanelLoadData>;
                        if (allCredentialData != null)
                            SendAllCredentialData(allCredentialData);
                        break;

                    case MessageBrokerMessageNames.SendDeletedCredentialsToHardware:
                        var deleteCredentials = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<CredentialToDeleteFromCpu>;
                        if (deleteCredentials != null)
                            SendDeleteCredentialData(deleteCredentials);
                        break;

                    case MessageBrokerMessageNames.SendCredentialChangesToHardware:
                        break;

                    case MessageBrokerMessageNames.SendInputOutputGroupToHardware:
                        var iogData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<InputOutputGroup_PanelLoadData>;
                        if (iogData != null)
                            SendInputOutputGroupToPanels(iogData);
                        break;

                    case MessageBrokerMessageNames.SendAllClusterInputOutputGroupsToHardware:
                        var iogDataItems = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<InputOutputGroup_PanelLoadData>;
                        if (iogDataItems != null)
                            SendAllClusterInputOutputGroupsToPanels(iogDataItems);
                        break;

                    case MessageBrokerMessageNames.SendAccessPortalsToHardware:
                        var accessPortalInterfaceBoardData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<GalaxyInterfaceBoardSection_PanelLoadData>;
                        if (accessPortalInterfaceBoardData != null)
                            SendInterfaceBoardSectionData(accessPortalInterfaceBoardData);
                        break;

                    case MessageBrokerMessageNames.SendInputOutputDevicesToHardware:
                        var inputOutputInterfaceBoardData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<GalaxyInterfaceBoardSection_PanelLoadData>;
                        if (inputOutputInterfaceBoardData != null)
                            SendInterfaceBoardSectionData(inputOutputInterfaceBoardData);
                        break;

                    case MessageBrokerMessageNames.GalaxyCpuDatabaseInformationSaved:
                        var cpuData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<GalaxyCpuDatabaseInformation>;
                        if (cpuData != null)
                            SendCpuDatabaseData(cpuData);
                        break;

                    case MessageBrokerMessageNames.SendRefreshGalaxyPanelDataFromDb:
                        var panelData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters<GalaxyCpuDatabaseInformation>;
                        if (panelData != null)
                            SendPanelDatabaseData(panelData);
                        break;

                    case MessageBrokerMessageNames.ClusterTimeZoneChanged:
                        var clusterTZChangedAddress =
                            pdsaMessageBrokerEventArgs.MessageObject.MessageBody as ClusterTimeZone;
                        if (clusterTZChangedAddress != null)
                            SendTimeZoneChangedToClusterAddress(clusterTZChangedAddress);
                        break;

                    case MessageBrokerMessageNames.ClusterAddressChanged:
                        var clusterAddress =
                            pdsaMessageBrokerEventArgs.MessageObject.MessageBody as ClusterAddress;
                        if (clusterAddress != null)
                            SendDisconnectPanelsForClusterAddress(clusterAddress, false);
                        break;

                    case MessageBrokerMessageNames.NewClusterSaved:
                        var clusterSavedAddress =
                            pdsaMessageBrokerEventArgs.MessageObject.MessageBody as ClusterAddress;
                        if (clusterSavedAddress != null)
                            SendDisconnectPanelsForClusterAddress(clusterSavedAddress, true);
                        break;

                    case MessageBrokerMessageNames.PanelAddressChanged:
                        var panelAddress =
                            pdsaMessageBrokerEventArgs.MessageObject.MessageBody as CpuHardwareAddress;
                        if (panelAddress != null)
                            SendDisconnectCpusForPanelAddress(panelAddress, false, false);
                        break;

                    case MessageBrokerMessageNames.NewPanelSaved:
                        var panelSavedAddress =
                            pdsaMessageBrokerEventArgs.MessageObject.MessageBody as CpuHardwareAddress;
                        if (panelSavedAddress != null)
                            SendDisconnectCpusForPanelAddress(panelSavedAddress, true, false);
                        break;

                    case MessageBrokerMessageNames.PanelDeleted:
                        var panelDeletedAddress =
                            pdsaMessageBrokerEventArgs.MessageObject.MessageBody as CpuHardwareAddress;
                        if (panelDeletedAddress != null)
                            SendDisconnectCpusForPanelAddress(panelDeletedAddress, false, true);
                        break;
                        //case MessageBrokerMessageNames.SendLoadDataFinished:
                        //    var loadDataFinishedData = pdsaMessageBrokerEventArgs.MessageObject.MessageBody as SendDataParameters;
                        //    if (loadDataFinishedData != null)
                        //        SendLoadFinishedData(loadDataFinishedData);
                        //    break;
                }
            }
            catch (Exception ex)
            {
                this.Log().ErrorFormat("MessageBrokerOnMessageReceived: {0}", ex.ToString());
            }
        }

        #region Private member variables
        private ConnectionManagerAsync _asyncManager;
        private bool _PanelServerEnabled = true;
        private bool _EncryptPanelCommunications = false;
        private string _EncryptionPhrase = "choose a phrase now";
        private string _ServerAddress = string.Empty;
        private Timer _requestDataThatNeedsLoadedTimer;
        private int _checkForDataChangesIntervalSeconds;
        private int _checkForDataChangesIntervalSecondsDefaultValue = 10;
        private int _galaxyCpuListenPortDefaultValue = 3001;
        private int _galaxyAckLogMessageIndexMinimumIntervalDefaultValue = 10;
        private int _galaxyOperationTimeoutSecondsDefaultValue = 10;

        #region Setting String Values
        private string _settingGroup = GCS.Core.Common.Utils.SystemUtilities.MyProcessName;
        private string _settingSubGroupTimers = "Timers";
        private string _settingKeyCheckForPanelChangesInterval = "Check For Panel Changes Interval Seconds";

        private string _settingSubGroupGalaxyCpuConnections = "Galaxy Cpu Connections";
        private string _settingKeyGalaxyCpuListenPort = "Cpu Listen Port";
        private string _settingKeyGalaxyCpuEncryptionEnabled = "Encryption Enabled";
        private string _settingKeyGalaxyCpuEncryptionPhrase = "Encryption Phrase";
        private string _settingKeyGalaxyAckLogMessageIndexMinimumInterval = "Ack Log Message Index Minimum Interval Seconds";
        private string _settingKeyDefaultOperationTimeout = "Operation Timeout Seconds";
        #endregion

        [Import] IDataRepositoryFactory _DataRepositoryFactory;
        #endregion

        public void Start()
        {
            ExecuteFaultHandledOperation(() =>
            {
                var settingsRepo = _DataRepositoryFactory.GetDataRepository<IGcsSettingRepository>();

                _checkForDataChangesIntervalSeconds = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    _settingGroup, _settingSubGroupTimers, _settingKeyCheckForPanelChangesInterval, _checkForDataChangesIntervalSecondsDefaultValue, true, this.ApplicationUserSessionHeader);
                if (_checkForDataChangesIntervalSeconds < 0)
                    _checkForDataChangesIntervalSeconds = 0;
                if (_checkForDataChangesIntervalSeconds > (int.MaxValue / 1000))
                    _checkForDataChangesIntervalSeconds = _checkForDataChangesIntervalSecondsDefaultValue;

                var listenPort = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    _settingGroup, _settingSubGroupGalaxyCpuConnections, _settingKeyGalaxyCpuListenPort, _galaxyCpuListenPortDefaultValue, true, this.ApplicationUserSessionHeader);

                var ackLogMessageIndexMinimumInterval = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    _settingGroup, _settingSubGroupGalaxyCpuConnections, _settingKeyGalaxyAckLogMessageIndexMinimumInterval, _galaxyAckLogMessageIndexMinimumIntervalDefaultValue, true, this.ApplicationUserSessionHeader);

                if (listenPort < 1 || listenPort > 65535)
                    listenPort = _galaxyCpuListenPortDefaultValue;

                _EncryptPanelCommunications = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    _settingGroup, _settingSubGroupGalaxyCpuConnections, _settingKeyGalaxyCpuEncryptionEnabled, false, true, this.ApplicationUserSessionHeader);

                _EncryptionPhrase = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    _settingGroup, _settingSubGroupGalaxyCpuConnections, _settingKeyGalaxyCpuEncryptionPhrase, "choose a phrase now", true, this.ApplicationUserSessionHeader);

                _galaxyOperationTimeoutSecondsDefaultValue = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    _settingGroup, _settingSubGroupGalaxyCpuConnections, _settingKeyDefaultOperationTimeout, _galaxyOperationTimeoutSecondsDefaultValue, true, this.ApplicationUserSessionHeader);

                _asyncManager?.Stop();
                if (_PanelServerEnabled == true)
                {
                    _ServerAddress = $"{GCS.Framework.Utilities.SystemUtilities.MyMachineName()}:{listenPort}";
                    if (_EncryptPanelCommunications == false)
                        _asyncManager = new ConnectionManagerAsync(new ConnectionManagerParameters(500, 1050, listenPort, ConnectionManagerAsync.IPVersionType.IPv4, string.Empty, _ServerAddress, ackLogMessageIndexMinimumInterval, _galaxyOperationTimeoutSecondsDefaultValue));
                    else
                        _asyncManager = new ConnectionManagerAsync(new ConnectionManagerParameters(500, 1050, listenPort, ConnectionManagerAsync.IPVersionType.IPv4, _EncryptionPhrase, _ServerAddress, ackLogMessageIndexMinimumInterval, _galaxyOperationTimeoutSecondsDefaultValue));
                    _asyncManager.ConnectionStateChangedEvent += asyncManager_ConnectionStateChangedEvent;
                    _asyncManager.PanelInformationEvent += _asyncManager_PanelInformationEvent;

                    _asyncManager.DebugPacketEvent += _asyncManager_DebugPacketEvent;
                    _asyncManager.Start();

                    this.Log().Info($"Starting load data changes timer");
                    StartRequestDataThatNeedsLoadedTimer();
                }
            });
        }

        private void _asyncManager_DebugPacketEvent(object sender, ConnectionDebugPacketEventArgs e)
        {
            CpuDataPacket debugPacket = new CpuDataPacket(e.Packet);

            SendConnectionDebugPacketToEventSubscribers(ref debugPacket);

        }

        private void _asyncManager_PanelInformationEvent(object sender, PanelInformationEventArgs e)
        {
            SendPanelInformationToEventSubscribers(e.GalaxyCpuInformation);
        }

        private void asyncManager_ConnectionStateChangedEvent(object sender, ConnectionStateChangeEventArgs e)
        {
            SendCpuConnectionInfoToEventSubscribers(e.ConnectionInfo);
            //Trace.WriteLine($"ConnectionStateChangeEventArgs: {nameof(e.ConnectionInfo.GalaxyCpuInformation.ClusterGroupId)}:{e.ConnectionInfo.GalaxyCpuInformation?.ClusterGroupId},{nameof(e.ConnectionInfo.GalaxyCpuInformation.ClusterNumber)}:{e.ConnectionInfo.GalaxyCpuInformation?.ClusterNumber}, {nameof(e.ConnectionInfo.GalaxyCpuInformation.PanelNumber)}:{e.ConnectionInfo.GalaxyCpuInformation?.PanelNumber}, {nameof(e.ConnectionInfo.IsConnected)}:{e.ConnectionInfo?.IsConnected}, {nameof(e.ConnectionInfo.IsAuthenticated)}:{e.ConnectionInfo?.IsAuthenticated}");
        }

        public void Stop()
        {
            ExecuteFaultHandledOperation(() =>
            {
                KillRequestDataThatNeedsLoadedTimer();
                if (_asyncManager != null)
                    _asyncManager.Stop();
                _asyncManager = null;
                SetAllCpusAsDisconnected();
            });
        }

        public void SetAllCpusAsDisconnected()
        {
            ExecuteFaultHandledOperation(() =>
            {
                var settingsRepo = _DataRepositoryFactory.GetDataRepository<IGcsSettingRepository>();
                var listenPort = settingsRepo.GetByUniqueKey(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id,
                    _settingGroup, _settingSubGroupGalaxyCpuConnections, _settingKeyGalaxyCpuListenPort, _galaxyCpuListenPortDefaultValue, true, this.ApplicationUserSessionHeader);
                if (listenPort < 1 || listenPort > 65535)
                    listenPort = _galaxyCpuListenPortDefaultValue;

                _ServerAddress = $"{GCS.Framework.Utilities.SystemUtilities.MyMachineName()}:{listenPort}";
                var cpuRepo = _DataRepositoryFactory.GetDataRepository<IGalaxyCpuRepository>();
                cpuRepo.SetGalaxyCpuConnection(new GalaxyCpuConnection()
                {
                    ServerAddress = _ServerAddress
                });
            });

        }

        public bool GetRunningStatus()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                    return _asyncManager.IsRunning;
                return false;
            });
        }

        public CpuConnectionInfo[] GetConnections(GetCpuConnectionsParameters parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();

                    CpuConnectionInfo[] ret;
                    switch (parameters.GetOption)
                    {
                        case GetCpuConnectionParams.SavedCpus:
                            ret = _asyncManager.CpuConnections.Where(o => o.CpuDatabaseInformation != null && o.CpuDatabaseInformation.CpuUid != Guid.Empty).ToArray();
                            break;

                        case GetCpuConnectionParams.UnsavedCpus:
                            ret = _asyncManager.CpuConnections.Where(o => o.CpuDatabaseInformation == null || o.CpuDatabaseInformation?.CpuUid == Guid.Empty).ToArray();
                            break;

                        case GetCpuConnectionParams.All:
                        default:
                            ret = _asyncManager.CpuConnections.ToArray();
                            break;
                    }
                    return ret;
                }
                else
                    return null;
            });
        }

        public bool IsPanelOnline(int clusterGroupId, int clusterNumber, int panelNumber)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    return _asyncManager.IsPanelOnline(clusterGroupId, clusterNumber, panelNumber);
                }
                return false;
            });

        }

        public void SendDataPacket(RawDataToSend dataPacket)
        {
            ExecuteFaultHandledOperation(() =>
            {
                _asyncManager?.SendRawData(dataPacket);
            });
        }

        public TestData[] GetTestDataItems()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    List<TestData> returnData = new List<TestData>();
                    foreach (CpuConnectionInfo cpuInfo in _asyncManager.CpuConnections)
                    {
                        TestData td = new TestData(cpuInfo);
                        returnData.Add(td);
                    }
                    TestData[] ret = returnData.ToArray();
                    return ret;
                }
                else
                    return null;
            });
        }
        public TestData GetTestData()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    TestData returnData = new TestData();
                    foreach (CpuConnectionInfo cpuInfo in _asyncManager.CpuConnections)
                    {
                        if (cpuInfo.Description != null)
                            returnData.Description = cpuInfo.Description;
                    }
                    return returnData;
                }
                else
                    return null;
            });
        }
        public String[] GetTestStrings()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    List<String> returnData = new List<String>();
                    foreach (CpuConnectionInfo cpuInfo in _asyncManager.CpuConnections)
                    {
                        returnData.Add(cpuInfo.Description);
                    }
                    String[] ret = returnData.ToArray();
                    return ret;
                }
                else
                    return null;
            });
        }

        private static Dictionary<string, IGalaxyPanelCommunicationEventServiceCallback> _eventServiceClients =
           new Dictionary<string, IGalaxyPanelCommunicationEventServiceCallback>();


        private static object locker = new object();

        #region IGalaxyPanelCommunicationEventService
        //       public void RegisterClient(GalaxyPanelCommunicationManagerEventSubscriber client)
        public void RegisterClient(GalaxyPanelCommunicationManagerEventSubscriber client)
        {
            if (client != null && client.ClientName != "")
            {
                try
                {
                    IGalaxyPanelCommunicationEventServiceCallback callback =
                        OperationContext.Current.GetCallbackChannel<IGalaxyPanelCommunicationEventServiceCallback>();
                    lock (locker)
                    {
                        //remove the old client
                        if (_eventServiceClients.Keys.Contains(client.ClientName))
                            _eventServiceClients.Remove(client.ClientName);
                        _eventServiceClients.Add(client.ClientName, callback);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void UnregisterClient(GalaxyPanelCommunicationManagerEventSubscriber client)
        {
            if (client != null && client.ClientName != "")
            {
                try
                {
                    IGalaxyPanelCommunicationEventServiceCallback callback =
                        OperationContext.Current.GetCallbackChannel<IGalaxyPanelCommunicationEventServiceCallback>();
                    lock (locker)
                    {
                        //remove the old client
                        if (_eventServiceClients.Keys.Contains(client.ClientName))
                            _eventServiceClients.Remove(client.ClientName);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void SetConnectionDebuggingModeForClient(ConnectionDebuggingModeForSubscriber client)
        {
            if (client != null && client.ClientName != "")
            {
                try
                {
                    ExecuteFaultHandledOperation(() =>
                    {
                        if (_asyncManager != null)
                        {
                            _asyncManager.EnableDebugging(client.ConnectionGuid.ToString(), client.EnableDebugging);
                        }
                    });
                }
                catch (Exception ex)
                {
                }
            }

        }
        #endregion

        public void SendCpuConnectionInfoToEventSubscribers(CpuConnectionInfo cpuInfo)
        {
            lock (locker)
            {
                var inactiveClients = new List<string>();
                foreach (
                    KeyValuePair<string, IGalaxyPanelCommunicationEventServiceCallback> kvp in _eventServiceClients)
                {
                    try
                    {
                        //                        Trace.WriteLine(" kvp.Value.BroadcastCpuConnectionInfoToClient");
                        kvp.Value.BroadcastCpuConnectionInfoToClient(cpuInfo);
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(string.Format(" kvp.Value.BroadcastCpuConnectionInfoToClient exception-> {0}", ex.ToString()));
                        this.Log().ErrorFormat("SendCpuConnectionInfoToEventSubscribers: {0}", ex.ToString());
                        inactiveClients.Add(kvp.Key);
                    }
                }
                if (inactiveClients.Count > 0)
                {
                    foreach (var clientName in inactiveClients)
                    {
                        _eventServiceClients.Remove(clientName);
                    }
                }
            }
        }

        public void SendPanelInformationToEventSubscribers(GalaxyCpuInformation galaxyCpuInfo)
        {
            lock (locker)
            {
                var inactiveClients = new List<string>();
                foreach (
                    KeyValuePair<string, IGalaxyPanelCommunicationEventServiceCallback> kvp in _eventServiceClients)
                {
                    try
                    {
                        //                        Trace.WriteLine(" kvp.Value.BroadcastPanelInformationToClient");
                        kvp.Value.BroadcastPanelInformationToClient(galaxyCpuInfo);
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(string.Format(" kvp.Value.BroadcastPanelInformationToClient exception-> {0}", ex.ToString()));
                        this.Log().ErrorFormat("SendPanelInformationToEventSubscribers: {0}", ex.ToString());
                        inactiveClients.Add(kvp.Key);
                    }
                }
                if (inactiveClients.Count > 0)
                {
                    foreach (var clientName in inactiveClients)
                    {
                        _eventServiceClients.Remove(clientName);
                    }
                }
            }
        }

        private void SendConnectionDebugPacketToEventSubscribers(ref CpuDataPacket debugPacket)
        {
            lock (locker)
            {
                var inactiveClients = new List<string>();
                foreach (
                    KeyValuePair<string, IGalaxyPanelCommunicationEventServiceCallback> kvp in _eventServiceClients)
                {
                    try
                    {
                        //                        Trace.WriteLine(string.Format(" kvp.Value.BroadcastPanelDebugPacketToClient"));
                        kvp.Value.BroadcastPanelDebugPacketToClient(debugPacket);
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(string.Format(" kvp.Value.BroadcastPanelDebugPacketToClient exception-> {0}", ex.ToString()));
                        this.Log().ErrorFormat("SendConnectionDebugPacketToEventSubscribers: {0}", ex.ToString());
                        inactiveClients.Add(kvp.Key);
                    }
                }
                //if (inactiveClients.Count > 0)
                {
                    foreach (var clientName in inactiveClients)
                    {
                        _eventServiceClients.Remove(clientName);
                    }
                }
            }
        }

        public SendDataResponse<AbaSettings> SendAbaSettings(SendDataParameters<AbaSettings> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();
                    if (data.PopulateDataFromDatabase)
                    {
                        var repository = _DataRepositoryFactory.GetDataRepository<IClusterRepository>();
                        var loadData = repository.GetCommonPanelLoadData(ApplicationUserSessionHeader, new GetParametersWithPhoto()
                        {
                            UniqueId = data.SendToAddress.ClusterUid,
                            ClusterGroupId = data.SendToAddress.ClusterGroupId,
                            ClusterNumber = data.SendToAddress.ClusterNumber
                        });
                        if (loadData != null)
                        {
                            data.SendToAddress.ClusterNumber = loadData.ClusterNumber;
                            data.SendToAddress.ClusterGroupId = loadData.ClusterGroupId;
                            data.Data.Start = loadData.AbaStartDigit;
                            data.Data.End = loadData.AbaStopDigit;
                            if (loadData.AbaFoldOption == true)
                                data.Data.Folding = AbaFold.On;
                            else
                                data.Data.Folding = AbaFold.Off;

                            if (loadData.AbaClipOption == true)
                                data.Data.Clipping = AbaClip.On;
                            else
                                data.Data.Clipping = AbaClip.None;
                        }
                    }
                    _asyncManager.SendAbaSettings(data);
                }

                return new SendDataResponse<AbaSettings>(data.Data);
            });
        }

        public SendDataResponse<Cluster_CommonPanelLoadData> SendClusterCommonSettingsToPanels(SendDataParameters<Cluster_CommonPanelLoadData> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();
                    ResolveSendToAddress(data.SendToAddress);
                    if (data.PopulateDataFromDatabase)
                    {
                        var repository = _DataRepositoryFactory.GetDataRepository<IClusterRepository>();
                        data.Data = repository.GetCommonPanelLoadData(ApplicationUserSessionHeader, new GetParametersWithPhoto()
                        {
                            UniqueId = data.Data.ClusterUid,
                            //ClusterGroupId = data.SendToAddress.ClusterGroupId,
                            //ClusterNumber = data.SendToAddress.ClusterNumber
                        });
                    }
                    if (data?.Data != null)
                        _asyncManager.SendClusterCommonSettingsToPanels(data);
                }
                return new SendDataResponse<Cluster_CommonPanelLoadData>(data.Data);
            });

        }

        //public SendDataResponse<GalaxyInterfaceBoardSection_PanelLoadData> SendInterfaceBoardSectionData(SendDataParameters<GalaxyInterfaceBoardSection_PanelLoadData> data)
        //{
        //    return ExecuteFaultHandledOperation(() =>
        //    {
        //        if (_asyncManager != null)
        //        {
        //            GetApplicationUserSessionHeader();
        //            if (data.PopulateDataFromDatabase)
        //            {
        //                var repository = _DataRepositoryFactory.GetDataRepository<IGalaxyInterfaceBoardSectionRepository>();
        //                data.Data = repository.GetGalaxyInterfaceBoardSectionPanelLoadData(ApplicationUserSessionHeader, new GetParametersWithPhoto() { UniqueId = data.Data.GalaxyInterfaceBoardSectionUid });
        //            }

        //            _asyncManager.SendInterfaceBoardSectionData(data);

        //            SaveAuditRecord(data);

        //            IEnumerable<Guid> accessPortalUids = null;
        //            IEnumerable<AccessPortal_PanelLoadData> accessPortalLoadData = null;
        //            switch ((GalaxySMS.Common.Enums.GalaxyInterfaceBoardType)data.Data.BoardTypeTypeCode)
        //            {
        //                case GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
        //                case GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
        //                    //accessPortalUids = GetAccessPortalUidsForInterfaceBoardSection(data.Data.GalaxyInterfaceBoardSectionUid);
        //                    accessPortalLoadData = GetAccessPortalLoadDataForInterfaceBoardSection(data.Data.GalaxyInterfaceBoardSectionUid);
        //                    break;

        //                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
        //                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
        //                    switch ((DualSerialChannelMode)data.Data.BoardSectionMode)
        //                    {
        //                        case DualSerialChannelMode.Unused:
        //                            break;
        //                        case DualSerialChannelMode.Shell:
        //                            break;
        //                        case DualSerialChannelMode.ElevatorRelays:
        //                            break;
        //                        case DualSerialChannelMode.CypressClockDisplay:
        //                            break;
        //                        case DualSerialChannelMode.OutputRelays:
        //                            break;
        //                        case DualSerialChannelMode.LCD_4x20Display:
        //                            break;

        //                        case DualSerialChannelMode.AllegionPimWiegand:
        //                        case DualSerialChannelMode.AllegionPimAba:
        //                        case DualSerialChannelMode.RS485DoorModule:
        //                        case DualSerialChannelMode.AssaAbloyAperio:
        //                        case DualSerialChannelMode.SaltoSallis:
        //                            //accessPortalUids = GetAccessPortalUidsForInterfaceBoardSection(data.Data.GalaxyInterfaceBoardSectionUid);
        //                            accessPortalLoadData = GetAccessPortalLoadDataForInterfaceBoardSection(data.Data.GalaxyInterfaceBoardSectionUid);
        //                            break;

        //                        case DualSerialChannelMode.RS485InputModule:
        //                            break;
        //                        case DualSerialChannelMode.VeridtCac:
        //                            break;
        //                    }
        //                    break;
        //            }

        //            if (accessPortalLoadData != null)
        //            {
        //                foreach (var apData in accessPortalLoadData)
        //                {
        //                    SendAccessPortalSettingsToPanel(new SendDataParameters<AccessPortal_PanelLoadData>(data) { Data = apData, PopulateDataFromDatabase = false });
        //                }
        //            }
        //        }
        //        return new SendDataResponse<GalaxyInterfaceBoardSection_PanelLoadData>(data.Data);
        //    });
        //}

        public SendDataResponse<GalaxyInterfaceBoardSection_PanelLoadData> SendInterfaceBoardSectionData(SendDataParameters<GalaxyInterfaceBoardSection_PanelLoadData> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();
                    if (data.PopulateDataFromDatabase)
                    {
                        var repository = _DataRepositoryFactory.GetDataRepository<IGalaxyInterfaceBoardSectionRepository>();
                        if (data.Data.GalaxyInterfaceBoardSectionUid != Guid.Empty)
                        {
                            var col = new List<GalaxyInterfaceBoardSection_PanelLoadData>();
                            data.Data = repository.GetGalaxyInterfaceBoardSectionPanelLoadData(ApplicationUserSessionHeader, new GetParametersWithPhoto() { UniqueId = data.Data.GalaxyInterfaceBoardSectionUid });
                            col.Add(data.Data);
                            data.Collection = col;
                        }
                        else if (data.Data.GalaxyPanelUid != Guid.Empty)
                        {
                            data.Collection = repository.GetGalaxyInterfaceBoardSectionPanelLoadDataForPanelUid(ApplicationUserSessionHeader, new GetParametersWithPhoto() { UniqueId = data.Data.GalaxyPanelUid }).ToList();
                        }
                        else if (data.Data.ClusterUid != Guid.Empty)
                        {
                            data.Collection = repository.GetGalaxyInterfaceBoardSectionPanelLoadDataForClusterUid(ApplicationUserSessionHeader, new GetParametersWithPhoto() { UniqueId = data.Data.ClusterUid }).ToList();
                        }
                    }

                    foreach (var o in data.Collection)
                    {
                        data.Data = o;
                        //_asyncManager.SendInterfaceBoardSectionData(data);

                        //SaveAuditRecord(data);

                        IEnumerable<Guid> accessPortalUids = null;
                        IEnumerable<AccessPortal_PanelLoadData> accessPortalLoadData = null;
                        IEnumerable<InputDevice_PanelLoadData> inputDevicePanelLoadData = null;
                        IEnumerable<OutputDevice_PanelLoadData> outputDevicePanelLoadData = null;

                        switch ((GalaxySMS.Common.Enums.GalaxyInterfaceBoardType)data.Data.BoardTypeTypeCode)
                        {
                            case GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
                            case GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
                                //accessPortalUids = GetAccessPortalUidsForInterfaceBoardSection(data.Data.GalaxyInterfaceBoardSectionUid);
                                accessPortalLoadData = GetAccessPortalLoadDataForInterfaceBoardSection(data.Data.GalaxyInterfaceBoardSectionUid);
                                break;

                            case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                            case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                                switch ((DualSerialChannelMode)data.Data.BoardSectionMode)
                                {
                                    case DualSerialChannelMode.Unused:
                                        break;
                                    case DualSerialChannelMode.Shell:
                                        break;
                                    case DualSerialChannelMode.ElevatorRelays:
                                        break;
                                    case DualSerialChannelMode.CypressClockDisplay:
                                        break;
                                    case DualSerialChannelMode.LCD_4x20Display:
                                        break;

                                    case DualSerialChannelMode.AllegionPimWiegand:
                                    case DualSerialChannelMode.AllegionPimAba:
                                    case DualSerialChannelMode.RS485DoorModule:
                                    case DualSerialChannelMode.AssaAbloyAperio:
                                    case DualSerialChannelMode.SaltoSallis:
                                        //accessPortalUids = GetAccessPortalUidsForInterfaceBoardSection(data.Data.GalaxyInterfaceBoardSectionUid);
                                        accessPortalLoadData = GetAccessPortalLoadDataForInterfaceBoardSection(data.Data.GalaxyInterfaceBoardSectionUid);
                                        break;

                                    case DualSerialChannelMode.RS485InputModule:
                                        inputDevicePanelLoadData = GetInputDeviceLoadDataForInterfaceBoardSection(data.Data.GalaxyInterfaceBoardSectionUid);
                                        break;
                                    case DualSerialChannelMode.OutputRelays:
                                        outputDevicePanelLoadData = GetOutputDeviceLoadDataForInterfaceBoardSection(data.Data.GalaxyInterfaceBoardSectionUid);
                                        if (outputDevicePanelLoadData != null)
                                            data.Data.RelayCount = (ushort)outputDevicePanelLoadData.Count();
                                        break;
                                    case DualSerialChannelMode.VeridtCac:
                                        break;
                                }
                                break;

                            case GalaxyInterfaceBoardType.DigitalInputOutputBoard600:
                                switch ((GalaxySMS.Common.Enums.DigitalInputOutputBoardInterfaceSectionMode)data.Data.BoardSectionMode)
                                {
                                    case DigitalInputOutputBoardInterfaceSectionMode.Outputs:
                                        outputDevicePanelLoadData = GetOutputDeviceLoadDataForInterfaceBoardSection(data.Data.GalaxyInterfaceBoardSectionUid);
                                        break;
                                    case DigitalInputOutputBoardInterfaceSectionMode.Inputs:
                                        inputDevicePanelLoadData = GetInputDeviceLoadDataForInterfaceBoardSection(data.Data.GalaxyInterfaceBoardSectionUid);
                                        break;
                                }
                                break;
                        }

                        _asyncManager.SendInterfaceBoardSectionData(data);

                        SaveAuditRecord(data);

                        if (accessPortalLoadData != null)
                        {
                            foreach (var apData in accessPortalLoadData)
                            {
                                SendAccessPortalSettingsToPanel(new SendDataParameters<AccessPortal_PanelLoadData>(data) { Data = apData, PopulateDataFromDatabase = false });
                            }
                        }

                        if (inputDevicePanelLoadData != null)
                        {
                            // The input data is contained in a collection of individual inputs
                            // Based on the hardware that the input is associated with, the inputs may be sent individually (DIO) or bundled into a single message per module (DSI RS-485 Input Module)
                            switch ((GalaxySMS.Common.Enums.GalaxyInterfaceBoardType)data.Data.BoardTypeTypeCode)
                            {
                                case GalaxyInterfaceBoardType.DigitalInputOutputBoard600:
                                    // Each input must be sent as a separate message
                                    foreach (var idData in inputDevicePanelLoadData)
                                    {
                                        SendInputDeviceSettingsToPanel(new SendDataParameters<InputDevice_PanelLoadData>(data) { Data = idData, PopulateDataFromDatabase = false });
                                    }
                                    break;

                                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                                    // RS 485 modules - all inputs (18) on a module must be bundled into a single message to the panel. 
                                    var inputsByModule = inputDevicePanelLoadData.GroupBy(x => x.GalaxyHardwareModuleUid).ToList();
                                    foreach (var eachModule in inputsByModule)
                                    {
                                        var firstInput = eachModule.FirstOrDefault();
                                        var sendParams = new SendDataParameters<InputDevice_PanelLoadData>(data)
                                        {
                                            Data = firstInput,
                                            PopulateDataFromDatabase = false,
                                            Collection = eachModule.ToList()
                                        };

                                        SendInputDeviceSettingsToPanel(sendParams);
                                    }

                                    break;
                            }
                        }

                        if (outputDevicePanelLoadData != null)
                        {
                            foreach (var odData in outputDevicePanelLoadData)
                            {
                                SendOutputDeviceSettingsToPanel(new SendDataParameters<OutputDevice_PanelLoadData>(data) { Data = odData, PopulateDataFromDatabase = false });
                            }
                        }

                    }

                    //var sendFinishedParams = new SendDataParameters<GalaxyPanel>(data);
                    //_asyncManager.SendLoadDataFinished(sendFinishedParams, nameof(LoadDataToPanelSettings.AccessPortalsInputsOutputs));

                }
                return new SendDataResponse<GalaxyInterfaceBoardSection_PanelLoadData>(data.Data);
            });
        }

        private void SendCpuDatabaseData(SendDataParameters<GalaxyCpuDatabaseInformation> data)
        {
            ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();

                    _asyncManager.SendCpuDatabaseDataToConnection(data);
                }
            });
        }

        private void SendDisconnectCpusForPanelAddress(CpuHardwareAddress panelAddress, Boolean newPanel, bool deletedPanel)
        {
            ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();

                    _asyncManager.SendDisconnectCpusForPanelAddress(panelAddress, newPanel, deletedPanel);
                }
            });
        }

        private void SendDisconnectPanelsForClusterAddress(ClusterAddress clusterAddress, Boolean newCluster)
        {
            ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();

                    _asyncManager.SendDisconnectPanelsForClusterAddress(clusterAddress, newCluster);
                }
            });
        }

        private void SendTimeZoneChangedToClusterAddress(ClusterTimeZone clusterAddress)
        {
            ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();

                    _asyncManager.SendTimeZoneChangedClusterAddress(clusterAddress);
                }
            });

        }

        private void SendPanelDatabaseData(SendDataParameters<GalaxyCpuDatabaseInformation> data)
        {
            ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();

                    _asyncManager.SendPanelDatabaseDataToConnection(data);
                }
            });
        }

        public SendDataResponse<AccessPortal_PanelLoadData> SendAccessPortalSettingsToPanel(SendDataParameters<AccessPortal_PanelLoadData> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();
                    if (data.PopulateDataFromDatabase)
                    {
                        var repository = _DataRepositoryFactory.GetDataRepository<IAccessPortalRepository>();
                        data.Data = repository.GetAccessPortalPanelLoadData(ApplicationUserSessionHeader, new GetParametersWithPhoto() { UniqueId = data.Data.AccessPortalUid });

                    }
                    //var convertedEntity = new Cluster_CommonPanelLoadData();
                    //var list = new List<string>();
                    //list.Add("IsValid");
                    //list.Add("IsDirty");

                    //SimpleMapper.PropertyMap(loadData, convertedEntity);// list);
                    _asyncManager.SendAccessPortalSettingsToPanel(data);

                    SaveAuditRecord(data);


                }
                return new SendDataResponse<AccessPortal_PanelLoadData>(data.Data);
            });
        }

        public SendDataResponse<AccessGroup_PanelLoadData> SendAccessGroupSettingsToPanels(SendDataParameters<AccessGroup_PanelLoadData> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();
                    ResolveSendToAddress(data.SendToAddress);
                    if (data.PopulateDataFromDatabase)
                    {
                        var repository = _DataRepositoryFactory.GetDataRepository<IGalaxyAccessGroupRepository>();

                        if (data.Data.AccessGroupUid != Guid.Empty)
                        {
                            data.Data = repository.GetAccessGroupPanelLoadData(ApplicationUserSessionHeader, new GetParametersWithPhoto() { UniqueId = data.Data.AccessGroupUid });

                            _asyncManager.SendAccessGroupSettingsToPanels(data);

                            SaveAuditRecord(data);
                        }
                        else if (data.Data.ClusterUid != Guid.Empty)
                            data.Collection = repository.GetAccessGroupPanelLoadDataForCluster(ApplicationUserSessionHeader, new GetParametersWithPhoto()
                            {
                                UniqueId = data.Data.ClusterUid,
                                ClusterUid = data.Data.ClusterUid
                            }).ToList();
                        else if (data.SendToAddress.ClusterUid != Guid.Empty && data.SendToAddress.PanelUid != Guid.Empty)
                            data.Collection = repository.GetAccessGroupPanelLoadDataForGalaxyPanel(ApplicationUserSessionHeader, new GetParametersWithPhoto()
                            {
                                UniqueId = data.SendToAddress.ClusterUid,
                                ClusterUid = data.SendToAddress.ClusterUid,
                                GetGuid = data.SendToAddress.PanelUid
                            }).ToList();

                        foreach (var ag in data.Collection.ToList())
                        {
                            data.Collection.Clear();
                            var newData = new SendDataParameters<AccessGroup_PanelLoadData>(ag, data);
                            _asyncManager.SendAccessGroupSettingsToPanels(newData);
                            SaveAuditRecord(newData);
                        }

                        //var sendFinishedParams = new SendDataParameters<GalaxyPanel>()
                        //{ Data = new GalaxyPanel() { GalaxyPanelUid = data.SendToAddress.PanelUid } };

                        //_asyncManager.SendLoadDataFinished(sendFinishedParams, nameof(LoadDataToPanelSettings.AccessRules));
                    }


                }
                return new SendDataResponse<AccessGroup_PanelLoadData>(data.Data);
            });

        }

        public SendDataResponse<InputDevice_PanelLoadData> SendInputDeviceSettingsToPanel(SendDataParameters<InputDevice_PanelLoadData> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();
                    if (data.PopulateDataFromDatabase)
                    {
                        var repository = _DataRepositoryFactory.GetDataRepository<IInputDeviceRepository>();
                        data.Data = repository.GetInputDevicePanelLoadData(ApplicationUserSessionHeader, new GetParametersWithPhoto() { UniqueId = data.Data.InputDeviceUid });

                    }
                    //var convertedEntity = new Cluster_CommonPanelLoadData();
                    //var list = new List<string>();
                    //list.Add("IsValid");
                    //list.Add("IsDirty");

                    //SimpleMapper.PropertyMap(loadData, convertedEntity);// list);
                    _asyncManager.SendInputDeviceSettingsToPanel(data);

                    SaveAuditRecord(data);


                }
                return new SendDataResponse<InputDevice_PanelLoadData>(data.Data);
            });
        }

        public SendDataResponse<OutputDevice_PanelLoadData> SendOutputDeviceSettingsToPanel(SendDataParameters<OutputDevice_PanelLoadData> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();
                    if (data.PopulateDataFromDatabase)
                    {
                        var repository = _DataRepositoryFactory.GetDataRepository<IOutputDeviceRepository>();
                        data.Data = repository.GetOutputDevicePanelLoadData(ApplicationUserSessionHeader, new GetParametersWithPhoto() { UniqueId = data.Data.OutputDeviceUid });

                    }
                    //var convertedEntity = new Cluster_CommonPanelLoadData();
                    //var list = new List<string>();
                    //list.Add("IsValid");
                    //list.Add("IsDirty");

                    //SimpleMapper.PropertyMap(loadData, convertedEntity);// list);
                    _asyncManager.SendOutputDeviceSettingsToPanel(data);

                    SaveAuditRecord(data);


                }
                return new SendDataResponse<OutputDevice_PanelLoadData>(data.Data);
            });
        }

        public SendDataResponse<GalaxyPanelResetCommand> SendResetCommandToPanel(SendDataParameters<GalaxyPanelResetCommand> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    _asyncManager.SendResetCommand(data);
                    SaveAuditRecord(data);
                }
                return new SendDataResponse<GalaxyPanelResetCommand>(data.Data);
            });
        }

        #region Private methods

        private SendDataResponse<DateType_PanelLoadData> SendDateTypeData(SendDataParameters<DateType_PanelLoadData> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();
                    if (data.PopulateDataFromDatabase)
                    {
                        var repository = _DataRepositoryFactory.GetDataRepository<IDateTypeRepository>();

                        // A specific date has been saved. This date type could be used by multiple schedule types, 
                        // so this logic must get retrieve data for all schedule types and push out to all hardware effected
                        var legacy15MinuteDataToSend = repository.GetPanelLoadData(ApplicationUserSessionHeader, new GetParametersWithPhoto()
                        {
                            UniqueId = data.Data.DateTypeUid
                        }, GalaxySMS.Common.Enums.TimeScheduleType.GalaxyFifteenMinuteInterval);

                        var oneMinuteDataToSend = repository.GetPanelLoadData(ApplicationUserSessionHeader, new GetParametersWithPhoto()
                        {
                            UniqueId = data.Data.DateTypeUid
                        }, GalaxySMS.Common.Enums.TimeScheduleType.GalaxyOneMinuteInterval);

                        var dayTypeDefaultBehaviors = repository.GetDefaultBehaviorPanelLoadData(ApplicationUserSessionHeader, new GetParametersWithPhoto() { UniqueId = ApplicationUserSessionHeader.CurrentEntityId });
                        int month = 0;
                        if (data.Data.Date_x.IsWithinTheNextYear())
                            month = data.Data.Date_x.Month;
                        _asyncManager.SendDateTypeDataToPanels(legacy15MinuteDataToSend, month, dayTypeDefaultBehaviors, data);
                        _asyncManager.SendDateTypeDataToPanels(oneMinuteDataToSend, month, dayTypeDefaultBehaviors, data);
                    }
                    SaveAuditRecord(data);
                }
                return new SendDataResponse<DateType_PanelLoadData>(data.Data);
            });
        }

        private SendDataResponse<DateType_GetClustersThatUseDateType> SendDateTypeData(SendDataParameters<DateType_GetClustersThatUseDateType> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();
                    if (data.PopulateDataFromDatabase)
                    {
                        var repository = _DataRepositoryFactory.GetDataRepository<IDateTypeRepository>();
                        foreach (var c in data.Collection)
                        {
                            // A specific date has been saved. This date type could be used by multiple schedule types, 
                            // so this logic must get retrieve data for all schedule types and push out to all hardware effected
                            var dataToSend = repository.GetPanelLoadDataForCluster(ApplicationUserSessionHeader, new GetParametersWithPhoto()
                            {
                                UniqueId = c.ClusterUid
                            }).ToList();
                            var dayTypeDefaultBehaviors = repository.GetDefaultBehaviorPanelLoadData(ApplicationUserSessionHeader, new GetParametersWithPhoto() { UniqueId = ApplicationUserSessionHeader.CurrentEntityId });

                            if (!dataToSend.Any())
                            {
                                //var clusterRepository = _DataRepositoryFactory.GetDataRepository<IClusterRepository>();
                                //var cluster = clusterRepository.Get(c.cl)
                                dataToSend.Add(new DateType_PanelLoadData()
                                {
                                    ClusterGroupId = c.ClusterGroupId,
                                    ClusterNumber = c.ClusterNumber,
                                    ClusterName = c.ClusterName,
                                    ScheduleTypeCode = c.ScheduleTypeCode
                                });
                            }
                            // If the data.Data.Date_x is a valid date within the next year, then only load the month that the date belongs to
                            if (data.Data.Date_x.IsWithinTheNextYear())
                                _asyncManager.SendDateTypeDataToPanels(dataToSend, data.Data.Date_x.Month, dayTypeDefaultBehaviors, data);
                            else
                                _asyncManager.SendDateTypeDataToPanels(dataToSend, 0, dayTypeDefaultBehaviors, data);

                        }
                    }

                    SaveAuditRecord(data);
                }
                return new SendDataResponse<DateType_GetClustersThatUseDateType>(data.Data);
            });
        }

        private SendDataResponse<TimeSchedule_PanelLoadData> SendTimeScheduleData(SendDataParameters<TimeSchedule_PanelLoadData> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();
                    if (data.PopulateDataFromDatabase)
                    {
                        var repository = _DataRepositoryFactory.GetDataRepository<ITimeScheduleRepository>();
                        var dataToSend = repository.GetTimeSchedulePanelLoadData(ApplicationUserSessionHeader, new GetParametersWithPhoto<TimeSchedule_PanelLoadData>()
                        {
                            UniqueId = data.Data.TimeScheduleUid,
                            Data = data.Data
                        });

                        _asyncManager.SendTimeScheduleData(dataToSend, data);

                    }

                    SaveAuditRecord(data);
                }
                return new SendDataResponse<TimeSchedule_PanelLoadData>(data.Data);
            });
        }

        private SendDataResponse<GalaxyTimePeriod_PanelLoadData> SendGalaxyTimePeriodData(SendDataParameters<GalaxyTimePeriod_PanelLoadData> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();
                    if (data.PopulateDataFromDatabase)
                    {
                        var repository = _DataRepositoryFactory.GetDataRepository<IGalaxyTimePeriodRepository>();
                        var dataToSend = repository.GetGalaxyTimePeriodPanelLoadData(ApplicationUserSessionHeader, new GetParametersWithPhoto<GalaxyTimePeriod_PanelLoadData>()
                        {
                            UniqueId = data.Data.GalaxyTimePeriodUid,
                            Data = data.Data
                        });

                        _asyncManager.SendGalaxyTimePeriodData(dataToSend, data);

                    }

                    SaveAuditRecord(data);
                }
                return new SendDataResponse<GalaxyTimePeriod_PanelLoadData>(data.Data);
            });
        }

        private SendDataResponse<TimeSchedule_PanelLoadData> SendAllScheduleData(SendDataParameters<TimeSchedule_PanelLoadData> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();
                    ResolveSendToAddress(data.SendToAddress);
                    if (data.PopulateDataFromDatabase)
                    {
                        var clusterRepository = _DataRepositoryFactory.GetDataRepository<IClusterRepository>();

                        var clusterGetParams = new GetParametersWithPhoto()
                        {
                            UniqueId = data.Data.ClusterUid,
                        };

                        var clusterData = clusterRepository.GetCommonPanelLoadData(ApplicationUserSessionHeader, clusterGetParams);
                        if (clusterData != null)
                        {
                            //ResolveSendToAddress(data.SendToAddress );

                            var dateTypeRepository = _DataRepositoryFactory.GetDataRepository<IDateTypeRepository>();

                            // A specific date has been saved. This date type could be used by multiple schedule types, 
                            // so this logic must get retrieve data for all schedule types and push out to all hardware effected
                            var dateTypeDataToSend = dateTypeRepository.GetPanelLoadDataForCluster(ApplicationUserSessionHeader, clusterGetParams);

                            var dayTypeDefaultBehaviors = dateTypeRepository.GetDefaultBehaviorPanelLoadData(ApplicationUserSessionHeader, new GetParametersWithPhoto() { UniqueId = ApplicationUserSessionHeader.CurrentEntityId });

                            //var firstDayType = dateTypeDataToSend.FirstOrDefault();
                            //if (firstDayType != null)
                            //{
                            //var schType = (GalaxySMS.Common.Enums.TimeScheduleType)firstDayType.ScheduleTypeCode;

                            if (!dateTypeDataToSend.Any())
                            {
                                //var clusterRepository = _DataRepositoryFactory.GetDataRepository<IClusterRepository>();
                                //var cluster = clusterRepository.Get(c.cl)
                                var tempDataToSend = new List<DateType_PanelLoadData>();

                                tempDataToSend.Add(new DateType_PanelLoadData()
                                {
                                    ClusterGroupId = clusterData.ClusterGroupId,
                                    ClusterNumber = clusterData.ClusterNumber,
                                    ClusterName = clusterData.ClusterName,
                                    ScheduleTypeCode = clusterData.TimeScheduleTypeCode,
                                });
                                dateTypeDataToSend = tempDataToSend;
                            }

                            var schType = (GalaxySMS.Common.Enums.TimeScheduleType)clusterData.TimeScheduleTypeCode;


                            if (schType == GalaxySMS.Common.Enums.TimeScheduleType.GalaxyFifteenMinuteInterval)
                            {
                                for (int month = 1; month <= 12; month++)
                                    _asyncManager.SendDateTypeDataToPanels(dateTypeDataToSend, month, dayTypeDefaultBehaviors, data);
                            }
                            else
                                _asyncManager.SendDateTypeDataToPanels(dateTypeDataToSend, 0, dayTypeDefaultBehaviors, data);
                            //}

                            var timePeriodRepository = _DataRepositoryFactory.GetDataRepository<IGalaxyTimePeriodRepository>();
                            var timePeriodDataToSend = timePeriodRepository.GetGalaxyTimePeriodPanelLoadData(ApplicationUserSessionHeader, new GetParametersWithPhoto<GalaxyTimePeriod_PanelLoadData>()
                            {
                                UniqueId = data.Data.ClusterUid,
                                Data = new GalaxyTimePeriod_PanelLoadData() { ClusterUid = data.Data.ClusterUid, }
                            });

                            _asyncManager.SendGalaxyTimePeriodData(timePeriodDataToSend, data);


                            var timeScheduleRepository = _DataRepositoryFactory.GetDataRepository<ITimeScheduleRepository>();
                            var p = new GetParametersWithPhoto<TimeSchedule_PanelLoadData>();
                            p.ClusterUid = data.Data.ClusterUid;
                            p.Data.ClusterUid = data.Data.ClusterUid;

                            var scheduleDataToSend = timeScheduleRepository.GetTimeSchedulePanelLoadData(ApplicationUserSessionHeader, p);
                            _asyncManager.SendTimeScheduleData(scheduleDataToSend, data);

                            //var sendFinishedParams = new SendDataParameters<GalaxyPanel>(data);
                            //_asyncManager.SendLoadDataFinished(sendFinishedParams, nameof(LoadDataToPanelSettings.TimeSchedules));
                        }
                    }

                    SaveAuditRecord(data);
                }
                return new SendDataResponse<TimeSchedule_PanelLoadData>(data.Data);
            });
        }

        private SendDataResponse<GalaxyPanelAlarmSettings_PanelLoadData> SendGalaxyPanelAlarmDataToPanels(SendDataParameters<GalaxyPanelAlarmSettings_PanelLoadData> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();
                    if (data.PopulateDataFromDatabase)
                    {

                        var repo = _DataRepositoryFactory.GetDataRepository<IGalaxyPanelRepository>();

                        IEnumerable<GalaxyPanelAlarmSettings_PanelLoadData> dataToSend = null;
                        if (data.Data.GalaxyPanelUid != Guid.Empty)
                            dataToSend = repo.GetAlarmEventSettingsByGalaxyPanelUid(ApplicationUserSessionHeader, new GetParametersWithPhoto()
                            {
                                UniqueId = data.Data.GalaxyPanelUid,
                            });
                        else
                            dataToSend = repo.GetAlarmEventSettingsByClusterUid(ApplicationUserSessionHeader, new GetParametersWithPhoto()
                            {
                                UniqueId = data.Data.ClusterUid,
                            });


                        var data1 = new SendDataParameters<GalaxyPanelAlarmSettings_PanelLoadData>() { Collection = dataToSend.ToList(), ApplicationUserSessionHeader = data.ApplicationUserSessionHeader, OperationUid = data.OperationUid };

                        _asyncManager.SendGalaxyPanelAlarmData(data1);

                    }

                    SaveAuditRecord(data);
                }
                return new SendDataResponse<GalaxyPanelAlarmSettings_PanelLoadData>(data.Data);
            });
        }

        //private SendDataResponse SendLoadFinishedData(SendDataParameters data)
        //{
        //    return ExecuteFaultHandledOperation(() =>
        //    {
        //        if (_asyncManager != null)
        //        {
        //            GetApplicationUserSessionHeader();
        //            var repo = _DataRepositoryFactory.GetDataRepository<IGalaxyPanelRepository>();

        //            IList<GalaxyPanel> dataToSend = null;
        //            if (data.SendToAddress.PanelUid != Guid.Empty)
        //            {
        //                dataToSend = new List<GalaxyPanel>();
        //                var p = repo.Get(data.SendToAddress.PanelUid, ApplicationUserSessionHeader, new GetParametersWithPhoto()
        //                {
        //                    UniqueId = data.SendToAddress.PanelUid,
        //                });
        //                if (p != null)
        //                    dataToSend.Add(p);
        //            }
        //            else
        //                dataToSend = repo.GetAllGalaxyPanelsForCluster(ApplicationUserSessionHeader, new GetParametersWithPhoto()
        //                {
        //                    UniqueId = data.SendToAddress.ClusterUid,
        //                }).Items;


        //            var data1 = new SendDataParameters<GalaxyPanel>() { Collection = dataToSend.ToList(), ApplicationUserSessionHeader = data.ApplicationUserSessionHeader, OperationUid = data.OperationUid };


        //            _asyncManager.SendLoadDataFinished(data1, "loaddata");

        //        }

        //        return new SendDataResponse();
        //    });
        //}

        private SendDataResponse<InputOutputGroup_PanelLoadData> SendInputOutputGroupToPanels(SendDataParameters<InputOutputGroup_PanelLoadData> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();
                    if (data.PopulateDataFromDatabase)
                    {
                        ResolveSendToAddress(data.SendToAddress);

                        var ioGroupRepository = _DataRepositoryFactory.GetDataRepository<IGalaxyInputOutputGroupRepository>();

                        // A specific date has been saved. This date type could be used by multiple schedule types, 
                        // so this logic must get retrieve data for all schedule types and push out to all hardware effected
                        var dataToSend = ioGroupRepository.GetInputOutputGroupPanelLoadData(ApplicationUserSessionHeader, new GetParametersWithPhoto()
                        {
                            UniqueId = data.Data.InputOutputGroupUid,
                        });

                        var ioGroupData = new SendDataParameters<InputOutputGroup_PanelLoadData>() { Data = dataToSend, ApplicationUserSessionHeader = data.ApplicationUserSessionHeader, SendToAddress = data.SendToAddress };


                        _asyncManager.SendGalaxyInputOutputGroupData(ioGroupData);

                    }

                    SaveAuditRecord(data);
                }
                return new SendDataResponse<InputOutputGroup_PanelLoadData>(data.Data);
            });
        }

        private SendDataResponse<InputOutputGroup_PanelLoadData> SendAllClusterInputOutputGroupsToPanels(SendDataParameters<InputOutputGroup_PanelLoadData> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();
                    ResolveSendToAddress(data.SendToAddress);
                    if (data.PopulateDataFromDatabase)
                    {
                        var ioGroupRepository = _DataRepositoryFactory.GetDataRepository<IGalaxyInputOutputGroupRepository>();

                        // A specific date has been saved. This date type could be used by multiple schedule types, 
                        // so this logic must get retrieve data for all schedule types and push out to all hardware effected
                        var d = ioGroupRepository.GetAllInputOutputGroupPanelLoadDataForCluster(ApplicationUserSessionHeader, new GetParametersWithPhoto()
                        {
                            UniqueId = data.Data.ClusterUid,
                        });

                        var dataToSend = new SendDataParameters<InputOutputGroup_PanelLoadData>(data);
                        dataToSend.Collection = d.ToList();
                        if (dataToSend.Collection.Any())
                        {
                            var first = dataToSend.Collection.FirstOrDefault();
                            if (first != null)
                            {
                                dataToSend.SendToAddress.ClusterGroupId = first.ClusterGroupId;
                                dataToSend.SendToAddress.ClusterNumber = first.ClusterNumber;
                                dataToSend.SendToAddress.PanelNumber = (int)PanelNumber.AllPanels;
                                dataToSend.SendToAddress.CpuId = (short)CpuHardwareAddress.CpuNumber.Both;
                                if (data.SendToAddress.PanelUid != Guid.Empty)
                                {
                                    var panelRepo = _DataRepositoryFactory.GetDataRepository<IGalaxyPanelRepository>();
                                    var p = panelRepo.Get(data.SendToAddress.PanelUid,
                                        this.ApplicationUserSessionHeader, new GetParametersWithPhoto());
                                    if (p != null)
                                        dataToSend.SendToAddress.PanelNumber = p.PanelNumber;
                                }
                            }

                        }

                        _asyncManager.SendAllGalaxyClusterInputOutputGroupData(dataToSend);

                    }

                    SaveAuditRecord(data);
                }
                return new SendDataResponse<InputOutputGroup_PanelLoadData>(data.Data);
            });
        }

        //private SendDataResponse<Credential_PanelLoadData> SendCredentialData(SendDataParameters<Credential_PanelLoadData> data)
        //{
        //    return ExecuteFaultHandledOperation(() =>
        //    {
        //        if (_asyncManager != null)
        //        {
        //            GetApplicationUserSessionHeader();
        //            if (data.PopulateDataFromDatabase)
        //            {
        //                var repository = _DataRepositoryFactory.GetDataRepository<IPersonRepository>();
        //                var dataToSend = repository.GetCredentialPanelLoadDataForPerson(ApplicationUserSessionHeader, new GetParametersWithPhoto<Credential_PanelLoadData>()
        //                {
        //                    UniqueId = data.Data.PersonUid,
        //                    PersonUid = data.Data.PersonUid,
        //                    Data = data.Data
        //                });

        //                if (dataToSend != null)
        //                {
        //                    var anyPersonalAccessGroups = dataToSend.FirstOrDefault(o => o.AccessGroup4 == (int)GalaxySMS.Common.Enums.AccessGroupNumber.PersonalGroup);
        //                    IEnumerable<PersonalAccessGroup_PanelLoadData> personalAccessGroupDataToSend = new List<PersonalAccessGroup_PanelLoadData>();
        //                    if (anyPersonalAccessGroups != null)
        //                    {
        //                        personalAccessGroupDataToSend = repository.GetPersonalAccessGroupPanelLoadData(ApplicationUserSessionHeader,
        //                            new GetParametersWithPhoto<PersonalAccessGroup_PanelLoadData>()
        //                            {
        //                                UniqueId = data.Data.PersonUid,
        //                                PersonUid = data.Data.PersonUid,
        //                            });
        //                    }

        //                    if (data.OperationUid != Guid.Empty)
        //                    {
        //                        dataToSend.All(c =>
        //                        {
        //                            c.OperationUid = data.OperationUid;
        //                            return true;
        //                        });
        //                        if (personalAccessGroupDataToSend.Any())
        //                        {
        //                            personalAccessGroupDataToSend.All(c =>
        //                            {
        //                                c.OperationUid = data.OperationUid;
        //                                return true;
        //                            });
        //                        }
        //                    }

        //                    _asyncManager.SendCredentialData(dataToSend, personalAccessGroupDataToSend, data.SendToAddress);
        //                }
        //            }

        //            SaveAuditRecord(data);
        //        }
        //        return new SendDataResponse<Credential_PanelLoadData>(data.Data);
        //    });
        //}
        private SendDataResponse<Credential_PanelLoadData> SendCredentialData(SendDataParameters<Credential_PanelLoadData> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();
                    if (data.PopulateDataFromDatabase)
                    {
                        var repository = _DataRepositoryFactory.GetDataRepository<IPersonRepository>();
                        var dataToSend = new SendDataParameters<List<Credential_PanelLoadData>>(data)
                        {
                            Data = repository.GetCredentialPanelLoadDataForPerson(ApplicationUserSessionHeader,
                                new GetParametersWithPhoto<Credential_PanelLoadData>()
                                {
                                    UniqueId = data.Data.PersonUid,
                                    PersonUid = data.Data.PersonUid,
                                    Data = data.Data
                                }).ToList()
                        };

                        if (dataToSend?.Data != null)
                        {
                            var personalAccessGroupDataToSend = new SendDataParameters<List<PersonalAccessGroup_PanelLoadData>>(data);
                            var anyPersonalAccessGroups = dataToSend.Data.FirstOrDefault(o => o.AccessGroup4 == (int)GalaxySMS.Common.Enums.AccessGroupNumber.PersonalGroup);
                            if (anyPersonalAccessGroups != null)
                            {
                                personalAccessGroupDataToSend.Data = repository.GetPersonalAccessGroupPanelLoadData(
                                            ApplicationUserSessionHeader,
                                            new GetParametersWithPhoto<PersonalAccessGroup_PanelLoadData>()
                                            {
                                                UniqueId = data.Data.PersonUid,
                                                PersonUid = data.Data.PersonUid,
                                            }).ToList();
                            }


                            _asyncManager.SendCredentialData(dataToSend, personalAccessGroupDataToSend);
                        }
                    }

                    SaveAuditRecord(data);
                }
                return new SendDataResponse<Credential_PanelLoadData>(data.Data);
            });
        }

        private void SendChangesToHardware()
        {
            ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    //OperationContext context = OperationContext.Current;
                    //if (context != null && context.IncomingMessageHeaders == null)
                    //    this.Log().Info($"context != null && context.IncomingMessageHeaders == null");

                    GetApplicationUserSessionHeader();
                    var getParams = new GetParametersWithPhoto()
                    {
                        UniqueId = Guid.Empty,
                        GetString = _ServerAddress
                    };

                    var credentialsToDeleteRepository = _DataRepositoryFactory.GetDataRepository<ICredentialToDeleteFromCpuRepository>();
                    var credentialsToDelete = credentialsToDeleteRepository.GetAllThatNeedDeletedForCpu(ApplicationUserSessionHeader, getParams);

                    var personRepository = _DataRepositoryFactory.GetDataRepository<IPersonRepository>();
                    var personDataToSend = personRepository.GetModifiedCredentialPanelLoadDataForCpu(ApplicationUserSessionHeader, getParams);

                    if (credentialsToDelete != null && credentialsToDelete.Any())
                    {
                        _asyncManager.SendDeleteCredentialData(credentialsToDelete);
                    }

                    if (personDataToSend != null && personDataToSend.Any())
                    {
                        IList<PersonalAccessGroup_PanelLoadData> personalAccessGroupDataToSend = new List<PersonalAccessGroup_PanelLoadData>();
                        var personalAccessGroupCards = personDataToSend.DistinctBy(o => o.PersonUid).Where(o => o.AccessGroup4 == (int)GalaxySMS.Common.Enums.AccessGroupNumber.PersonalGroup).ToList();

                        foreach (var c in personDataToSend.DistinctBy(o => o.PersonUid).Where(o => o.AccessGroup4 == (int)GalaxySMS.Common.Enums.AccessGroupNumber.PersonalGroup))
                        {
                            if (c.AccessGroup4 == (int)GalaxySMS.Common.Enums.AccessGroupNumber.PersonalGroup)
                            {
                                var pagData = personRepository.GetPersonalAccessGroupPanelLoadData(ApplicationUserSessionHeader,
                                   new GetParametersWithPhoto<PersonalAccessGroup_PanelLoadData>()
                                   {
                                       UniqueId = c.PersonUid,
                                       PersonUid = c.PersonUid,
                                   });
                                if (pagData.Any())
                                    personalAccessGroupDataToSend.AddRange(pagData);
                            }
                        }
                        this.Log().Info($"SendChangesToHardware calling _asyncManager.SetPersonDataToSend with {personDataToSend.Count()} records.");
                        _asyncManager.SetPersonDataToSend(personDataToSend, personalAccessGroupDataToSend, new SendDataParameters());
                    }


                    var accessPortalRespository = _DataRepositoryFactory.GetDataRepository<IAccessPortalRepository>();
                    var accessPortalDataToSend = accessPortalRespository.GetModifiedPanelLoadDataForCpu(ApplicationUserSessionHeader, getParams);

                    if (accessPortalDataToSend != null && accessPortalDataToSend.Any())
                    {
                        foreach (var ap in accessPortalDataToSend)
                        {
                            var sendParameters = new SendDataParameters<AccessPortal_PanelLoadData>()
                            {
                                ApplicationUserSessionHeader = this.ApplicationUserSessionHeader,
                                Data = ap,
                            };
                            _asyncManager.SendAccessPortalSettingsToPanel(sendParameters);
                        }
                    }

                    var accessGroupRepository = _DataRepositoryFactory.GetDataRepository<IGalaxyAccessGroupRepository>();
                    var accessGroupDataToSend = accessGroupRepository.GetModifiedAccessGroupPanelLoadDataForCpu(ApplicationUserSessionHeader, getParams);

                    if (accessGroupDataToSend != null && accessGroupDataToSend.Any())
                    {
                        foreach (var ag in accessGroupDataToSend)
                            _asyncManager.SendAccessGroupToCpu(ag);
                    }



                    var inputDeviceRespository = _DataRepositoryFactory.GetDataRepository<IInputDeviceRepository>();
                    var inputDeviceDataToSend = inputDeviceRespository.GetModifiedPanelLoadDataForCpu(ApplicationUserSessionHeader, getParams);

                    if (inputDeviceDataToSend != null && inputDeviceDataToSend.Any())
                    {
                        foreach (var id in inputDeviceDataToSend)
                        {
                            var sendParameters = new SendDataParameters<InputDevice_PanelLoadData>()
                            {
                                ApplicationUserSessionHeader = this.ApplicationUserSessionHeader,
                                Data = id,
                            };
                            _asyncManager.SendInputDeviceSettingsToPanel(sendParameters);
                        }
                    }


                    var outputDeviceRespository = _DataRepositoryFactory.GetDataRepository<IOutputDeviceRepository>();
                    var outputDeviceDataToSend = outputDeviceRespository.GetModifiedPanelLoadDataForCpu(ApplicationUserSessionHeader, getParams);

                    if (outputDeviceDataToSend != null && outputDeviceDataToSend.Any())
                    {
                        foreach (var od in outputDeviceDataToSend)
                        {
                            var sendParameters = new SendDataParameters<OutputDevice_PanelLoadData>()
                            {
                                ApplicationUserSessionHeader = this.ApplicationUserSessionHeader,
                                Data = od,
                            };
                            _asyncManager.SendOutputDeviceSettingsToPanel(sendParameters);
                        }
                    }

                }
            });
        }

        //private SendDataResponse<Credential_PanelLoadData> SendAllCredentialData(SendDataParameters<Credential_PanelLoadData> data)
        //{
        //    return ExecuteFaultHandledOperation(() =>
        //    {
        //        if (_asyncManager != null)
        //        {
        //            GetApplicationUserSessionHeader();
        //            if (data.PopulateDataFromDatabase)
        //            {
        //                var repository = _DataRepositoryFactory.GetDataRepository<IPersonRepository>();
        //                var dataToSend = repository.GetCredentialPanelLoadDataForCluster(ApplicationUserSessionHeader, new GetParametersWithPhoto<Credential_PanelLoadData>()
        //                {
        //                    UniqueId = data.Data.ClusterUid,
        //                    ClusterUid = data.Data.ClusterUid,
        //                    Data = data.Data
        //                }).ToList();

        //                var sendDataParameters = new SendDataParameters<List<Credential_PanelLoadData>>(data)
        //                {
        //                    Data = dataToSend
        //                };

        //                if (dataToSend != null)
        //                {
        //                    IList<PersonalAccessGroup_PanelLoadData> personalAccessGroupDataToSend = new List<PersonalAccessGroup_PanelLoadData>();
        //                    var personalAccessGroupCards = dataToSend.DistinctBy(o => o.PersonUid).Where(o => o.AccessGroup4 == (int)GalaxySMS.Common.Enums.AccessGroupNumber.PersonalGroup).ToList();

        //                    foreach (var c in dataToSend.DistinctBy(o => o.PersonUid).Where(o => o.AccessGroup4 == (int)GalaxySMS.Common.Enums.AccessGroupNumber.PersonalGroup))
        //                    {
        //                        if (c.AccessGroup4 == (int)GalaxySMS.Common.Enums.AccessGroupNumber.PersonalGroup)
        //                        {
        //                            var pagData = repository.GetPersonalAccessGroupPanelLoadData(ApplicationUserSessionHeader,
        //                               new GetParametersWithPhoto<PersonalAccessGroup_PanelLoadData>()
        //                               {
        //                                   UniqueId = c.PersonUid,
        //                                   PersonUid = c.PersonUid,
        //                               });
        //                            if (pagData.Any())
        //                                personalAccessGroupDataToSend.AddRange(pagData);
        //                        }
        //                    }

        //                    if (data.OperationUid != Guid.Empty)
        //                    {
        //                        dataToSend.All(c =>
        //                        {
        //                            c.OperationUid = data.OperationUid;
        //                            return true;
        //                        });
        //                        if (personalAccessGroupDataToSend.Any())
        //                        {
        //                            personalAccessGroupDataToSend.All(c =>
        //                            {
        //                                c.OperationUid = data.OperationUid;
        //                                return true;
        //                            });
        //                        }
        //                    }

        //                    _asyncManager.SendCredentialData(dataToSend, personalAccessGroupDataToSend, data.SendToAddress);
        //                }
        //            }

        //            SaveAuditRecord(data);
        //        }
        //        return new SendDataResponse<Credential_PanelLoadData>(data.Data);
        //    });
        //}

        private SendDataResponse<Credential_PanelLoadData> SendAllCredentialData(SendDataParameters<Credential_PanelLoadData> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();
                    if (data.PopulateDataFromDatabase)
                    {
                        var repository = _DataRepositoryFactory.GetDataRepository<IPersonRepository>();

                        ResolveSendToAddress(data.SendToAddress);

                        var sendDataParameters = new SendDataParameters<List<Credential_PanelLoadData>>(data)
                        {
                            Data = repository.GetCredentialPanelLoadDataForCluster(ApplicationUserSessionHeader, new GetParametersWithPhoto<Credential_PanelLoadData>()
                            {
                                UniqueId = data.Data.ClusterUid,
                                ClusterUid = data.Data.ClusterUid,
                                Data = data.Data
                            }).ToList()
                        };


                        if (sendDataParameters.Data != null && sendDataParameters.Data.Any())
                        {
                            var personalAccessGroupDataToSend =
                                new SendDataParameters<List<PersonalAccessGroup_PanelLoadData>>(data)
                                {

                                };
                            var personalAccessGroupCards = sendDataParameters.Data.DistinctBy(o => o.PersonUid).Where(o => o.AccessGroup4 == (int)GalaxySMS.Common.Enums.AccessGroupNumber.PersonalGroup).ToList();

                            foreach (var c in sendDataParameters.Data.DistinctBy(o => o.PersonUid).Where(o => o.AccessGroup4 == (int)GalaxySMS.Common.Enums.AccessGroupNumber.PersonalGroup))
                            {
                                if (c.AccessGroup4 == (int)GalaxySMS.Common.Enums.AccessGroupNumber.PersonalGroup)
                                {
                                    var pagData = repository.GetPersonalAccessGroupPanelLoadData(ApplicationUserSessionHeader,
                                       new GetParametersWithPhoto<PersonalAccessGroup_PanelLoadData>()
                                       {
                                           UniqueId = c.PersonUid,
                                           PersonUid = c.PersonUid,
                                       });
                                    if (pagData.Any())
                                        personalAccessGroupDataToSend.Data.AddRange(pagData);
                                }
                            }

                            if (data.OperationUid != Guid.Empty)
                            {
                                sendDataParameters.Data.All(c =>
                                {
                                    c.OperationUid = data.OperationUid;
                                    return true;
                                });
                                if (personalAccessGroupDataToSend.Data.Any())
                                {
                                    personalAccessGroupDataToSend.Data.All(c =>
                                    {
                                        c.OperationUid = data.OperationUid;
                                        return true;
                                    });
                                }
                            }

                            _asyncManager.SendCredentialData(sendDataParameters, personalAccessGroupDataToSend);

                            //var sendDataParams = new SendDataParameters<GalaxyPanel>(sendDataParameters);
                            //_asyncManager.SendLoadDataFinished(sendDataParams, nameof(LoadDataToPanelSettings.AllCardData));
                        }
                    }

                    SaveAuditRecord(data);
                }
                return new SendDataResponse<Credential_PanelLoadData>(data.Data);
            });
        }

        // Fill in hardware address based on ClusterUid, PanelUid and CpuUid values
        private void ResolveSendToAddress(BoardSectionNodeHardwareAddress data)
        {
            var repo = _DataRepositoryFactory.GetDataRepository<IGalaxyCpuRepository>();
            var cpus = repo.GetGalaxyCpuInformation(this.ApplicationUserSessionHeader,
                new GetHardwareAddressParameters()
                {
                    ClusterUid = data.ClusterUid,
                    GalaxyPanelUid = data.PanelUid,
                    CpuUid = data.CpuUid,
                    ClusterGroupId = data.ClusterGroupId,
                    ClusterNumber = data.ClusterNumber,
                    PanelNumber = data.PanelNumber,
                    CpuNumber = data.CpuId
                });
            var first = cpus.FirstOrDefault();
            if (first != null)
            {
                if (data.CpuUid != Guid.Empty)
                {
                    data.ClusterGroupId = first.ClusterGroupId;
                    data.ClusterNumber = first.ClusterNumber;
                    data.PanelNumber = first.PanelNumber;
                    data.CpuId = first.CpuNumber;
                }
                else if (data.PanelUid != Guid.Empty)
                {
                    data.ClusterGroupId = first.ClusterGroupId;
                    data.ClusterNumber = first.ClusterNumber;
                    data.PanelNumber = first.PanelNumber;
                    data.CpuId = 0;
                }
                else if (data.ClusterUid != Guid.Empty)
                {
                    data.ClusterGroupId = first.ClusterGroupId;
                    data.ClusterNumber = first.ClusterNumber;
                    data.PanelNumber = 0;
                    data.CpuId = 0;
                }
            }
        }

        private SendDataResponse<CredentialToDeleteFromCpu> SendDeleteCredentialData(SendDataParameters<CredentialToDeleteFromCpu> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();
                    if (data.PopulateDataFromDatabase)
                    {
                        var repository = _DataRepositoryFactory.GetDataRepository<ICredentialToDeleteFromCpuRepository>();
                        var dataToSend = repository.GetAllThatNeedDeleted(ApplicationUserSessionHeader, new GetParametersWithPhoto() { GetString = _ServerAddress });

                        if (dataToSend != null)
                        {
                            _asyncManager.SendDeleteCredentialData(dataToSend);
                        }
                    }

                    SaveAuditRecord(data);
                }
                return new SendDataResponse<CredentialToDeleteFromCpu>(data.Data);
            });
        }

        private SendDataResponse<GalaxyCpuCommandAction> SendCpuCommandToPanels(SendDataParameters<GalaxyCpuCommandAction> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();

                    _asyncManager.SendCpuCommandToPanels(data);

                    SaveAuditRecord(data);
                }
                return new SendDataResponse<GalaxyCpuCommandAction>(data.Data);
            });
        }

        private SendDataResponse<GalaxyCpuCommandAction> SendClusterCommandToPanels(SendDataParameters<GalaxyCpuCommandAction> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();

                    _asyncManager.SendClusterCommandToPanels(data);

                    SaveAuditRecord(data);
                }
                return new SendDataResponse<GalaxyCpuCommandAction>(data.Data);
            });
        }

        private SendDataResponse<GalaxyLoadFlashCommandAction> SendGalaxyLoadFlashCommandToPanels(SendDataParameters<GalaxyLoadFlashCommandAction> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();
                    _asyncManager.SendGalaxyLoadFlashCommandToPanels(data);

                    SaveAuditRecord(data);
                }
                return new SendDataResponse<GalaxyLoadFlashCommandAction>(data.Data);
            });
        }

        private SendDataResponse<AccessPortalCommandAction> SendAccessPortalCommandToPanels(SendDataParameters<AccessPortalCommandAction> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();

                    _asyncManager.SendAccessPortalCommandToPanels(data);

                    if (data.Data.CommandUid != GalaxySMS.Common.Constants.AccessPortalCommandIds.RequestStatus)
                        SaveAuditRecord(data);

                }
                return new SendDataResponse<AccessPortalCommandAction>(data.Data);
            });
        }

        private SendDataResponse<InputDeviceCommandAction> SendInputDeviceCommandToPanels(SendDataParameters<InputDeviceCommandAction> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();

                    _asyncManager.SendInputDeviceCommandToPanels(data);

                    if (data.Data.CommandUid != GalaxySMS.Common.Constants.InputCommandIds.RequestStatus &&
                        data.Data.CommandUid != GalaxySMS.Common.Constants.InputCommandIds.ReadVoltages)
                        SaveAuditRecord(data);

                }
                return new SendDataResponse<InputDeviceCommandAction>(data.Data);
            });
        }

        private SendDataResponse<OutputDeviceCommandAction> SendOutputDeviceCommandToPanels(SendDataParameters<OutputDeviceCommandAction> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();

                    _asyncManager.SendOutputDeviceCommandToPanels(data);

                    if (data.Data.CommandUid != GalaxySMS.Common.Constants.InputCommandIds.RequestStatus &&
                        data.Data.CommandUid != GalaxySMS.Common.Constants.InputCommandIds.ReadVoltages)
                        SaveAuditRecord(data);

                }
                return new SendDataResponse<OutputDeviceCommandAction>(data.Data);
            });
        }

        private SendDataResponse<InputOutputGroupCommandAction> SendInputOutputGroupCommandToPanels(SendDataParameters<InputOutputGroupCommandAction> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();

                    _asyncManager.SendInputOutputGroupCommandToPanels(data);

                    if (data.Data.CommandUid != GalaxySMS.Common.Constants.AccessPortalCommandIds.RequestStatus)
                        SaveAuditRecord(data);

                }
                return new SendDataResponse<InputOutputGroupCommandAction>(data.Data);
            });
        }


        private SendDataResponse<GalaxyInterfaceBoardSectionCommandAction> SendGalaxyBoardSectionCommandToPanels(SendDataParameters<GalaxyInterfaceBoardSectionCommandAction> data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (_asyncManager != null)
                {
                    GetApplicationUserSessionHeader();

                    _asyncManager.SendBoardSectionCommandToPanels(data);

                    if (data.Data.CommandUid != GalaxySMS.Common.Constants.GalaxyInterfaceBoardSectionCommandIds.GalaxyInterfaceBoardSectionCommand_RequestSerialChannelRS485DeviceInfo)
                        SaveAuditRecord(data);

                }
                return new SendDataResponse<GalaxyInterfaceBoardSectionCommandAction>(data.Data);
            });
        }


        private IEnumerable<Guid> GetAccessPortalUidsForInterfaceBoardSection(Guid id)
        {
            var repository = _DataRepositoryFactory.GetDataRepository<IAccessPortalRepository>();
            return repository.GetAccessPortalUidsForInterfaceBoardSection(this.ApplicationUserSessionHeader, new GetParametersWithPhoto() { UniqueId = id });
        }

        private IEnumerable<AccessPortal_PanelLoadData> GetAccessPortalLoadDataForInterfaceBoardSection(Guid id)
        {
            var repository = _DataRepositoryFactory.GetDataRepository<IAccessPortalRepository>();
            return repository.GetAccessPortalsPanelLoadData(this.ApplicationUserSessionHeader, new GetParametersWithPhoto() { UniqueId = id });
        }


        private IEnumerable<InputDevice_PanelLoadData> GetInputDeviceLoadDataForInterfaceBoardSection(Guid id)
        {
            var repository = _DataRepositoryFactory.GetDataRepository<IInputDeviceRepository>();
            return repository.GetInputDevicesPanelLoadData(this.ApplicationUserSessionHeader, new GetParametersWithPhoto() { UniqueId = id });
        }

        private IEnumerable<OutputDevice_PanelLoadData> GetOutputDeviceLoadDataForInterfaceBoardSection(Guid id)
        {
            var repository = _DataRepositoryFactory.GetDataRepository<IOutputDeviceRepository>();
            return repository.GetOutputDevicesPanelLoadData(this.ApplicationUserSessionHeader, new GetParametersWithPhoto() { UniqueId = id });
        }


        private void SaveAuditRecord(SendDataParameters<GalaxyInterfaceBoardSection_PanelLoadData> data)
        {
            try
            {
                //var repository = _DataRepositoryFactory.GetDataRepository<IGalaxyPanelCommandAuditRepository>();
                //var entity = new GalaxyPanelCommandAudit()
                //{
                //    GalaxyPanelCommandAuditUid = GuidUtilities.GenerateComb(),
                //    GalaxyPanelUid = data.Data.GalaxyPanelUid-
                //}
                //repository.Add()
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }
        private void SaveAuditRecord(SendDataParameters<GalaxyInterfaceBoardSectionCommandAction> data)
        {
            try
            {
                //var repository = _DataRepositoryFactory.GetDataRepository<IGalaxyPanelCommandAuditRepository>();
                //var entity = new GalaxyPanelCommandAudit()
                //{
                //    GalaxyPanelCommandAuditUid = GuidUtilities.GenerateComb(),
                //    GalaxyPanelUid = data.Data.GalaxyPanelUid-
                //}
                //repository.Add()
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }

        private void SaveAuditRecord(SendDataParameters<GalaxyPanelAlarmSettings_PanelLoadData> data)
        {
            try
            {
                //var repository = _DataRepositoryFactory.GetDataRepository<IGalaxyPanelCommandAuditRepository>();
                //var entity = new GalaxyPanelCommandAudit()
                //{
                //    GalaxyPanelCommandAuditUid = GuidUtilities.GenerateComb(),
                //    GalaxyPanelUid = data.Data.GalaxyPanelUid-
                //}
                //repository.Add()
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }

        private void SaveAuditRecord(SendDataParameters<AccessPortal_PanelLoadData> data)
        {
            try
            {
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }

        private void SaveAuditRecord(SendDataParameters<InputDevice_PanelLoadData> data)
        {
            try
            {
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }

        private void SaveAuditRecord(SendDataParameters<OutputDevice_PanelLoadData> data)
        {
            try
            {
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }

        private void SaveAuditRecord(SendDataParameters<AccessGroup_PanelLoadData> data)
        {
            try
            {
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }

        private void SaveAuditRecord(SendDataParameters<DateType_PanelLoadData> data)
        {
            try
            {
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }

        private void SaveAuditRecord(SendDataParameters<DateType_GetClustersThatUseDateType> data)
        {
            try
            {
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }

        private void SaveAuditRecord(SendDataParameters<TimeSchedule_PanelLoadData> data)
        {
            try
            {
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }

        private void SaveAuditRecord(SendDataParameters<GalaxyTimePeriod_PanelLoadData> data)
        {
            try
            {
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }

        private void SaveAuditRecord(SendDataParameters<InputOutputGroup_PanelLoadData> data)
        {
            try
            {
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }

        private void SaveAuditRecord(SendDataParameters<GalaxyPanelResetCommand> data)
        {
            try
            {
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }

        private void SaveAuditRecord(SendDataParameters<Credential_PanelLoadData> data)
        {
            try
            {
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }

        private void SaveAuditRecord(SendDataParameters<CredentialToDeleteFromCpu> data)
        {
            try
            {
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }

        private void SaveAuditRecord(SendDataParameters<GalaxyCpuCommandAction> data)
        {
            try
            {
                if (data.Data.ClusterUid == Guid.Empty)
                    return;

                var repository = _DataRepositoryFactory.GetDataRepository<IClusterCommandAuditRepository>();
                var audit = new ClusterCommandAudit()
                {
                    ClusterCommandUid = data.Data.CommandUid,
                    ClusterUid = data.SendToAddress.ClusterUid,
                };
                UpdateProperties(audit);

                repository.Add(audit, this.ApplicationUserSessionHeader, null);

            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }

        //private void SaveAuditRecord(SendDataParameters<GalaxyCpuCommandAction> data)
        //{
        //    try
        //    {
        //        var repository = _DataRepositoryFactory.GetDataRepository<IClusterCommandAuditRepository>();
        //        foreach (var clusterUid in data.Data.ClusterUids)
        //        {
        //            var audit = new ClusterCommandAudit()
        //            {

        //                ClusterCommandUid = data.Data.CommandUid,
        //                ClusterUid = clusterUid,
        //            };
        //            UpdateProperties(audit);

        //            repository.Add(audit, this.ApplicationUserSessionHeader, null, null);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
        //    }
        //}

        private void SaveAuditRecord(SendDataParameters<GalaxyLoadFlashCommandAction> data)
        {
            try
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IClusterCommandAuditRepository>();
                foreach (var clusterUid in data.Data.ClusterUids)
                {
                    var audit = new ClusterCommandAudit()
                    {

                        ClusterCommandUid = data.Data.CommandUid,
                        ClusterUid = clusterUid,
                    };
                    UpdateProperties(audit);

                    repository.Add(audit, this.ApplicationUserSessionHeader, null);
                }

            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }

        private void SaveAuditRecord(SendDataParameters<AccessPortalCommandAction> data)
        {
            try
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IAccessPortalCommandAuditRepository>();
                var audit = new AccessPortalCommandAudit()
                {
                    AccessPortalCommandUid = data.Data.CommandUid,
                    AccessPortalUid = data.Data.AccessPortalUid,
                    UserId = this.UserSessionToken.UserData.UserId
                };
                UpdateProperties(audit);

                var b = repository.Insert(audit);
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }
        private void SaveAuditRecord(SendDataParameters<InputDeviceCommandAction> data)
        {
            try
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IInputCommandAuditRepository>();
                var audit = new InputCommandAudit()
                {
                    InputCommandUid = data.Data.CommandUid,
                    InputDeviceUid = data.Data.InputDeviceUid,
                    UserId = this.UserSessionToken.UserData.UserId
                };
                UpdateProperties(audit);

                var b = repository.Insert(audit);
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }

        private void SaveAuditRecord(SendDataParameters<OutputDeviceCommandAction> data)
        {
            try
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IOutputCommandAuditRepository>();
                var audit = new OutputCommandAudit()
                {
                    OutputCommandUid = data.Data.CommandUid,
                    OutputDeviceUid = data.Data.OutputDeviceUid,
                    UserId = this.UserSessionToken.UserData.UserId
                };
                UpdateProperties(audit);

                var b = repository.Insert(audit);
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }

        private void SaveAuditRecord(SendDataParameters<InputOutputGroupCommandAction> data)
        {
            try
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IInputOutputGroupCommandAuditRepository>();
                var audit = new InputOutputGroupCommandAudit()
                {
                    InputOutputGroupCommandUid = data.Data.CommandUid,
                    InputOutputGroupUid = data.Data.InputOutputGroupUid,
                    UserId = this.UserSessionToken.UserData.UserId
                };
                UpdateProperties(audit);

                var b = repository.Insert(audit);
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
            }
        }

        private void SaveUserAuditData()
        {

        }

        private async Task RequestDataThatNeedsLoadedTimerCallback(object state)
        {

            //this.Log().Info($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} RequestDataThatNeedsLoadedTimerCallback fired");
            KillRequestDataThatNeedsLoadedTimer();

            try
            {
                SendChangesToHardware();
            }
            catch (Exception ex)
            {

                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
            StartRequestDataThatNeedsLoadedTimer();
        }

        private void StartRequestDataThatNeedsLoadedTimer()
        {
            KillRequestDataThatNeedsLoadedTimer();
            if (_checkForDataChangesIntervalSeconds <= 0)
            {
                return;
            }

            var currentInterval = _checkForDataChangesIntervalSeconds;

            var secondsTillTopOfMinute = 60 - DateTimeOffset.Now.Second;
            if (secondsTillTopOfMinute < currentInterval && secondsTillTopOfMinute != 0)
            {
                currentInterval = secondsTillTopOfMinute;
            }

            if (_requestDataThatNeedsLoadedTimer != null)
                _requestDataThatNeedsLoadedTimer = new System.Threading.Timer(async o => await RequestDataThatNeedsLoadedTimerCallback(o), null, currentInterval * 1000, Timeout.Infinite);
            else
                _requestDataThatNeedsLoadedTimer = new System.Threading.Timer(async o => await RequestDataThatNeedsLoadedTimerCallback(o), null, currentInterval * 1000, Timeout.Infinite);
        }

        private void KillRequestDataThatNeedsLoadedTimer()
        {
            if (_requestDataThatNeedsLoadedTimer != null)
            {
                _requestDataThatNeedsLoadedTimer.Dispose();
                _requestDataThatNeedsLoadedTimer = null;
            }

        }

        #endregion
    }

}
