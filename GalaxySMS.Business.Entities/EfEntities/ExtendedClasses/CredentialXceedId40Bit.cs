using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class CredentialXceedId40Bit
    {
        public CredentialXceedId40Bit()
        {
            Initialize();
        }

        public CredentialXceedId40Bit(CredentialXceedId40Bit e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(CredentialXceedId40Bit e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.CredentialUid = e.CredentialUid;
            this.SiteCode = e.SiteCode;
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

        public CredentialXceedId40Bit Clone(CredentialXceedId40Bit e)
        {
            return new CredentialXceedId40Bit(e);
        }

        public bool Equals(CredentialXceedId40Bit other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(CredentialXceedId40Bit other)
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
