using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialFormatParityRepository : IDataRepository<CredentialFormatParity>
    {
        IEnumerable<CredentialFormatParity> GetAllCredentialFormatParitiesForCredentialFormat(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

