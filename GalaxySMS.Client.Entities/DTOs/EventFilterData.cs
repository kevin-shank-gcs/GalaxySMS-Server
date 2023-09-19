using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{

    [DataContract]
    public class EventFilterData:DtoObjectBase
    {

        public EventFilterData()
        {
            EventTypes = new HashSet<EventType>();
        }

        private ICollection<EventType> _EventTypes;
        [DataMember]
        public ICollection<EventType> EventTypes
        {
            get { return _EventTypes; }
            set
            {
                if (_EventTypes != value)
                {
                    _EventTypes = value;
                    OnPropertyChanged(() => EventTypes, true);
                }
            }
        }

        private string _deviceType;

        [DataMember]
        public string DeviceType
        {
            get { return _deviceType; }
            set
            {
                if (_deviceType != value)
                {
                    _deviceType = value;
                    OnPropertyChanged(() => DeviceType, true);
                }
            }
        }


        private string _DeviceName;

        [DataMember]
        public string DeviceName
        {
            get { return _DeviceName; }
            set
            {
                if (_DeviceName != value)
                {
                    _DeviceName = value;
                    OnPropertyChanged(() => DeviceName, true);
                }
            }
        }


        private string _LastName;

        [DataMember]
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    OnPropertyChanged(() => LastName, true);
                }
            }
        }


        private string _FirstName;

        [DataMember]
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    OnPropertyChanged(() => FirstName, true);
                }
            }
        }


        private string _ClusterName;
        [DataMember]
        public string ClusterName
        {
            get { return _ClusterName; }
            set
            {
                if (_ClusterName != value)
                {
                    _ClusterName = value;
                    OnPropertyChanged(() => ClusterName, true);
                }
            }
        }


    }

    public class EventType :DtoObjectBase
    {

        private Guid _id;

        [DataMember]
        public Guid Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(() => Id, true);
                }
            }
        }


        private string _name;

        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(() => Name, true);
                }
            }
        }
    }
}
