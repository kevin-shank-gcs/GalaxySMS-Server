using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyInputArmingInputOutputGroupRepository : IDataRepository<GalaxyInputArmingInputOutputGroup>
    {
        IEnumerable<GalaxyInputArmingInputOutputGroup> GetByInputDeviceUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

