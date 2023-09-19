using GalaxySMS.Business.Entities;
using GalaxySMS.Data;
using GCS.PanelDataProcessors.Interfaces;
using System;

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
