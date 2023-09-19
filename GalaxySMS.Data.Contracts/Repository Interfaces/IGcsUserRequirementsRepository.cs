using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsUserRequirementsRepository : IDataRepository<gcsUserRequirement>
    {
        gcsUserRequirement GetByEntityId(Guid entityId);
    }
}
