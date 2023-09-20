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
	public partial class AccessPortalType
    {
        public AccessPortalType()
        {
            Initialize();
        }

        public AccessPortalType(AccessPortalType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(AccessPortalType e)
        {
            Initialize();
            if (e == null)
                return;
            this.AccessPortalTypeUid = e.AccessPortalTypeUid;
            this.CredentialReaderTypeUid = e.CredentialReaderTypeUid;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.AccessPortalTypeDescription = e.AccessPortalTypeDescription;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public AccessPortalType Clone(AccessPortalType e)
        {
            return new AccessPortalType(e);
        }

        public bool Equals(AccessPortalType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalType other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalTypeUid != this.AccessPortalTypeUid)
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
