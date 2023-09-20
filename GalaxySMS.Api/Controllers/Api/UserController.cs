extern alias NetCoreCommon;
using AutoMapper;
using GalaxySMS.Api.Support;
using GalaxySMS.Client.SDK.Helpers;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using RequestModels = GalaxySMS.Api.Models.RequestModels;
using ResponseModels = GalaxySMS.Api.Models.ResponseModels;
using WcfEntities = GalaxySMS.Business.Entities;
using GCS.Core.Common.Extensions;
using System.Collections.Generic;
using System.Linq;
using GalaxySMS.Api.Models.RequestModels;
using GCS.Core.Common.Contracts;
using GCS.Framework.Security;
using Microsoft.Extensions.Caching.Distributed;
using NetCoreCommon::GCS.Core.Common.Utils;
using static System.Collections.Specialized.BitVector32;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GalaxySMS.Api.Controllers.Api
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Operations relating Entities. </summary>
    ///<remarks> An user is a foundational element of the system. Most all data items in the system are associated with an user. 
    ///          Entities are used to separate, isolate or partition data within the system. An user can be thought of as a 
    ///          customer or tenant in a multi-tenant application. Entities can also be used to represent a department or division
    ///           within a larger organization where the data needs to be separated or isolated from other groups within the organization. 
    ///           Individual data items such as persons, regions, sites, time schedules and users are all associated with a specific user. 
    ///           Entities can be hierarchical in nature where an user can have child entities. In this scenario, the parent user can 
    ///           access its children’s data items. </remarks>
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================

    [Route("api/[controller]")]
    [ApiController]  // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBaseEx
    {
        public UserController(IConfiguration config,
            IMapper mapper,
            ILogger<UserController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper, logger, linkGenerator, cache, distributedCache)
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary> Get a collection of gcsUser objects. </summary>
        /// 
        ///  <param name="entityId">     (Optional) The unique ID of the entity to request users for. If not specified, users for current entity will be requested. </param>
        ///   <param name="pageSize">     Size of the page. 0 = no paging</param>
        ///   <param name="pageNumber">   The page number. </param>
        ///  <param name="includePhoto">     (Optional) True to include photo, false to exclude the photo. </param>
        ///  <param name="photoPixelWidth">  (Optional) Width of the photo in pixels (0 = full size). </param>
        ///  <param name="includeEntitiesAndRoles"></param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by (UserName, InsertDate, UpdateDate, Email, LastLoginDate)</param>
        ///   <param name="orderBy">      (Optional) Specifies if the results should be returned in ascending (asc, default) or descending (desc) order.</param>
        /// 
        ///  <returns>   A Task&lt;ActionResult&lt;ApiEntities.gcsUserBasic[]&gt;&gt; </returns>
        /// =================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.gcsUserBasic>>> Get(Guid entityId, int pageSize, int pageNumber, bool includePhoto = true, int photoPixelWidth = 200, bool includeEntitiesAndRoles = true, UserSortProperty sortBy = UserSortProperty.UserName, OrderBy orderBy = OrderBy.Asc)//, bool includeChildren = false)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<UserManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetAllUsersListAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = entityId,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = includeEntitiesAndRoles,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (entityId == Guid.Empty)
                {
                    var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.gcsUserBasic>>(results);
                    return Ok(resp);
                }

                var respData = new ApiEntities.ArrayResponse<ApiEntities.gcsUserBasicRoles>()
                {
                    PageItemCount = results.PageItemCount,
                    PageNumber = results.PageNumber,
                    PageSize = results.PageSize,
                    TotalItemCount = results.TotalItemCount,
                    TotalPageCount = results.TotalPageCount
                };

                var users = new List<ApiEntities.gcsUserBasicRoles>();
                foreach (var u in results.Items)
                {
                    var i = Mapper.Map<ApiEntities.gcsUserBasicRoles>(u);
                    if (u.Entities.Any())
                        i.Roles = u.Entities.FirstOrDefault()?.Roles;
                    users.Add(i);
                }

                respData.Items = users.ToArray();
                return Ok(respData);

            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Get a single of gcsUser object based on userId (unique id (Guid or uuid) value). </summary>
        ///
        /// <param name="userId">       Identifier for the user. </param>
        /// <param name="includeProperties">    (Optional) Comma-separated list of property names to include in the response</param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.gcsUser&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ResponseModels.gcsUserResp>> Get(Guid userId, string includeProperties = "")
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var getForPut = true;

                var mgr = Helpers.GetManager<UserManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                //                var result = await mgr.GetByUserIdAsync(userId);

                var parameters = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = userId,
                    IncludeMemberCollections = true,
                    IncludePhoto = true
                };

                InitializeExcludeProperties(includeProperties, parameters);

                var result = await mgr.GetByUserIdAsync(parameters);
                //var result = await mgr.GetByUserIdAsync(new WcfEntities.GetParametersWithPhoto() { UniqueId = userId, IncludeMemberCollections = true, IncludePhoto = true });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();
                if (getForPut)
                {
                    var putModel = Mapper.Map<RequestModels.UserPutReq>(result);
                    return Ok(putModel);
                }

                var model = Mapper.Map<ResponseModels.gcsUserResp>(result);
                return Ok(model);
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
                    return NotFound();

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{userId}/permissions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.UserEntityPermissions>> GetPermissions(Guid userId, Guid entityId)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<UserManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                //                var result = await mgr.GetByUserIdAsync(userId);

                var parameters = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = userId,
                    CurrentEntityId = entityId
                };

                var result = await mgr.GetUsersPermissionsAsync(parameters);
                //var result = await mgr.GetByUserIdAsync(new WcfEntities.GetParametersWithPhoto() { UniqueId = userId, IncludeMemberCollections = true, IncludePhoto = true });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                var putModel = Mapper.Map<ApiEntities.UserEntityPermissions>(result);
                return Ok(putModel);
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
                    return NotFound();

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        private static void InitializeExcludeProperties(string includeProperties, IHasExcludeMemberSupport parameters)
        {
            if (!string.IsNullOrEmpty(includeProperties))
            {
                var includeProps = includeProperties.ToLower().Split(',');
                var responseProperties =
                    typeof(WcfEntities.gcsUser).GetComplexProperties().ToList();

                var userEntityProperties = typeof(WcfEntities.gcsUserEntity).GetComplexProperties();
                responseProperties.AddRange(userEntityProperties);


                foreach (var p in responseProperties)
                {
                    var included = includeProps.FirstOrDefault(o => o.TrimStart().TrimEnd().ToLower() == p.Name.ToLower());
                    if (included == null)
                        parameters.ExcludeMemberCollectionSettings.Add(p.Name);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary>
        ///  Create a new gcsUser item.
        ///  </summary>
        ///  
        ///  <remarks>Valid IgnoreProperties values: gcsUserEntities
        ///            </remarks>
        ///  <param name="parameters">   Options for controlling the operation. </param>
        ///  <param name="includeProperties">    (Optional) Comma-separated list of property names to include in the response</param>
        ///  <param name="addDescendantEntities"> (Optional) True if the server should automatically add UserEntities for all descendant entities with default roles. Ignored if UserEntities is populated.</param>
        ///  <param name="allowParentEntityRoles"></param>
        ///  <param name="isEntityAdmin"></param>
        ///  <returns>   A Task&lt;ActionResult&lt;ApiEntities.gcsUser[]&gt;&gt; </returns>
        /// =================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        //[SwaggerRequestExample(typeof(RequestModels.SaveParams<RequestModels.Entity>), typeof(SaveEntityExamples))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<UserPutReq>> Post(RequestModels.SaveParams<RequestModels.UserPostReq> parameters, string includeProperties = "")
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var getForPut = true;

                var mgr = Helpers.GetManager<UserManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                // Make up some Guid value for encryption purposes only
                var validationProblemDetails = await ValidatePassword(GuidUtilities.GenerateComb(), parameters.Data.PrimaryEntityId,
                    parameters.Data.UserPassword, mgr);
                if (validationProblemDetails != null)
                    return ValidationProblem(validationProblemDetails);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                InitializeExcludeProperties(includeProperties, wcfSaveParameters);

                var wcfEntity = Mapper.Map<WcfEntities.gcsUserSave>(parameters.Data);

                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.gcsUserSave>(wcfEntity, wcfSaveParameters);

                if (parameters.Data.DefaultUserEntityOptions != null)
                {
                    wcfParams.AddOption(SaveUserOption.AddDescendantEntities.ToString(), parameters.Data.DefaultUserEntityOptions.AddDescendantEntities);
                    wcfParams.AddOption(SaveUserOption.InheritParentEntityRoles.ToString(), parameters.Data.DefaultUserEntityOptions.InheritParentEntityRoles);
                    wcfParams.AddOption(SaveUserOption.IsEntityAdministrator.ToString(), parameters.Data.DefaultUserEntityOptions.IsEntityAdmin);
                    wcfParams.AddOption(SaveUserOption.DoNotAddDefaultRolesToUser.ToString(), parameters.Data.DefaultUserEntityOptions.DoNotAddDefaultRolesToUser);
                }

                var results = await mgr.SaveUserAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    //                    var savedItem = Mapper.Map<ApiEntities.gcsUser>(results);
                    var savedItem = Mapper.Map<RequestModels.UserPutReq>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "User",
                        new { userId = savedItem.UserId });
                    if (results.UpdateDate > results.InsertDate)
                    {
                        return Ok(Mapper.Map<RequestModels.UserPutReq>(results));
                    }

                    if (!getForPut)
                        return Created(url, Mapper.Map<ApiEntities.gcsUser>(results));
                    return Created(url, Mapper.Map<RequestModels.UserPutReq>(results));
                }
                return this.StatusCode(StatusCodes.Status500InternalServerError, ResponseMessages.UnknownReason);
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.AuthorizationValidationException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
                    return NotFound();

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.DuplicateIndexException).ToString()))
                    return BadRequest(ex.Message);


                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.DataValidationException).ToString()))
                    return BadRequest(ex.Message);

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }

        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Updates an existing gcsUser item. Can also create a new gcsUser if the EntityId property is specified 
        /// </summary>
        /// 
        /// <remarks>Valid IgnoreProperties values: gcsUserEntities
        /// </remarks>
        /// 
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="includeProperties">    (Optional) Comma-separated list of property names to include in the response</param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.gcsUser&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        //[SwaggerRequestExample(typeof(RequestModels.SaveParams<RequestModels.Entity>), typeof(SaveEntityExamples))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<UserPutReq>> Put(RequestModels.SaveParams<RequestModels.UserPutReq> parameters, string includeProperties = "")
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (parameters.Data.UserId == Guid.Empty)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot update user with UserId value of {parameters.Data.UserId}");

                var getForPut = true;

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgr = Helpers.GetManager<UserManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);
                InitializeExcludeProperties(includeProperties, wcfSaveParameters);

                var wcfEntity = Mapper.Map<WcfEntities.gcsUser>(parameters.Data);
                foreach (var ue in wcfEntity.UserEntities)
                {
                    ue.UserId = wcfEntity.UserId;
                    //foreach (var uear in ue.gcsUserEntityApplicationRoles)
                    //{
                    //    uear.UserEntityId = ue.UserEntityId;
                    //}
                }
                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.gcsUser>(wcfEntity, wcfSaveParameters) { DoNotValidateAuthorization = true };

                var results = await mgr.SaveUserAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var url = LinkGenerator.GetPathByAction("Get",
                        "User",
                        new { userId = results.UserId });
                    if (results.UpdateDate > results.InsertDate)
                    {
                        //if( !getForPut)
                        //    return Ok(Mapper.Map<ApiEntities.gcsUser>(results));
                        return Ok(Mapper.Map<RequestModels.UserPutReq>(results));
                    }

                    if (!getForPut)
                        return Created(url, Mapper.Map<ApiEntities.gcsUser>(results));

                    return Created(url, Mapper.Map<RequestModels.UserPutReq>(results));
                }

                return this.StatusCode(StatusCodes.Status500InternalServerError, ResponseMessages.UnknownReason);
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.AuthorizationValidationException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
                    return NotFound();

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.DuplicateIndexException).ToString()))
                    return BadRequest(ex.Message);


                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.DataValidationException).ToString()))
                    return BadRequest(ex.Message);

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }

        }


        private async Task<ValidationProblemDetails> ValidatePassword(Guid userId, Guid entityId, string password, UserManager mgr)
        {
            var validationProblems = new Dictionary<string, string[]>();
            var errorsArray = new List<string>();

            var results = await mgr.ValidatePasswordAsync(new WcfEntities.gcsUser()
            { UserId = userId, PrimaryEntityId = entityId, UserPassword = password }, false);

            if (results.Result != PasswordValidationResult.Valid)
            {
                foreach (var validationProblem in results.Results.Where(o => o.Result != PasswordValidationResult.Valid))
                {
                    errorsArray.Add($"{validationProblem.Message}");
                }
            }

            if (errorsArray.Any())
            {
                validationProblems.Add($"{nameof(WcfEntities.gcsUser.UserPassword)}", errorsArray.ToArray());
                return new ValidationProblemDetails(validationProblems);
            }

            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Delete a specific gcsUser by userId.
        /// </summary>
        ///
        /// <param name="userId"> Identifier for the user to delete. </param>
        ///
        /// <returns>   A Task&lt;IActionResult&gt; </returns>
        ///=================================================================================================        
        [HttpDelete("{userId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid userId)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (userId == Guid.Empty || userId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"Forbidden from deleting userId:{userId}");

                var mgr = Helpers.GetManager<UserManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetByUserIdAsync(new WcfEntities.GetParametersWithPhoto() { UniqueId = userId });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                var x = await mgr.DeleteUserAsync(result);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                return Ok();
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
                    return NotFound();

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get user editor data
        /// </summary>
        ///
        /// <remarks>   Kevin, 11/23/2021. </remarks>
        ///
        /// <param name="includePhoto">                 (Optional) True to include photo image data, false to exclude the photo. </param>
        /// <param name="photoPixelWidth">              (Optional) Width of the photo in pixels (0 = full size). </param>
        /// <param name="includeMemberCollections">     (Optional) True to include, false to exclude the member collections. </param>
        /// <param name="excludeNotAuthorizedRoles">    (Optional) True to exclude all roles that have the IsAuthorized property = false, false to include all roles. </param>
        /// <param name="excludeNotAuthorizedApplications">(Optional) True to exclude all applications that have the IsAuthorized property = false, false to include all applications.</param>
        /// <param name="applicationId">                (Optional) Identifier for the application. Omit or specify 00000000-0000-0000-0000-000000000000 to include all applications</param>
        ///
        /// <returns>   The user editor data. </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("editordata")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]


        public async Task<ActionResult<ApiEntities.gcsUserEditingData>> GetUserEditorData(bool includePhoto = true, int photoPixelWidth = 200, bool includeMemberCollections = false, bool excludeNotAuthorizedRoles = false, bool excludeNotAuthorizedApplications = false, Guid? applicationId = null)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);


                var mgr = Helpers.GetManager<UserManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var wcfParams = new WcfEntities.GetParametersWithPhoto() { IncludePhoto = includePhoto, PhotoPixelWidth = photoPixelWidth, IncludeMemberCollections = includeMemberCollections };
                if (excludeNotAuthorizedRoles == true)
                {
                    wcfParams.Options.Add(new System.Collections.Generic.KeyValuePair<string, bool>(GetOptions_UserEditorData.ExcludeNotAuthorizedRoles, true));
                }

                if (excludeNotAuthorizedApplications == true)
                {
                    wcfParams.Options.Add(new System.Collections.Generic.KeyValuePair<string, bool>(GetOptions_UserEditorData.ExcludeNotAuthorizedApplications, true));
                }


                if (applicationId != null && applicationId.Value != Guid.Empty)
                    wcfParams.AllowedApplicationIds.Add(applicationId.Value);

                var result = await mgr.GetUserEditingDataAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();
                var model = Mapper.Map<ApiEntities.gcsUserEditingData>(result);
                return Ok(model);
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
                    return NotFound();

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        [AllowAnonymous]
        [HttpPost("requestpasswordchangetoken")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ApiEntities.UserRequestPasswordChangeTokenResponse>> RequestPasswordChangeToken(ApiEntities.UserRequestPasswordChangeToken parameters)
        {
            try
            {
                //var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                //if (sessionId == Guid.Empty)
                //    return BadRequest(ResponseMessages.JwtMissingSessionId);

                //var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                //var getForPut = true;

                var mgr = Helpers.GetManager<UserManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var wcfParams = Mapper.Map<WcfEntities.UserRequestPasswordChangeToken>(parameters);
                var results = await mgr.RequestUserPasswordChangeTokenAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    if (results.UnknownUser)
                        return NotFound($"UserName '{parameters.UserName}' not recognized");

                    var savedItem = Mapper.Map<ApiEntities.UserRequestPasswordChangeTokenResponse>(results);
                    return Ok(savedItem);
                }
                return this.StatusCode(StatusCodes.Status500InternalServerError, ResponseMessages.UnknownReason);
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.AuthorizationValidationException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
                    return NotFound();

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.DuplicateIndexException).ToString()))
                    return BadRequest(ex.Message);


                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.DataValidationException).ToString()))
                    return BadRequest(ex.Message);

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }

        }


        [AllowAnonymous]
        [HttpPost("updatepassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ApiEntities.UpdateUserPasswordResult>> UpdatePassword(ApiEntities.UpdateUserPasswordParameters parameters)
        {
            try
            {
                //var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                //if (sessionId == Guid.Empty)
                //    return BadRequest(ResponseMessages.JwtMissingSessionId);

                //var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                //var getForPut = true;

                var mgr = Helpers.GetManager<UserManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                //var user = await mgr.GetByPasswordAsync(parameters.CurrentPassword);
                //if (user == null || user.UserId == Guid.Empty)
                //{
                //    user = await mgr.GetByPasswordAsync(parameters.EncryptedText);
                //    if (user == null || user.UserId == Guid.Empty)
                //    {
                //        return NotFound($"User not found");
                //    }
                //}



                var wcfParams = Mapper.Map<WcfEntities.UpdateUserPasswordParameters>(parameters);

                var results = await mgr.UpdateUserPasswordAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results.ValidationInfo != null && results.ValidationInfo.Results.Any())
                    return BadRequest(results);

                if (results.Result == WcfEntities.UpdateUserPasswordResult.UpdateUserPasswordResultCodes.UserNotFound)
                    return NotFound(results);
                if (results.Result != WcfEntities.UpdateUserPasswordResult.UpdateUserPasswordResultCodes.Success)
                    return BadRequest(results);
                return Ok(results);
                //if (results != null)
                //{
                //    if (results.UnknownUser)
                //        return NotFound($"UserName '{parameters.UserName}' not recognized");

                //    var savedItem = Mapper.Map<ApiEntities.UserRequestPasswordChangeTokenResponse>(results);
                //    return Ok(savedItem);
                //}
                return this.StatusCode(StatusCodes.Status500InternalServerError, ResponseMessages.UnknownReason);
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.AuthorizationValidationException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
                    return NotFound();

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.DuplicateIndexException).ToString()))
                    return BadRequest(ex.Message);


                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.DataValidationException).ToString()))
                    return BadRequest(ex.Message);

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }

        }
    }
}
