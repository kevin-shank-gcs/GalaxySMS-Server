using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialFormatRepository : IDataRepository<CredentialFormat>
    {
        IEnumerable<CredentialFormat> GetAllCredentialFormatsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

