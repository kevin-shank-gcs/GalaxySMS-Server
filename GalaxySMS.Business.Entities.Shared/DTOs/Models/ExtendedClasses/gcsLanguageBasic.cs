using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
	public partial class gcsLanguageBasic
    {
        public gcsLanguageBasic()
        {
            Initialize();
        }

        public gcsLanguageBasic(gcsLanguage e)
        {
            Initialize(e);
        }
        public gcsLanguageBasic(gcsLanguageBasic e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(gcsLanguageBasic e)
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
 //           this.ConcurrencyValue = e.ConcurrencyValue;
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
            //           this.ConcurrencyValue = e.ConcurrencyValue;
        }

        public gcsLanguageBasic Clone(gcsLanguageBasic e)
        {
            return new gcsLanguageBasic(e);
        }

        public bool Equals(gcsLanguageBasic other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsLanguageBasic other)
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
