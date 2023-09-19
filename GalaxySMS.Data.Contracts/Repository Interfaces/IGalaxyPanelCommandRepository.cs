using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyPanelCommandRepository : IDataRepository<GalaxyPanelCommand>
    {
        IEnumerable<GalaxyPanelCommand> GetAllGalaxyPanelCommandForPanelModel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

