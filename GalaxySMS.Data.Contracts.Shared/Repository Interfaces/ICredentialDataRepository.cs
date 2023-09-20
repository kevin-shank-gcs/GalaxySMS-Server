using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialDataRepository : IDataRepository<CredentialData>
    {
        CredentialData Save(CredentialData entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);
        IEnumerable<CredentialData> GetByNumbers(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<CredentialData> getParameters);
    }
}

