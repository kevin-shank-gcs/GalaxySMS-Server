
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{

    [DataContract]
    public class DeviceAlertEventSettings : DtoObjectBase
    {

        public DeviceAlertEventSettings()
        {
            Cluster = new ItemIdName();
            Schedule = new ItemIdName();
            Devices = new HashSet<ItemIdName>();
            EventTypes = new HashSet<ItemIdName>();
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


        private ItemIdName _cluster;

        [DataMember]
        public ItemIdName Cluster
        {
            get { return _cluster; }
            set
            {
                if (_cluster != value)
                {
                    _cluster = value;
                    OnPropertyChanged(() => Cluster, true);
                }
            }
        }

        private ItemIdName _schedule;
        [DataMember]

        public ItemIdName Schedule
        {
            get { return _schedule; }
            set
            {
                if (_schedule != value)
                {
                    _schedule = value;
                    OnPropertyChanged(() => Schedule, true);
                }
            }
        }


        private ICollection<ItemIdName> _devices;

        [DataMember]
        public ICollection<ItemIdName> Devices
        {
            get { return _devices; }
            set
            {
                if (_devices != value)
                {
                    _devices = value;
                    OnPropertyChanged(() => Devices, true);
                }
            }
        }

        private ICollection<ItemIdName> _eventTypes;

        [DataMember]
        public ICollection<ItemIdName> EventTypes
        {
            get { return _eventTypes; }
            set
            {
                if (_eventTypes != value)
                {
                    _eventTypes = value;
                    OnPropertyChanged(() => EventTypes, true);
                }
            }
        }
    }

    [DataContract]
    public class ItemIdName : DtoObjectBase
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

    [DataContract]
    public class EntityDeviceAlertEventSettings :DtoObjectBase
    {
        private Guid _EntityId;
        [DataMember]
        public Guid EntityId
        {
            get { return _EntityId; }
            set
            {
                if (_EntityId != value)
                {
                    _EntityId = value;
                    OnPropertyChanged(() => EntityId, true);
                }
            }
        }


        private string _entityName;

        [DataMember]
        public string EntityName
        {
            get { return _entityName; }
            set
            {
                if (_entityName != value)
                {
                    _entityName = value;
                    OnPropertyChanged(() => EntityName, true);
                }
            }
        }


        private ObservableCollection<DeviceAlertEventSettings> _data;

        [DataMember]
        public ObservableCollection<DeviceAlertEventSettings> Data
        {
            get { return _data; }
            set
            {
                if (_data != value)
                {
                    _data = value;
                    OnPropertyChanged(() => Data, true);
                }
            }
        }

    }
}
