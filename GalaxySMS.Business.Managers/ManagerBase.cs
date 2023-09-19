using GalaxySMS.Business.Entities;
using GalaxySMS.Common;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;
using GCS.Core.Common.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Threading;
using GalaxySMS.Data;
using GCS.Framework.Caching;
using System.Transactions;
using GalaxySMS.Data.Contracts;
using GCS.Core.Common.Utils;

namespace GalaxySMS.Business.Managers
{
    //[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    //public class AuthorizeEnumAttribute : AuthorizeAttribute
    //{
    //    public AuthorizeEnumAttribute(params object[] roles)
    //    {
    //        if (roles.Any(r => r.GetType().BaseType != typeof(Enum)))
    //            throw new ArgumentException("roles");

    //        this.Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
    //    }
    //}

    public class ManagerBase
    {
        [Import] public ICacheManager _CacheManager { get; internal set; }

        public ManagerBase()
        {
#if PDSANoLicense
#else
            try
            {
                // Set Entry Assembly
                //                var executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                var executingAssembly = System.Reflection.Assembly.GetEntryAssembly();
                //this.Log()
                //    .DebugFormat(
                //        "ManagerBase constructor PDSA.Common.PDSACheckAssembly.SetEntryAssembly. ExecutingAssembly={0}",
                //        executingAssembly.FullName);
                PDSA.Common.PDSACheckAssembly.SetEntryAssembly(executingAssembly);

                // Check PDSA License
                //this.Log().DebugFormat("ManagerBase constructor PDSA.Common.PDSACheckAssembly.CheckPDSALicense");
                PDSA.Common.PDSACheckAssembly.CheckPDSALicense();
                //this.Log()
                //    .DebugFormat("ManagerBase constructor PDSA.Common.PDSACheckAssembly.CheckPDSALicense finished");
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//ManagerBase constructor exception:", ex);
            }

#endif
            GetApplicationUserSessionHeader();
            if (!_CacheManager.IsInitialized)
            {
                _CacheManager.Enabled = Globals.Instance.RedisCacheEnabled;
                if (_CacheManager.Enabled)
                {
                    var cacheInitialized = _CacheManager.Initialize(Globals.Instance.RedisConnectionString);
                }
            }
        }

        protected void GetApplicationUserSessionHeader()
        {
            OperationContext context = OperationContext.Current;
            if (context != null)
            {
                if (context.IncomingMessageHeaders == null)
                    _clientUserSessionData = new ApplicationUserSessionHeader();
                else
                {
                    try
                    {
                        _clientUserSessionData =
                            OperationContext.Current.IncomingMessageHeaders.GetHeader<ApplicationUserSessionHeader>(
                                HeaderNames.ApplicationUserSessionHeaderName, HeaderNames.HeaderNamespace);
                    }
                    catch (System.ServiceModel.MessageHeaderException)
                    {
                        _clientUserSessionData = new ApplicationUserSessionHeader();
                    }
                    catch (Exception ex)
                    {
                        _clientUserSessionData = new ApplicationUserSessionHeader();
                    }
                }
                UserSessionToken = Globals.Instance.GetUserBySessionId(GalaxyUserSessionGuid);
                if (_clientUserSessionData != null && UserSessionToken?.UserData != null)
                {
                    _clientUserSessionData.UserId = UserId;
                    _clientUserSessionData.UserName = UserSessionToken.UserData.UserName;
                    if (UserSessionToken.CurrentEntityId == Guid.Empty)
                        UserSessionToken.CurrentEntityId = UserSessionToken.UserData.PrimaryEntityId;
                    _clientUserSessionData.CurrentEntityId = UserSessionToken.CurrentEntityId;
                }
                //if( _clientUserSessionData.CurrentEntityId != Guid.Empty &&
                //    UserSessionToken.CurrentEntityId != _clientUserSessionData.CurrentEntityId)
                //    UserSessionToken.CurrentEntityId = _clientUserSessionData.CurrentEntityId;
            }

            try
            {
                //if (ObjectBase.Container != null)
                //    ObjectBase.Container.SatisfyImportsOnce(this);
                if (StaticObjects.Container != null)
                    StaticObjects.Container.SatisfyImportsOnce(this);

                //if (!string.IsNullOrWhiteSpace(LoginName))
                //    _AuthorizationAccount = LoadAuthorizationValidationAccount(LoginName);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    this.Log().DebugFormat("{0}", ex.InnerException.Message);
                ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }
        }

