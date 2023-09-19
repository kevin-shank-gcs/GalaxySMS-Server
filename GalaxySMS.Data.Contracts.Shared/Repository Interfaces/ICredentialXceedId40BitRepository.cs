using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialXceedId40BitRepository : IDataRepository<CredentialXceedId40Bit>
    {
        CredentialXceedId40Bit Save(CredentialXceedId40Bit entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);
        IEnumerable<CredentialXceedId40Bit> GetBySiteAndIdCodes(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<CredentialXceedId40Bit> getParameters);
        IEnumerable<CredentialXceedId40Bit> GetByIdCode(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

