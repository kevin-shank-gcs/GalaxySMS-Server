using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class gcsUserSetting
    {
        public gcsUserSetting()
        {
            Initialize();
        }

        public gcsUserSetting(gcsUserSetting e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(gcsUserSetting e)
        {
            Initialize();
            if (e == null)
                return;
            this.UserSettingId = e.UserSettingId;
            this.UserId = e.UserId;
            this.ApplicationId = e.ApplicationId;
            this.Category = e.Category;
            this.SettingKey = e.SettingKey;
            this.SettingValue = e.SettingValue;
            this.SettingDescription = e.SettingDescription;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public gcsUserSetting Clone(gcsUserSetting e)
        {
            return new gcsUserSetting(e);
        }

        public bool Equals(gcsUserSetting other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsUserSetting other)
        {
            if (other == null)
                return false;

            if (other.UserSettingId != this.UserSettingId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
