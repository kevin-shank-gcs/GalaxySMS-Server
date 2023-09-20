using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyInterfaceBoardRepository : IDataRepository<GalaxyInterfaceBoard>, IHasGetEntityId
    {
        IEnumerable<GalaxyInterfaceBoard> GetAllGalaxyInterfaceBoardsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyInterfaceBoard> GetAllGalaxyInterfaceBoardsForPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyInterfaceBoard> GetAllGalaxyInterfaceBoardsForPanelAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        Guid GetParentEntityId(Guid parentUid);
    }
}

