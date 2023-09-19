using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonRecordTypeRepository : IDataRepository<PersonRecordType>, IHasGetEntityId
    {
        IEnumerable<PersonRecordType> GetAllPersonRecordTypesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

