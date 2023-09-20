using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonActiveStatusTypeRepository : IDataRepository<PersonActiveStatusType>
    {
        IEnumerable<PersonActiveStatusType> GetAllPersonActiveStatusTypesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

