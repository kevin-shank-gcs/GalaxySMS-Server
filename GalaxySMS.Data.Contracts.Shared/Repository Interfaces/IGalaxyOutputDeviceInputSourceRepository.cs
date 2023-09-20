using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyOutputDeviceInputSourceRepository : IDataRepository<GalaxyOutputDeviceInputSource>
    {
        IEnumerable<GalaxyOutputDeviceInputSource> GetByOutputDeviceUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);

        IEnumerable<GalaxyOutputDevice_InputSource_Main_PanelLoadData> GetPanelLoadDataForOutputDeviceUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

