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
    public partial class AccessPortal
    {
        public AccessPortal()
        {
            Initialize();
        }

        public AccessPortal(AccessPortal e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.EntityIds = new HashSet<Guid>();
            this.RoleIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();

            GalaxyHardwareAddress = new AccessPortalGalaxyHardwareAddress();
            Properties = new AccessPortalProperties();
            Areas = new HashSet<AccessPortalArea>();
            Schedules = new HashSet<AccessPortalTimeSchedule>();
            AlertEvents = new HashSet<AccessPortalAlertEvent>();
            AuxiliaryOutputs = new HashSet<AccessPortalAuxiliaryOutput>();
            Notes = new HashSet<Note>();
            AccessGroups = new HashSet<AccessGroupAccessPortal>();
            Commands = new HashSet<AccessPortalCommand>();
            DisabledCommandIds = new HashSet<Guid>();
            LastUsageData = new AccessPortalLastUsageData();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(EnsureAccessPortalExistsParameters ensureExistsParameters)
        {
            this.EntityIds = new HashSet<Guid>();
            this.RoleIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();

            GalaxyHardwareAddress = new AccessPortalGalaxyHardwareAddress();
            Properties = new AccessPortalProperties();
            Areas = new HashSet<AccessPortalArea>();
            Schedules = new HashSet<AccessPortalTimeSchedule>();
            AlertEvents = new HashSet<AccessPortalAlertEvent>();
            AuxiliaryOutputs = new HashSet<AccessPortalAuxiliaryOutput>();
            Notes = new HashSet<Note>();
            AccessGroups = new HashSet<AccessGroupAccessPortal>();
            Commands = new HashSet<AccessPortalCommand>();
            DisabledCommandIds = new HashSet<Guid>();

            InitializeAreaCollection(
                ensureExistsParameters.Areas.FirstOrDefault(a => a.AreaNumber == (int)GalaxySMS.Common.Enums.AreaNumber.NoChange).AreaUid,
                ensureExistsParameters.Areas.FirstOrDefault(a => a.AreaNumber == (int)GalaxySMS.Common.Enums.AreaNumber.NoChange).AreaUid);

            InitializeSchedulesCollection(GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never, GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always);
            InitializeAlertEventsCollection(GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never, GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always,
                ensureExistsParameters.InputOutputGroups.FirstOrDefault(a => a.IOGroupNumber == (int)GalaxySMS.Common.Enums.InputOutputGroupNumber.None).InputOutputGroupUid);
            InitializeAuxiliaryOutputsCollection(GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never, GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always);
            InitializeAccessGroupAccessPortalsCollection();
        }

        public void InitializeAreaCollection(Guid noChangeAreaUid, Guid noAreaUid)
        {
            if (Areas.FirstOrDefault(i => i.AccessPortalAreaTypeUid == GalaxySMS.Common.Constants.AccessPortalAreaTypeIds.FromArea) == null)
            {
                Areas.Add(new AccessPortalArea()
                {
                    AccessPortalAreaTypeUid = GalaxySMS.Common.Constants.AccessPortalAreaTypeIds.FromArea,
                    AreaUid = noChangeAreaUid
                });
            }

            if (Areas.FirstOrDefault(i => i.AccessPortalAreaTypeUid == GalaxySMS.Common.Constants.AccessPortalAreaTypeIds.ToArea) == null)
            {
                Areas.Add(new AccessPortalArea()
                {
                    AccessPortalAreaTypeUid = GalaxySMS.Common.Constants.AccessPortalAreaTypeIds.ToArea,
                    AreaUid = noChangeAreaUid
                });
            }

            if (Areas.FirstOrDefault(i => i.AccessPortalAreaTypeUid == GalaxySMS.Common.Constants.AccessPortalAreaTypeIds.WhosInArea) == null)
            {
                Areas.Add(new AccessPortalArea()
                {
                    AccessPortalAreaTypeUid = GalaxySMS.Common.Constants.AccessPortalAreaTypeIds.WhosInArea,
                    AreaUid = noAreaUid
                });
            }
        }

        public void InitializeSchedulesCollection(Guid neverScheduleUid, Guid alwaysScheduleUid)
        {
            if (Schedules.FirstOrDefault(i => i.AccessPortalScheduleTypeUid == GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.AutomaticUnlock) == null)
            {
                Schedules.Add(new AccessPortalTimeSchedule()
                {
                    AccessPortalScheduleTypeUid = GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.AutomaticUnlock,
                    TimeScheduleUid = neverScheduleUid
                });
            }

            if (Schedules.FirstOrDefault(i => i.AccessPortalScheduleTypeUid == GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.AuxiliaryOutput) == null)
            {
                Schedules.Add(new AccessPortalTimeSchedule()
                {
                    AccessPortalScheduleTypeUid = GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.AuxiliaryOutput,
                    TimeScheduleUid = neverScheduleUid
                });
            }

            if (Schedules.FirstOrDefault(i => i.AccessPortalScheduleTypeUid == GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.CrisisUnlock) == null)
            {
                Schedules.Add(new AccessPortalTimeSchedule()
                {
                    AccessPortalScheduleTypeUid = GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.CrisisUnlock,
                    TimeScheduleUid = neverScheduleUid
                });
            }

            if (Schedules.FirstOrDefault(i => i.AccessPortalScheduleTypeUid == GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.DisableForcedOpen) == null)
            {
                Schedules.Add(new AccessPortalTimeSchedule()
                {
                    AccessPortalScheduleTypeUid = GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.DisableForcedOpen,
                    TimeScheduleUid = neverScheduleUid
                });
            }

            if (Schedules.FirstOrDefault(i => i.AccessPortalScheduleTypeUid == GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.DisableOpenTooLong) == null)
            {
                Schedules.Add(new AccessPortalTimeSchedule()
                {
                    AccessPortalScheduleTypeUid = GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.DisableOpenTooLong,
                    TimeScheduleUid = neverScheduleUid
                });
            }

            if (Schedules.FirstOrDefault(i => i.AccessPortalScheduleTypeUid == GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.PinRequired) == null)
            {
                Schedules.Add(new AccessPortalTimeSchedule()
                {
                    AccessPortalScheduleTypeUid = GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.PinRequired,
                    TimeScheduleUid = neverScheduleUid
                });
            }

        }

        public void InitializeAlertEventsCollection(Guid neverScheduleUid, Guid alwaysScheduleUid, Guid ioGroupUid)
        {
            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.AccessGranted) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.AccessGranted,
                    AcknowledgeTimeScheduleUid = neverScheduleUid,
                    InputOutputGroupUid = ioGroupUid
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.DoorGroup) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.DoorGroup,
                    AcknowledgeTimeScheduleUid = neverScheduleUid,
                    InputOutputGroupUid = ioGroupUid
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.DuressAuxiliaryFunction) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.DuressAuxiliaryFunction,
                    AcknowledgeTimeScheduleUid = neverScheduleUid,
                    InputOutputGroupUid = ioGroupUid
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.ForcedOpen) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.ForcedOpen,
                    AcknowledgeTimeScheduleUid = neverScheduleUid,
                    InputOutputGroupUid = ioGroupUid
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.OpenTooLong) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.OpenTooLong,
                    AcknowledgeTimeScheduleUid = neverScheduleUid,
                    InputOutputGroupUid = ioGroupUid
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.PassbackViolation) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.PassbackViolation,
                    AcknowledgeTimeScheduleUid = neverScheduleUid,
                    InputOutputGroupUid = ioGroupUid
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.InvalidAccessAttempt) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.InvalidAccessAttempt,
                    AcknowledgeTimeScheduleUid = neverScheduleUid,
                    InputOutputGroupUid = ioGroupUid
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.ReaderHeartbeat) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.ReaderHeartbeat,
                    AcknowledgeTimeScheduleUid = neverScheduleUid,
                    InputOutputGroupUid = ioGroupUid
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.LockedBy) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.LockedBy,
                    AcknowledgeTimeScheduleUid = neverScheduleUid,
                    InputOutputGroupUid = ioGroupUid
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.UnlockedBy) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.UnlockedBy,
                    AcknowledgeTimeScheduleUid = neverScheduleUid,
                    InputOutputGroupUid = ioGroupUid
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup1) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup1,
                    AcknowledgeTimeScheduleUid = neverScheduleUid,
                    InputOutputGroupUid = ioGroupUid
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup2) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup2,
                    AcknowledgeTimeScheduleUid = neverScheduleUid,
                    InputOutputGroupUid = ioGroupUid
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup3) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup3,
                    AcknowledgeTimeScheduleUid = neverScheduleUid,
                    InputOutputGroupUid = ioGroupUid
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup4) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup4,
                    AcknowledgeTimeScheduleUid = neverScheduleUid,
                    InputOutputGroupUid = ioGroupUid
                });
            }


        }

        public void InitializeAuxiliaryOutputsCollection(Guid neverScheduleUid, Guid alwaysScheduleUid)
        {
            if (AuxiliaryOutputs.FirstOrDefault(i => i.Tag == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputTags.Relay2) == null)
            {
                AuxiliaryOutputs.Add(new AccessPortalAuxiliaryOutput()
                {
                    Tag = GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputTags.Relay2,
                    AccessPortalAuxiliaryOutputModeUid = GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Follows,
                    TimeScheduleUid = neverScheduleUid,
#if NetCoreApi
                    Description = "Relay 2"
#else
                    Description = GalaxySMS.Resources.Resources.AccessPortal_AuxiliaryOutputDescription_Relay2_Text
#endif

                });
            }

        }

        public void InitializeAccessGroupAccessPortalsCollection()
        {

        }

        public void Initialize(AccessPortal e)
        {
            Initialize();
            if (e == null)
                return;
            this.AccessPortalUid = e.AccessPortalUid;
            this.AccessPortalTypeUid = e.AccessPortalTypeUid;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.SiteUid = e.SiteUid;
            this.EntityId = e.EntityId;
            this.PortalName = e.PortalName;
            this.Location = e.Location;
            this.ServiceComment = e.ServiceComment;
            this.CriticalityComment = e.CriticalityComment;
            this.Comment = e.Comment;
            this.IsTemplate = e.IsTemplate;
            this.IsEnabled = e.IsEnabled;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);
            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.RoleIds != null)
                this.RoleIds = e.RoleIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();

            this.RegionUid = e.RegionUid;
            this.RegionName = e.RegionName;
            this.SiteName = e.SiteName;
            this.ClusterUid = e.ClusterUid;
            this.GalaxyPanelUid = e.GalaxyPanelUid;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.PanelNumber = e.PanelNumber;
            this.BoardNumber = e.BoardNumber;
            this.SectionNumber = e.SectionNumber;
            this.ModuleNumber = e.ModuleNumber;
            this.NodeNumber = e.NodeNumber;
            this.ClusterTypeUid = e.ClusterTypeUid;
            this.ClusterTypeCode = e.ClusterTypeCode;
            this.GalaxyPanelModelUid = e.GalaxyPanelModelUid;
            this.GalaxyPanelTypeCode = e.GalaxyPanelTypeCode;
            this.InterfaceBoardTypeUid = e.InterfaceBoardTypeUid;
            this.InterfaceBoardTypeCode = e.InterfaceBoardTypeCode;
            this.InterfaceBoardModel = e.InterfaceBoardModel;
            this.InterfaceBoardSectionModeUid = e.InterfaceBoardSectionModeUid;
            this.InterfaceBoardSectionModeCode = e.InterfaceBoardSectionModeCode;
            this.GalaxyHardwareModuleTypeUid = e.GalaxyHardwareModuleTypeUid;
            this.ModuleTypeCode = e.ModuleTypeCode;
            this.IsNodeActive = e.IsNodeActive;
            this.IsBoundToHardware = e.IsBoundToHardware;
            
            this.GalaxyHardwareAddress = e.GalaxyHardwareAddress;

            if (e.Properties != null)
                this.Properties = e.Properties;

            if (e.Areas != null)
                this.Areas = e.Areas.ToCollection();

            if (e.Schedules != null)
                this.Schedules = e.Schedules.ToCollection();

            if (e.AlertEvents != null)
                this.AlertEvents = e.AlertEvents.ToCollection();

            if (e.AuxiliaryOutputs != null)
                this.AuxiliaryOutputs = e.AuxiliaryOutputs.ToCollection();

            if (e.Notes != null)
                this.Notes = e.Notes.ToCollection();

            if (e.AccessGroups != null)
                this.AccessGroups = e.AccessGroups.ToCollection();

            if (e.Commands != null)
                this.Commands = e.Commands.ToCollection();

            if (e.DisabledCommandIds != null)
                this.DisabledCommandIds = e.DisabledCommandIds.ToCollection();

            this.TotalRowCount = e.TotalRowCount;
            this.DoorNumber = e.DoorNumber;
            this.GalaxyInterfaceBoardSectionNodeUid = e.GalaxyInterfaceBoardSectionNodeUid;
            this.GalaxyHardwareModuleUid = e.GalaxyHardwareModuleUid;
            this.GalaxyInterfaceBoardSectionUid = e.GalaxyInterfaceBoardSectionUid;
            this.GalaxyInterfaceBoardUid = e.GalaxyInterfaceBoardUid;
            this.PanelName = e.PanelName;
            this.ClusterName = e.ClusterName;
            this.LastUsageData = e.LastUsageData;
        }

        public AccessPortal Clone(AccessPortal e)
        {
            return new AccessPortal(e);
        }

        public bool Equals(AccessPortal other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortal other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalUid != this.AccessPortalUid)
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
                Uid = AccessPortalUid,
                EntityId = EntityId,
                Name = this.PortalName,
                KeyValue = AccessPortalUid.ToString(),
                Image = gcsBinaryResource?.BinaryResource
            };
        }

        public AccessPortalListItemCommands ToAccessPortalListItemCommands()
        {
            var o = new AccessPortalListItemCommands()
            {
                Uid = AccessPortalUid,
                EntityId = EntityId,
                Name = this.PortalName,
                KeyValue = AccessPortalUid.ToString(),
                Image = gcsBinaryResource?.BinaryResource,
                IsNodeActive = this.IsNodeActive,
                DisabledCommandIds = this.DisabledCommandIds.ToList(),
                LastUsageData = this.LastUsageData,
                IsBoundToHardware = !string.IsNullOrEmpty(PanelName),
                InterfaceBoardSectionModeCode = this.InterfaceBoardSectionModeCode
                //Commands = this.Commands.ToList()
            };
            //foreach (var c in Commands)
            //{
            //    o.Commands.Add(new AccessPortalCommandBasic(c));
            //}

            return o;
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int TotalRowCount { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public int DoorNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyInterfaceBoardSectionNodeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyHardwareModuleUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyInterfaceBoardSectionUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyInterfaceBoardUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PanelName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ClusterName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessPortalLastUsageData LastUsageData { get; set; }

    }
}
