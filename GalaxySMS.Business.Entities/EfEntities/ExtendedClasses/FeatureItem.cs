using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class FeatureItem
    {
        public FeatureItem()
        {
            Initialize();
        }

        public FeatureItem(FeatureItem e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(FeatureItem e)
        {
            Initialize();
            if (e == null)
                return;
            this.FeatureItemUid = e.FeatureItemUid;
            this.FeatureUid = e.FeatureUid;
            this.Value = e.Value;
            this.Code = e.Code;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public FeatureItem Clone(FeatureItem e)
        {
            return new FeatureItem(e);
        }

        public bool Equals(FeatureItem other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(FeatureItem other)
        {
            if (other == null)
                return false;

            if (other.FeatureItemUid != this.FeatureItemUid)
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
