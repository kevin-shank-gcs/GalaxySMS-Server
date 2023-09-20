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
	public partial class CredentialDataLength
    {
        public CredentialDataLength()
        {
            Initialize();
        }

        public CredentialDataLength(CredentialDataLength e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(CredentialDataLength e)
        {
            Initialize();
            if (e == null)
                return;
            this.CredentialDataLengthUid = e.CredentialDataLengthUid;
            this.DataLength = e.DataLength;
            this.IsActive = e.IsActive;
   
            // Common table properties
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

            // IHasDisplayResource & IHasDescriptionResource members
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.ResourceClassName = e.ResourceClassName;
            this.UniqueResourceName = e.UniqueResourceName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;
        }

        public CredentialDataLength Clone(CredentialDataLength e)
        {
            return new CredentialDataLength(e);
        }

        public bool Equals(CredentialDataLength other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(CredentialDataLength other)
        {
            if (other == null)
                return false;

            if (other.CredentialDataLengthUid != this.CredentialDataLengthUid)
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
