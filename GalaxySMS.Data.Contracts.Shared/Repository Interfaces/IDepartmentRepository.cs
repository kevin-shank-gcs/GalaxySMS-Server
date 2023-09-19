using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;

namespace GalaxySMS.Data.Contracts
{
    public interface IDepartmentRepository : IPagedDataRepository<Department>, IHasGetEntityId
    {
        IArrayResponse<Department> GetAllDepartmentsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

