using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialFormatEntityMapRepository : IDataRepository<CredentialFormatEntityMap>
    {
        IEnumerable<CredentialFormatEntityMap> GetAllCredentialFormatEntityMapsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<CredentialFormatEntityMap> GetAllCredentialFormatEntityMapsForCredentialFormat(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}

