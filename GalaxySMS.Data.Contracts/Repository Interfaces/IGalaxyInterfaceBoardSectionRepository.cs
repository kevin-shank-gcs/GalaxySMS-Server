using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyInterfaceBoardSectionRepository : IDataRepository<GalaxyInterfaceBoardSection>, IHasGetEntityId
    {
        IEnumerable<GalaxyInterfaceBoardSection> GetAllGalaxyInterfaceBoardSectionsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyInterfaceBoardSection> GetAllGalaxyInterfaceBoardSectionsForPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyInterfaceBoardSection> GetAllGalaxyInterfaceBoardSectionsForPanelAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyInterfaceBoardSection> GetAllGalaxyInterfaceBoardSectionsForInterfaceBoard(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyInterfaceBoardSection> GetAllGalaxyInterfaceBoardSectionsForAccessPortalUidModeCode(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        GalaxyInterfaceBoardSection_PanelLoadData GetGalaxyInterfaceBoardSectionPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<GalaxyInterfaceBoardSection_PanelLoadData> GetGalaxyInterfaceBoardSectionPanelLoadDataForPanelUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<GalaxyInterfaceBoardSection_PanelLoadData> GetGalaxyInterfaceBoardSectionPanelLoadDataForClusterUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        Guid GetParentEntityId(Guid parentUid);
        Guid GetGalaxyPanelUid(Guid uid);
    }
}

