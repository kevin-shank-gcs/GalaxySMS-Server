using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IInputOutputGroupAssignmentRepository : IDataRepository<InputOutputGroupAssignment>
    {
        IEnumerable<InputOutputGroupAssignment> GetAllForInputOutputGroup(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