        protected virtual Account LoadAuthorizationValidationAccount(string loginName)
        {
            return null;
        }

        Account _AuthorizationAccount = null;
        private IApplicationUserSessionDataHeader _clientUserSessionData = new ApplicationUserSessionHeader();

        public IApplicationUserSessionDataHeader ApplicationUserSessionHeader
        {
            get { return _clientUserSessionData; }
        }

        public string LoginName
        {
            get
            {
                if (UserSessionToken?.UserData != null)
                    if (!string.IsNullOrEmpty(UserSessionToken.UserData.UserName))
                        return UserSessionToken.UserData.UserName;
                return _clientUserSessionData.UserName;
            }
        }

        public Guid UserId
        {
            get
            {
                if (UserSessionToken?.UserData != null)
                    return UserSessionToken.UserData.UserId;
                return Guid.Empty;
            }
        }
        public UserSessionToken UserSessionToken { get; internal set; }
        //public Guid GalaxyUserSessionGuid { get { return _clientUserSessionData.SessionGuid; } }
        public Guid GalaxyUserSessionGuid
        {
            get
            {
                if (UserSessionToken == null)
                    return _clientUserSessionData.SessionGuid;
                return UserSessionToken.SessionId;
            }
        }

        public Guid CurrentEntityId
        {
            get
            {
                if (UserSessionToken == null)
                    return Guid.Empty;
                return UserSessionToken.CurrentEntityId;
            }
        }

        public Guid CurrentSiteId
        {
            get { return _clientUserSessionData.CurrentSiteId; }
        }

        public Guid GalaxyOperationGuid
        {
            get { return _clientUserSessionData.OperationGuid; }
        }

        public string CultureName
        {
            get { return _clientUserSessionData.Culture; }
        }

        public string UiCultureName
        {
            get { return _clientUserSessionData.UiCulture; }
        }

        //public DateTimeOffset ClientDateTime { get { return _clientUserSessionData.ClientDateTime; } }

        public string ClientTimeZoneId
        {
            get { return _clientUserSessionData.ClientTimeZoneId; }
        }

        protected void ValidateAuthorization(IAccountOwnedEntity entity)
        {
            if (!Thread.CurrentPrincipal.IsInRole(Security.GalaxySMSAdminRole))
            {
                if (_AuthorizationAccount != null)
                {
                    if (LoginName != string.Empty && entity.OwnerAccountId != _AuthorizationAccount.AccountId)
                    {
                        AuthorizationValidationException ex =
                            new AuthorizationValidationException(
                                "Attempt to access a secure record with improper user authorization validation.");
                        throw new FaultException<AuthorizationValidationException>(ex, ex.Message);
                    }
                }
            }
        }

        public bool ValidateUserHasEntityAccess(Guid entityId, bool bThrowException)
        {
            if (entityId == Guid.Empty)
            {
                if (bThrowException)
                    throw new UnauthorizedAccessException();
                return false;
            }

            if (UserSessionToken == null)
            {
                if (bThrowException)
                    throw new UnauthorizedAccessException();
                return false;
            }

            if (UserSessionToken.IsSessionExpired)
            {
                if (bThrowException)
                    throw new UnauthorizedAccessException();
                return false;
            }

            if (!Globals.Instance.DoesEntityExist(entityId))
            {
                if (bThrowException)
                    throw new NotFoundException($"The EntityId:{entityId} {GalaxySMS.Business.Managers.Support.MagicStringsExceptionMessages.not_found}");
                return false;
            }

            if (!Globals.Instance.DoesUserHaveEntity(UserId, entityId))
            {
                if (bThrowException)
                    throw new UnauthorizedAccessException($"The {GalaxySMS.Business.Managers.Support.MagicStringsExceptionMessages.entity_forbidden}");
                return false;
            }
            return true;
        }

        protected void ValidateAuthorizationAndSetupOperation(ISaveParameters<object> parameters, Guid permissionRequired)
        {
            if (parameters.Data == null)
                throw new ArgumentNullException();
            var permissionsRequired = new List<Guid> { permissionRequired };
            ValidateAuthorizationAndSetupOperation(parameters, permissionsRequired, PermissionsCheck.CanHaveAny, DeviceType.None);
        }


