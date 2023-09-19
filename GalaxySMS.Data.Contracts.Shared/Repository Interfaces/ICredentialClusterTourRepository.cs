using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialClusterTourRepository : IDataRepository<CredentialClusterTour>
    {
        IEnumerable<CredentialClusterTour> GetAllCredentialClusterToursForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

