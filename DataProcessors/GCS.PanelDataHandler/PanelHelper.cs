using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Data;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Utils;
using GCS.PanelDataProcessors.Interfaces;
using GCS.PanelProtocols.Series6xx;

namespace GCS.PanelOutputDataHandlers
{
    public class PanelHelper
    {
        public static uint GetLastLogIndex(CpuIdentifer id)
        {
            try
            {
                var mgr = new GalaxyCpuLoggingControlRepository();
                var result = mgr.GetGalaxyCpuLoggingControlForAccountClusterPanelCpuNumbers(null, new GetParametersWithPhoto()
                {
                    ClusterGroupId = id.ClusterGroupId,
                    ClusterNumber = id.ClusterNumber,
                    PanelNumber = id.PanelNumber,
                    GetInt16 = id.CpuNumber
                });
                return (uint)result.LastLogIndex;

            }
            catch (Exception ex)
            {
                throw;
            }
            return 0;
        }

        public static GalaxyCpuDatabaseInformation GetCpuDatabaseInformation(CpuIdentifer id)
        {
            try
            {
                var mgr = new GalaxyCpuLoggingControlRepository();
                var result = mgr.GetGalaxyCpuDatabaseInformation(null, new GetParametersWithPhoto()
                {
                    ClusterGroupId = id.ClusterGroupId,
                    ClusterNumber = id.ClusterNumber,
                    PanelNumber = id.PanelNumber,
                    GetInt16 = id.CpuNumber
                });

                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
