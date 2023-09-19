using GalaxySMS.Business.Entities;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public enum AccessGroupClusterPermissionValidationResult
    {
        Ok = 0,
        InvalidOrderNumber,
        AccessGroupNotInCluster,
        AccessGroupNumberNotPermittedForOrderNumber1or2,
        AccessGroupNotPermittedForOrderNumber3,
        UnknownResult
    }
    public interface IGalaxyAccessGroupRepository : IPagedDataRepository<AccessGroup>, IHasGetEntityId
    {
        IArrayResponse<AccessGroup> GetAllGalaxyAccessGroupsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<AccessGroup> GetAllGalaxyAccessGroupsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<AccessGroup> GetAllGalaxyAccessGroupsForAccessPortal(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<AccessGroup> GetAllGalaxyAccessGroupsForEntityAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<AccessGroup> GetAllSystemAccessGroupsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        AccessGroup_PanelLoadData GetAccessGroupPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<AccessGroup_PanelLoadData> GetAccessGroupPanelLoadDataForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<AccessGroup_PanelLoadData> GetAccessGroupPanelLoadDataForGalaxyPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<AccessGroup_PanelLoadDataChanges> GetModifiedAccessGroupPanelLoadDataForCpu(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<AccessGroup_PanelLoadDataChanges> GetModifiedAccessGroupPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<AccessGroupSelectionItemBasic> GetAllAccessGroupSelectionItemsForEntityAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        int GetAvailableAccessGroupNumber(Guid clusterUid, ChooseAvailableAccessGroupNumberRange rangeOption);
        void UpdateLastLoadedDate(Guid cpuUid, int accessGroupNumber);
        void UpdateAccessPortalLastLoadedDate(Guid cpuUid, int accessGroupNumber, int boardNumber, int sectionNumber, int nodeNumber);
        DateTimeOffset GetCurrentTimeForCluster(Guid clusterUid);
        AccessGroupClusterPermissionValidationResult GetAccessGroupClusterPermissionValidationResult(Guid clusterUid, Guid accessGroupUid, short orderNumber);
        bool DoesClusterUidMatch(AccessGroup entity);
        AccessGroupCounts GetNewestCountsForAccessGroup(Guid accessGroupUid);
        ////AccessGroupCounts UpdateCountsForAccessGroup(Guid accessGroupUid);
        IArrayResponse<AccessGroupPersonInfo> GetPersonInfoForAccessGroup(IApplicationUserSessionDataHeader sessionData, GetParametersWithPhoto parameters);
        Guid GetParentEntityId(Guid parentUid);
        Guid GetClusterUidOf(Guid accessGroupUid);
        IEnumerable<Guid> GetUidsForCluster(Guid clusterUid);
        ValidationProblemDetails Validate(AccessGroup data);
    }
}

