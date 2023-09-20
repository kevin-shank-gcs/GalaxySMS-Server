using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Data.Contracts;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GCS.Core.Common.Data;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using PDSA.Validation;
using System;
using System.ComponentModel.Composition;

namespace GalaxySMS.Data
{
    [Export(typeof(IAccessPortalActivityEventInsertRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccessPortalActivityEventInsertRepository : DataInsertRepositoryBase<AccessPortalActivityEvent>, IAccessPortalActivityEventInsertRepository
    {
        protected override void InsertEntity(AccessPortalActivityEvent entity)
        {
            try
            {
                //this.Log().InfoFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType.Name} => {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
                //this.Log().InfoFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
                //this.Log().InfoFormat($"entity.GalaxyActivityEventTypeUid: {entity.GalaxyActivityEventTypeUid}, entity.PersonExpirationModeUid: {entity.PersonExpirationModeUid}, entity.UsageCount: {entity.UsageCount}");
                if (entity.ActivityDateTime < DateTimeOffset.Now.MinSqlDateTime())
                    entity.ActivityDateTime = DateTimeOffset.Now.MinSqlDateTime();

                var isAccessGrantedEvent = (entity.GalaxyActivityEventTypeUid == GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.AccessGranted ||
                    entity.GalaxyActivityEventTypeUid == GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.AccessGrantedWithPinData ||
                    entity.GalaxyActivityEventTypeUid == GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.AccessGrantedNoCardCodeLookup);

                var mgr = new insert_AccessPortalActivityEventPDSAManager
                {
                    Entity =
                    {
                        AccessPortalActivityEventUid = entity.AccessPortalActivityEventUid,
                        GalaxyActivityEventTypeUid = entity.GalaxyActivityEventTypeUid,
                        AccessPortalUid = entity.AccessPortalUid
                    }
                };
                //GuidUtilities.GenerateComb();
                if (entity.CredentialUid.HasValue)
                    mgr.Entity.CredentialUid = entity.CredentialUid.Value;
                if (entity.PersonUid.HasValue)
                    mgr.Entity.PersonUid = entity.PersonUid.Value;
                mgr.Entity.eventType = entity.EventType;
                mgr.Entity.BufferIndex = entity.BufferIndex;

                mgr.Entity.CpuUid = entity.CpuUid;
                mgr.Entity.CpuNumber = entity.CpuNumber;
                mgr.Entity.InsertDate = DateTimeOffset.Now;
                mgr.Entity.ActivityDateTime = entity.ActivityDateTime;
                if (entity.CredentialBytes != null && entity.CredentialBytes.Length > 0)
                    mgr.Entity.CredentialBytes = entity.CredentialBytes;

                mgr.Entity.IsAlarmEvent = entity.IsAlarmEvent;
                if (entity.NoteUid.HasValue)
                    mgr.Entity.NoteUid = entity.NoteUid.Value;

                if (entity.BinaryResourceUid.HasValue)
                    mgr.Entity.BinaryResourceUid = entity.BinaryResourceUid.Value;

                mgr.Entity.AlarmPriority = entity.AlarmPriority;
                mgr.Entity.ResponseRequired = entity.ResponseRequired;
                mgr.Entity.IsAccessGrantedEvent = isAccessGrantedEvent;
                var ret = mgr.Execute();

                //this.Log().InfoFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}, mgr.Execute() returned: {ret}");

                if (isAccessGrantedEvent &&
                    entity.PersonExpirationModeUid == Common.Constants.PersonExpirationModeIds.ExpireByUsageCount &&
                    entity.UsageCount > 0)
                {
                    try
                    {
                        //this.Log().InfoFormat($"Decrimenting Usage Count: {entity.PersonCredentialUid}, Count:{entity.UsageCount}");
                        var usageCountMgr = new PersonCredential_DecrimentUsageCountPDSAManager();
                        usageCountMgr.Entity.PersonCredentialUid = entity.PersonCredentialUid;
                        usageCountMgr.Entity.StartingUsageCount = entity.UsageCount;
                        usageCountMgr.Execute();
                    }
                    catch (Exception ex)
                    {   // Swallow it up and don't re-throw
                        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} PersonCredential_DecrimentUsageCountPDSAManager.Execute() exception:  {ex.ToString()}");
                    }

                }
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
