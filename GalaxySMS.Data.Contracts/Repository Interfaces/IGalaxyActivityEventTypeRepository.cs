using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyActivityEventTypeRepository : IDataRepository<GalaxyActivityEventType>
    {
        IEnumerable<GalaxyActivityEventType> GetAllForCulture(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        GalaxyActivityEventType GetByEventTypeForCulture(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

