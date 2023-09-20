using GalaxySMS.Business.Contracts;
using GalaxySMS.Business.Entities;
using GalaxySMS.Data.Contracts;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using GalaxySMS.Data;
using GCS.Core.Common.ServiceModel.Extensions;

namespace GalaxySMS.Business.Managers
{
    [Export(typeof(IPanelDataProcessingService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
                    ConcurrencyMode = ConcurrencyMode.Multiple,
                    ReleaseServiceInstanceOnTransactionComplete = false,
                    TransactionTimeout = "00:10:00",// - Defaults to 00:00:00 (no timeout)
                    TransactionIsolationLevel = IsolationLevel.ReadUncommitted)] // defaults to Serializable
    [ApplicationUserSessionHeaderInspectorBehavior]
    public class PanelDataProcessingManager : ManagerBase, IPanelDataProcessingService
    {
        public PanelDataProcessingManager()
        {
        }

        public PanelDataProcessingManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        [Import]
        IDataRepositoryFactory _DataRepositoryFactory;

        [OperationBehavior(TransactionScopeRequired = true)]
        public void SavePanelDataPacketLog(Entities.PanelDataPacketLog logData)
        {
            ExecuteFaultHandledOperation(() =>
            {
                IPanelDataPacketLogInsertRepository logDataRepository = _DataRepositoryFactory.GetDataInsertRepository<IPanelDataPacketLogInsertRepository>();

                logDataRepository.Insert(logData);
            });
        }

        public GalaxyCpuDatabaseInformation GetGalaxyCpuDatabaseInformation(CpuHardwareAddress cpuHardwareAddress)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var mgr = new GalaxyCpuLoggingControlRepository();
                var result = mgr.GetGalaxyCpuDatabaseInformation(null, new GetParametersWithPhoto()
                {
                    ClusterGroupId = cpuHardwareAddress.ClusterGroupId,
                    ClusterNumber = cpuHardwareAddress.ClusterNumber,
                    PanelNumber = cpuHardwareAddress.PanelNumber,
                    GetInt16 = (Int16)cpuHardwareAddress.CpuId
                });

                return result;
            });
        }


        public GalaxyCpuDatabaseInformation GetGalaxyClusterPanelInformation(CpuHardwareAddress cpuHardwareAddress)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var mgr = new GalaxyCpuRepository();
                var result = mgr.GetGalaxyClusterPanelInformation(null, new GetHardwareAddressParameters()
                {
                    ClusterGroupId = cpuHardwareAddress.ClusterGroupId,
                    ClusterNumber = cpuHardwareAddress.ClusterNumber,
                    PanelNumber = cpuHardwareAddress.PanelNumber,
                    CpuNumber = (short)cpuHardwareAddress.CpuId
                });

                if (result != null)
                    return result.FirstOrDefault();
                return null;
            });
        }

        public bool UpdateGalaxyCpuConnection(GalaxyCpuConnection cpuConnection)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repo = new GalaxyCpuRepository();
                repo.SetGalaxyCpuConnection(cpuConnection);
                return true;
            });
        }

        public bool IsGalaxyPanelConnected(Guid galaxyPanelUid)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var mgr = new GalaxyPanelRepository();
                return mgr.IsPanelConnected(galaxyPanelUid);
            });
        }

    }
}
