using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyInputOutputGroupEntityMapRepository : IDataRepository<InputOutputGroupEntityMap>
    {
        IEnumerable<InputOutputGroupEntityMap> GetAllInputOutputGroupEntityMapsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<InputOutputGroupEntityMap> GetAllInputOutputGroupEntityMapsForInputOutputGroup(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

