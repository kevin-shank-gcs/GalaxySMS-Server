using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyOutputDeviceInputSourceInputOutputGroupRepository : IDataRepository<GalaxyOutputDeviceInputSourceInputOutputGroup>
    {
        IEnumerable<GalaxyOutputDeviceInputSourceInputOutputGroup> GetByGalaxyOutputDeviceInputSource(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadData> GetPanelLoadDataForInputSourceUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}

