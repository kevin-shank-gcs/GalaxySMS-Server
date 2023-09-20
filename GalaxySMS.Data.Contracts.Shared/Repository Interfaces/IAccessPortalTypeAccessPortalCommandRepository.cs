using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccessPortalTypeAccessPortalCommandRepository : IDataRepository<AccessPortalTypeAccessPortalCommand>
    {
        IEnumerable<AccessPortalTypeAccessPortalCommand> GetAllForAccessPortalType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<AccessPortalTypeAccessPortalCommand> GetAllForAccessPortalCommand(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);

    }
}

