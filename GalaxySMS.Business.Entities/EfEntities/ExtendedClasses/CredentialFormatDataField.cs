using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class CredentialFormatDataField
    {
        public CredentialFormatDataField()
        {
            Initialize();
        }

        public CredentialFormatDataField(CredentialFormatDataField e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(CredentialFormatDataField e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.CredentialFormatDataFieldUid = e.CredentialFormatDataFieldUid;
            this.CredentialFormatUid = e.CredentialFormatUid;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.FieldName = e.FieldName;
            this.Display = e.Display;
            this.Description = e.Description;
            this.StartsAt = e.StartsAt;
            this.BitLength = e.BitLength;
            this.MinimumValue = e.MinimumValue;
            this.MaximumValue = e.MaximumValue;
            this.FieldNumber = e.FieldNumber;
            this.IsReadOnly = e.IsReadOnly;
            this.IsVisible = e.IsVisible;
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

        public CredentialFormatDataField Clone(CredentialFormatDataField e)
        {
            return new CredentialFormatDataField(e);
        }

        public bool Equals(CredentialFormatDataField other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(CredentialFormatDataField other)
        {
            if (other == null)
                return false;

            if (other.CredentialFormatDataFieldUid != this.CredentialFormatDataFieldUid)
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
