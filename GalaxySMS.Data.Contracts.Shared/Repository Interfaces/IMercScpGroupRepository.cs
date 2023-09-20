using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IMercScpGroupRepository : IPagedDataRepository<MercScpGroup>, IHasGetEntityId
    {
        //IEnumerable<MercScpGroup> GetMercScpGroupsByMercScpGroupNumber(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        //IEnumerable<MercScpGroup> GetMercScpGroupsByMercScpGroupGroupId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        //MercScpGroup GetByHardwareAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<MercScpGroup> GetAllMercScpGroupsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<MercScpGroup> GetAllMercScpGroupsForSite(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        //IArrayResponse<MercScpGroupSelectionItemBasic> GetAllMercScpGroupSelectionItemsForEntityAndSite(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        //IArrayResponse<MercScpGroupSelectionItemBasic> GetAllMercScpGroupSelectionItemsForSite(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        //MercScpGroup_CommonPanelLoadData GetCommonPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        //MercScpGroup_GetHardwareAddress GetMercScpGroupHardwareAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters);
        //int GetAvailableMercScpGroupNumber(int MercScpGroupGroupId);
        bool DoesUserHavePermission(IApplicationUserSessionDataHeader sessionData, Guid MercScpGroupUid, Guid permissionId, Guid entityId);
        IEnumerable<Guid> GetAllPrimaryKeyUids();
        IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleId(Guid roleId);
        IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleIdAndSiteUid(Guid roleId, Guid siteUid);
        IArrayResponse<MercScpGroup> GetAllMercScpGroupsForEntityPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IArrayResponse<MercScpGroup> GetAllMercScpGroupsForSitePaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        bool VerifyEntityIdMatches(Guid MercScpGroupUid, Guid entityId);
        //Guid GetEntityId(int MercScpGroupGroupId, int MercScpGroupNumber);

        //IArrayResponse<MercScpGroupTimeScheduleItem> GetMercScpGroupTimeScheduleItemsBySchedule(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        //bool IsMercScpGroupAddressUnique(MercScpGroup entity);
        bool IsMercScpGroupNameUnique(MercScpGroup entity);

    }
}

