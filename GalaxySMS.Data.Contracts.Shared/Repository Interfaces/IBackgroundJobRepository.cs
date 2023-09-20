using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Data.Contracts
{
    public interface IBackgroundJobRepository : IDataRepository<BackgroundJob>
    {
        IEnumerable<BackgroundJob> GetAllBackgroundJobsByState(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters, BackgroundJobState state);
    }
}

