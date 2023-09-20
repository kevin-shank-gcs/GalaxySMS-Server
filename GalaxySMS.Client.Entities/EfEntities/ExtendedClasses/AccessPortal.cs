////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\AccessPortal.cs
//
// summary:	Implements the access portal class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class AccessPortal
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortal()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessPortal to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortal(AccessPortal e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this AccessPortal. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            EntityIds = new HashSet<Guid>();
            this.RoleIds = new HashSet<Guid>();
            MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
            GalaxyHardwareAddress = new AccessPortalGalaxyHardwareAddress();
            Properties = new AccessPortalProperties();

            Areas = new HashSet<AccessPortalArea>();
            Schedules = new HashSet<AccessPortalTimeSchedule>();
            AlertEvents = new HashSet<AccessPortalAlertEvent>();
            AuxiliaryOutputs = new HashSet<AccessPortalAuxiliaryOutput>();
            Notes = new HashSet<Note>();
            AccessGroups = new HashSet<AccessGroupAccessPortal>();
            //Commands = new HashSet<AccessPortalCommand>();
            DisabledCommandIds = new HashSet<Guid>();

            InitializeAreaCollection();
            InitializeSchedulesCollection();
            InitializeAlertEventsCollection();
            InitializeAuxiliaryOutputsCollection();
            InitializeAlertEventsCollection();
            InitializeAccessGroupAccessPortalsCollection();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes the area collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void InitializeAreaCollection()
        {
            if (Areas.FirstOrDefault(i => i.AccessPortalAreaTypeUid == GalaxySMS.Common.Constants.AccessPortalAreaTypeIds.FromArea) == null)
            {
                Areas.Add(new AccessPortalArea()
                {
                    AccessPortalAreaTypeUid = GalaxySMS.Common.Constants.AccessPortalAreaTypeIds.FromArea,
                    AreaUid = GalaxySMS.Common.Constants.AreaIds.Area_NoChange
                });
            }

            if (Areas.FirstOrDefault(i => i.AccessPortalAreaTypeUid == GalaxySMS.Common.Constants.AccessPortalAreaTypeIds.ToArea) == null)
            {
                Areas.Add(new AccessPortalArea()
                {
                    AccessPortalAreaTypeUid = GalaxySMS.Common.Constants.AccessPortalAreaTypeIds.ToArea,
                    AreaUid = GalaxySMS.Common.Constants.AreaIds.Area_NoChange
                });
            }

            if (Areas.FirstOrDefault(i => i.AccessPortalAreaTypeUid == GalaxySMS.Common.Constants.AccessPortalAreaTypeIds.WhosInArea) == null)
            {
                Areas.Add(new AccessPortalArea()
                {
                    AccessPortalAreaTypeUid = GalaxySMS.Common.Constants.AccessPortalAreaTypeIds.WhosInArea,
                    AreaUid = GalaxySMS.Common.Constants.AreaIds.Area_NoChange
                });
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes the schedules collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void InitializeSchedulesCollection()
        {
            if (Schedules.FirstOrDefault(i => i.AccessPortalScheduleTypeUid == GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.AutomaticUnlock) == null)
            {
                Schedules.Add(new AccessPortalTimeSchedule()
                {
                    AccessPortalScheduleTypeUid = GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.AutomaticUnlock,
                    TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never
                });
            }

            if (Schedules.FirstOrDefault(i => i.AccessPortalScheduleTypeUid == GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.AuxiliaryOutput) == null)
            {
                Schedules.Add(new AccessPortalTimeSchedule()
                {
                    AccessPortalScheduleTypeUid = GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.AuxiliaryOutput,
                    TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never
                });
            }

            if (Schedules.FirstOrDefault(i => i.AccessPortalScheduleTypeUid == GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.CrisisUnlock) == null)
            {
                Schedules.Add(new AccessPortalTimeSchedule()
                {
                    AccessPortalScheduleTypeUid = GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.CrisisUnlock,
                    TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never
                });
            }

            if (Schedules.FirstOrDefault(i => i.AccessPortalScheduleTypeUid == GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.DisableForcedOpen) == null)
            {
                Schedules.Add(new AccessPortalTimeSchedule()
                {
                    AccessPortalScheduleTypeUid = GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.DisableForcedOpen,
                    TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never
                });
            }

            if (Schedules.FirstOrDefault(i => i.AccessPortalScheduleTypeUid == GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.DisableOpenTooLong) == null)
            {
                Schedules.Add(new AccessPortalTimeSchedule()
                {
                    AccessPortalScheduleTypeUid = GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.DisableOpenTooLong,
                    TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never
                });
            }

            if (Schedules.FirstOrDefault(i => i.AccessPortalScheduleTypeUid == GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.PinRequired) == null)
            {
                Schedules.Add(new AccessPortalTimeSchedule()
                {
                    AccessPortalScheduleTypeUid = GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.PinRequired,
                    TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never
                });
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes the alert events collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void InitializeAlertEventsCollection()
        {
            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.AccessGranted) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.AccessGranted,
                    AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.DoorGroup) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.DoorGroup,
                    AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.DuressAuxiliaryFunction) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.DuressAuxiliaryFunction,
                    AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.ForcedOpen) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.ForcedOpen,
                    AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.OpenTooLong) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.OpenTooLong,
                    AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.PassbackViolation) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.PassbackViolation,
                    AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.InvalidAccessAttempt) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.InvalidAccessAttempt,
                    AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.ReaderHeartbeat) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.ReaderHeartbeat,
                    AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.LockedBy) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.LockedBy,
                    AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.UnlockedBy) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.UnlockedBy,
                    AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup1) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup1,
                    AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup2) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup2,
                    AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup3) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup3,
                    AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup4) == null)
            {
                AlertEvents.Add(new AccessPortalAlertEvent()
                {
                    AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup4,
                    AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never
                });
            }


        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes the auxiliary outputs collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void InitializeAuxiliaryOutputsCollection()
        {
            if (AuxiliaryOutputs.FirstOrDefault(i => i.Tag == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputTags.Relay2) == null)
            {
                AuxiliaryOutputs.Add(new AccessPortalAuxiliaryOutput()
                {
                    Tag = GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputTags.Relay2,
                    AccessPortalAuxiliaryOutputModeUid = GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Follows,
                    TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never,
                    Description = GalaxySMS.Resources.Resources.AccessPortal_AuxiliaryOutputDescription_Relay2_Text
                });
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes the access group access portals collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void InitializeAccessGroupAccessPortalsCollection()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this AccessPortal. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessPortal to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

            if (e.gcsBinaryResource != null)
                this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);

            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();

            if (e.RoleIds != null)
                this.RoleIds = e.RoleIds.ToCollection();

            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();

            this.RegionName = e.RegionName;
            this.SiteName = e.SiteName;
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

            //if (e.Commands != null)
            //    this.Commands = e.Commands.ToCollection();

            if (e.DisabledCommandIds != null)
                this.DisabledCommandIds = e.DisabledCommandIds.ToCollection();

            this.ClusterUid = e.ClusterUid;
            this.GalaxyPanelUid = e.GalaxyPanelUid;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.PanelNumber = e.PanelNumber;
            this.BoardNumber = e.BoardNumber;
            this.SectionNumber = e.SectionNumber;
            this.ModuleNumber = e.ModuleNumber;
            this.NodeNumber = e.NodeNumber;
            this.IsNodeActive = e.IsNodeActive;
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
            this.TotalRowCount = e.TotalRowCount;
            this.DoorNumber = e.DoorNumber;
            this.GalaxyInterfaceBoardSectionNodeUid = e.GalaxyInterfaceBoardSectionNodeUid;
            this.GalaxyHardwareModuleUid = e.GalaxyHardwareModuleUid;
            this.GalaxyInterfaceBoardSectionUid = e.GalaxyInterfaceBoardSectionUid;
            this.GalaxyInterfaceBoardUid = e.GalaxyInterfaceBoardUid;
            this.PanelName = e.PanelName;
            this.ClusterName = e.ClusterName;
            this.IsBoundToHardware = e.IsBoundToHardware;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this AccessPortal. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessPortal to process. </param>
        ///
        /// <returns>   A copy of this AccessPortal. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortal Clone(AccessPortal e)
        {
            return new AccessPortal(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this AccessPortal is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(AccessPortal other)
        {
            return base.Equals(other);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'other' is primary key equal. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if primary key equal, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsPrimaryKeyEqual(AccessPortal other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalUid != this.AccessPortalUid)
                return false;
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Serves as the default hash function. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A hash code for the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>   The command menu. </summary>
        private ObservableCollection<MenuItem> _commandMenu;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the command menu. </summary>
        ///
        /// <value> The command menu. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<MenuItem> CommandMenu
        {
            get { return _commandMenu; }
            set
            {
                if (_commandMenu != value)
                {
                    _commandMenu = value;
                    OnPropertyChanged(() => CommandMenu, false);
                }
            }
        }


        private AccessPortalStatusReply _lastStatusReply;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the last status reply. </summary>
        /// <remarks>   This is a client-side only property provided as a convenience. The client application can populate this property as status updates are received from the server</remarks>
        /// <value> The last status reply. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalStatusReply LastStatusReply
        {
            get { return _lastStatusReply; }
            set
            {
                if (_lastStatusReply != value)
                {
                    _lastStatusReply = value;
                    OnPropertyChanged(() => LastStatusReply, false);
                }
            }
        }
        public string HardwareAddressString
        {
            get
            {
                return $"Cluster Group #:{ClusterGroupId}, Cluster #:{ClusterNumber}, Panel #:{PanelNumber}, Board #:{BoardNumber}, Section #:{SectionNumber}, Device #:{NodeNumber}";
            }
        }

        private int _TotalRowCount;

        [DataMember]
        public int TotalRowCount
        {
            get => _TotalRowCount;
            set
            {
                if (_TotalRowCount != value)
                {
                    _TotalRowCount = value;
                    OnPropertyChanged(() => TotalRowCount, false);
                }
            }
        }

        private int _DoorNumber;

        [DataMember]
        public int DoorNumber
        {
            get => _DoorNumber;
            set
            {
                if (_DoorNumber != value)
                {
                    _DoorNumber = value;
                    OnPropertyChanged(() => DoorNumber, false);
                }
            }
        }

        private Guid _GalaxyInterfaceBoardSectionNodeUid;

        [DataMember]
        public Guid GalaxyInterfaceBoardSectionNodeUid
        {
            get => _GalaxyInterfaceBoardSectionNodeUid;
            set
            {
                if (_GalaxyInterfaceBoardSectionNodeUid != value)
                {
                    _GalaxyInterfaceBoardSectionNodeUid = value;
                    OnPropertyChanged(() => GalaxyInterfaceBoardSectionNodeUid, false);
                }
            }
        }

        private Guid _GalaxyHardwareModuleUid;

        [DataMember]
        public Guid GalaxyHardwareModuleUid
        {
            get => _GalaxyHardwareModuleUid;
            set
            {
                if (_GalaxyHardwareModuleUid != value)
                {
                    _GalaxyHardwareModuleUid = value;
                    OnPropertyChanged(() => GalaxyHardwareModuleUid, false);
                }
            }
        }

        private Guid _GalaxyInterfaceBoardSectionUid;

        [DataMember]
        public Guid GalaxyInterfaceBoardSectionUid
        {
            get => _GalaxyInterfaceBoardSectionUid;
            set
            {
                if (_GalaxyInterfaceBoardSectionUid != value)
                {
                    _GalaxyInterfaceBoardSectionUid = value;
                    OnPropertyChanged(() => GalaxyInterfaceBoardSectionUid, false);
                }
            }
        }

        private Guid _GalaxyInterfaceBoardUid;

        [DataMember]
        public Guid GalaxyInterfaceBoardUid
        {
            get => _GalaxyInterfaceBoardUid;
            set
            {
                if (_GalaxyInterfaceBoardUid != value)
                {
                    _GalaxyInterfaceBoardUid = value;
                    OnPropertyChanged(() => GalaxyInterfaceBoardUid, false);
                }
            }
        }

        private string _panelName;

        [DataMember]
        public string PanelName
        {
            get => _panelName;
            set
            {
                if (_panelName != value)
                {
                    _panelName = value;
                    OnPropertyChanged(() => PanelName, false);
                }
            }
        }


        private string _clusterName;

        [DataMember]
        public string ClusterName
        {
            get => _clusterName;
            set
            {
                if (_clusterName != value)
                {
                    _clusterName = value;
                    OnPropertyChanged(() => ClusterName, false);
                }
            }
        }
    }
}
