using GCS.Core.Common.Extensions;
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
    public partial class Cluster
    {
        public Cluster() : base()
        {
            Initialize();
        }

        public Cluster(Cluster e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.EntityIds = new HashSet<Guid>();
            this.RoleIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();

            this.TimeSchedules = new HashSet<TimeScheduleSelect>();
            //this.DayTypes = new HashSet<DayTypeSelect>();
            //this.GalaxyClusterTimeScheduleMaps = new HashSet<GalaxyClusterTimeScheduleMap>();
            this.InputOutputGroups = new HashSet<InputOutputGroup>();
            this.AccessGroups = new HashSet<AccessGroup>();
            this.Areas = new HashSet<Area>();
            this.ClusterEntityMaps = new HashSet<ClusterEntityMapBasic>();
            this.ClusterInputOutputGroups = new HashSet<ClusterInputOutputGroup>();
            this.GalaxyPanels = new HashSet<GalaxyPanel>();
            this.ClusterCommands = new HashSet<ClusterCommand>();
            this.ClusterFlashingCommands = new HashSet<ClusterCommand>();
            DisabledCommandIds = new HashSet<Guid>();
            ScheduleIds = new HashSet<Guid>();
            MappedSchedules = new HashSet<ClusterTimeScheduleItem>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(Cluster e)
        {
            Initialize();

            if (e == null)
                return;

            this.ClusterUid = e.ClusterUid;
            this.SiteUid = e.SiteUid;
            this.ClusterNumber = e.ClusterNumber;
            this.ClusterName = e.ClusterName;
            this.Description = e.Description;
            this.ClusterTypeUid = e.ClusterTypeUid;
            this.EntityId = e.EntityId;
            this.CredentialDataLengthUid = e.CredentialDataLengthUid;
            this.TimeScheduleTypeUid = e.TimeScheduleTypeUid;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.ClusterGroupId = e.ClusterGroupId;
            this.IsActive = e.IsActive;
            this.AbaStartDigit = e.AbaStartDigit;
            this.AbaStopDigit = e.AbaStopDigit;
            this.AbaFoldOption = e.AbaFoldOption;
            this.AbaClipOption = e.AbaClipOption;
            this.WiegandStartBit = e.WiegandStartBit;
            this.WiegandStopBit = e.WiegandStopBit;
            this.CardaxStartBit = e.CardaxStartBit;
            this.CardaxStopBit = e.CardaxStopBit;
            this.LockoutAfterInvalidAttempts = e.LockoutAfterInvalidAttempts;
            this.LockoutDurationSeconds = e.LockoutDurationSeconds;
            this.AccessRuleOverrideTimeout = e.AccessRuleOverrideTimeout;
            this.UnlimitedCredentialTimeout = e.UnlimitedCredentialTimeout;
            this.TimeZoneId = e.TimeZoneId;
            this.CrisisActivateInputOutputGroupUid = e.CrisisActivateInputOutputGroupUid;
            this.CrisisResetInputOutputGroupUid = e.CrisisResetInputOutputGroupUid;
            this.AccessPortalLockedLedBehaviorModeUid = e.AccessPortalLockedLedBehaviorModeUid;
            this.AccessPortalUnlockedLedBehaviorModeUid = e.AccessPortalUnlockedLedBehaviorModeUid;
            this.TimeSchedules = e.TimeSchedules.ToCollection();
            //this.DayTypes = e.DayTypes.ToCollection();
            //this.GalaxyClusterTimeScheduleMaps = e.GalaxyClusterTimeScheduleMaps.ToCollection();
            this.InputOutputGroups = e.InputOutputGroups.ToCollection();
            this.AccessGroups = e.AccessGroups.ToCollection();
            this.Areas = e.Areas.ToCollection();
            this.ClusterEntityMaps = e.ClusterEntityMaps.ToCollection();
            this.ClusterInputOutputGroups = e.ClusterInputOutputGroups.ToCollection();
            this.GalaxyPanels = e.GalaxyPanels.ToCollection();
            this.ClusterCommands = e.ClusterCommands.ToCollection();
            this.ClusterFlashingCommands = e.ClusterFlashingCommands.ToCollection();
            if (e.DisabledCommandIds != null)
                this.DisabledCommandIds = e.DisabledCommandIds.ToCollection();
            if (e.ScheduleIds != null)
                this.ScheduleIds = e.ScheduleIds.ToCollection();
            if (e.MappedSchedules != null)
                this.MappedSchedules = e.MappedSchedules.ToCollection();
            this.ClusterType = e.ClusterType;
            this.AccessPortalTypeUid = e.AccessPortalTypeUid;
            this.TemplateAccessPortalUid = e.TemplateAccessPortalUid;
            this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);
            this.TotalRowCount = e.TotalRowCount;
            this.Counts = e.Counts;
#if NetCoreApi
#else
            this.PanelScheduleNumber = e.PanelScheduleNumber;
#endif
            //this.Site = e.Site;

            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();

            if (e.RoleIds != null)
                this.RoleIds = e.RoleIds.ToCollection();

            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();

            //if (e.CrisisActivateInputOutputGroup != null)
            //    this.CrisisActivateInputOutputGroup = new InputOutputGroup(e.CrisisActivateInputOutputGroup);

            //if (e.CrisisResetInputOutputGroup != null)
            //    this.CrisisResetInputOutputGroup = new InputOutputGroup(e.CrisisResetInputOutputGroup);

            //if (e.AccessPortalLockedLedBehaviorMode != null)
            //    this.AccessPortalLockedLedBehaviorMode = new ClusterLedBehaviorMode(e.AccessPortalLockedLedBehaviorMode);

            //if (e.AccessPortalUnlockedLedBehaviorMode != null)
            //    this.AccessPortalUnlockedLedBehaviorMode = new ClusterLedBehaviorMode(e.AccessPortalUnlockedLedBehaviorMode);

            // Common table properties
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
        }

        public void SetDefaults()
        {
            this.AbaFoldOption = true;
            this.AbaStartDigit = 1;
            this.AbaStopDigit = 60;
            this.WiegandStopBit = 255;
            this.CardaxStartBit = 34;
            this.CardaxStopBit = 59;
            this.TimeScheduleTypeUid = GalaxySMS.Common.Constants.TimeScheduleTypeIds.TimeScheduleType_GalaxyMinuteInterval;
            this.CredentialDataLengthUid = GalaxySMS.Common.Constants.CredentialDataLengthIds.Standard48Bits;
            this.ClusterTypeUid = GalaxySMS.Common.Constants.GalaxyClusterTypeIds.GalaxyClusterType_Only635;
            this.TimeZoneId = TimeZoneInfo.Local.Id;
            this.AccessPortalLockedLedBehaviorModeUid = GalaxySMS.Common.Constants.ClusterLedBehaviorIds.SteadyLow;
            this.AccessPortalUnlockedLedBehaviorModeUid = GalaxySMS.Common.Constants.ClusterLedBehaviorIds.Strobe;
            this.CrisisActivateInputOutputGroupUid = Guid.Empty;
            this.CrisisResetInputOutputGroupUid = Guid.Empty;
            //this.TimeSchedules.Add(new TimeScheduleSelect()
            //{
                
            //});
        }

        public Cluster Clone(Cluster e)
        {
            return new Cluster(e);
        }

        public bool Equals(Cluster other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(Cluster other)
        {
            if (other == null)
                return false;

            if (other.ClusterUid != this.ClusterUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public ListItemBase ToListItemBase()
        {
            return new ListItemBase()
            {
                Uid = ClusterUid,
                EntityId = EntityId,
                Name = ClusterName,
                KeyValue = $"{ClusterNumber}:{ClusterGroupId}",
                Image = gcsBinaryResource?.BinaryResource
            };
        }

        public ClusterListItemCommands ToClusterListItemCommands()
        {
            var o = new ClusterListItemCommands()
            {
                Uid = ClusterUid,
                Name = this.ClusterName,
                Description = this.Description,
                ClusterNumber = this.ClusterNumber,
                ClusterGroupId = this.ClusterGroupId,
                IsActive = this.IsActive,
#if NetCoreApi
#else
                Image = gcsBinaryResource?.BinaryResource,
#endif
                Counts = this.Counts,
                DisabledCommandIds = this.DisabledCommandIds.ToList()
            };
            //foreach (var c in this.ClusterCommands)
            //{
            //    o.Commands.Add(new ClusterCommandBasic(c));
            //}
            //foreach (var c in this.ClusterFlashingCommands)
            //{
            //    o.FlashingCommands.Add(new ClusterCommandBasic(c));
            //}
            return o;
        }

#if NetCoreApi
#else
        public ClusterTimeScheduleItem ToClusterTimeScheduleItem()
        {
            return new ClusterTimeScheduleItem()
            {
                Id = ClusterUid,
                Name = ClusterName,
                Number = PanelScheduleNumber
            };
        }
#endif

#if NetCoreApi
#else
        [DataMember]
#endif
        public int TotalRowCount { get; set; }


#if NetCoreApi
#else
        public int PanelScheduleNumber { get; set; }
#endif

#if NetCoreApi
#else
        [DataMember]
#endif
        public ClusterCounts Counts { get; set; }

    }
}
