using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class gcsLanguage
    {
        public gcsLanguage()
        {
            Initialize();
        }

        public gcsLanguage(gcsLanguage e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.gcsUsers = new HashSet<gcsUser>();
        }

        public void Initialize(gcsLanguage e)
        {
            Initialize();
            if (e == null)
                return;
            this.LanguageId = e.LanguageId;
            this.CultureName = e.CultureName;
            this.LanguageName = e.LanguageName;
            this.Description = e.Description;
            this.Notes = e.Notes;
            this.IsActive = e.IsActive;
            this.IsDisplay = e.IsDisplay;
            this.IsDefault = e.IsDefault;
            this.FlagImage = e.FlagImage;
            this.DisplayOrder = e.DisplayOrder;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.gcsUsers = e.gcsUsers.ToCollection();

        }

        public gcsLanguage Clone(gcsLanguage e)
        {
            return new gcsLanguage(e);
        }

        public bool Equals(gcsLanguage other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsLanguage other)
        {
            if (other == null)
                return false;

            if (other.LanguageId != this.LanguageId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
