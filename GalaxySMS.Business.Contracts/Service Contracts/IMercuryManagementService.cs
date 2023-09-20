using GalaxySMS.Business.Entities;
using GCS.Core.Common.ServiceModel;
using System;
using System.Collections.Generic;
using System.ServiceModel;
namespace GalaxySMS.Business.Contracts
{
    [ServiceContract]
    public interface IMercuryManagementService
    {
        //#region ScpType Operations
        //[OperationContract]
        //MercScpType[] GetAllMercScpTypes(GetParametersWithPhoto parameters);

        //[OperationContract]
        //ListItemBase[] GetAllMercScpTypesList(GetParametersWithPhoto parameters);

        //[OperationContract]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //MercScpType GetMercScpType(GetParametersWithPhoto parameters);

        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //MercScpType SaveMercScpType(SaveParameters<MercScpType> parameters);

        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //int DeleteMercScpTypeByPk(DeleteParameters parameters);

        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //int DeleteMercScpType(DeleteParameters<MercScpType> parameters);

        //[OperationContract]
        //bool IsMercScpTypeReferenced(Guid uid);

        //[OperationContract]
        //bool IsMercScpTypeUnique(MercScpType data);
        //#endregion

        //#region SioType Operations
        //[OperationContract]
        //MercSioType[] GetAllMercSioTypes(GetParametersWithPhoto parameters);

        //[OperationContract]
        //ListItemBase[] GetAllMercSioTypesList(GetParametersWithPhoto parameters);

        //[OperationContract]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //MercSioType GetMercSioType(GetParametersWithPhoto parameters);

        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //MercSioType SaveMercSioType(SaveParameters<MercSioType> parameters);

        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //int DeleteMercSioTypeByPk(DeleteParameters parameters);

        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //int DeleteMercSioType(DeleteParameters<MercSioType> parameters);

        //[OperationContract]
        //bool IsMercSioTypeReferenced(Guid uid);

        //[OperationContract]
        //bool IsMercSioTypeUnique(MercSioType data);
        //#endregion

        #region ScpIdReport Operations
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
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        MercScpIdReport InsertMercScpIdReport(SaveParameters<MercScpIdReport> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
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

        #region MercScpGroup Operations
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

        #region Galaxy Panel Operations
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

    }
}
