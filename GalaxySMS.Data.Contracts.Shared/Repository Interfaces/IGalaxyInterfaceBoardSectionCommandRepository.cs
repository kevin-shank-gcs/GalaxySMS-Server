using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyInterfaceBoardSectionCommandRepository : IDataRepository<GalaxyInterfaceBoardSectionCommand>
    {
        IEnumerable<GalaxyInterfaceBoardSectionCommand> GetAllGalaxyInterfaceBoardSectionCommandsForGalaxyInterfaceBoardSectionMode(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
//        IEnumerable<GalaxyInterfaceBoardSectionCommand> GetAllGalaxyInterfaceBoardSectionCommandsForGalaxyInterfaceBoardSection(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

