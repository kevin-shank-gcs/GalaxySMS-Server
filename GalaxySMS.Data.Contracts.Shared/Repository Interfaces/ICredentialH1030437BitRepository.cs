using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialH1030437BitRepository : IDataRepository<CredentialH1030437Bit>
    {
        CredentialH1030437Bit Save(CredentialH1030437Bit entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);
        IEnumerable<CredentialH1030437Bit> GetByFacilityAndIdCodes(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<CredentialH1030437Bit> getParameters);
        IEnumerable<CredentialH1030437Bit> GetByIdCode(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

