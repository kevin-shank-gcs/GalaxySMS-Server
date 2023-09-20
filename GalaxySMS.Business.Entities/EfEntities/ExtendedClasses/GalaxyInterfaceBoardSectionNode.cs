using System;
using System.Collections.Generic;
using System.Linq;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
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
        }

        public void Initialize(GalaxyInterfaceBoardSectionNode e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyInterfaceBoardSectionNodeUid = e.GalaxyInterfaceBoardSectionNodeUid;
            this.GalaxyInterfaceBoardSectionUid = e.GalaxyInterfaceBoardSectionUid;
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
    }
}
