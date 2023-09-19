using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Entities;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Exceptions;

namespace GalaxySMS.Client.Contracts
{
    [ServiceContract]
    public interface IPanelDataProcessingService : IServiceContract
    {
        #region Synchronous operations

        [OperationContract]
        [FaultContract(typeof(AuthorizationValidationException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void SavePanelDataPacketLog(PanelDataPacketLog logData);

        [OperationContract]
        GalaxyCpuDatabaseInformation GetGalaxyCpuDatabaseInformation(CpuHardwareAddress cpuHardwareAddress);

        [OperationContract]
        GalaxyCpuDatabaseInformation GetGalaxyClusterPanelInformation(CpuHardwareAddress cpuHardwareAddress);

        #endregion

        #region Async operations
        [OperationContract]
        Task SavePanelDataPacketLogAsync(PanelDataPacketLog logData);

        [OperationContract]
        Task<GalaxyCpuDatabaseInformation> GetGalaxyCpuDatabaseInformationAsync(CpuHardwareAddress cpuHardwareAddress);
        
        [OperationContract]
        Task<GalaxyCpuDatabaseInformation> GetGalaxyClusterPanelInformationAsync(CpuHardwareAddress cpuHardwareAddress);

        #endregion
    }
}
