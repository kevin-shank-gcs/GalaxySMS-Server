
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
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

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
    }
}