        protected void ValidateUserAuthorization(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentNullException();
            if( ApplicationUserSessionHeader?.UserId != userId)
                    throw new UnauthorizedAccessException();
            if (UserSessionToken?.UserData?.UserId != userId)
                throw new UnauthorizedAccessException();
        }

        protected void ValidateEntityAuthorizationAndSetupOperation(Guid entityId, Guid permissionRequired)
        {
            if (entityId == Guid.Empty)
                throw new ArgumentNullException();
            var permissionsRequired = new List<Guid> { permissionRequired };
            ValidateEntityAuthorizationAndSetupOperation(entityId, permissionsRequired, PermissionsCheck.CanHaveAny, DeviceType.None);
        }

        protected void ValidateAuthorizationAndSetupOperation(ICallParametersBase parameters, Guid permissionRequired)
        {
            if (!parameters.DoNotValidateAuthorization)
            {
                var permissionsRequired = new List<Guid> {permissionRequired};
                ValidateAuthorizationAndSetupOperation(parameters, permissionsRequired, PermissionsCheck.CanHaveAny,
                    DeviceType.None);
            }
        }

        protected void ValidateAuthorizationAndSetupDeviceOperation(ICallParametersBase parameters, Guid permissionRequired, DeviceType deviceType)
        {
            if (!parameters.DoNotValidateAuthorization)
            {
                var permissionsRequired = new List<Guid> {permissionRequired};
                ValidateAuthorizationAndSetupOperation(parameters, permissionsRequired, PermissionsCheck.CanHaveAny,
                    deviceType);
            }
        }

        protected void ValidateAuthorizationAndSetupOperation(ICallParametersBase parameters, List<Guid> permissionsRequired, PermissionsCheck permissionRule, DeviceType deviceType)
        {
            if (parameters.DoNotValidateAuthorization)
                return;
            if (permissionsRequired?.Count > 0 && permissionsRequired[0] != Guid.Empty || permissionsRequired[0] == PermissionIds.GalaxySMSDataAccessPermission.IsLoggedOn)
            {
                if (UserSessionToken == null)
                    throw new UnauthorizedAccessException();
            }

            if (ApplicationUserSessionHeader.CurrentEntityId == Guid.Empty)
            {
                if (parameters.CurrentEntityId != Guid.Empty)
                    ApplicationUserSessionHeader.CurrentEntityId = parameters.CurrentEntityId;
                else if (CurrentEntityId != Guid.Empty)
                    ApplicationUserSessionHeader.CurrentEntityId = CurrentEntityId;
            }
            else if (ApplicationUserSessionHeader.CurrentEntityId != parameters.CurrentEntityId && parameters.CurrentEntityId != Guid.Empty)
                ApplicationUserSessionHeader.CurrentEntityId = parameters.CurrentEntityId;

            if (ApplicationUserSessionHeader.CurrentSiteId == Guid.Empty)
            {
                if (parameters.CurrentSiteUid != Guid.Empty)
                    ApplicationUserSessionHeader.CurrentSiteId = parameters.CurrentSiteUid;
                else if (CurrentSiteId != Guid.Empty)
                    ApplicationUserSessionHeader.CurrentSiteId = CurrentSiteId;
            }

            if (permissionsRequired?.Count == 1 && permissionsRequired[0] == Guid.Empty && deviceType == DeviceType.None)
                return;

            if (UserSessionToken != null)
            {
                if (UserSessionToken.IsSessionExpired)
                    throw new UnauthorizedAccessException();

                var entityExists = Globals.Instance.DoesEntityExist(ApplicationUserSessionHeader.CurrentEntityId);
                if (!entityExists)
                    throw new NotFoundException($"EntityId:{ApplicationUserSessionHeader.CurrentEntityId} {GalaxySMS.Business.Managers.Support.MagicStringsExceptionMessages.not_found}");

                var userHasEntity = Globals.Instance.DoesUserHaveEntity(UserId, ApplicationUserSessionHeader.CurrentEntityId);
                if (userHasEntity == false)
                    ApplicationUserSessionHeader.CurrentEntityId = Guid.Empty;

                if (permissionsRequired?.Count > 0)
                {
                    if (deviceType == DeviceType.None)
                    {
                        int hasPermissionCount = 0;
                        foreach (var p in permissionsRequired)
                        {
                            //if (UserSessionToken.HasPermission(ApplicationUserSessionHeader.CurrentEntityId, p))
                            if (Globals.Instance.DoesUserHavePermission(UserId, ApplicationUserSessionHeader.CurrentEntityId, p))
                            {
                                hasPermissionCount++;
                                if (permissionRule == PermissionsCheck.CanHaveAny)
                                    return;
                            }
                        }

                        switch (permissionRule)
                        {
                            case PermissionsCheck.CanHaveAny:
                                if (hasPermissionCount == 0)
                                    throw new UnauthorizedAccessException($"{MagicExceptionStrings.forbidden}. {Resources.Resources.ExceptionMessage_UserDoesNotHaveAppropriatePermissions}");
                                break;

                            case PermissionsCheck.MustHaveAll:
                                if (hasPermissionCount != permissionsRequired.Count)
                                    throw new UnauthorizedAccessException($"{MagicExceptionStrings.forbidden}. {Resources.Resources.ExceptionMessage_UserDoesNotHaveAppropriatePermissions}");
                                break;

                            case PermissionsCheck.CannotHaveAny:
                                if (hasPermissionCount != 0)
                                    throw new UnauthorizedAccessException($"{MagicExceptionStrings.forbidden}. {Resources.Resources.ExceptionMessage_UserDoesNotHaveAppropriatePermissions}");
                                break;
                        }
                    }
                    else
                    {   // there is a deviceType specified other than DeviceTypeCode.None
                        // In this case, consult the database to see if the user has the requested permission to the requested device.
                        switch (deviceType)
                        {
                            case DeviceType.None:
                                throw new UnauthorizedAccessException($"{MagicExceptionStrings.forbidden}. {Resources.Resources.ExceptionMessage_UserDoesNotHaveAppropriatePermissions}");

                            case DeviceType.AccessPortal:
                                break;
                            case DeviceType.InputOutputGroup:
                                break;
                            case DeviceType.InputDevice:
                                break;
                            case DeviceType.OutputDevice:
                                break;
                            case DeviceType.Cluster:
                                break;
                            case DeviceType.GalaxyPanel:
                                break;
                        }
                    }
                }
            }
        }

