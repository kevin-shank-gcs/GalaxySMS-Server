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
    [Export(typeof(IActivityEventInsertRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ActivityEventInsertRepository : DataInsertRepositoryBase<ActivityEvent>, IActivityEventInsertRepository
    {
        protected override void InsertEntity(ActivityEvent entity)
        {
            try
            {
                //this.Log().InfoFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType.Name} => {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
                //this.Log().InfoFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
                //this.Log().InfoFormat($"entity.GalaxyActivityEventTypeUid: {entity.GalaxyActivityEventTypeUid}, entity.PersonExpirationModeUid: {entity.PersonExpirationModeUid}, entity.UsageCount: {entity.UsageCount}");
                var isAccessGrantedEvent = (entity.EventTypeUid == GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.AccessGranted ||
                                            entity.EventTypeUid == GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.AccessGrantedWithPinData ||
                                            entity.EventTypeUid == GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.AccessGrantedNoCardCodeLookup);

                if (entity.ActivityDateTime < DateTimeOffset.Now.MinSqlDateTime())
                    entity.ActivityDateTime = DateTimeOffset.Now.MinSqlDateTime();

                var mgr = new insert_ActivityEventPDSAManager()
                {
                    Entity =
                    {
                        ActivityEventUid = entity.ActivityEventUid,
                        ActivityDateTime = entity.ActivityDateTime,
                        EventTypeMessage = entity.EventTypeMessage,
                        ForeColor = entity.ForeColor,
                        DeviceName = entity.DeviceName,
                        SiteName = entity.SiteName,
                        EntityId = entity.EntityId,
                        DeviceUid = entity.DeviceUid,
                        EventTypeUid = entity.EventTypeUid,
                        DeviceType = entity.DeviceType,
                        LastName = entity.LastName,
                        FirstName = entity.FirstName,
                        IsTraced = entity.IsTraced,
                        CredentialDescription = entity.CredentialDescription,
                        ClusterName = entity.ClusterName,
                        InputOutputGroupName = entity.InputOutputGroupName,
                        EntityName = entity.EntityName,
                        EntityType = entity.EntityType,
                        BufferIndex = entity.BufferIndex,
                        CredentialBytes = entity.CredentialBytes,
                    }
                };
                if (entity.PersonUid.HasValue)
                    mgr.Entity.PersonUid = entity.PersonUid.Value;
                if (entity.CredentialUid.HasValue)
                    mgr.Entity.CredentialUid = entity.CredentialUid.Value;
                if (entity.ClusterUid.HasValue)
                    mgr.Entity.ClusterUid = entity.ClusterUid.Value;
                if( entity.ClusterNumber.HasValue)
                    mgr.Entity.ClusterNumber = entity.ClusterNumber.Value;
                if (entity.ClusterGroupId.HasValue)
                    mgr.Entity.ClusterGroupId = entity.ClusterGroupId.Value;
                if (entity.PanelNumber.HasValue)
                    mgr.Entity.PanelNumber = entity.PanelNumber.Value;
                if (entity.InputOutputGroupNumber.HasValue)
                    mgr.Entity.InputOutputGroupNumber = entity.InputOutputGroupNumber.Value;
                if (entity.CpuNumber.HasValue)
                    mgr.Entity.CpuNumber = entity.CpuNumber.Value;
                if (entity.BoardNumber.HasValue)
                    mgr.Entity.BoardNumber = entity.BoardNumber.Value;
                if (entity.SectionNumber.HasValue)
                    mgr.Entity.SectionNumber = entity.SectionNumber.Value;
                if (entity.ModuleNumber.HasValue)
                    mgr.Entity.ModuleNumber = entity.ModuleNumber.Value;
                if (entity.NodeNumber.HasValue)
                    mgr.Entity.NodeNumber = entity.NodeNumber.Value;
                if (entity.AlarmPriority.HasValue)
                    mgr.Entity.AlarmPriority = entity.AlarmPriority.Value;
                if (entity.ResponseRequired.HasValue)
                    mgr.Entity.ResponseRequired = entity.ResponseRequired.Value;


                //mgr.Entity.CpuUid = entity.CpuUid;

                mgr.Entity.IsAlarmEvent = entity.IsAlarmEvent;
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
