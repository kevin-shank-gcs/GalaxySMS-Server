using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class gcsResourceStringLanguage
    {
        public gcsResourceStringLanguage()
        {
            Initialize();
        }

        public gcsResourceStringLanguage(gcsResourceStringLanguage e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(gcsResourceStringLanguage e)
        {
            Initialize();
            if (e == null)
                return;
            this.ResourceStringLanguageId = e.ResourceStringLanguageId;
            this.ResourceId = e.ResourceId;
            this.LanguageId = e.LanguageId;
            this.StringValue = e.StringValue;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public gcsResourceStringLanguage Clone(gcsResourceStringLanguage e)
        {
            return new gcsResourceStringLanguage(e);
        }

        public bool Equals(gcsResourceStringLanguage other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsResourceStringLanguage other)
        {
            if (other == null)
                return false;

            if (other.ResourceStringLanguageId != this.ResourceStringLanguageId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
