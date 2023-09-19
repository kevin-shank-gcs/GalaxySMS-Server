using GalaxySMS.Business.Contracts;
using GalaxySMS.Business.Entities;
using GalaxySMS.Common.Constants;
using GalaxySMS.Data.Contracts;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;
using GCS.Core.Common.ServiceModel.Extensions;
using GCS.Core.Common.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using System.Transactions;
using GalaxySMS.Business.Managers.Support;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Extensions;
using GCS.PanelDataProcessors.Interfaces;
using GCS.PanelOutputDataHandlers;
using PDSA.MessageBroker;
using GalaxySMS.Data.Support;
using System.Net;

namespace GalaxySMS.Business.Managers
{
    [Export(typeof(IMercuryManagementService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        ReleaseServiceInstanceOnTransactionComplete = false,
        TransactionTimeout = "00:10:00",// - Defaults to 00:00:00 (no timeout)
        TransactionIsolationLevel = IsolationLevel.ReadUncommitted)] // defaults to Serializable
    [ApplicationUserSessionHeaderInspectorBehavior]
    public class MercuryManagement : ManagerBase, IMercuryManagementService
    {
        public MercuryManagement()
        {
        }

        public MercuryManagement(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        public MercuryManagement(IDataRepositoryFactory dataRepositoryFactory,
            IBusinessEngineFactory businessEngineFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
            _BusinessEngineFactory = businessEngineFactory;
        }

        [Import] IDataRepositoryFactory _DataRepositoryFactory;

        [Import] IBusinessEngineFactory _BusinessEngineFactory;

        #region Helper methods

        private Guid GetEntityIdOf(IHasGetEntityId repo, Guid uid, bool throwNotFoundException, string typeName, string propertyName)
        {
            return WcfManagerHelpers.GetEntityIdOf(repo, uid, throwNotFoundException, typeName, propertyName);
        }

        private Guid GetEntityIdOfSite(Guid siteUid, bool throwNotFoundException)
        {
            return WcfManagerHelpers.GetEntityIdOfSite(siteUid, throwNotFoundException, _DataRepositoryFactory);
        }
        private Guid GetEntityIdOfMercScpGroup(Guid siteUid, bool throwNotFoundException)
        {
            return WcfManagerHelpers.GetEntityIdOfMercScpGroup(siteUid, throwNotFoundException, _DataRepositoryFactory);
        }

        private Guid GetEntityIdOfMercScpGroup(IGetParametersBase parameters, bool throwNotFoundException)
        {
            if (parameters.MercScpGroupUid != Guid.Empty)
                return GetEntityIdOfMercScpGroup(parameters.MercScpGroupUid, throwNotFoundException);
            if (parameters.UniqueId != Guid.Empty)
                return GetEntityIdOfMercScpGroup(parameters.UniqueId, throwNotFoundException);
            if (parameters.GetGuid != Guid.Empty)
                return GetEntityIdOfMercScpGroup(parameters.GetGuid, throwNotFoundException);
            return Guid.Empty;
        }

        #endregion

        #region MercScpIdReport Operations

        public MercScpIdReport[] GetAllMercScpIdReports(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpIdReportRepository>();
                IEnumerable<MercScpIdReport> data = repository.GetAll(ApplicationUserSessionHeader, parameters);

                return data.ToArray();
            });
        }

        public MercScpIdReport[] GetMercScpIdReportsByMacAddress(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpIdReportRepository>();
                IEnumerable<MercScpIdReport> data = repository.GetAllMercScpIdReportsForMacAddress(ApplicationUserSessionHeader, parameters.GetString);

                return data.ToArray();
            });
        }

        public MercScpIdReport[] GetMercScpIdReportsByModelAndSerialNumber(GetParametersWithPhoto parameters, string model)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpIdReportRepository>();
                IEnumerable<MercScpIdReport> data = repository.GetAllMercScpIdReportsForModelAndSerialNumber(ApplicationUserSessionHeader, model, parameters.GetString);

                return data.ToArray();
            });

        }

        public MercScpIdReport GetMercScpIdReport(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpIdReportRepository>();
                var data = repository.Get(parameters.UniqueId, ApplicationUserSessionHeader, parameters);
                if (data == null && parameters.ThrowExceptionIfNotFound)
                {
                    var ex =
                        new NotFoundException(string.Format("MercScpIdReport with MercScpIdReportUid of {0} is not in database",
                            parameters.UniqueId));
                    var detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return data;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public MercScpIdReport InsertMercScpIdReport(SaveParameters<MercScpIdReport> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                //if (!parameters.DoNotValidateAuthorization)
                //    ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanAddId);
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpIdReportRepository>();
                MercScpIdReport updatedEntity = null;
                //if (repository.IsUnique(parameters.Data) == false)
                //{
                //    if (parameters.ThrowExceptionIfDuplicate)
                //    {
                //        var ex =
                //            new DuplicateIndexException(
                //                string.Format("MercScpIdReport with Name of '{0}' cannot be saved because it is a duplicate.",
                //                    parameters.Data.MercScpIdReportName));
                //        var detail = new ExceptionDetailEx(ex);
                //        throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                //    }
                //    return parameters.Data;
                //}

                parameters.Data.UpdateDate = DateTimeOffset.Now;
                parameters.Data.UpdateName = LoginName;
                if (parameters.Data.MercScpIdReportUid == Guid.Empty)
                {
                    parameters.Data.MercScpIdReportUid = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                }

                //if (repository.DoesExist(parameters.Data.MercScpIdReportUid) == false)
                //{
                this.Log().Info($"Saving MercScpIdReport: {parameters.Data.MacAddress}");
                parameters.Data.InsertDate = DateTimeOffset.Now;
                parameters.Data.InsertName = LoginName;
                updatedEntity = repository.Add(parameters.Data, ApplicationUserSessionHeader, parameters);
                //}
                //else
                //{
                //    updatedEntity = repository.Update(parameters.Data, ApplicationUserSessionHeader, parameters);
                //}

                return updatedEntity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteMercScpIdReportByPk(DeleteParameters parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanDeleteId);
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpIdReportRepository>();

                return repository.Remove(parameters.UniqueId, ApplicationUserSessionHeader);
            });
        }

        #endregion

        #region MercScpGroup Operations

        //        public MercScpGroup[] GetAllMercScpGroups(GetParametersWithPhoto parameters)
        public ArrayResponse<MercScpGroup> GetAllMercScpGroups(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpGroupRepository>();
                //var data = repository.GetAll(ApplicationUserSessionHeader, parameters);

                //return Helpers.ToArrayResponse<MercScpGroup>(data.ToArray(), 0, 0, 0);
                var data = repository.GetAllPaged(ApplicationUserSessionHeader, parameters);

                return (ArrayResponse<MercScpGroup>)data;

            });
        }

        public ArrayResponse<MercScpGroupListItemCommands> GetAllMercScpGroupsList(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpGroupRepository>();
                //                var data = repository.GetAll(ApplicationUserSessionHeader, parameters);
                //                var ri = new List<ListItemBase>();
                //foreach (var o in data)
                //{
                //    ri.Add(o.ToListItemBase());
                //}
                //return ri.ToArray();
                var data = repository.GetAllPaged(ApplicationUserSessionHeader, parameters);
                var ri = new List<MercScpGroupListItemCommands>();
                var totalItemCount = 0;
                foreach (var o in data.Items)
                {
                    if (totalItemCount == 0)
                        totalItemCount = o.TotalRowCount;
                    ri.Add(o.ToMercScpGroupListItemCommands());
                }
                return ArrayResponseHelpers.ToArrayResponse(ri, parameters.PageNumber, parameters.PageSize, totalItemCount);
            });
        }

        public ArrayResponse<MercScpGroup> GetAllMercScpGroupsForEntity(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpGroupRepository>();

                if (parameters.UniqueId != Guid.Empty)
                    ValidateUserHasEntityAccess(parameters.UniqueId, true);

                var data = repository.GetAllMercScpGroupsForEntityPaged(ApplicationUserSessionHeader, parameters);
                return (ArrayResponse<MercScpGroup>)data;
            });
        }

        public ArrayResponse<MercScpGroupListItemCommands> GetAllMercScpGroupsForEntityList(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);

                if (parameters.UniqueId != Guid.Empty)
                    ValidateUserHasEntityAccess(parameters.UniqueId, true);

                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpGroupRepository>();
                var data = repository.GetAllMercScpGroupsForEntityPaged(ApplicationUserSessionHeader, parameters);
                var ri = new List<MercScpGroupListItemCommands>();
                var totalItemCount = 0;
                foreach (var o in data.Items)
                {
                    if (totalItemCount == 0)
                        totalItemCount = o.TotalRowCount;
                    ri.Add(o.ToMercScpGroupListItemCommands());
                }
                return ArrayResponseHelpers.ToArrayResponse(ri, parameters.PageNumber, parameters.PageSize, totalItemCount);
            });
        }

        public ArrayResponse<MercScpGroupMercScpMinimal> GetMercScpGroupsWithMercScpMinimal(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);

                if (parameters.UniqueId != Guid.Empty)
                    ValidateUserHasEntityAccess(parameters.UniqueId, true);

                var MercScpGroupUids = parameters.GetString.ToIEnumerableGuid(',');
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpRepository>();
                var ri = new List<MercScpGroupMercScpMinimal>();
                var totalItemCount = MercScpGroupUids.Count();
                foreach (var uid in MercScpGroupUids)
                {
                    var item = new MercScpGroupMercScpMinimal()
                    {
                        MercScpGroupUid = uid
                    };
                    parameters.UniqueId = uid;
                    var data = repository.GetAllMercScpsForMercScpGroup(ApplicationUserSessionHeader, parameters);
                    foreach (var o in data.Items)
                    {
                        item.MercScps.Add(new MercScpMinimal()
                        {
                            MercScpUid = o.MercScpUid,
                            ScpName = o.ScpName,
                            Location = o.Location,
                            DisabledCommandIds = new List<Guid>(),// o.DisabledCommandIds,
                            ActiveCpuCount = o.ActiveCpuCount,
                            AccessPortalCount = o.AccessPortalCount,
                            ElevatorOutputCount = o.ElevatorOutputCount,
                            InputDeviceCount = o.InputDeviceCount,
                            InterfaceBoardCount = o.InterfaceBoardCount,
                            OutputDeviceCount = o.OutputDeviceCount
                        });
                    }
                    ri.Add(item);
                }

                return ArrayResponseHelpers.ToArrayResponse(ri, parameters.PageNumber, parameters.PageSize, totalItemCount);
            });
        }

        public ArrayResponse<MercScpGroup> GetAllMercScpGroupsForSite(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                parameters.CurrentEntityId = GetEntityIdOfSite(parameters.UniqueId, true);
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpGroupRepository>();
                var data = repository.GetAllMercScpGroupsForSitePaged(ApplicationUserSessionHeader, parameters);

                return (ArrayResponse<MercScpGroup>)data;
            });
        }


        public ArrayResponse<MercScpGroupListItemCommands> GetAllMercScpGroupsForSiteList(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpGroupRepository>();
                var data = repository.GetAllMercScpGroupsForSitePaged(ApplicationUserSessionHeader, parameters);
                var ri = new List<MercScpGroupListItemCommands>();
                var totalItemCount = 0;
                foreach (var o in data.Items)
                {
                    if (totalItemCount == 0)
                        totalItemCount = o.TotalRowCount;
                    ri.Add(o.ToMercScpGroupListItemCommands());
                }
                return ArrayResponseHelpers.ToArrayResponse(ri, parameters.PageNumber, parameters.PageSize, totalItemCount);
            });
        }

        public MercScpGroup GetMercScpGroup(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpGroupRepository>();
                parameters.CurrentEntityId = GetEntityIdOf(repository, parameters.UniqueId, true, nameof(MercScpGroup), nameof(MercScpGroup.MercScpGroupUid));

                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);
                var data = repository.Get(parameters.UniqueId, ApplicationUserSessionHeader, parameters);
                if (data == null && parameters.ThrowExceptionIfNotFound)
                {
                    var ex =
                        new NotFoundException(string.Format("MercScpGroup with MercScpGroupUid of {0} is not in database",
                            parameters.UniqueId));
                    var detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                // Verify that the user has permissions to the entity that the MercScpGroup is associated with
                ValidateEntityAuthorizationAndSetupOperation(data.EntityId, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);

                return data;
            });
        }

        //public MercScpGroup GetMercScpGroupByHardwareAddress(GetParametersWithPhoto parameters)
        //{
        //    return ExecuteFaultHandledOperation(() =>
        //    {
        //        ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);
        //        var repository = _DataRepositoryFactory.GetDataRepository<IMercScpGroupRepository>();
        //        var data = repository.GetByHardwareAddress(ApplicationUserSessionHeader, parameters);
        //        if (data == null && parameters.ThrowExceptionIfNotFound)
        //        {
        //            var ex =
        //                new NotFoundException($"MercScpGroup with MercScpGroupGroupId:{parameters.MercScpGroupGroupId}, MercScpGroupNumber:{parameters.MercScpGroupNumber} is not in database");
        //            var detail = new ExceptionDetailEx(ex);
        //            throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
        //        }

        //        // Verify that the user has permissions to the entity that the MercScpGroup is associated with
        //        ValidateEntityAuthorizationAndSetupOperation(data.EntityId, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);

        //        return data;
        //    });
        //}

        public ValidationProblemDetails ValidateMercScpGroup(SaveParameters<MercScpGroup> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var response = new ValidationProblemDetails();
                var errorsArray = new List<string>();
                var exists = false;
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpGroupRepository>();

                if (parameters.Data.MercScpGroupUid != Guid.Empty)
                {
                    var existingItem = repository.Get(parameters.Data.MercScpGroupUid, ApplicationUserSessionHeader,
                        new GetParametersWithPhoto());
                    if (existingItem != null)
                    {
                        exists = true;
                        // Verify that the SiteUid is not being changed
                        if (parameters.Data.SiteUid == Guid.Empty)
                            parameters.Data.SiteUid = existingItem.SiteUid;
                        if (parameters.Data.SiteUid != existingItem.SiteUid)
                        {
                            errorsArray.Add($"The {nameof(MercScpGroup.SiteUid)} cannot be changed.");
                        }

                        // Verify that the EntityId is not being changed
                        if (parameters.Data.EntityId == Guid.Empty)
                            parameters.Data.EntityId = existingItem.EntityId;
                        if (parameters.Data.EntityId != existingItem.EntityId)
                            errorsArray.Add($"The {nameof(MercScpGroup.EntityId)} cannot be changed.");
                    }
                }

                if (!exists)
                {
                    if (parameters.Data.SiteUid == Guid.Empty)
                        parameters.Data.SiteUid = parameters.CurrentSiteUid;
                    if (parameters.Data.SiteUid == Guid.Empty)
                        parameters.Data.SiteUid = ApplicationUserSessionHeader.CurrentSiteId;

                    if (parameters.Data.EntityId == Guid.Empty && parameters.Data.SiteUid == Guid.Empty)
                    {
                        errorsArray.Add($"The {nameof(MercScpGroup.EntityId)} and {nameof(MercScpGroup.SiteUid)} properties are both missing. One of these properties are required.");
                    }
                }


                var siteRepo = _DataRepositoryFactory.GetDataRepository<ISiteRepository>();
                var sites = siteRepo.GetAllSitesForEntity(ApplicationUserSessionHeader,
                    new GetParametersWithPhoto()
                    {
                        CurrentEntityId = parameters.Data.EntityId
                    });
                Site s = null;
                if (parameters.Data.SiteUid == Guid.Empty)
                    parameters.Data.SiteUid = CurrentSiteId;
                if (parameters.Data.SiteUid != Guid.Empty)
                    s = sites.FirstOrDefault(o => o.SiteUid == parameters.Data.SiteUid);
                else
                {
                    s = sites.FirstOrDefault();
                }
                if (s != null)
                    parameters.Data.SiteUid = s.SiteUid;
                else
                {
                    if (parameters.Data.SiteUid == Guid.Empty)
                        errorsArray.Add(
                            $"The property {nameof(parameters.Data.SiteUid)} is required.");
                    else
                        errorsArray.Add(
                            $"Cannot add the MercScpGroup to the specified site. Make sure a valid {nameof(parameters.Data.SiteUid)} value is specified.");
                }


                if (errorsArray.Any())
                {
                    response.Errors.Add($"{nameof(MercScpGroup)}", errorsArray.ToArray());
                    return response;
                }

                parameters.CurrentEntityId = GetEntityIdOfSite(parameters.Data.SiteUid, true);
                if (exists)
                    ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanUpdateId);
                else
                    ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanAddId);

                //if (parameters.Data.CrisisActivateInputOutputGroupUid.HasValue &&
                //    parameters.Data.CrisisActivateInputOutputGroupUid != Guid.Empty)
                //{
                //    var crisisIoGroupEntityId = GetEntityIdOfInputOutputGroup(parameters.Data.CrisisActivateInputOutputGroupUid.Value, true);
                //    if (crisisIoGroupEntityId != parameters.Data.EntityId)
                //        errorsArray.Add($"The {nameof(MercScpGroup.CrisisActivateInputOutputGroupUid)} value {parameters.Data.CrisisActivateInputOutputGroupUid} is not permitted because it is from a different MercScpGroup. The input-output group must be on the same MercScpGroup as the cluser being saved.");
                //}

                //if (parameters.Data.CrisisResetInputOutputGroupUid.HasValue &&
                //    parameters.Data.CrisisResetInputOutputGroupUid != parameters.Data.CrisisActivateInputOutputGroupUid &&
                //    parameters.Data.CrisisResetInputOutputGroupUid != Guid.Empty)
                //{
                //    var crisisIoGroupEntityId = GetEntityIdOfInputOutputGroup(parameters.Data.CrisisResetInputOutputGroupUid.Value, true);
                //    if (crisisIoGroupEntityId != parameters.Data.EntityId)
                //        errorsArray.Add($"The {nameof(MercScpGroup.CrisisResetInputOutputGroupUid)} value {parameters.Data.CrisisResetInputOutputGroupUid} is not permitted because it is from a different MercScpGroup. The input-output group must be on the same MercScpGroup as the cluser being saved.");
                //}

                parameters.Data.EntityId = parameters.CurrentEntityId;

                //var scheduleMapRepository = _DataRepositoryFactory.GetDataRepository<IGalaxyMercScpGroupTimeScheduleMapRepository>();

                //if (parameters.Data.MercScpGroupNumber < 1)
                //{
                //    parameters.Data.MercScpGroupNumber = repository.GetAvailableMercScpGroupNumber(parameters.Data.MercScpGroupGroupId);
                //}

                //if (repository.IsUnique(parameters.Data) == false)
                //{
                //    if (repository.IsMercScpGroupNameUnique(parameters.Data) == false)
                //    {
                //        errorsArray.Add($"MercScpGroup with Name of '{parameters.Data.Name}' cannot be saved because it is a duplicate.");
                //    }

                //    if (repository.IsMercScpGroupAddressUnique(parameters.Data) == false)
                //    {
                //        errorsArray.Add(
                //                $"MercScpGroup with {nameof(MercScpGroup.MercScpGroupGroupId)}: {parameters.Data.MercScpGroupGroupId} and {nameof(MercScpGroup.MercScpGroupNumber)}: {parameters.Data.MercScpGroupNumber} cannot be saved because it is a duplicate.");
                //    }
                //}

                if (errorsArray.Any())
                {
                    response.Errors.Add($"{nameof(parameters.Data.MercScpGroupUid)}", errorsArray.ToArray());
                    errorsArray.Clear();
                }

                var timeScheduleRepository = _DataRepositoryFactory.GetDataRepository<ITimeScheduleRepository>();
                var autoMapSchedules = timeScheduleRepository.GetAutoMapTimeSchedulesForEntity(parameters.Data.EntityId);
                var schedules = timeScheduleRepository.GetAllTimeSchedulesForEntity(
                    ApplicationUserSessionHeader, new GetParametersWithPhoto()
                    {
                        UniqueId = parameters.CurrentEntityId
                    });

                //if (!autoMapSchedules)
                //{
                //    if (parameters.Data.TimeSchedules != null && parameters.Data.TimeSchedules.Any())
                //    {
                //        var x = 0;

                //        foreach (var ts in parameters.Data.TimeSchedules)
                //        {
                //            if (ts.Selected)
                //            {
                //                if (schedules.Items.FirstOrDefault(o => o.TimeScheduleUid == ts.TimeScheduleUid) == null)
                //                {
                //                    errorsArray.Add(
                //                        $"The {nameof(parameters.Data.TimeSchedules)} value {ts.TimeScheduleUid} is not permitted because it does not exist for entity {parameters.CurrentEntityId}.");
                //                    response.Errors.Add($"{nameof(parameters.Data.TimeSchedules)}[{x}]", errorsArray.ToArray());
                //                    errorsArray.Clear();
                //                }
                //            }

                //            x++;
                //        }
                //    }
                //}

                if (response.Errors.Any())
                {
                    return response;
                }

                return null;

            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public MercScpGroup SaveMercScpGroup(SaveParameters<MercScpGroup> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpGroupRepository>();
                var exists = false;
                if (parameters.Data.MercScpGroupUid != Guid.Empty)
                {
                    var existingItem = repository.Get(parameters.Data.MercScpGroupUid, ApplicationUserSessionHeader,
                        new GetParametersWithPhoto());
                    if (existingItem != null)
                    {
                        exists = true;
                        // Verify that the SiteUid is not being changed
                        if (parameters.Data.SiteUid == Guid.Empty)
                            parameters.Data.SiteUid = existingItem.SiteUid;
                        if (parameters.Data.SiteUid != existingItem.SiteUid)
                            throw new DataValidationException($"The {nameof(MercScpGroup.SiteUid)} cannot be changed.");

                        // Verify that the EntityId is not being changed
                        if (parameters.Data.EntityId == Guid.Empty)
                            parameters.Data.EntityId = existingItem.EntityId;
                        if (parameters.Data.EntityId != existingItem.EntityId)
                            throw new DataValidationException($"The {nameof(MercScpGroup.EntityId)} cannot be changed.");
                    }
                }

                if (!exists)
                {
                    if (parameters.Data.SiteUid == Guid.Empty)
                        parameters.Data.SiteUid = parameters.CurrentSiteUid;
                    if (parameters.Data.SiteUid == Guid.Empty)
                        parameters.Data.SiteUid = ApplicationUserSessionHeader.CurrentSiteId;

                    if (parameters.Data.EntityId == Guid.Empty && parameters.Data.SiteUid == Guid.Empty)
                    {
                        throw new DataValidationException(
                            $"The {nameof(MercScpGroup.EntityId)} and {nameof(MercScpGroup.SiteUid)} properties are both missing. One of these properties are required.");
                    }
                }

                //// Start by validating the SiteUid value. 
                //// If empty, the user session CurrentSiteId will be used. If that has not been set, then an exception is thrown.
                //if (parameters.Data.SiteUid == Guid.Empty)
                //{
                //    parameters.Data.SiteUid = ApplicationUserSessionHeader.CurrentSiteId;
                //}

                if (parameters.Data.SiteUid == Guid.Empty)
                {
                    var siteRepo = _DataRepositoryFactory.GetDataRepository<ISiteRepository>();
                    var sites = siteRepo.GetAllSitesForEntity(ApplicationUserSessionHeader,
                        new GetParametersWithPhoto()
                        {
                            CurrentEntityId = parameters.Data.EntityId
                        });
                    if (sites.Count() != 1)
                        throw new DataValidationException($"The {nameof(MercScpGroup.SiteUid)} is missing.");
                    var s = sites.FirstOrDefault();
                    if (s != null)
                        parameters.Data.SiteUid = s.SiteUid;
                }

                parameters.CurrentEntityId = GetEntityIdOfSite(parameters.Data.SiteUid, true);
                if (exists)
                    ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanUpdateId);
                else
                    ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanAddId);

                //if (parameters.Data.CrisisActivateInputOutputGroupUid.HasValue &&
                //    parameters.Data.CrisisActivateInputOutputGroupUid != Guid.Empty)
                //{
                //    var crisisIoGroupEntityId =
                //        GetEntityIdOfInputOutputGroup(parameters.Data.CrisisActivateInputOutputGroupUid.Value, true);
                //    if (crisisIoGroupEntityId != parameters.Data.EntityId)
                //        throw new DataValidationException($"The {nameof(MercScpGroup.CrisisActivateInputOutputGroupUid)} value {parameters.Data.CrisisActivateInputOutputGroupUid} is not permitted because it is from a different MercScpGroup. The input-output group must be on the same MercScpGroup as the cluser being saved.");
                //}

                //if (parameters.Data.CrisisResetInputOutputGroupUid.HasValue &&
                //    parameters.Data.CrisisResetInputOutputGroupUid != parameters.Data.CrisisActivateInputOutputGroupUid &&
                //    parameters.Data.CrisisResetInputOutputGroupUid != Guid.Empty)
                //{
                //    var crisisIoGroupEntityId =
                //        GetEntityIdOfInputOutputGroup(parameters.Data.CrisisResetInputOutputGroupUid.Value, true);
                //    if (crisisIoGroupEntityId != parameters.Data.EntityId)
                //        throw new DataValidationException($"The {nameof(MercScpGroup.CrisisResetInputOutputGroupUid)} value {parameters.Data.CrisisResetInputOutputGroupUid} is not permitted because it is from a different MercScpGroup. The input-output group must be on the same MercScpGroup as the cluser being saved.");
                //}

                // Possibly validate the TemplateAccessPortalUid here

                //parameters.Data.SiteUid = parameters.cURR;
                parameters.Data.EntityId = parameters.CurrentEntityId;

                //var scheduleMapRepository =
                //    _DataRepositoryFactory.GetDataRepository<IGalaxyMercScpGroupTimeScheduleMapRepository>();

                //if (parameters.Data.MercScpGroupNumber < 1)
                //{
                //    parameters.Data.MercScpGroupNumber = repository.GetAvailableMercScpGroupNumber(parameters.Data.MercScpGroupGroupId);
                //}

                //if (repository.IsUnique(parameters.Data) == false)
                //{
                //    if (repository.IsMercScpGroupNameUnique(parameters.Data) == false)
                //    {
                //        var ex = new DuplicateIndexException($"MercScpGroup with Name of '{parameters.Data.Name}' cannot be saved because it is a duplicate.");
                //        var detail = new ExceptionDetailEx(ex);
                //        throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                //    }

                //    if (repository.IsMercScpGroupAddressUnique(parameters.Data) == false)
                //    {
                //        var ex =
                //            new DuplicateIndexException(
                //                $"MercScpGroup with {nameof(MercScpGroup.MercScpGroupGroupId)}: {parameters.Data.MercScpGroupGroupId} and {nameof(MercScpGroup.MercScpGroupNumber)}: {parameters.Data.MercScpGroupNumber} cannot be saved because it is a duplicate.");
                //        var detail = new ExceptionDetailEx(ex);
                //        throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                //    }
                //}

                MercScpGroup updatedItem = null;

                parameters.Data.UpdateDate = DateTimeOffset.Now;
                parameters.Data.UpdateName = LoginName;
                if (parameters.Data.MercScpGroupUid == Guid.Empty)
                {
                    parameters.Data.MercScpGroupUid = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                }


                var timeScheduleRepository = _DataRepositoryFactory.GetDataRepository<ITimeScheduleRepository>();
                var autoMapSchedules = timeScheduleRepository.GetAutoMapTimeSchedulesForEntity(parameters.Data.EntityId);
                var schedules = timeScheduleRepository.GetAllTimeSchedulesForEntity(
                    ApplicationUserSessionHeader, new GetParametersWithPhoto()
                    {
                        UniqueId = parameters.CurrentEntityId
                    });

                //if (!autoMapSchedules)
                //{
                //    if (parameters.Data.TimeSchedules != null && parameters.Data.TimeSchedules.Any())
                //    {
                //        foreach (var ts in parameters.Data.TimeSchedules.Where(o => o.Selected))
                //        {
                //            if (schedules.Items.FirstOrDefault(o => o.TimeScheduleUid == ts.TimeScheduleUid) == null)
                //                throw new DataValidationException($"The {nameof(ts.TimeScheduleUid)} value {ts.TimeScheduleUid} is not permitted because it does not exist for entity {parameters.CurrentEntityId}.");
                //        }
                //    }
                //}

                if (repository.DoesExist(parameters.Data.MercScpGroupUid) == false)
                {
                    // New MercScpGroup
                    if (parameters.Data.RoleIds == null || !parameters.Data.RoleIds.Any())
                    {
                        var roleRepository = _DataRepositoryFactory.GetDataRepository<IGcsRoleRepository>();
                        var roleParams = new GetParametersWithPhoto() { IncludeMemberCollections = true, RefreshCache = true };
                        roleParams.ExcludeMemberCollectionSettings.Add(nameof(gcsRole.RolePermissions));
                        roleParams.ExcludeMemberCollectionSettings.Add(nameof(gcsRole.DeviceFilters.Regions));
                        var roles = roleRepository.GetAllRolesForEntity(parameters.CurrentEntityId, roleParams);
                        parameters.Data.RoleIds = roles.Where(o => o.DeviceFilters.IncludeAllClusters == true).Select(o => o.RoleId).ToCollection();

                        //parameters.Data.RoleIds = roleRepository.GetAllPrimaryKeyUids(parameters.CurrentEntityId).ToCollection();
                    }
                    //if (parameters.Data.TimeSchedules == null || !parameters.Data.TimeSchedules.Any())
                    //{
                    //    if (parameters.Data.TimeSchedules == null)
                    //        parameters.Data.TimeSchedules = new HashSet<TimeScheduleSelect>();
                    //    else
                    //    {
                    //        parameters.Data.TimeSchedules = parameters.Data.TimeSchedules.ToList();
                    //    }
                    //}

                    //if (autoMapSchedules)
                    //{
                    //    // ignore any incoming schedule data  if automap is enabled
                    //    parameters.Data.TimeSchedules.Clear();
                    //    foreach (var ts in schedules.Items.Take(TimeScheduleLimits.HighestDefinableNumber)
                    //                 .OrderBy(o => o.InsertDate))
                    //    {
                    //        parameters.Data.TimeSchedules.Add(new TimeScheduleSelect(ts)
                    //        {
                    //            Selected = true
                    //        });
                    //    }
                    //}

                    parameters.Data.InsertDate = DateTimeOffset.Now;
                    parameters.Data.InsertName = LoginName;
                    updatedItem = repository.Add(parameters.Data, ApplicationUserSessionHeader, parameters);

                    //// Add the never and always time schedule mappings
                    //var neverScheduleMap = new GalaxyMercScpGroupTimeScheduleMap();
                    //neverScheduleMap.GalaxyMercScpGroupTimeScheduleMapUid = GuidUtilities.GenerateComb();
                    //neverScheduleMap.MercScpGroupUid = updatedItem.MercScpGroupUid;
                    //neverScheduleMap.TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never;
                    //neverScheduleMap.PanelScheduleNumber =
                    //    (int)GalaxySMS.Common.Enums.TimeScheduleNumbers.TimeScheduleNever;
                    //UpdateProperties(neverScheduleMap);

                    //scheduleMapRepository.Add(neverScheduleMap, ApplicationUserSessionHeader, null, parameters);

                    //var alwaysScheduleMap = new GalaxyMercScpGroupTimeScheduleMap();
                    //alwaysScheduleMap.GalaxyMercScpGroupTimeScheduleMapUid = GuidUtilities.GenerateComb();
                    //alwaysScheduleMap.MercScpGroupUid = updatedItem.MercScpGroupUid;
                    //alwaysScheduleMap.TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always;
                    //alwaysScheduleMap.PanelScheduleNumber =
                    //    (int)GalaxySMS.Common.Enums.TimeScheduleNumbers.TimeScheduleAlways;
                    //UpdateProperties(alwaysScheduleMap);

                    //scheduleMapRepository.Add(alwaysScheduleMap, ApplicationUserSessionHeader, null, parameters);
                }
                else
                {
                    //if (autoMapSchedules)
                    //    parameters.Data.TimeSchedules = new HashSet<TimeScheduleSelect>();

                    updatedItem = repository.Update(parameters.Data, ApplicationUserSessionHeader, parameters);
                }

                if (parameters.Data.IsPanelDataDirty)
                {
                    //// Now send to the panels
                    //var sendParameters = new SendDataParameters<MercScpGroup_CommonPanelLoadData>()
                    //{ PopulateDataFromDatabase = true, ApplicationUserSessionHeader = this.ApplicationUserSessionHeader };
                    //sendParameters.Data.MercScpGroupUid = updatedItem.MercScpGroupUid;
                    //sendParameters.SendToAddress.MercScpGroupUid = updatedItem.MercScpGroupUid;
                    //Globals.Instance.MessageBroker.SendMessage(
                    //    new PDSAMessageBrokerMessage(MessageBrokerMessageNames.SendMercScpGroupSettingsToHardware, sendParameters));
                }
                return updatedItem;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteMercScpGroupByPk(DeleteParameters parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpGroupRepository>();
                parameters.CurrentEntityId = GetEntityIdOf(repository, parameters.UniqueId, true, nameof(MercScpGroup), nameof(MercScpGroup.MercScpGroupUid));

                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanDeleteId);

                var x = repository.Get(parameters.UniqueId, ApplicationUserSessionHeader, new GetParametersWithPhoto());
                if (x != null)
                {
                    // Verify that the user has permissions to the entity that the MercScpGroup is associated with
                    ValidateEntityAuthorizationAndSetupOperation(x.EntityId, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanDeleteId);
                    return repository.Remove(parameters.UniqueId, ApplicationUserSessionHeader);
                }
                var ex = new NotFoundException(string.Format("MercScpGroup with MercScpGroupUid of {0} is not in database", parameters.UniqueId));
                var detail = new ExceptionDetailEx(ex);
                throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteMercScpGroup(DeleteParameters<MercScpGroup> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpGroupRepository>();
                parameters.CurrentEntityId = GetEntityIdOf(repository, parameters.Data.MercScpGroupUid, true, nameof(MercScpGroup), nameof(MercScpGroup.MercScpGroupUid));

                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanDeleteId);

                return repository.Remove(parameters.Data, ApplicationUserSessionHeader);
            });
        }

        public bool IsMercScpGroupReferenced(Guid uid)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpGroupRepository>();

                bReturn = repository.IsReferenced(uid);
                return bReturn;
            });
        }

        public bool IsMercScpGroupUnique(MercScpGroup data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpGroupRepository>();

                bReturn = repository.IsUnique(data);
                return bReturn;
            });
        }

        public MercScpGroupEditingData GetMercScpGroupEditingData(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var MercScpGroupEditingData = new MercScpGroupEditingData();
                ValidateAuthorizationAndSetupOperation(parameters,
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);

                //if (!parameters.IsExcluded(nameof(MercScpGroupEditingData.MercScpGroupTypes)))
                //{
                //    var MercScpGroupTypeRepository = _DataRepositoryFactory.GetDataRepository<IMercScpGroupTypeRepository>();
                //    MercScpGroupEditingData.MercScpGroupTypes =
                //        MercScpGroupTypeRepository.GetAll(ApplicationUserSessionHeader, parameters).ToCollection();
                //}

                //if (!parameters.IsExcluded(nameof(MercScpGroupEditingData.CredentialDataLengths)))
                //{
                //    var credentialDataLengthRepository =
                //        _DataRepositoryFactory.GetDataRepository<ICredentialDataLengthRepository>();
                //    MercScpGroupEditingData.CredentialDataLengths =
                //        credentialDataLengthRepository.GetAll(ApplicationUserSessionHeader, parameters).ToCollection();
                //}

                //if (!parameters.IsExcluded(nameof(MercScpGroupEditingData.TimeScheduleTypes)))
                //{
                //    var timeScheduleTypeRepository =
                //        _DataRepositoryFactory.GetDataRepository<ITimeScheduleTypeRepository>();
                //    MercScpGroupEditingData.TimeScheduleTypes =
                //        timeScheduleTypeRepository.GetAll(ApplicationUserSessionHeader, parameters).ToCollection();
                //}

                //if (!parameters.IsExcluded(nameof(MercScpGroupEditingData.LedBehaviorModes)))
                //{
                //    var MercScpGroupLedBehaviorModeRepository =
                //        _DataRepositoryFactory.GetDataRepository<IMercScpGroupLedBehaviorModeRepository>();
                //    MercScpGroupEditingData.LedBehaviorModes =
                //        MercScpGroupLedBehaviorModeRepository.GetAll(ApplicationUserSessionHeader, parameters)
                //            .ToCollection();
                //}

                //if (!parameters.IsExcluded(nameof(MercScpGroupEditingData.AccessPortalTypes)))
                //{
                //    var accessPortalTypeRepository =
                //        _DataRepositoryFactory.GetDataRepository<IAccessPortalTypeRepository>();
                //    MercScpGroupEditingData.AccessPortalTypes =
                //        accessPortalTypeRepository.GetAll(ApplicationUserSessionHeader, parameters).ToCollection();
                //}

                //if (!parameters.IsExcluded(nameof(MercScpGroupEditingData.TimeZones)))
                //{
                //    var timeZoneRepository = _DataRepositoryFactory.GetDataRepository<ITimeZoneRepository>();
                //    var timeZones = timeZoneRepository.GetAll(ApplicationUserSessionHeader, parameters).ToCollection();
                //    foreach (var tz in timeZones)
                //    {
                //        MercScpGroupEditingData.TimeZones.Add(new TimeZoneListItem()
                //        {
                //            Id = tz.Id,
                //            DisplayName = tz.DisplayName
                //        });
                //    }
                //}

                //if (!parameters.IsExcluded(nameof(MercScpGroupEditingData.AccessRuleOverrideTimeoutValues)))
                //{
                //    MercScpGroupEditingData.AccessRuleOverrideTimeoutValues.Add(new StringIntPair(
                //        string.Format(GalaxySMS.Resources.Resources.MercScpGroupAccessRuleOverride_Disabled),
                //        (0)));

                //    for (short seconds = 0; seconds < 10; seconds++)
                //    {
                //        for (short tenths = 0; tenths < 10; tenths++)
                //        {
                //            if (seconds + tenths != 0)
                //            {
                //                MercScpGroupEditingData.AccessRuleOverrideTimeoutValues.Add(new StringIntPair(
                //                    string.Format(GalaxySMS.Resources.Resources.MercScpGroupAccessRuleOverrideTimeout_Format,
                //                        seconds, tenths),
                //                    ((seconds * 100) + tenths * 10)));
                //            }
                //        }
                //    }
                //}

                //if (!parameters.IsExcluded(nameof(MercScpGroupEditingData.UnlimitedCredentialTimeoutValues)))
                //{
                //    MercScpGroupEditingData.UnlimitedCredentialTimeoutValues.Add(new StringIntPair(
                //        string.Format(GalaxySMS.Resources.Resources.UnlimitedCredential_Disabled),
                //        (0)));

                //    for (short seconds = 0; seconds < 10; seconds++)
                //    {
                //        for (short tenths = 0; tenths < 10; tenths++)
                //        {
                //            if (seconds + tenths != 0)
                //            {
                //                MercScpGroupEditingData.UnlimitedCredentialTimeoutValues.Add(new StringIntPair(
                //                    string.Format(GalaxySMS.Resources.Resources.UnlimitedCredentialTimeout_Format,
                //                        seconds, tenths),
                //                    ((seconds * 100) + tenths * 10)));
                //            }
                //        }
                //    }
                //}

                //if (!parameters.IsExcluded(nameof(MercScpGroupEditingData.Entities)))
                //{
                //    var entityRepository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();
                //    var regionRepository = _DataRepositoryFactory.GetDataRepository<IRegionRepository>();
                //    var siteRepository = _DataRepositoryFactory.GetDataRepository<ISiteRepository>();
                //    var permittedEntities = entityRepository.GetEntitiesForUser(ApplicationUserSessionHeader.UserId,
                //        ApplicationUserSessionHeader, parameters);
                //    foreach (var e in permittedEntities.Where(o =>
                //                 o.EntityId != GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id))
                //    {
                //        var newE = new gcsEntityListItem()
                //        {
                //            EntityId = e.EntityId,
                //            EntityName = e.EntityName,
                //            Image = e.gcsBinaryResource?.BinaryResource
                //        };

                //        var sites = siteRepository.GetAllSitesForEntity(ApplicationUserSessionHeader,
                //            new GetParametersWithPhoto(parameters)
                //            {
                //                UniqueId = e.EntityId,
                //                IncludeMemberCollections = false
                //            });

                //        var regions = regionRepository.GetAllRegionSelectionItemsForEntity(ApplicationUserSessionHeader,
                //            new GetParametersWithPhoto(parameters)
                //            {
                //                CurrentEntityId = e.EntityId,
                //                IncludeMemberCollections = false
                //            });

                //        foreach (var r in regions)
                //        {
                //            var newR = new RegionListItem()
                //            {
                //                RegionUid = r.RegionUid,
                //                RegionName = r.RegionName,
                //                Image = r.Photo
                //            };

                //            var regionSites = sites.Where(o => o.RegionUid == r.RegionUid).ToList();
                //            foreach (var s in regionSites)
                //            {
                //                var newS = new SiteListItem()
                //                {
                //                    SiteUid = s.SiteUid,
                //                    SiteName = s.SiteName,
                //                    Image = s.gcsBinaryResource?.BinaryResource
                //                };
                //                newR.Sites.Add(newS);
                //            }

                //            newE.Regions.Add(newR);
                //        }

                //        MercScpGroupEditingData.Entities.Add(newE);
                //    }
                //}

                //if (!parameters.IsExcluded(nameof(MercScpGroupEditingData.MercScpGroupCommands)) &&
                //    !parameters.IsExcluded(nameof(MercScpGroupEditingData.MercScpGroupFlashingCommands)))
                //{
                //    var MercScpGroupCommandRepository =
                //        _DataRepositoryFactory.GetDataRepository<IMercScpGroupCommandRepository>();
                //    if (!parameters.IsExcluded(nameof(MercScpGroupEditingData.MercScpGroupCommands)))
                //        MercScpGroupEditingData.MercScpGroupCommands = MercScpGroupCommandRepository.GetAllMercScpGroupCommandsForMercScpGroupType(ApplicationUserSessionHeader,
                //                new GetParametersWithPhoto() { UniqueId = parameters.UniqueId }).ToCollection();

                //    if (!parameters.IsExcluded(nameof(MercScpGroupEditingData.MercScpGroupFlashingCommands)))
                //        MercScpGroupEditingData.MercScpGroupFlashingCommands = MercScpGroupCommandRepository.GetAllMercScpGroupFlashingCommandsForMercScpGroupType(ApplicationUserSessionHeader,
                //                new GetParametersWithPhoto() { UniqueId = parameters.UniqueId }).ToCollection();
                //}

                return MercScpGroupEditingData;
            });
        }

        //// This does not support loading data to panels on more than one MercScpGroup
        //public LoadDataCommandResponse<MercScpGroupDataLoadParameters> SendMercScpGroupDataToPanels(CommandParameters<MercScpGroupDataLoadParameters> parameters)
        //{
        //    return ExecuteFaultHandledOperation(() =>
        //    {
        //        ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanAddId);

        //        if (parameters.OperationUid == Guid.Empty)
        //            parameters.OperationUid = GuidUtilities.GenerateComb();
        //        parameters.RequestDateTime = DateTimeOffset.UtcNow;

        //        var response = new LoadDataCommandResponse<MercScpGroupDataLoadParameters>(parameters) { ApproximateDuration = 60, TimeoutSeconds = Globals.Instance.LoadDataTimeoutSeconds };

        //        // Now send to the panels
        //        var sendParameters = new SendDataParameters<object>()
        //        { PopulateDataFromDatabase = true, ApplicationUserSessionHeader = this.ApplicationUserSessionHeader, OperationUid = parameters.OperationUid };
        //        sendParameters.SendToAddress.MercScpGroupUid = parameters.Data.MercScpGroupUid;
        //        sendParameters.SendToAddress.PanelUid = parameters.Data.MercScpUid;
        //        sendParameters.SendToAddress.CpuUid = parameters.Data.CpuUid;

        //        if (parameters.Data.CpuAddresses.Count == 1)
        //        {
        //            sendParameters.SendToAddress.MercScpGroupGroupId = parameters.Data.CpuAddresses[0].MercScpGroupGroupId;
        //            sendParameters.SendToAddress.MercScpGroupNumber = parameters.Data.CpuAddresses[0].MercScpGroupNumber;
        //            sendParameters.SendToAddress.PanelNumber = parameters.Data.CpuAddresses[0].PanelNumber;
        //            sendParameters.SendToAddress.CpuId = parameters.Data.CpuAddresses[0].CpuId;
        //        }

        //        var MercScpGroupUid = sendParameters.SendToAddress.MercScpGroupUid;
        //        var panelUid = sendParameters.SendToAddress.PanelUid;
        //        var cpuUid = sendParameters.SendToAddress.CpuUid;

        //        var repository = _DataRepositoryFactory.GetDataRepository<IGalaxyCpuRepository>();
        //        var cpuInfo = new List<GalaxyCpuDatabaseInformation>();

        //        if (sendParameters.SendToAddress.MercScpGroupUid != Guid.Empty)
        //        {
        //            var getHardwareAddressParameters = new GetHardwareAddressParameters() { MercScpGroupUid = sendParameters.SendToAddress.MercScpGroupUid };
        //            cpuInfo.AddRange(repository.GetGalaxyCpuInformation(ApplicationUserSessionHeader, getHardwareAddressParameters));
        //        }

        //        if (sendParameters.SendToAddress.PanelUid != Guid.Empty)
        //        {
        //            var getHardwareAddressParameters = new GetHardwareAddressParameters() { MercScpUid = sendParameters.SendToAddress.PanelUid };
        //            var cpusForPanels = repository.GetGalaxyCpuInformation(ApplicationUserSessionHeader,
        //                getHardwareAddressParameters);
        //            foreach (var c in cpusForPanels)
        //            {
        //                var existingCpu = cpuInfo.FirstOrDefault(o => o.CpuUid == c.CpuUid);
        //                if (existingCpu == null)
        //                    cpuInfo.Add(c);
        //            }
        //        }

        //        if (sendParameters.SendToAddress.CpuUid != Guid.Empty)
        //        {
        //            var getHardwareAddressParameters = new GetHardwareAddressParameters() { CpuUid = sendParameters.SendToAddress.CpuUid };
        //            var cpusForCpu = repository.GetGalaxyCpuInformation(ApplicationUserSessionHeader, getHardwareAddressParameters);
        //            foreach (var c in cpusForCpu)
        //            {
        //                var existingCpu = cpuInfo.FirstOrDefault(o => o.CpuUid == c.CpuUid);
        //                if (existingCpu == null)
        //                    cpuInfo.Add(c);
        //            }
        //        }

        //        var MercScpUid = Guid.Empty;
        //        var cpusOnlineCount = 0;

        //        // Now spin through the cpuInfo collection and send the command to each one
        //        foreach (var c in cpuInfo)
        //        {
        //            if (MercScpGroupUid == Guid.Empty)
        //            {
        //                MercScpGroupUid = c.MercScpGroupUid;
        //                //sendParameters.SendToAddress.MercScpGroupGroupId = c.MercScpGroupGroupId;
        //                //sendParameters.SendToAddress.MercScpGroupNumber = c.MercScpGroupNumber;
        //            }
        //            //if (sendParameters.SendToAddress.PanelUid == Guid.Empty)
        //            //{
        //            //    sendParameters.SendToAddress.PanelUid = c.MercScpUid;
        //            //    //sendParameters.SendToAddress.PanelNumber = c.PanelNumber;
        //            //}
        //            //if (sendParameters.SendToAddress.CpuUid == Guid.Empty)
        //            //{
        //            //    sendParameters.SendToAddress.CpuUid = c.CpuUid;
        //            //    //sendParameters.SendToAddress.CpuId = c.CpuNumber;
        //            //}

        //            if (c.CpuIsActive)
        //            {
        //                var panelSentTo =
        //                    response.PanelsSentTo.FirstOrDefault(o => o.MercScpUid == c.MercScpUid);
        //                if (panelSentTo == null)
        //                {
        //                    panelSentTo = new PanelCommandResponseInfo()
        //                    {
        //                        MercScpUid = c.MercScpUid
        //                    };
        //                    response.PanelsSentTo.Add(panelSentTo);
        //                }

        //                panelSentTo.Cpus.Add(new CpuCommandResponseInfo()
        //                {
        //                    CpuUid = c.CpuUid,
        //                    IsCpuOnline = c.IsConnected
        //                });
        //                if (c.IsConnected)
        //                {
        //                    panelSentTo.IsPanelOnline = c.IsConnected;
        //                    if (MercScpUid == Guid.Empty)
        //                        MercScpUid = c.MercScpUid;
        //                    cpusOnlineCount++;
        //                }
        //            }
        //        }

        //        LoadDataCounts counts = null;
        //        if (MercScpUid != Guid.Empty)
        //        {
        //            var MercScpRepo = _DataRepositoryFactory.GetDataRepository<IMercScpRepository>();
        //            counts = MercScpRepo.GetLoadDataCounts(MercScpUid, parameters.Data.LoadDataSettings);
        //        }


        //        if (parameters.Data.LoadDataSettings.MercScpGroupSharedSettings)
        //        {
        //            response.NotificationCounts.MercScpGroupSharedSettingsCount = cpusOnlineCount * 7;

        //            Globals.Instance.MessageBroker.SendMessage(
        //                new PDSAMessageBrokerMessage(MessageBrokerMessageNames.SendMercScpGroupSettingsToHardware, new SendDataParameters<MercScpGroup_CommonPanelLoadData>(sendParameters)
        //                {
        //                    Data = new MercScpGroup_CommonPanelLoadData()
        //                    {
        //                        MercScpGroupUid = MercScpGroupUid//parameters.Data.MercScpGroupUid,
        //                    },
        //                }));
        //        }

        //        if (parameters.Data.LoadDataSettings.PanelAlarms)
        //        {
        //            response.NotificationCounts.PanelAlarmsCount = cpusOnlineCount;
        //            Globals.Instance.MessageBroker.SendMessage(
        //                new PDSAMessageBrokerMessage(MessageBrokerMessageNames.SendPanelAlarmsToHardware, new SendDataParameters<MercScpAlarmSettings_PanelLoadData>(sendParameters)
        //                {
        //                    Data = new MercScpAlarmSettings_PanelLoadData()
        //                    {
        //                        MercScpGroupUid = MercScpGroupUid,//parameters.Data.MercScpGroupUid,
        //                        MercScpUid = parameters.Data.MercScpUid
        //                    }
        //                }));
        //        }

        //        if (parameters.Data.LoadDataSettings.TimeSchedules)
        //        {
        //            if (counts != null)
        //                response.NotificationCounts.TimeSchedulesCount = counts.TimeSchedulesCount * cpusOnlineCount;
        //            Globals.Instance.MessageBroker.SendMessage(
        //                new PDSAMessageBrokerMessage(MessageBrokerMessageNames.SendAllTimeSchedulesToHardware, new SendDataParameters<TimeSchedule_PanelLoadData>(sendParameters)
        //                {
        //                    Data = new TimeSchedule_PanelLoadData() { MercScpGroupUid = MercScpGroupUid }// parameters.Data.MercScpGroupUid, }
        //                }));
        //        }

        //        if (parameters.Data.LoadDataSettings.AllCardData)
        //        {
        //            if (counts != null)
        //                response.NotificationCounts.AllCardDataCount = counts.AllCardDataCount * cpusOnlineCount;

        //            var sendDeleteParameters = new SendDataParameters<CredentialToDeleteFromCpu>()
        //            {
        //                PopulateDataFromDatabase = true,
        //                ApplicationUserSessionHeader = this.ApplicationUserSessionHeader,
        //            };
        //            Globals.Instance.MessageBroker.SendMessage(
        //                new PDSAMessageBrokerMessage(MessageBrokerMessageNames.SendDeletedCredentialsToHardware, sendDeleteParameters));

        //            Globals.Instance.MessageBroker.SendMessage(
        //                new PDSAMessageBrokerMessage(MessageBrokerMessageNames.SendAllCredentialDataToHardware, new SendDataParameters<Credential_PanelLoadData>(sendParameters)
        //                {
        //                    Data = new Credential_PanelLoadData() { MercScpGroupUid = MercScpGroupUid }//parameters.Data.MercScpGroupUid, }
        //                }));
        //        }

        //        //if (parameters.Data.LoadDataSettings.CardChanges)
        //        //    Globals.Instance.MessageBroker.SendMessage(
        //        //        new PDSAMessageBrokerMessage(MessageBrokerMessageNames.SendCredentialChangesToHardware, sendParameters));

        //        if (parameters.Data.LoadDataSettings.InputOutputGroups)
        //        {
        //            if (counts != null)
        //                response.NotificationCounts.InputOutputGroupCount = counts.InputOutputGroupCount * cpusOnlineCount;

        //            Globals.Instance.MessageBroker.SendMessage(
        //                new PDSAMessageBrokerMessage(MessageBrokerMessageNames.SendAllMercScpGroupInputOutputGroupsToHardware, new SendDataParameters<InputOutputGroup_PanelLoadData>(sendParameters)
        //                {
        //                    Data = new InputOutputGroup_PanelLoadData() { MercScpGroupUid = MercScpGroupUid }// parameters.Data.MercScpGroupUid, }
        //                }));
        //        }

        //        if (parameters.Data.LoadDataSettings.AccessPortalsInputsOutputs)
        //        {
        //            if (counts != null)
        //            {
        //                response.NotificationCounts.AccessPortalsInputsOutputsCount = counts.AccessPortalsInputsOutputsCount * cpusOnlineCount;
        //                response.NotificationCounts.AccessRulesCount = counts.AccessPortalAccessRulesCount * cpusOnlineCount;
        //            }

        //            Globals.Instance.MessageBroker.SendMessage(
        //                new PDSAMessageBrokerMessage(MessageBrokerMessageNames.SendAccessPortalsToHardware, new SendDataParameters<GalaxyInterfaceBoardSection_PanelLoadData>(sendParameters)
        //                {
        //                    Data = new GalaxyInterfaceBoardSection_PanelLoadData()
        //                    {
        //                        MercScpGroupUid = MercScpGroupUid,// parameters.Data.MercScpGroupUid,
        //                        MercScpUid = parameters.Data.MercScpUid,
        //                    }
        //                }));
        //        }

        //        if (parameters.Data.LoadDataSettings.AccessRules)
        //        {
        //            if (counts != null)
        //                response.NotificationCounts.AccessRulesCount = counts.AccessRulesCount * cpusOnlineCount;

        //            Globals.Instance.MessageBroker.SendMessage(
        //                new PDSAMessageBrokerMessage(MessageBrokerMessageNames.SendAccessGroupSettingsToHardware, new SendDataParameters<AccessGroup_PanelLoadData>(sendParameters)
        //                {
        //                    SendToAddress = new BoardSectionNodeHardwareAddress()
        //                    {
        //                        MercScpGroupUid = MercScpGroupUid,//parameters.Data.MercScpGroupUid,
        //                        PanelUid = parameters.Data.MercScpUid,
        //                        CpuUid = parameters.Data.CpuUid
        //                    },

        //                }));
        //        }

        //        //if (parameters.Data.LoadDataSettings.InputOutputDevices)
        //        //    Globals.Instance.MessageBroker.SendMessage(
        //        //        new PDSAMessageBrokerMessage(MessageBrokerMessageNames.SendInputOutputDevicesToHardware, new SendDataParameters<GalaxyInterfaceBoardSection_PanelLoadData>(sendParameters)
        //        //        {
        //        //            Data = new GalaxyInterfaceBoardSection_PanelLoadData()
        //        //            {
        //        //                MercScpGroupUid = parameters.Data.MercScpGroupUid,
        //        //                MercScpUid = parameters.Data.MercScpUid,
        //        //            }
        //        //        }));

        //        //Globals.Instance.MessageBroker.SendMessage(
        //        //    new PDSAMessageBrokerMessage(MessageBrokerMessageNames.SendLoadDataFinished, new SendDataParameters(sendParameters)
        //        //    {
        //        //        SendToAddress = new BoardSectionNodeHardwareAddress()
        //        //        {
        //        //            MercScpGroupUid = MercScpGroupUid,//parameters.Data.MercScpGroupUid,
        //        //            PanelUid = parameters.Data.MercScpUid,
        //        //            CpuUid = parameters.Data.CpuUid
        //        //        }
        //        //    }));

        //        return response;
        //    });
        //}


        //[OperationBehavior(TransactionScopeRequired = true)]
        //public BackgroundJobInfo<LoadDataCommandResponse<MercScpGroupDataLoadParameters>> SendMercScpGroupDataToPanelsJob(CommandParameters<MercScpGroupDataLoadParameters> parameters)
        //{
        //    return ExecuteFaultHandledOperation(() =>
        //    {
        //        ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanAddId);

        //        if (parameters.OperationUid == Guid.Empty)
        //            parameters.OperationUid = GuidUtilities.GenerateComb();
        //        parameters.RequestDateTime = DateTimeOffset.UtcNow;

        //        var response = new LoadDataCommandResponse<MercScpGroupDataLoadParameters>(parameters) { ApproximateDuration = 60, TimeoutSeconds = Globals.Instance.LoadDataTimeoutSeconds };

        //        // Now send to the panels
        //        var sendParameters = new SendDataParameters<object>()
        //        { PopulateDataFromDatabase = true, ApplicationUserSessionHeader = this.ApplicationUserSessionHeader, OperationUid = parameters.OperationUid };
        //        sendParameters.SendToAddress.MercScpGroupUid = parameters.Data.MercScpGroupUid;
        //        sendParameters.SendToAddress.PanelUid = parameters.Data.MercScpUid;
        //        sendParameters.SendToAddress.CpuUid = parameters.Data.CpuUid;

        //        if (parameters.Data.CpuAddresses.Count == 1)
        //        {
        //            sendParameters.SendToAddress.MercScpGroupGroupId = parameters.Data.CpuAddresses[0].MercScpGroupGroupId;
        //            sendParameters.SendToAddress.MercScpGroupNumber = parameters.Data.CpuAddresses[0].MercScpGroupNumber;
        //            sendParameters.SendToAddress.PanelNumber = parameters.Data.CpuAddresses[0].PanelNumber;
        //            sendParameters.SendToAddress.CpuId = parameters.Data.CpuAddresses[0].CpuId;
        //        }

        //        var MercScpGroupUid = sendParameters.SendToAddress.MercScpGroupUid;
        //        var panelUid = sendParameters.SendToAddress.PanelUid;
        //        var cpuUid = sendParameters.SendToAddress.CpuUid;

        //        var repository = _DataRepositoryFactory.GetDataRepository<IGalaxyCpuRepository>();
        //        var cpuInfo = new List<GalaxyCpuDatabaseInformation>();

        //        if (sendParameters.SendToAddress.MercScpGroupUid != Guid.Empty)
        //        {
        //            var getHardwareAddressParameters = new GetHardwareAddressParameters() { MercScpGroupUid = sendParameters.SendToAddress.MercScpGroupUid };
        //            cpuInfo.AddRange(repository.GetGalaxyCpuInformation(ApplicationUserSessionHeader, getHardwareAddressParameters));
        //        }

        //        if (sendParameters.SendToAddress.PanelUid != Guid.Empty)
        //        {
        //            var getHardwareAddressParameters = new GetHardwareAddressParameters() { MercScpUid = sendParameters.SendToAddress.PanelUid };
        //            var cpusForPanels = repository.GetGalaxyCpuInformation(ApplicationUserSessionHeader,
        //                getHardwareAddressParameters);
        //            foreach (var c in cpusForPanels)
        //            {
        //                var existingCpu = cpuInfo.FirstOrDefault(o => o.CpuUid == c.CpuUid);
        //                if (existingCpu == null)
        //                    cpuInfo.Add(c);
        //            }
        //        }

        //        if (sendParameters.SendToAddress.CpuUid != Guid.Empty)
        //        {
        //            var getHardwareAddressParameters = new GetHardwareAddressParameters() { CpuUid = sendParameters.SendToAddress.CpuUid };
        //            var cpusForCpu = repository.GetGalaxyCpuInformation(ApplicationUserSessionHeader, getHardwareAddressParameters);
        //            foreach (var c in cpusForCpu)
        //            {
        //                var existingCpu = cpuInfo.FirstOrDefault(o => o.CpuUid == c.CpuUid);
        //                if (existingCpu == null)
        //                    cpuInfo.Add(c);
        //            }
        //        }

        //        var MercScpUid = Guid.Empty;
        //        var cpusOnlineCount = 0;
        //        // Now spin through the cpuInfo collection and send the command to each one
        //        foreach (var c in cpuInfo)
        //        {
        //            if (MercScpGroupUid == Guid.Empty)
        //            {
        //                MercScpGroupUid = c.MercScpGroupUid;
        //                //sendParameters.SendToAddress.MercScpGroupGroupId = c.MercScpGroupGroupId;
        //                //sendParameters.SendToAddress.MercScpGroupNumber = c.MercScpGroupNumber;
        //            }
        //            //if (sendParameters.SendToAddress.PanelUid == Guid.Empty)
        //            //{
        //            //    sendParameters.SendToAddress.PanelUid = c.MercScpUid;
        //            //    //sendParameters.SendToAddress.PanelNumber = c.PanelNumber;
        //            //}
        //            //if (sendParameters.SendToAddress.CpuUid == Guid.Empty)
        //            //{
        //            //    sendParameters.SendToAddress.CpuUid = c.CpuUid;
        //            //    //sendParameters.SendToAddress.CpuId = c.CpuNumber;
        //            //}

        //            if (c.CpuIsActive)
        //            {
        //                var panelSentTo =
        //                    response.PanelsSentTo.FirstOrDefault(o => o.MercScpUid == c.MercScpUid);
        //                if (panelSentTo == null)
        //                {
        //                    panelSentTo = new PanelCommandResponseInfo()
        //                    {
        //                        MercScpUid = c.MercScpUid
        //                    };
        //                    response.PanelsSentTo.Add(panelSentTo);
        //                }

        //                panelSentTo.Cpus.Add(new CpuCommandResponseInfo()
        //                {
        //                    CpuUid = c.CpuUid,
        //                    IsCpuOnline = c.IsConnected
        //                });
        //                if (c.IsConnected)
        //                {
        //                    panelSentTo.IsPanelOnline = c.IsConnected;
        //                    if (MercScpUid == Guid.Empty)
        //                        MercScpUid = c.MercScpUid;
        //                    cpusOnlineCount++;
        //                }
        //            }
        //        }

        //        LoadDataCounts counts = null;
        //        if (MercScpUid != Guid.Empty)
        //        {
        //            var MercScpRepo = _DataRepositoryFactory.GetDataRepository<IMercScpRepository>();
        //            counts = MercScpRepo.GetLoadDataCounts(MercScpUid, parameters.Data.LoadDataSettings);

        //            if (counts != null)
        //            {
        //                if (parameters.Data.LoadDataSettings.MercScpGroupSharedSettings)
        //                    response.NotificationCounts.MercScpGroupSharedSettingsCount = cpusOnlineCount * 7;

        //                if (parameters.Data.LoadDataSettings.PanelAlarms)
        //                    response.NotificationCounts.PanelAlarmsCount = cpusOnlineCount;

        //                if (parameters.Data.LoadDataSettings.AccessPortalsInputsOutputs)
        //                {
        //                    response.NotificationCounts.AccessPortalsInputsOutputsCount =
        //                        counts.AccessPortalsInputsOutputsCount * cpusOnlineCount;
        //                    response.NotificationCounts.AccessRulesCount =
        //                        counts.AccessPortalAccessRulesCount * cpusOnlineCount;
        //                }

        //                if (parameters.Data.LoadDataSettings.AccessRules)
        //                    response.NotificationCounts.AccessRulesCount += counts.AccessRulesCount * cpusOnlineCount;

        //                if (parameters.Data.LoadDataSettings.AllCardData)
        //                    response.NotificationCounts.AllCardDataCount = counts.AllCardDataCount * cpusOnlineCount;

        //                if (parameters.Data.LoadDataSettings.InputOutputGroups)
        //                    response.NotificationCounts.InputOutputGroupCount = counts.InputOutputGroupCount * cpusOnlineCount;

        //                if (parameters.Data.LoadDataSettings.TimeSchedules)
        //                    response.NotificationCounts.TimeSchedulesCount = counts.TimeSchedulesCount * cpusOnlineCount;
        //            }
        //        }

        //        // Assign a jobId and fill the SaveParameters.BackgroundJobId property. This will be used by the SaveEntity method to update the 
        //        // BackgroundJob tables.
        //        parameters.BackgroundJobId = GuidUtilities.GenerateComb();
        //        var jobParameters = new SaveJobParameters<CommandParameters<MercScpGroupDataLoadParameters>>()
        //        {
        //            JobId = parameters.BackgroundJobId,
        //            SaveParameters = new SaveParameters<CommandParameters<MercScpGroupDataLoadParameters>>(parameters) { },
        //            UserSessionData = ApplicationUserSessionHeader as ApplicationUserSessionHeader
        //        };

        //        var responseInfo = new BackgroundJobInfo<LoadDataCommandResponse<MercScpGroupDataLoadParameters>>(response)
        //        {
        //            JobId = jobParameters.JobId,
        //            DataType = nameof(CommandParameters<MercScpGroupDataLoadParameters>),
        //            JobType = BackgroundJobOperationType.ExecuteCommand,
        //            State = BackgroundJobState.Queued,
        //            ItemName = parameters.Data.MercScpUid.ToString()
        //        };

        //        responseInfo.DataItemUid = parameters.BackgroundJobId;
        //        responseInfo.EntityId = parameters.BackgroundJobId;

        //        var bgJob = new BackgroundJob()
        //        {
        //            BackgroundJobUid = jobParameters.JobId,
        //            UserId = UserSessionToken.UserData.UserId,
        //            State = responseInfo.State.ToString(),
        //            JobType = responseInfo.JobType.ToString(),
        //            DataType = responseInfo.DataType,
        //            ItemName = responseInfo.ItemName,
        //            InsertDate = DateTimeOffset.Now,
        //            InsertName = LoginName,
        //            UpdateDate = DateTimeOffset.Now,
        //            UpdateName = LoginName,
        //            ConcurrencyValue = 0
        //        };


        //        bgJob.DataItemUid = responseInfo.EntityId;
        //        bgJob.EntityId = responseInfo.EntityId;


        //        //// If EntityId is empty, most likely this is a new insert. If this is the case AND there is a parent entity id specified
        //        //// then use the parent entity id. This will allow the signalR hub to notify listeners who have joined the parent entity id group to 
        //        //// recieve job completion notifications
        //        //if (bgJob.EntityId == Guid.Empty && entity.ParentEntityId.HasValue)
        //        //    bgJob.EntityId = entity.ParentEntityId.Value;

        //        SaveBackgroundJob(bgJob, string.Empty, _DataRepositoryFactory);

        //        IJobMessageHandler recorder = new JobMessageHandler();
        //        recorder.HandleMessage(jobParameters);

        //        return responseInfo;

        //    });
        //}

        #endregion

        #region Mercury Scp Operations

        public ArrayResponse<MercScp> GetAllMercScps(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpRepository>();
                var data = repository.GetAllPaged(ApplicationUserSessionHeader, parameters);

                return (ArrayResponse<MercScp>)data;
            });
        }

        public ArrayResponse<MercScp> GetAllMercScpsForMercScpGroup(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                parameters.CurrentEntityId = GetEntityIdOfMercScpGroup(parameters, true);

                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpRepository>();
                var data = repository.GetAllMercScpsForMercScpGroup(ApplicationUserSessionHeader, parameters);

                return (ArrayResponse<MercScp>)data;
            });
        }

        //public MercScp[] GetAllMercScpsForEntity(GetParametersWithPhoto parameters)
        //{
        //    return ExecuteFaultHandledOperation(() =>
        //    {
        //        ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);
        //        var repository = _DataRepositoryFactory.GetDataRepository<IMercScpRepository>();
        //        var data = repository.GetAllMercScpsForEntity(ApplicationUserSessionHeader, parameters);

        //        return data.ToArray();
        //    });
        //}

        //public MercScp[] GetAllMercScpsForRegion(GetParametersWithPhoto parameters)
        //{
        //    return ExecuteFaultHandledOperation(() =>
        //    {
        //        ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);
        //        var repository = _DataRepositoryFactory.GetDataRepository<IMercScpRepository>();
        //        var data = repository.GetAllMercScpsForRegion(ApplicationUserSessionHeader, parameters);

        //        return data.ToArray();
        //    });
        //}

        public ArrayResponse<MercScp> GetAllMercScpsForSite(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                parameters.CurrentEntityId = GetEntityIdOfSite(parameters.UniqueId, true);
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpRepository>();
                var data = repository.GetAllMercScpsForSite(ApplicationUserSessionHeader, parameters);

                return (ArrayResponse<MercScp>)data;
            });
        }

        public MercScp GetMercScp(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpRepository>();
                parameters.CurrentEntityId = GetEntityIdOf(repository, parameters.UniqueId, true, nameof(MercScp), nameof(MercScp.MercScpUid));

                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);
                var data = repository.Get(parameters.UniqueId, ApplicationUserSessionHeader, parameters);
                if (data == null && parameters.ThrowExceptionIfNotFound)
                {
                    var ex =
                        new NotFoundException(string.Format(
                            "MercScp with MercScpUid of {0} is not in database", parameters.
                                UniqueId));
                    var detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return data;
            });
        }

        //public MercScp GetMercScpByHardwareAddress(GetParametersWithPhoto parameters)
        //{
        //    return ExecuteFaultHandledOperation(() =>
        //    {
        //        ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);
        //        var repository = _DataRepositoryFactory.GetDataRepository<IMercScpRepository>();
        //        var data = repository.GetByHardwareAddress(ApplicationUserSessionHeader, parameters);
        //        if (data == null && parameters.ThrowExceptionIfNotFound)
        //        {
        //            var msg = string.Empty;
        //            if (parameters.MercScpGroupUid == Guid.Empty)
        //            {
        //                msg = $"MercScp with MercScpGroupGroupId:{parameters.MercScpGroupGroupId}, MercScpGroupNumber:{parameters.MercScpGroupNumber}, PanelNumber:{parameters.PanelNumber} is not in database";
        //            }
        //            else
        //                msg = $"MercScp with MercScpGroupUid:{parameters.MercScpGroupUid}, PanelNumber:{parameters.PanelNumber} is not in database";
        //            var ex = new NotFoundException(msg);
        //            var detail = new ExceptionDetailEx(ex);
        //            throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
        //        }

        //        return data;
        //    });
        //}

        public ValidationProblemDetails ValidateMercScp(SaveParameters<MercScp> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var response = new ValidationProblemDetails();
                var errorsArray = new List<string>();
                var mercScpGroupRepo = _DataRepositoryFactory.GetDataRepository<IMercScpGroupRepository>();
                var mercScpGroupExists = mercScpGroupRepo.DoesExist(parameters.Data.MercScpGroupUid);
                if (!mercScpGroupExists)
                {
                    errorsArray.Add(
                        $"The {nameof(parameters.Data.MercScpGroupUid)} value {parameters.Data.MercScpGroupUid} does not exist in the database.");
                    response.Errors.Add($"{nameof(parameters.Data.MercScpGroupUid)}", errorsArray.ToArray());
                    return response;
                }

                //var editorDataParams = new GetParametersWithPhoto()
                //{
                //    UniqueId = parameters.Data.MercScpGroupUid
                //};
                //editorDataParams.ExcludeMemberCollectionSettings.Add(nameof(MercScpEditingData.MercScpModel635Commands));
                //var editorData = GetMercScpEditingData(editorDataParams);

                //var boardIndex = 0;
                //foreach (var b in parameters.Data.InterfaceBoards)
                //{
                //    errorsArray.Clear();
                //    var sections = new List<GalaxyInterfaceBoardSection>();
                //    if (b.InterfaceBoardSections != null)
                //        sections = b.InterfaceBoardSections.ToList();

                //    var boardType =
                //        editorData.InterfaceBoardTypes.FirstOrDefault(o =>
                //            o.InterfaceBoardTypeUid == b.InterfaceBoardTypeUid);
                //    var sectionModes =
                //        editorData.InterfaceBoardSectionModes.Where(o =>
                //            o.InterfaceBoardTypeUid == b.InterfaceBoardTypeUid);

                //    if (boardType != null)
                //    {
                //        if (sections.Count > boardType.NumberOfSections)
                //        {
                //            errorsArray.Add($"There are {sections.Count} sections specified. BoardType {boardType.TypeCode} can have {boardType.NumberOfSections} sections.");
                //        }
                //    }

                //    var sectionIndex = 0;
                //    foreach (var s in sections)
                //    {
                //        var sectionCount = sections.Count(o => o.SectionNumber == s.SectionNumber);
                //        if (sectionCount > 1)
                //        {
                //            errorsArray.Add($"There are {sectionCount} sections specified with SectionNumber {s.SectionNumber}. SectionNumbers must be unique.");
                //        }

                //        if (boardType != null)
                //        {
                //            var sectionMode = sectionModes.FirstOrDefault(o =>
                //                    o.InterfaceBoardSectionModeUid == s.InterfaceBoardSectionModeUid);

                //            if (sectionMode == null)
                //                errorsArray.Add($"InterfaceBoardSections[{sectionIndex}].SectionMode is not valid for BoardType {boardType.TypeCode}.");
                //        }

                //        sectionIndex++;
                //    }

                //    if (b.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds
                //            .GalaxyInterfaceBoardType_DualReaderInterface600)
                //    {
                //        // there must be two sections, numbered 1 & 2
                //        var invalidSections = sections.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
                //        foreach (var s in invalidSections)
                //        {
                //            errorsArray.Add(
                //                $"Invalid section number {s.SectionNumber}. This board type can only have section numbers 1 and 2");
                //        }
                //    }
                //    else if (b.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds
                //                 .GalaxyInterfaceBoardType_DualReaderInterface635)
                //    {
                //        var invalidSections = sections.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
                //        foreach (var s in invalidSections)
                //        {
                //            //sections.Remove(s);
                //            errorsArray.Add(
                //                $"Invalid section number {s.SectionNumber}. This board type can only have section numbers 1 and 2");
                //        }
                //    }
                //    else if (b.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds
                //                 .GalaxyInterfaceBoardType_DualSerialInterface635)
                //    {
                //        var invalidSections = sections.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
                //        foreach (var s in invalidSections)
                //        {
                //            //sections.Remove(s);
                //            errorsArray.Add($"Invalid section number {s.SectionNumber}. This board type can only have section numbers 1 and 2");
                //        }

                //        foreach (var s in sections)
                //        {
                //            var sectionMode = sectionModes.FirstOrDefault(o =>
                //                o.InterfaceBoardSectionModeUid == s.InterfaceBoardSectionModeUid);

                //            if (s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds
                //                    .DualSerialChannelMode_AllegionPimAba &&
                //                s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds
                //                    .DualSerialChannelMode_AllegionPimWiegand &&
                //                s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds
                //                    .DualSerialChannelMode_AssaAbloyAperio &&
                //                s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds
                //                    .DualSerialChannelMode_CypressClockDisplay &&
                //                s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds
                //                    .DualSerialChannelMode_ElevatorRelays &&
                //                s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds
                //                    .DualSerialChannelMode_LCD_4x20Display &&
                //                s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds
                //                    .DualSerialChannelMode_OutputRelays &&
                //                s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds
                //                    .DualSerialChannelMode_SaltoSallis &&
                //                s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds
                //                    .DualSerialChannelMode_RS485DoorModule &&
                //                s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds
                //                    .DualSerialChannelMode_RS485InputModule &&
                //                s.InterfaceBoardSectionModeUid !=
                //                DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Shell &&
                //                s.InterfaceBoardSectionModeUid !=
                //                DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Unused &&
                //                s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds
                //                    .DualSerialChannelMode_VeridtCac)
                //                errorsArray.Add(
                //                    $"Invalid InterfaceBoardSectionModeUid ({s.InterfaceBoardSectionModeUid}) or SectionType ({sectionMode.ModeCode}) value for board type ({b.InterfaceBoardTypeUid})");
                //        }
                //    }
                //    else if (b.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds
                //                 .GalaxyInterfaceBoardType_DigitalInputOutput600)
                //    {

                //    }
                //    else if (b.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds
                //                 .GalaxyInterfaceBoardType_KoneElevatorInterface)
                //    {

                //    }
                //    else if (b.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds
                //                 .GalaxyInterfaceBoardType_OtisElevatorInterface)
                //    {

                //    }
                //    else if (b.InterfaceBoardTypeUid ==
                //             GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_Cpu)
                //    {

                //    }
                //    else if (b.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds
                //                 .GalaxyInterfaceBoardType_Veridt_ReaderModule)
                //    {

                //    }
                //    //else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_CardTourManager)
                //    //{

                //    //}
                //    //else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface600)
                //    //{
                //    //    var invalidSections = sections.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
                //    //    foreach (var s in invalidSections)
                //    //    {
                //    //        //sections.Remove(s);
                //    //        errorsArray.Add($"Invalid section number {s.SectionNumber}. This board type can only have section numbers 1 and 2");
                //    //    }
                //    //    foreach (var s in sections)
                //    //    {
                //    //        // If the InterfaceBoardSectionModeUid is not specified, then use the SectionType enum and assign the correct Uid value
                //    //        if (s.InterfaceBoardSectionModeUid == Guid.Empty)
                //    //        {
                //    //            switch (s.SectionMode)
                //    //            {
                //    //                case PanelInterfaceBoardSectionType.DsiIngersolRandPimClockData:
                //    //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimAba;
                //    //                    break;

                //    //                case PanelInterfaceBoardSectionType.DsiIngersolRandPimWiegand:
                //    //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand;
                //    //                    break;

                //    //                case PanelInterfaceBoardSectionType.DsiAssaAbloyAperio:
                //    //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio;
                //    //                    break;

                //    //                case PanelInterfaceBoardSectionType.DsiCypressClockDisplay:
                //    //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_CypressClockDisplay;
                //    //                    break;

                //    //                case PanelInterfaceBoardSectionType.DsiElevatorControlRelays:
                //    //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_ElevatorRelays;
                //    //                    break;

                //    //                case PanelInterfaceBoardSectionType.DsiLcd4x20Display:
                //    //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_LCD_4x20Display;
                //    //                    break;

                //    //                case PanelInterfaceBoardSectionType.DsiOutputControlRelays:
                //    //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_OutputRelays;
                //    //                    break;

                //    //                case PanelInterfaceBoardSectionType.DsiSalto:
                //    //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_SaltoSallis;
                //    //                    break;

                //    //                case PanelInterfaceBoardSectionType.DrmSection:
                //    //                case PanelInterfaceBoardSectionType.None:
                //    //                case PanelInterfaceBoardSectionType.Dio8X4Outputs:
                //    //                case PanelInterfaceBoardSectionType.Dio8X4Inputs:
                //    //                case PanelInterfaceBoardSectionType.DsiRs485DoorModule:
                //    //                case PanelInterfaceBoardSectionType.DsiRs485InputModule:
                //    //                case PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                //    //                //case PanelInterfaceBoardSectionType.CardTourManagerCpu:
                //    //                case PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                //    //                case PanelInterfaceBoardSectionType.VeridtCpu:
                //    //                case PanelInterfaceBoardSectionType.VeridtReader:
                //    //                    break;
                //    //            }
                //    //        }
                //    //        if (s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimAba &&
                //    //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand &&
                //    //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio &&
                //    //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_CypressClockDisplay &&
                //    //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_ElevatorRelays &&
                //    //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_LCD_4x20Display &&
                //    //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_OutputRelays &&
                //    //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_SaltoSallis &&
                //    //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Shell &&
                //    //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Unused &&
                //    //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_VeridtCac)
                //    //            return BadRequest($"Invalid InterfaceBoardSectionModeUid ({s.InterfaceBoardSectionModeUid}) or SectionType ({s.SectionMode}) value for board type ({b.InterfaceBoardTypeUid})");
                //    //    }
                //    //}
                //    if (errorsArray.Any())
                //        response.Errors.Add($"{nameof(GalaxyInterfaceBoard)}[{boardIndex}]", errorsArray.ToArray());
                //    boardIndex++;
                //}

                //var aeIndex = 0;
                //foreach (var ae in parameters.Data.AlertEvents)
                //{
                //    errorsArray.Clear();
                //    if (ae.MercScpAlertEventTypeUid == Guid.Empty)
                //    {
                //        errorsArray.Add($"{nameof(ae.MercScpAlertEventTypeUid)} value {ae.MercScpAlertEventTypeUid} is not valid.");
                //    }
                //    else
                //    {
                //        var aeCount = parameters.Data.AlertEvents.Count(o =>
                //            o.MercScpAlertEventTypeUid == ae.MercScpAlertEventTypeUid);
                //        if (aeCount > 1)
                //        {
                //            errorsArray.Add(
                //                $"There are {aeCount} alert events specified with MercScpAlertEventTypeUid {ae.MercScpAlertEventTypeUid}. MercScpAlertEventTypeUid must be unique.");
                //        }
                //    }

                //    if (ae.AcknowledgeTimeScheduleUid != Guid.Empty)
                //    {
                //        var ts = editorData.TimeSchedules.FirstOrDefault(o => o.TimeScheduleUid == ae.AcknowledgeTimeScheduleUid);
                //        if (ts == null)
                //        {
                //            errorsArray.Add($"{nameof(ae.AcknowledgeTimeScheduleUid)} value {ae.AcknowledgeTimeScheduleUid} is not valid for {nameof(parameters.Data.MercScpGroupUid)} {parameters.Data.MercScpGroupUid}.");
                //        }
                //    }

                //    if (ae.InputOutputGroupAssignmentUid.HasValue && ae.InputOutputGroupAssignmentUid.Value != Guid.Empty && ae.InputOutputGroupUid == Guid.Empty)
                //    {
                //        ae.InputOutputGroupUid =
                //            InputOutputGroupHelpers.GetInputOutputUidFromInputOutputGroupAssignmentUid(ae.InputOutputGroupAssignmentUid.Value);
                //    }

                //    if (ae.InputOutputGroupUid != Guid.Empty)
                //    {
                //        var ts = editorData.InputOutputGroups.FirstOrDefault(o => o.InputOutputGroupUid == ae.InputOutputGroupUid);
                //        if (ts == null)
                //        {
                //            errorsArray.Add($"{nameof(ae.InputOutputGroupUid)} value {ae.InputOutputGroupUid} is not valid for {nameof(parameters.Data.MercScpGroupUid)} {parameters.Data.MercScpGroupUid}.");
                //        }
                //    }

                //    if (ae.InputOutputGroupAssignmentUid.HasValue && ae.InputOutputGroupAssignmentUid.Value != Guid.Empty)
                //    {
                //        if (!InputOutputGroupHelpers.IsInputOutputGroupAssignmentAssociatedWithInputOutputGroup(ae.InputOutputGroupAssignmentUid.Value, ae.InputOutputGroupUid))
                //        {
                //            errorsArray.Add($"{nameof(ae.InputOutputGroupAssignmentUid)} value {ae.InputOutputGroupAssignmentUid} is not valid for {nameof(ae.InputOutputGroupUid)} {ae.InputOutputGroupUid}.");
                //        }
                //    }

                //    if (errorsArray.Any())
                //        response.Errors.Add($"{nameof(parameters.Data.AlertEvents)}[{aeIndex}]", errorsArray.ToArray());
                //    aeIndex++;
                //}

                if (response.Errors.Any())
                {
                    return response;
                }

                return null;

            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public MercScp SaveMercScp(SaveParameters<MercScp> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpRepository>();
                // Must validate EntityId is set correctly. If an update, the parent Uid may not be specified. If this is the case, the
                // it must be obtained before permissions can be validated
                var entityId = Guid.Empty;
                if (parameters.Data.MercScpUid != Guid.Empty)
                {
                    entityId = repository.GetEntityId(parameters.Data.MercScpUid);
                }
                if (entityId == Guid.Empty && parameters.Data.MercScpGroupUid != Guid.Empty)
                {
                    entityId = repository.GetParentEntityId(parameters.Data.MercScpGroupUid);
                }

                if (entityId == Guid.Empty)
                {
                    var ex = new ApplicationException($"Cannot validate entityId for MercScp");
                    var detail = new ExceptionDetailEx(ex) { PreferredHttpStatusCode = HttpStatusCode.BadRequest };
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                parameters.CurrentEntityId = entityId;

                if (!parameters.DoNotValidateAuthorization)
                {
                    if (repository.DoesExist(parameters.Data.MercScpUid))
                        ValidateAuthorizationAndSetupOperation(parameters,
                            PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanUpdateId);
                    else
                        ValidateAuthorizationAndSetupOperation(parameters,
                            PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanAddId);
                }

                MercScp updatedItem = null;

                if (repository.IsUnique(parameters.Data) == false)
                {
                    if (repository.IsPanelNameUnique(parameters.Data) == false)
                    {
                        var ex =
                            new DuplicateIndexException(
                                string.Format(
                                    "MercScp with Name of '{0}' cannot be saved because it is a duplicate.",
                                    parameters.Data.ScpName));
                        var detail = new ExceptionDetailEx(ex);
                        throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                    }

                    if (repository.IsPanelMacAddressUnique(parameters.Data) == false)
                    {
                        var ex =
                            new DuplicateIndexException(
                                string.Format(
                                    "MercScp with MacAddress of '{0}' cannot be saved because it is a duplicate.",
                                    parameters.Data.MacAddress));
                        var detail = new ExceptionDetailEx(ex);
                        throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                    }
                }

                //var dirtyBoards = parameters.Data.InterfaceBoards.Where(b => b.GalaxyInterfaceBoardUid == Guid.Empty || b.IsAnythingDirty == true).ToCollection();
                //var newCpuNumbers = parameters.Data.Cpus.Where(c => c.CpuUid == Guid.Empty).Select(o => o.CpuNumber).ToList();
                parameters.Data.UpdateDate = DateTimeOffset.Now;
                parameters.Data.UpdateName = LoginName;
                if (parameters.Data.MercScpUid == Guid.Empty)
                {
                    parameters.Data.MercScpUid = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                }

                if (repository.DoesExist(parameters.Data.MercScpUid) == false)
                {
                    parameters.Data.InsertDate = DateTimeOffset.Now;
                    parameters.Data.InsertName = LoginName;
                    updatedItem = repository.Add(parameters.Data, ApplicationUserSessionHeader, parameters);
                    //if (!newCpuNumbers.Any())
                    //{
                    //    foreach (var cpu in updatedItem.Cpus)
                    //    {
                    //        newCpuNumbers.Add(cpu.CpuNumber);
                    //    }
                    //}
                }
                else
                {
                    updatedItem = repository.Update(parameters.Data, ApplicationUserSessionHeader, parameters);
                }

                //var newCpus = updatedItem.Cpus.Where(p => newCpuNumbers.Contains(p.CpuNumber)).ToList();
                //foreach (var cpu in newCpus)
                //{
                //    //////////////////////////////////////////////////////////////////////////////////////////
                //    var cpuRepository = _DataRepositoryFactory.GetDataRepository<IGalaxyCpuRepository>();
                //    var cpuInfo = cpuRepository.GetGalaxyCpuInformation(this.ApplicationUserSessionHeader, new GetHardwareAddressParameters()
                //    {
                //        CpuUid = cpu.CpuUid,
                //    });

                //    // Notify the communication connection about the new data.
                //    var sendParameters = new SendDataParameters<GalaxyCpuDatabaseInformation>()
                //    { PopulateDataFromDatabase = false, ApplicationUserSessionHeader = this.ApplicationUserSessionHeader };
                //    sendParameters.Data = cpuInfo.FirstOrDefault();
                //    Globals.Instance.MessageBroker.SendMessage(
                //        new PDSAMessageBrokerMessage(MessageBrokerMessageNames.GalaxyCpuDatabaseInformationSaved, sendParameters));
                //}

                //// for each board that has dirty data, push the section(s) to the panel
                //foreach (var dirtyBoard in dirtyBoards)
                //{
                //    foreach (var section in dirtyBoard.InterfaceBoardSections.Where(s => s.IsAnythingDirty).ToCollection())
                //    {
                //        var sendParameters = new SendDataParameters<GalaxyInterfaceBoardSection_PanelLoadData>()
                //        { PopulateDataFromDatabase = true, ApplicationUserSessionHeader = this.ApplicationUserSessionHeader };
                //        sendParameters.Data.GalaxyInterfaceBoardSectionUid = section.GalaxyInterfaceBoardSectionUid;
                //        Globals.Instance.MessageBroker.SendMessage(
                //            new PDSAMessageBrokerMessage(MessageBrokerMessageNames.SendInterfaceBoardSectionDataToHardware, sendParameters));
                //    }
                //}

                //var sendParameters2 = new SendDataParameters<GalaxyCpuDatabaseInformation>()
                //{ PopulateDataFromDatabase = false, ApplicationUserSessionHeader = this.ApplicationUserSessionHeader };
                //sendParameters2.Data = new GalaxyCpuDatabaseInformation()
                //{
                //    MercScpUid = updatedItem.MercScpUid,
                //    MercScpGroupGroupId = updatedItem.MercScpGroupGroupId,
                //    MercScpGroupNumber = updatedItem.MercScpGroupNumber,
                //    PanelNumber = updatedItem.PanelNumber,
                //    CpuNumber = (short)CpuHardwareAddress.CpuNumber.Both
                //};
                //Globals.Instance.MessageBroker.SendMessage(
                //    new PDSAMessageBrokerMessage(MessageBrokerMessageNames.SendRefreshMercScpDataFromDb, sendParameters2));


                //Globals.Instance.MessageBroker.SendMessage(new PDSAMessageBrokerMessage(MessageBrokerMessageNames.SendPanelAlarmsToHardware, new SendDataParameters<MercScpAlarmSettings_PanelLoadData>()
                //{
                //    PopulateDataFromDatabase = true,
                //    ApplicationUserSessionHeader = this.ApplicationUserSessionHeader,
                //    Data = new MercScpAlarmSettings_PanelLoadData() { MercScpUid = parameters.Data.MercScpUid }
                //}));
                return updatedItem;
            });
        }


        [OperationBehavior(TransactionScopeRequired = true)]
        public SaveResponse<List<MercuryPanel>> SaveMercuryPanels(SaveParameters<List<MercuryPanel>> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var results = new SaveResponse<List<MercuryPanel>>()
                {
                    SaveType = parameters.SaveType,
                    OperationUid = parameters.OperationUid,
                };
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpRepository>();
                var x = 0;
                foreach (var mp in parameters.Data)
                {
                    var guidMpExists = false;
                    if (!string.IsNullOrEmpty(mp.Guid))
                    {
                        var mpGuid = Guid.Empty;
                        if (Guid.TryParse(mp.Guid, out mpGuid))
                        {
                            guidMpExists = repository.DoesExist(mpGuid);
                        }
                    }

                    var macAddressExists = repository.DoesMacAddressExist(mp.MacAddress);
                    if (parameters.SaveType == SaveOperationType.AddOnly && macAddressExists )
                    {
                        var errors = new List<string> {$"Cannot add {nameof(MercuryPanel)} with {nameof(MercuryPanel.MacAddress)} '{mp.MacAddress}' because it already exists."};
                        results.Errors.Add($"{nameof(MercuryPanel)}[{x}]", errors.ToArray());
                    }
                    else if (parameters.SaveType == SaveOperationType.AddOnly && !string.IsNullOrEmpty(mp.Guid) &&
                             guidMpExists)
                    {
                        var errors = new List<string> { $"Cannot add {nameof(MercuryPanel)} with {nameof(MercuryPanel.Guid)} '{mp.Guid}' because it already exists." };
                        results.Errors.Add($"{nameof(MercuryPanel)}[{x}]", errors.ToArray());
                    }
                    else if (parameters.SaveType == SaveOperationType.UpdateOnly )
                    {
                        if( !string.IsNullOrEmpty(mp.Guid))
                        {
                            if (!guidMpExists)
                            {
                                var errors = new List<string>
                                {
                                    $"Cannot update {nameof(MercuryPanel)} with {nameof(MercuryPanel.Guid)} '{mp.Guid}' because it does not exist."
                                };
                                results.Errors.Add($"{nameof(MercuryPanel)}[{x}]", errors.ToArray());
                            }
                        }
                        else if (!macAddressExists)
                        {
                            var errors = new List<string>
                            {
                                $"Cannot update {nameof(MercuryPanel)} with {nameof(MercuryPanel.MacAddress)} '{mp.MacAddress}' because it does not exist."
                            };
                            results.Errors.Add($"{nameof(MercuryPanel)}[{x}]", errors.ToArray());
                        }
                    }

                    x++;
                }

                if (results.Errors.Any())
                {
                    results.HttpStatus = HttpStatusCode.BadRequest;
                    return results;
                }

                foreach (var mp in parameters.Data)
                {
                    var existingItem = repository.GetByMacAddress(this.ApplicationUserSessionHeader,
                        new GetParametersWithPhoto(parameters) { GetString = mp.MacAddress });
                    bool allowConnection = false;
                    var scpTypeUid = MercScpTypeIds.Lp1501;
                    switch (mp.PanelType)
                    {
                        case MercuryPanelType.LP1501:
                            scpTypeUid = MercScpTypeIds.Lp1501;
                            allowConnection = true;
                            break;

                        case MercuryPanelType.LP1502:
                            scpTypeUid = MercScpTypeIds.Lp1502;
                            allowConnection = true;
                            break;

                        case MercuryPanelType.LP2500:
                            scpTypeUid = MercScpTypeIds.Lp2500;
                            allowConnection = true;
                            break;

                        case MercuryPanelType.LP4502:
                            scpTypeUid = MercScpTypeIds.Lp4502;
                            allowConnection = true;
                            break;

                        case MercuryPanelType.SCP:
                            scpTypeUid = MercScpTypeIds.SCP;
                            break;

                        case MercuryPanelType.SCPC:
                            scpTypeUid = MercScpTypeIds.SCPC;
                            break;

                        case MercuryPanelType.SCPE:
                            scpTypeUid = MercScpTypeIds.SCPE;
                            break;

                        case MercuryPanelType.PW5000:
                            scpTypeUid = MercScpTypeIds.PW5000;
                            break;

                        case MercuryPanelType.PW5000A:
                            scpTypeUid = MercScpTypeIds.PW5000A;
                            break;

                        case MercuryPanelType.PW3000:
                            scpTypeUid = MercScpTypeIds.PW3000;
                            break;

                        case MercuryPanelType.EP1501:
                            scpTypeUid = MercScpTypeIds.EP1501;
                            break;

                        case MercuryPanelType.EP1502:
                            scpTypeUid = MercScpTypeIds.EP1502;
                            break;

                        case MercuryPanelType.EP2500:
                            scpTypeUid = MercScpTypeIds.EP2500;
                            break;

                        case MercuryPanelType.EP4502:
                            scpTypeUid = MercScpTypeIds.EP4502;
                            break;

                        case MercuryPanelType.PW6000:
                            scpTypeUid = MercScpTypeIds.PW6000;
                            break;

                        case MercuryPanelType.PRO3200:
                            scpTypeUid = MercScpTypeIds.PRO3200;
                            break;

                        case MercuryPanelType.NXT:
                            scpTypeUid = MercScpTypeIds.NXT;
                            break;

                        case MercuryPanelType.MIRS4:
                            scpTypeUid = MercScpTypeIds.MIRS4;
                            break;

                        case MercuryPanelType.MIXL16:
                            scpTypeUid = MercScpTypeIds.MIXL16;
                            break;

                        case MercuryPanelType.MSICS:
                            scpTypeUid = MercScpTypeIds.MSICS;
                            break;

                        case MercuryPanelType.M5IC:
                            scpTypeUid = MercScpTypeIds.M5IC;
                            break;

                        case MercuryPanelType.SSC:
                            scpTypeUid = MercScpTypeIds.SSC;
                            break;

                        case MercuryPanelType.AP2:
                            scpTypeUid = MercScpTypeIds.AP2;
                            break;

                        case MercuryPanelType.X1100:
                            scpTypeUid = MercScpTypeIds.X1100;
                            break;

                        case MercuryPanelType.PW7000:
                            scpTypeUid = MercScpTypeIds.PW7000;
                            break;

                        case MercuryPanelType.PRO4200:
                            scpTypeUid = MercScpTypeIds.PRO4200;
                            break;

                        default:
                            continue;
                            break;

                    }
                    if (existingItem != null)
                    {
                        if (existingItem.Online != mp.Online ||
                            existingItem.LastConnected != mp.LastConnected ||
                            existingItem.Serialnumber != mp.Serialnumber ||
                            existingItem.MercScpTypeUid != scpTypeUid)
                        {
                            existingItem.Online = mp.Online;
                            existingItem.LastConnected = mp.LastConnected;
                            existingItem.Serialnumber = mp.Serialnumber;
                            existingItem.MercScpTypeUid = scpTypeUid;
                            existingItem.UpdateDate = DateTimeOffset.Now;
                            existingItem.UpdateName = LoginName;
                            var updatedItem = repository.Update(existingItem, ApplicationUserSessionHeader, parameters);
                            if (updatedItem != null)
                            {
                                mp.Guid = updatedItem.MercScpUid.ToString();
                                results.Data.Add(mp);
                            }
                        }
                        else
                        {
                            //existingItem.Online = mp.Online;
                            //existingItem.LastConnected = mp.LastConnected;
                            //existingItem.SerialNumber = mp.Serialnumber;
                            //existingItem.AllowConnection = mp.Authorized.Value;
                            results.Data.Add(mp);
                        }
                    }
                    else
                    {
                        var g = GuidUtilities.GenerateComb();
                        if (string.IsNullOrEmpty(mp.Guid))
                        {
                            mp.Guid = g.ToString();
                        }
                        else
                        {
                            if (Guid.TryParse(mp.Guid, out g))
                            {

                            }
                            else
                            {
                                mp.Guid = g.ToString();
                            }
                        }

                        var saveThisScp = new MercScp()
                        {
                            MercScpUid = g,
                            MacAddress = mp.MacAddress,
                            Serialnumber = mp.Serialnumber,
                            MercScpTypeUid = scpTypeUid,
                            MercScpGroupUid = MercScpGroupIds.Default,
                            ScpName = mp.Name,
                            Description = mp.Description,
                            ConnectionType = (int)MercScpConnectionType.IPClient,
                            AllowConnection = allowConnection,
                            IpPort = 3001,
                            ScpReplyTimeout = 500,
                            TcpConnectRetryInterval = 30000,
                            RetryCountBeforeOffline = 0,
                            OfflineTime = 15000,
                            PollDelay = 5000,
                            TimeZoneId = System.TimeZone.CurrentTimeZone.StandardName,
                            UseDaylightSavingsTime = true,
                            TransactionCount = 100000,
                            TransactionUnreportedLimit = 50000,
                            DualPortEnabled = false,
                            ConnectionTypeAlt= (int)MercScpConnectionType.None,
                            RetryCountBeforeOfflineAlt = 0,
                            PollDelayAlt = 5000,
                            IpPortAlt = 3001,
                            InsertDate = DateTimeOffset.Now,
                            UpdateDate = DateTimeOffset.Now,
                            InsertName = LoginName,
                            UpdateName = LoginName,
                            Online = mp.Online,
                            LastConnected = mp.LastConnected
                        };
                        var updatedItem = repository.Add(saveThisScp, ApplicationUserSessionHeader, parameters);
                        if (updatedItem != null)
                        {
                            mp.Guid = updatedItem.MercScpUid.ToString();
                            results.Data.Add(mp);
                        }
                    }
                }

                results.HttpStatus = HttpStatusCode.OK;
                return results;
            });

        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteMercScpByPk(DeleteParameters parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpRepository>();
                parameters.CurrentEntityId = GetEntityIdOf(repository, parameters.UniqueId, true, nameof(MercScp), nameof(MercScp.MercScpUid));

                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanDeleteId);

                return repository.Remove(parameters.UniqueId, ApplicationUserSessionHeader);
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteMercScp(DeleteParameters<MercScp> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpRepository>();
                parameters.CurrentEntityId = GetEntityIdOf(repository, parameters.Data.MercScpUid, true, nameof(MercScp), nameof(MercScp.MercScpUid));

                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanDeleteId);
                return repository.Remove(parameters.Data, ApplicationUserSessionHeader);
            });
        }

        public bool IsMercScpReferenced(Guid uid)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpRepository>();

                bReturn = repository.IsReferenced(uid);
                return bReturn;
            });
        }

        public bool IsMercScpUnique(MercScp data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpRepository>();

                bReturn = repository.IsUnique(data);
                return bReturn;
            });
        }

        public MercScpEditingData GetMercScpEditingData(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var panelEditingData = new MercScpEditingData();
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);
                //        if (!parameters.IsExcluded(nameof(MercScpEditingData.PanelModels)))
                //        {
                //            var panelModelRepository = _DataRepositoryFactory.GetDataRepository<IMercScpModelRepository>();
                //            panelEditingData.PanelModels =
                //                panelModelRepository.GetAll(ApplicationUserSessionHeader, parameters).OrderBy(o => o.
                //                    Display).ToCollection();
                //        }

                //        if (!parameters.IsExcluded(nameof(MercScpEditingData.CpuModels)))
                //        {
                //            var cpuModelRepository = _DataRepositoryFactory.GetDataRepository<IGalaxyCpuModelRepository>();
                //            panelEditingData.CpuModels =
                //                cpuModelRepository.GetAll(ApplicationUserSessionHeader, parameters).OrderBy(o => o.Display)
                //                    .ToCollection();
                //        }

                //        if (!parameters.IsExcluded(nameof(MercScpEditingData.InterfaceBoardTypes)))
                //        {
                //            var interfaceBoardTypeRepository =
                //                _DataRepositoryFactory.GetDataRepository<IGalaxyInterfaceBoardTypeRepository>();

                //            panelEditingData.InterfaceBoardTypes =
                //                interfaceBoardTypeRepository.GetAll(ApplicationUserSessionHeader, parameters).
                //                    OrderBy(o => o.Display).ToCollection();
                //        }

                //        if (!parameters.IsExcluded(nameof(MercScpEditingData.InterfaceBoardSectionModes)))
                //        {
                //            var interfaceBoardSectionModeRepository = _DataRepositoryFactory.GetDataRepository<
                //                IGalaxyInterfaceBoardSectionModeRepository>();
                //            panelEditingData.InterfaceBoardSectionModes =
                //                interfaceBoardSectionModeRepository.GetAll(ApplicationUserSessionHeader,
                //                    parameters).OrderBy(o => o.Display).ToCollection();
                //        }

                //        if (!parameters.IsExcluded(nameof(MercScpEditingData.GalaxyHardwareModuleTypes)))
                //        {
                //            var hardwareModuleTypeRepository =
                //                _DataRepositoryFactory.GetDataRepository<IGalaxyHardwareModuleTypeRepository>();
                //            panelEditingData.GalaxyHardwareModuleTypes =
                //                hardwareModuleTypeRepository.GetAll(ApplicationUserSessionHeader,
                //                    parameters).OrderBy(o => o.Display).ToCollection();
                //        }

                //        if (!parameters.IsExcluded(nameof(MercScpEditingData.InputOutputGroups)))
                //        {
                //            var ioGroupRepository =
                //                _DataRepositoryFactory.GetDataRepository<IGalaxyInputOutputGroupRepository>();
                //            panelEditingData.InputOutputGroups = ioGroupRepository.GetAllGalaxyInputOutputGroupsForMercScpGroup(ApplicationUserSessionHeader, parameters).Items.OrderBy(o => o.Display).ToCollection();
                //        }


                //        if (!parameters.IsExcluded(nameof(MercScpEditingData.AlertEventTypes)))
                //        {
                //            var alertEventTypeRepository =
                //                _DataRepositoryFactory.GetDataRepository<IMercScpAlertEventTypeRepository>();
                //            panelEditingData.AlertEventTypes = alertEventTypeRepository.GetAll(ApplicationUserSessionHeader, parameters).ToCollection();
                //        }

                //        if (!parameters.IsExcluded(nameof(MercScpEditingData.TimeSchedules)))
                //        {
                //            var timeScheduleRepository = _DataRepositoryFactory.GetDataRepository<ITimeScheduleRepository>();
                //            parameters.IncludeMemberCollections = false;
                //            panelEditingData.TimeSchedules = timeScheduleRepository.GetAllTimeSchedulesForGalaxyMercScpGroup(ApplicationUserSessionHeader, parameters).Items.ToCollection();
                //        }

                //        if (!parameters.IsExcluded(nameof(MercScpEditingData.MercScpModel635Commands)))
                //        {
                //            var _galaxyPanelCommandRepository = _DataRepositoryFactory.GetDataRepository<IMercScpCommandRepository>();
                //            panelEditingData.MercScpModel635Commands = _galaxyPanelCommandRepository.GetAllMercScpCommandForPanelModel(ApplicationUserSessionHeader, new GetParametersWithPhoto() { UniqueId = GalaxySMS.Common.Constants.MercScpTypeIds.MercScpType_635 }).ToCollection();
                //        }

                //        //if (!parameters.IsExcluded(nameof(MercScpEditingData.MercScpModel600Commands)))
                //        //{
                //        //    var _galaxyPanelCommandRepository = _DataRepositoryFactory.GetDataRepository<IMercScpCommandRepository>();
                //        //    panelEditingData.MercScpModel600Commands = _galaxyPanelCommandRepository.GetAllMercScpCommandForPanelModel(ApplicationUserSessionHeader, new GetParametersWithPhoto() { UniqueId = GalaxySMS.Common.Constants.MercScpTypeIds.MercScpType_600 }).ToCollection();
                //        //}


                return panelEditingData;
            });
        }

        public ArrayResponse<ActivityHistoryEvent> GetMercScpActivityHistoryEvents(
            ActivityHistoryEventSearchParameters parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<IMercScpRepository>();
                var data = repository.GetActivityHistoryEvents(ApplicationUserSessionHeader, parameters);

                return (ArrayResponse<ActivityHistoryEvent>)data;
            });
        }


        #endregion
    }

}

