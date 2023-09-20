////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ActivityHistoryEvent.cs
//
// summary:	Implements the activity history event class
///=================================================================================================

using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
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
    public partial class ActivityHistoryEvent //: ObjectBase
    {
        #region public Properties
#if NetCoreApi
#else
        [DataMember]
#endif
        public int TotalItemCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset ActivityDateTime  {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset ActivityDateTimeUTC { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string EventTypeMessage {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ForeColor {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ForeColorHex { get; set; }
    

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DeviceName {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public string SiteName {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public string EntityName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string EntityType { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid DeviceUid {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EventTypeUid {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DeviceType {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public string LastName {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public string FirstName {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CredentialDescription {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PersonUid {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsTraced { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CredentialUid {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PK {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ClusterNumber {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int TotalRecordCount {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ClusterName {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int PageNumber {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ClusterGroupId {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int PageSize {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int PanelNumber {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InputOutputGroupName {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int InputOutputGroupNumber {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public short CpuNumber {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int BoardNumber {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int SectionNumber {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ModuleNumber {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int NodeNumber {get; set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public int? AlarmPriority { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool ResponseRequired { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset? AcknowledgedTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsAcknowledgeable { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int AckCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsAcknowledged { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string AcknowledgeComment { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string AcknowledgedByUser { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AcknowledgedAlarmBasicData> Acknowledgements { get; set; }
        #endregion
    }
}
