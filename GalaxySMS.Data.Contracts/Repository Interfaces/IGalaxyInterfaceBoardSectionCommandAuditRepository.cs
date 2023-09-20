using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyInterfaceBoardSectionCommandAuditRepository : IDataRepository<GalaxyInterfaceBoardSectionCommandAudit>
    {
        bool Insert(GalaxyInterfaceBoardSectionCommandAudit data);
    }
}

