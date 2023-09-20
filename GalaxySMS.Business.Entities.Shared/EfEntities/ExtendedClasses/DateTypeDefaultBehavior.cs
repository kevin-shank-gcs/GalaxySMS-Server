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
	public partial class DateTypeDefaultBehavior
    {
        public DateTypeDefaultBehavior()
        {
            Initialize();
        }

        public DateTypeDefaultBehavior(DateTypeDefaultBehavior e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(DateTypeDefaultBehavior e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            //this.DateTypeDefaultBehaviorUid = e.DateTypeDefaultBehaviorUid;
            this.EntityId = e.EntityId;
            this.SundayDayTypeUid = e.SundayDayTypeUid;
            this.MondayDayTypeUid = e.MondayDayTypeUid;
            this.TuesdayDayTypeUid = e.TuesdayDayTypeUid;
            this.WednesdayDayTypeUid = e.WednesdayDayTypeUid;
            this.ThursdayDayTypeUid = e.ThursdayDayTypeUid;
            this.FridayDayTypeUid = e.FridayDayTypeUid;
            this.SaturdayDayTypeUid = e.SaturdayDayTypeUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public bool IsAnythingDirty
        {
            get
            {
                //foreach( var o in InterfaceBoardSections)
                //{
                //	if (o.IsAnythingDirty == true)
                //		return true;
                //}
                return IsDirty;
            }
        }

        public DateTypeDefaultBehavior Clone(DateTypeDefaultBehavior e)
        {
            return new DateTypeDefaultBehavior(e);
        }

        public bool Equals(DateTypeDefaultBehavior other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(DateTypeDefaultBehavior other)
        {
            if (other == null)
                return false;

            if (other.EntityId != this.EntityId)
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
