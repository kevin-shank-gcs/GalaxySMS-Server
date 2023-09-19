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
    public partial class gcsUserEntityRole
    {
        public gcsUserEntityRole()
        {
            Initialize();
        }

        public gcsUserEntityRole(gcsUserEntityRole e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsUserEntityRole e)
        {
            Initialize();
            if (e == null)
                return;
            
            this.IsDirty = e.IsDirty;
            this.UserEntityRoleId = e.UserEntityRoleId;
            this.UserEntityId = e.UserEntityId;
            this.RoleId = e.RoleId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.RoleName = e.RoleName;
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

        public gcsUserEntityRole Clone(gcsUserEntityRole e)
        {
            return new gcsUserEntityRole(e);
        }

        public bool Equals(gcsUserEntityRole other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsUserEntityRole other)
        {
            if (other == null)
                return false;

            if (other.UserEntityRoleId != this.UserEntityRoleId)
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
        public string RoleName { get; set; }
    }
}
