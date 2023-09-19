using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IInputDeviceEventPropertiesRepository : IDataRepository<InputDeviceEventProperty>
    {
        IEnumerable<InputDeviceEventProperty> GetByInputDeviceUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<InputDeviceEventProperty> GetByEntityId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

