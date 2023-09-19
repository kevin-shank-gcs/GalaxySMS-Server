using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAssaDsrEntityMapRepository : IDataRepository<AssaDsrEntityMap>
    {
        IEnumerable<AssaDsrEntityMap> GetAllAssaDsrEntityMapsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<AssaDsrEntityMap> GetAllAssaDsrEntityMapsForAssaDsr(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

