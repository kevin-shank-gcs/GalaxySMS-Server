using System;
using System.Collections.Generic;
using System.Linq;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
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
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();

            GalaxyHardwareAddress = new AccessPortalGalaxyHardwareAddress();
            Properties = new AccessPortalProperties();
            Areas = new HashSet<AccessPortalArea>();
            Schedules = new HashSet<AccessPortalTimeSchedule>();
            AlertEvents = new HashSet<AccessPortalAlertEvent>();
            AuxiliaryOutputs = new HashSet<AccessPortalAuxiliaryOutput>();
            Notes = new HashSet<Note>();
            AccessGroupAccessPortals = new HashSet<AccessGroupAccessPortal>();
            Commands = new HashSet<AccessPortalCommand>();
        }

        public void Initialize(EnsureAccessPortalExistsParameters ensureExistsParameters)
        {
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();

            GalaxyHardwareAddress = new AccessPortalGalaxyHardwareAddress();
            Properties = new AccessPortalProperties();
            Areas = new HashSet<AccessPortalArea>();
            Schedules = new HashSet<AccessPortalTimeSchedule>();
            AlertEvents = new HashSet<AccessPortalAlertEvent>();
            AuxiliaryOutputs = new HashSet<AccessPortalAuxiliaryOutput>();
            Notes = new HashSet<Note>();
            AccessGroupAccessPortals = new HashSet<AccessGroupAccessPortal>();
            Commands = new HashSet<AccessPortalCommand>();

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

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.Duress) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.Duress,
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
                    Description = GalaxySMS.Resources.Resources.AccessPortal_AuxiliaryOutputDescription_Relay2_Text
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
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);
            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
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

            if (e.AccessGroupAccessPortals != null)
                this.AccessGroupAccessPortals = e.AccessGroupAccessPortals.ToCollection();

            if( e.Commands != null)
                this.Commands = e.Commands.ToCollection();
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
    }
}
