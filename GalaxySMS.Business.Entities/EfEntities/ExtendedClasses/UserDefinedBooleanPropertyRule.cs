using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class UserDefinedBooleanPropertyRule
    {
        public UserDefinedBooleanPropertyRule()
        {
            Initialize();
        }

        public UserDefinedBooleanPropertyRule(UserDefinedBooleanPropertyRule e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(UserDefinedBooleanPropertyRule e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.UserDefinedPropertyUid = e.UserDefinedPropertyUid;
            this.CanBeIndeterminate = e.CanBeIndeterminate;
            this.TrueDisplay = e.TrueDisplay;
            this.TrueDisplayResourceKey = e.TrueDisplayResourceKey;
            this.TrueDescription = e.TrueDescription;
            this.TrueDescriptionResourceKey = e.TrueDescriptionResourceKey;
            this.FalseDisplay = e.FalseDisplay;
            this.FalseDisplayResourceKey = e.FalseDisplayResourceKey;
            this.FalseDescription = e.FalseDescription;
            this.FalseDescriptionResourceKey = e.FalseDescriptionResourceKey;
            this.IndeterminateDisplay = e.IndeterminateDisplay;
            this.IndeterminateDisplayResourceKey = e.IndeterminateDisplayResourceKey;
            this.IndeterminateDescription = e.IndeterminateDescription;
            this.IndeterminateDescriptionResourceKey = e.IndeterminateDescriptionResourceKey;
            this.DefaultValue = e.DefaultValue;
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

        public UserDefinedBooleanPropertyRule Clone(UserDefinedBooleanPropertyRule e)
        {
            return new UserDefinedBooleanPropertyRule(e);
        }

        public bool Equals(UserDefinedBooleanPropertyRule other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(UserDefinedBooleanPropertyRule other)
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
