using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ITimePeriodEntityMapRepository : IDataRepository<TimePeriodEntityMap>
    {
        IEnumerable<TimePeriodEntityMap> GetAllForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<TimePeriodEntityMap> GetAllForTimePeriod(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