        protected void ValidateEntityAuthorizationAndSetupOperation(Guid entityId, List<Guid> permissionsRequired, PermissionsCheck permissionRule, DeviceType deviceType)
        {
            if (permissionsRequired?.Count > 0 && permissionsRequired[0] != Guid.Empty)
            {
                if (UserSessionToken == null)
                    throw new UnauthorizedAccessException();
            }


            if (permissionsRequired?.Count == 1 && permissionsRequired[0] == Guid.Empty && deviceType == DeviceType.None)
                return;

            if (UserSessionToken != null)
            {
                if (UserSessionToken.IsSessionExpired)
                    throw new UnauthorizedAccessException();

                var userHasEntity = Globals.Instance.DoesUserHaveEntity(UserId, entityId);
                if (userHasEntity == false)
                    throw new UnauthorizedAccessException($"{MagicExceptionStrings.forbidden}. {Resources.Resources.ExceptionMessage_UserDoesNotHaveAppropriatePermissions}");

                if (permissionsRequired?.Count > 0)
                {
                    if (deviceType == DeviceType.None)
                    {
                        int hasPermissionCount = 0;
                        foreach (var p in permissionsRequired)
                        {
                            if (Globals.Instance.DoesUserHavePermission(UserId, entityId, p))
                            {
                                hasPermissionCount++;
                                if (permissionRule == PermissionsCheck.CanHaveAny)
                                    return;
                            }
                        }

                        switch (permissionRule)
                        {
                            case PermissionsCheck.CanHaveAny:
                                if (hasPermissionCount == 0)
                                    throw new UnauthorizedAccessException($"{MagicExceptionStrings.forbidden}. {Resources.Resources.ExceptionMessage_UserDoesNotHaveAppropriatePermissions}");
                                break;

                            case PermissionsCheck.MustHaveAll:
                                if (hasPermissionCount != permissionsRequired.Count)
                                    throw new UnauthorizedAccessException($"{MagicExceptionStrings.forbidden}. {Resources.Resources.ExceptionMessage_UserDoesNotHaveAppropriatePermissions}");
                                break;

                            case PermissionsCheck.CannotHaveAny:
                                if (hasPermissionCount != 0)
                                    throw new UnauthorizedAccessException($"{MagicExceptionStrings.forbidden}. {Resources.Resources.ExceptionMessage_UserDoesNotHaveAppropriatePermissions}");
                                break;
                        }
                    }
                    else
                    {   // there is a deviceType specified other than DeviceTypeCode.None
                        // In this case, consult the database to see if the user has the requested permission to the requested device.
                        switch (deviceType)
                        {
                            case DeviceType.None:
                                throw new UnauthorizedAccessException($"{MagicExceptionStrings.forbidden}. {Resources.Resources.ExceptionMessage_UserDoesNotHaveAppropriatePermissions}");

                            case DeviceType.AccessPortal:
                                break;
                            case DeviceType.InputOutputGroup:
                                break;
                            case DeviceType.InputDevice:
                                break;
                            case DeviceType.OutputDevice:
                                break;
                            case DeviceType.Cluster:
                                break;
                            case DeviceType.GalaxyPanel:
                                break;
                        }
                    }
                }
            }
        }

