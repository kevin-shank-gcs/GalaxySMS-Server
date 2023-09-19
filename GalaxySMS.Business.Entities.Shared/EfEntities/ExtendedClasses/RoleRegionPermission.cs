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
    public partial class RoleRegionPermission
    {
        public RoleRegionPermission()
        {
            Initialize();
        }

        public RoleRegionPermission(RoleRegionPermission e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(RoleRegionPermission e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.RoleRegionPermissionUid = e.RoleRegionPermissionUid;
            this.RoleRegionUid = e.RoleRegionUid;
            this.PermissionId = e.PermissionId;
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

        public RoleRegionPermission Clone(RoleRegionPermission e)
        {
            return new RoleRegionPermission(e);
        }

        public bool Equals(RoleRegionPermission other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(RoleRegionPermission other)
        {
            if (other == null)
                return false;

            if (other.RoleRegionPermissionUid != this.RoleRegionPermissionUid)
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
