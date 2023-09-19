using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsPermissionCategoryRepository : IDataRepository<gcsPermissionCategory>
    {
        IEnumerable<gcsPermissionCategory> GetAllPermissionCategoriesForApplication(Guid applicationId, IGetParametersWithPhoto getParameters);
    }
}

