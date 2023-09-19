using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
	public partial class Feature
    {
        public Feature()
        {
            Initialize();
        }

        public Feature(Feature e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.AccessPortalTypeFeatureMaps = new HashSet<AccessPortalTypeFeatureMap>();
            this.CredentialReaderTypeFeatureMaps = new HashSet<CredentialReaderTypeFeatureMap>();
            this.FeatureItems = new HashSet<FeatureItem>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(Feature e)
        {
            Initialize();
            if (e == null)
                return;
            this.FeatureUid = e.FeatureUid;
            this.CategoryCode = e.CategoryCode;
            this.FeatureCode = e.FeatureCode;
            this.Description = e.Description;
            this.FeatureType = e.FeatureType;
            this.DefaultValue = e.DefaultValue;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.AccessPortalTypeFeatureMaps = e.AccessPortalTypeFeatureMaps.ToCollection();
            this.CredentialReaderTypeFeatureMaps = e.CredentialReaderTypeFeatureMaps.ToCollection();
            this.FeatureItems = e.FeatureItems.ToCollection();

        }

        public Feature Clone(Feature e)
        {
            return new Feature(e);
        }

        public bool Equals(Feature other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(Feature other)
        {
            if (other == null)
                return false;

            if (other.FeatureUid != this.FeatureUid)
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
