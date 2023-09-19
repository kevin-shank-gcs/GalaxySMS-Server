using GalaxySMS.Business.Entities;
using GalaxySMS.Common;
using GCS.Core.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Contracts
{
    [ServiceContract]
    public interface IPanelDataProcessingService
    {
        //[OperationContract]
        //[FaultContract(typeof(AuthorizationValidationException))]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //void SavePanelDataPacketLog(PanelDataPacketLog logData);


        //[OperationContract]
        //GalaxyCpuDatabaseInformation GetGalaxyCpuDatabaseInformation(CpuHardwareAddress cpuHardwareAddress);

        //[OperationContract]
        //GalaxyCpuDatabaseInformation GetGalaxyClusterPanelInformation(CpuHardwareAddress cpuHardwareAddress);

        //[OperationContract]
        //[FaultContract(typeof(AuthorizationValidationException))]
        ////[TransactionFlow(TransactionFlowOption.Allowed)]
        //bool UpdateGalaxyCpuConnection(GalaxyCpuConnection cpuConnection);

        #region Synchronous operations

        [OperationContract]
        [FaultContract(typeof(AuthorizationValidationException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void SavePanelDataPacketLog(PanelDataPacketLog logData);

        [OperationContract]
        GalaxyCpuDatabaseInformation GetGalaxyCpuDatabaseInformation(CpuHardwareAddress cpuHardwareAddress);

        [OperationContract]
        GalaxyCpuDatabaseInformation GetGalaxyClusterPanelInformation(CpuHardwareAddress cpuHardwareAddress);

        [OperationContract]
        [FaultContract(typeof(AuthorizationValidationException))]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        bool UpdateGalaxyCpuConnection(GalaxyCpuConnection cpuConnection);
        #endregion

        //#region Async operations
        //[OperationContract]
        //Task SavePanelDataPacketLogAsync(PanelDataPacketLog logData);

        //[OperationContract]
        //Task<GalaxyCpuDatabaseInformation> GetGalaxyCpuDatabaseInformationAsync(CpuHardwareAddress cpuHardwareAddress);

        //[OperationContract]
        //Task<GalaxyCpuDatabaseInformation> GetGalaxyClusterPanelInformationAsync(CpuHardwareAddress cpuHardwareAddress);

        //[OperationContract]
        //Task<bool> UpdateGalaxyCpuConnectionAsync(GalaxyCpuConnection cpuConnection);
        //#endregion

    }
}
