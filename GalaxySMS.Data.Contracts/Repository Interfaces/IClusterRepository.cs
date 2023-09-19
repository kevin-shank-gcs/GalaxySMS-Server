using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IClusterRepository : IPagedDataRepository<Cluster>, IHasGetEntityId
    {
        IEnumerable<Cluster> GetClustersByClusterNumber(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<Cluster> GetClustersByClusterGroupId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        Cluster GetByHardwareAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<Cluster> GetAllClustersForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<Cluster> GetAllClustersForSite(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IArrayResponse<ClusterSelectionItemBasic> GetAllClusterSelectionItemsForEntityAndSite(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<ClusterSelectionItemBasic> GetAllClusterSelectionItemsForSite(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        Cluster_CommonPanelLoadData GetCommonPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        Cluster_GetHardwareAddress GetClusterHardwareAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters);
        int GetAvailableClusterNumber(int clusterGroupId);
        bool DoesUserHavePermission(IApplicationUserSessionDataHeader sessionData, Guid clusterUid, Guid permissionId, Guid entityId);
        IEnumerable<Guid> GetAllPrimaryKeyUids();
        IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleId(Guid roleId);
        IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleIdAndSiteUid(Guid roleId, Guid siteUid);
        IArrayResponse<Cluster> GetAllClustersForEntityPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IArrayResponse<Cluster> GetAllClustersForSitePaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        bool VerifyEntityIdMatches(Guid clusterUid, Guid entityId);
        Guid GetEntityId(int clusterGroupId, int clusterNumber);

        IArrayResponse<ClusterTimeScheduleItem> GetClusterTimeScheduleItemsBySchedule(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        bool IsClusterAddressUnique(Cluster entity);
        bool IsClusterNameUnique(Cluster entity);

    }
}

