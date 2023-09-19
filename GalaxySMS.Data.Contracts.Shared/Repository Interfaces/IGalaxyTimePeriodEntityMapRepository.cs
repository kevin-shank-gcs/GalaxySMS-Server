using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyTimePeriodEntityMapRepository : IDataRepository<GalaxyTimePeriodEntityMap>
    {
        IEnumerable<GalaxyTimePeriodEntityMap> GetAllForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyTimePeriodEntityMap> GetAllForGalaxyTimePeriod(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

