using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccessPortalCommandRepository : IDataRepository<AccessPortalCommand>
    {
        IEnumerable<AccessPortalCommand> GetAllAccessPortalCommandsForAccessPortalType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<AccessPortalCommand> GetAllAccessPortalCommandsForAccessPortal(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

