using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccessPortalCommandAuditRepository : IDataRepository<AccessPortalCommandAudit>
    {
        bool Insert(AccessPortalCommandAudit data);
    }
}