        protected void ValidateAdminAuthorizationAndSetupOperation(ICallParametersBase parameters)
        {
            if (parameters.DoNotValidateAuthorization)
                return;

            if (UserSessionToken == null)
                throw new UnauthorizedAccessException();

            if (parameters == null)
                parameters = new GetParameters();

            if (ApplicationUserSessionHeader.CurrentEntityId == Guid.Empty)
            {
                if (parameters.CurrentEntityId != Guid.Empty)
                    ApplicationUserSessionHeader.CurrentEntityId = parameters.CurrentEntityId;
                else if (CurrentEntityId != Guid.Empty)
                    ApplicationUserSessionHeader.CurrentEntityId = CurrentEntityId;
            }

            if (ApplicationUserSessionHeader.CurrentSiteId == Guid.Empty)
            {
                if (parameters.CurrentSiteUid != Guid.Empty)
                    ApplicationUserSessionHeader.CurrentSiteId = parameters.CurrentSiteUid;
                else if (CurrentSiteId != Guid.Empty)
                    ApplicationUserSessionHeader.CurrentSiteId = CurrentSiteId;
            }

            if (UserSessionToken.IsSessionExpired)
                throw new UnauthorizedAccessException();

            var userHasEntity = Globals.Instance.DoesUserHaveEntity(UserId, ApplicationUserSessionHeader.CurrentEntityId);
            if (userHasEntity == false)
                ApplicationUserSessionHeader.CurrentEntityId = Guid.Empty;

            if (Globals.Instance.DoesUserHaveAdminRole( UserId, ApplicationUserSessionHeader.CurrentEntityId) == true)
                return;

            throw new UnauthorizedAccessException();
        }

        protected bool DoesUserHaveAdminAuthorizationToEntity(Guid userId, Guid entityId)
        {
            return Globals.Instance.DoesUserHaveAdminRole(userId, entityId);

        }
        // This function is based on the Cached UserSessionToken having all the UserEntity, ApplicationRoles & Permissions in memory.
        // This was replaced with database calls to validate against the db at runtime
        //protected bool DoesUserHavePermission(ICallParametersBase parameters, Guid permissionRequired)
        //{
        //    if (UserSessionToken == null)
        //        return false;

        //    if (permissionRequired == Guid.Empty)
        //        return false;

        //    if (ApplicationUserSessionHeader.CurrentEntityId == Guid.Empty)
        //    {
        //        if (parameters.CurrentEntityId != Guid.Empty)
        //            ApplicationUserSessionHeader.CurrentEntityId = parameters.CurrentEntityId;
        //        else if (CurrentEntityId != Guid.Empty)
        //            ApplicationUserSessionHeader.CurrentEntityId = CurrentEntityId;
        //    }

        //    if (UserSessionToken != null)
        //    {
        //        if (UserSessionToken.IsSessionExpired)
        //            return false;

        //        var entity = (from ue in UserSessionToken.UserData.UserEntities
        //                      where ue.EntityId == ApplicationUserSessionHeader.CurrentEntityId
        //                      select ue).FirstOrDefault();
        //        if (entity == null)
        //            ApplicationUserSessionHeader.CurrentEntityId = Guid.Empty;

