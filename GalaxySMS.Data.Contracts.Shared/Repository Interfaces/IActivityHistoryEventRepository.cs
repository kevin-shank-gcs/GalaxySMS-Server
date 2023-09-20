using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Data.Contracts
{
    public interface IActivityHistoryEventRepository : IDataRepository
    {
        IArrayResponse<ActivityHistoryEvent> GetActivityHistoryEvents(IApplicationUserSessionDataHeader sessionData, ActivityHistoryEventSearchParameters parameters);
        IArrayResponse<ActivityHistoryEvent> GetActivityEvents(IApplicationUserSessionDataHeader sessionData, ActivityHistoryEventSearchParameters parameters);
        EventFilterData GetEventFilterData(IApplicationUserSessionDataHeader sessionData, EventFilterDataSelectionParameters parameters);
    }
}
