using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IFeatureItemRepository : IDataRepository<FeatureItem>
    {
        IEnumerable<FeatureItem> GetAllForFeature(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

