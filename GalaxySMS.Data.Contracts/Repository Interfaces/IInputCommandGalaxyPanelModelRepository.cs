using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IInputCommandGalaxyPanelModelRepository : IDataRepository<InputCommandGalaxyPanelModel>
    {
        IEnumerable<InputCommandGalaxyPanelModel> GetAllForGalaxyPanelModel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<InputCommandGalaxyPanelModel> GetAllForInputDeviceCommand(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

