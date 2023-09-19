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
	public partial class CredentialPIV75Bit
    {
        public CredentialPIV75Bit()
        {
            Initialize();
        }

        public CredentialPIV75Bit(CredentialPIV75Bit e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(CredentialPIV75Bit e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.CredentialUid = e.CredentialUid;
            this.AgencyCode = e.AgencyCode;
            this.SiteCode = e.SiteCode;
            this.CredentialCode = e.CredentialCode;
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

        public CredentialPIV75Bit Clone(CredentialPIV75Bit e)
        {
            return new CredentialPIV75Bit(e);
        }

        public bool Equals(CredentialPIV75Bit other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(CredentialPIV75Bit other)
        {
            if (other == null)
                return false;

            if (other.CredentialUid != this.CredentialUid)
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
