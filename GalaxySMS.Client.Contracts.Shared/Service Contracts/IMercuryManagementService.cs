using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.ServiceModel;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

#if NETCOREAPP
using GalaxySMS.Business.Entities.NetStd2;
namespace GalaxySMS.Client.Contracts.NetCore
#else
namespace GalaxySMS.Client.Contracts
#endif
{
    [ServiceContract]
    public interface IMercuryManagementService : IServiceContract
    {
        #region ScpIdReport Operations
        #region Synchronous operations
        [OperationContract]
        MercScpIdReport[] GetAllMercScpIdReports(GetParametersWithPhoto parameters);

        [OperationContract]
        MercScpIdReport[] GetMercScpIdReportsByMacAddress(GetParametersWithPhoto parameters);

        [OperationContract]
        MercScpIdReport[] GetMercScpIdReportsByModelAndSerialNumber(GetParametersWithPhoto parameters, string model);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        MercScpIdReport GetMercScpIdReport(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        MercScpIdReport InsertMercScpIdReport(SaveParameters<MercScpIdReport> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteMercScpIdReportByPk(DeleteParameters parameters);

        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //int DeleteMercScpIdReport(DeleteParameters<MercScpIdReport> parameters);

        //[OperationContract]
        //bool IsMercScpIdReportReferenced(Guid uid);

        //[OperationContract]
        //bool IsMercScpIdReportUnique(MercScpIdReport data);
        #endregion

        #region Async operations
        [OperationContract]
        Task<MercScpIdReport[]> GetAllMercScpIdReportsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<MercScpIdReport[]> GetMercScpIdReportsByMacAddressAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<MercScpIdReport[]> GetMercScpIdReportsByModelAndSerialNumberAsync(GetParametersWithPhoto parameters, string model);

        [OperationContract]
        Task<MercScpIdReport> GetMercScpIdReportAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<MercScpIdReport> InsertMercScpIdReportAsync(SaveParameters<MercScpIdReport> parameters);

        [OperationContract]
        Task<int> DeleteMercScpIdReportByPkAsync(DeleteParameters parameters);

        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //int DeleteMercScpIdReport(DeleteParameters<MercScpIdReport> parameters);

        //[OperationContract]
        //bool IsMercScpIdReportReferenced(Guid uid);

        //[OperationContract]
        //bool IsMercScpIdReportUnique(MercScpIdReport data);
        #endregion

        #endregion

        #region MercScpGroup Operations
        #region Synchronous operations
        [OperationContract]
        ArrayResponse<MercScpGroup> GetAllMercScpGroups(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<MercScpGroupListItemCommands> GetAllMercScpGroupsList(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<MercScpGroup> GetAllMercScpGroupsForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<MercScpGroupListItemCommands> GetAllMercScpGroupsForEntityList(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<MercScpGroupMercScpMinimal> GetMercScpGroupsWithMercScpMinimal(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<MercScpGroup> GetAllMercScpGroupsForSite(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<MercScpGroupListItemCommands> GetAllMercScpGroupsForSiteList(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        MercScpGroup GetMercScpGroup(GetParametersWithPhoto parameters);

        //[OperationContract]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //MercScpGroup GetMercScpGroupByHardwareAddress(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        ValidationProblemDetails ValidateMercScpGroup(SaveParameters<MercScpGroup> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        MercScpGroup SaveMercScpGroup(SaveParameters<MercScpGroup> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteMercScpGroupByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteMercScpGroup(DeleteParameters<MercScpGroup> parameters);

        [OperationContract]
        bool IsMercScpGroupReferenced(Guid uid);

        [OperationContract]
        bool IsMercScpGroupUnique(MercScpGroup data);

        [OperationContract]
        MercScpGroupEditingData GetMercScpGroupEditingData(GetParametersWithPhoto parameters);

        //[OperationContract]
        //LoadDataCommandResponse<MercScpGroupDataLoadParameters> SendMercScpGroupDataToPanels(CommandParameters<MercScpGroupDataLoadParameters> parameters);

        //[OperationContract]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //BackgroundJobInfo<LoadDataCommandResponse<MercScpGroupDataLoadParameters>> SendMercScpGroupDataToPanelsJob(CommandParameters<MercScpGroupDataLoadParameters> parameters);
        #endregion

        #region Asynchronous operations
        [OperationContract]
        Task<ArrayResponse<MercScpGroup>> GetAllMercScpGroupsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<MercScpGroupListItemCommands>> GetAllMercScpGroupsListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<MercScpGroup>> GetAllMercScpGroupsForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<MercScpGroupListItemCommands>> GetAllMercScpGroupsForEntityListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<MercScpGroupMercScpMinimal>> GetMercScpGroupsWithMercScpMinimalAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<MercScpGroup>> GetAllMercScpGroupsForSiteAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<MercScpGroupListItemCommands>> GetAllMercScpGroupsForSiteListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<MercScpGroup> GetMercScpGroupAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //MercScpGroup GetMercScpGroupByHardwareAddress(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ValidationProblemDetails> ValidateMercScpGroupAsync(SaveParameters<MercScpGroup> parameters);

        [OperationContract]
        Task<MercScpGroup> SaveMercScpGroupAsync(SaveParameters<MercScpGroup> parameters);

        [OperationContract]
        Task<int> DeleteMercScpGroupByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteMercScpGroupAsync(DeleteParameters<MercScpGroup> parameters);

        [OperationContract]
        Task<bool> IsMercScpGroupReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsMercScpGroupUniqueAsync(MercScpGroup data);

        [OperationContract]
        Task<MercScpGroupEditingData> GetMercScpGroupEditingDataAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<LoadDataCommandResponse<MercScpGroupDataLoadParameters>> SendMercScpGroupDataToPanelsAsync(CommandParameters<MercScpGroupDataLoadParameters> parameters);

        //[OperationContract]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //Task<BackgroundJobInfo<LoadDataCommandResponse<MercScpGroupDataLoadParameters>>> SendMercScpGroupDataToPanelsJobAsync(CommandParameters<MercScpGroupDataLoadParameters> parameters);
        #endregion
        #endregion

        #region Mercury Scp Operations
        #region Synchronous operations

        [OperationContract]
        ArrayResponse<MercScp> GetAllMercScps(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<MercScp> GetAllMercScpsForMercScpGroup(GetParametersWithPhoto parameters);

        //[OperationContract]
        //MercScp[] GetAllMercScpsForEntity(GetParametersWithPhoto parameters);

        //[OperationContract]
        //MercScp[] GetAllMercScpsForRegion(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<MercScp> GetAllMercScpsForSite(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        MercScp GetMercScp(GetParametersWithPhoto parameters);

        //[OperationContract]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //MercScp GetMercScpByHardwareAddress(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        MercScp SaveMercScp(SaveParameters<MercScp> parameters);


        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        SaveResponse<List<MercuryPanel>> SaveMercuryPanels(SaveParameters<List<MercuryPanel>> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteMercScpByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteMercScp(DeleteParameters<MercScp> parameters);

        [OperationContract]
        bool IsMercScpReferenced(Guid uid);

        [OperationContract]
        bool IsMercScpUnique(MercScp data);

        [OperationContract]
        //        MercScpEditingDataBasic GetMercScpEditingData(GetParametersWithPhoto parameters);
        MercScpEditingData GetMercScpEditingData(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<ActivityHistoryEvent> GetMercScpActivityHistoryEvents(ActivityHistoryEventSearchParameters parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        ValidationProblemDetails ValidateMercScp(SaveParameters<MercScp> parameters);
        #endregion

        #region Asynchronous operations

        [OperationContract]
        Task<ArrayResponse<MercScp>> GetAllMercScpsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<MercScp>> GetAllMercScpsForMercScpGroupAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<MercScp[]> GetAllMercScpsForEntityAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<MercScp[]> GetAllMercScpsForRegionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<MercScp>> GetAllMercScpsForSiteAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<MercScp> GetMercScpAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //Task<MercScp> GetMercScpByHardwareAddressAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<MercScp> SaveMercScpAsync(SaveParameters<MercScp> parameters);

        [OperationContract]
        Task<SaveResponse<List<MercuryPanel>>> SaveMercuryPanelsAsync(SaveParameters<List<MercuryPanel>> parameters);

        [OperationContract]
        Task<int> DeleteMercScpByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteMercScpAsync(DeleteParameters<MercScp> parameters);

        [OperationContract]
        Task<bool> IsMercScpReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsMercScpUniqueAsync(MercScp data);

        [OperationContract]
        //        MercScpEditingDataBasic GetMercScpEditingData(GetParametersWithPhoto parameters);
        Task<MercScpEditingData> GetMercScpEditingDataAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<ActivityHistoryEvent>> GetMercScpActivityHistoryEventsAsync(ActivityHistoryEventSearchParameters parameters);

        [OperationContract]
        Task<ValidationProblemDetails> ValidateMercScpAsync(SaveParameters<MercScp> parameters);
        #endregion
        #endregion
    }

}
