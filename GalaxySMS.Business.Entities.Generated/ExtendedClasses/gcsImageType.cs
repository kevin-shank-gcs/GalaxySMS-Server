using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class gcsImageType
    {
        public gcsImageType()
        {
            Initialize();
        }

        public gcsImageType(gcsImageType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(gcsImageType e)
        {
            Initialize();
            if (e == null)
                return;
            this.ImageTypeId = e.ImageTypeId;
            this.ImageTypeCode = e.ImageTypeCode;
            this.ImageTypeName = e.ImageTypeName;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public gcsImageType Clone(gcsImageType e)
        {
            return new gcsImageType(e);
        }

        public bool Equals(gcsImageType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsImageType other)
        {
            if (other == null)
                return false;

            if (other.ImageTypeId != this.ImageTypeId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
