using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IDayTypeEntityMapRepository : IDataRepository<DayTypeEntityMap>
    {
        IEnumerable<DayTypeEntityMap> GetAllForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<DayTypeEntityMap> GetAllForDayType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

