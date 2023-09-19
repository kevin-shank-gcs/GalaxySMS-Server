using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IBadgeTemplateEntityMapRepository : IDataRepository<BadgeTemplateEntityMap>
    {
        IEnumerable<BadgeTemplateEntityMap> GetAllBadgeTemplateEntityMapsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<BadgeTemplateEntityMap> GetAllBadgeTemplateEntityMapsForBadgeTemplate(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}

