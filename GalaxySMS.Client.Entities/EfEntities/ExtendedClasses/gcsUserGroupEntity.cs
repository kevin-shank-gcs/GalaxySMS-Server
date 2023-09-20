using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using GCS.Core.Common.Contracts;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    public partial class gcsUserGroupEntity
    {
        public gcsUserGroupEntity() : base()
        {
            Initialize();
        }

        public gcsUserGroupEntity(gcsUserGroupEntity e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(gcsUserGroupEntity e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.UserGroupEntityId = e.UserGroupEntityId;
            this.UserGroupId = e.UserGroupId;
            this.EntityId = e.EntityId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public gcsUserGroupEntity Clone(gcsUserGroupEntity e)
        {
            return new gcsUserGroupEntity(e);
        }

        public bool Equals(gcsUserGroupEntity other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsUserGroupEntity other)
        {
            if (other == null)
                return false;

            if (other.UserGroupEntityId != this.UserGroupEntityId)
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
