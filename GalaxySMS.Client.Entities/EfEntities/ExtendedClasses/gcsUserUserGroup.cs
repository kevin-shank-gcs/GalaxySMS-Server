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
    public partial class gcsUserUserGroup
    {
        public gcsUserUserGroup() : base()
        {
            Initialize();
        }

        public gcsUserUserGroup(gcsUserUserGroup e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(gcsUserUserGroup e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.UserUserGroupId = e.UserUserGroupId;
            this.UserGroupId = e.UserGroupId;
            this.UserId = e.UserId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public gcsUserUserGroup Clone(gcsUserUserGroup e)
        {
            return new gcsUserUserGroup(e);
        }

        public bool Equals(gcsUserUserGroup other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsUserUserGroup other)
        {
            if (other == null)
                return false;

            if (other.UserUserGroupId != this.UserUserGroupId)
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
