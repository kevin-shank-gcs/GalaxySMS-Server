using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyInterfaceBoardSectionModeCommandRepository : IDataRepository<GalaxyInterfaceBoardSectionModeCommand>
    {
        IEnumerable<GalaxyInterfaceBoardSectionModeCommand> GetAllGalaxyInterfaceBoardSectionModeCommandForMode(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyInterfaceBoardSectionModeCommand> GetAllGalaxyInterfaceBoardSectionModeCommandForCommand(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

