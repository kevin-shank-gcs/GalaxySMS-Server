using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IInputDeviceSupervisionTypeInterfaceBoardSectionModeRepository : IDataRepository<InputDeviceSupervisionTypeInterfaceBoardSectionMode>
    {
        IEnumerable<InputDeviceSupervisionTypeInterfaceBoardSectionMode> GetAllInputDeviceSupervisionTypeInterfaceBoardSectionModesForBoardSectionMode(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<InputDeviceSupervisionTypeInterfaceBoardSectionMode> GetAllInputDeviceSupervisionTypeInterfaceBoardSectionModesForSupervisionType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

