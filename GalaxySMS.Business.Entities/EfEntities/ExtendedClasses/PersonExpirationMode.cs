using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class PersonExpirationMode
    {
        public PersonExpirationMode()
        {
            Initialize();
        }

        public PersonExpirationMode(PersonExpirationMode e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(PersonExpirationMode e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonExpirationModeUid = e.PersonExpirationModeUid;
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

        public PersonExpirationMode Clone(PersonExpirationMode e)
        {
            return new PersonExpirationMode(e);
        }

        public bool Equals(PersonExpirationMode other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonExpirationMode other)
        {
            if (other == null)
                return false;

            if (other.PersonExpirationModeUid != this.PersonExpirationModeUid)
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
