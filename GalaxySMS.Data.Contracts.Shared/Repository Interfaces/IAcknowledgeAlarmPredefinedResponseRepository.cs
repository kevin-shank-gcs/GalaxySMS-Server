using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAcknowledgeAlarmPredefinedResponseRepository : IDataRepository<AcknowledgeAlarmPredefinedResponse>
    {
        IEnumerable<AcknowledgeAlarmPredefinedResponse> GetAllAcknowledgeAlarmPredefinedResponsesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

