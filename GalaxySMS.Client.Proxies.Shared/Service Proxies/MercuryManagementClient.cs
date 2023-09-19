using System;
using System.Collections.Generic;
using GalaxySMS.Client.Contracts;
using GCS.Core.Common.ServiceModel;
using GCS.Core.Common.ServiceModel.Extensions;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;

namespace GalaxySMS.Client.Proxies
{
    [Export(typeof(IMercuryManagementService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [ApplicationUserSessionHeaderInspectorBehavior]
    public class MercuryManagementClient : UserClientBase<IMercuryManagementService>, IMercuryManagementService
    {
        #region MercScpIdReport operations
        #region Synchronous operations
        public MercScpIdReport[] GetAllMercScpIdReports(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllMercScpIdReports(parameters);
        }
        public MercScpIdReport[] GetMercScpIdReportsByMacAddress(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetMercScpIdReportsByMacAddress(parameters);
        }
        public MercScpIdReport[] GetMercScpIdReportsByModelAndSerialNumber(GetParametersWithPhoto parameters, string model)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetMercScpIdReportsByModelAndSerialNumber(parameters, model);
        }

        public MercScpIdReport GetMercScpIdReport(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetMercScpIdReport(parameters);
        }

        public MercScpIdReport InsertMercScpIdReport(SaveParameters<MercScpIdReport> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.InsertMercScpIdReport(parameters);
        }

        public int DeleteMercScpIdReportByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteMercScpIdReportByPk(parameters);
        }
        #endregion

        #region Async operations
        public Task<MercScpIdReport[]> GetAllMercScpIdReportsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllMercScpIdReportsAsync(parameters);
        }
        public Task<MercScpIdReport[]> GetMercScpIdReportsByMacAddressAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetMercScpIdReportsByMacAddressAsync(parameters);
        }
        public Task<MercScpIdReport[]> GetMercScpIdReportsByModelAndSerialNumberAsync(GetParametersWithPhoto parameters, string model)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetMercScpIdReportsByModelAndSerialNumberAsync(parameters, model);
        }

        public Task<MercScpIdReport> GetMercScpIdReportAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetMercScpIdReportAsync(parameters);
        }

        public Task<MercScpIdReport> InsertMercScpIdReportAsync(SaveParameters<MercScpIdReport> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.InsertMercScpIdReportAsync(parameters);
        }

        public Task<int> DeleteMercScpIdReportByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteMercScpIdReportByPkAsync(parameters);
        }
        #endregion
        #endregion

        #region MercScpGroup operations
        #region Synchronous operations

        public ArrayResponse<MercScpGroup> GetAllMercScpGroups(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllMercScpGroups(parameters);
        }

        public ArrayResponse<MercScpGroupListItemCommands> GetAllMercScpGroupsList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllMercScpGroupsList(parameters);
        }

        public ArrayResponse<MercScpGroup> GetAllMercScpGroupsForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllMercScpGroupsForEntity(parameters);
        }

        public ArrayResponse<MercScpGroupListItemCommands> GetAllMercScpGroupsForEntityList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllMercScpGroupsForEntityList(parameters);
        }

        public ArrayResponse<MercScpGroupMercScpMinimal> GetMercScpGroupsWithMercScpMinimal(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetMercScpGroupsWithMercScpMinimal(parameters);
        }

        public ArrayResponse<MercScpGroup> GetAllMercScpGroupsForSite(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllMercScpGroupsForSite(parameters);
        }

        public ArrayResponse<MercScpGroupListItemCommands> GetAllMercScpGroupsForSiteList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllMercScpGroupsForSiteList(parameters);
        }

        public MercScpGroup GetMercScpGroup(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetMercScpGroup(parameters);
        }

        public ValidationProblemDetails ValidateMercScpGroup(SaveParameters<MercScpGroup> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidateMercScpGroup(parameters);
        }

        public MercScpGroup SaveMercScpGroup(SaveParameters<MercScpGroup> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveMercScpGroup(parameters);
        }

        public int DeleteMercScpGroupByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteMercScpGroupByPk(parameters);
        }

        public int DeleteMercScpGroup(DeleteParameters<MercScpGroup> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteMercScpGroup(parameters);
        }

        public bool IsMercScpGroupReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsMercScpGroupReferenced(uid);
        }

        public bool IsMercScpGroupUnique(MercScpGroup data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsMercScpGroupUnique(data);
        }

        public MercScpGroupEditingData GetMercScpGroupEditingData(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetMercScpGroupEditingData(parameters);
        }

        #endregion

        #region Asynchronous operations

        public Task<ArrayResponse<MercScpGroup>> GetAllMercScpGroupsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllMercScpGroupsAsync(parameters);
        }

        public Task<ArrayResponse<MercScpGroupListItemCommands>> GetAllMercScpGroupsListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllMercScpGroupsListAsync(parameters);
        }

        public Task<ArrayResponse<MercScpGroup>> GetAllMercScpGroupsForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllMercScpGroupsForEntityAsync(parameters);
        }

        public Task<ArrayResponse<MercScpGroupListItemCommands>> GetAllMercScpGroupsForEntityListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllMercScpGroupsForEntityListAsync(parameters);
        }

        public Task<ArrayResponse<MercScpGroupMercScpMinimal>> GetMercScpGroupsWithMercScpMinimalAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetMercScpGroupsWithMercScpMinimalAsync(parameters);
        }

        public Task<ArrayResponse<MercScpGroup>> GetAllMercScpGroupsForSiteAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllMercScpGroupsForSiteAsync(parameters);
        }

        public Task<ArrayResponse<MercScpGroupListItemCommands>> GetAllMercScpGroupsForSiteListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllMercScpGroupsForSiteListAsync(parameters);
        }

        public Task<MercScpGroup> GetMercScpGroupAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetMercScpGroupAsync(parameters);
        }

        public Task<ValidationProblemDetails> ValidateMercScpGroupAsync(SaveParameters<MercScpGroup> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidateMercScpGroupAsync(parameters);
        }

        public Task<MercScpGroup> SaveMercScpGroupAsync(SaveParameters<MercScpGroup> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveMercScpGroupAsync(parameters);
        }

        public Task<int> DeleteMercScpGroupByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteMercScpGroupByPkAsync(parameters);
        }

        public Task<int> DeleteMercScpGroupAsync(DeleteParameters<MercScpGroup> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteMercScpGroupAsync(parameters);
        }

        public Task<bool> IsMercScpGroupReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsMercScpGroupReferencedAsync(uid);
        }

        public Task<bool> IsMercScpGroupUniqueAsync(MercScpGroup data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsMercScpGroupUniqueAsync(data);
        }

        public Task<MercScpGroupEditingData> GetMercScpGroupEditingDataAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetMercScpGroupEditingDataAsync(parameters);
        }
        #endregion
        #endregion

        #region MercScp operations
        #region Synchronous operations

        public ArrayResponse<MercScp> GetAllMercScps(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllMercScps(parameters);
        }

        public ArrayResponse<MercScp> GetAllMercScpsForMercScpGroup(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllMercScpsForMercScpGroup(parameters);
        }

        public ArrayResponse<MercScp> GetAllMercScpsForSite(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllMercScpsForSite(parameters);
        }

        public MercScp GetMercScp(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetMercScp(parameters);
        }

        public MercScp SaveMercScp(SaveParameters<MercScp> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveMercScp(parameters);
        }

        public SaveResponse<List<MercuryPanel>> SaveMercuryPanels(SaveParameters<List<MercuryPanel>> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveMercuryPanels(parameters);
        }

        public int DeleteMercScpByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteMercScpByPk(parameters);
        }

        public int DeleteMercScp(DeleteParameters<MercScp> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteMercScp(parameters);
        }

        public bool IsMercScpReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsMercScpReferenced(uid);
        }

        public bool IsMercScpUnique(MercScp data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsMercScpUnique(data);
        }

        public MercScpEditingData GetMercScpEditingData(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetMercScpEditingData(parameters);
        }

        public ArrayResponse<ActivityHistoryEvent> GetMercScpActivityHistoryEvents(ActivityHistoryEventSearchParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetMercScpActivityHistoryEvents(parameters);
        }

        public ValidationProblemDetails ValidateMercScp(SaveParameters<MercScp> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidateMercScp(parameters);
        }

        #endregion

        #region Asynchronous operations
        public Task<ArrayResponse<MercScp>> GetAllMercScpsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllMercScpsAsync(parameters);
        }

        public Task<ArrayResponse<MercScp>> GetAllMercScpsForMercScpGroupAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllMercScpsForMercScpGroupAsync(parameters);
        }

        public Task<ArrayResponse<MercScp>> GetAllMercScpsForSiteAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllMercScpsForSiteAsync(parameters);
        }

        public Task<MercScp> GetMercScpAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetMercScpAsync(parameters);
        }

        public Task<MercScp> SaveMercScpAsync(SaveParameters<MercScp> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveMercScpAsync(parameters);
        }

        public Task<SaveResponse<List<MercuryPanel>>> SaveMercuryPanelsAsync(SaveParameters<List<MercuryPanel>> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveMercuryPanelsAsync(parameters);
        }

        public Task<int> DeleteMercScpByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteMercScpByPkAsync(parameters);
        }

        public Task<int> DeleteMercScpAsync(DeleteParameters<MercScp> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteMercScpAsync(parameters);
        }

        public Task<bool> IsMercScpReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsMercScpReferencedAsync(uid);
        }

        public Task<bool> IsMercScpUniqueAsync(MercScp data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsMercScpUniqueAsync(data);
        }

        public Task<MercScpEditingData> GetMercScpEditingDataAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetMercScpEditingDataAsync(parameters);
        }

        public Task<ArrayResponse<ActivityHistoryEvent>> GetMercScpActivityHistoryEventsAsync(ActivityHistoryEventSearchParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetMercScpActivityHistoryEventsAsync(parameters);
        }

        public Task<ValidationProblemDetails> ValidateMercScpAsync(SaveParameters<MercScp> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidateMercScpAsync(parameters);
        }

        #endregion
        #endregion
    }
}
