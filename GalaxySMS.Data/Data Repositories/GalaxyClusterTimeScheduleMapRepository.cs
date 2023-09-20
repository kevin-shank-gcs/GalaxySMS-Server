using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Data.Contracts;
using System.Data.Entity;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Reflection;
using GCS.Core.Common.Utils;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Data
{
    [Export(typeof(IGalaxyClusterTimeScheduleMapRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxyClusterTimeScheduleMapRepository : DataRepositoryBase<GalaxyClusterTimeScheduleMap>, IGalaxyClusterTimeScheduleMapRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;

        protected override GalaxyClusterTimeScheduleMap AddEntity(GalaxyClusterTimeScheduleMap entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var mgr = new GalaxyClusterTimeScheduleMapPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.GalaxyClusterTimeScheduleMapUid, sessionData, null);
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                    }
                    return result;
                }
                return entity;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyClusterTimeScheduleMapRepository::AddEntity", ex);
                throw;
            }
        }

        protected override GalaxyClusterTimeScheduleMap UpdateEntity(GalaxyClusterTimeScheduleMap entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.GalaxyClusterTimeScheduleMapUid, sessionData, null);
                var mgr = new GalaxyClusterTimeScheduleMapPDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.GalaxyClusterTimeScheduleMapUid); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.GalaxyClusterTimeScheduleMapUid, sessionData, null);
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                    return updatedEntity;
                }
                return entity;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyClusterTimeScheduleMapRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(GalaxyClusterTimeScheduleMap entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new GalaxyClusterTimeScheduleMapPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.GalaxyClusterTimeScheduleMapUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyClusterTimeScheduleMapRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new GalaxyClusterTimeScheduleMapPDSAManager();

                // PDSA Audit Tracking setup phase
                int rowsDeleted = 0;
                int rowsLoaded = mgr.DataObject.LoadByPK(id); // must read the original record from the database so the PDSA object can detect changes
                if (rowsLoaded == 1 && originalEntity != null)
                {
                    rowsDeleted = mgr.DataObject.DeleteByPK(id);
                    if (rowsDeleted > 0)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Delete, sessionData, originalEntity, null, mgr.DataObject.AuditRowAsXml);
                    }
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyClusterTimeScheduleMapRepository::Remove", ex);
                throw;
            }
        }

        // GetAllGalaxyClusterTimeScheduleMaps in a region
        protected override IEnumerable<GalaxyClusterTimeScheduleMap> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyClusterTimeScheduleMapPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyClusterTimeScheduleMapPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyClusterTimeScheduleMapRepository::GetEntities", ex);
                throw;
            }
        }

        private IEnumerable<GalaxyClusterTimeScheduleMap> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, GalaxyClusterTimeScheduleMapPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (GalaxyClusterTimeScheduleMap entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, sessionData, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<GalaxyClusterTimeScheduleMap> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyClusterTimeScheduleMapPDSAManager();
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyClusterTimeScheduleMapRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyClusterTimeScheduleMap> GetAllGalaxyClusterTimeScheduleMapForSchedule(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyClusterTimeScheduleMapPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyClusterTimeScheduleMapPDSAData.SelectFilters.ByTimeScheduleUid;
                mgr.Entity.TimeScheduleUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyClusterTimeScheduleMapRepository::GetAllGalaxyClusterTimeScheduleMapForSchedule", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyClusterTimeScheduleMap> GetAllGalaxyClusterTimeScheduleMapForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyClusterTimeScheduleMapPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyClusterTimeScheduleMapPDSAData.SelectFilters.ByClusterUid;
                mgr.Entity.ClusterUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyClusterTimeScheduleMapRepository::GetAllGalaxyClusterTimeScheduleMapForCluster", ex);
                throw;
            }
        }
        protected override GalaxyClusterTimeScheduleMap GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override GalaxyClusterTimeScheduleMap GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyClusterTimeScheduleMapPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    GalaxyClusterTimeScheduleMap result = new GalaxyClusterTimeScheduleMap();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(result, sessionData, getParameters);
                    return result;
                }
                return null;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyClusterTimeScheduleMapRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        public GalaxyClusterTimeScheduleMap GetByClusterUidAndTimeScheduleUid(IApplicationUserSessionDataHeader sessionData, Guid clusterUid, Guid timeScheduleUid)
        {
            try
            {
                var mgr = new GalaxyClusterTimeScheduleMapPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyClusterTimeScheduleMapPDSAData.SelectFilters.ByClusterUidAndTimeScheduleUid;
                mgr.Entity.ClusterUid = clusterUid;
                mgr.Entity.TimeScheduleUid = timeScheduleUid;
                var entities = GetIEnumerable(sessionData, null, mgr);
                var entity = entities.FirstOrDefault();
                if (entity != null)
                {
                    GalaxyClusterTimeScheduleMap result = new GalaxyClusterTimeScheduleMap();
                    SimpleMapper.PropertyMap(entity, result);
                    return result;
                }
                return null;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyClusterTimeScheduleMapRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, GalaxyClusterTimeScheduleMap originalEntity, GalaxyClusterTimeScheduleMap newEntity, string auditXml)
        {
            try
            {
                if (!string.IsNullOrEmpty(auditXml))
                    auditXml = auditXml.EncodeForXml();
                var mgr = new gcsAudit_InsertPDSAManager();

                switch (operationType)
                {
                    case OperationType.Update:
                        if (newEntity == null)
                            throw new ArgumentNullException("newEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        List<String> propertiesToIgnore = new List<string>();
                        propertiesToIgnore.Add("UpdateDate");
                        propertiesToIgnore.Add("UpdateName");
                        propertiesToIgnore.Add("ConcurrencyValue");
                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "GalaxyClusterTimeScheduleMapUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyClusterTimeScheduleMapUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyClusterTimeScheduleMapUid.ToString();
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;

                        if (string.IsNullOrEmpty(auditXml) == false)
                        {
                            mgr.Entity.AuditXml = auditXml;
                            mgr.Execute();
                        }


                        mgr.Entity.AuditXml = null;

                        SimpleObjectDifferenceDetector.CompareResults differences = SimpleObjectDifferenceDetector.CompareObjects(originalEntity, newEntity, propertiesToIgnore);
                        foreach (var property in differences.PropertyChanges)
                        {
                            //System.Diagnostics.Trace.WriteLine(property.ToString());
                            mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                            mgr.Entity.ColumnName = property.Value.PropertyName;
                            if (property.Value.PropertyType == typeof(System.Byte[]))
                            {
                                mgr.Entity.OriginalValue = null;
                                mgr.Entity.NewValue = null;
                                mgr.Entity.OriginalBinaryValue = property.Value.OriginalValue as byte[];
                                mgr.Entity.NewBinaryValue = property.Value.NewValue as byte[];
                            }
                            else
                            {
                                mgr.Entity.OriginalValue = property.Value.OriginalValue?.ToString();
                                mgr.Entity.NewValue = property.Value.NewValue.ToString();
                                mgr.Entity.OriginalBinaryValue = null;
                                mgr.Entity.NewBinaryValue = null;
                            }
                            mgr.Execute();
                        }
                        break;

                    case OperationType.Insert:
                        if (newEntity == null)
                            throw new ArgumentNullException("newEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "GalaxyClusterTimeScheduleMapUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyClusterTimeScheduleMapUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyClusterTimeScheduleMapUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;

                    case OperationType.Delete:
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "GalaxyClusterTimeScheduleMapUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.GalaxyClusterTimeScheduleMapUid;
                        mgr.Entity.RecordTag = originalEntity.GalaxyClusterTimeScheduleMapUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyClusterTimeScheduleMapRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(GalaxyClusterTimeScheduleMap entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            //}
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("GalaxyClusterTimeScheduleMap", "GalaxyClusterTimeScheduleMapUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("GalaxyClusterTimeScheduleMap", "GalaxyClusterTimeScheduleMapUid", id);
            if (count == 0)
                return false;
            return true;
        }

        protected override bool IsEntityReferenced(int id)
        {
            return false;
        }

        protected override bool CanEntityBeDeleted(int id)
        {
            return true;
        }

        protected override bool IsEntityUnique(GalaxyClusterTimeScheduleMap entity)
        {
            var mgr = new IsGalaxyClusterTimeScheduleMapUniquePDSAManager();
            mgr.Entity.GalaxyClusterTimeScheduleMapUid = entity.GalaxyClusterTimeScheduleMapUid;
            mgr.Entity.TimeScheduleUid = entity.TimeScheduleUid;
            mgr.Entity.ClusterUid = entity.ClusterUid;
            mgr.Entity.PanelScheduleNumber = entity.PanelScheduleNumber;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("GalaxyClusterTimeScheduleMap", "GalaxyClusterTimeScheduleMapUid", id);
            if (count == 0)
                return false;
            return true;
        }

        protected override bool DoesEntityExist(int id)
        {
            return false;
        }

        protected override bool CanEntityBeDeleted(Guid id)
        {
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("GalaxyClusterTimeScheduleMap", "GalaxyClusterTimeScheduleMapUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public int GetLowestAvailablePanelTimeScheduleNumber(Guid clusterUid)
        {
            var mgr = new GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSAManager();
            mgr.Entity.ClusterUid = clusterUid;
            var results = mgr.BuildCollection();
            var r = results.FirstOrDefault();
            if (r != null)
                return r.PanelScheduleNumber;

            return 0;
        }

        public bool CanTimeScheduleBeUnmappedFromCluster(Guid timeScheduledUid, Guid clusterUid)
        {
            var mgr = new TimeSchedule_CanBeUnmappedFromClusterPDSAManager
            {
                Entity =
                {
                    timeScheduleUid = timeScheduledUid,
                    clusterUid = clusterUid
                }
            };
            var results = mgr.BuildCollection();
            var r = results.FirstOrDefault();
            if (r != null)
                return r.Count == 0;

            return false;
        }

        public TimeScheduleUsageData GetTimeScheduleUsageData(Guid timeScheduledUid, Guid clusterUid)
        {
            var data = new TimeScheduleUsageData();
            var tsClusterMgr = new GetTimeScheduleAndClusterNamesPDSAManager()
            {
                Entity =
                {
                    timeScheduleUid = timeScheduledUid,
                    clusterUid = clusterUid
                }
            };

            var tsClusterResults = tsClusterMgr.BuildCollection();
            if (tsClusterResults != null)
            {
                var tsCluster = tsClusterResults.FirstOrDefault();
                if (tsCluster != null)
                {
                    data.TimeScheduleName = tsCluster.TimeScheduleName;
                    data.TimeScheduleUid = timeScheduledUid;
                    data.ClusterUid = clusterUid;
                    data.ClusterName = tsCluster.ClusterName;

                    var mgr = new TimeSchedule_GetTimeScheduleUsageDataForClusterPDSAManager()
                    {
                        Entity =
                        {
                            timeScheduleUid = timeScheduledUid,
                            clusterUid = clusterUid
                        }
                    };
                    var results = mgr.BuildCollection();
                    foreach (var i in results.Where(o=>o.DataType == TimeScheduleUsageTypeDataType.AccessGroup.ToString() && string.IsNullOrEmpty(o.DeviceName)))
                    {
                        data.Mappings.AccessGroups.Add( new TimeScheduleUsageItem()
                        {
                            Id = i.Id,
                            Name = i.Name,
                            Type = i.Type_x,
                            ClusterUid = i.clusterUid
                        });
                    }

                    foreach (var i in results.Where(o => o.DataType == TimeScheduleUsageTypeDataType.AccessGroup.ToString()))
                    {
                        data.Mappings.AccessGroupAccessPortals.Add(new TimeScheduleUsageItemAccessGroupAccessPortal()
                        {
                            Id = i.Id,
                            Name = i.Name,
                            Type = i.Type_x,
                            AccessPortalName = i.DeviceName,
                            AccessPortalUid = i.DeviceUid,
                            ClusterUid = i.clusterUid
                        });
                    }
                    foreach (var i in results.Where(o => o.DataType == TimeScheduleUsageTypeDataType.AccessPortal.ToString()))
                    {
                        data.Mappings.AccessPortals.Add(new TimeScheduleUsageItem()
                        {
                            Id = i.Id,
                            Name = i.Name,
                            Type = i.Type_x,
                            ClusterUid = i.clusterUid
                        });
                    }

                    foreach (var i in results.Where(o => o.DataType == TimeScheduleUsageTypeDataType.GalaxyPanel.ToString()))
                    {
                        data.Mappings.GalaxyPanels.Add(new TimeScheduleUsageItem()
                        {
                            Id = i.Id,
                            Name = i.Name,
                            Type = i.Type_x,
                            ClusterUid = i.clusterUid
                        });
                    }

                    foreach (var i in results.Where(o => o.DataType == TimeScheduleUsageTypeDataType.InputOutputGroup.ToString()))
                    {
                        data.Mappings.InputOutputGroups.Add(new TimeScheduleUsageItem()
                        {
                            Id = i.Id,
                            Name = i.Name,
                            Type = i.Type_x,
                            ClusterUid = i.clusterUid
                        });

                    }

                    foreach (var i in results.Where(o => o.DataType == TimeScheduleUsageTypeDataType.InputDevice.ToString()))
                    {
                        data.Mappings.InputDevices.Add(new TimeScheduleUsageItem()
                        {
                            Id = i.Id,
                            Name = i.Name,
                            Type = i.Type_x,
                            ClusterUid = i.clusterUid
                        });

                    }

                    foreach (var i in results.Where(o => o.DataType == TimeScheduleUsageTypeDataType.OutputDevice.ToString()))
                    {
                        data.Mappings.OutputDevices.Add(new TimeScheduleUsageItem()
                        {
                            Id = i.Id,
                            Name = i.Name,
                            Type = i.Type_x,
                            ClusterUid = i.clusterUid
                        });

                    }

                    foreach (var i in results.Where(o => o.DataType == TimeScheduleUsageTypeDataType.PersonalAccessGroup.ToString()))
                    {
                        data.Mappings.People.Add(new TimeScheduleUsageItemPersonalAccessGroup()
                        {
                            Id = i.Id,
                            Name = i.Name,
                            Type = i.Type_x,
                            ClusterName = i.DeviceName,
                            ClusterUid = i.DeviceUid
                        });
                    }

                    if (data.IsUsed)
                    {
                        data.Message = 
                            "You should un-map the schedule from children data items before removing it from Cluster.";
                    }
                }
            }

            return data;
        }

        public void OnImportsSatisfied()
        {
        }
    }
}
