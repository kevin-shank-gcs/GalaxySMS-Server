using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
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
            this.gcsUserEntityApplicationRoles = new HashSet<gcsUserEntityApplicationRole>();
            //this.ApplicationsPermittedToEntity = new HashSet<gcsApplication>();
            //this.ApplicationsAuthorizedForUser = new HashSet<gcsApplication>();
            //this.ApplicationsNotAuthorizedForUser = new HashSet<gcsApplication>();
        }

        public void Initialize(gcsUserEntity e)
        {
            Initialize();
            if (e == null)
                return;
            this.UserEntityId = e.UserEntityId;
            this.UserId = e.UserId;
            this.EntityId = e.EntityId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.gcsUserEntityApplicationRoles = e.gcsUserEntityApplicationRoles.ToCollection();

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

        //public virtual ICollection<gcsApplication> ApplicationsPermittedToEntity { get; set; }
        //public virtual ICollection<gcsApplication> ApplicationsAuthorizedForUser { get; set; }
        //public virtual ICollection<gcsApplication> ApplicationsNotAuthorizedForUser { get; set; }
    }
}