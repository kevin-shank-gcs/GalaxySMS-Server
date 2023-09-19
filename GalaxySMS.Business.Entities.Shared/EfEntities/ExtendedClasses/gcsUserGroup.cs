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
    public partial class gcsUserGroup
    {
        public gcsUserGroup()
        {
            Initialize();
        }

        public gcsUserGroup(gcsUserGroup e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.gcsUserGroupEntities = new HashSet<gcsUserGroupEntity>();
            this.gcsUserUserGroups = new HashSet<gcsUserUserGroup>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsUserGroup e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.UserGroupId = e.UserGroupId;
            this.Name = e.Name;
            this.Description = e.Description;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.gcsUserGroupEntities = e.gcsUserGroupEntities.ToCollection();
            this.gcsUserUserGroups = e.gcsUserUserGroups.ToCollection();

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

        public gcsUserGroup Clone(gcsUserGroup e)
        {
            return new gcsUserGroup(e);
        }

        public bool Equals(gcsUserGroup other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsUserGroup other)
        {
            if (other == null)
                return false;

            if (other.UserGroupId != this.UserGroupId)
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
