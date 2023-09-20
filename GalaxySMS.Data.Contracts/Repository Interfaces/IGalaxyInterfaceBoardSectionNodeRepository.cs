using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyInterfaceBoardSectionNodeRepository : IDataRepository<GalaxyInterfaceBoardSectionNode>, IHasGetEntityId
    {
        IEnumerable<GalaxyInterfaceBoardSectionNode> GetAllGalaxyInterfaceBoardSectionNodesForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyInterfaceBoardSectionNode> GetAllGalaxyInterfaceBoardSectionNodesForPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyInterfaceBoardSectionNode> GetAllGalaxyInterfaceBoardSectionNodesForPanelAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyInterfaceBoardSectionNode> GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoard(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyInterfaceBoardSectionNode> GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoardSection(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyInterfaceBoardSectionNode> GetAllGalaxyInterfaceBoardSectionNodesForGalaxyHardwareModule(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

