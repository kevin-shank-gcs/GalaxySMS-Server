using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using PDSA.DataLayer.DataClasses;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialRepository : IDataRepository<Credential>
    {
        IEnumerable<Credential> GetByCredentialValues(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<Credential> getParameters);
        Credential SaveCredential(Credential entity, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction, ISaveParameters saveParams);
        Credential_ActivityEventData GetActivityEventData(byte[] credentialBinaryData);
    }
}

