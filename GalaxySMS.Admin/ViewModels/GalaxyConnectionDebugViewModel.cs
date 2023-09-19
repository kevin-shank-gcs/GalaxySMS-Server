using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows;
using GalaxySMS.Client.Entities;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.UI.Core;
using PDSA.MessageBroker;
using GalaxySMS.Admin.Support;

namespace GalaxySMS.Admin.ViewModels
{
    [Export]
    [Export(typeof(IGalaxyConnectionDebugViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxyConnectionDebugViewModel : ViewModelBase, IGalaxyConnectionDebugViewModel
    {
        #region Private fields
        private CpuConnectionInfo _cpuConn = null;
        private PDSAMessageBroker _MessageBroker = null;
        private ObservableCollection<CpuDataPacket> _packetsCombined = new ObservableCollection<CpuDataPacket>();
        private ObservableCollection<CpuDataPacket> _packetsReceived = new ObservableCollection<CpuDataPacket>();
        private ObservableCollection<CpuDataPacket> _packetsTransmitted = new ObservableCollection<CpuDataPacket>();
        private ReadOnlyObservableCollection<CpuDataPacket> _packetsReceivedReadOnly;
        private ReadOnlyObservableCollection<CpuDataPacket> _packetsTransmittedReadOnly;
        private ReadOnlyObservableCollection<CpuDataPacket> _packetsCombinedReadOnly;
        private bool _CombineTransmitReceive = false;
        private short _ReceiveListLimit = 100;
        private short _TransmitListLimit = 100;
        private short _CombinedListLimit = 200;
        private bool _DisplayHeartbeats = false;
        private string _DataToSend = "18";
        private Int32[] _boardNumbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };
        private Int32[] _sectionNumbers = { 0, 1, 2 };
        private Int32[] _nodeNumbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };
         #endregion

        #region Public properties
        public override string ViewTitle
        {
            get
            {
                if (_cpuConn == null)
                    return string.Empty;
                return _cpuConn.Description;
            }
        }
        public Guid InstanceGuid
        {
            get
            {
                if (_cpuConn != null)
                    return _cpuConn.EntityGuid;
                return Guid.Empty;
            }
        }
        public DelegateCommand<object> SendDataCommand { get; private set; }
        public DelegateCommand<object> ClearTransmitReceiveListsCommand { get; private set; }
        public DelegateCommand<CommandContainer> SendSelectedCommand { get; private set; }

        public Int32[] BoardNumbers
        {
            get { return _boardNumbers; }
        }

        public Int32[] SectionNumbers
        {
            get { return _sectionNumbers; }
        }

        public Int32[] NodeNumbers
        {
            get { return _nodeNumbers; }
        }

        private Int32 _selectedBoardNumber;

        public Int32 SelectedBoardNumber
        {
            get { return _selectedBoardNumber; }
            set
            {
                if (_selectedBoardNumber != value)
                {
                    _selectedBoardNumber = value;
                    OnPropertyChanged(() => SelectedBoardNumber, false);
                }
            }
        }

        private Int32 _selectedSectionNumber;

        public Int32 SelectedSectionNumber
        {
            get { return _selectedSectionNumber; }
            set
            {
                if (_selectedSectionNumber != value)
                {
                    _selectedSectionNumber = value;
                    OnPropertyChanged(() => SelectedSectionNumber, false);
                }
            }
        }

        private Int32 _selectedNodeNumber;

        public Int32 SelectedNodeNumber
        {
            get { return _selectedNodeNumber; }
            set
            {
                if (_selectedNodeNumber != value)
                {
                    _selectedNodeNumber = value;
                    OnPropertyChanged(() => SelectedNodeNumber, false);
                }
            }
        }

        private ObservableCollection<CommandContainer> _commandsContainer;

        public ObservableCollection<CommandContainer> CommandsContainer
        {
            get { return _commandsContainer; }
            set
            {
                if (_commandsContainer != value)
                {
                    _commandsContainer = value;
                    OnPropertyChanged(() => CommandsContainer, false);
                }
            }
        }

        private CommandContainer _selectedCommand;

        public CommandContainer SelectedCommand
        {
            get { return _selectedCommand; }
            set
            {
                if (_selectedCommand != value)
                {
                    _selectedCommand = value;
                    DataToSend = SelectedCommand.HexCommandString;
                    OnPropertyChanged(() => SelectedCommand, false);
                }
            }
        }


        public string DataToSend
        {
            get { return _DataToSend; }
            set
            {
                if (_DataToSend != value)
                {
                    _DataToSend = value;
                    OnPropertyChanged(() => DataToSend, false);
                    OnPropertyChanged(() => SendDataCommand, false);
                }
            }
        }

        public bool DisplayHeartbeats
        {
            get { return _DisplayHeartbeats; }
            set
            {
                if (_DisplayHeartbeats != value)
                {
                    _DisplayHeartbeats = value;
                    OnPropertyChanged(() => DisplayHeartbeats, false);
                }
            }
        }

        public bool CombineTransmitReceive
        {
            get { return _CombineTransmitReceive; }
            set
            {
                if (_CombineTransmitReceive != value)
                {
                    _CombineTransmitReceive = value;
                    OnPropertyChanged(() => CombineTransmitReceive, false);
                }
            }
        }

        public short ReceiveListLimit
        {
            get { return _ReceiveListLimit; }
            set
            {
                if (_ReceiveListLimit != value)
                {
                    _ReceiveListLimit = value;
                    OnPropertyChanged(() => ReceiveListLimit, false);
                }
            }
        }

        public short TransmitListLimit
        {
            get { return _TransmitListLimit; }
            set
            {
                if (_TransmitListLimit != value)
                {
                    _TransmitListLimit = value;
                    OnPropertyChanged(() => TransmitListLimit, false);
                }
            }
        }

        public short CombinedListLimit
        {
            get { return _CombinedListLimit; }
            set
            {
                if (_CombinedListLimit != value)
                {
                    _CombinedListLimit = value;
                    OnPropertyChanged(() => CombinedListLimit, false);
                }
            }
        }
        public ReadOnlyObservableCollection<CpuDataPacket> PacketsCombined
        {
            get { return _packetsCombinedReadOnly; }
        }

        public ReadOnlyObservableCollection<CpuDataPacket> PacketsReceived
        {
            get { return _packetsReceivedReadOnly; }
        }

        public ReadOnlyObservableCollection<CpuDataPacket> PacketsTransmitted
        {
            get { return _packetsTransmittedReadOnly; }
        }

        public CpuConnectionInfo Connection
        {
            get { return _cpuConn; }
            internal set { _cpuConn = value; }
        }

        public PDSAMessageBroker Messenger
        {
            get { return _MessageBroker; }
        }

        #endregion

        public GalaxyConnectionDebugViewModel()
        {
            _packetsReceivedReadOnly = new ReadOnlyObservableCollection<CpuDataPacket>(_packetsReceived);
            _packetsTransmittedReadOnly = new ReadOnlyObservableCollection<CpuDataPacket>(_packetsTransmitted);
            _packetsCombinedReadOnly = new ReadOnlyObservableCollection<CpuDataPacket>(_packetsCombined);
            // Initialize this ViewModel's commands.
            SendDataCommand = new DelegateCommand<object>(ExecuteSendDataCommand, CanExecuteSendDataCommand);
            ClearTransmitReceiveListsCommand = new DelegateCommand<object>(ExecuteClearTransmitReceiveListsCommand);
            SendSelectedCommand = new DelegateCommand<CommandContainer>(ExecuteSendSelectedCommand);
            CommandsContainer = new ObservableCollection<CommandContainer>();

            BuildCommandsContainer();

            var app = Application.Current as App;
            if (app != null) _MessageBroker = Globals.Instance.MessageBrokerPanelCommunication;
        }

        private void ExecuteClearTransmitReceiveListsCommand(object obj)
        {
            _packetsCombined.Clear();
            _packetsReceived.Clear();
            _packetsTransmitted.Clear();
        }


        private void BuildCommandsContainer()
        {
            CommandsContainer.Add(new CommandContainer()
            {
                Text = string.Format("{0}", GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandResetCpu),
                ToolTip = "Simulate pressing the reset button on the CPU board",
                CommandCode = GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandResetCpu,
                HexCommandString = string.Format("{0:X02}00", (byte)GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandResetCpu),
            });

            CommandsContainer.Add(new CommandContainer()
            {
                Text = string.Format("{0} (Cold Reset)", GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandResetCpu),
                ToolTip = "Force a COLD reset on the CPU",
                CommandCode = GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandResetCpu,
                HexCommandString = string.Format("{0:X02}02", (byte)GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandResetCpu),
            });

            CommandsContainer.Add(new CommandContainer()
            {
                Text = string.Format("{0}", GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandPing),
                ToolTip = "Send echo command to the CPU",
                CommandCode = GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandPing,
                HexCommandString = string.Format("{0:X02}", (byte)GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandPing),
            });

            CommandsContainer.Add(new CommandContainer()
            {
                Text = string.Format("{0}", GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandPanelInquire),
                ToolTip = "Request basic controller information",
                CommandCode = GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandPanelInquire,
                HexCommandString = string.Format("{0:X02}", (byte)GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandPanelInquire),
            });

            CommandsContainer.Add(new CommandContainer()
            {
                Text = string.Format("{0}", GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandRequestLoggingInformation),
                ToolTip = "Request logging information",
                CommandCode = GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandRequestLoggingInformation,
                HexCommandString = string.Format("{0:X02}", (byte)GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandRequestLoggingInformation),
            });

            CommandsContainer.Add(new CommandContainer()
            {
                Text = string.Format("{0}", GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandRequestConnectedBoardInformation),
                ToolTip = "Request Boards Information",
                CommandCode = GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandRequestConnectedBoardInformation,
                HexCommandString = string.Format("{0:X02}", (byte)GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandRequestConnectedBoardInformation),
            });
  
            CommandsContainer.Add(new CommandContainer()
            {
                Text = string.Format("Set Logging OFF {0}", GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandLoggingSetOnOff),
                ToolTip = "Set Logging Off",
                CommandCode = GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandLoggingSetOnOff,
                HexCommandString = string.Format("{0:X02}00", (byte)GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandLoggingSetOnOff),
            });
 
            CommandsContainer.Add(new CommandContainer()
            {
                Text = string.Format("Set Logging ON {0}", GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandLoggingSetOnOff),
                ToolTip = "Set Logging On",
                CommandCode = GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandLoggingSetOnOff,
                HexCommandString = string.Format("{0:X02}01", (byte)GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandLoggingSetOnOff),
            });

            CommandsContainer.Add(new CommandContainer()
            {
                Text = string.Format("{0}", GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandPulseDoor),
                ToolTip = "Unlock momentarily",
                CommandCode = GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandPulseDoor,
                HexCommandString = string.Format("{0:X02}", (byte)GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandPulseDoor),
            });

            CommandsContainer.Add(new CommandContainer()
            {
                Text = string.Format("{0}", GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandEnableDoor),
                ToolTip = "Enable",
                CommandCode = GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandEnableDoor,
                HexCommandString = string.Format("{0:X02}", (byte)GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandEnableDoor),
            });

            CommandsContainer.Add(new CommandContainer()
            {
                Text = string.Format("{0}", GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandDisableDoor),
                ToolTip = "Disable",
                CommandCode = GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandDisableDoor,
                HexCommandString = string.Format("{0:X02}", (byte)GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandDisableDoor),
            });

            CommandsContainer.Add(new CommandContainer()
            {
                Text = string.Format("{0}", GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandLockDoor),
                ToolTip = "CommandLockDoor",
                CommandCode = GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandLockDoor,
                HexCommandString = string.Format("{0:X02}", (byte)GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandLockDoor),
            });

            CommandsContainer.Add(new CommandContainer()
            {
                Text = string.Format("{0}", GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandUnlockDoor),
                ToolTip = "CommandUnlockDoor",
                CommandCode = GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandUnlockDoor,
                HexCommandString = string.Format("{0:X02}", (byte)GCS.PanelProtocols.Enums.PacketDataCodeTo6xx.CommandUnlockDoor),
            });

        }

        private void ExecuteSendSelectedCommand(CommandContainer obj)
        {
            throw new NotImplementedException();
        }

        private void SendMessage(string messageName, object data)
        {
            if (Messenger != null)
            {
                var arg = new PDSAMessageBrokerMessage()
                {
                    MessageName = messageName,
                    MessageBody = data
                };

                Messenger.SendMessage(arg);
            }
        }



        public override void ViewUnloaded(object arg)
        {

        }
        private bool CanExecuteSendDataCommand(object obj)
        {
            if (DataToSend == string.Empty)
            {
                return false;
            }
            return true;
        }

        private void ExecuteSendDataCommand(object obj)
        {
            if (Messenger != null)
            {
                var data = new RawDataToSend();
                data.CpuModel = Connection.GalaxyCpuInformation.CpuModel;
                data.Address.CpuModel = Connection.GalaxyCpuInformation.CpuModel;
                data.Address.ClusterNumber = this.Connection.GalaxyCpuInformation.ClusterNumber;
                data.Address.PanelNumber = this.Connection.GalaxyCpuInformation.PanelNumber;
                data.Address.CpuId = this.Connection.GalaxyCpuInformation.CpuId;
                data.Address.ClusterGroupId = this.Connection.GalaxyCpuInformation.ClusterGroupId;
                data.Address.BoardNumber = SelectedBoardNumber;
                data.Address.SectionNumber = SelectedSectionNumber;
                data.Address.NodeNumber = SelectedNodeNumber;

                data.StringData = DataToSend;

                PDSAMessageBrokerMessage arg = new PDSAMessageBrokerMessage();

                arg.MessageName = MessageNames.SendRawData;
                arg.MessageBody = data;

                Messenger.SendMessage(arg);
            }
        }

        private void SetAddressToSend(ISendDataParameters p)
        {
            p.SendToAddress.ClusterNumber = this.Connection.GalaxyCpuInformation.ClusterNumber;
            p.SendToAddress.PanelNumber = this.Connection.GalaxyCpuInformation.PanelNumber;
            p.SendToAddress.CpuId = this.Connection.GalaxyCpuInformation.CpuId;
            p.SendToAddress.ClusterGroupId = this.Connection.GalaxyCpuInformation.ClusterGroupId;
        }

        protected override void OnViewLoaded()
        {

        }

        public void Initialize(CpuConnectionInfo connInfo)
        {
            _cpuConn = connInfo;
        }

        public void HandlePacket(CpuDataPacket e)
        {
            if (DisplayHeartbeats == false &&
                e.DataType == PacketDataType.CpuHeartbeat)
                return;

            _packetsCombined.Insert(0, e);
            while (_packetsCombined.Count > CombinedListLimit)
            {
                _packetsCombined.RemoveAt(_packetsCombined.Count - 1);
            }

            switch (e.WhichDirection)
            {
                case DataPacketBase.Direction.ReceivedFromPanel:
                    _packetsReceived.Insert(0, e);
                    while (_packetsReceived.Count > ReceiveListLimit)
                    {
                        _packetsReceived.RemoveAt(_packetsReceived.Count - 1);
                    }
                    break;

                case DataPacketBase.Direction.TransmittedToPanel:
                    _packetsTransmitted.Insert(0, e);
                    while (_packetsTransmitted.Count > TransmitListLimit)
                    {
                        _packetsTransmitted.RemoveAt(_packetsTransmitted.Count - 1);
                    }
                    break;
            }
        }



        public void Activate()
        {

        }
    }
}
