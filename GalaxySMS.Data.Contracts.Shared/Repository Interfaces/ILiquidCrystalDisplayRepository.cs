using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ILiquidCrystalDisplayRepository : IDataRepository<LiquidCrystalDisplay>
    {
        IEnumerable<LiquidCrystalDisplay> GetAllLiquidCrystalDisplaysForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<LiquidCrystalDisplay> GetAllLiquidCrystalDisplaysForRegion(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<LiquidCrystalDisplay> GetAllLiquidCrystalDisplaysForSite(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<LiquidCrystalDisplay> GetAllLiquidCrystalDisplaysForGalaxyPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<LiquidCrystalDisplay> GetAllLiquidCrystalDisplaysForAccessPoint(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        LiquidCrystalDisplay GetLiquidCrystalDisplayForAccessPoint(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        LiquidCrystalDisplay EnsureLiquidCrystalDisplayExists(IApplicationUserSessionDataHeader sessionData, EnsureLiquidCrystalDisplayExistsParameters parameters, ISaveParameters saveParams);
    }
}

