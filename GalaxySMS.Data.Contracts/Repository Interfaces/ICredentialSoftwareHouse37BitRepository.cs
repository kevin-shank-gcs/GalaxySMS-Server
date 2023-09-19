using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using PDSA.DataLayer.DataClasses;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialSoftwareHouse37BitRepository : IDataRepository<CredentialSoftwareHouse37Bit>
    {
        CredentialSoftwareHouse37Bit Save(CredentialSoftwareHouse37Bit entity, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction, ISaveParameters saveParams);
        IEnumerable<CredentialSoftwareHouse37Bit> GetByFacilitySiteAndIdCodes(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<CredentialSoftwareHouse37Bit> getParameters);
        IEnumerable<CredentialSoftwareHouse37Bit> GetByIdCode(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

