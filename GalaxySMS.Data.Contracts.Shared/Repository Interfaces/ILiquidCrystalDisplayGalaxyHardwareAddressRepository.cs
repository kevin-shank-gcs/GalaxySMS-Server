using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ILiquidCrystalDisplayGalaxyHardwareAddressRepository : IDataRepository<LiquidCrystalDisplayGalaxyHardwareAddress>
    {
        LiquidCrystalDisplayGalaxyHardwareAddress GetByLiquidCrystalDisplayUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        LiquidCrystalDisplayGalaxyHardwareAddress GetByLiquidCrystalDisplayGalaxyHardwareAddressUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);

    }
}

