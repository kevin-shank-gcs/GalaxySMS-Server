using System;
using System.Collections.Generic;
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
    public partial class gcsUserEntitySave
    {
        public gcsUserEntitySave()
        {
            Initialize();
        }

        public gcsUserEntitySave(gcsUserEntitySave e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.UserEntityRoles = new HashSet<gcsUserEntityRoleSave>();
            //this.ApplicationsPermittedToEntity = new HashSet<gcsApplication>();
            //this.ApplicationsAuthorizedForUser = new HashSet<gcsApplication>();
            //this.ApplicationsNotAuthorizedForUser = new HashSet<gcsApplication>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsUserEntitySave e)
        {
            Initialize();
            if (e == null)
                return;
            //this.UserEntityId = e.UserEntityId;
            //this.UserId = e.UserId;
            this.EntityId = e.EntityId;
            this.IsAdministrator = e.IsAdministrator;
            this.InheritParentRoles = e.InheritParentRoles;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.UserEntityRoles = e.UserEntityRoles.ToCollection();

            //this.ApplicationsPermittedToEntity = e.ApplicationsPermittedToEntity.ToCollection();
            //this.ApplicationsAuthorizedForUser = e.ApplicationsAuthorizedForUser.ToCollection();
            //this.ApplicationsNotAuthorizedForUser = e.ApplicationsNotAuthorizedForUser.ToCollection();

        }

        public gcsUserEntitySave Clone(gcsUserEntitySave e)
        {
            return new gcsUserEntitySave(e);
        }

        public bool Equals(gcsUserEntitySave other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsUserEntitySave other)
        {
            if (other == null)
                return false;

            if (other.EntityId != this.EntityId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }

}