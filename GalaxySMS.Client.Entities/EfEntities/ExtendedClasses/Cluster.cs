////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\Cluster.cs
//
// summary:	Implements the cluster class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A cluster. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class Cluster
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Cluster() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The Cluster to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Cluster(Cluster e) : base(e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this Cluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            base.Initialize();
            this.TimeSchedules = new HashSet<TimeScheduleSelect>();
            //this.DayTypes = new HashSet<DayTypeSelect>();
            //this.GalaxyClusterTimeScheduleMaps = new HashSet<GalaxyClusterTimeScheduleMap>();
            this.InputOutputGroups = new HashSet<InputOutputGroup>();
            this.AccessGroups = new HashSet<AccessGroup>();
            this.Areas = new HashSet<Area>();
            this.ClusterEntityMaps = new HashSet<ClusterEntityMap>();
            this.ClusterInputOutputGroups = new HashSet<ClusterInputOutputGroup>();
            this.EntityIds = new HashSet<Guid>();
            this.RoleIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this Cluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The Cluster to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(Cluster e)
        {
            Initialize();
            base.Initialize(e);

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
            this.AccessPortalTypeUid = e.AccessPortalTypeUid;
            this.TemplateAccessPortalUid = e.TemplateAccessPortalUid;

            this.ConcurrencyValue = e.ConcurrencyValue;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;

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
            this.ClusterType = e.ClusterType;
            this.gcsBinaryResource = e.gcsBinaryResource;
            this.TotalRowCount = e.TotalRowCount;
            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.RoleIds != null)
                this.RoleIds = e.RoleIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();
            //this.Site = e.Site;

            //if (e.CrisisActivateInputOutputGroup != null)
            //    this.CrisisActivateInputOutputGroup = new InputOutputGroup(e.CrisisActivateInputOutputGroup);

            //if (e.CrisisResetInputOutputGroup != null)
            //    this.CrisisResetInputOutputGroup = new InputOutputGroup(e.CrisisResetInputOutputGroup);

            //if (e.AccessPortalLockedLedBehaviorMode != null)
            //    this.AccessPortalLockedLedBehaviorMode = new ClusterLedBehaviorMode(e.AccessPortalLockedLedBehaviorMode);

            //if (e.AccessPortalUnlockedLedBehaviorMode != null)
            //    this.AccessPortalUnlockedLedBehaviorMode = new ClusterLedBehaviorMode(e.AccessPortalUnlockedLedBehaviorMode);

            SelectedClusterCommand = e.SelectedClusterCommand;
            Counts = e.Counts;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets the defaults. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetDefaults()
        {
            this.AbaFoldOption = true;
            this.AbaStartDigit = 1;
            this.AbaStopDigit = 60;
            this.WiegandStopBit = 255;
            this.CardaxStartBit = 34;
            this.CardaxStopBit = 59;
            this.TimeScheduleTypeUid = GalaxySMS.Common.Constants.TimeScheduleTypeIds.TimeScheduleType_GalaxyLegacy15MinuteInterval;
            this.CredentialDataLengthUid = GalaxySMS.Common.Constants.CredentialDataLengthIds.Standard48Bits;
            this.ClusterTypeUid = GalaxySMS.Common.Constants.GalaxyClusterTypeIds.GalaxyClusterType_Only635;
            this.TimeZoneId = TimeZoneInfo.Local.Id;
            this.AccessPortalLockedLedBehaviorModeUid = GalaxySMS.Common.Constants.ClusterLedBehaviorIds.SteadyLow;
            this.AccessPortalUnlockedLedBehaviorModeUid = GalaxySMS.Common.Constants.ClusterLedBehaviorIds.Strobe;
            this.CrisisActivateInputOutputGroupUid = Guid.Empty;
            this.CrisisResetInputOutputGroupUid = Guid.Empty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this Cluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The Cluster to process. </param>
        ///
        /// <returns>   A copy of this Cluster. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Cluster Clone(Cluster e)
        {
            return new Cluster(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this Cluster is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(Cluster other)
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

        public bool IsPrimaryKeyEqual(Cluster other)
        {
            if (other == null)
                return false;

            if (other.ClusterUid != this.ClusterUid)
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

        /// <summary>   True to panel data dirty. </summary>
        private bool _panelDataDirty;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the panel data dirty. </summary>
        ///
        /// <value> True if panel data dirty, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool PanelDataDirty
        {
            get { return _panelDataDirty; }
            set
            {
                if (_panelDataDirty != value)
                {
                    _panelDataDirty = value;
                    OnPropertyChanged(() => PanelDataDirty, true, true);
                }
            }
        }


        private ClusterCommand _selectedClusterCommand;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the selected cluster command. </summary>
        ///
        /// <value> The selected cluster command. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ClusterCommand SelectedClusterCommand
        {
            get { return _selectedClusterCommand; }
            set
            {
                if (_selectedClusterCommand != value)
                {
                    _selectedClusterCommand = value;
                    OnPropertyChanged(() => SelectedClusterCommand, false);
                }
            }
        }


        public bool IsResetCrisisModeSupported
        {
            get
            {
                if (this.ClusterTypeUid == GalaxySMS.Common.Constants.GalaxyClusterTypeIds.GalaxyClusterType_Only635)
                    return true;
                return false;
            }
            set
            {
                OnPropertyChanged(() => IsResetCrisisModeSupported, false);
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

        [DataMember]
        public ClusterCounts Counts { get; set; }
        //private int _panelScheduleNumber;

        //[DataMember]
        //public int PanelScheduleNumber
        //{
        //    get { return _panelScheduleNumber; }
        //    set
        //    {
        //        if (_panelScheduleNumber != value)
        //        {
        //            _panelScheduleNumber = value;
        //            OnPropertyChanged(() => PanelScheduleNumber, true);
        //        }
        //    }
        //}

    }
}
