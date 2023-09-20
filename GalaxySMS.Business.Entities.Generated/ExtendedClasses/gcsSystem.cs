using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class gcsSystem
    {
        public gcsSystem()
        {
            Initialize();
        }

        public gcsSystem(gcsSystem e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(gcsSystem e)
        {
            Initialize();
            if (e == null)
                return;
            this.SystemId = e.SystemId;
            this.License = e.License;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.SystemName = e.SystemName;
            this.CompanyName = e.CompanyName;
            this.SupportCompany = e.SupportCompany;
            this.SupportContact = e.SupportContact;
            this.SupportPhone = e.SupportPhone;
            this.SupportEmail = e.SupportEmail;
            this.SupportUrl = e.SupportUrl;
            this.SupportImage = e.SupportImage;
            this.SystemImage = e.SystemImage;
            this.LicensePublicKey = e.LicensePublicKey;
        }

        public gcsSystem Clone(gcsSystem e)
        {
            return new gcsSystem(e);
        }

        public bool Equals(gcsSystem other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsSystem other)
        {
            if (other == null)
                return false;

            if (other.SystemId != this.SystemId)
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

        public string LicensePublicKey { get; set; }
    }
}
