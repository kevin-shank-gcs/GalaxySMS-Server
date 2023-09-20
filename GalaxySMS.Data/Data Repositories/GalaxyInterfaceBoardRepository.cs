using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using GalaxySMS.Data.Contracts;
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
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace GalaxySMS.Data
{
    [Export(typeof(IGalaxyInterfaceBoardRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxyInterfaceBoardRepository : DataRepositoryBase<GalaxyInterfaceBoard>, IGalaxyInterfaceBoardRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;

        [Import]
        private IGalaxyInterfaceBoardSectionRepository _galaxyInterfaceBoardSectionRepository;

        protected override GalaxyInterfaceBoard AddEntity(GalaxyInterfaceBoard entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var mgr = new GalaxyInterfaceBoardPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    //SaveEntityMappings(sessionData, entity.GalaxyInterfaceBoardUid, entity);
                    var result = GetEntityByGuidId(entity.GalaxyInterfaceBoardUid, sessionData, null);
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        result = GetEntityByGuidId(entity.GalaxyInterfaceBoardUid, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = true});
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardRepository::AddEntity", ex);
                throw;
            }
        }

        protected override GalaxyInterfaceBoard UpdateEntity(GalaxyInterfaceBoard entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.GalaxyInterfaceBoardUid, sessionData, null);
                var mgr = new GalaxyInterfaceBoardPDSAManager();

                // PDSA Audit Tracking setup phase
                if (mgr.DataObject.LoadByPK(entity.GalaxyInterfaceBoardUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    entity.GalaxyPanelUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.GalaxyPanelUid, entity.GalaxyPanelUid);
                    entity.InterfaceBoardTypeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.InterfaceBoardTypeUid, entity.InterfaceBoardTypeUid);

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        //SaveEntityMappings(sessionData, entity.GalaxyInterfaceBoardUid, entity);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.GalaxyInterfaceBoardUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        updatedEntity = GetEntityByGuidId(entity.GalaxyInterfaceBoardUid, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = true });
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.GalaxyInterfaceBoardUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(GalaxyInterfaceBoard entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.GalaxyInterfaceBoardUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new GalaxyInterfaceBoardPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<GalaxyInterfaceBoard> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, GalaxyInterfaceBoardPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (var entity in entities)
                {
                    if (getParameters != null && getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, null, getParameters);
                }
                return entities;
            }
            return null;
        }

        // GetAllGalaxyInterfaceBoards for an Entity
        protected override IEnumerable<GalaxyInterfaceBoard> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<GalaxyInterfaceBoard> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyInterfaceBoard> GetAllGalaxyInterfaceBoardsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardPDSAData.SelectFilters.ByClusterUid;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardRepository::GetAllGalaxyInterfaceBoardsForCluster", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyInterfaceBoard> GetAllGalaxyInterfaceBoardsForPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardPDSAData.SelectFilters.ByGalaxyPanelUid;
                mgr.Entity.GalaxyPanelUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardRepository::GetAllGalaxyInterfaceBoardsForPanel", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyInterfaceBoard> GetAllGalaxyInterfaceBoardsForPanelAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardPDSAData.SelectFilters.ByPanelAddress;
                mgr.Entity.ClusterGroupId = parameters.ClusterGroupId;
                mgr.Entity.ClusterNumber = (short)parameters.ClusterNumber;
                mgr.Entity.PanelNumber = (short)parameters.PanelNumber;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardRepository::GetAllGalaxyInterfaceBoardsForPanel", ex);
                throw;
            }
        }
        public Guid GetParentEntityId(Guid parentUid)
        {
            var mgr = new GetEntityIdForGalaxyPanelPDSAManager
            {
                Entity =
                {
                    uid = parentUid
                }
            };
            var results = mgr.BuildCollection();
            var r = results.FirstOrDefault();
            if (r != null)
                return r.EntityId;
            return Guid.Empty;
        }

        public Guid GetEntityId(Guid uid)
        {
            var mgr = new GetEntityIdForGalaxyInterfaceBoardPDSAManager
            {
                Entity =
                {
                    uid = uid
                }
            };
            var results = mgr.BuildCollection();
            var r = results.FirstOrDefault();
            if (r != null)
                return r.EntityId;
            return Guid.Empty;
        }


        protected override GalaxyInterfaceBoard GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override GalaxyInterfaceBoard GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    GalaxyInterfaceBoard result = new GalaxyInterfaceBoard();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    if (getParameters != null && getParameters.IncludeMemberCollections)
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        private void EnsureChildRecordsExist(GalaxyInterfaceBoard entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (!saveParams.Ignore(nameof(entity.InterfaceBoardSections)))
                SaveInterfaceBoardSections(entity, sessionData, saveParams);
        }

        private void SaveInterfaceBoardSections(GalaxyInterfaceBoard entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            //var createDefaultModulesOption = saveParams.OptionValue(SaveGalaxyInterfaceBoardOption.CreateDefaultModulesAndNodes.ToString());
            //var defaultIsActiveOption = saveParams.OptionValue(SaveGalaxyInterfaceBoardOption.DefaultIsActiveValue.ToString());
            //var createDefaultModules = false;
            //var defaultIsActive = false;
            //if ( bool.TryParse(createDefaultModulesOption, out createDefaultModules))
            //{

            //}
            //if (bool.TryParse(defaultIsActiveOption, out defaultIsActive))
            //{

            //}

            // Interface Board Sections
            var sections = _galaxyInterfaceBoardSectionRepository.GetAllGalaxyInterfaceBoardSectionsForInterfaceBoard(sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyInterfaceBoardUid });

            //// Now delete any that are no longer defined in the GalaxyPanel
            //foreach (var section in sections)
            //{
            //    // If the GalaxyInterfaceBoardSectionUid does not exist in the entity, then delete the item from the database
            //    var temp = entity.InterfaceBoardSections.FirstOrDefault(o => o.GalaxyInterfaceBoardSectionUid == section.GalaxyInterfaceBoardSectionUid);
            //    if (temp == null)
            //    {
            //        _galaxyInterfaceBoardSectionRepository.Remove(section.GalaxyInterfaceBoardSectionUid, sessionData, null);
            //    }
            //}

            var sects = entity.InterfaceBoardSections.ToList();

            // Make sure the section types are valid for the board type
            if (entity.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface600)
            {
                // Simply delete any that do not have a valid number
                var invalidSections = sects.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
                foreach (var s in invalidSections)
                {
                    sects.Remove(s);
                }

                // verify that there are 2 sections
                for (short x = 1; x <= 2; x++)
                {
                    var sx = sects.FirstOrDefault(o => o.SectionNumber == x);
                    if (sx == null)
                    {
                        sx = new GalaxyInterfaceBoardSection()
                        {
                            SectionNumber = x,
                            IsSectionActive = true,
                        };
                        sx.InterfaceBoardSectionModeUid = Common.Constants.DualReaderInterface600ModeIds.ReaderInterfaceMode_AccessPortal;
                        sects.Add(sx);
                    }
                    else
                    {
                        sx.IsSectionActive = sx.InterfaceBoardSectionModeUid == Common.Constants.DualReaderInterface600ModeIds.ReaderInterfaceMode_AccessPortal ||
                            sx.InterfaceBoardSectionModeUid == Common.Constants.DualReaderInterface600ModeIds.ReaderInterfaceMode_AccessPortal;
                    }
                    // Now verify that there is one module
                    List<GalaxyHardwareModule> mods = null;
                    if (sx.GalaxyHardwareModules == null)
                        mods = new List<GalaxyHardwareModule>();
                    else
                        mods = sx.GalaxyHardwareModules.ToList();

                    var invalidModules = mods.Where(o => o.ModuleNumber != 1).ToList();
                    foreach (var m in invalidModules)
                        mods.Remove(m);

                    if (mods.Count == 0)
                    {
                        mods.Add(new GalaxyHardwareModule());
                    }

                    foreach (var m in mods)
                    {
                        m.ModuleNumber = 1;
                        m.GalaxyHardwareModuleTypeUid = Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_ReaderPortModule;
                        m.IsModuleActive = true;
                        if (m.GalaxyInterfaceBoardSectionNodes == null)
                            m.GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNode>();

                        // now confirm the correct # of nodes
                        var nodes = m.GalaxyInterfaceBoardSectionNodes.ToList();
                        var invalidNodes = nodes.Where(o => o.ModuleNumber > 1).ToList();   // allow 0 or 1
                        foreach (var n in invalidNodes)
                            nodes.Remove(n);
                        if (nodes.Count == 0)
                            nodes.Add(new GalaxyInterfaceBoardSectionNode());

                        foreach (var n in nodes)
                        {
                            n.ModuleNumber = m.ModuleNumber;
                            n.NodeNumber = 1;
                            n.IsNodeActive = true;
                        }
                        m.GalaxyInterfaceBoardSectionNodes = nodes.ToCollection();
                    }
                    sx.GalaxyHardwareModules = mods.ToCollection();
                }

                foreach (var bs in sects)
                {
                    if (!bs.IsModeValidForBoardType(GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface600))
                        bs.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualReaderInterface600ModeIds.ReaderInterfaceMode_AccessPortal;
                    foreach (var m in bs.GalaxyHardwareModules)
                    {
                        if (m.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_ReaderPortModule)
                            m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_ReaderPortModule;
                    }
                }
            }
            else if (entity.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635)
            {
                // Simply delete any that do not have a valid number
                var invalidSections = sects.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
                foreach (var s in invalidSections)
                {
                    sects.Remove(s);
                }

                // verify that there are 2 sections
                for (short x = 1; x <= 2; x++)
                {
                    var sx = sects.FirstOrDefault(o => o.SectionNumber == x);
                    if (sx == null)
                    {
                        sx = new GalaxyInterfaceBoardSection()
                        {
                            SectionNumber = x,
                            IsSectionActive = true,
                            InterfaceBoardSectionModeUid = Common.Constants.DualReaderInterface635ModeIds.ReaderInterfaceMode_AccessPortal
                        };
                        sects.Add(sx);
                    }
                    else
                    {
                        sx.IsSectionActive = sx.InterfaceBoardSectionModeUid == Common.Constants.DualReaderInterface635ModeIds.ReaderInterfaceMode_AccessPortal ||
                            sx.InterfaceBoardSectionModeUid == Common.Constants.DualReaderInterface635ModeIds.ReaderInterfaceMode_CredentialReaderOnly;
                    }
                    // Now verify that there is one module
                    List<GalaxyHardwareModule> mods = null;
                    if (sx.GalaxyHardwareModules == null)
                        mods = new List<GalaxyHardwareModule>();
                    else
                        mods = sx.GalaxyHardwareModules.ToList();

                    var invalidModules = mods.Where(o => o.ModuleNumber > 1).ToList();// allow 0 or 1
                    foreach (var m in invalidModules)
                        mods.Remove(m);

                    if (mods.Count == 0)
                    {
                        mods.Add(new GalaxyHardwareModule());
                    }

                    foreach (var m in mods)
                    {
                        m.ModuleNumber = 1;
                        m.GalaxyHardwareModuleTypeUid = Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_ReaderPortModule;
                        m.IsModuleActive = true;
                        if (m.GalaxyInterfaceBoardSectionNodes == null)
                            m.GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNode>();

                        // now confirm the correct # of nodes
                        var nodes = m.GalaxyInterfaceBoardSectionNodes.ToList();
                        var invalidNodes = nodes.Where(o => o.ModuleNumber > 1).ToList();
                        foreach (var n in invalidNodes)
                            nodes.Remove(n);
                        if (nodes.Count == 0)
                            nodes.Add(new GalaxyInterfaceBoardSectionNode());

                        foreach (var n in nodes)
                        {
                            n.ModuleNumber = m.ModuleNumber;
                            n.NodeNumber = 1;
                            n.IsNodeActive = true;
                        }
                        m.GalaxyInterfaceBoardSectionNodes = nodes.ToCollection();
                    }
                    sx.GalaxyHardwareModules = mods.ToCollection();
                }
                foreach (var bs in sects)
                {
                    if (!bs.IsModeValidForBoardType(GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635))
                        bs.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualReaderInterface635ModeIds.ReaderInterfaceMode_AccessPortal;

                    foreach (var m in bs.GalaxyHardwareModules)
                    {
                        if (m.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_ReaderPortModule)
                            m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_ReaderPortModule;
                    }
                }
            }
            else if (entity.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DigitalInputOutput600)
            {
                // Simply delete any that do not have a valid number
                var invalidSections = sects.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
                foreach (var s in invalidSections)
                {
                    sects.Remove(s);
                }

                // verify that there are 2 sections. Section 1 = 4 Outputs, Section 2 = 8 Inputs
                for (short x = 1; x <= 2; x++)
                {
                    var sx = sects.FirstOrDefault(o => o.SectionNumber == x);
                    if (sx == null)
                    {
                        sx = new GalaxyInterfaceBoardSection()
                        {
                            SectionNumber = x,
                            IsSectionActive = true,
                        };
                        if (x == 1)
                        {
                            sx.InterfaceBoardSectionModeUid =
                               DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Outputs;
                        }
                        else
                        {
                            sx.InterfaceBoardSectionModeUid =
                                DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs;
                        }
                        sects.Add(sx);
                    }
                    sx.IsSectionActive = true;

                    // Now verify that there is one module
                    List<GalaxyHardwareModule> mods = null;
                    if (sx.GalaxyHardwareModules == null)
                        mods = new List<GalaxyHardwareModule>();
                    else
                        mods = sx.GalaxyHardwareModules.ToList();

                    if (x == 1)
                    {
                        var m = sx.GalaxyHardwareModules.FirstOrDefault(o => o.GalaxyHardwareModuleTypeUid == GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_DigitalInputOutputOutputModule);
                        if (m == null)
                        {
                            m = new GalaxyHardwareModule()
                            {
                                GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_DigitalInputOutputOutputModule,
                                ModuleNumber = 1
                            };

                            // Create nodes for each possible remote input module
                            for (var n = GalaxySMS.Common.Constants.GalaxyDigitalInputOutputModuleLimits.LowestDefinableOututNumber; n <= GalaxySMS.Common.Constants.GalaxyDigitalInputOutputModuleLimits.HighestDefinableOutputNumber; n++)
                            {
                                m.GalaxyInterfaceBoardSectionNodes.Add(new GalaxyInterfaceBoardSectionNode() { NodeNumber = n, IsNodeActive = true });
                            }

                            mods.Add(m);
                        }
                    }
                    else
                    {
                        var m = sx.GalaxyHardwareModules.FirstOrDefault(o => o.GalaxyHardwareModuleTypeUid == GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_DigitalInputOutputInputModule);
                        if (m == null)
                        {
                            m = new GalaxyHardwareModule()
                            {
                                GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_DigitalInputOutputInputModule,
                                ModuleNumber = 1
                            };

                            // Create nodes for each possible remote input module
                            for (var n = GalaxySMS.Common.Constants.GalaxyDigitalInputOutputModuleLimits.LowestDefinableInputNumber; n <= GalaxySMS.Common.Constants.GalaxyDigitalInputOutputModuleLimits.HighestDefinableInputNumber; n++)
                            {
                                m.GalaxyInterfaceBoardSectionNodes.Add(new GalaxyInterfaceBoardSectionNode() { NodeNumber = n, IsNodeActive = true });
                            }

                            mods.Add(m);
                        }
                    }

                    sx.GalaxyHardwareModules = mods.ToCollection();
                }


                foreach (var bs in sects)
                {
                    if (bs.SectionNumber == 1 && bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Outputs)
                    {
                        bs.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Outputs;
                        foreach (var m in bs.GalaxyHardwareModules)
                        {
                            if (m.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_DigitalInputOutputOutputModule)
                                m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_DigitalInputOutputOutputModule;
                        }

                    }
                    else if (bs.SectionNumber == 2 && bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs)
                    {
                        bs.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs;
                        foreach (var m in bs.GalaxyHardwareModules)
                        {
                            if (m.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_DigitalInputOutputInputModule)
                                m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_DigitalInputOutputInputModule;
                        }
                    }
                }
            }
            //else if (entity.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface600)
            //{
            //    // Simply delete any that do not have a valid number
            //    var invalidSections = sects.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
            //    foreach (var s in invalidSections)
            //    {
            //        sects.Remove(s);
            //    }

            //    foreach (var bs in sects)
            //    {
            //        if (bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimAba &&
            //            bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand &&
            //            bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio &&
            //            bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_CypressClockDisplay &&
            //            bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_ElevatorRelays &&
            //            bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_LCD_4x20Display &&
            //            bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_OutputRelays &&
            //            bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_SaltoSallis &&
            //            bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Shell &&
            //            bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Unused &&
            //            bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_VeridtCac)
            //            bs.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Unused;

            //        if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimAba ||
            //            bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand)
            //        {
            //            foreach (var m in bs.GalaxyHardwareModules)
            //            {
            //                if (m.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AllegionPIM)
            //                    m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AllegionPIM;
            //            }
            //        }
            //        else if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio)
            //        {
            //            foreach (var m in bs.GalaxyHardwareModules)
            //            {
            //                if (m.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AssaAbloyAperioHub)
            //                    m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AssaAbloyAperioHub;
            //            }
            //        }
            //        else if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_CypressClockDisplay)
            //        {
            //            foreach (var m in bs.GalaxyHardwareModules)
            //            {
            //                if (m.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_CypressLCD)
            //                    m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_CypressLCD;
            //            }
            //        }
            //        else if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_ElevatorRelays)
            //        {
            //            foreach (var m in bs.GalaxyHardwareModules)
            //            {
            //                if (m.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RelayModule8)
            //                    m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RelayModule8;
            //            }
            //        }
            //        else if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_LCD_4x20Display)
            //        {
            //            foreach (var m in bs.GalaxyHardwareModules)
            //            {
            //                if (m.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_CypressLCD)
            //                    m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_CypressLCD;
            //            }
            //        }
            //        else if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_OutputRelays)
            //        {
            //            foreach (var m in bs.GalaxyHardwareModules)
            //            {
            //                if (m.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RelayModule8)
            //                    m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RelayModule8;
            //            }
            //        }
            //        else if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_SaltoSallis)
            //        {
            //            foreach (var m in bs.GalaxyHardwareModules)
            //            {
            //                if (m.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_SaltoSallisHub)
            //                    m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_SaltoSallisHub;
            //            }
            //        }
            //        else if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_VeridtCac)
            //        {
            //            foreach (var m in bs.GalaxyHardwareModules)
            //            {
            //            }
            //        }
            //        else if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Shell)
            //        {
            //            foreach (var m in bs.GalaxyHardwareModules)
            //            {
            //            }
            //        }
            //        else if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Unused)
            //        {
            //            foreach (var m in bs.GalaxyHardwareModules)
            //            {
            //            }
            //        }
            //    }
            //}
            else if (entity.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface635)
            {
                // Simply delete any that do not have a valid number
                var invalidSections = sects.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
                foreach (var s in invalidSections)
                {
                    sects.Remove(s);
                }

                // ensure two sections exist
                for (short x = 1; x <= 2; x++)
                {
                    var sx = sects.FirstOrDefault(o => o.SectionNumber == x);
                    if (sx == null)
                    {
                        sx = new GalaxyInterfaceBoardSection()
                        {
                            SectionNumber = x,
                            IsSectionActive = true,
                            InterfaceBoardSectionModeUid = Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Unused
                        };
                        sects.Add(sx);
                    }
                    sx.IsSectionActive = sx.InterfaceBoardSectionModeUid != Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Unused;
                }



                foreach (var bs in sects)
                {
                    if (bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimAba &&
                        bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand &&
                        bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio &&
                        bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_CypressClockDisplay &&
                        bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_ElevatorRelays &&
                        bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_LCD_4x20Display &&
                        bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_OutputRelays &&
                        bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_SaltoSallis &&
                        bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Shell &&
                        bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Unused &&
                        bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_VeridtCac &&
                        bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485InputModule &&
                        bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485DoorModule)
                        bs.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Unused;

                    if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimAba ||
                        bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand)
                    {
                        foreach (var m in bs.GalaxyHardwareModules)
                        {
                            if (m.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AllegionPIM)
                                m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AllegionPIM;
                        }
                    }
                    else if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio)
                    {
                        foreach (var m in bs.GalaxyHardwareModules)
                        {
                            if (m.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AssaAbloyAperioHub)
                                m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AssaAbloyAperioHub;
                        }
                    }
                    else if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_CypressClockDisplay)
                    {
                        foreach (var m in bs.GalaxyHardwareModules)
                        {
                            if (m.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_CypressLCD)
                                m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_CypressLCD;
                        }
                    }
                    else if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_ElevatorRelays)
                    {
                        foreach (var m in bs.GalaxyHardwareModules)
                        {
                            if (m.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RelayModule8)
                                m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RelayModule8;
                        }
                    }
                    else if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_LCD_4x20Display)
                    {
                        foreach (var m in bs.GalaxyHardwareModules)
                        {
                            if (m.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_CypressLCD)
                                m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_CypressLCD;
                        }
                    }
                    else if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_OutputRelays)
                    {
                        foreach (var m in bs.GalaxyHardwareModules)
                        {
                            if (m.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RelayModule8)
                                m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RelayModule8;
                        }
                    }
                    else if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_SaltoSallis)
                    {
                        foreach (var m in bs.GalaxyHardwareModules)
                        {
                            if (m.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_SaltoSallisHub)
                                m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_SaltoSallisHub;
                        }
                    }
                    else if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485DoorModule)
                    {
                        List<GalaxyHardwareModule> mods = null;
                        if (bs.GalaxyHardwareModules == null)
                            mods = new List<GalaxyHardwareModule>();
                        else
                            mods = bs.GalaxyHardwareModules.ToList();

                        // Discard any modules that have an invalid ModuleNumber                        
                        var invalidModules = mods.Where(o => o.ModuleNumber < DualSerialChannel_DoorModuleLimits.LowestDefinableModuleNumber || o.ModuleNumber > DualSerialChannel_DoorModuleLimits.HighestDefinableModuleNumber).ToList();
                        foreach (var m in invalidModules)
                            mods.Remove(m);

                        if (mods.Count == 0)
                        {
                            mods.Add(new GalaxyHardwareModule() { ModuleNumber = DualSerialChannel_DoorModuleLimits.LowestDefinableModuleNumber });
                        }

                        // There should only be one modu
                        foreach( var m in mods)
                        { 
                            m.ModuleNumber = 1;
                            m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RemoteDoorModule;
                            m.IsModuleActive = true;
                            if (m.GalaxyInterfaceBoardSectionNodes == null)
                                m.GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNode>();

                            // now confirm the correct # of nodes
                            var nodes = m.GalaxyInterfaceBoardSectionNodes.ToList();
                            var invalidNodes = nodes.Where(o => o.NodeNumber < GalaxySMS.Common.Constants.DualSerialChannel_DoorModuleLimits.LowestNodeNumber ||
                            o.NodeNumber > DualSerialChannel_DoorModuleLimits.HighestNodeNumber).ToList();
                            foreach (var n in invalidNodes)
                                nodes.Remove(n);


                            for( var x = DualSerialChannel_DoorModuleLimits.LowestNodeNumber; x <= DualSerialChannel_DoorModuleLimits.HighestNodeNumber; x++)
                            {
                                // Strip out duplicate NodeNumbers
                                var nodesX = nodes.Where(o => o.NodeNumber == x).ToList();
                                if (nodesX.Count > 1)
                                {
                                    int y = 0;
                                    foreach (var n1 in nodesX)
                                    {
                                        if (y > 0)
                                        {
                                            nodes.Remove(n1);
                                        }
                                        y++;
                                    }
                                }

                                var n = nodes.FirstOrDefault(o => o.NodeNumber == x);
                                if( n == null)
                                {
                                    nodes.Add(new GalaxyInterfaceBoardSectionNode()
                                    {
                                        ModuleNumber = m.ModuleNumber,
                                        NodeNumber = x,
                                        IsNodeActive = false
                                    });
                                }
                            }
                            m.GalaxyInterfaceBoardSectionNodes = nodes.ToCollection();
                        }
                        bs.GalaxyHardwareModules = mods.ToCollection();
                    }
                    else if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485InputModule)
                    {
                        foreach (var m in bs.GalaxyHardwareModules)
                        {
                            if (m.GalaxyHardwareModuleTypeUid != GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_InputModule16)
                                m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_InputModule16;
                        }
                    }
                    else if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_VeridtCac)
                    {
                        foreach (var m in bs.GalaxyHardwareModules)
                        {
                        }
                    }
                    else if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Shell)
                    {
                        foreach (var m in bs.GalaxyHardwareModules)
                        {
                        }
                    }
                    else if (bs.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Unused)
                    {
                        foreach (var m in bs.GalaxyHardwareModules)
                        {
                        }
                    }

                }
            }
            else if (entity.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_KoneElevatorInterface)
            {
                foreach (var bs in sects)
                {
                    if (bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.KoneElevatorManagerBoardInterfaceSectionModeIds.KoneElevatorManagerSectionMode_KEI)
                        bs.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.KoneElevatorManagerBoardInterfaceSectionModeIds.KoneElevatorManagerSectionMode_KEI;
                }
            }
            else if (entity.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_OtisElevatorInterface)
            {
                foreach (var bs in sects)
                {
                    if (bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_OtisElevatorInterface)
                        bs.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.OtisElevatorManagerBoardInterfaceSectionModeIds.OtisElevatorManagerSectionMode_OEI;
                }
            }
            //else if (entity.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_CardTourManager)
            //{
            //    foreach (var bs in sects)
            //    {
            //        if (bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_CardTourManager)
            //            bs.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.CardTourManagerBoardInterfaceSectionModeIds.CTMSectionMode_CTM;
            //    }
            //}
            else if (entity.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_Cpu)
            {
                foreach (var bs in sects)
                {
                    if (bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_Cpu)
                        bs.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.VeridtCpuBoardInterfaceSectionModeIds.VeridtCpuBoardInterfaceSectionMode_Cpu;
                }
            }
            else if (entity.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_ReaderModule)
            {
                foreach (var bs in sects)
                {
                    if (bs.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_ReaderModule)
                        bs.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.VeridtReaderModuleBoardInterfaceSectionModeIds.VeridtReaderModuleBoardInterfaceSectionMode_Reader;
                }
            }

            // Now save those that are defined in the GalaxyPanel
            entity.InterfaceBoardSections = sects.ToCollection();

            //foreach (var section in entity.InterfaceBoardSections)
            foreach (var section in entity.InterfaceBoardSections)
            {
                section.ClusterNumber = entity.ClusterNumber;
                section.PanelNumber = entity.PanelNumber;
                section.GalaxyInterfaceBoardUid = entity.GalaxyInterfaceBoardUid;
                section.GalaxyPanelUid = entity.GalaxyPanelUid;
                var existingSection = sections.FirstOrDefault(o => o.GalaxyInterfaceBoardSectionUid == section.GalaxyInterfaceBoardSectionUid);
                if (existingSection != null)//&& section.IsAnythingDirty)
                {
                    UpdateTableEntityBaseProperties(section, sessionData);
                    _galaxyInterfaceBoardSectionRepository.Update(section, sessionData, saveParams);
                }
                if (section.GalaxyInterfaceBoardSectionUid == Guid.Empty)
                {
                    section.GalaxyInterfaceBoardSectionUid = GuidUtilities.GenerateComb();
                    section.GalaxyInterfaceBoardUid = entity.GalaxyInterfaceBoardUid;
                    UpdateTableEntityBaseProperties(section, sessionData);
                    _galaxyInterfaceBoardSectionRepository.Add(section, sessionData, saveParams);
                }
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, GalaxyInterfaceBoard originalEntity, GalaxyInterfaceBoard newEntity, string auditXml)
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
                        propertiesToIgnore.Add("InterfaceBoardSections");

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "GalaxyInterfaceBoardUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyInterfaceBoardUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyInterfaceBoardUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyInterfaceBoardUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyInterfaceBoardUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyInterfaceBoardUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyInterfaceBoardUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.GalaxyInterfaceBoardUid;
                        mgr.Entity.RecordTag = originalEntity.GalaxyInterfaceBoardUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(GalaxyInterfaceBoard entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            //}
            //var entityMaps = _entityMapRepository.GetAllGalaxyInterfaceBoardEntityMapsForGalaxyInterfaceBoard(sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyInterfaceBoardUid });
            //var entityIds = (from e in entityMaps select e.EntityId).ToList();
            //entity.EntityIds.AddRange(entityIds);
            //foreach ( var e in entityMaps)
            //{
            //    if(e.EntityId != entity.EntityId)
            //        entity.EntityIds.Add(e.EntityId);
            //}
            //entity.EntityIds.Add(entity.EntityId);
            if (!getParameters.IsExcluded(nameof(entity.InterfaceBoardSections)))
                entity.InterfaceBoardSections = _galaxyInterfaceBoardSectionRepository.GetAllGalaxyInterfaceBoardSectionsForInterfaceBoard(sessionData, new GetParametersWithPhoto(getParameters) { UniqueId = entity.GalaxyInterfaceBoardUid, IncludeMemberCollections = getParameters.IncludeMemberCollections }).ToCollection();
        }

        //private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasEntityMappingList entity)
        //{
        //    var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
        //    var existingEntityMappings = _entityMapRepository.GetAllGalaxyInterfaceBoardEntityMapsForGalaxyInterfaceBoard(sessionData, getParameters);
        //    var existingEntityIds = new HashSet<Guid>(existingEntityMappings.Select(e => e.EntityId));
        //    var userPermittedEntities = GcsUserSessionRepository.GetUserEntitiesForSession(sessionData.SessionGuid);
        //    foreach (var existingEntityId in existingEntityIds)
        //    {
        //        if (!entity.EntityIds.Contains(existingEntityId) && userPermittedEntities.Contains(existingEntityId))
        //        {
        //            var deleteThisExistingEntityMap = (from eem in existingEntityMappings where eem.EntityId == existingEntityId select eem).FirstOrDefault();
        //            if (deleteThisExistingEntityMap != null)
        //                _entityMapRepository.Remove(deleteThisExistingEntityMap.GalaxyInterfaceBoardEntityMapUid, sessionData, null);
        //        }
        //    }
        //    foreach (var entityId in entity.EntityIds)
        //    {
        //        if (!existingEntityIds.Contains(entityId))
        //        {
        //            var entityMap = new GalaxyInterfaceBoardEntityMap();
        //            entityMap.GalaxyInterfaceBoardEntityMapUid = GuidUtilities.GenerateComb();
        //            entityMap.GalaxyInterfaceBoardUid = uid;
        //            entityMap.EntityId = entityId;
        //            entityMap.UpdateDate = DateTimeOffset.Now;
        //            entityMap.UpdateName = sessionData.UserName;
        //            entityMap.InsertDate = DateTimeOffset.Now;
        //            entityMap.InsertName = sessionData.UserName;

        //            _entityMapRepository.Add(entityMap, sessionData, null);
        //        }
        //    }
        //}

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("GalaxyInterfaceBoard", "GalaxyInterfaceBoardUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("GalaxyInterfaceBoard", "GalaxyInterfaceBoardUid", id);
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

        protected override bool IsEntityUnique(GalaxyInterfaceBoard entity)
        {
            var mgr = new IsGalaxyInterfaceBoardUniquePDSAManager();
            mgr.Entity.GalaxyInterfaceBoardUid = entity.GalaxyInterfaceBoardUid;
            mgr.Entity.GalaxyPanelUid = entity.GalaxyPanelUid;
            mgr.Entity.BoardNumber = entity.BoardNumber;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("GalaxyInterfaceBoard", "GalaxyInterfaceBoardUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("GalaxyInterfaceBoard", "GalaxyInterfaceBoardUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }


    }
}
