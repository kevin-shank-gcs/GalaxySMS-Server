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
    [DataContract]
    public class FlashProgressMessage : ObjectBase
    {
        public FlashProgressMessage()
        { }

        public FlashProgressMessage(FlashProgressMessage msg)
        {
            ClusterGroupId = msg.ClusterGroupId;
            ClusterNumber = msg.ClusterNumber;
            PanelNumber = msg.PanelNumber;
            CpuId = msg.CpuId;
            CpuModel = msg.CpuModel;
            DateTimeOffset = msg.DateTimeOffset;
            CpuUid = msg.CpuUid;
        }

        private int _clusterGroupId;

        [DataMember]
        public int ClusterGroupId
        {
            get { return _clusterGroupId; }
            set
            {
                if (_clusterGroupId != value)
                {
                    _clusterGroupId = value;
                    OnPropertyChanged(() => ClusterGroupId, false);
                }
            }
        }


        private int _ClusterNumber;

        [DataMember]
        public int ClusterNumber
        {
            get { return _ClusterNumber; }
            set
            {
                if (_ClusterNumber != value)
                {
                    _ClusterNumber = value;
                    OnPropertyChanged(() => ClusterNumber, false);
                }
            }
        }

        private int _PanelNumber;

        [DataMember]
        public int PanelNumber
        {
            get { return _PanelNumber; }
            set
            {
                if (_PanelNumber != value)
                {
                    _PanelNumber = value;
                    OnPropertyChanged(() => PanelNumber, false);
                }
            }
        }

        private short _CpuId;

        [DataMember]
        public short CpuId
        {
            get { return _CpuId; }
            set
            {
                if (_CpuId != value)
                {
                    _CpuId = value;
                    OnPropertyChanged(() => CpuId, false);
                }
            }
        }

        private CpuModel _CpuModel;

        [DataMember]
        public CpuModel CpuModel
        {
            get { return _CpuModel; }
            set
            {
                if (_CpuModel != value)
                {
                    _CpuModel = value;
                    OnPropertyChanged(() => CpuModel, false);
                }
            }
        }


        private DateTimeOffset _DateTime;

        [DataMember]
        public DateTimeOffset DateTimeOffset
        {
            get { return _DateTime; }
            set
            {
                if (_DateTime != value)
                {
                    _DateTime = value;
                    OnPropertyChanged(() => DateTimeOffset, false);
                }
            }
        }

        private DateTimeOffset _StartedDateTime;

        [DataMember]
        public DateTimeOffset StartedDateTime
        {
            get { return _StartedDateTime; }
            set
            {
                if (_StartedDateTime != value)
                {
                    _StartedDateTime = value;
                    OnPropertyChanged(() => StartedDateTime, false);
                }
            }
        }

        private Guid _CpuUid;

        [DataMember]
        public Guid CpuUid
        {
            get { return _CpuUid; }
            set
            {
                if (_CpuUid != value)
                {
                    _CpuUid = value;
                    OnPropertyChanged(() => CpuUid, false);
                }
            }
        }


        private FlashingState _currentState;
        [DataMember]

        public FlashingState CurrentState
        {
            get { return _currentState; }
            set
            {
                if (_currentState != value)
                {
                    _currentState = value;
                    OnPropertyChanged(() => CurrentState, false);
                }
            }
        }

        private FlashValidationResult _validationResult;
        [DataMember]

        public FlashValidationResult ValidationResult
        {
            get { return _validationResult; }
            set
            {
                if (_validationResult != value)
                {
                    _validationResult = value;
                    OnPropertyChanged(() => ValidationResult, false);
                }
            }
        }

        private int _PacketNumber;

        [DataMember]
        public int PacketNumber
        {
            get { return _PacketNumber; }
            set
            {
                if (_PacketNumber != value)
                {
                    _PacketNumber = value;
                    OnPropertyChanged(() => PacketNumber, false);
                    OnPropertyChanged(() => ProgressMessage, false);
                    OnPropertyChanged(() => ProgressPercentage, false);
                    OnPropertyChanged(() => Duration, false);
                    OnPropertyChanged(() => IsFlashing, false);
                }
            }
        }

        private int _TotalPacketCount;

        [DataMember]
        public int TotalPacketCount
        {
            get { return _TotalPacketCount; }
            set
            {
                if (_TotalPacketCount != value)
                {
                    _TotalPacketCount = value;
                    OnPropertyChanged(() => TotalPacketCount, false);
                }
            }
        }

        public string ProgressMessage
        {
            get
            {
                if (TotalPacketCount == 0)
                    return string.Empty;
                return $"{PacketNumber} => {TotalPacketCount}";
            }
        }

        public TimeSpan Duration
        {
            get
            {
                if (StartedDateTime > DateTimeOffset.MinValue)
                    return DateTimeOffset.Now - StartedDateTime;
                return new TimeSpan(0);
            }
        }

        public int ProgressPercentage
        {
            get
            {
                if (TotalPacketCount == 0)
                    return 0;
                return (PacketNumber * 200 + TotalPacketCount) / (TotalPacketCount * 2);
            }
        }


        public bool IsFlashing
        {
            get { return !string.IsNullOrEmpty(ProgressMessage); }
            set
            {
                OnPropertyChanged(() => IsFlashing, false);
            }
        }

        public String UniqueCpuId { get { return string.Format(GalaxySMS.Common.Constants.UniqueHardwareAddressFormat.GalaxyCpu, ClusterGroupId, ClusterNumber, PanelNumber, CpuId); } }
    }

}
