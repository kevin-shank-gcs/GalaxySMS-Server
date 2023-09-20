using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyPanelModelInterfaceBoardSectionModeRepository : IDataRepository<GalaxyPanelModelInterfaceBoardSectionMode>
    {
        IEnumerable<GalaxyPanelModelInterfaceBoardSectionMode> GetAllGalaxyPanelModelInterfaceBoardSectionModesForPanelModel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<GalaxyPanelModelInterfaceBoardSectionMode> GetAllGalaxyPanelModelInterfaceBoardSectionModesForMode(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

