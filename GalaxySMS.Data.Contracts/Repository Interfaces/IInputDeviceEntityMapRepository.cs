using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IInputDeviceEntityMapRepository : IDataRepository<InputDeviceEntityMap>
    {
        IEnumerable<InputDeviceEntityMap> GetAllInputDeviceEntityMapsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<InputDeviceEntityMap> GetAllInputDeviceEntityMapsForInputDevice(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

