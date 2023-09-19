using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IOutputCommandGalaxyOutputModeRepository : IDataRepository<OutputCommandGalaxyOutputMode>
    {
        IEnumerable<OutputCommandGalaxyOutputMode> GetAllOutputCommandGalaxyOutputModeForOutputCommand(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<OutputCommandGalaxyOutputMode> GetAllOutputCommandGalaxyOutputModeForOutputMode(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

