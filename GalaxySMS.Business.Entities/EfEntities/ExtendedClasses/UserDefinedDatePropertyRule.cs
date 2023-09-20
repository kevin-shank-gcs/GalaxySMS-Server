using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class UserDefinedDatePropertyRule
    {
        public UserDefinedDatePropertyRule()
        {
            Initialize();
        }

        public UserDefinedDatePropertyRule(UserDefinedDatePropertyRule e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(UserDefinedDatePropertyRule e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;

            this.UserDefinedPropertyUid = e.UserDefinedPropertyUid;
            this.AllowNull = e.AllowNull;
            this.DefaultOffsetFromNow = e.DefaultOffsetFromNow;
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

        public UserDefinedDatePropertyRule Clone(UserDefinedDatePropertyRule e)
        {
            return new UserDefinedDatePropertyRule(e);
        }

        public bool Equals(UserDefinedDatePropertyRule other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(UserDefinedDatePropertyRule other)
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
