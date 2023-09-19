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
	public partial class CredentialReaderTypeFeatureMap
    {
        public CredentialReaderTypeFeatureMap()
        {
            Initialize();
        }

        public CredentialReaderTypeFeatureMap(CredentialReaderTypeFeatureMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(CredentialReaderTypeFeatureMap e)
        {
            Initialize();
            if (e == null)
                return;
            this.CredentialReaderTypeFeatureMapUid = e.CredentialReaderTypeFeatureMapUid;
            this.CredentialReaderTypeUid = e.CredentialReaderTypeUid;
            this.FeatureUid = e.FeatureUid;
            this.IsSupported = e.IsSupported;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public CredentialReaderTypeFeatureMap Clone(CredentialReaderTypeFeatureMap e)
        {
            return new CredentialReaderTypeFeatureMap(e);
        }

        public bool Equals(CredentialReaderTypeFeatureMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(CredentialReaderTypeFeatureMap other)
        {
            if (other == null)
                return false;

            if (other.CredentialReaderTypeFeatureMapUid != this.CredentialReaderTypeFeatureMapUid)
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
