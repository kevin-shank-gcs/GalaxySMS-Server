using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyCpuLoggingControlRepository : IDataRepository<GalaxyCpuLoggingControl>
    {
        IEnumerable<GalaxyCpuLoggingControl> GetAllGalaxyCpuLoggingControlsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyCpuLoggingControl> GetAllGalaxyCpuLoggingControlsForPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyCpuLoggingControl> GetAllGalaxyCpuLoggingControlsForCpu(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        GalaxyCpuLoggingControl GetGalaxyCpuLoggingControlForAccountClusterPanelCpuNumbers(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        GalaxyCpuDatabaseInformation GetGalaxyCpuDatabaseInformation(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        void SaveCpuLoggingControl(IApplicationUserSessionDataHeader sessionData, ISaveParameters<GalaxyCpuLoggingControl> entity);
    }
}

