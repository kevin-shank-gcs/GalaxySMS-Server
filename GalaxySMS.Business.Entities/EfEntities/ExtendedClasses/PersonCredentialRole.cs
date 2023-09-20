using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class PersonCredentialRole
    {
        public PersonCredentialRole()
        {
            Initialize();
        }

        public PersonCredentialRole(PersonCredentialRole e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(PersonCredentialRole e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonCredentialRoleUid = e.PersonCredentialRoleUid;
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.Code = e.Code;
            this.DisplayOrder = e.DisplayOrder;
            this.IsDefault = e.IsDefault;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

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

        public PersonCredentialRole Clone(PersonCredentialRole e)
        {
            return new PersonCredentialRole(e);
        }

        public bool Equals(PersonCredentialRole other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonCredentialRole other)
        {
            if (other == null)
                return false;

            if (other.PersonCredentialRoleUid != this.PersonCredentialRoleUid)
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
