using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredential26BitStandardRepository : IDataRepository<Credential26BitStandard>
    {
        Credential26BitStandard Save(Credential26BitStandard entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);
        IEnumerable<Credential26BitStandard> GetByFacilityAndIdCodes(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<Credential26BitStandard> getParameters);
        IEnumerable<Credential26BitStandard> GetByIdCode(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

