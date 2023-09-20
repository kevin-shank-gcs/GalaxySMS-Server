
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyInterfaceBoard
    {
        public GalaxyInterfaceBoard()
        {
            Initialize();
        }

        public GalaxyInterfaceBoard(GalaxyInterfaceBoard e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.InterfaceBoardSections = new HashSet<GalaxyInterfaceBoardSection>();
        }

        public void Initialize(GalaxyInterfaceBoard e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyInterfaceBoardUid = e.GalaxyInterfaceBoardUid;
            this.GalaxyPanelUid = e.GalaxyPanelUid;
            this.InterfaceBoardTypeUid = e.InterfaceBoardTypeUid;
            this.BoardNumber = e.BoardNumber;
            this.IsDirty = e.IsDirty;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

            if (e.InterfaceBoardSections != null)
                this.InterfaceBoardSections = e.InterfaceBoardSections.ToCollection();

            this.ClusterNumber = e.ClusterNumber;
            this.PanelNumber = e.PanelNumber;
        }

        public GalaxyInterfaceBoard Clone(GalaxyInterfaceBoard e)
        {
            return new GalaxyInterfaceBoard(e);
        }

        public bool IsAnythingDirty
        {
            get
            {
                foreach( var o in InterfaceBoardSections)
                {
                    if (o.IsAnythingDirty == true)
                        return true;
                }
                return IsDirty;                
            }
        }

        public bool Equals(GalaxyInterfaceBoard other)
        {
            //if (this.BoardNumber != other.BoardNumber ||
            //    this.GalaxyInterfaceBoardUid != other.GalaxyInterfaceBoardUid ||
            //    this.GalaxyPanelUid != other.GalaxyPanelUid ||
            //    this.InterfaceBoardTypeUid != other.InterfaceBoardTypeUid)
            //    return false;
            //return true;
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyInterfaceBoard other)
        {
            if (other == null)
                return false;

            if (other.GalaxyInterfaceBoardUid != this.GalaxyInterfaceBoardUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
