using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.ServiceModel;
using System.ServiceModel;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Contracts.NetCore
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
    }

}
