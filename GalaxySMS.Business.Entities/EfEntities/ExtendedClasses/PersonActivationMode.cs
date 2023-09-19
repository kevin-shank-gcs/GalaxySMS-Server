using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class PersonActivationMode
    {
        public PersonActivationMode()
        {
            Initialize();
        }

        public PersonActivationMode(PersonActivationMode e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(PersonActivationMode e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonActivationModeUid = e.PersonActivationModeUid;
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

        public PersonActivationMode Clone(PersonActivationMode e)
        {
            return new PersonActivationMode(e);
        }

        public bool Equals(PersonActivationMode other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonActivationMode other)
        {
            if (other == null)
                return false;

            if (other.PersonActivationModeUid != this.PersonActivationModeUid)
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
