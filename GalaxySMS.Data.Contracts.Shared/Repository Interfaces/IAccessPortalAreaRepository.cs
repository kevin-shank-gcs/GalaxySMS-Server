using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccessPortalAreaRepository : IDataRepository<AccessPortalArea>
    {
        IEnumerable<AccessPortalArea> GetByAccessPortalUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

