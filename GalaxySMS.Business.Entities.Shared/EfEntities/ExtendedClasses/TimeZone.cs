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
	public partial class TimeZone
    {
        public TimeZone()
        {
            Initialize();
        }

        public TimeZone(TimeZone e)
        {
            Initialize(e);
        }

        public TimeZone(TimeZoneInfo tz)
        {
            Initialize();
            this.Id = tz.Id;
            this.BaseUtcOffset = (int)tz.BaseUtcOffset.TotalSeconds;
            this.DaylightName = tz.DaylightName;
            this.DisplayName = tz.DisplayName;
            this.StandardName = tz.StandardName;
            this.SupportsDaylightSavingsTime = tz.SupportsDaylightSavingTime;
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(TimeZone e)
        {
            Initialize();
            if (e == null)
                return;
            this.TimeZoneUid = e.TimeZoneUid;
            this.Id = e.Id;
            this.DisplayName = e.DisplayName;
            this.StandardName = e.StandardName;
            this.DaylightName = e.DaylightName;
            this.SupportsDaylightSavingsTime = e.SupportsDaylightSavingsTime;
            this.BaseUtcOffset = e.BaseUtcOffset;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public TimeZone Clone(TimeZone e)
        {
            return new TimeZone(e);
        }

        public bool Equals(TimeZone other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(TimeZone other)
        {
            if (other == null)
                return false;

            if (other.TimeZoneUid != this.TimeZoneUid)
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
