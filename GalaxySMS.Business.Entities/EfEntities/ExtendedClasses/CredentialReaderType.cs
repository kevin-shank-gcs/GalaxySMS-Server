using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class CredentialReaderType
    {
        public CredentialReaderType()
        {
            Initialize();
        }

        public CredentialReaderType(CredentialReaderType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.CredentialReaderTypeFeatureMaps = new HashSet<CredentialReaderTypeFeatureMap>();
        }

        public void Initialize(CredentialReaderType e)
        {
            Initialize();
            if (e == null)
                return;
            this.CredentialReaderTypeUid = e.CredentialReaderTypeUid;
            this.CredentialReaderDataFormatUid = e.CredentialReaderDataFormatUid;
            this.BrandUid = e.BrandUid;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.ReaderTypeName = e.ReaderTypeName;
            this.Model = e.Model;
            this.Description = e.Description;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.CredentialReaderTypeFeatureMaps = e.CredentialReaderTypeFeatureMaps.ToCollection();

        }

        public CredentialReaderType Clone(CredentialReaderType e)
        {
            return new CredentialReaderType(e);
        }

        public bool Equals(CredentialReaderType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(CredentialReaderType other)
        {
            if (other == null)
                return false;

            if (other.CredentialReaderTypeUid != this.CredentialReaderTypeUid)
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
