using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAssaAccessPointTypeRepository : IDataRepository<AssaAccessPointType>
    {
        AssaAccessPointType GetAssaAccessPointTypeById(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

