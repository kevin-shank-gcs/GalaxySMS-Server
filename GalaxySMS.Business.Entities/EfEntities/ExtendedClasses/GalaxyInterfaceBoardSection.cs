using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyInterfaceBoardSection
    {
        public GalaxyInterfaceBoardSection()
        {
            Initialize();
        }

        public GalaxyInterfaceBoardSection(GalaxyInterfaceBoardSection e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.GalaxyHardwareModules = new HashSet<GalaxyHardwareModule>();
        }

        public void Initialize(GalaxyInterfaceBoardSection e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyInterfaceBoardSectionUid = e.GalaxyInterfaceBoardSectionUid;
            this.GalaxyInterfaceBoardUid = e.GalaxyInterfaceBoardUid;
            this.InterfaceBoardSectionModeUid = e.InterfaceBoardSectionModeUid;
            this.SectionNumber = e.SectionNumber;
            this.IsSectionActive = e.IsSectionActive;
            this.IsDirty = e.IsDirty;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.GalaxyHardwareModules = e.GalaxyHardwareModules.ToCollection();

            this.ClusterNumber = e.ClusterNumber;
            this.PanelNumber = e.PanelNumber;
            this.BoardNumber = e.BoardNumber;
            this.ClusterGroupId = e.ClusterGroupId;
        }


        public bool IsAnythingDirty
        {
            get
            {
                foreach (var o in GalaxyHardwareModules)
                {
                    if (o.IsAnythingDirty == true)
                        return true;
                }
                return IsDirty;
            }
        }

        public GalaxyInterfaceBoardSection Clone(GalaxyInterfaceBoardSection e)
        {
            return new GalaxyInterfaceBoardSection(e);
        }

        public bool Equals(GalaxyInterfaceBoardSection other)
        {

            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyInterfaceBoardSection other)
        {
            if (other == null)
                return false;

            if (other.GalaxyInterfaceBoardSectionUid != this.GalaxyInterfaceBoardSectionUid)
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
