using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IUserDefinedPropertyEntityMapRepository : IDataRepository<UserDefinedPropertyEntityMap>
    {
        IEnumerable<UserDefinedPropertyEntityMap> GetAllUserDefinedPropertyEntityMapsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<UserDefinedPropertyEntityMap> GetAllUserDefinedPropertyEntityMapsForUserDefinedProperty(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

