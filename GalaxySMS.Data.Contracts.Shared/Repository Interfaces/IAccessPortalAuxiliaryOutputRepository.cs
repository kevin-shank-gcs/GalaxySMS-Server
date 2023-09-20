using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccessPortalAuxiliaryOutputRepository : IDataRepository<AccessPortalAuxiliaryOutput>
    {
        IEnumerable<AccessPortalAuxiliaryOutput> GetByAccessPortalUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

