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
    [Export(typeof(IInputDeviceActivityEventInsertRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class InputDeviceActivityEventInsertRepository : DataInsertRepositoryBase<InputDeviceActivityEvent>, IInputDeviceActivityEventInsertRepository
    {
        protected override void InsertEntity(InputDeviceActivityEvent entity)
        {
            try
            {
                //this.Log().InfoFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType.Name} => {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
                //this.Log().InfoFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
                if( entity.ActivityDateTime < DateTimeOffset.Now.MinSqlDateTime())
                    entity.ActivityDateTime = DateTimeOffset.Now.MinSqlDateTime();
                
                var mgr = new insert_InputDeviceActivityEventPDSAManager
                {
                    Entity =
                    {
                        InputDeviceActivityEventUid = GuidUtilities.GenerateComb(),
                        GalaxyActivityEventTypeUid = entity.GalaxyActivityEventTypeUid,
                        InputDeviceUid = entity.InputDeviceUid,
                        eventType = entity.EventType,
                        BufferIndex = entity.BufferIndex,
                        CpuUid = entity.CpuUid,
                        CpuNumber = entity.CpuNumber,
                        InsertDate = DateTimeOffset.Now,
                        ActivityDateTime = entity.ActivityDateTime,
                        IsAlarmEvent = entity.IsAlarmEvent
                    }
                };

                if (entity.NoteUid.HasValue)
                    mgr.Entity.NoteUid = entity.NoteUid.Value;

                if (entity.BinaryResourceUid.HasValue)
                    mgr.Entity.BinaryResourceUid = entity.BinaryResourceUid.Value;

                mgr.Entity.AlarmPriority = entity.AlarmPriority;
                mgr.Entity.ResponseRequired = entity.ResponseRequired;
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
