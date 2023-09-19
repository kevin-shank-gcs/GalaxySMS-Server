using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessPortalTypeFeatureMap
    {
        public AccessPortalTypeFeatureMap()
        {
            Initialize();
        }

        public AccessPortalTypeFeatureMap(AccessPortalTypeFeatureMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(AccessPortalTypeFeatureMap e)
        {
            Initialize();
            if (e == null)
                return;
            this.AccessPortalTypeFeatureMapUid = e.AccessPortalTypeFeatureMapUid;
            this.AccessPortalTypeUid = e.AccessPortalTypeUid;
            this.FeatureUid = e.FeatureUid;
            this.IsSupported = e.IsSupported;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public AccessPortalTypeFeatureMap Clone(AccessPortalTypeFeatureMap e)
        {
            return new AccessPortalTypeFeatureMap(e);
        }

        public bool Equals(AccessPortalTypeFeatureMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalTypeFeatureMap other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalTypeFeatureMapUid != this.AccessPortalTypeFeatureMapUid)
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
