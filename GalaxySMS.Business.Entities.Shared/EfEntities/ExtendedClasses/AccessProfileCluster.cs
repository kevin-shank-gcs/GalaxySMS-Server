using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
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
            this.AccessProfileAccessGroups = new HashSet<AccessProfileAccessGroup>();
            this.AccessProfileInputOutputGroups = new HashSet<AccessProfileInputOutputGroup>();
            this.ConcurrencyValue = 0;
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
            if (e.AccessProfileAccessGroups != null)
                this.AccessProfileAccessGroups = e.AccessProfileAccessGroups.ToCollection();
            if (e.AccessProfileInputOutputGroups != null)
                this.AccessProfileInputOutputGroups = e.AccessProfileInputOutputGroups.ToCollection();

            this.ClusterName = e.ClusterName;
        }

        public bool IsAnythingDirty
        {
            get
            {
                foreach (var o in AccessProfileAccessGroups)
                {
                    if (o.IsAnythingDirty == true)
                        return true;
                }

                foreach (var o in AccessProfileInputOutputGroups)
                {
                    if (o.IsAnythingDirty == true)
                        return true;
                }
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

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ClusterName { get; set; }

    }
}
