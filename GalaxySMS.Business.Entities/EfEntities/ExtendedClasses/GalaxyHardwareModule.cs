using System;
using System.Collections.Generic;
using System.Linq;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyHardwareModule
    {
        public GalaxyHardwareModule()
        {
            Initialize();
        }

        public GalaxyHardwareModule(GalaxyHardwareModule e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.GalaxyInterfaceBoardSectionNodes = new HashSet<GalaxyInterfaceBoardSectionNode>();
        }

        public void Initialize(GalaxyHardwareModule e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyHardwareModuleUid = e.GalaxyHardwareModuleUid;
            this.GalaxyInterfaceBoardSectionUid = e.GalaxyInterfaceBoardSectionUid;
            this.GalaxyHardwareModuleTypeUid = e.GalaxyHardwareModuleTypeUid;
            this.ModuleNumber = e.ModuleNumber;
            this.IsModuleActive = e.IsModuleActive;
            this.IsDirty = e.IsDirty;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.GalaxyInterfaceBoardSectionNodes = e.GalaxyInterfaceBoardSectionNodes.ToCollection();

            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.PanelNumber = e.PanelNumber;
            this.BoardNumber = e.BoardNumber;
            this.SectionNumber = e.SectionNumber;
        }

        public bool IsAnythingDirty
        {
            get
            {
                foreach (var o in GalaxyInterfaceBoardSectionNodes)
                {
                    if (o.IsAnythingDirty == true)
                        return true;
                }
                return IsDirty;
            }
        }

        public GalaxyHardwareModule Clone(GalaxyHardwareModule e)
        {
            return new GalaxyHardwareModule(e);
        }

        public bool Equals(GalaxyHardwareModule other)
        {
            if (other == null)
                return false;

            if (this.ModuleNumber != other.ModuleNumber ||
                this.GalaxyHardwareModuleUid != other.GalaxyHardwareModuleUid ||
                this.GalaxyInterfaceBoardSectionUid != other.GalaxyInterfaceBoardSectionUid ||
                this.GalaxyHardwareModuleTypeUid != other.GalaxyHardwareModuleTypeUid)
                return false;
            if (this.GalaxyInterfaceBoardSectionNodes?.Count != other?.GalaxyInterfaceBoardSectionNodes?.Count)
                return false;

            foreach( var n in this.GalaxyInterfaceBoardSectionNodes)
            {
                var o = other.GalaxyInterfaceBoardSectionNodes.Where(i => i.GalaxyInterfaceBoardSectionNodeUid == n.GalaxyInterfaceBoardSectionNodeUid).FirstOrDefault();
                if (n.Equals(o) == false)
                    return false;
            }

            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyHardwareModule other)
        {
            if (other == null)
                return false;

            if (other.GalaxyHardwareModuleUid != this.GalaxyHardwareModuleUid)
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

