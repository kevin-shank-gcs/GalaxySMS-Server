using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{

    [DataContract]
    public class EntityBaseSimple : DtoObjectBase
    {
        [DataMember]
        public int ConcurrencyValue { get; set; }


        #region Custom properties added just for client side usage

        /// <summary>   True if role has permission. </summary>
        private bool _roleIncludesItem;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the role has permission. </summary>
        ///
        /// <value> True if role has permission, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool RoleIncludesItem
        {
            get { return _roleIncludesItem; }
            set
            {
                if (_roleIncludesItem != value)
                {
                    _roleIncludesItem = value;
                    //OnPropertyChanged(() => RoleIncludesItem);
                }
            }
        }

        #endregion

    }

    [DataContract]
    public class InputOutputGroupSelectionItemBasic : EntityBaseSimple
    {
        public InputOutputGroupSelectionItemBasic()
        {

        }


        [DataMember]
        public Guid InputOutputGroupUid { get; set; }

        [DataMember]
        public Guid ClusterUid { get; set; }

        [DataMember]
        public Guid EntityId { get; set; }

        [DataMember]
        public string InputOutputGroupName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int InputOutputGroupNumber { get; set; }
    }

    [DataContract]
    public class AccessGroupSelectionItemBasic : EntityBaseSimple
    {
        public AccessGroupSelectionItemBasic()
        {

        }

        [DataMember]
        public Guid AccessGroupUid { get; set; }

        [DataMember]
        public Guid ClusterUid { get; set; }

        [DataMember]
        public Guid EntityId { get; set; }

        [DataMember]
        public string AccessGroupName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int AccessGroupNumber { get; set; }

        //[DataMember]
        public bool IsExtendedAccessGroup => AccessGroupNumber > GalaxySMS.Common.Constants.AccessGroupLimits.UnlimitedAccess;

        public bool Selected { get; set; }

    }


    [DataContract]
    public class AccessPortalSelectionItemBasic : EntityBaseSimple
    {
        public AccessPortalSelectionItemBasic()
        {

        }

        [DataMember]
        public Guid AccessPortalUid { get; set; }

        [DataMember]
        public Guid ClusterUid { get; set; }

        [DataMember]
        public Guid EntityId { get; set; }

        [DataMember]
        public string AccessPortalName { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public byte[] BinaryResource { get; set; }

        [DataMember]
        public string ClusterTypeCode { get; set; }

        [DataMember]
        public string GalaxyPanelTypeCode { get; set; }

        [DataMember]
        public string InterfaceBoardModel { get; set; }

        [DataMember]
        public short InterfaceBoardSectionModeCode { get; set; }

        [DataMember]
        public short InterfaceBoardTypeCode { get; set; }

        [DataMember]
        public short ModuleTypeCode { get; set; }

        public bool Selected { get; set; }

    }


    [DataContract]
    public class InputDeviceSelectionItemBasic : EntityBaseSimple
    {
        public InputDeviceSelectionItemBasic()
        {

        }

        [DataMember]
        public Guid InputDeviceUid { get; set; }

        [DataMember]
        public Guid ClusterUid { get; set; }

        [DataMember]
        public Guid EntityId { get; set; }

        [DataMember]
        public string InputName { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public byte[] BinaryResource { get; set; }

        [DataMember]
        public string ClusterTypeCode { get; set; }

        [DataMember]
        public string GalaxyPanelTypeCode { get; set; }

        [DataMember]
        public string InterfaceBoardModel { get; set; }

        [DataMember]
        public short InterfaceBoardSectionModeCode { get; set; }

        [DataMember]
        public short InterfaceBoardTypeCode { get; set; }

        [DataMember]
        public short ModuleTypeCode { get; set; }
    }

    [DataContract]
    public class OutputDeviceSelectionItemBasic : EntityBaseSimple
    {
        public OutputDeviceSelectionItemBasic()
        {

        }

        [DataMember]
        public Guid OutputDeviceUid { get; set; }

        [DataMember]
        public Guid ClusterUid { get; set; }

        [DataMember]
        public Guid EntityId { get; set; }

        [DataMember]
        public string OutputName { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public byte[] BinaryResource { get; set; }

        [DataMember]
        public string ClusterTypeCode { get; set; }

        [DataMember]
        public string GalaxyPanelTypeCode { get; set; }

        [DataMember]
        public string InterfaceBoardModel { get; set; }

        [DataMember]
        public short InterfaceBoardSectionModeCode { get; set; }

        [DataMember]
        public short InterfaceBoardTypeCode { get; set; }

        [DataMember]
        public short ModuleTypeCode { get; set; }
    }


    [DataContract]
    public class TimeScheduleSelectionItemBasic : EntityBaseSimple
    {
        public TimeScheduleSelectionItemBasic()
        {

        }

        [DataMember]
        public Guid TimeScheduleUid { get; set; }

        [DataMember]
        public string TimeScheduleName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Guid EntityId { get; set; }

        [DataMember]

        public int PanelScheduleNumber { get; set; }

    }



    [DataContract]
    public class ClusterSelectionItemBasic : EntityBaseSimple
    {
        public ClusterSelectionItemBasic()
        {
            AccessGroups = new HashSet<AccessGroupSelectionItemBasic>();
            InputOutputGroups = new HashSet<InputOutputGroupSelectionItemBasic>();
            AccessPortals = new HashSet<AccessPortalSelectionItemBasic>();
            InputDevices = new HashSet<InputDeviceSelectionItemBasic>();
            OutputDevices = new HashSet<OutputDeviceSelectionItemBasic>();
        }

        public ClusterSelectionItemBasic(Cluster o)
        {
            AccessGroups = new HashSet<AccessGroupSelectionItemBasic>();
            InputOutputGroups = new HashSet<InputOutputGroupSelectionItemBasic>();
            AccessPortals = new HashSet<AccessPortalSelectionItemBasic>();
            InputDevices = new HashSet<InputDeviceSelectionItemBasic>();
            OutputDevices = new HashSet<OutputDeviceSelectionItemBasic>();

            ClusterUid = o.ClusterUid;
            SiteUid = o.SiteUid;
            ClusterName = o.ClusterName;
            ClusterNumber = o.ClusterNumber;
            ClusterGroupId = o.ClusterGroupId;
            EntityId = o.EntityId;

            Photo = o.gcsBinaryResource?.BinaryResource;
        }

        [DataMember]
        public Guid ClusterUid { get; set; }

        [DataMember]
        public Guid SiteUid { get; set; }

        [DataMember]
        public string ClusterName { get; set; }

        [DataMember]
        public int ClusterNumber { get; set; }

        [DataMember]
        public int ClusterGroupId { get; set; }

        [DataMember]
        public byte[] Photo { get; set; }

        [DataMember]
        public Guid EntityId { get; set; }

        [DataMember]
        public ICollection<AccessGroupSelectionItemBasic> AccessGroups { get; set; }

        [DataMember]
        public ICollection<InputOutputGroupSelectionItemBasic> InputOutputGroups { get; set; }

        [DataMember]
        public ICollection<TimeScheduleSelectionItemBasic> TimeSchedules { get; set; }

        [DataMember]
        public ICollection<AccessPortalSelectionItemBasic> AccessPortals { get; set; }

        [DataMember]
        public ICollection<InputDeviceSelectionItemBasic> InputDevices { get; set; }

        [DataMember]
        public ICollection<OutputDeviceSelectionItemBasic> OutputDevices { get; set; }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the access group non extended selection items. </summary>
        ///
        /// <value> The access group non extended selection items. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<AccessGroupSelectionItemBasic> AccessGroupNonExtendedSelectionItems
        {
            get { return AccessGroups.Where(i => i.IsExtendedAccessGroup == false && i.AccessGroupNumber < GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup).ToObservableCollection(); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the access group with extended selection items. </summary>
        ///
        /// <value> The access group with extended selection items. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<AccessGroupSelectionItemBasic> AccessGroupWithExtendedSelectionItems
        {
            get { return AccessGroups.Where(i => i.AccessGroupNumber < GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup).ToObservableCollection(); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the access group with personal access group selection items. </summary>
        ///
        /// <value> The access group with personal access group selection items. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<AccessGroupSelectionItemBasic> AccessGroupWithPersonalAccessGroupSelectionItems
        {
            get { return AccessGroups.ToObservableCollection(); }
        }


    }

    [DataContract]
    public class SiteSelectionItemBasic : EntityBaseSimple
    {
        public SiteSelectionItemBasic()
        {
            Clusters = new HashSet<ClusterSelectionItemBasic>();
        }

        [DataMember]
        public Guid SiteUid { get; set; }

        [DataMember]
        public Guid RegionUid { get; set; }

        [DataMember]
        public string SiteName { get; set; }

        [DataMember]
        public byte[] BinaryResource { get; set; }

        [DataMember]
        public string SiteId { get; set; }

        [DataMember]
        public Guid EntityId { get; set; }

        [DataMember]
        public ICollection<ClusterSelectionItemBasic> Clusters { get; set; }

    }



    [DataContract]

    public class RegionSelectionItemBasic : EntityBaseSimple
    {
        public RegionSelectionItemBasic()
        {
            Sites = new HashSet<SiteSelectionItemBasic>();
        }

        [DataMember]
        public Guid RegionUid { get; set; }

        [DataMember]
        public string RegionName { get; set; }

        [DataMember]
        public byte[] BinaryResource { get; set; }

        [DataMember]
        public string RegionId { get; set; }

        [DataMember]
        public Guid EntityId { get; set; }

        [DataMember]
        public ICollection<SiteSelectionItemBasic> Sites { get; set; }

    }


    [DataContract]
    public class AccessAndAlarmControlPermissionsEditingDataBasic : EntityBaseSimple
    {
        public AccessAndAlarmControlPermissionsEditingDataBasic()
        {
            Regions = new HashSet<RegionSelectionItemBasic>();

        }

        [DataMember]
        public ICollection<RegionSelectionItemBasic> Regions { get; set; }

    }
}
