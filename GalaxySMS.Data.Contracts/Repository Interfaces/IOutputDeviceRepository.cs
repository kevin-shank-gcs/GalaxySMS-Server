using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IOutputDeviceRepository : IPagedDataRepository<OutputDevice>, IHasGetEntityId
    {
        IArrayResponse<OutputDevice> GetAllOutputDevicesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<OutputDevice> GetAllOutputDevicesForRegion(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<OutputDevice> GetAllOutputDevicesForSite(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        OutputDevice EnsureOutputDeviceExists(IApplicationUserSessionDataHeader sessionData, EnsureOutputDeviceExistsParameters parameters, ISaveParameters saveParams);
        IArrayResponse<OutputDevice> GetAllOutputDevicesForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<OutputDevice> GetAllOutputDevicesForGalaxyPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<OutputDeviceListItem> GetOutputDeviceListForGalaxyPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters);
        IArrayResponse<OutputDeviceListItem> GetOutputDeviceListItemsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters);
        OutputDeviceListItem GetOutputDeviceListItem(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters);
        OutputDevice_PanelLoadData GetOutputDevicePanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<OutputDevice_PanelLoadData> GetOutputDevicesPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<Guid> GetOutputDeviceUidsForInterfaceBoardSection(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<OutputDeviceSelectionItemBasic> GetAllOutputDeviceSelectionItemsForEntityAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        OutputDevice_GetHardwareInformation GetHardwareInformation(IApplicationUserSessionDataHeader sessionData, Guid inputDeviceUid);
        void UpdateGalaxyOutputDeviceLastLoadedDate(Guid cpuUid, Guid inputDeviceUid);
        IEnumerable<OutputDevice_PanelLoadData> GetModifiedPanelLoadDataForCpu(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<ActivityHistoryEvent> GetActivityHistoryEvents(IApplicationUserSessionDataHeader sessionData, ActivityHistoryEventSearchParameters parameters);
        IArrayResponse<OutputDevice> GetByNameOrComments(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<OutputDeviceListItem> GetListItemsByNameOrComments(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters);
        bool DoesUserHavePermission(IApplicationUserSessionDataHeader sessionData, Guid outputDeviceUid, Guid permissionId, Guid entityId);
        IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleId(Guid roleId);
        IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleIdAndClusterUid(Guid roleId, Guid clusterUid);

        IEnumerable<string> GetOutputDevicesByNameAndSite(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

