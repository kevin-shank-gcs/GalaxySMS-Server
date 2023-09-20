using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IBadgeTemplateRepository : IDataRepository<BadgeTemplate>, IHasGetEntityId
    {
        IEnumerable<BadgeTemplate> GetAllBadgeTemplatesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

