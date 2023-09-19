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
    public class ClusterEditingDataBasic : EntityBaseSimple
    {
        public ClusterEditingDataBasic()
        {
            ClusterTypes = new HashSet<ClusterTypeBasic>();
            CredentialDataLengths = new HashSet<CredentialDataLengthBasic>();
            TimeScheduleTypes = new HashSet<TimeScheduleTypeBasic>();
            AccessRuleOverrideTimeoutValues = new HashSet<StringIntPair>();
            UnlimitedCredentialTimeoutValues = new HashSet<StringIntPair>();
            TimeZones = new HashSet<TimeZoneListItem>();
            LedBehaviorModes = new HashSet<ClusterLedBehaviorModeBasic>();
            AccessPortalTypes = new HashSet<AccessPortalTypeBasic>();
            Entities = new HashSet<gcsEntityListItem>();
            ClusterCommands = new HashSet<ClusterCommandBasic>();
            ClusterFlashingCommands = new HashSet<ClusterCommandBasic>();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<ClusterTypeBasic> ClusterTypes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<CredentialDataLengthBasic> CredentialDataLengths { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeScheduleTypeBasic> TimeScheduleTypes { get; set; }

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
        public ICollection<ClusterLedBehaviorModeBasic> LedBehaviorModes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalTypeBasic> AccessPortalTypes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<gcsEntityListItem> Entities { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<ClusterCommandBasic> ClusterCommands { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<ClusterCommandBasic> ClusterFlashingCommands { get; set; }
    }
}
