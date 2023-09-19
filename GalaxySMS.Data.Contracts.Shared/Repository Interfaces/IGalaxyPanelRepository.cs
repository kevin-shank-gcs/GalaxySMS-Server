using System;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyPanelRepository : IPagedDataRepository<GalaxyPanel>, IHasGetEntityId
    {
        //IArrayResponse<GalaxyPanel> GetAllGalaxyPanelsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<GalaxyPanel> GetAllGalaxyPanelsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        //IEnumerable<GalaxyPanel> GetAllGalaxyPanelsForRegion(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<GalaxyPanel> GetAllGalaxyPanelsForSite(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        GalaxyPanel GetByHardwareAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyPanelAlarmSettings_PanelLoadData> GetAlarmEventSettingsByGalaxyPanelUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyPanelAlarmSettings_PanelLoadData> GetAlarmEventSettingsByClusterUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<ActivityHistoryEvent> GetActivityHistoryEvents(IApplicationUserSessionDataHeader sessionData, ActivityHistoryEventSearchParameters parameters);
        bool VerifyEntityIdMatches(Guid galaxyPanelUid, Guid entityId);
        Guid GetParentEntityId(Guid parentUid);
        Guid GetEntityId(int clusterGroupId, int clusterNumber, int panelNumber);
        bool IsPanelNumberUnique(GalaxyPanel entity);
        bool IsPanelNameUnique(GalaxyPanel entity);
        bool IsPanelConnected(Guid galaxyPanelUid);
        LoadDataCounts GetLoadDataCounts(Guid galaxyPanelUid, LoadDataToPanelSettings loadSettings);
        IEnumerable<Guid> GetAllPrimaryKeyUidsForEntityId(Guid entityId);
        IEnumerable<Guid> GetAllPrimaryKeyUidsForClusterUid(Guid clusterUid);
    }
}

