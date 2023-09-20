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
	public partial class gcsPermissionCategoryBasic
    {
        public gcsPermissionCategoryBasic()
        {
            Initialize();
        }

        public gcsPermissionCategoryBasic(gcsPermissionCategory e)
        {
            Initialize(e);
        }
        public gcsPermissionCategoryBasic(gcsPermissionCategoryBasic e)
        {
            Initialize(e);
        }


        public void Initialize()
        {
            this.Permissions = new HashSet<gcsPermissionBasic>();
        }

        public void Initialize(gcsPermissionCategory e)
        {
            Initialize();
            if (e == null)
                return;
            this.ApplicationId = e.ApplicationId;
            this.CategoryName = e.CategoryName;
            this.IsEntityCategory = e.IsEntityCategory;
            this.IsSystemCategory = e.IsSystemCategory;
            this.PermissionCategoryDescription = e.PermissionCategoryDescription;
            this.PermissionCategoryId = e.PermissionCategoryId;
            if( e.Permissions != null)
            {
                foreach( var p in e.Permissions)
                {
                    this.Permissions.Add(new gcsPermissionBasic(p));
                }
            }
        }
        public void Initialize(gcsPermissionCategoryBasic e)
        {
            Initialize();
            if (e == null)
                return;
            this.ApplicationId = e.ApplicationId;
            this.CategoryName = e.CategoryName;
            this.IsEntityCategory = e.IsEntityCategory;
            this.IsSystemCategory = e.IsSystemCategory;
            this.PermissionCategoryDescription = e.PermissionCategoryDescription;
            this.PermissionCategoryId = e.PermissionCategoryId;
            if( e.Permissions != null)
            {
                this.Permissions = e.Permissions.ToCollection();
            }
        }

        public gcsPermissionCategoryBasic Clone(gcsPermissionCategoryBasic e)
        {
            return new gcsPermissionCategoryBasic(e);
        }

        public bool Equals(gcsPermissionCategoryBasic other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsPermissionCategoryBasic other)
        {
            if (other == null)
                return false;

            if (other.PermissionCategoryId != this.PermissionCategoryId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return CategoryName;
        }


    }
}
