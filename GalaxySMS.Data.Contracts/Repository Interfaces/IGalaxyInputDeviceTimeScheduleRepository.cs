using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyInputDeviceTimeScheduleRepository : IDataRepository<GalaxyInputDeviceTimeSchedule>
    {
        GalaxyInputDeviceTimeSchedule GetByInputDeviceUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

