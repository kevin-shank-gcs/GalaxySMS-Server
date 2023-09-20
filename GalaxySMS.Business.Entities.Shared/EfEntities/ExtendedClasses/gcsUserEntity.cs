using System;
using System.Collections;
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
	public partial class gcsUserEntity
    {

        public gcsUserEntity()
        {
            Initialize();
        }

        public gcsUserEntity(gcsUserEntity e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.UserEntityRoles = new HashSet<gcsUserEntityRole>();
            //this.ApplicationsPermittedToEntity = new HashSet<gcsApplication>();
            //this.ApplicationsAuthorizedForUser = new HashSet<gcsApplication>();
            //this.ApplicationsNotAuthorizedForUser = new HashSet<gcsApplication>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsUserEntity e)
        {
            Initialize();
            if (e == null)
                return;
            this.UserEntityId = e.UserEntityId;
            this.UserId = e.UserId;
            this.EntityId = e.EntityId;
            this.IsAdministrator =  e.IsAdministrator;
            this.InheritParentRoles = e.InheritParentRoles;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.UserEntityRoles = e.UserEntityRoles.ToCollection();
            this.EntityName = e.EntityName;
            //this.ApplicationsPermittedToEntity = e.ApplicationsPermittedToEntity.ToCollection();
            //this.ApplicationsAuthorizedForUser = e.ApplicationsAuthorizedForUser.ToCollection();
            //this.ApplicationsNotAuthorizedForUser = e.ApplicationsNotAuthorizedForUser.ToCollection();

        }

        public gcsUserEntity Clone(gcsUserEntity e)
        {
            return new gcsUserEntity(e);
        }

        public bool Equals(gcsUserEntity other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsUserEntity other)
        {
            if (other == null)
                return false;

            if (other.UserEntityId != this.UserEntityId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string EntityName { get; set; }


    }
}