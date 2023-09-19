using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IStateProvinceRepository : IDataRepository<StateProvince>
    {
        IEnumerable<StateProvince> GetAllForCountry(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

