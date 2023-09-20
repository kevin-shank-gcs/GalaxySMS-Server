
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif
    public partial class RoleSitePermission
    {
        public RoleSitePermission()
        {
            Initialize();
        }

        public RoleSitePermission(RoleSitePermission e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(RoleSitePermission e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.RoleSitePermissionUid = e.RoleSitePermissionUid;
            this.RoleSiteUid = e.RoleSiteUid;
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

        public RoleSitePermission Clone(RoleSitePermission e)
        {
            return new RoleSitePermission(e);
        }

        public bool Equals(RoleSitePermission other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(RoleSitePermission other)
        {
            if (other == null)
                return false;

            if (other.RoleSitePermissionUid != this.RoleSitePermissionUid)
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
