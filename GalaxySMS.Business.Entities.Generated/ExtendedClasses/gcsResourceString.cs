using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class gcsResourceString
    {
        public gcsResourceString()
        {
            Initialize();
        }

        public gcsResourceString(gcsResourceString e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(gcsResourceString e)
        {
            Initialize();
            if (e == null)
                return;
            this.ResourceId = e.ResourceId;
            this.ResourceName = e.ResourceName;
            this.ResourceNumber = e.ResourceNumber;
            this.ResourceClassName = e.ResourceClassName;
            this.DefaultValue = e.DefaultValue;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public gcsResourceString Clone(gcsResourceString e)
        {
            return new gcsResourceString(e);
        }

        public bool Equals(gcsResourceString other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsResourceString other)
        {
            if (other == null)
                return false;

            if (other.ResourceId != this.ResourceId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
