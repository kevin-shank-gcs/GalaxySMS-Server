﻿using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialSoftwareHouse37BitRepository : IDataRepository<CredentialSoftwareHouse37Bit>
    {
        CredentialSoftwareHouse37Bit Save(CredentialSoftwareHouse37Bit entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);
        IEnumerable<CredentialSoftwareHouse37Bit> GetByFacilitySiteAndIdCodes(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<CredentialSoftwareHouse37Bit> getParameters);
        IEnumerable<CredentialSoftwareHouse37Bit> GetByIdCode(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

