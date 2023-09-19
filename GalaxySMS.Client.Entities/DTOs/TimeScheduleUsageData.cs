using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Framework.Licensing;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class TimeScheduleUsageData
    {
        [DataMember]
        public Guid TimeScheduleUid { get; set; }

        [DataMember]
        public string TimeScheduleName { get; set; }

        [DataMember]
        public Guid ClusterUid { get; set; }

        [DataMember]
        public string ClusterName { get; set; }

        [DataMember]
        public ICollection<TimeScheduleUsageItem> AccessGroups { get; set; }

        [DataMember]
        public ICollection<TimeScheduleUsageItemAccessGroupAccessPortal> AccessGroupAccessPortals { get; set; }

        [DataMember]
        public ICollection<TimeScheduleUsageItem> AccessPortals { get; set; }

        [DataMember]
        public ICollection<TimeScheduleUsageItem> GalaxyPanels { get; set; }

        [DataMember]
        public ICollection<TimeScheduleUsageItem> InputOutputGroups { get; set; }

        [DataMember]
        public ICollection<TimeScheduleUsageItem> InputDevices { get; set; }

        [DataMember]
        public ICollection<TimeScheduleUsageItem> OutputDevices { get; set; }

        [DataMember]
        public ICollection<TimeScheduleUsageItemPersonalAccessGroup> People { get; set; }
    }

    [DataContract]
    public class TimeScheduleUsageItem
    {
        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string DataType { get; set; }

        [DataMember]
        public Guid Id { get; set; }


        [DataMember]

        public string Name { get; set; }


        [DataMember]
        public string Type { get; set; }

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


    [DataContract]
    public class TimeScheduleUsageItemAccessGroupAccessPortal : TimeScheduleUsageItem
    {
        [DataMember]
        public Guid AccessPortalUid { get; set; }

        [DataMember]
        public string AccessPortalName { get; set; }

    }


    [DataContract]

    public class TimeScheduleUsageItemPersonalAccessGroup : TimeScheduleUsageItem
    {
        [DataMember]
        public Guid PersonUid { get; set; }

        [DataMember]
        public string PersonName { get; set; }

    }
}
