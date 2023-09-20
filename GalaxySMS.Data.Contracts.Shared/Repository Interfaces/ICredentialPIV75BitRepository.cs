using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialPIV75BitRepository : IDataRepository<CredentialPIV75Bit>
    {
        CredentialPIV75Bit Save(CredentialPIV75Bit entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);
        IEnumerable<CredentialPIV75Bit> GetByAgencyAndSiteAndCredentialCodes(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<CredentialPIV75Bit> getParameters);
    }
}

