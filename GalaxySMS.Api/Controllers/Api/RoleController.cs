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
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Threading.Tasks;
using GCS.Core.Common.Extensions;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using RequestModels = GalaxySMS.Api.Models.RequestModels;
using WcfEntities = GalaxySMS.Business.Entities;
using GalaxySMS.Api.Models.RequestModels;

namespace GalaxySMS.Api.Controllers.Api
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Operations relating to Roles. </summary>
    ///<remarks>  </remarks>
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================

    [Route("api/[controller]")]
    [ApiController]  // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RoleController : ControllerBaseEx
    {
        public RoleController(IConfiguration config,
            IMapper mapper,
            ILogger<RoleController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper, logger, linkGenerator, cache, distributedCache)
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary> Get a collection of Role objects. </summary>
        /// 
        ///  <param name="entityId">    The identifier of the entity</param>
        ///  <param name="pageSize">     Size of the page. 0 = no paging</param>
        ///  <param name="pageNumber">   The page number. </param>
        ///  <param name="includeChildren">  (Optional) True to include, false to exclude the children. (True can significantly increase response time and body size) </param>
        ///   <param name="sortBy"> (Optional) The property to sort the results by (RoleName, InsertDate, UpdateDate)</param>
        ///   <param name="orderBy">      (Optional) Specifies if the results should be returned in ascending (asc, default) or descending (desc) order.</param>
        ///  <param name="forCurrentUser"></param>
        ///  <returns>   A Task&lt;ActionResult&lt;ApiEntities.gcsRole[]&gt;&gt; </returns>
        /// =================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("allforentity/{entityId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.gcsRoleBasic>>> GetAllForEntity(Guid entityId, int pageSize, int pageNumber, bool includeChildren = false, RoleSortProperty sortBy = RoleSortProperty.RoleName, OrderBy orderBy = OrderBy.Asc, bool forCurrentUser = true)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<RoleManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var wcfParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = entityId,
                    IncludeMemberCollections = includeChildren,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                };


                //wcfParams.AddOption(GetRoleOption.ForCurrentUser.ToString(), forCurrentUser);

                var results = await mgr.GetAllRolesForEntityAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.gcsRoleBasic>>(results);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary> Get a single Role based on roleId (unique id (Guid or uuid) value). </summary>
        /// 
        ///  <param name="roleId">         Identifier for the role. </param>
        ///  <param name="applicationId">  Specifies the application to get permissions for.</param>
        ///  <param name="includeChildren">  (Optional) True to include, false to exclude the children.
        ///                                  (True can significantly increase response time and body size) </param>
        ///  <returns>   A Task&lt;ActionResult&lt;ApiEntities.gcsRole[]&gt;&gt; </returns>
        /// =================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{roleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.gcsRole>> Get(Guid roleId, Guid applicationId, bool includeChildren = true)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var getForPut = true;

                var mgr = Helpers.GetManager<RoleManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var wcfParams = new WcfEntities.GetParametersWithPhoto
                {
                    UniqueId = roleId,
                    IncludeMemberCollections = includeChildren,
                };
                if (applicationId != Guid.Empty)
                    wcfParams.AllowedApplicationIds.Add(applicationId);
                var result = await mgr.GetRoleAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                if (getForPut)
                    return Ok(Mapper.Map<RequestModels.RolePutReq>(result));

                var model = Mapper.Map<ApiEntities.gcsRole>(result);
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Create a new Role item.
        /// </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <remarks>Valid IgnoreProperties values: RolePermissions
        ///           </remarks>
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.gcsRole[]&gt;&gt; </returns>
        ///=================================================================================================


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<RolePutReq>> Post(RequestModels.SaveParams<RequestModels.RoleReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgr = Helpers.GetManager<RoleManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                if (parameters.Data.RolePermissions == null)
                    parameters.Data.RolePermissions = new List<RequestModels.RolePermissionReq>();

                if (parameters.Data.DeviceFilters == null)
                    parameters.Data.DeviceFilters ??= new RequestModels.RoleFiltersReq()
                    {
                        IncludeAllRegions = parameters.Data.IsAdministratorRole,
                        IncludeAllSites = parameters.Data.IsAdministratorRole,
                        IncludeAllClusters = parameters.Data.IsAdministratorRole,
                        IncludeAllAccessPortals = parameters.Data.IsAdministratorRole,
                        IncludeAllInputDevices = parameters.Data.IsAdministratorRole,
                        IncludeAllOutputDevices = parameters.Data.IsAdministratorRole,
                        IncludeAllInputOutputGroups = parameters.Data.IsAdministratorRole
                    };

                //parameters.Data.DeviceFilters.Clusters ??= new HashSet<RequestModels.RoleClusterReq>();
                parameters.Data.DeviceFilters.Regions ??= new HashSet<RequestModels.RoleRegionReq>();

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.gcsRole>(parameters.Data);
                wcfEntity.ConcurrencyValue = 0;

                //foreach (var p in parameters.Data.AccessPortalIds.Where(o => o != Guid.Empty))
                //{
                //    wcfEntity.AccessPortals.Add(new WcfEntities.RoleAccessPortal()
                //    {
                //        AccessPortalUid = p
                //    });
                //}

                //foreach (var p in parameters.Data.InputDeviceIds.Where(o => o != Guid.Empty))
                //{
                //    wcfEntity.InputDevices.Add(new WcfEntities.RoleInputDevice()
                //    {
                //        InputDeviceUid = p
                //    });
                //}

                //foreach (var p in parameters.Data.OutputDeviceIds.Where(o => o != Guid.Empty))
                //{
                //    wcfEntity.OutputDevices.Add(new WcfEntities.RoleOutputDevice()
                //    {
                //        OutputDeviceUid = p
                //    });
                //}

                //foreach (var p in parameters.Data.ClusterIds.Where(o => o != Guid.Empty))
                //{
                //    wcfEntity.Clusters.Add(new WcfEntities.RoleCluster()
                //    {
                //        ClusterUid = p
                //    });
                //}

                //foreach (var p in parameters.Data.InputOutputGroupIds.Where(o => o != Guid.Empty))
                //{
                //    wcfEntity.InputOutputGroups.Add(new WcfEntities.RoleInputOutputGroup()
                //    {
                //        InputOutputGroupUid = p
                //    });
                //}

                if (parameters.Data.Options == null)
                {
                    parameters.Data.Options = new AddRoleOptions();
                }

                wcfSaveParameters.AddOption(SaveRoleOption.AddToExistingUsers.ToString(), parameters.Data.Options.AddToExistingUsers);

                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.gcsRole>(wcfEntity, wcfSaveParameters);

                var results = await mgr.SaveRoleAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var savedItem = Mapper.Map<RolePutReq>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "Role",
                        new { roleId = savedItem.RoleId });
                    if (results.UpdateDate > results.InsertDate)
                        return Ok(savedItem);
                    return Created(url, savedItem);
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
        /// Update an existing Role item. Can also create a new Role.
        /// </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.gcsRole&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<RolePutReq>> Put(RequestModels.SaveParams<RequestModels.RolePutReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (parameters.Data.RoleId == Guid.Empty)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot update role with RoleUid value of {parameters.Data.RoleId}");

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgr = Helpers.GetManager<RoleManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.gcsRole>(parameters.Data);
                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.gcsRole>(wcfEntity, wcfSaveParameters);

                var results = await mgr.SaveRoleAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var savedItem = Mapper.Map<RolePutReq>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "Role",
                        new { roleId = savedItem.RoleId });
                    if (results.UpdateDate > results.InsertDate)
                        return Ok(savedItem);
                    return Created(url, savedItem);
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
        /// Delete a specific Role by roleId.
        /// </summary>
        ///
        /// <param name="roleId"> Identifier for the role to delete. </param>
        ///
        /// <returns>   A Task&lt;IActionResult&gt; </returns>
        ///=================================================================================================        
        [HttpDelete("{roleId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid roleId)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<RoleManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetRoleAsync(new WcfEntities.GetParametersWithPhoto() { UniqueId = roleId, IncludeMemberCollections = false });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                var x = await mgr.DeleteRoleAsync(result);

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
        ///  <summary>
        ///  Request lists of permission categories with permissions for a specific application. 
        ///  </summary>
        /// 
        ///  <param name="entityId">    The identifier of the entity. </param>
        ///  <param name="applicationId"> The identifier of the application return data for.</param>
        ///  <param name="includeProperties">    (Optional) Comma-separated list of property names to include in the response</param>
        ///  <param name="refreshCache"> (Optional) false = return data from cache if possible, true = always request data from database and cache the response</param>
        ///  <returns>   The editor data. </returns>
        /// =================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("editordata/{entityId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.EntityRoleEditingDataMinimal>> GetEditorData(Guid entityId, Guid applicationId, string includeProperties = "", bool refreshCache = false)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (includeProperties == null)
                    includeProperties = string.Empty;
                else includeProperties = includeProperties.ToLower();

                var cacheKey = $"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name}:{entityId}:{includeProperties}:{applicationId}".ToLower();

                if (!refreshCache)
                {
                    var cachedItem = Cache.Get(cacheKey);
                    if (cachedItem != null)
                        return Ok(cachedItem);
                }
                var mgr = Helpers.GetManager<RoleManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var getparams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = entityId,
                    IncludeMemberCollections = true,
                    IncludePhoto = false,
                    AllowedApplicationIds = new List<Guid>()
                };

                if (applicationId != Guid.Empty)
                    getparams.AllowedApplicationIds.Add(applicationId);

                if (!string.IsNullOrEmpty(includeProperties))
                {
                    var includeProps = includeProperties.Split(',');
                    var responseProperties =
                        typeof(WcfEntities.EntityRoleEditingData).GetComplexProperties().ToList();
                    foreach (var p in responseProperties)
                    {
                        var included = includeProps.FirstOrDefault(o => o.TrimStart().TrimEnd().ToLower() == p.Name.ToLower());
                        if (included == null)
                            getparams.ExcludeMemberCollectionSettings.Add(p.Name);
                    }
                }

                getparams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.ClusterSelectionItemBasic.AccessGroups));
                getparams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.ClusterSelectionItemBasic.TimeSchedules));

                var result = await mgr.GetRoleEditingDataAsync(getparams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                {
                    return NotFound();
                }
                var model = Mapper.Map<ApiEntities.EntityRoleEditingDataMinimal>(result);

                var cachedData = Cache.Set(cacheKey, model);

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


    }
}
