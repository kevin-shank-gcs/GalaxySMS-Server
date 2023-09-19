using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ICountryRepository : IDataRepository<Country>
    {
        Country GetByIso(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        Country GetByIso3(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<Country> GetByCountryName(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

