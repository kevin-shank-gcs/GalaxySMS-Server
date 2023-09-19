using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IRegionEntityMapRepository : IDataRepository<RegionEntityMap>
    {
        IEnumerable<RegionEntityMap> GetAllRegionEntityMapsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<RegionEntityMap> GetAllRegionEntityMapsForRegion(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}

