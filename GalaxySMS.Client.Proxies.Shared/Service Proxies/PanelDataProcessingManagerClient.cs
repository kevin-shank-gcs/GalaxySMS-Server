using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net.Mime;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Client.Contracts;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.ServiceModel;
using GCS.Core.Common.ServiceModel.Extensions;
using GCS.Framework.Security;

namespace GalaxySMS.Client.Proxies
{
    [Export(typeof(IPanelDataProcessingService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [ApplicationUserSessionHeaderInspectorBehavior]
    public class PanelDataProcessingManagerClient : UserClientBase<IPanelDataProcessingService>, IPanelDataProcessingService
    {

        #region Synchronous operations

        public void SavePanelDataPacketLog(PanelDataPacketLog logData)
        {
            base.InsertUserDataToOutgoingHeader();
            Channel.SavePanelDataPacketLog(logData);
        }

        public GalaxyCpuDatabaseInformation GetGalaxyCpuDatabaseInformation(CpuHardwareAddress cpuHardwareAddress)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyCpuDatabaseInformation(cpuHardwareAddress);
        }

        public GalaxyCpuDatabaseInformation GetGalaxyClusterPanelInformation(CpuHardwareAddress cpuHardwareAddress)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyClusterPanelInformation(cpuHardwareAddress);
        }

        public bool UpdateGalaxyCpuConnection(GalaxyCpuConnection cpuConnection)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.UpdateGalaxyCpuConnection(cpuConnection);
        }



        #endregion

        #region Async operations
        public Task SavePanelDataPacketLogAsync(PanelDataPacketLog logData)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SavePanelDataPacketLogAsync(logData);
        }

        public Task<GalaxyCpuDatabaseInformation> GetGalaxyCpuDatabaseInformationAsync(CpuHardwareAddress cpuHardwareAddress)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyCpuDatabaseInformationAsync(cpuHardwareAddress);
        }

        public Task<GalaxyCpuDatabaseInformation> GetGalaxyClusterPanelInformationAsync(CpuHardwareAddress cpuHardwareAddress)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyClusterPanelInformationAsync(cpuHardwareAddress);
        }

        public Task<bool> UpdateGalaxyCpuConnectionAsync(GalaxyCpuConnection cpuConnection)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.UpdateGalaxyCpuConnectionAsync(cpuConnection);
        }

        #endregion


    }
}
