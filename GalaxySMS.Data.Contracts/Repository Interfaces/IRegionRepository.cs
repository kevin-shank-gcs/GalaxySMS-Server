using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IRegionRepository : IDataRepository<Region>, IHasGetEntityId
    {
        IEnumerable<Region> GetAllRegionsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<RegionSelectionItemBasic> GetAllRegionSelectionItemsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleId(Guid roleId);
    }
}

