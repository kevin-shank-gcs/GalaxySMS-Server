using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class gcsSetting
    {
        public gcsSetting()
        {
            Initialize();
        }

        public gcsSetting(gcsSetting e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(gcsSetting e)
        {
            Initialize();
            if (e == null)
                return;
            this.SettingId = e.SettingId;
            this.SettingGroup = e.SettingGroup;
            this.SettingSubGroup = e.SettingSubGroup;
            this.SettingKey = e.SettingKey;
            this.Value = e.Value;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public gcsSetting Clone(gcsSetting e)
        {
            return new gcsSetting(e);
        }

        public bool Equals(gcsSetting other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsSetting other)
        {
            if (other == null)
                return false;

            if (other.SettingId != this.SettingId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
