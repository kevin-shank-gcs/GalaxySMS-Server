using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyPanelModelInterfaceBoardTypeRepository : IDataRepository<GalaxyPanelModelInterfaceBoardType>
    {
        IEnumerable<GalaxyPanelModelInterfaceBoardType> GetAllGalaxyPanelModelInterfaceBoardTypesForPanelModel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<GalaxyPanelModelInterfaceBoardType> GetAllGalaxyPanelModelInterfaceBoardTypesForType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

