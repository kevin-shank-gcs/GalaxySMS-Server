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
    public partial class AccessGroup_PanelLoadData
    {
        public AccessGroup_PanelLoadData()
        {
            Initialize();
        }

        public AccessGroup_PanelLoadData(AccessGroup_PanelLoadData e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            AccessGroupData = new HashSet<AccessGroupAccessPortal_PanelLoadData>();
        }

        public void Initialize(AccessGroup_PanelLoadData e)
        {
            Initialize();
            if (e == null)
                return;

            this.AccessGroupUid = e.AccessGroupUid;
            this.ClusterUid = e.ClusterUid;
            this.AccessGroupName = e.AccessGroupName;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.AccessGroupNumber = e.AccessGroupNumber;
            this.CrisisModeAccessGroupUid = e.CrisisModeAccessGroupUid;
            this.CrisisModeAccessGroupName = e.CrisisModeAccessGroupName;
            this.CrisisModeAccessGroupNumber = e.CrisisModeAccessGroupNumber;
            this.ActivationDate = e.ActivationDate;
            this.ExpirationDate = e.ExpirationDate;
            this.IsEnabled = e.IsEnabled;

            if (e.AccessGroupData != null)
                this.AccessGroupData = e.AccessGroupData.ToCollection();
            this.CurrentTimeForCluster = e.CurrentTimeForCluster;
        }

        public AccessGroup_PanelLoadData Clone(AccessGroup_PanelLoadData e)
        {
            return new AccessGroup_PanelLoadData(e);
        }

        public bool Equals(AccessGroup_PanelLoadData other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessGroup_PanelLoadData other)
        {
            if (other == null)
                return false;

            if (other.AccessGroupUid != this.AccessGroupUid)
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
