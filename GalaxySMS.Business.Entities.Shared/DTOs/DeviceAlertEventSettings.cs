using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif
    public class DeviceAlertEventSettings
    {
        public DeviceAlertEventSettings()
        {
            Cluster = new ItemIdName();
            Schedule = new ItemIdName();
            Devices = new HashSet<ItemIdName>();
            EventTypes = new HashSet<ItemIdName>();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DeviceType { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ItemIdName Cluster { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ItemIdName Schedule { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<ItemIdName> Devices { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<ItemIdName> EventTypes { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class ItemIdName
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid Id { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Name { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class EntityDeviceAlertEventSettings
    {
        public EntityDeviceAlertEventSettings()
        {
            Data = new HashSet<DeviceAlertEventSettings>();
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string EntityName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<DeviceAlertEventSettings> Data { get; set; }

    }
}
