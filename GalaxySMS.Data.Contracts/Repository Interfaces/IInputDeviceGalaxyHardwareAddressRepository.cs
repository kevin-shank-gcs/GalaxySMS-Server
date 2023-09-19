using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IInputDeviceGalaxyHardwareAddressRepository : IDataRepository<InputDeviceGalaxyHardwareAddress>
    {
        InputDeviceGalaxyHardwareAddress GetByInputDeviceUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        InputDeviceGalaxyHardwareAddress GetByInputDeviceGalaxyHardwareAddressUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);

    }
}

