using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Common.Constants;
using GalaxySMS.Data.Contracts;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Reflection;
using GCS.Core.Common.Utils;
using GCS.Framework.Licensing;
using GCS.Framework.Licensing.Generator;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;

namespace GalaxySMS.Data
{
    [Export(typeof(IGcsSystemRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsSystemRepository : DataRepositoryBase<gcsSystem>, IGcsSystemRepository
    {
        protected override gcsSystem AddEntity(gcsSystem entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //this.Log().Info("GcsSystemRepository::AddEntity ValidateLicense");

                if (entity == null)
                    throw new ArgumentNullException("entity");

                EnsureTrialLicenseExists(entity);

                ValidateLicense(entity?.PublicKey, entity?.License);
                if (!string.IsNullOrEmpty(entity?.License))
                    entity.TheLicense = GCS.Core.Common.Utils.XmlUtilities.ConvertXmlStringtoObject<License>(entity.License);
                //this.Log().Info("GcsSystemRepository::AddEntity Creating gcsSystemPDSAManager");

                gcsSystemPDSAManager mgr = new gcsSystemPDSAManager();
                //this.Log()
                //    .InfoFormat(mgr != null
                //        ? "GcsSystemRepository::AddEntity Created gcsSystemPDSAManager"
                //        : "GcsSystemRepository::AddEntity gcsSystemPDSAManager is null");

                //this.Log().Info("GcsSystemRepository::AddEntity calling  mgr.InitEntityObject");
                mgr.InitEntityObject(entity);
                //this.Log().Info("GcsSystemRepository::AddEntity calling mgr.DataObject.Insert()");
                int rowCount = mgr.DataObject.Insert();
                //this.Log().InfoFormat("GcsSystemRepository::AddEntity rowCount = {0}", rowCount);
                if (rowCount > 0)
                {
                    //this.Log()
                    //    .Info(entity != null
                    //        ? "GcsSystemRepository::AddEntity GetEntityByGuidId"
                    //        : "GcsSystemRepository::AddEntity GetEntityByGuidId entity is null");
                    var result = GetEntityByGuidId(entity.SystemId, sessionData, null);
                    if (result != null)
                    {
                        //this.Log().InfoFormat("GcsSystemRepository::AddEntity mgr.DataObject.DBObjectName");
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        //this.Log().InfoFormat("GcsSystemRepository::AddEntity calling SaveAuditData");
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                    }
                    //this.Log().InfoFormat("GcsSystemRepository::AddEntity returning result");
                    return result;
                }
                //this.Log().InfoFormat("GcsSystemRepository::AddEntity returning entity");
                return entity;
            }
            catch (PDSAValidationException ex)
            {
                this.Log().InfoFormat("GcsSystemRepository::AddEntity caught PDSAValidationException");
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().InfoFormat("GcsSystemRepository::AddEntity caught Exception");
                var exTemp = ex;
                while (exTemp != null)
                {
                    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSystemRepository::AddEntity", exTemp);
                    exTemp = exTemp.InnerException;
                }

                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSystemRepository::AddEntity", ex);
                throw;
            }
        }

        public gcsSystem EnsureTrialLicenseExists(gcsSystem entity)
        {
            if (string.IsNullOrEmpty(entity?.License))
            {
                var trialLicenseRequest = new GenerateLicenseRequestData()
                {
                    LicenseType = Portable.Licensing.Prime.LicenseType.Trial,
                    ExpiresAt = DateTime.Now.AddDays(DefaultTrialLicenseValues.ValidForDays),
                    MaximumUtilizations = 5,
                };

                if (!string.IsNullOrEmpty(entity.CompanyName))
                    trialLicenseRequest.CustomerName = entity.CompanyName;

                if (!string.IsNullOrEmpty(entity.CompanyEmail))
                    trialLicenseRequest.EmailAddress = entity.CompanyEmail;

                trialLicenseRequest.Features.Add(LicenseFeatureKey.SoftwareLicenseKey.ToString(), "XXXXX-XXXXX-XXXXX-XXXXX-XXXX");
                trialLicenseRequest.Features.Add(LicenseFeatureKey.ServerThumbPrint.ToString(), GCS.Framework.Utilities.MachineThumbPrint.Value());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.ServerSystemNumber.ToString(), GCS.Framework.Utilities.SystemUtilities.GetLogicalDriveInfo(string.Empty).VolumeSerialNumberDecimal);
                trialLicenseRequest.Features.Add(LicenseFeatureKey.ProductLevel.ToString(), ProductLevel.Enterprise.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.Version.ToString(), GCS.Framework.Utilities.SystemUtilities.ExecutingAssembly.GetName().Version.Major.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.MaximumClients.ToString(), DefaultTrialLicenseValues.MaximumClients.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.MaximumAccessPortals.ToString(), DefaultTrialLicenseValues.MaximumAccessPortals.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.MaximumDsiAccessPortals.ToString(), DefaultTrialLicenseValues.MaximumDsiAccessPortals.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.MaximumInputDevices.ToString(), DefaultTrialLicenseValues.MaximumInputDevices.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.CanUpgradeVersions.ToString(), DefaultTrialLicenseValues.CanUpgradeVersions.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.BiometricMorphoManger.ToString(), DefaultTrialLicenseValues.BiometricMorphoManger.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.BiometricInvixiumIXMWeb.ToString(), DefaultTrialLicenseValues.BiometricInvixiumIXMWeb.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.BadgingSystemIdProducer.ToString(), DefaultTrialLicenseValues.BadgingSystemIdProducer.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.MaximumBadgePrinters.ToString(), DefaultTrialLicenseValues.MaximumBadgePrinters.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.GalaxyVms.ToString(), DefaultTrialLicenseValues.GalaxyVms.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.VmsApi.ToString(), DefaultTrialLicenseValues.VmsApi.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.VmsSystemLimit.ToString(), DefaultTrialLicenseValues.VmsSystemLimit.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.TimeAttendance.ToString(), DefaultTrialLicenseValues.TimeAttendance.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.ImportExport.ToString(), DefaultTrialLicenseValues.ImportExport.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.EventLogDistribution.ToString(), DefaultTrialLicenseValues.EventLogDistribution.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.UserStatus.ToString(), DefaultTrialLicenseValues.UserStatus.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.GuardTour.ToString(), DefaultTrialLicenseValues.GuardTour.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.AlarmPanelIntegration.ToString(), DefaultTrialLicenseValues.AlarmPanelIntegration.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.Passback.ToString(), DefaultTrialLicenseValues.Passback.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.DoorGroups.ToString(), DefaultTrialLicenseValues.DoorGroups.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.GraphicDeviceStatus.ToString(), DefaultTrialLicenseValues.GraphicDeviceStatus.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.UnlimitedCredentialCapability.ToString(), DefaultTrialLicenseValues.UnlimitedCredentialCapability.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.AccessRuleOverride.ToString(), DefaultTrialLicenseValues.AccessRuleOverride.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.ApiAccess.ToString(), DefaultTrialLicenseValues.ApiAccess.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.ApiCanGetPersonData.ToString(), DefaultTrialLicenseValues.ApiCanGetPersonData.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.ApiCanPostPersonData.ToString(), DefaultTrialLicenseValues.ApiCanPostPersonData.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.ApiCanPutPersonData.ToString(), DefaultTrialLicenseValues.ApiCanPutPersonData.ToString());
                trialLicenseRequest.Features.Add(LicenseFeatureKey.ApiCanDeletePersonData.ToString(), DefaultTrialLicenseValues.ApiCanDeletePersonData.ToString());
                trialLicenseRequest.Attributes.Add(LicenseAttributeKey.Attribute1.ToString(), false.ToString());
                trialLicenseRequest.Attributes.Add(LicenseAttributeKey.Attribute2.ToString(), false.ToString());
                var l = LicenseGenerator.GenerateLicense(trialLicenseRequest);

                entity.License = l.ToString();
                entity.PublicKey = l.PublicKey;
            }

            return entity;
        }

        //protected override gcsSystem UpdateEntity(gcsSystem entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        //{
        //    try
        //    {
        //        EnsureTrialLicenseExists(entity);

        //        ValidateLicense(entity.PublicKey, entity.License);

        //        var originalEntity = GetEntityByGuidId(entity.SystemId, sessionData, null);
        //        gcsSystemPDSAManager mgr = new gcsSystemPDSAManager();

        //        // PDSA Audit Tracking setup phase
        //        if (mgr.DataObject.LoadByPK(entity.SystemId) > 0) // must read the original record from the database so the PDSA object can detect changes
        //        {
        //            entity.InsertDate = mgr.Entity.InsertDate;
        //            entity.InsertName = mgr.Entity.InsertName;

        //            mgr.InitEntityObject(entity);
        //            int rowsUpdated = mgr.DataObject.Update();
        //            if (rowsUpdated > 0)
        //            {
        //                // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
        //                var updatedEntity = GetEntityByGuidId(entity.SystemId, sessionData, null);
        //                DataStoreTableName = mgr.DataObject.DBObjectName;
        //                SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
        //                return updatedEntity;
        //            }
        //            return entity;
        //        }
        //        throw new Exception($"{entity.GetType().Name} {entity.SystemId} not found");

        //    }
        //    catch (PDSAValidationException ex)
        //    {
        //        DataValidationException dve = Converters.ConvertToDataValidationException(ex);
        //        throw dve;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSystemRepository::UpdateEntity", ex);
        //        throw;
        //    }
        //}
        protected override gcsSystem UpdateEntity(gcsSystem entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.SystemId, sessionData, null);

                EnsureTrialLicenseExists(originalEntity);

                ValidateLicense(originalEntity.PublicKey, originalEntity.License);

                gcsSystemPDSAManager mgr = new gcsSystemPDSAManager();

                // PDSA Audit Tracking setup phase
                if (mgr.DataObject.LoadByPK(entity.SystemId) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    if (string.IsNullOrEmpty(entity.License))
                        entity.License = originalEntity.License;
                    if (string.IsNullOrEmpty(entity.PublicKey))
                        entity.PublicKey = originalEntity.PublicKey;

                    ValidateLicense(entity.PublicKey, entity.License);

                    if (!string.IsNullOrEmpty(entity?.License))
                        entity.TheLicense = GCS.Core.Common.Utils.XmlUtilities.ConvertXmlStringtoObject<License>(entity.License);

                    if (saveParams == null || saveParams.SavePhoto == false)
                    {
                        entity.SupportImage = originalEntity.SupportImage;
                        entity.SystemImage = originalEntity.SystemImage;
                    }

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.SystemId, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.SystemId} not found");

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSystemRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(gcsSystem entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsSystemPDSAManager mgr = new gcsSystemPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.SystemId);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSystemRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                gcsSystemPDSAManager mgr = new gcsSystemPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSystemRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsSystem> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsSystemPDSAManager mgr = new gcsSystemPDSAManager();

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    foreach (var e in entities)
                    {
                        if (!string.IsNullOrEmpty(e.PublicKey) && !string.IsNullOrEmpty(e.License))
                        {
                            ValidateLicense(e.PublicKey, e.License);
                            e.IsLicenseValid = true;
                        }
                    }
                    return entities;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSystemRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsSystem> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }

        protected override gcsSystem GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override gcsSystem GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsSystemPDSAManager mgr = new gcsSystemPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    gcsSystem result = new gcsSystem();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    if (!string.IsNullOrEmpty(result.License))
                    {
                        result.TheLicense = GCS.Core.Common.Utils.XmlUtilities.ConvertXmlStringtoObject<License>(result.License);
                        try
                        {
                            if (!string.IsNullOrEmpty(result.PublicKey) && !string.IsNullOrEmpty(result.License))
                            {
                                ValidateLicense(result.PublicKey, result.License);
                                result.IsLicenseValid = true;
                            }
                        }
                        catch (ApplicationException)
                        {
                        }
                        return result;
                    }
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSystemRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, gcsSystem originalEntity, gcsSystem newEntity, string auditXml)
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
                        propertiesToIgnore.Add("TheLicense"); propertiesToIgnore.Add("UpdateDate");
                        propertiesToIgnore.Add("UpdateName");
                        propertiesToIgnore.Add("ConcurrencyValue");
                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "SystemId";
                        mgr.Entity.PrimaryKeyValue = newEntity.SystemId;
                        mgr.Entity.RecordTag = "SystemData";
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        if (string.IsNullOrEmpty(auditXml) == false)
                        {// This must be commented out because the License xml data is not clean XML. An exception will be thrown when trying to insert auditXml that contains license data
                            //mgr.Entity.AuditXml = auditXml;
                            //mgr.Execute();
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
                        mgr.Entity.PrimaryKeyColumn = "SystemId";
                        mgr.Entity.PrimaryKeyValue = newEntity.SystemId;
                        mgr.Entity.RecordTag = "SystemData";
mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "SystemId";
                        mgr.Entity.PrimaryKeyValue = originalEntity.SystemId;
                        mgr.Entity.RecordTag = "SystemData";
mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSystemRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(gcsSystem entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {

        }

        protected override bool IsEntityReferenced(Guid id)
        {
            return false;
            //int count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("gcsSystem", "SystemId", id);
            //if (count == 0)
            //    return false;
            //return true;
        }

        protected override bool IsEntityReferenced(int id)
        {
            return false;
        }

        protected override bool CanEntityBeDeleted(Guid id)
        {
            return true;
            //int count = GalaxySMSDatabaseManager.CanRowBeDeleted("gcsSystem", "SystemId", id);
            //if (count == 0)
            //    return true;
            //return false;
        }

        protected override bool CanEntityBeDeleted(int id)
        {
            return true;
        }

        protected override bool IsEntityUnique(gcsSystem system)
        {
            return true;
            //gcs_IsLanguageUniquePDSAManager mgr = new gcs_IsLanguageUniquePDSAManager();
            //mgr.Entity.SystemId = system.SystemId;
            //mgr.Entity.LanguageName = language.LanguageName;
            //mgr.BuildCollection();


            //if (Convert.ToInt32(mgr.Entity.Result) == 0)
            //    return true;
            //return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("gcsSystem", "SystemId", id);
            if (count == 0)
                return false;
            return true;
        }

        protected override bool DoesEntityExist(int id)
        {
            return false;
        }

        private void ValidateLicense(string publicKey, string license)
        {
            LicenseGenerator.ValidateLicense(publicKey, license, Properties.Resources.ExceptionMessage_LicenseKeyInvalid, Properties.Resources.ExceptionMessage_LicenseInvalid);

            //if (string.IsNullOrEmpty(license) == false)
            //{
            //    if (string.IsNullOrEmpty(publicKey))
            //        throw new ApplicationException(Properties.Resources.ExceptionMessage_LicenseKeyInvalid);
            //    var licenseData = new LicenseData();
            //    if (licenseData.InitializeFromXmlString(publicKey, license) == false)
            //    {
            //        var validationMessages = new StringBuilder();
            //        foreach (var validationError in licenseData.LicenseValidationFailures)
            //        {
            //            validationMessages.Append(validationError.Message);
            //            validationMessages.Append(validationError.HowToResolve);
            //        }
            //        var innerEx = new ApplicationException(validationMessages.ToString());
            //        var ex = new ApplicationException(Properties.Resources.ExceptionMessage_LicenseInvalid, innerEx);
            //        throw ex;
            //    }
            //}
        }
    }
}
