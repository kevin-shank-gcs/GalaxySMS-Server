using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities.Api.NetCore.Response
{
    public class CustomTimeScheduleUsageData
    {
    }
}

public class CustomTimeScheduleUsageData
{
    public CustomTimeScheduleUsageData()
    {
        Mappings = new TimeScheduleMappings();
    }

    public string Message { get; set; }
    public Guid TimeScheduleUid { get; set; }
    public string TimeScheduleName { get; set; }
    public Guid ClusterUid { get; set; }
    public string ClusterName { get; set; }


    public TimeScheduleMappings Mappings { get; set; }

    //public bool IsUsed
    //{
    //    get
    //    {
    //        return !string.IsNullOrEmpty(ClusterName) &&
    //               !string.IsNullOrEmpty(TimeScheduleName) &&
    //               Mappings.IsUsed;
    //    }
    //}
}

public class TimeScheduleMappings
{
    public TimeScheduleMappings()
    {
        //AccessGroups = new HashSet<TimeScheduleUsageItem>();
        //AccessGroupAccessPortals = new HashSet<TimeScheduleUsageItemAccessGroupAccessPortal>();
        //AccessPortals = new HashSet<TimeScheduleUsageItem>();
        //GalaxyPanels = new HashSet<TimeScheduleUsageItem>();
        //InputOutputGroups = new HashSet<TimeScheduleUsageItem>();
        //InputDevices = new HashSet<TimeScheduleUsageItem>();
        //OutputDevices = new HashSet<TimeScheduleUsageItem>();
        //People = new HashSet<TimeScheduleUsageItemPersonalAccessGroup>();
        AccessGroups = new HashSet<object>();
        AccessPortals = new HashSet<object>();
        GalaxyPanels = new HashSet<object>();
        InputOutputGroups = new HashSet<object>();
        InputDevices = new HashSet<object>();
        OutputDevices = new HashSet<object>();
        People = new HashSet<object>();
    }

    //public ICollection<TimeScheduleUsageItem> AccessGroups { get; set; }

    //public ICollection<TimeScheduleUsageItemAccessGroupAccessPortal> AccessGroupAccessPortals { get; set; }
    public ICollection<object> AccessGroups { get; set; }
    public ICollection<object> AccessPortals { get; set; }

    public ICollection<object> GalaxyPanels { get; set; }

    public ICollection<object> InputOutputGroups { get; set; }

    public ICollection<object> InputDevices { get; set; }

    public ICollection<object> OutputDevices { get; set; }

    public ICollection<object> People { get; set; }

    //public bool IsUsed
    //{
    //    get
    //    {
    //        return AccessPortals.Any() ||
    //                //AccessGroupAccessPortals.Any() ||
    //                AccessGroups.Any() ||
    //                GalaxyPanels.Any() ||
    //                InputOutputGroups.Any() ||
    //                InputDevices.Any() ||
    //                OutputDevices.Any() ||
    //                People.Any();
    //    }
    //}

}

//public class TimeScheduleUsageItem
//{
//    public Guid Id { get; set; }

//    public string Name { get; set; }

//    public string Type { get; set; }
//}

//public class TimeScheduleUsageItemAccessGroupAccessPortal : TimeScheduleUsageItem
//{
//    public Guid AccessPortalUid { get; set; }

//    public string AccessPortalName { get; set; }
//}

//public class TimeScheduleUsageItemPersonalAccessGroup : TimeScheduleUsageItem
//{
//    public Guid ClusterUid { get; set; }

//    public string ClusterName { get; set; }
//}
