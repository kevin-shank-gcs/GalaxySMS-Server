using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccessPortalRepository : IPagedDataRepository<AccessPortal>, IHasGetEntityId
    {
        IArrayResponse<AccessPortal> GetAllAccessPortalsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IArrayResponse<AccessPortal> GetAllAccessPortalsForRegion(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IArrayResponse<AccessPortal> GetAllAccessPortalsForSite(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        AccessPortal EnsureAccessPortalExists(IApplicationUserSessionDataHeader sessionData, EnsureAccessPortalExistsParameters parameters, ISaveParameters saveParams);
        IArrayResponse<AccessPortal> GetAllAccessPortalsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IArrayResponse<AccessPortal> GetAllAccessPortalsForGalaxyPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IArrayResponse<AccessPortalListItem> GetAccessPortalListForGalaxyPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters);
        IArrayResponse<AccessPortalListItem> GetAccessPortalListItemsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters);
        AccessPortalListItem GetAccessPortalListItem(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters);
        AccessPortal_PanelLoadData GetAccessPortalPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<AccessPortal_PanelLoadData> GetAccessPortalsPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<Guid> GetAccessPortalUidsForInterfaceBoardSection(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<AccessPortalSelectionItemBasic> GetAllAccessPortalSelectionItemsForEntityAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        AccessPortal_GetHardwareInformation GetHardwareInformation(IApplicationUserSessionDataHeader sessionData, Guid accessPortalUid);
        void UpdateGalaxyAccessPortalLastLoadedDate(Guid cpuUid, Guid accessPortalUid);

        IEnumerable<AccessPortal_PanelLoadData> GetModifiedPanelLoadDataForCpu(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        IArrayResponse<ActivityHistoryEvent> GetActivityHistoryEvents(IApplicationUserSessionDataHeader sessionData, ActivityHistoryEventSearchParameters getParameters);
        IArrayResponse<AccessPortal> GetByNameOrComments(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IArrayResponse<AccessPortalListItem> GetListItemsByNameOrComments(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters);
        bool DoesUserHavePermission(IApplicationUserSessionDataHeader sessionData, Guid accessPortalUid, Guid permissionId, Guid entityId);
        IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleId(Guid roleId);
        IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleIdAndClusterUid(Guid roleId, Guid clusterUid);
        ValidationProblemDetails Validate(AccessPortal data, ISaveParameters saveParams, IApplicationUserSessionDataHeader sessionData);
        Guid GetGalaxyPanelUid(Guid uid);
        IArrayResponse<AccessPortalListItem> GetAccessPortalsByNameAndSite(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters);
        IEnumerable<Guid> GetAllPrimaryKeyUidsForEntityId(Guid entityId);
        IEnumerable<Guid> GetAllPrimaryKeyUidsForClusterUid(Guid clusterUid);

    }
}

