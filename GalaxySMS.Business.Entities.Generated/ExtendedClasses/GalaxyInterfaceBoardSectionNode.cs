
using System;
using System.Collections.Generic;
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
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public GalaxyInterfaceBoardSectionNode Clone(GalaxyInterfaceBoardSectionNode e)
        {
            return new GalaxyInterfaceBoardSectionNode(e);
        }

        public bool Equals(GalaxyInterfaceBoardSectionNode other)
        {
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
    }
}
