using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyCpuRepository : IDataRepository<GalaxyCpu>, IHasGetEntityId
    {
        IEnumerable<GalaxyCpu> GetAllGalaxyCpusForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyCpu> GetAllGalaxyCpusForPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        GalaxyCpu GetByHardwareAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        void SaveCpuLoggingControl(IApplicationUserSessionDataHeader sessionData, ISaveParameters<GalaxyCpuLoggingControl> entity);
        IEnumerable<GalaxyCpuDatabaseInformation> GetGalaxyCpuInformation(IApplicationUserSessionDataHeader sessionData, GetHardwareAddressParameters parameters);
        IEnumerable<GalaxyCpuDatabaseInformation> GetGalaxyClusterPanelInformation(IApplicationUserSessionDataHeader sessionData, GetHardwareAddressParameters parameters);
        void UpdateCpuInformation(GalaxyCpuSaveInformationData parameters);
        bool IsCpuConnected(Guid cpuUid);
        void SetGalaxyCpuConnection(GalaxyCpuConnection cpuConnection);

    }
}