        //        if (UserSessionToken.HasPermission(ApplicationUserSessionHeader.CurrentEntityId, permissionRequired))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        protected bool DoesUserHavePermission(ICallParametersBase parameters, Guid permissionRequired)
        {
            if (UserSessionToken == null)
                return false;

            if (permissionRequired == Guid.Empty)
                return false;

            if (ApplicationUserSessionHeader.CurrentEntityId == Guid.Empty)
            {
                if (parameters.CurrentEntityId != Guid.Empty)
                    ApplicationUserSessionHeader.CurrentEntityId = parameters.CurrentEntityId;
                else if (CurrentEntityId != Guid.Empty)
                    ApplicationUserSessionHeader.CurrentEntityId = CurrentEntityId;
            }

            if (UserSessionToken != null)
            {
                if (UserSessionToken.IsSessionExpired)
                    return false;

                //var entity = (from ue in UserSessionToken.UserData.UserEntities
                //    where ue.EntityId == ApplicationUserSessionHeader.CurrentEntityId
                //    select ue).FirstOrDefault();
                //if (entity == null)
                //    ApplicationUserSessionHeader.CurrentEntityId = Guid.Empty;
                var userHasEntity = Globals.Instance.DoesUserHaveEntity(UserId, ApplicationUserSessionHeader.CurrentEntityId);
                if (userHasEntity == false)
                    ApplicationUserSessionHeader.CurrentEntityId = Guid.Empty;

                //if (UserSessionToken.HasPermission(ApplicationUserSessionHeader.CurrentEntityId, permissionRequired))
                //{
                //    return true;
                //}

                if (Globals.Instance.DoesUserHavePermission( this.UserId, ApplicationUserSessionHeader.CurrentEntityId, permissionRequired))
                {
                    return true;
                }
            }
            return false;
        }

        protected T ExecuteFaultHandledOperation<T>(Func<T> codetoExecute)
        {
            try
            {
                return codetoExecute.Invoke();
            }
            catch (AuthorizationValidationException ex)
            {
                this.Log().Error(ex);
                throw new FaultException<AuthorizationValidationException>(ex, ex.Message);
            }
            catch (DataValidationException ex)
            {
                ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                foreach (ValidationRule r in ex.ValidationRuleMessages)
                    detail.AddMessage(r.Message);
                FaultException<ExceptionDetailEx> fe = new FaultException<ExceptionDetailEx>(detail, ex.ToString());
                this.Log().Error(fe);
                throw fe;
            }
            catch (FaultException ex)
            {
                this.Log().Error(ex);
                throw;
            }
            catch (System.Net.WebException ex)
            {
                ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                //while (ex.InnerException != null)
                //    ex = ex.InnerException;
                var msg = string.Empty;
                if (ex.Response != null)
                {
                    msg = ((HttpWebResponse)ex.Response).StatusDescription;//ex.Message;
                    this.Log().Error(msg, ex);
                }
                else
                {
                    msg = ex.Message;
                    var innerEx = ex.InnerException;
                    while (innerEx != null)
                    {
                        msg += $"{Environment.NewLine}{innerEx.Message}";
                        innerEx = innerEx.InnerException;
                    }
                }
                FaultException<ExceptionDetailEx> fe = new FaultException<ExceptionDetailEx>(detail, msg);
                throw fe;
            }
            catch (Exception ex)
            {
                ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                string msg = ex.Message;
                this.Log().Error(msg, ex);
                FaultException<ExceptionDetailEx> fe = new FaultException<ExceptionDetailEx>(detail, msg);
                throw fe;
            }
        }

        protected void ExecuteFaultHandledOperation(Action codetoExecute)
        {
            try
            {
                codetoExecute.Invoke();
            }
            catch (AuthorizationValidationException ex)
            {
                this.Log().Error(ex);
                throw new FaultException<AuthorizationValidationException>(ex, ex.Message);
            }
            catch (FaultException ex)
            {
                this.Log().Error(ex);
                throw;
            }
            catch (DataValidationException ex)
            {
                ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                foreach (ValidationRule r in ex.ValidationRuleMessages)
                    detail.AddMessage(r.Message);
                FaultException<ExceptionDetailEx> fe = new FaultException<ExceptionDetailEx>(detail, ex.ToString());
                this.Log().Error(fe);
                throw fe;
            }
            catch (Exception ex)
            {
                this.Log().Error(ex);
                ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                //throw new FaultException(ex.Message);
            }
        }

