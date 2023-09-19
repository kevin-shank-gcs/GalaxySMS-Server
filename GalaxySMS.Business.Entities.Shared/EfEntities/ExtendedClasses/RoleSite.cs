using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
    namespace GalaxySMS.Business.Entities.NetStd2
#else
    namespace GalaxySMS.Business.Entities
#endif
{
    public partial class RoleSite
    {
        public RoleSite()
        {
            Initialize();
        }

        public RoleSite(RoleSite e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.RoleSitePermissions = new HashSet<RoleSitePermission>();
            this.Clusters = new HashSet<RoleCluster>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(RoleSite e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.RoleSiteUid = e.RoleSiteUid;
            this.RoleId = e.RoleId;
            this.SiteUid = e.SiteUid;
            this.IncludeAllClusters = e.IncludeAllClusters;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.RoleSitePermissions = e.RoleSitePermissions.ToCollection();
            if (e.Clusters != null)
                this.Clusters = e.Clusters.ToCollection();
            this.SiteName = e.SiteName;
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

        public RoleSite Clone(RoleSite e)
        {
            return new RoleSite(e);
        }

        public bool Equals(RoleSite other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(RoleSite other)
        {
            if (other == null)
                return false;

            if (other.RoleSiteUid != this.RoleSiteUid)
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
        public string SiteName { get; set; }

    }
}
