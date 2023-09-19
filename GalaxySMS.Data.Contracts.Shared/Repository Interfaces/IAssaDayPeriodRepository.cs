using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAssaDayPeriodRepository : IDataRepository<AssaDayPeriod>, IHasGetEntityId
    {
        IEnumerable<AssaDayPeriod> GetAllAssaDayPeriodsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        //IEnumerable<AssaDayPeriod> GetAllAssaDayPeriodsForGalaxyCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        //IEnumerable<AssaDayPeriod> GetAllAssaDayPeriodsForAssaAbloyDsr(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

