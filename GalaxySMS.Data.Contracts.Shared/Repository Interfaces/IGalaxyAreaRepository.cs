using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyAreaRepository : IPagedDataRepository<Area>, IHasGetEntityId
    {
        IArrayResponse<Area> GetAllGalaxyAreasForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<Area> GetAllGalaxyAreasForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<Area> GetAllGalaxyAreasForAccessPortal(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        int GetAvailableAreaNumber(Guid clusterUid);
        Guid GetParentEntityId(Guid parentUid);
        IEnumerable<Guid> GetUidsForCluster(Guid clusterUid);

    }
}

