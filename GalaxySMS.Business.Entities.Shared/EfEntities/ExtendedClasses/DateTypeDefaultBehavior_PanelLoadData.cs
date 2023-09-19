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

    public partial class DateTypeDefaultBehavior_PanelLoadData
    {
        public DateTypeDefaultBehavior_PanelLoadData()
        {
            Initialize();
        }

        public DateTypeDefaultBehavior_PanelLoadData(DateTypeDefaultBehavior_PanelLoadData e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(DateTypeDefaultBehavior_PanelLoadData e)
        {
            Initialize();
            if (e == null)
                return;

            //this.DateTypeDefaultBehaviorUid = e.DateTypeDefaultBehaviorUid;
            this.EntityName = e.EntityName;
            this.EntityId = e.EntityId;
            this.SundayDayCode = e.SundayDayCode;
            this.MondayDayCode = e.MondayDayCode;
            this.TuesdayDayCode = e.TuesdayDayCode;
            this.WednesdayDayCode = e.WednesdayDayCode;
            this.ThursdayDayCode = e.ThursdayDayCode;
            this.FridayDayCode = e.FridayDayCode;
            this.SaturdayDayCode = e.SaturdayDayCode;
        }

        public DateTypeDefaultBehavior_PanelLoadData Clone(DateTypeDefaultBehavior_PanelLoadData e)
        {
            return new DateTypeDefaultBehavior_PanelLoadData(e);
        }

        public bool Equals(DateTypeDefaultBehavior_PanelLoadData other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(DateTypeDefaultBehavior_PanelLoadData other)
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