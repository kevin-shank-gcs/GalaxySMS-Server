using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyHardwareModuleRepository : IDataRepository<GalaxyHardwareModule>, IHasGetEntityId
    {
        IEnumerable<GalaxyHardwareModule> GetAllGalaxyHardwareModulesForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyHardwareModule> GetAllGalaxyHardwareModulesForPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyHardwareModule> GetAllGalaxyHardwareModulesForPanelAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyHardwareModule> GetAllGalaxyHardwareModulesForInterfaceBoard(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyHardwareModule> GetAllGalaxyHardwareModulesForInterfaceBoardSection(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        Guid GetParentEntityId(Guid parentUid);
    }
}

