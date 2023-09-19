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
    [Export(typeof(IGalaxyRawActivityEventInsertRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxyRawActivityEventInsertRepository : DataInsertRepositoryBase<GalaxyRawActivityEvent>, IGalaxyRawActivityEventInsertRepository
    {
        protected override void InsertEntity(GalaxyRawActivityEvent entity)
        {
            try
            {
                if( entity.EventDateTime < DateTimeOffset.Now.MinSqlDateTime())
                    entity.EventDateTime = DateTimeOffset.Now.MinSqlDateTime();

                var mgr = new insert_GalaxyRawActivityEventPDSAManager
                {
                    Entity =
                    {
                        GalaxyRawActivityEventUid = GuidUtilities.GenerateComb(),
                        InsertDate = DateTimeOffset.Now,
                        ClusterGroupId = entity.ClusterGroupId,
                        ClusterNumber = entity.ClusterNumber,
                        PanelNumber = entity.PanelNumber,
                        CpuNumber = entity.CpuNumber,
                        EventDateTime = entity.EventDateTime,
                        EventType = entity.EventType,
                        BufferIndex = entity.BufferIndex
                    }
                };

                if (entity.CpuUid.HasValue)
                    mgr.Entity.CpuUid = entity.CpuUid.Value;
                if (entity.BoardNumber.HasValue)
                    mgr.Entity.BoardNumber = entity.BoardNumber.Value;
                if (entity.SectionNumber.HasValue)
                    mgr.Entity.SectionNumber = entity.SectionNumber.Value;
                if (entity.ModuleNumber.HasValue)
                    mgr.Entity.ModuleNumber = entity.ModuleNumber.Value;
                if (entity.NodeNumber.HasValue)
                    mgr.Entity.NodeNumber = entity.NodeNumber.Value;
                if (entity.CredentialBytes != null && entity.CredentialBytes.Length > 0)
                    mgr.Entity.CredentialBytes = entity.CredentialBytes;
                if (entity.Pin.HasValue)
                    mgr.Entity.Pin = entity.Pin.Value;
                if (entity.BitCount.HasValue)
                    mgr.Entity.BitCount = entity.BitCount.Value;
                if (entity.InputOutputGroupNumber.HasValue)
                    mgr.Entity.InputOutputGroupNumber = entity.InputOutputGroupNumber.Value;

                mgr.Entity.RawData = entity.RawData;
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
