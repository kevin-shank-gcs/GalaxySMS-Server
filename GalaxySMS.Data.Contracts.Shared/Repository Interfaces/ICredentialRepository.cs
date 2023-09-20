using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialRepository : IDataRepository<Credential>
    {
        IEnumerable<Credential> GetByCredentialValues(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<Credential> getParameters);
        Credential SaveCredential(Credential entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);
        Credential_ActivityEventData GetActivityEventData(byte[] credentialBinaryData);
    }
}

