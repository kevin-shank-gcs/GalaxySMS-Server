﻿using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using PDSA.DataLayer.DataClasses;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialCorporate1K35BitRepository : IDataRepository<CredentialCorporate1K35Bit>
    {
        CredentialCorporate1K35Bit Save(CredentialCorporate1K35Bit entity, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction, ISaveParameters saveParams);
        IEnumerable<CredentialCorporate1K35Bit> GetByCompanyAndIdCodes(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<CredentialCorporate1K35Bit> getParameters);
        IEnumerable<CredentialCorporate1K35Bit> GetByIdCode(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

