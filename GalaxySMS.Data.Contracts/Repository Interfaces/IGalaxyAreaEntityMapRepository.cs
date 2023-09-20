using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyAreaEntityMapRepository : IDataRepository<AreaEntityMap>
    {
        IEnumerable<AreaEntityMap> GetAllAreaEntityMapsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<AreaEntityMap> GetAllAreaEntityMapsForArea(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

