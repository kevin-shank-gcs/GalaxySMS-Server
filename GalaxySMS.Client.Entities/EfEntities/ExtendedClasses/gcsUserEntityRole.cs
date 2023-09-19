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
    public partial class gcsUserEntityRole
    {
        public gcsUserEntityRole() : base()
        {
            Initialize();
        }

        public gcsUserEntityRole(gcsUserEntityRole e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(gcsUserEntityRole e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
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

        private string _roleName;

        [DataMember]
        public string RoleName
        {
            get { return _roleName; }
            set
            {
                if (_roleName != value)
                {
                    _roleName = value;
                    OnPropertyChanged(() => RoleName, false);
                }
            }
        }

    }
}
