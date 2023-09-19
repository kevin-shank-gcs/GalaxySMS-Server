using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsEntityApplicationRepository : IDataRepository<gcsEntityApplication>
    {
        IEnumerable<gcsEntityApplication> GetAllForEntity(Guid entityId, IGetParametersWithPhoto getParameters);
        IEnumerable<gcsEntityApplication> GetAllForApplication(Guid applicationId, IGetParametersWithPhoto getParameters);
        gcsEntityApplication GetForEntityAndApplication(Guid entityId, Guid applicationId, IGetParametersWithPhoto getParameters);
    }
}
