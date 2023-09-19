
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class gcsApplicationSetting
    {
        public gcsApplicationSetting()
        {
            Initialize();
        }

        public gcsApplicationSetting(gcsApplicationSetting e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(gcsApplicationSetting e)
        {
            Initialize();
            if (e == null)
                return;
            this.ApplicationSettingId = e.ApplicationSettingId;
            this.ApplicationId = e.ApplicationId;
            this.SettingKey = e.SettingKey;
            this.SettingValue = e.SettingValue;
            this.SettingDescription = e.SettingDescription;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.Category = e.Category;

        }

        public gcsApplicationSetting Clone(gcsApplicationSetting e)
        {
            return new gcsApplicationSetting(e);
        }

        public bool Equals(gcsApplicationSetting other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsApplicationSetting other)
        {
            if (other == null)
                return false;

            if (other.ApplicationSettingId != this.ApplicationSettingId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
