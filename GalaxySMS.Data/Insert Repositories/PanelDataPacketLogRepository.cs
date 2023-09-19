using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GCS.Core.Common.Data;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using PDSA.Validation;
using GCS.Core.Common.Utils;

namespace GalaxySMS.Data
{
    [Export(typeof(IPanelDataPacketLogInsertRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PanelDataPacketLogInsertRepository : DataInsertRepositoryBase<PanelDataPacketLog>, IPanelDataPacketLogInsertRepository
    {
        protected override void InsertEntity(PanelDataPacketLog entity)
        {
            try
            {
                var mgr = new PanelDataPacketLog_InsertPDSAManager
                {
                    Entity =
                    {
                        Id = GuidUtilities.GenerateComb(),
                        InsertDate = DateTimeOffset.Now,
                        UpdateDate = DateTimeOffset.Now,
                        Length = entity.Length,
                        Distribute = entity.Distribute,
                        ClusterGroupId = entity.ClusterGroupId,
                        ClusterId = entity.ClusterId,
                        PanelId = entity.PanelId,
                        CpuId = entity.CpuId,
                        BoardNumber = entity.BoardNumber,
                        SectionNumber = entity.SectionNumber,
                        SecondsFromWeekStart = entity.SecondsFromWeekStart,
                        Sequence = entity.Sequence,
                        RawData = entity.RawData,
                        Direction = entity.Direction
                    }
                };
                mgr.Execute();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }

        }
    }
}
