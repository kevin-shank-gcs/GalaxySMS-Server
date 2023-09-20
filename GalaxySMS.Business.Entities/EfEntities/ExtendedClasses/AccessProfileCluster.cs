using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessProfileCluster
    {
        public AccessProfileCluster()
        {
            Initialize();
        }

        public AccessProfileCluster(AccessProfileCluster e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(AccessProfileCluster e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessProfileClusterUid = e.AccessProfileClusterUid;
            this.AccessProfileUid = e.AccessProfileUid;
            this.ClusterUid = e.ClusterUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public bool IsAnythingDirty
        {
            get
            {
                //foreach( var o in InterfaceBoardSections)
                //{
                //	if (o.IsAnythingDirty == true)
                //		return true;
                //}
                return IsDirty;
            }
        }

        public AccessProfileCluster Clone(AccessProfileCluster e)
        {
            return new AccessProfileCluster(e);
        }

        public bool Equals(AccessProfileCluster other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessProfileCluster other)
        {
            if (other == null)
                return false;

            if (other.AccessProfileClusterUid != this.AccessProfileClusterUid)
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
