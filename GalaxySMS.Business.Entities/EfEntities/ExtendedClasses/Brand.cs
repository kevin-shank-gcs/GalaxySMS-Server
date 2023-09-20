using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class Brand
    {
        public Brand()
        {
            Initialize();
        }

        public Brand(Brand e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(Brand e)
        {
            Initialize();
            if (e == null)
                return;
            this.BrandUid = e.BrandUid;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.BrandName = e.BrandName;
            this.CompanyName = e.CompanyName;
            this.Category = e.Category;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);

        }

        public Brand Clone(Brand e)
        {
            return new Brand(e);
        }

        public bool Equals(Brand other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(Brand other)
        {
            if (other == null)
                return false;

            if (other.BrandUid != this.BrandUid)
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