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
    public partial class GalaxyInterfaceBoardSectionNode
    {
        public GalaxyInterfaceBoardSectionNode()
        {
            Initialize();
        }

        public GalaxyInterfaceBoardSectionNode(GalaxyInterfaceBoardSectionNode e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.InputOutputGroupAssignments = new HashSet<InputOutputGroupAssignment>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(GalaxyInterfaceBoardSectionNode e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyInterfaceBoardSectionNodeUid = e.GalaxyInterfaceBoardSectionNodeUid;
            //this.GalaxyInterfaceBoardSectionUid = e.GalaxyInterfaceBoardSectionUid;
            this.NodeNumber = e.NodeNumber;
            this.IsNodeActive = e.IsNodeActive;
            this.IsDirty = e.IsDirty;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.GalaxyHardwareModuleUid = e.GalaxyHardwareModuleUid;
            this.InputOutputGroupAssignments = e.InputOutputGroupAssignments.ToCollection();

            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.PanelNumber = e.PanelNumber;
            this.BoardNumber = e.BoardNumber;
            this.SectionNumber = e.SectionNumber;
            this.ModuleNumber = e.ModuleNumber;
            this.ClusterUid = e.ClusterUid;
            this.DeviceName = e.DeviceName;
            this.AccessPortalUid = e.AccessPortalUid;
            this.InputDeviceUid = e.InputDeviceUid;
            this.OutputDeviceUid = e.OutputDeviceUid;
            this.PortalName = e.PortalName;
            this.InputName = e.InputName;
            this.OutputName = e.OutputName;
            this.GalaxyPanelUid = e.GalaxyPanelUid;
        }


        public bool IsAnythingDirty
        {
            get
            {
                foreach (var o in InputOutputGroupAssignments)
                {
                    if (o.IsAnythingDirty == true)
                        return true;
                }
                return IsDirty;
            }
        }

        public GalaxyInterfaceBoardSectionNode Clone(GalaxyInterfaceBoardSectionNode e)
        {
            return new GalaxyInterfaceBoardSectionNode(e);
        }

        public bool Equals(GalaxyInterfaceBoardSectionNode other)
        {
            if (other == null)
                return false;

            if (this.GalaxyInterfaceBoardSectionNodeUid != other.GalaxyInterfaceBoardSectionNodeUid ||
                this.GalaxyHardwareModuleUid != other.GalaxyHardwareModuleUid ||
                this.NodeNumber != other.NodeNumber ||
                this.IsNodeActive != other.IsNodeActive)
                return false;

            foreach (var n in this.InputOutputGroupAssignments)
            {
                var o = other.InputOutputGroupAssignments.Where(i => i.InputOutputGroupAssignmentUid == n.InputOutputGroupAssignmentUid).FirstOrDefault();
                if (n.Equals(o) == false)
                    return false;
            }

            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyInterfaceBoardSectionNode other)
        {
            if (other == null)
                return false;

            if (other.GalaxyInterfaceBoardSectionNodeUid != this.GalaxyInterfaceBoardSectionNodeUid)
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

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AccessPortalUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid InputDeviceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid OutputDeviceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PortalName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InputName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string OutputName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyPanelUid { get; set; }


    }
}
