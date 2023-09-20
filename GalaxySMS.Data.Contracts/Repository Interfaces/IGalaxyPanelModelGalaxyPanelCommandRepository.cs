using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyPanelModelGalaxyPanelCommandRepository : IDataRepository<GalaxyPanelModelGalaxyPanelCommand>
    {
        IEnumerable<GalaxyPanelModelGalaxyPanelCommand> GetAllGalaxyPanelModelGalaxyPanelCommandForPanelModel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyPanelModelGalaxyPanelCommand> GetAllGalaxyPanelModelGalaxyPanelCommandForCommand(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