        protected void UpdateProperties(ITableEntityBase o)
        {
            if (o == null)
                return;
            if (o.InsertDate == null || o.InsertDate == DateTimeOffset.MinValue)
                o.InsertDate = DateTimeOffset.Now;
            if (string.IsNullOrEmpty(o.InsertName))
                o.InsertName = this.ApplicationUserSessionHeader.UserName;
            o.UpdateDate = DateTimeOffset.Now;
            o.UpdateName = this.ApplicationUserSessionHeader.UserName;
        }

        protected void UpdateProperties(ITableEntityBase2 o)
        {
            if (o == null)
                return;
            if (o.InsertDate == null || o.InsertDate == DateTimeOffset.MinValue)
                o.InsertDate = DateTimeOffset.Now;
            if (string.IsNullOrEmpty(o.InsertName))
                o.InsertName = this.ApplicationUserSessionHeader.UserName;
            o.UpdateDate = DateTimeOffset.Now;
            o.UpdateName = this.ApplicationUserSessionHeader.UserName;
        }

        protected void LogTransactionInformation(string callingMethod)
        {
            var ambientTransaction = Transaction.Current;
            if (ambientTransaction == null)
            {
                this.Log().Info($"{callingMethod} - Transaction.Current is null");
                return;
            }

            this.Log().Info($"{callingMethod} - Current transaction ID:{ambientTransaction.TransactionInformation.LocalIdentifier}, Distributed ID:{ambientTransaction.TransactionInformation.DistributedIdentifier}");
            this.Log().Info($"{callingMethod} - Current transaction Status: {ambientTransaction.TransactionInformation.Status}");
            this.Log().Info($"{callingMethod} - Current transaction Creation Time: {ambientTransaction.TransactionInformation.CreationTime}");
            this.Log().Info($"{callingMethod} - Current transaction Isolation level: {ambientTransaction.IsolationLevel}");
            this.Log().Info($"{callingMethod} - Current transaction PromoterType: {ambientTransaction.PromoterType}");
        }


        protected Guid SaveBackgroundJob(BackgroundJob bgJob, string info, IDataRepositoryFactory dataRepositoryFactory)
        {
            if (bgJob != null)
            {
                if (bgJob.BackgroundJobUid == Guid.Empty)
                    bgJob.BackgroundJobUid = GuidUtilities.GenerateComb();

                var mgr = dataRepositoryFactory.GetDataRepository<IBackgroundJobRepository>();
                mgr.Add(bgJob, ApplicationUserSessionHeader, null);

                var jobStateRepository =
                    dataRepositoryFactory.GetDataRepository<IBackgroundJobStateChangeRepository>();
                jobStateRepository.Add(new BackgroundJobStateChange()
                {
                    BackgroundJobStateChangeUid = GuidUtilities.GenerateComb(),
                    BackgroundJobUid = bgJob.BackgroundJobUid,
                    ChangeDateTime = DateTimeOffset.Now,
                    State = BackgroundJobState.Queued.ToString(),
                    Info = info
                }, ApplicationUserSessionHeader, null);

                return bgJob.BackgroundJobUid;
            }

            return Guid.Empty;
        }

        protected void SaveBackgroundJobState(Guid backgroundJobId, Guid dataItemUid, BackgroundJobState state, string info, IDataRepositoryFactory dataRepositoryFactory)
        {
            var jobRepository = dataRepositoryFactory.GetDataRepository<IBackgroundJobRepository>();
            var bgJob = jobRepository.Get(backgroundJobId, ApplicationUserSessionHeader, null);

            if (bgJob != null)
            {
                bgJob.State = state.ToString();
                bgJob.UpdateDate = DateTimeOffset.Now;
                bgJob.UpdateName = LoginName;
                if (dataItemUid != Guid.Empty && bgJob.DataItemUid == Guid.Empty)
                    bgJob.DataItemUid = dataItemUid;

                jobRepository.Update(bgJob, ApplicationUserSessionHeader, null);

                var jobStateRepository =
                    dataRepositoryFactory.GetDataRepository<IBackgroundJobStateChangeRepository>();
                jobStateRepository.Add(new BackgroundJobStateChange()
                {
                    BackgroundJobStateChangeUid = GuidUtilities.GenerateComb(),
                    BackgroundJobUid = backgroundJobId,
                    ChangeDateTime = DateTimeOffset.Now,
                    State = state.ToString(),
                    Info = info
                }, ApplicationUserSessionHeader,  null);
            }
        }


    }
}