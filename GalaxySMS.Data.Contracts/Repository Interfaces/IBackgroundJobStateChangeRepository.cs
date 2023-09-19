using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IBackgroundJobStateChangeRepository : IDataRepository<BackgroundJobStateChange>
    {
        IEnumerable<BackgroundJobStateChange> GetByBackgroundJob(Guid jobUid);
    }
}

