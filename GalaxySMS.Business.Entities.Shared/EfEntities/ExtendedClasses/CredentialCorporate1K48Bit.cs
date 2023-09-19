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
	public partial class CredentialCorporate1K48Bit
    {
        public CredentialCorporate1K48Bit()
        {
            Initialize();
        }

        public CredentialCorporate1K48Bit(CredentialCorporate1K48Bit e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(CredentialCorporate1K48Bit e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.CredentialUid = e.CredentialUid;
            this.CompanyCode = e.CompanyCode;
            this.IdCode = e.IdCode;
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

        public CredentialCorporate1K48Bit Clone(CredentialCorporate1K48Bit e)
        {
            return new CredentialCorporate1K48Bit(e);
        }

        public bool Equals(CredentialCorporate1K48Bit other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(CredentialCorporate1K48Bit other)
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
