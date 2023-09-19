using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    public class ClusterEditingData : EntityBase
    {
        public ClusterEditingData()
        {
            ClusterTypes = new HashSet<ClusterType>();
            CredentialDataLengths = new HashSet<CredentialDataLength>();
            TimeScheduleTypes = new HashSet<TimeScheduleType>();
            AccessRuleOverrideTimeoutValues = new HashSet<StringShortPair>();
            UnlimitedCredentialTimeoutValues = new HashSet<StringShortPair>();
            TimeZones = new HashSet<TimeZone>();
            LedBehaviorModes = new HashSet<ClusterLedBehaviorMode>();
            AccessPortalTypes = new HashSet<AccessPortalType>();
        }

        public ICollection<ClusterType> ClusterTypes { get; set; }
        public ICollection<CredentialDataLength> CredentialDataLengths { get; set; }
        public ICollection<TimeScheduleType> TimeScheduleTypes { get; set; }
        public ICollection<StringShortPair> AccessRuleOverrideTimeoutValues { get; set; }
        public ICollection<StringShortPair> UnlimitedCredentialTimeoutValues { get; set; }
        public ICollection<TimeZone> TimeZones { get; set; }
        public ICollection<ClusterLedBehaviorMode> LedBehaviorModes { get; set; }
        public ICollection<AccessPortalType> AccessPortalTypes {get;set; }
    }
}
