using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    public partial class AcknowledgedAlarm : DtoObjectBase
    {
        #region Private Variables
        private Guid _ActivityEventUid = Guid.Empty;
        private int _clusterGroupId = 0;
        private int _ClusterNumber = 0;
        private int _PanelNumber = 0;
        private short _CpuId = 0;
        private int _BoardNumber = 0;
        private int _SectionNumber = 0;
        private int _NodeNumber = 0;
        private int _CpuModel = 0;
        private DateTimeOffset _DateTime = DateTimeOffset.Now;
        private int _BufferIndex = 0;
        private PanelActivityEventCode _PanelActivityType = PanelActivityEventCode.DoorForcedOpen;
        private int _InputOutputGroupNumber = 0;
        private AccessPortalMultiFactorModeCode _MultiFactorMode = AccessPortalMultiFactorModeCode.SingleFactor;
        private string _DeviceDescription = string.Empty;
        private string _EventDescription = string.Empty;
        private Guid _DeviceEntityId = Guid.Empty;
        private Guid _DeviceUid = Guid.Empty;
        private Guid _CpuUid = Guid.Empty;
        private string _ClusterName = string.Empty;
        private int _IsAlarmEvent = 0;
        private int _AlarmPriority = 0;
        private string _Instructions = string.Empty;
        private Guid _InstructionsNoteUid = Guid.Empty;
        private Guid _AudioBinaryResourceUid = Guid.Empty;
        private byte[] _RawData = null;
        private int _Color = 0;
        private Guid _PersonUid = Guid.Empty;
        private Guid _CredentialUid = Guid.Empty;
        private string _PersonDescription = string.Empty;
        private string _CredentialDescription = string.Empty;
        private bool _Trace = false;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the Activity Event Uid value
        /// </summary>

        [DataMember]

        public Guid ActivityEventUid
        {
            get { return _ActivityEventUid; }
            set
            {
                if (_ActivityEventUid != value)
                {
                    _ActivityEventUid = value;
                    OnPropertyChanged(() => ActivityEventUid);
                }
            }
        }

        /// <summary>
        /// Get/Set the Account Code value
        /// </summary>

        [DataMember]

        public int ClusterGroupId
        {
            get { return _clusterGroupId; }
            set
            {
                if (_clusterGroupId != value)
                {
                    _clusterGroupId = value;
                    OnPropertyChanged(() => ClusterGroupId);
                }
            }
        }

        /// <summary>
        /// Get/Set the Cluster Number value
        /// </summary>

        [DataMember]

        public int ClusterNumber
        {
            get { return _ClusterNumber; }
            set
            {
                if (_ClusterNumber != value)
                {
                    _ClusterNumber = value;
                    OnPropertyChanged(() => ClusterNumber);
                }
            }
        }

        /// <summary>
        /// Get/Set the Panel Number value
        /// </summary>

        [DataMember]

        public int PanelNumber
        {
            get { return _PanelNumber; }
            set
            {
                if (_PanelNumber != value)
                {
                    _PanelNumber = value;
                    OnPropertyChanged(() => PanelNumber);
                }
            }
        }

        /// <summary>
        /// Get/Set the Cpu Id value
        /// </summary>

        [DataMember]

        public short CpuId
        {
            get { return _CpuId; }
            set
            {
                if (_CpuId != value)
                {
                    _CpuId = value;
                    OnPropertyChanged(() => CpuId);
                }
            }
        }

        /// <summary>
        /// Get/Set the Board Number value
        /// </summary>

        [DataMember]

        public int BoardNumber
        {
            get { return _BoardNumber; }
            set
            {
                if (_BoardNumber != value)
                {
                    _BoardNumber = value;
                    OnPropertyChanged(() => BoardNumber);
                }
            }
        }

        /// <summary>
        /// Get/Set the Section Number value
        /// </summary>

        [DataMember]

        public int SectionNumber
        {
            get { return _SectionNumber; }
            set
            {
                if (_SectionNumber != value)
                {
                    _SectionNumber = value;
                    OnPropertyChanged(() => SectionNumber);
                }
            }
        }

        /// <summary>
        /// Get/Set the Node Number value
        /// </summary>

        [DataMember]

        public int NodeNumber
        {
            get { return _NodeNumber; }
            set
            {
                if (_NodeNumber != value)
                {
                    _NodeNumber = value;
                    OnPropertyChanged(() => NodeNumber);
                }
            }
        }

        /// <summary>
        /// Get/Set the Cpu Model value
        /// </summary>

        [DataMember]

        public int CpuModel
        {
            get { return _CpuModel; }
            set
            {
                if (_CpuModel != value)
                {
                    _CpuModel = value;
                    OnPropertyChanged(() => CpuModel);
                }
            }
        }

        /// <summary>
        /// Get/Set the Date Time value
        /// </summary>

        [DataMember]

        public DateTimeOffset DateTimeOffset
        {
            get { return _DateTime; }
            set
            {
                if (_DateTime != value)
                {
                    _DateTime = value;
                    OnPropertyChanged(() => DateTimeOffset);
                }
            }
        }

        /// <summary>
        /// Get/Set the Buffer Index value
        /// </summary>

        [DataMember]

        public int BufferIndex
        {
            get { return _BufferIndex; }
            set
            {
                if (_BufferIndex != value)
                {
                    _BufferIndex = value;
                    OnPropertyChanged(() => BufferIndex);
                }
            }
        }

        /// <summary>
        /// Get/Set the Panel Activity Type value
        /// </summary>

        [DataMember]

        public PanelActivityEventCode PanelActivityType
        {
            get { return _PanelActivityType; }
            set
            {
                if (_PanelActivityType != value)
                {
                    _PanelActivityType = value;
                    OnPropertyChanged(() => PanelActivityType);
                }
            }
        }

        /// <summary>
        /// Get/Set the Input Output Group Number value
        /// </summary>

        [DataMember]

        public int InputOutputGroupNumber
        {
            get { return _InputOutputGroupNumber; }
            set
            {
                if (_InputOutputGroupNumber != value)
                {
                    _InputOutputGroupNumber = value;
                    OnPropertyChanged(() => InputOutputGroupNumber);
                }
            }
        }

        /// <summary>
        /// Get/Set the Multi Factor Mode value
        /// </summary>

        [DataMember]

        public AccessPortalMultiFactorModeCode MultiFactorMode
        {
            get { return _MultiFactorMode; }
            set
            {
                if (_MultiFactorMode != value)
                {
                    _MultiFactorMode = value;
                    OnPropertyChanged(() => MultiFactorMode);
                }
            }
        }

        /// <summary>
        /// Get/Set the Device Description value
        /// </summary>

        [DataMember]

        public string DeviceDescription
        {
            get { return _DeviceDescription; }
            set
            {
                if (_DeviceDescription != value)
                {
                    _DeviceDescription = value;
                    OnPropertyChanged(() => DeviceDescription);
                }
            }
        }

        /// <summary>
        /// Get/Set the Event Description value
        /// </summary>

        [DataMember]

        public string EventDescription
        {
            get { return _EventDescription; }
            set
            {
                if (_EventDescription != value)
                {
                    _EventDescription = value;
                    OnPropertyChanged(() => EventDescription);
                }
            }
        }

        /// <summary>
        /// Get/Set the Device Entity Id value
        /// </summary>

        [DataMember]

        public Guid DeviceEntityId
        {
            get { return _DeviceEntityId; }
            set
            {
                if (_DeviceEntityId != value)
                {
                    _DeviceEntityId = value;
                    OnPropertyChanged(() => DeviceEntityId);
                }
            }
        }

        /// <summary>
        /// Get/Set the Device Uid value
        /// </summary>

        [DataMember]

        public Guid DeviceUid
        {
            get { return _DeviceUid; }
            set
            {
                if (_DeviceUid != value)
                {
                    _DeviceUid = value;
                    OnPropertyChanged(() => DeviceUid);
                }
            }
        }

        /// <summary>
        /// Get/Set the Cpu Uid value
        /// </summary>

        [DataMember]

        public Guid CpuUid
        {
            get { return _CpuUid; }
            set
            {
                if (_CpuUid != value)
                {
                    _CpuUid = value;
                    OnPropertyChanged(() => CpuUid);
                }
            }
        }

        /// <summary>
        /// Get/Set the Cluster Name value
        /// </summary>

        [DataMember]

        public string ClusterName
        {
            get { return _ClusterName; }
            set
            {
                if (_ClusterName != value)
                {
                    _ClusterName = value;
                    OnPropertyChanged(() => ClusterName);
                }
            }
        }

        /// <summary>
        /// Get/Set the Is Alarm Event value
        /// </summary>

        [DataMember]

        public int IsAlarmEvent
        {
            get { return _IsAlarmEvent; }
            set
            {
                if (_IsAlarmEvent != value)
                {
                    _IsAlarmEvent = value;
                    OnPropertyChanged(() => IsAlarmEvent);
                }
            }
        }

        /// <summary>
        /// Get/Set the Alarm Priority value
        /// </summary>

        [DataMember]

        public int AlarmPriority
        {
            get { return _AlarmPriority; }
            set
            {
                if (_AlarmPriority != value)
                {
                    _AlarmPriority = value;
                    OnPropertyChanged(() => AlarmPriority);
                }
            }
        }

        /// <summary>
        /// Get/Set the Instructions value
        /// </summary>

        [DataMember]

        public string Instructions
        {
            get { return _Instructions; }
            set
            {
                if (_Instructions != value)
                {
                    _Instructions = value;
                    OnPropertyChanged(() => Instructions);
                }
            }
        }

        /// <summary>
        /// Get/Set the Instructions Note Uid value
        /// </summary>

        [DataMember]

        public Guid InstructionsNoteUid
        {
            get { return _InstructionsNoteUid; }
            set
            {
                if (_InstructionsNoteUid != value)
                {
                    _InstructionsNoteUid = value;
                    OnPropertyChanged(() => InstructionsNoteUid);
                }
            }
        }

        /// <summary>
        /// Get/Set the Audio Binary Resource Uid value
        /// </summary>

        [DataMember]

        public Guid AudioBinaryResourceUid
        {
            get { return _AudioBinaryResourceUid; }
            set
            {
                if (_AudioBinaryResourceUid != value)
                {
                    _AudioBinaryResourceUid = value;
                    OnPropertyChanged(() => AudioBinaryResourceUid);
                }
            }
        }

        /// <summary>
        /// Get/Set the Raw Data value
        /// </summary>

        [DataMember]

        public byte[] RawData
        {
            get { return _RawData; }
            set
            {
                if (_RawData != value)
                {
                    _RawData = value;
                    OnPropertyChanged(() => RawData);
                }
            }
        }

        /// <summary>
        /// Get/Set the Color value
        /// </summary>

        [DataMember]

        public int Color
        {
            get { return _Color; }
            set
            {
                if (_Color != value)
                {
                    _Color = value;
                    OnPropertyChanged(() => Color);
                }
            }
        }

        /// <summary>
        /// Get/Set the Person Uid value
        /// </summary>

        [DataMember]

        public Guid PersonUid
        {
            get { return _PersonUid; }
            set
            {
                if (_PersonUid != value)
                {
                    _PersonUid = value;
                    OnPropertyChanged(() => PersonUid);
                }
            }
        }

        /// <summary>
        /// Get/Set the Credential Uid value
        /// </summary>

        [DataMember]

        public Guid CredentialUid
        {
            get { return _CredentialUid; }
            set
            {
                if (_CredentialUid != value)
                {
                    _CredentialUid = value;
                    OnPropertyChanged(() => CredentialUid);
                }
            }
        }

        /// <summary>
        /// Get/Set the Person Description value
        /// </summary>

        [DataMember]

        public string PersonDescription
        {
            get { return _PersonDescription; }
            set
            {
                if (_PersonDescription != value)
                {
                    _PersonDescription = value;
                    OnPropertyChanged(() => PersonDescription);
                }
            }
        }

        /// <summary>
        /// Get/Set the Credential Description value
        /// </summary>

        [DataMember]

        public string CredentialDescription
        {
            get { return _CredentialDescription; }
            set
            {
                if (_CredentialDescription != value)
                {
                    _CredentialDescription = value;
                    OnPropertyChanged(() => CredentialDescription);
                }
            }
        }

        /// <summary>
        /// Get/Set the Trace value
        /// </summary>

        [DataMember]

        public bool Trace
        {
            get { return _Trace; }
            set
            {
                if (_Trace != value)
                {
                    _Trace = value;
                    OnPropertyChanged(() => Trace);
                }
            }
        }


        #endregion
    }
}
