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
	public partial class DateType
    {
        public DateType()
        {
            Initialize();
        }

        public DateType(DateType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(DateType e)
        {
            Initialize();
            if (e == null)
                return;
            this.DateTypeUid = e.DateTypeUid;
            this.EntityId = e.EntityId;
            this.DayTypeUid = e.DayTypeUid;
            this.Date = e.Date;
            this.Title = e.Title;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.TotalRowCount = e.TotalRowCount;

        }

        public DateType Clone(DateType e)
        {
            return new DateType(e);
        }

        public bool Equals(DateType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(DateType other)
        {
            if (other == null)
                return false;

            if (other.DateTypeUid != this.DateTypeUid)
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

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public int TotalRowCount { get; set; }

    }
}
