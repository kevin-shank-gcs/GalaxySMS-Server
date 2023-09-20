using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class UserDefinedNumberPropertyRule
    {
        public UserDefinedNumberPropertyRule()
        {
            Initialize();
        }

        public UserDefinedNumberPropertyRule(UserDefinedNumberPropertyRule e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(UserDefinedNumberPropertyRule e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;

            this.UserDefinedPropertyUid = e.UserDefinedPropertyUid;
            this.IsRequired = e.IsRequired;
            this.MinimumValue = e.MinimumValue;
            this.MaximumValue = e.MaximumValue;
            this.ValidationRegEx = e.ValidationRegEx;
            this.DefaultValue = e.DefaultValue;
            this.EmptyContent = e.EmptyContent;
            this.ValidationErrorMessage = e.ValidationErrorMessage;
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

        public UserDefinedNumberPropertyRule Clone(UserDefinedNumberPropertyRule e)
        {
            return new UserDefinedNumberPropertyRule(e);
        }

        public bool Equals(UserDefinedNumberPropertyRule other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(UserDefinedNumberPropertyRule other)
        {
            if (other == null)
                return false;

            if (other.UserDefinedPropertyUid != this.UserDefinedPropertyUid)
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
