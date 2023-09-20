using GCS.Core.Common.Core;
using System.Collections.Generic;
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
    public class ClusterEditingData : EntityBase
    {
        public ClusterEditingData()
        {
            ClusterTypes = new HashSet<ClusterType>();
            CredentialDataLengths = new HashSet<CredentialDataLength>();
            TimeScheduleTypes = new HashSet<TimeScheduleType>();
            AccessRuleOverrideTimeoutValues = new HashSet<StringIntPair>();
            UnlimitedCredentialTimeoutValues = new HashSet<StringIntPair>();
            TimeZones = new HashSet<TimeZoneListItem>();
            LedBehaviorModes = new HashSet<ClusterLedBehaviorMode>();
            AccessPortalTypes = new HashSet<AccessPortalType>();
            Entities = new HashSet<gcsEntityListItem>();
            ClusterCommands = new HashSet<ClusterCommand>();
            ClusterFlashingCommands = new HashSet<ClusterCommand>();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<ClusterType> ClusterTypes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<CredentialDataLength> CredentialDataLengths { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeScheduleType> TimeScheduleTypes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<StringIntPair> AccessRuleOverrideTimeoutValues { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<StringIntPair> UnlimitedCredentialTimeoutValues { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeZoneListItem> TimeZones { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<ClusterLedBehaviorMode> LedBehaviorModes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalType> AccessPortalTypes { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<gcsEntityListItem> Entities { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<ClusterCommand> ClusterCommands { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<ClusterCommand> ClusterFlashingCommands { get; set; }
    }



}
