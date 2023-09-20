using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ITimeScheduleEntityMapRepository : IDataRepository<TimeScheduleEntityMap>
    {
        IEnumerable<TimeScheduleEntityMap> GetAllForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<TimeScheduleEntityMap> GetAllForTimeSchedule(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

