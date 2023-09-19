using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ISiteRepository : IDataRepository<Site>, IHasGetEntityId
    {
        IEnumerable<Site> GetAllSitesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<SiteSelectionItemBasic> GetAllSiteSelectionItemsForEntityAndRegion(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleId(Guid roleId);
        IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleIdAndRegionUid(Guid roleId, Guid regionUid);

    }
}

