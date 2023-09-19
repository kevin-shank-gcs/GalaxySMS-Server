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
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using RequestModels = GalaxySMS.Api.Models.RequestModels;
using ResponseModels = GalaxySMS.Api.Models.ResponseModels;
using WcfEntities = GalaxySMS.Business.Entities;
using System.Collections.Generic;

namespace GalaxySMS.Api.Controllers.Api
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Operations relating to Access Groups. </summary>
    ///<remarks>  </remarks>
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================

    [Route("api/[controller]")]
    [ApiController]  // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccessGroupController : ControllerBaseEx
    {
        public AccessGroupController(IConfiguration config,
            IMapper mapper,
            ILogger<AccessGroupController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper, logger, linkGenerator, cache, distributedCache)
        {

        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Get all access groups for the current entity. </summary>
        /////
        ///// <param name="pageSize">     Size of the page. 0 = no paging</param>
        ///// <param name="pageNumber">   The page number. </param>
        ///// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        /////  <param name="sortBy"> (Optional) The property to sort the results by</param>
        /////  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        /////  <param name="includeSystemAccessGroups"> (Optional) Specify False to exclude the No Access, Unlimited and Personal access groups.</param>
        /////
        ///// <returns>   A Task&lt;ActionResult&lt;ApiEntities.AccessGroupBasic[]&gt;&gt; </returns>
        /////=================================================================================================

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        ////[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        //// If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        ////[MapToApiVersion("1.0")]
        //public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.AccessGroupBasic>>> Get(int pageSize, int pageNumber, bool includeChildren = false, AccessGroupSortProperty sortBy = AccessGroupSortProperty.Display, OrderBy orderBy = OrderBy.Asc, bool includeSystemAccessGroups = true)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<GalaxyAccessGroupManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

        //        var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
        //        {
        //            IncludePhoto = false,
        //            IncludeMemberCollections = includeChildren,
        //            PageNumber = pageNumber,
        //            PageSize = pageSize,
        //            DescendingOrder = orderBy == OrderBy.Desc,
        //            SortProperty = sortBy.ToString()
        //        };

        //        wcfGetParams.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions_AccessGroup.IncludeSystemAccessGroups, includeSystemAccessGroups));
        //        wcfGetParams.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeCounts, true));

        //        var results = await mgr.GetAllAccessGroupsForEntityAsync(wcfGetParams);

        //        if (mgr.HasErrors)
        //        {
        //            return GetStatusCodeResult(mgr);
        //        }

        //        var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.AccessGroupBasic>>(results);

        //        return Ok(resp);

        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Get all access groups. </summary>
        /////
        ///// <param name="pageSize">         Size of the page. 0 = no paging. </param>
        ///// <param name="pageNumber">       The page number. </param>
        ///// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        ///// <param name="sortBy">           (Optional) The property to sort the results by. </param>
        ///// <param name="orderBy">          (Optional) Specifies if the results should be returned in.</param>
        ///// <param name="includeSystemAccessGroups"> (Optional) Specify False to exclude the No Access, Unlimited and Personal access groups.</param>
        /////
        ///// <returns>   all. </returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet("all")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        ////[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        //// If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        ////[MapToApiVersion("1.0")]
        //public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.AccessGroupBasic>>> GetAll(int pageSize, int pageNumber, bool includeChildren = false, AccessGroupSortProperty sortBy = AccessGroupSortProperty.Display, OrderBy orderBy = OrderBy.Asc, bool includeSystemAccessGroups = true)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<GalaxyAccessGroupManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

        //        var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
        //        {
        //            IncludePhoto = false,
        //            IncludeMemberCollections = includeChildren,
        //            PageNumber = pageNumber,
        //            PageSize = pageSize,
        //            DescendingOrder = orderBy == OrderBy.Desc,
        //            SortProperty = sortBy.ToString()
        //        };

        //        wcfGetParams.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions_AccessGroup.IncludeSystemAccessGroups, includeSystemAccessGroups));
        //        wcfGetParams.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeCounts, true));

        //        var results = await mgr.GetAllAccessGroupsAsync(wcfGetParams);

        //        if (mgr.HasErrors)
        //        {
        //            return GetStatusCodeResult(mgr);
        //        }

        //        var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.AccessGroupBasic>>(results);

        //        return Ok(resp);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get all access groups for a specific entity.
        /// </summary>
        ///
        /// <param name="entityId">  The entity ID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///  <param name="includeSystemAccessGroups"> (Optional) Specify False to exclude the No Access, Unlimited and Personal access groups.</param>
        ///
        /// <returns>   The access groups for the entity. </returns>
        ///=================================================================================================
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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.AccessGroupBasic>>> GetAccessGroupsForEntity(Guid entityId, int pageSize, int pageNumber, bool includeChildren = false, AccessGroupSortProperty sortBy = AccessGroupSortProperty.Display, OrderBy orderBy = OrderBy.Asc, bool includeSystemAccessGroups = true)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<GalaxyAccessGroupManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = entityId,
                    IncludePhoto = false,
                    IncludeMemberCollections = false,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                };

                wcfGetParams.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions_AccessGroup.IncludeSystemAccessGroups, includeSystemAccessGroups));
                wcfGetParams.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeCounts, true));

                var results = await mgr.GetAllAccessGroupsForEntityAsync(wcfGetParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.AccessGroupBasic>>(results);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary>
        ///  Get all access groups for a cluster.
        ///  </summary>
        /// 
        ///  <param name="clusterUid">  The cluster UID. </param>
        ///  <param name="pageSize">     Size of the page. 0 = no paging</param>
        ///  <param name="pageNumber">   The page number. </param>
        ///  <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        ///   <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///   <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///  <param name="includeSystemAccessGroups"> (Optional) Specify False to exclude the No Access, Unlimited and Personal access groups.</param>
        ///  <returns>   The access groups for cluster. </returns>
        /// =================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("allforcluster/{clusterUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.AccessGroupBasic>>> GetAccessGroupsForCluster(Guid clusterUid, int pageSize, int pageNumber, bool includeChildren = false, AccessGroupSortProperty sortBy = AccessGroupSortProperty.Display, OrderBy orderBy = OrderBy.Asc, bool includeSystemAccessGroups = true)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<GalaxyAccessGroupManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = clusterUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = false,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                };
                wcfGetParams.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions_AccessGroup.IncludeSystemAccessGroups, includeSystemAccessGroups));
                wcfGetParams.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeCounts, true));

                var results = await mgr.GetAccessGroupsForClusterAsync(wcfGetParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.AccessGroupBasic>>(results);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary>   Get a access group by AccessGroupUid value. </summary>
        ///  
        ///  <param name="accessGroupUid">   The access group UID. </param>
        ///  <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        ///  <param name="includeAllAccessPortals">(Optional) True to include all accessPortals, false to exclude the access portals with Never schedule.</param>
        ///  <returns>   A Task&lt;ActionResult&lt;ApiEntities.AccessGroup&gt;&gt; </returns>
        /// =================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{accessGroupUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ResponseModels.AccessGroupResp>> Get(Guid accessGroupUid, bool includeChildren = false, bool includeAllAccessPortals = false/*, bool getForPut = false*/)
        {
            try
            {
                var getForPut = true;
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<GalaxyAccessGroupManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = accessGroupUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = includeChildren,
                };

                wcfGetParams.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeCounts, true));
                wcfGetParams.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions_AccessGroup.IncludeAllAccessPortals, includeAllAccessPortals));

                var result = await mgr.GetAccessGroupAsync(wcfGetParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                if (getForPut)
                {
                    var ag = Mapper.Map<RequestModels.AccessGroupPutReq>(result);
                    return Ok(ag);
                }


                var model = Mapper.Map<ResponseModels.AccessGroupResp>(result);
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
        /// Request lists of access portals and time schedules for a specific cluster. 
        /// </summary>
        ///
        /// <param name="clusterUid">       The cluster UID. </param>
        /// <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        /// <param name="photoPixelWidth">  (Optional) Width of the photo pixel. </param>
        ///
        /// <returns>   The editor data. </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("editordata/{clusterUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]


        public async Task<ActionResult<ApiEntities.AccessGroupEditingDataBasic>> GetEditorData(Guid clusterUid, bool includePhoto = true, int photoPixelWidth = 200)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<GalaxyAccessGroupManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var getparams = new WcfEntities.GetParametersWithPhoto()
                {
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    ClusterUid = clusterUid,
                    UniqueId = clusterUid,
                    IncludeMemberCollections = false
                };


                var result = await mgr.GetAccessGroupEditingDataAsync(getparams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                {
                    return NotFound();
                }
                var model = Mapper.Map<ApiEntities.AccessGroupEditingDataBasic>(result);
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
        /// Create a new Access Group.
        /// </summary>
        /// <remarks>   IgnoreProperties: AccessPortals</remarks>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.AccessGroup&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RequestModels.AccessGroupPutReq>> Post(RequestModels.SaveParams<RequestModels.AccessGroupReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (parameters.Data.ClusterUid == Guid.Empty)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot add AccessGroup with ClusterUid value of {parameters.Data.ClusterUid}");
                if (parameters.Data.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup ||
                    //parameters.Data.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.None ||
                    parameters.Data.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.UnlimitedAccess)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"AccessGroupNumber {parameters.Data.AccessGroupNumber} cannot be created because it is a reserved system access group");

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());
                var mgr = Helpers.GetManager<GalaxyAccessGroupManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.AccessGroup>(parameters.Data);
                wcfEntity.ConcurrencyValue = 0;

                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.AccessGroup>(wcfEntity, wcfSaveParameters);
                var validationProblemDetails = await mgr.ValidateAccessGroupAsync(wcfParams);
                if (validationProblemDetails != null)
                {
                    if (validationProblemDetails is { IsValid: false })
                    {
                        return ValidationProblem(new ValidationProblemDetails(validationProblemDetails.Errors));
                    }
                }

                var results = await mgr.SaveAccessGroupAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    //var savedItem = Mapper.Map<ApiEntities.AccessGroup>(results);
                    var savedItem = Mapper.Map<RequestModels.AccessGroupPutReq>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "AccessGroup",
                        new { accessGroupUid = savedItem.AccessGroupUid });
                    if (results.UpdateDate > results.InsertDate)
                        return Ok(savedItem);
                    return Created(url, savedItem);
                }

                return this.StatusCode((int)mgr.HttpStatusCode, ResponseMessages.UnknownReason);
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

                return this.StatusCode((int)ex.Detail.PreferredHttpStatusCode, ex.Message);
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
        /// Update an existing Access Group item. Can also create a new access group.
        /// </summary>
        /// <remarks>   IgnoreProperties: AccessPortals</remarks>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.AccessGroup&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<RequestModels.AccessGroupPutReq>> Put(RequestModels.SaveParams<RequestModels.AccessGroupPutReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (parameters.Data.ClusterUid == Guid.Empty)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot update AccessGroup with ClusterUid value of {parameters.Data.ClusterUid}");

                if (parameters.Data.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup ||
                    parameters.Data.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.None ||
                    parameters.Data.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.UnlimitedAccess)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"AccessGroupNumber {parameters.Data.AccessGroupNumber} cannot be saved because it is a reserved system access group");

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgr = Helpers.GetManager<GalaxyAccessGroupManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);
                wcfSaveParameters.AddOption(nameof(GalaxySMS.Common.Enums.SaveAccessGroupAccessPortalsOption), SaveAccessGroupAccessPortalsOption.SetMissingItemsToNever.ToString());
                var wcfEntity = Mapper.Map<WcfEntities.AccessGroup>(parameters.Data);
                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.AccessGroup>(wcfEntity, wcfSaveParameters);

                var validationProblemDetails = await mgr.ValidateAccessGroupAsync(wcfParams);
                if (validationProblemDetails != null)
                {
                    if (validationProblemDetails is { IsValid: false })
                    {
                        return ValidationProblem(new ValidationProblemDetails(validationProblemDetails.Errors));
                    }
                }
                var results = await mgr.SaveAccessGroupAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    //var savedItem = Mapper.Map<ApiEntities.AccessGroup>(results);
                    var savedItem = Mapper.Map<RequestModels.AccessGroupPutReq>(results);
                    //foreach (var ap in savedItem.AccessPortals)
                    //{
                    //    if (ap.TimeScheduleUid == TimeScheduleIds.TimeSchedule_Default)
                    //    {
                    //        ap.TimeScheduleUid = null;
                    //        ap.TimeScheduleName = null;
                    //    }
                    //}
                    var url = LinkGenerator.GetPathByAction("Get",
                        "AccessGroup",
                        new { accessGroupUid = savedItem.AccessGroupUid });
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

                return this.StatusCode((int)ex.Detail.PreferredHttpStatusCode, ex.Message);
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
        /// Delete a specific access group by AccessGroupUid.
        /// </summary>
        ///
        /// <param name="accessGroupUid"> Identifier for the Access Group to delete. </param>
        ///
        /// <returns>   A Task&lt;IActionResult&gt; </returns>
        ///=================================================================================================        
        [HttpDelete("{accessGroupUid}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid accessGroupUid)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<GalaxyAccessGroupManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetAccessGroupAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = accessGroupUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = false
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                if (result.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup ||
                    result.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.None ||
                    result.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.UnlimitedAccess)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"This access group cannot be deleted because it is a reserved system access group");
                //return Forbid();

                var x = await mgr.DeleteAccessGroupByUniqueIdAsync(new WcfEntities.DeleteParameters() { UniqueId = accessGroupUid });

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


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("personinfo/{accessGroupUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.AccessGroupPersonInfo>>> GetPersonInfoForAccessGroup(Guid accessGroupUid, bool includeLastUsageData, int pageSize, int pageNumber)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<GalaxyAccessGroupManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = accessGroupUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = false,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                if( includeLastUsageData)
                    wcfGetParams.AddOption(GetOptions_AccessGroup.IncludePersonLastAccessInfo, includeLastUsageData);

                var results = await mgr.GetPersonInfoForAccessGroupAsync(wcfGetParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.AccessGroupPersonInfo>>(results);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }



    }
}
