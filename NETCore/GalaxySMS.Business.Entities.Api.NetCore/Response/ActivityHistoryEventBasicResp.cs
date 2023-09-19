using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public partial class ActivityHistoryEventBasicResp //: ObjectBase
    {
        #region public Properties
        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int TotalItemCount { get; set; }public Guid PK { get; set; }public DateTimeOffset ActivityDateTime { get; set; }public DateTimeOffset ActivityDateTimeUTC { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PK { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset ActivityDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset ActivityDateTimeUTC { get; set; }


        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public DateTimeOffset? AcknowledgedTime { get; set; }public bool IsAcknowledgeable { get; set; }public bool IsAcknowledged { get; set; }public int AckCount { get; set; }public ICollection<AcknowledgedAlarmBasicData> Acknowledgements { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsAcknowledgeable { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsAcknowledged { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int AckCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Business.Entities.Api.NetCore.AcknowledgedAlarmBasicData> Acknowledgements { get; set; }


        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string AcknowledgeComment { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif    
        //        public string AcknowledgedByUser { get; set; }public Guid EventTypeUid { get; set; }public string EventTypeMessage { get; set; }public string ForeColorHex { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EventTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string EventTypeMessage { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ForeColorHex { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string ForeColorArgb { get; set; }public int? AlarmPriority { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int? AlarmPriority { get; set; }


        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int ForeColor {get; set;}public string DeviceType { get; set; }public Guid DeviceUid { get; set; }public string DeviceName { get; set; }public Guid PersonUid { get; set; }public string LastName { get; set; }public string FirstName { get; set; }public bool IsTraced { get; set; }public string CredentialDescription { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string DeviceType { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid DeviceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DeviceName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PersonUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string LastName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string FirstName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsTraced { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CredentialDescription { get; set; }

        //#if NetCoreApi

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string SiteName { get; set; }public Guid EntityId { get; set; }public string EntityName { get; set; }

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

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid CredentialUid {get; set;}public Guid ClusterUid { get; set; }public string ClusterName { get; set; }

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



        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int ClusterNumber {get; set;}

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int TotalRecordCount {get; set;}


        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int PageNumber {get; set;}

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int ClusterGroupId {get; set;}

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int PageSize {get; set;}

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int PanelNumber {get; set;}public string InputOutputGroupName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InputOutputGroupName { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int InputOutputGroupNumber {get; set;}

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public short CpuNumber {get; set;}

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int BoardNumber {get; set;}

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int SectionNumber {get; set;}

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int ModuleNumber {get; set;}

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int NodeNumber {get; set;}

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public bool ResponseRequired { get; set; }

        #endregion
    }

    public partial class ActivityHistoryEventBasicWithEntityResp : ActivityHistoryEventBasicResp
    {
        public Guid EntityId { get; set; }
        public string EntityName { get; set; }
        public string EntityType { get; set; }
    }

}
