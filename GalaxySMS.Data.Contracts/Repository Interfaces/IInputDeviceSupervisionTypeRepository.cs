using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IInputDeviceSupervisionTypeRepository : IDataRepository<InputDeviceSupervisionType>
    {
        IEnumerable<InputDeviceSupervisionType> GetAllInputDeviceSupervisionTypeForInputDevice(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

