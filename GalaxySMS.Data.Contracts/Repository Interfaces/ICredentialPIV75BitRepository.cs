using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using PDSA.DataLayer.DataClasses;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialPIV75BitRepository : IDataRepository<CredentialPIV75Bit>
    {
        CredentialPIV75Bit Save(CredentialPIV75Bit entity, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction, ISaveParameters saveParams);
        IEnumerable<CredentialPIV75Bit> GetByAgencyAndSiteAndCredentialCodes(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<CredentialPIV75Bit> getParameters);
    }
}

