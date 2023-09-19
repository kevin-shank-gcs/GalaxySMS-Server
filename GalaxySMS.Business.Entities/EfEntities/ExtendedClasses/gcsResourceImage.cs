using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class gcsResourceImage
    {
        public gcsResourceImage()
        {
            Initialize();
        }

        public gcsResourceImage(gcsResourceImage e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(gcsResourceImage e)
        {
            Initialize();
            if (e == null)
                return;
            this.ResourceImageId = e.ResourceImageId;
            this.ResourceName = e.ResourceName;
            this.ResourceNumber = e.ResourceNumber;
            this.ResourceClassName = e.ResourceClassName;
            this.ImageTypeId = e.ImageTypeId;
            this.ImageData = e.ImageData;
            this.ImageUri = e.ImageUri;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public gcsResourceImage Clone(gcsResourceImage e)
        {
            return new gcsResourceImage(e);
        }

        public bool Equals(gcsResourceImage other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsResourceImage other)
        {
            if (other == null)
                return false;

            if (other.ResourceImageId != this.ResourceImageId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}