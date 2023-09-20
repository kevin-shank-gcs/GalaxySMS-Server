using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialCypress37BitRepository : IDataRepository<CredentialCypress37Bit>
    {
        CredentialCypress37Bit Save(CredentialCypress37Bit entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);
        IEnumerable<CredentialCypress37Bit> GetByFacilityAndIdCodes(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<CredentialCypress37Bit> getParameters);
        IEnumerable<CredentialCypress37Bit> GetByIdCode(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

