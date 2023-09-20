using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IInputOutputGroupCommandAuditRepository : IDataRepository<InputOutputGroupCommandAudit>
    {
        bool Insert(InputOutputGroupCommandAudit data);
    }
}

