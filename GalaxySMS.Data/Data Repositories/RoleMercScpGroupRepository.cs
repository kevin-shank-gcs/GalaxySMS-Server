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
using GCS.Core.Common.Shared.Utils;
using GCS.Core.Common.Utils;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;
using GCS.Framework.Caching;

namespace GalaxySMS.Data
{
    [Export(typeof(IRoleMercScpGroupRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RoleMercScpGroupRepository : DataRepositoryBase<RoleMercScpGroup>, IRoleMercScpGroupRepository, IPartImportsSatisfiedNotification
    {
        [Import] private IDataRepositoryFactory _dataRepositoryFactory;
        [Import] private ICacheManager _cacheManager;

        protected override RoleMercScpGroup AddEntity(RoleMercScpGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var mgr = new RoleMercScpGroupPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    //SaveEntityMappings(sessionData, entity.RoleMercScpGroupUid, entity);
                    var result = GetEntityByGuidId(entity.RoleMercScpGroupUid, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = false });
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleMercScpGroupRepository::AddEntity", ex);
                throw;
            }
        }

        protected override RoleMercScpGroup UpdateEntity(RoleMercScpGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.RoleMercScpGroupUid, sessionData, null);
                var mgr = new RoleMercScpGroupPDSAManager();

                // PDSA Audit Tracking setup phase
                if (mgr.DataObject.LoadByPK(entity.RoleMercScpGroupUid) >
                    0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        //SaveEntityMappings(sessionData, entity.RoleMercScpGroupUid, entity);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.RoleMercScpGroupUid, sessionData, new GetParametersWithPhoto()
                        {
                            RefreshCache = true,
                            IncludeMemberCollections = true
                        });
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity,
                            mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        return updatedEntity;
                    }

                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.RoleMercScpGroupUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleMercScpGroupRepository::UpdateEntity", ex);
                throw;
            }
        }

        private void EnsureChildRecordsExist(RoleMercScpGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            //if (!saveParams.Ignore(nameof(entity.AccessPortals)) && entity.AccessPortals != null)
            //    SaveAccessPortalFilters(entity, sessionData, saveParams);

            //if (!saveParams.Ignore(nameof(entity.InputDevices)) && entity.InputDevices != null)
            //    SaveInputDeviceFilters(entity, sessionData, saveParams);

            //if (!saveParams.Ignore(nameof(entity.OutputDevices)) && entity.OutputDevices != null)
            //    SaveOutputDeviceFilters(entity, sessionData, saveParams);

            //if (!saveParams.Ignore(nameof(entity.InputOutputGroups)) && entity.InputOutputGroups != null)
            //    SaveInputOutputGroupFilters(entity, sessionData, saveParams);
        }

        //private void SaveAccessPortalFilters(RoleMercScpGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        //{
        //    if (entity.AccessPortals == null || saveParams.Ignore(nameof(entity.AccessPortals)))
        //        return;

        //    // Don't support this capability
        //    //var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveRoleFiltersOption).ToString());

        //    //bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
        //    //                           !string.IsNullOrEmpty(kvpSaveOption.Value) &&
        //    //                           kvpSaveOption.Value == SaveRoleFiltersOption.DeleteMissingItems.ToString();

        //    var roleAccessPortalRepository = _dataRepositoryFactory.GetDataRepository<IRoleAccessPortalRepository>();
        //    var accessPortalRepository = _dataRepositoryFactory.GetDataRepository<IAccessPortalRepository>();
        //    var accessPortalUids = accessPortalRepository.GetAllPrimaryKeyUidsFromRoleIdAndMercScpGroupUid(entity.RoleId, entity.MercScpGroupUid);

        //    var existingAccessPortals = roleAccessPortalRepository.GetAllForRoleIdAndMercScpGroupUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.RoleId, MercScpGroupUid = entity.MercScpGroupUid, IncludeMemberCollections = true }).ToList();
        //    var addTheseAccessPortals = entity.AccessPortals.Where(o => existingAccessPortals.All(o2 => o2.AccessPortalUid != o.AccessPortalUid)).ToList();
        //    //var updateTheseAccessPortals = entity.AccessPortals.Where(o => existingAccessPortals.All(o2 => o2.AccessPortalUid == o.AccessPortalUid));

        //    if (entity.IncludeAllAccessPortals)
        //    {
        //        foreach (var accessPortalUid in accessPortalUids)
        //        {
        //            var existingRap = existingAccessPortals.FirstOrDefault(o => o.AccessPortalUid == accessPortalUid);
        //            if (existingRap == null)
        //            {
        //                var existingAddRc = addTheseAccessPortals.FirstOrDefault(o => o.AccessPortalUid == accessPortalUid);
        //                if (existingAddRc == null)
        //                {
        //                    addTheseAccessPortals.Add(new RoleAccessPortal()
        //                    {
        //                        AccessPortalUid = accessPortalUid,
        //                    });
        //                }
        //            }
        //        }
        //    }

        //    //var propsToInclude = new List<string>();

        //    //var propsToIgnore = new List<string>
        //    //{
        //    //    nameof(RoleAccessPortal.IsDirty),
        //    //    nameof(RoleAccessPortal.IsAnythingDirty),
        //    //    nameof(RoleAccessPortal.IsPanelDataDirty)
        //    //};

        //    //var dirtyRoleAccessPortals = new List<RoleAccessPortal>();
        //    //foreach (var rc in updateTheseAccessPortals)
        //    //{
        //    //    // Grab the existing item and see if any properties are different. If so, update the record
        //    //    var existingItem = existingAccessPortals.FirstOrDefault(o => o.AccessPortalUid == rc.AccessPortalUid);
        //    //    if (existingItem == null)
        //    //        continue;

        //    //    if (rc.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(rc, existingItem, propsToInclude, propsToIgnore))
        //    //    {
        //    //        dirtyRoleAccessPortals.Add(rc);
        //    //    }
        //    //}

        //    //// spin through all the dirty role MercScpGroup permissions
        //    //foreach (var rc in dirtyRoleAccessPortals)
        //    //{
        //    //    rc.RoleId = entity.RoleId;

        //    //    UpdateTableEntityBaseProperties(rc, sessionData);
        //    //    roleAccessPortalRepository.Update(rc, sessionData, null, saveParams);
        //    //}

        //    // spin through all the new role MercScpGroup permissions
        //    foreach (var rap in addTheseAccessPortals)
        //    {
        //        rap.RoleId = entity.RoleId;

        //        UpdateTableEntityBaseProperties(rap, sessionData);
        //        if (rap.RoleAccessPortalUid == Guid.Empty)
        //        {
        //            rap.RoleAccessPortalUid = GuidUtilities.GenerateComb();
        //            roleAccessPortalRepository.Add(rap, sessionData, saveParams);
        //        }
        //    }

        //    // Delete existing role MercScpGroups that are not included in the incoming data set if IncludeAllMercScpGroups is false
        //    if (!entity.IncludeAllAccessPortals)
        //    {
        //        var deleteTheseItems = existingAccessPortals.Where(c => entity.AccessPortals.All(c2 => c2.AccessPortalUid != c.AccessPortalUid)).ToList();
        //        foreach (var rap in deleteTheseItems)
        //        {
        //            // must explicitly delete the credential first
        //            roleAccessPortalRepository.Remove(rap.RoleAccessPortalUid, sessionData);
        //        }
        //    }
        //}

        //private void SaveInputDeviceFilters(RoleMercScpGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        //{
        //    if (entity.InputDevices == null || saveParams.Ignore(nameof(entity.InputDevices)))
        //        return;

        //    // Don't support this capability
        //    //var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveRoleFiltersOption).ToString());

        //    //bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
        //    //                           !string.IsNullOrEmpty(kvpSaveOption.Value) &&
        //    //                           kvpSaveOption.Value == SaveRoleFiltersOption.DeleteMissingItems.ToString();

        //    var roleInputDeviceRepository = _dataRepositoryFactory.GetDataRepository<IRoleInputDeviceRepository>();
        //    var inputDeviceRepository = _dataRepositoryFactory.GetDataRepository<IInputDeviceRepository>();
        //    var inputDeviceUids = inputDeviceRepository.GetAllPrimaryKeyUidsFromRoleIdAndMercScpGroupUid(entity.RoleId, entity.MercScpGroupUid);

        //    var existingInputDevices = roleInputDeviceRepository.GetAllForRoleIdAndMercScpGroupUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.RoleId, MercScpGroupUid = entity.MercScpGroupUid, IncludeMemberCollections = true }).ToList();
        //    var addTheseInputDevices = entity.InputDevices.Where(o => existingInputDevices.All(o2 => o2.InputDeviceUid != o.InputDeviceUid)).ToList();
        //    //var updateTheseAccessPortals = entity.InputDevices.Where(o => existingInputDevices.All(o2 => o2.InputDeviceUid == o.InputDeviceUid));

        //    if (entity.IncludeAllInputDevices)
        //    {
        //        foreach (var idUid in inputDeviceUids)
        //        {
        //            var existingRap = existingInputDevices.FirstOrDefault(o => o.InputDeviceUid == idUid);
        //            if (existingRap == null)
        //            {
        //                var existingAddRc = addTheseInputDevices.FirstOrDefault(o => o.InputDeviceUid == idUid);
        //                if (existingAddRc == null)
        //                {
        //                    addTheseInputDevices.Add(new RoleInputDevice()
        //                    {
        //                        InputDeviceUid = idUid,
        //                    });
        //                }
        //            }
        //        }
        //    }

        //    //var propsToInclude = new List<string>();

        //    //var propsToIgnore = new List<string>
        //    //{
        //    //    nameof(RoleAccessPortal.IsDirty),
        //    //    nameof(RoleAccessPortal.IsAnythingDirty),
        //    //    nameof(RoleAccessPortal.IsPanelDataDirty)
        //    //};

        //    //var dirtyRoleAccessPortals = new List<RoleAccessPortal>();
        //    //foreach (var rc in updateTheseAccessPortals)
        //    //{
        //    //    // Grab the existing item and see if any properties are different. If so, update the record
        //    //    var existingItem = existingAccessPortals.FirstOrDefault(o => o.AccessPortalUid == rc.AccessPortalUid);
        //    //    if (existingItem == null)
        //    //        continue;

        //    //    if (rc.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(rc, existingItem, propsToInclude, propsToIgnore))
        //    //    {
        //    //        dirtyRoleAccessPortals.Add(rc);
        //    //    }
        //    //}

        //    //// spin through all the dirty role MercScpGroup permissions
        //    //foreach (var rc in dirtyRoleAccessPortals)
        //    //{
        //    //    rc.RoleId = entity.RoleId;

        //    //    UpdateTableEntityBaseProperties(rc, sessionData);
        //    //    roleAccessPortalRepository.Update(rc, sessionData, null, saveParams);
        //    //}

        //    // spin through all the new role MercScpGroup permissions
        //    foreach (var rid in addTheseInputDevices)
        //    {
        //        rid.RoleId = entity.RoleId;

        //        UpdateTableEntityBaseProperties(rid, sessionData);
        //        if (rid.RoleInputDeviceUid == Guid.Empty)
        //        {
        //            rid.RoleInputDeviceUid = GuidUtilities.GenerateComb();
        //            roleInputDeviceRepository.Add(rid, sessionData, saveParams);
        //        }
        //    }

        //    // Delete existing role MercScpGroups that are not included in the incoming data set if IncludeAllMercScpGroups is false
        //    if (!entity.IncludeAllInputDevices)
        //    {
        //        var deleteTheseItems = existingInputDevices.Where(c => entity.InputDevices.All(c2 => c2.InputDeviceUid != c.InputDeviceUid)).ToList();
        //        foreach (var rap in deleteTheseItems)
        //        {
        //            // must explicitly delete the credential first
        //            roleInputDeviceRepository.Remove(rap.RoleInputDeviceUid, sessionData);
        //        }
        //    }
        //}

        //private void SaveOutputDeviceFilters(RoleMercScpGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        //{
        //    if (entity.OutputDevices == null || saveParams.Ignore(nameof(entity.OutputDevices)))
        //        return;

        //    // Don't support this capability
        //    //var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveRoleFiltersOption).ToString());

        //    //bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
        //    //                           !string.IsNullOrEmpty(kvpSaveOption.Value) &&
        //    //                           kvpSaveOption.Value == SaveRoleFiltersOption.DeleteMissingItems.ToString();

        //    var roleOutputDeviceRepository = _dataRepositoryFactory.GetDataRepository<IRoleOutputDeviceRepository>();
        //    var outputDeviceRepository = _dataRepositoryFactory.GetDataRepository<IOutputDeviceRepository>();
        //    var outputDeviceUids = outputDeviceRepository.GetAllPrimaryKeyUidsFromRoleIdAndMercScpGroupUid(entity.RoleId, entity.MercScpGroupUid);

        //    var existingOutputDevices = roleOutputDeviceRepository.GetAllForRoleIdAndMercScpGroupUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.RoleId, MercScpGroupUid = entity.MercScpGroupUid, IncludeMemberCollections = true }).ToList();
        //    var addTheseOutputDevices = entity.OutputDevices.Where(o => existingOutputDevices.All(o2 => o2.OutputDeviceUid != o.OutputDeviceUid)).ToList();
        //    //var updateTheseAccessPortals = entity.OutputDevices.Where(o => existingOutputDevices.All(o2 => o2.OutputDeviceUid == o.OutputDeviceUid));

        //    if (entity.IncludeAllOutputDevices)
        //    {
        //        foreach (var idUid in outputDeviceUids)
        //        {
        //            var existingRap = existingOutputDevices.FirstOrDefault(o => o.OutputDeviceUid == idUid);
        //            if (existingRap == null)
        //            {
        //                var existingAddRc = addTheseOutputDevices.FirstOrDefault(o => o.OutputDeviceUid == idUid);
        //                if (existingAddRc == null)
        //                {
        //                    addTheseOutputDevices.Add(new RoleOutputDevice()
        //                    {
        //                        OutputDeviceUid = idUid,
        //                    });
        //                }
        //            }
        //        }
        //    }

        //    //var propsToInclude = new List<string>();

        //    //var propsToIgnore = new List<string>
        //    //{
        //    //    nameof(RoleAccessPortal.IsDirty),
        //    //    nameof(RoleAccessPortal.IsAnythingDirty),
        //    //    nameof(RoleAccessPortal.IsPanelDataDirty)
        //    //};

        //    //var dirtyRoleAccessPortals = new List<RoleAccessPortal>();
        //    //foreach (var rc in updateTheseAccessPortals)
        //    //{
        //    //    // Grab the existing item and see if any properties are different. If so, update the record
        //    //    var existingItem = existingAccessPortals.FirstOrDefault(o => o.AccessPortalUid == rc.AccessPortalUid);
        //    //    if (existingItem == null)
        //    //        continue;

        //    //    if (rc.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(rc, existingItem, propsToInclude, propsToIgnore))
        //    //    {
        //    //        dirtyRoleAccessPortals.Add(rc);
        //    //    }
        //    //}

        //    //// spin through all the dirty role MercScpGroup permissions
        //    //foreach (var rc in dirtyRoleAccessPortals)
        //    //{
        //    //    rc.RoleId = entity.RoleId;

        //    //    UpdateTableEntityBaseProperties(rc, sessionData);
        //    //    roleAccessPortalRepository.Update(rc, sessionData, null, saveParams);
        //    //}

        //    // spin through all the new role MercScpGroup permissions
        //    foreach (var rid in addTheseOutputDevices)
        //    {
        //        rid.RoleId = entity.RoleId;

        //        UpdateTableEntityBaseProperties(rid, sessionData);
        //        if (rid.RoleOutputDeviceUid == Guid.Empty)
        //        {
        //            rid.RoleOutputDeviceUid = GuidUtilities.GenerateComb();
        //            roleOutputDeviceRepository.Add(rid, sessionData, saveParams);
        //        }
        //    }

        //    // Delete existing role MercScpGroups that are not included in the incoming data set if IncludeAllMercScpGroups is false
        //    if (!entity.IncludeAllOutputDevices)
        //    {
        //        var deleteTheseItems = existingOutputDevices.Where(c => entity.OutputDevices.All(c2 => c2.OutputDeviceUid != c.OutputDeviceUid)).ToList();
        //        foreach (var rap in deleteTheseItems)
        //        {
        //            // must explicitly delete the credential first
        //            roleOutputDeviceRepository.Remove(rap.RoleOutputDeviceUid, sessionData);
        //        }
        //    }
        //}

        //private void SaveInputOutputGroupFilters(RoleMercScpGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        //{
        //    if (entity.InputOutputGroups == null || saveParams.Ignore(nameof(entity.InputOutputGroups)))
        //        return;

        //    // Don't support this capability
        //    //var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveRoleFiltersOption).ToString());

        //    //bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
        //    //                           !string.IsNullOrEmpty(kvpSaveOption.Value) &&
        //    //                           kvpSaveOption.Value == SaveRoleFiltersOption.DeleteMissingItems.ToString();

        //    var roleInputOutputGroupRepository = _dataRepositoryFactory.GetDataRepository<IRoleInputOutputGroupRepository>();
        //    var inputOutputGroupRepository = _dataRepositoryFactory.GetDataRepository<IGalaxyInputOutputGroupRepository>();
        //    var inputOutputGroupUids = inputOutputGroupRepository.GetAllPrimaryKeyUidsFromRoleIdAndMercScpGroupUid(entity.RoleId, entity.MercScpGroupUid);

        //    var existingInputOutputGroups = roleInputOutputGroupRepository.GetAllForRoleIdAndMercScpGroupUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.RoleId, MercScpGroupUid = entity.MercScpGroupUid, IncludeMemberCollections = true }).ToList();
        //    var addTheseInputOutputGroups = entity.InputOutputGroups.Where(o => existingInputOutputGroups.All(o2 => o2.InputOutputGroupUid != o.InputOutputGroupUid)).ToList();
        //    //var updateTheseAccessPortals = entity.InputOutputGroups.Where(o => existingInputOutputGroups.All(o2 => o2.InputOutputGroupUid == o.InputOutputGroupUid));

        //    if (entity.IncludeAllInputOutputGroups)
        //    {
        //        foreach (var idUid in inputOutputGroupUids)
        //        {
        //            var existingRap = existingInputOutputGroups.FirstOrDefault(o => o.InputOutputGroupUid == idUid);
        //            if (existingRap == null)
        //            {
        //                var existingAddRc = addTheseInputOutputGroups.FirstOrDefault(o => o.InputOutputGroupUid == idUid);
        //                if (existingAddRc == null)
        //                {
        //                    addTheseInputOutputGroups.Add(new RoleInputOutputGroup()
        //                    {
        //                        InputOutputGroupUid = idUid,
        //                    });
        //                }
        //            }
        //        }
        //    }

        //    //var propsToInclude = new List<string>();

        //    //var propsToIgnore = new List<string>
        //    //{
        //    //    nameof(RoleAccessPortal.IsDirty),
        //    //    nameof(RoleAccessPortal.IsAnythingDirty),
        //    //    nameof(RoleAccessPortal.IsPanelDataDirty)
        //    //};

        //    //var dirtyRoleAccessPortals = new List<RoleAccessPortal>();
        //    //foreach (var rc in updateTheseAccessPortals)
        //    //{
        //    //    // Grab the existing item and see if any properties are different. If so, update the record
        //    //    var existingItem = existingAccessPortals.FirstOrDefault(o => o.AccessPortalUid == rc.AccessPortalUid);
        //    //    if (existingItem == null)
        //    //        continue;

        //    //    if (rc.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(rc, existingItem, propsToInclude, propsToIgnore))
        //    //    {
        //    //        dirtyRoleAccessPortals.Add(rc);
        //    //    }
        //    //}

        //    //// spin through all the dirty role MercScpGroup permissions
        //    //foreach (var rc in dirtyRoleAccessPortals)
        //    //{
        //    //    rc.RoleId = entity.RoleId;

        //    //    UpdateTableEntityBaseProperties(rc, sessionData);
        //    //    roleAccessPortalRepository.Update(rc, sessionData, null, saveParams);
        //    //}

        //    // spin through all the new role MercScpGroup permissions
        //    foreach (var rid in addTheseInputOutputGroups)
        //    {
        //        rid.RoleId = entity.RoleId;

        //        UpdateTableEntityBaseProperties(rid, sessionData);
        //        if (rid.RoleInputOutputGroupUid == Guid.Empty)
        //        {
        //            rid.RoleInputOutputGroupUid = GuidUtilities.GenerateComb();
        //            roleInputOutputGroupRepository.Add(rid, sessionData, saveParams);
        //        }
        //    }

        //    // Delete existing role MercScpGroups that are not included in the incoming data set if IncludeAllMercScpGroups is false
        //    if (!entity.IncludeAllInputOutputGroups)
        //    {
        //        var deleteTheseItems = existingInputOutputGroups.Where(c => entity.InputOutputGroups.All(c2 => c2.InputOutputGroupUid != c.InputOutputGroupUid)).ToList();
        //        foreach (var rap in deleteTheseItems)
        //        {
        //            // must explicitly delete the credential first
        //            roleInputOutputGroupRepository.Remove(rap.RoleInputOutputGroupUid, sessionData);
        //        }
        //    }
        //}


        protected override int DeleteEntity(RoleMercScpGroup entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new RoleMercScpGroupPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.RoleMercScpGroupUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);

                    if (_cacheManager?.IsInitialized == true)
                    {
                        var cacheKey = GetItemCacheKey(entity.RoleMercScpGroupUid);
                        var deleted = _cacheManager.DeleteCachedItem(cacheKey);
                    }
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleMercScpGroupRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new RoleMercScpGroupPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleMercScpGroupRepository::Remove", ex);
                throw;
            }
        }

        //private IEnumerable<RoleMercScpGroup> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, RoleMercScpGroupPDSAManager mgr)
        //{
        //    var pdsaEntities = mgr.BuildCollection();
        //    if (pdsaEntities != null)
        //    {
        //        var entities = mgr.ConvertPDSACollection(pdsaEntities);
        //        foreach (var entity in entities)
        //        {
        //            if (getParameters == null || getParameters.IncludeMemberCollections)
        //                FillMemberCollections(entity, null, getParameters);
        //        }
        //        return entities;
        //    }
        //    return null;
        //}

        private IEnumerable<RoleMercScpGroup> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, RoleMercScpGroupPDSAManager mgr)
        {
            IEnumerable<RoleMercScpGroup> entities = null;
            var cacheKey = string.Empty;
            switch (mgr.DataObject.SelectFilter)
            {
                case RoleMercScpGroupPDSAData.SelectFilters.All:
                    cacheKey = GetItemsCacheKey(Guid.Empty, $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}.{mgr.DataObject.SelectFilter}");
                    break;
                case RoleMercScpGroupPDSAData.SelectFilters.ByMercScpGroupUid:
                    cacheKey = GetItemsCacheKey(mgr.Entity.MercScpGroupUid, $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}.{mgr.DataObject.SelectFilter}");
                    break;
                case RoleMercScpGroupPDSAData.SelectFilters.ByRoleId:
                    cacheKey = GetItemsCacheKey(mgr.Entity.RoleId, $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}.{mgr.DataObject.SelectFilter}");
                    break;
                case RoleMercScpGroupPDSAData.SelectFilters.ByRoleIdAndSiteUid:
                    cacheKey = GetItemsCacheKey(mgr.Entity.RoleId, mgr.Entity.SiteUid, $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}.{mgr.DataObject.SelectFilter}");
                    break;
                //case RoleMercScpGroupPDSAData.SelectFilters.ByMercScpGroupAddress:
                //    break;
                //case RoleMercScpGroupPDSAData.SelectFilters.ListBox:
                    //    break;
                    //case RoleMercScpGroupPDSAData.SelectFilters.PrimaryKey:
                    //    break;
                    //case RoleMercScpGroupPDSAData.SelectFilters.Search:
                    //    break;
                    //case RoleMercScpGroupPDSAData.SelectFilters.Custom:
                    //    break;
                    //default:
                    //    throw new ArgumentOutOfRangeException();
            }
            if (CacheHelpers.ShouldReadFromCache(_cacheManager, getParameters) && !string.IsNullOrEmpty(cacheKey))
            {
                entities = _cacheManager.GetCachedItem<List<RoleMercScpGroup>>(cacheKey);
                if (entities == null) // if no cached item is found, set RefreshCache = true to force writing to cache
                    getParameters.RefreshCache = true;
            }

            if (entities == null || !entities.Any())
            {
                entities = new List<RoleMercScpGroup>();

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    entities = mgr.ConvertPDSACollection(pdsaEntities);
                    if (CacheHelpers.ShouldCacheBeUpdated(_cacheManager, getParameters) && !string.IsNullOrEmpty(cacheKey))
                    {
                        var bCached = _cacheManager.SetCachedItem(cacheKey, entities);
                    }
                }
            }

            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, null, getParameters);
                }
            }

            return entities;
        }

        // GetAllRoleMercScpGroups for an Entity
        protected override IEnumerable<RoleMercScpGroup> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetAllEntities(sessionData, getParameters);
            //try
            //{
            //    var mgr = new RoleMercScpGroupPDSAManager();
            //    mgr.DataObject.SelectFilter = RoleMercScpGroupPDSAData.SelectFilters.All;

            //    return GetIEnumerable(sessionData, getParameters, mgr);
            //}
            //catch (PDSAValidationException ex)
            //{
            //    DataValidationException dve = Converters.ConvertToDataValidationException(ex);
            //    throw dve;
            //}
            //catch (Exception ex)
            //{
            //    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleMercScpGroupRepository::GetEntities", ex);
            //    throw;
            //}
        }

        protected override IEnumerable<RoleMercScpGroup> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleMercScpGroupPDSAManager();
                mgr.DataObject.SelectFilter = RoleMercScpGroupPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleMercScpGroupRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IEnumerable<RoleMercScpGroup> GetAllForRoleId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleMercScpGroupPDSAManager();
                mgr.DataObject.SelectFilter = RoleMercScpGroupPDSAData.SelectFilters.ByRoleId;
                mgr.Entity.RoleId = getParameters.UniqueId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleMercScpGroupRepository::GetAllForRoleId", ex);
                throw;
            }
        }
        public IEnumerable<RoleMercScpGroup> GetAllForRoleIdAndSiteUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleMercScpGroupPDSAManager();
                mgr.DataObject.SelectFilter = RoleMercScpGroupPDSAData.SelectFilters.ByRoleIdAndSiteUid;
                mgr.Entity.RoleId = getParameters.UniqueId;
                mgr.Entity.SiteUid = getParameters.CurrentSiteUid;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleMercScpGroupRepository::GetAllForRoleId", ex);
                throw;
            }
        }

        public IEnumerable<RoleMercScpGroup> GetAllForMercScpGroupUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleMercScpGroupPDSAManager();
                mgr.DataObject.SelectFilter = RoleMercScpGroupPDSAData.SelectFilters.ByMercScpGroupUid;
                mgr.Entity.MercScpGroupUid = getParameters.UniqueId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleMercScpGroupRepository::GetAllForMercScpGroupUid", ex);
                throw;
            }
        }

        
        protected override RoleMercScpGroup GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override RoleMercScpGroup GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleMercScpGroupPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    RoleMercScpGroup result = new RoleMercScpGroup();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleMercScpGroupRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        private string GetItemCacheKey(Guid uid)
        {
            return CacheHelpers.GetCacheKey(typeof(RoleMercScpGroup), uid, false);
        }

        private string GetItemsCacheKey(Guid uid, string prefix)
        {
            return CacheHelpers.GetCacheKey(typeof(RoleMercScpGroup), uid, true, prefix);
        }

        private string GetItemsCacheKey(Guid uid, Guid uid2, string prefix)
        {
            return CacheHelpers.GetCacheKey(typeof(RoleMercScpGroup), uid, uid2, true, prefix);
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, RoleMercScpGroup originalEntity, RoleMercScpGroup newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "RoleMercScpGroupUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.RoleMercScpGroupUid;
                        mgr.Entity.RecordTag = newEntity.RoleMercScpGroupUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "RoleMercScpGroupUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.RoleMercScpGroupUid;
                        mgr.Entity.RecordTag = newEntity.RoleMercScpGroupUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "RoleMercScpGroupUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.RoleMercScpGroupUid;
                        mgr.Entity.RecordTag = originalEntity.RoleMercScpGroupUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleMercScpGroupRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(RoleMercScpGroup entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (getParameters == null)
                getParameters = new GetParametersWithPhoto();

            //if (!getParameters.IsExcluded(nameof(entity.AccessPortals)))
            //{
            //    var roleAccessPortalRepository =
            //        _dataRepositoryFactory.GetDataRepository<IRoleAccessPortalRepository>();
            //    entity.AccessPortals = roleAccessPortalRepository.GetAllForRoleIdAndMercScpGroupUid(sessionData,
            //        new GetParametersWithPhoto() { UniqueId = entity.RoleId, MercScpGroupUid = entity.MercScpGroupUid, RefreshCache = getParameters.RefreshCache}).ToCollection();
            //}

            //if (!getParameters.IsExcluded(nameof(entity.InputDevices)))
            //{
            //    var roleInputDeviceRepository =
            //        _dataRepositoryFactory.GetDataRepository<IRoleInputDeviceRepository>();
            //    entity.InputDevices = roleInputDeviceRepository.GetAllForRoleIdAndMercScpGroupUid(sessionData,
            //        new GetParametersWithPhoto() { UniqueId = entity.RoleId, MercScpGroupUid = entity.MercScpGroupUid, RefreshCache = getParameters.RefreshCache }).ToCollection();
            //}

            //if (!getParameters.IsExcluded(nameof(entity.OutputDevices)))
            //{
            //    var roleOutputDeviceRepository =
            //        _dataRepositoryFactory.GetDataRepository<IRoleOutputDeviceRepository>();
            //    entity.OutputDevices = roleOutputDeviceRepository.GetAllForRoleIdAndMercScpGroupUid(sessionData,
            //        new GetParametersWithPhoto() { UniqueId = entity.RoleId, MercScpGroupUid = entity.MercScpGroupUid, RefreshCache = getParameters.RefreshCache }).ToCollection();
            //}

            //if (!getParameters.IsExcluded(nameof(entity.InputOutputGroups)))
            //{
            //    var roleInputOutputGroupRepository =
            //        _dataRepositoryFactory.GetDataRepository<IRoleInputOutputGroupRepository>();
            //    entity.InputOutputGroups = roleInputOutputGroupRepository.GetAllForRoleIdAndMercScpGroupUid(sessionData,
            //        new GetParametersWithPhoto() { UniqueId = entity.RoleId, MercScpGroupUid = entity.MercScpGroupUid, RefreshCache = getParameters.RefreshCache }).ToCollection();
            //}

            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            //}
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("RoleMercScpGroup", "RoleMercScpGroupUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("RoleMercScpGroup", "RoleMercScpGroupUid", id);
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

        protected override bool IsEntityUnique(RoleMercScpGroup entity)
        {
            var mgr = new IsRoleMercScpGroupUniquePDSAManager();
            mgr.Entity.RoleMercScpGroupUid = entity.RoleMercScpGroupUid;
            mgr.Entity.RoleId = entity.RoleId;
            mgr.Entity.MercScpGroupUid = entity.MercScpGroupUid;

            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("RoleMercScpGroup", "RoleMercScpGroupUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("RoleMercScpGroup", "RoleMercScpGroupUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }


    }
}
