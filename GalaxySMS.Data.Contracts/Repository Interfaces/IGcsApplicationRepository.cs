using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsApplicationRepository : IDataRepository<gcsApplication>
    {
        IEnumerable<gcsApplicationBasic> GetAllApplicationsBasic(IGetParametersWithPhoto getParameters, IApplicationUserSessionDataHeader sessionData);
        IEnumerable<gcsApplication> GetAllApplicationsForEntity(Guid entityId, IGetParametersWithPhoto getParameters);
        IEnumerable<gcsApplication> GetAllApplicationsForUser(Guid userId, IGetParametersWithPhoto getParameters);
        bool EnsureDefaultUserEntityApplicationRolesExist(gcsApplication entity, IApplicationUserSessionDataHeader sessionData);
    }
}
