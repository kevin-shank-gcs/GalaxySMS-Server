using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

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
    public class TimeScheduleUsageData
    {
        public TimeScheduleUsageData()
        {
            Mappings = new TimeScheduleMappings();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Message { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid TimeScheduleUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TimeScheduleName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ClusterName { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public TimeScheduleMappings Mappings { get; set; }

        public bool IsUsed
        {
            get
            {
                return !string.IsNullOrEmpty(TimeScheduleName) &&
                       Mappings.IsUsed;
                //return !string.IsNullOrEmpty(ClusterName) &&
                //       !string.IsNullOrEmpty(TimeScheduleName) &&
                //       Mappings.IsUsed;
            }
        }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class TimeScheduleMappings
    {
        public TimeScheduleMappings()
        {
            AccessGroups = new HashSet<TimeScheduleUsageItem>();
            AccessGroupAccessPortals = new HashSet<TimeScheduleUsageItemAccessGroupAccessPortal>();
            AccessPortals = new HashSet<TimeScheduleUsageItem>();
            GalaxyPanels = new HashSet<TimeScheduleUsageItem>();
            InputOutputGroups = new HashSet<TimeScheduleUsageItem>();
            InputDevices = new HashSet<TimeScheduleUsageItem>();
            OutputDevices = new HashSet<TimeScheduleUsageItem>();
            People = new HashSet<TimeScheduleUsageItemPersonalAccessGroup>();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeScheduleUsageItem> AccessGroups { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeScheduleUsageItemAccessGroupAccessPortal> AccessGroupAccessPortals { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeScheduleUsageItem> AccessPortals { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeScheduleUsageItem> GalaxyPanels { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeScheduleUsageItem> InputOutputGroups { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeScheduleUsageItem> InputDevices { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeScheduleUsageItem> OutputDevices { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeScheduleUsageItemPersonalAccessGroup> People { get; set; }

        public bool IsUsed
        {
            get
            {
                return AccessPortals.Any() ||
                        AccessGroupAccessPortals.Any() ||
                        AccessGroups.Any() ||
                        GalaxyPanels.Any() ||
                        InputOutputGroups.Any() ||
                        InputDevices.Any() ||
                        OutputDevices.Any() ||
                        People.Any();
            }
        }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class TimeScheduleUsageItem
    {
        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string DataType { get; set; }

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

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Type { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string DeviceUid { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string DeviceName { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class TimeScheduleUsageItemAccessGroupAccessPortal : TimeScheduleUsageItem
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AccessPortalUid { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string AccessPortalName { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class TimeScheduleUsageItemPersonalAccessGroup : TimeScheduleUsageItem
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string ClusterName { get; set; }

    }

}
