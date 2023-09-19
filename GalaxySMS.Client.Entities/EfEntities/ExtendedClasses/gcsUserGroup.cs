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
    public partial class gcsUserGroup
    {
        public gcsUserGroup() : base()
        {
            Initialize();
        }

        public gcsUserGroup(gcsUserGroup e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
            this.gcsUserGroupEntities = new HashSet<gcsUserGroupEntity>();
            this.gcsUserUserGroups = new HashSet<gcsUserUserGroup>();
        }

        public void Initialize(gcsUserGroup e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
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
