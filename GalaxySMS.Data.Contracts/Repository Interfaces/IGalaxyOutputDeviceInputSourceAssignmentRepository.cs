using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyOutputDeviceInputSourceAssignmentRepository : IDataRepository<GalaxyOutputDeviceInputSourceAssignment>
    {
        IEnumerable<GalaxyOutputDeviceInputSourceAssignment> GetByGalaxyOutputDeviceInputSource(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyOutputDevice_InputSource_Assignments_PanelLoadData> GetPanelLoadDataForInputSourceUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

