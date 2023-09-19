using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class CredentialReaderDataFormat
    {
        public CredentialReaderDataFormat()
        {
            Initialize();
        }

        public CredentialReaderDataFormat(CredentialReaderDataFormat e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.CredentialReaderTypes = new HashSet<CredentialReaderType>();
        }

        public void Initialize(CredentialReaderDataFormat e)
        {
            Initialize();
            if (e == null)
                return;
            this.CredentialReaderDataFormatUid = e.CredentialReaderDataFormatUid;
            this.DataFormatName = e.DataFormatName;
            this.PanelDataFormatCode = e.PanelDataFormatCode;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.CredentialReaderTypes = e.CredentialReaderTypes.ToCollection();

        }

        public CredentialReaderDataFormat Clone(CredentialReaderDataFormat e)
        {
            return new CredentialReaderDataFormat(e);
        }

        public bool Equals(CredentialReaderDataFormat other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(CredentialReaderDataFormat other)
        {
            if (other == null)
                return false;

            if (other.CredentialReaderDataFormatUid != this.CredentialReaderDataFormatUid)
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
