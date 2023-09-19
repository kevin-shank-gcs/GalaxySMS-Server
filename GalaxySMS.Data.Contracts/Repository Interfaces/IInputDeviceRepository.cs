using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    //public interface IInputDeviceRepository : IPagedDataRepository<InputDevice>
    //{
    //    IEnumerable<InputDevice> GetAllInputDevicesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    //    IEnumerable<InputDevice> GetAllInputDevicesForRegion(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    //    IEnumerable<InputDevice> GetAllInputDevicesForSite(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    //    InputDevice EnsureInputDeviceExists(IApplicationUserSessionDataHeader sessionData, EnsureInputDeviceExistsParameters parameters, ISaveParameters saveParams);
    //    IEnumerable<InputDevice> GetAllInputDevicesForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    //    IEnumerable<InputDevice> GetAllInputDevicesForGalaxyPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    //    IEnumerable<InputDeviceListItem> GetInputDeviceListForGalaxyPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters);
    //    IEnumerable<InputDeviceListItem> GetInputDeviceListItemsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters);
    //    InputDeviceListItem GetInputDeviceListItem(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters);
    //    InputDevice_PanelLoadData GetInputDevicePanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    //    IEnumerable<InputDevice_PanelLoadData> GetInputDevicesPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    //    IEnumerable<Guid> GetInputDeviceUidsForInterfaceBoardSection(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    //    IEnumerable<InputDeviceSelectionItemBasic> GetAllInputDeviceSelectionItemsForEntityAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    //    InputDevice_GetHardwareInformation GetHardwareInformation(IApplicationUserSessionDataHeader sessionData, Guid inputDeviceUid);
    //    void UpdateGalaxyInputDeviceLastLoadedDate(Guid cpuUid, Guid inputDeviceUid);
    //    IEnumerable<InputDevice_PanelLoadData> GetModifiedPanelLoadDataForCpu(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    //    IEnumerable<ActivityHistoryEvent> GetActivityHistoryEvents(IApplicationUserSessionDataHeader sessionData, ActivityHistoryEventSearchParameters parameters);
    //    IEnumerable<InputDevice> GetByNameOrComments(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    //    IEnumerable<InputDeviceListItem> GetListItemsByNameOrComments(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters);
    //    bool DoesUserHavePermission(IApplicationUserSessionDataHeader sessionData, Guid inputDeviceUid, Guid permissionId);

    //}
    public interface IInputDeviceRepository : IPagedDataRepository<InputDevice>, IHasGetEntityId
    {
        IArrayResponse<InputDevice> GetAllInputDevicesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<InputDevice> GetAllInputDevicesForRegion(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<InputDevice> GetAllInputDevicesForSite(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        InputDevice EnsureInputDeviceExists(IApplicationUserSessionDataHeader sessionData, EnsureInputDeviceExistsParameters parameters, ISaveParameters saveParams);
        IArrayResponse<InputDevice> GetAllInputDevicesForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<InputDevice> GetAllInputDevicesForGalaxyPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<InputDeviceListItem> GetInputDeviceListForGalaxyPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters);
        IArrayResponse<InputDeviceListItem> GetInputDeviceListItemsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters);
        InputDeviceListItem GetInputDeviceListItem(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters);
        InputDevice_PanelLoadData GetInputDevicePanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<InputDevice_PanelLoadData> GetInputDevicesPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<Guid> GetInputDeviceUidsForInterfaceBoardSection(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<InputDeviceSelectionItemBasic> GetAllInputDeviceSelectionItemsForEntityAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        InputDevice_GetHardwareInformation GetHardwareInformation(IApplicationUserSessionDataHeader sessionData, Guid inputDeviceUid);
        void UpdateGalaxyInputDeviceLastLoadedDate(Guid cpuUid, Guid inputDeviceUid);
        IEnumerable<InputDevice_PanelLoadData> GetModifiedPanelLoadDataForCpu(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<ActivityHistoryEvent> GetActivityHistoryEvents(IApplicationUserSessionDataHeader sessionData, ActivityHistoryEventSearchParameters parameters);
        IArrayResponse<InputDevice> GetByNameOrComments(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<InputDeviceListItem> GetListItemsByNameOrComments(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters);
        bool DoesUserHavePermission(IApplicationUserSessionDataHeader sessionData, Guid inputDeviceUid, Guid permissionId, Guid entityId);
        IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleId(Guid roleId);
        IEnumerable<Guid> GetAllPrimaryKeyUidsForEntityId(Guid entityId);
        IEnumerable<Guid> GetAllPrimaryKeyUidsForClusterUid(Guid clusterUid);

        IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleIdAndClusterUid(Guid roleId, Guid clusterUid);
        IArrayResponse<InputDeviceListItem> GetInputDevicesByNameAndSite(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters);

    }
}

