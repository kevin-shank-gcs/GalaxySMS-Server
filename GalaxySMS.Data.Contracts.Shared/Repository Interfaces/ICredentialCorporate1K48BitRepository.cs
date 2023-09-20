using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialCorporate1K48BitRepository : IDataRepository<CredentialCorporate1K48Bit>
    {
        CredentialCorporate1K48Bit Save(CredentialCorporate1K48Bit entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);
        IEnumerable<CredentialCorporate1K48Bit> GetByCompanyAndIdCodes(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<CredentialCorporate1K48Bit> getParameters);
        IEnumerable<CredentialCorporate1K48Bit> GetByIdCode(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

