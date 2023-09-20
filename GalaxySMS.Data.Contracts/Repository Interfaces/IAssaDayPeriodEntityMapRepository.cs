using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAssaDayPeriodEntityMapRepository : IDataRepository<AssaDayPeriodEntityMap>
    {
        IEnumerable<AssaDayPeriodEntityMap> GetAllForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<AssaDayPeriodEntityMap> GetAllForAssaDayPeriod(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

