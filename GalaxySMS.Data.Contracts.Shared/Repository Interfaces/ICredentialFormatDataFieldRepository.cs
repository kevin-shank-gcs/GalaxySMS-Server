using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialFormatDataFieldRepository : IDataRepository<CredentialFormatDataField>
    {
        IEnumerable<CredentialFormatDataField> GetAllCredentialFormatDataFieldsForCredentialFormat(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

