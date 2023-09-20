using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class UserDefinedListPropertyRule
    {
        public UserDefinedListPropertyRule()
        {
            Initialize();
        }

        public UserDefinedListPropertyRule(UserDefinedListPropertyRule e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(UserDefinedListPropertyRule e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.UserDefinedPropertyUid = e.UserDefinedPropertyUid;
            this.AllowMultipleSelections = e.AllowMultipleSelections;
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

        public UserDefinedListPropertyRule Clone(UserDefinedListPropertyRule e)
        {
            return new UserDefinedListPropertyRule(e);
        }

        public bool Equals(UserDefinedListPropertyRule other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(UserDefinedListPropertyRule other)
        {
            if (other == null)
                return false;

            if (other.UserDefinedProperty != this.UserDefinedProperty)
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
