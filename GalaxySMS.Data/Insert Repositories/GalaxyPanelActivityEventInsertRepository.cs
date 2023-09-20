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
    [Export(typeof(IGalaxyPanelActivityEventInsertRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxyPanelActivityEventInsertRepository : DataInsertRepositoryBase<GalaxyPanelActivityEvent>, IGalaxyPanelActivityEventInsertRepository
    {
        protected override void InsertEntity(GalaxyPanelActivityEvent entity)
        {
            try
            {
                if( entity.ActivityDateTime < DateTimeOffset.Now.MinSqlDateTime())
                    entity.ActivityDateTime = DateTimeOffset.Now.MinSqlDateTime();

                var mgr = new insert_GalaxyPanelActivityEventPDSAManager
                {
                    Entity =
                    {
                        GalaxyPanelActivityEventUid = entity.GalaxyPanelActivityEventUid,
                        GalaxyActivityEventTypeUid = entity.GalaxyActivityEventTypeUid,
                        GalaxyPanelUid = entity.GalaxyPanelUid
                    }
                };
                // GuidUtilities.GenerateComb();
                if (entity.CredentialUid.HasValue)
                    mgr.Entity.CredentialUid = entity.CredentialUid.Value;
                if (entity.PersonUid.HasValue)
                    mgr.Entity.PersonUid = entity.PersonUid.Value;
                if (entity.InputOutputGroupUid.HasValue)
                    mgr.Entity.InputOutputGroupUid = entity.InputOutputGroupUid.Value;
                if (entity.GalaxyInterfaceBoardUid.HasValue)
                    mgr.Entity.GalaxyInterfaceBoardUid = entity.GalaxyInterfaceBoardUid.Value;
                if (entity.GalaxyInterfaceBoardSectionUid.HasValue)
                    mgr.Entity.GalaxyInterfaceBoardSectionUid = entity.GalaxyInterfaceBoardSectionUid.Value;
                if (entity.GalaxyHardwareModuleUid.HasValue)
                    mgr.Entity.GalaxyHardwareModuleUid = entity.GalaxyHardwareModuleUid.Value;
                if (entity.GalaxyInterfaceBoardSectionNodeUid.HasValue)
                    mgr.Entity.GalaxyInterfaceBoardSectionNodeUid = entity.GalaxyInterfaceBoardSectionNodeUid.Value;

                mgr.Entity.ActivityDateTime = entity.ActivityDateTime;
                mgr.Entity.CpuUid = entity.CpuUid;
                mgr.Entity.CpuNumber = entity.CpuNumber;
                mgr.Entity.eventType = entity.EventType;
                mgr.Entity.BufferIndex = entity.BufferIndex;
                if (entity.InputOutputGroupNumber.HasValue)
                    mgr.Entity.InputOutputGroupNumber = entity.InputOutputGroupNumber.Value;
                if (entity.BoardNumber.HasValue)
                    mgr.Entity.BoardNumber = entity.BoardNumber.Value;
                if (entity.SectionNumber.HasValue)
                    mgr.Entity.SectionNumber = entity.SectionNumber.Value;
                if (entity.ModuleNumber.HasValue)
                    mgr.Entity.ModuleNumber = entity.ModuleNumber.Value;
                if (entity.NodeNumber.HasValue)
                    mgr.Entity.NodeNumber = entity.NodeNumber.Value;

                mgr.Entity.IsAlarmEvent = entity.IsAlarmEvent;
                if (entity.NoteUid.HasValue)
                    mgr.Entity.NoteUid = entity.NoteUid.Value;

                if (entity.BinaryResourceUid.HasValue)
                    mgr.Entity.BinaryResourceUid = entity.BinaryResourceUid.Value;

                mgr.Entity.AlarmPriority = entity.AlarmPriority;
                mgr.Entity.ResponseRequired = entity.ResponseRequired;
                mgr.Entity.InsertDate = DateTimeOffset.Now;
                mgr.Execute();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }

        }
    }
}
