using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Extensions;


#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class AccessGroup_PanelLoadDataChanges
    {
        public AccessGroup_PanelLoadDataChanges() : base()
        {
            Initialize();
        }

        public AccessGroup_PanelLoadDataChanges(AccessGroup_PanelLoadDataChanges e) :base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(AccessGroup_PanelLoadDataChanges e)
        {
            Initialize();
            if (e == null)
                return;

            if (e.AccessGroupData != null)
                this.AccessGroupData = e.AccessGroupData.ToCollection();
            this.CurrentTimeForCluster = e.CurrentTimeForCluster;
            this.PanelNumber = e.PanelNumber;
            this.GalaxyPanelUid = e.GalaxyPanelUid;
            this.CpuNumber = e.CpuNumber;
            this.CpuUid = e.CpuUid;
            this.AccessGroupLoadToCpuUid = e.AccessGroupLoadToCpuUid;
        }

        public AccessGroup_PanelLoadDataChanges Clone(AccessGroup_PanelLoadDataChanges e)
        {
            return new AccessGroup_PanelLoadDataChanges(e);
        }

        public bool Equals(AccessGroup_PanelLoadDataChanges other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessGroup_PanelLoadDataChanges other)
        {
            if (other == null)
                return false;

            if (other.AccessGroupLoadToCpuUid != this.AccessGroupLoadToCpuUid)
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
