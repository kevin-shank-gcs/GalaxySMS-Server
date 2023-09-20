using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IOutputDeviceEntityMapRepository : IDataRepository<OutputDeviceEntityMap>
    {
        IEnumerable<OutputDeviceEntityMap> GetAllOutputDeviceEntityMapsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<OutputDeviceEntityMap> GetAllOutputDeviceEntityMapsForOutputDevice(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

