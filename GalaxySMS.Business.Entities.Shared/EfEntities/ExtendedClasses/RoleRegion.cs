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
    public partial class RoleRegion
    {
        public RoleRegion()
        {
            Initialize();
        }

        public RoleRegion(RoleRegion e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.RoleRegionPermissions = new HashSet<RoleRegionPermission>();
            this.Sites = new HashSet<RoleSite>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(RoleRegion e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.RoleRegionUid = e.RoleRegionUid;
            this.RoleId = e.RoleId;
            this.RegionUid = e.RegionUid;
            this.IncludeAllSites = e.IncludeAllSites;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.RoleRegionPermissions = e.RoleRegionPermissions.ToCollection();
            this.IncludeAllClusters = e.IncludeAllClusters;
            this.IncludeAllAccessPortals = e.IncludeAllAccessPortals;
            this.IncludeAllInputDevices = e.IncludeAllInputDevices;
            this.IncludeAllOutputDevices = e.IncludeAllOutputDevices;
            this.IncludeAllInputOutputGroups = e.IncludeAllInputOutputGroups;
            if (e.Sites != null)
                this.Sites = e.Sites.ToCollection();
            this.RegionName = e.RegionName;
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

        public RoleRegion Clone(RoleRegion e)
        {
            return new RoleRegion(e);
        }

        public bool Equals(RoleRegion other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(RoleRegion other)
        {
            if (other == null)
                return false;

            if (other.RoleRegionUid != this.RoleRegionUid)
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
        public string RegionName { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Boolean IncludeAllClusters { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Boolean IncludeAllAccessPortals { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Boolean IncludeAllInputDevices { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Boolean IncludeAllOutputDevices { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Boolean IncludeAllInputOutputGroups { get; set; }

    }
}