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
	public partial class AutomaticForgivePassbackFrequency
    {
        public AutomaticForgivePassbackFrequency()
        {
            Initialize();
        }

        public AutomaticForgivePassbackFrequency(AutomaticForgivePassbackFrequency e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(AutomaticForgivePassbackFrequency e)
        {
            Initialize();
            if (e == null)
                return;
            this.AutomaticForgivePassbackFrequencyUid = e.AutomaticForgivePassbackFrequencyUid;
            this.Code = e.Code;
            this.DisplayOrder = e.DisplayOrder;
            this.IsDefault = e.IsDefault;
            this.IsActive = e.IsActive;
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

        public AutomaticForgivePassbackFrequency Clone(AutomaticForgivePassbackFrequency e)
        {
            return new AutomaticForgivePassbackFrequency(e);
        }

        public bool Equals(AutomaticForgivePassbackFrequency other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AutomaticForgivePassbackFrequency other)
        {
            if (other == null)
                return false;

            if (other.AutomaticForgivePassbackFrequencyUid != this.AutomaticForgivePassbackFrequencyUid)
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
