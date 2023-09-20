using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class UserDefinedTextPropertyRule
    {
        public UserDefinedTextPropertyRule()
        {
            Initialize();
        }

        public UserDefinedTextPropertyRule(UserDefinedTextPropertyRule e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(UserDefinedTextPropertyRule e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;

            this.UserDefinedPropertyUid = e.UserDefinedPropertyUid;
            this.MinimumLength = e.MinimumLength;
            this.MaximumLength = e.MaximumLength;
            this.MaximumLengthLimit = e.MaximumLengthLimit;
            this.DefaultValue = e.DefaultValue;
            this.Mask = e.Mask;
            this.ValidationRegEx = e.ValidationRegEx;
            this.AllUpperCase = e.AllUpperCase;
            this.FirstCharacterUpperCase = e.FirstCharacterUpperCase;
            this.IsRequired = e.IsRequired;
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

        public UserDefinedTextPropertyRule Clone(UserDefinedTextPropertyRule e)
        {
            return new UserDefinedTextPropertyRule(e);
        }

        public bool Equals(UserDefinedTextPropertyRule other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(UserDefinedTextPropertyRule other)
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
