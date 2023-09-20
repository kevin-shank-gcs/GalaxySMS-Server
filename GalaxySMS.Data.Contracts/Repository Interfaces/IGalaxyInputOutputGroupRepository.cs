using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public enum InputOutputGroupClusterPermissionValidationResult
    {
        Ok = 0,
        InvalidOrderNumber,
        InputOutputGroupNotInCluster,
        UnknownResult
    }

    public interface IGalaxyInputOutputGroupRepository : IPagedDataRepository<InputOutputGroup>, IHasGetEntityId
    {
        IArrayResponse<InputOutputGroup> GetAllGalaxyInputOutputGroupsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<InputOutputGroup> GetAllGalaxyInputOutputGroupsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<InputOutputGroup> GetAllGalaxyInputOutputGroupsForAccessPortal(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<InputOutputGroup> GetAllGalaxyInputOutputGroupsForInputDevice(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<InputOutputGroup> GetAllGalaxyInputOutputGroupsForOutputDevice(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<InputOutputGroupSelectionItemBasic> GetAllInputOutputGroupSelectionItemsForEntityAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<InputOutputGroup> GetAllSystemInputOutputGroupsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        InputOutputGroup_PanelLoadData GetInputOutputGroupPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<InputOutputGroup_PanelLoadData> GetAllInputOutputGroupPanelLoadDataForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        int GetAvailableInputOutputGroupNumber(Guid clusterUid);
        IArrayResponse<InputOutputGroup> GetAllInputOutputGroupSelectionItemsForClusterAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        InputOutputGroup GetInputOutputGroupSelectionItemsForClusterAddressAndInputOutputGroupNumber(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<InputOutputGroupAssignmentSource> GetInputOutputGroupAssignmentSourcesForInputOutputGroupUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        bool DoesUserHavePermission(IApplicationUserSessionDataHeader sessionData, Guid inputOutputGroupUid, Guid permissionId, Guid entityId);
        InputOutputGroupClusterPermissionValidationResult GetInputOutputGroupClusterPermissionValidationResult(Guid clusterUid, Guid inputOutputGroupUid, short orderNumber);
        IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleId(Guid roleId);
        IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleIdAndClusterUid(Guid roleId, Guid clusterUid);
        Guid GetParentEntityId(Guid parentUid);
        IEnumerable<Guid> GetUidsForCluster(Guid clusterUid);

    }
}

