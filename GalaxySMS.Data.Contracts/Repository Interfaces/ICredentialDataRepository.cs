using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using PDSA.DataLayer.DataClasses;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialDataRepository : IDataRepository<CredentialData>
    {
        CredentialData Save(CredentialData entity, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction, ISaveParameters saveParams);
        IEnumerable<CredentialData> GetByNumbers(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<CredentialData> getParameters);
    }
}

