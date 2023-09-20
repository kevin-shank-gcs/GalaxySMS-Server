using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyCpuModelInterfaceBoardSectionModeRepository : IDataRepository<GalaxyCpuModelInterfaceBoardSectionMode>
    {
        IEnumerable<GalaxyCpuModelInterfaceBoardSectionMode> GetAllGalaxyCpuModelInterfaceBoardSectionModesForCpuModel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<GalaxyCpuModelInterfaceBoardSectionMode> GetAllGalaxyCpuModelInterfaceBoardSectionModesForMode(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

