using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IOutputDeviceGalaxyHardwareAddressRepository : IDataRepository<OutputDeviceGalaxyHardwareAddress>
    {
        OutputDeviceGalaxyHardwareAddress GetByOutputDeviceUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        OutputDeviceGalaxyHardwareAddress GetByOutputDeviceGalaxyHardwareAddressUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);

    }
}

