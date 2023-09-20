using System;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccessProfileRepository : IPagedDataRepository<AccessProfile>, IHasGetEntityId
    {
        IArrayResponse<AccessProfile> GetAllAccessProfilesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<AccessProfile> GetAllAccessProfilesForMappedEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

