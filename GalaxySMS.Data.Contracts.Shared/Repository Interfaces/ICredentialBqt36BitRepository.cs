using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialBqt36BitRepository : IDataRepository<CredentialBqt36Bit>
    {
        CredentialBqt36Bit Save(CredentialBqt36Bit entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);
        IEnumerable<CredentialBqt36Bit> GetByFacilityAndIdAndIssueCodes(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<CredentialBqt36Bit> getParameters);
        IEnumerable<CredentialBqt36Bit> GetByIdCode(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

