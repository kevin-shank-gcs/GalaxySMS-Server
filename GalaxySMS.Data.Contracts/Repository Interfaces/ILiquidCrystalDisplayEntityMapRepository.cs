using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ILiquidCrystalDisplayEntityMapRepository : IDataRepository<LiquidCrystalDisplayEntityMap>
    {
        IEnumerable<LiquidCrystalDisplayEntityMap> GetAllLiquidCrystalDisplayEntityMapsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<LiquidCrystalDisplayEntityMap> GetAllLiquidCrystalDisplayEntityMapsForLiquidCrystalDisplay(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

