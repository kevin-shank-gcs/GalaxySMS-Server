using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ISiteEntityMapRepository : IDataRepository<SiteEntityMap>
    {
        IEnumerable<SiteEntityMap> GetAllSiteEntityMapsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<SiteEntityMap> GetAllSiteEntityMapsForSite(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

