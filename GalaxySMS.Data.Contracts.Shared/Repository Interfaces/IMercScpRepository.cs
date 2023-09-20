using System;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IMercScpRepository : IPagedDataRepository<MercScp>, IHasGetEntityId
    {
        //IArrayResponse<MercScp> GetAllMercScpsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<MercScp> GetAllMercScpsForMercScpGroup(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        MercScp GetByMacAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);

        //IEnumerable<MercScp> GetAllMercScpsForRegion(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<MercScp> GetAllMercScpsForSite(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        //MercScp GetByHardwareAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        //IEnumerable<MercScpAlarmSettings_PanelLoadData> GetAlarmEventSettingsByMercScpUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        //IEnumerable<MercScpAlarmSettings_PanelLoadData> GetAlarmEventSettingsByClusterUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<ActivityHistoryEvent> GetActivityHistoryEvents(IApplicationUserSessionDataHeader sessionData, ActivityHistoryEventSearchParameters parameters);
        bool VerifyEntityIdMatches(Guid MercScpUid, Guid entityId);
        Guid GetParentEntityId(Guid parentUid);
        //Guid GetEntityId(int clusterGroupId, int clusterNumber, int panelNumber);
        bool IsPanelMacAddressUnique(MercScp entity);
        bool DoesMacAddressExist(string macAddress);
        bool IsPanelNameUnique(MercScp entity);
        //bool IsPanelConnected(Guid MercScpUid);
        //LoadDataCounts GetLoadDataCounts(Guid MercScpUid, LoadDataToPanelSettings loadSettings);
        IEnumerable<Guid> GetAllPrimaryKeyUidsForEntityId(Guid entityId);
        IEnumerable<Guid> GetAllPrimaryKeyUidsForMercScpGroupUid(Guid mercScpGroupUid);
    }
}

