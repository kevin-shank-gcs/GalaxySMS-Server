using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsEntityIdProducerRepository : IDataRepository<gcsEntityIdProducer>
    {
        gcsEntityIdProducer GetByIdProducerSubscriptionId(int subscriptionId, IApplicationUserSessionDataHeader sessionData);
        gcsEntityIdProducer GetByPersonUid(Guid personUid, IApplicationUserSessionDataHeader sessionData);
    }
}
