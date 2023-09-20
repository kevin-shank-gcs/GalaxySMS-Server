using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccessPortalGalaxyHardwareAddressRepository : IDataRepository<AccessPortalGalaxyHardwareAddress>
    {
        AccessPortalGalaxyHardwareAddress GetByAccessPortalUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        AccessPortalGalaxyHardwareAddress GetByAccessPortalGalaxyHardwareAddressUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);

    }
}

