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

    public class UnacknowledgedAlarm : ObjectBase
    {
        #region Private fields
        private Guid _ActivityEventUid;
        private Guid _DeviceUid;
        private Guid _DeviceEntityId;
        private Guid _CpuUid;
        private Guid _GalaxyActivityEventTypeUid;
        private Guid _PersonUid;
        private Guid _CredentialUid;
        private DateTimeOffset _ActivityDateTime;
        private string _EventDescription;
        private string _DeviceName;
        private int _AlarmPriority;
        private string _Instructions;
        private string _Category;
        private string _ActivityEventText;
        private string _CredentialDescription;

        #endregion

        #region Public Variables


        [DataMember]
        public Guid ActivityEventUid
        {
            get { return _ActivityEventUid; }
            set
            {
                if (_ActivityEventUid != value)
                {
                    _ActivityEventUid = value;
                    OnPropertyChanged(() => ActivityEventUid, false);
                }
            }
        }


        [DataMember]
        public Guid DeviceUid
        {
            get { return _DeviceUid; }
            set
            {
                if (_DeviceUid != value)
                {
                    _DeviceUid = value;
                    OnPropertyChanged(() => DeviceUid, false);
                }
            }
        }


        [DataMember]
        public Guid DeviceEntityId
        {
            get { return _DeviceEntityId; }
            set
            {
                if (_DeviceEntityId != value)
                {
                    _DeviceEntityId = value;
                    OnPropertyChanged(() => DeviceEntityId, false);
                }
            }
        }


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


        [DataMember]
        public Guid GalaxyActivityEventTypeUid
        {
            get { return _GalaxyActivityEventTypeUid; }
            set
            {
                if (_GalaxyActivityEventTypeUid != value)
                {
                    _GalaxyActivityEventTypeUid = value;
                    OnPropertyChanged(() => GalaxyActivityEventTypeUid, false);
                }
            }
        }


        [DataMember]
        public Guid PersonUid
        {
            get { return _PersonUid; }
            set
            {
                if (_PersonUid != value)
                {
                    _PersonUid = value;
                    OnPropertyChanged(() => PersonUid, false);
                }
            }
        }


        [DataMember]
        public Guid CredentialUid
        {
            get { return _CredentialUid; }
            set
            {
                if (_CredentialUid != value)
                {
                    _CredentialUid = value;
                    OnPropertyChanged(() => CredentialUid, false);
                }
            }
        }


        [DataMember]
        public DateTimeOffset ActivityDateTime
        {
            get { return _ActivityDateTime; }
            set
            {
                if (_ActivityDateTime != value)
                {
                    _ActivityDateTime = value;
                    OnPropertyChanged(() => ActivityDateTime, false);
                }
            }
        }

        [DataMember]
        public string EventDescription
        {
            get { return _EventDescription; }
            set
            {
                if (_EventDescription != value)
                {
                    _EventDescription = value;
                    OnPropertyChanged(() => EventDescription, false);
                }
            }
        }


        [DataMember]
        public string DeviceName
        {
            get { return _DeviceName; }
            set
            {
                if (_DeviceName != value)
                {
                    _DeviceName = value;
                    OnPropertyChanged(() => DeviceName, false);
                }
            }
        }


        [DataMember]
        public int AlarmPriority
        {
            get { return _AlarmPriority; }
            set
            {
                if (_AlarmPriority != value)
                {
                    _AlarmPriority = value;
                    OnPropertyChanged(() => AlarmPriority, false);
                }
            }
        }


        [DataMember]
        public string Instructions
        {
            get { return _Instructions; }
            set
            {
                if (_Instructions != value)
                {
                    _Instructions = value;
                    OnPropertyChanged(() => Instructions, false);
                }
            }
        }


        [DataMember]
        public string Category
        {
            get { return _Category; }
            set
            {
                if (_Category != value)
                {
                    _Category = value;
                    OnPropertyChanged(() => Category, false);
                }
            }
        }


        [DataMember]
        public string ActivityEventText
        {
            get { return _ActivityEventText; }
            set
            {
                if (_ActivityEventText != value)
                {
                    _ActivityEventText = value;
                    OnPropertyChanged(() => ActivityEventText, false);
                }
            }
        }


        [DataMember]
        public string CredentialDescription
        {
            get { return _CredentialDescription; }
            set
            {
                if (_CredentialDescription != value)
                {
                    _CredentialDescription = value;
                    OnPropertyChanged(() => CredentialDescription, false);
                }
            }
        }

        #endregion
    }
}
