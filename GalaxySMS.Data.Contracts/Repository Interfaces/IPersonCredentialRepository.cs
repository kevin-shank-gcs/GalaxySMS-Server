using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonCredentialRepository : IDataRepository<PersonCredential>
    {
        IEnumerable<PersonCredential> GetAllPersonCredentialsForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonCredential> GetAllPersonCredentialsForCredential(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        PersonCredential GetByCredentialUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        PersonCredentialBadgeDataView GetPersonCredentialBadgeDataView(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

