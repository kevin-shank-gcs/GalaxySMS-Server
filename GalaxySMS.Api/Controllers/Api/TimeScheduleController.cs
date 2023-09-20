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
using GalaxySMS.Api.Models.RequestModels;
using GCS.Core.Common.Extensions;
using System.Linq;
using GalaxySMS.Business.Entities.Api.NetCore.Response;

namespace GalaxySMS.Api.Controllers.Api
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Operations relating to Time Schedules. </summary>
    ///<remarks>  </remarks>
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================
    //[ApiExplorerSettings(IgnoreApi = true)]

    [Route("api/[controller]")]
    [ApiController] // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TimeScheduleController : ControllerBaseEx
    {
        public TimeScheduleController(IConfiguration config,
            IMapper mapper,
            ILogger<TimeScheduleController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper,
            logger, linkGenerator, cache, distributedCache)
        {

        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get all Time Schedules for an entity. </summary>
        ///
        /// <param name="entityId">     (Optional) The unique ID of the entity to request schedules for. If not specified, schedules for current entity will be requested. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.TimeScheduleBasic[]&gt;&gt; </returns>
        ///=================================================================================================

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
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.TimeScheduleBasic>>> Get(Guid entityId,
            int pageSize, int pageNumber, bool includeChildren = false,
            TimeScheduleSortProperty sortBy = TimeScheduleSortProperty.Display, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<TimeScheduleManager>(ServerWcfServerAddress, ServerWcfBindingType,
                    ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetTimeSchedulesForEntityAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = entityId,
                    IncludePhoto = false,
                    IncludeMemberCollections = includeChildren,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.TimeScheduleBasic>>(results);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get all Time Schedules for an entity. </summary>
        /// 
        /// <param name="entityId">     (Optional) The unique ID of the entity to request schedules for. If not specified, schedules for current entity will be requested. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.TimeScheduleBasic[]&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.ListItemBaseSimple>>> GetList(
            Guid entityId, int pageSize, int pageNumber,
            TimeScheduleClusterItemSortProperty sortBy = TimeScheduleClusterItemSortProperty.Name,
            OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<TimeScheduleManager>(ServerWcfServerAddress, ServerWcfBindingType,
                    ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetTimeSchedulesForEntityListItemsAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = entityId,
                    IncludePhoto = false,
                    IncludeMemberCollections = false,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                //var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.TimeScheduleListItem>>(results);
                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.ListItemBaseSimple>>(results);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");
            }
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("forcluster/{clusterUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.TimeScheduleClusterItem>>> GetForCluster(
            Guid clusterUid, int pageSize, int pageNumber,
            TimeScheduleClusterItemSortProperty sortBy = TimeScheduleClusterItemSortProperty.Name,
            OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<TimeScheduleManager>(ServerWcfServerAddress, ServerWcfBindingType,
                    ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetTimeScheduleClusterItemsForClusterAsync(
                    new WcfEntities.GetParametersWithPhoto()
                    {
                        UniqueId = clusterUid,
                        IncludePhoto = false,
                        IncludeMemberCollections = false,
                        PageNumber = pageNumber,
                        PageSize = pageSize,
                        DescendingOrder = orderBy == OrderBy.Desc,
                        SortProperty = sortBy.ToString()
                    });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                //var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.TimeScheduleListItem>>(results);
                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.TimeScheduleClusterItem>>(results);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get all Time Schedules for an entity. </summary>
        /// 
        /// <param name="entityId">     (Optional) The unique ID of the entity to request schedules for. If not specified, schedules for current entity will be requested. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.TimeScheduleBasic[]&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("listforcluster")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.ListItemBaseSimple>>> GetListForCluster(
            Guid clusterUid, int pageSize, int pageNumber,
            TimeScheduleClusterItemSortProperty sortBy = TimeScheduleClusterItemSortProperty.Name,
            OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<TimeScheduleManager>(ServerWcfServerAddress, ServerWcfBindingType,
                    ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetTimeSchedulesForClusterListItemsAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = clusterUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = false,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                //var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.TimeScheduleListItem>>(results);
                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.ListItemBaseSimple>>(results);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");
            }
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get all Time Schedules. </summary>
        ///
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.TimeScheduleBasic[]&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("all")]
        [ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.TimeScheduleBasic>>> GetAll(int pageSize,
            int pageNumber, bool includeChildren = false,
            TimeScheduleSortProperty sortBy = TimeScheduleSortProperty.Display, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<TimeScheduleManager>(ServerWcfServerAddress, ServerWcfBindingType,
                    ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetAllTimeSchedulesAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    IncludePhoto = false,
                    IncludeMemberCollections = includeChildren,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.TimeScheduleBasic>>(results);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get list of all Time Schedules. </summary>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.TimeScheduleBasic[]&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("alllist")]
        [ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.ListItemBaseSimple>>> GetAllList(
            int pageSize, int pageNumber,
            TimeScheduleClusterItemSortProperty sortBy = TimeScheduleClusterItemSortProperty.Name,
            OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<TimeScheduleManager>(ServerWcfServerAddress, ServerWcfBindingType,
                    ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetAllTimeSchedulesListItemsAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    IncludePhoto = false,
                    IncludeMemberCollections = false,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.ListItemBaseSimple>>(results);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get a Time Schedule by TimeScheduleUid value. </summary>
        /// 
        /// <param name="timeScheduleUid">   The TimeScheduleUID. </param>
        /// <param name="includeProperties">    (Optional) Comma-separated list of property names to include in the response
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.TimeSchedule&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{timeScheduleUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<RequestModels.TimeSchedulePutReq>> Get(Guid timeScheduleUid,
            string includeProperties = "")
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var includeChildren = true;
                var getForPut = true;

                var parameters = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = timeScheduleUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = includeChildren,
                };

                if (!string.IsNullOrEmpty(includeProperties))
                {
                    var includeProps = includeProperties.ToLower().Split(',');
                    var responseProperties =
                        typeof(WcfEntities.TimeSchedule).GetComplexProperties().ToList();
                    foreach (var p in responseProperties)
                    {
                        var included =
                            includeProps.FirstOrDefault(o => o.TrimStart().TrimEnd().ToLower() == p.Name.ToLower());
                        if (included == null)
                            parameters.ExcludeMemberCollectionSettings.Add(p.Name);
                    }
                }
                else
                {
                }

                var mgr = Helpers.GetManager<TimeScheduleManager>(ServerWcfServerAddress, ServerWcfBindingType,
                    ServerUserName, ServerPassword, ClientUserSessionData);


                //wcfGetParams.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(WcfEntities.Cluster.GalaxyPanels), true));
                //wcfGetParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.Cluster.GalaxyPanels));
                var result = await mgr.GetTimeScheduleAsync(parameters);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                return Ok(Mapper.Map<RequestModels.TimeSchedulePutReq>(result));
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
                    return NotFound();

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Create a new Time Schedule.
        /// </summary>
        /// <remarks>    </remarks>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.TimeSchedule&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<ResponseModels.TimeScheduleResp>> Post(RequestModels.SaveParams<RequestModels.TimeScheduleReq> parameters)
        public async Task<ActionResult<TimeSchedulePutReq>> Post(
            RequestModels.SaveParams<RequestModels.TimeScheduleReq> parameters)
        {
            //return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot add an TimeSchedule using this technique. New Time Schedules are created via the GalaxyPanel POST/PUT operations.");
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());
                var mgr = Helpers.GetManager<TimeScheduleManager>(ServerWcfServerAddress, ServerWcfBindingType,
                    ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.TimeSchedule>(parameters.Data);
                wcfEntity.ConcurrencyValue = 0;

                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.TimeSchedule>(wcfEntity, wcfSaveParameters);

                var results = await mgr.SaveTimeScheduleAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var savedItem = Mapper.Map<TimeSchedulePutReq>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "TimeSchedule",
                        new { TimeScheduleUid = savedItem.TimeScheduleUid });
                    if (results.UpdateDate > results.InsertDate)
                        return Ok(savedItem);
                    return Created(url, savedItem);
                }

                return this.StatusCode(StatusCodes.Status500InternalServerError, ResponseMessages.UnknownReason);
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(
                        typeof(GCS.Core.Common.Exceptions.AuthorizationValidationException).ToString()))
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
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");
            }

        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Update an existing Time Schedule item. Can also create a new Time Schedule.
        /// </summary>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.TimeSchedule&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<TimeSchedulePutReq>> Put(
            RequestModels.SaveParams<RequestModels.TimeSchedulePutReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (parameters.Data.TimeScheduleUid == Guid.Empty)
                    return BadRequest($"Cannot update TimeSchedule without a valid TimeScheduleUid value");

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgr = Helpers.GetManager<TimeScheduleManager>(ServerWcfServerAddress, ServerWcfBindingType,
                    ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.TimeSchedule>(parameters.Data);
                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.TimeSchedule>(wcfEntity, wcfSaveParameters);

                var results = await mgr.SaveTimeScheduleAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var savedItem = Mapper.Map<TimeSchedulePutReq>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "TimeSchedule",
                        new { TimeScheduleUid = savedItem.TimeScheduleUid });
                    if (results.UpdateDate > results.InsertDate)
                        return Ok(savedItem);
                    return Created(url, savedItem);
                }

                return this.StatusCode(StatusCodes.Status500InternalServerError, ResponseMessages.UnknownReason);
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(
                        typeof(GCS.Core.Common.Exceptions.AuthorizationValidationException).ToString()))
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
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Delete a specific Time Schedule by TimeScheduleUid.
        /// </summary>
        ///
        /// <param name="timeScheduleUid"> Identifier for the Time Schedule to delete. </param>
        ///
        /// <returns>   A Task&lt;IActionResult&gt; </returns>
        ///=================================================================================================        
        [HttpDelete("{timeScheduleUid}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid timeScheduleUid)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<TimeScheduleManager>(ServerWcfServerAddress, ServerWcfBindingType,
                    ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetTimeScheduleAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = timeScheduleUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = false
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                var canUnmap = await mgr.CanTimeScheduleBeDeletedAsync(timeScheduleUid);
                if (!canUnmap)
                {
                    var mappings = await mgr.GetTimeScheduleUsageInformationAsync(timeScheduleUid, Guid.Empty);
                    if (mappings != null && mappings.IsUsed)
                    {
                        var data = new CustomTimeScheduleUsageData()
                        {
                            ClusterName = mappings.ClusterName,
                            ClusterUid = mappings.ClusterUid,
                            TimeScheduleUid = mappings.TimeScheduleUid,
                            TimeScheduleName = mappings.TimeScheduleName,
                            Message = mappings.Message,
                            Mappings = new TimeScheduleMappings()
                        };
                        if (mappings.Mappings.AccessPortals.Any())
                            data.Mappings.AccessPortals.AddRange(mappings.Mappings.AccessPortals);
                        if (mappings.Mappings.AccessGroups.Any())
                            data.Mappings.AccessGroups.AddRange(mappings.Mappings.AccessGroups);
                        if (mappings.Mappings.AccessGroupAccessPortals.Any())
                            data.Mappings.AccessGroups.AddRange(mappings.Mappings.AccessGroupAccessPortals);
                        if (mappings.Mappings.GalaxyPanels.Any())
                            data.Mappings.GalaxyPanels.AddRange(mappings.Mappings.GalaxyPanels);
                        if (mappings.Mappings.InputOutputGroups.Any())
                            data.Mappings.InputOutputGroups.AddRange(mappings.Mappings.InputOutputGroups);
                        if (mappings.Mappings.InputDevices.Any())
                            data.Mappings.InputDevices.AddRange(mappings.Mappings.InputDevices);
                        if (mappings.Mappings.OutputDevices.Any())
                            data.Mappings.OutputDevices.AddRange(mappings.Mappings.OutputDevices);
                        if (mappings.Mappings.People.Any())
                            data.Mappings.People.AddRange(mappings.Mappings.People);

                        var response = new CustomValidationProblemDetails()
                        {
                            errors = data,
                            status = StatusCodes.Status400BadRequest,
                            title = "One or more validation errors occurred."
                        };
                        return BadRequest(response);
                    }
                    return BadRequest($"TimeScheduleUid {timeScheduleUid} cannot be deleted because it is in use.");
                }



                var x = await mgr.DeleteTimeScheduleByUniqueIdAsync(new WcfEntities.DeleteParameters()
                { UniqueId = timeScheduleUid });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                return Ok();
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
                    return NotFound();

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary>
        ///  Maps a specific TimeSchedule to a cluster.
        ///  </summary>
        /// 
        ///  <param name="timeScheduleUid"> Identifier for the TimeSchedule to map. </param>
        ///  <param name="clusterUid"> Identifier for the Cluster to map. </param>
        ///  <param name="fifteenMinuteFormatUsesHolidays"> True enables holiday support for the time schedule</param>
        ///  <returns>   A Task&lt;IActionResult&gt; </returns>
        /// =================================================================================================        
        [HttpPost("{timeScheduleUid}/mapcluster/{clusterUid}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiEntities.GalaxyClusterTimeScheduleMapBasic>> PostTimeScheduleMapping(Guid timeScheduleUid, Guid clusterUid, bool fifteenMinuteFormatUsesHolidays = true)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var validationProblemDetails = await ValidateClusterTimeScheduleMapping(timeScheduleUid, clusterUid);
                if (validationProblemDetails != null)
                    return ValidationProblem(validationProblemDetails);

                var mgr = Helpers.GetManager<TimeScheduleManager>(ServerWcfServerAddress, ServerWcfBindingType,
                    ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.SaveTimeScheduleClusterMappingAsync(timeScheduleUid, clusterUid, true,
                    fifteenMinuteFormatUsesHolidays);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                return Ok(Mapper.Map<ApiEntities.GalaxyClusterTimeScheduleMapBasic>(result));
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
                    return NotFound();

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Delete a specific Cluster to TimeSchedule mapping.
        /// </summary>
        ///
        /// <param name="timeScheduleUid"> Identifier for the TimeSchedule to delete. </param>
        /// <param name="clusterUid"> Identifier for the Cluster to delete. </param>
        ///
        /// <returns>   A Task&lt;IActionResult&gt; </returns>
        ///=================================================================================================        
        [HttpDelete("{timeScheduleUid}/mapcluster/{clusterUid}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTimeScheduleMapping(Guid timeScheduleUid, Guid clusterUid)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (timeScheduleUid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never ||
                    timeScheduleUid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always)
                    return BadRequest($"TimeScheduleUid {timeScheduleUid} cannot be un-mapped from a cluster.");

                var mgr = Helpers.GetManager<TimeScheduleManager>(ServerWcfServerAddress, ServerWcfBindingType,
                    ServerUserName, ServerPassword, ClientUserSessionData);
                var canUnmap = await mgr.CanTimeScheduleBeUnmappedFromClusterAsync(timeScheduleUid, clusterUid);
                if (!canUnmap)
                {
                    var mappings = await mgr.GetTimeScheduleUsageInformationAsync(timeScheduleUid, clusterUid);
                    if (mappings != null && mappings.IsUsed)
                    {
                        var data = new CustomTimeScheduleUsageData()
                        {
                            ClusterName = mappings.ClusterName,
                            ClusterUid = mappings.ClusterUid,
                            TimeScheduleUid = mappings.TimeScheduleUid,
                            TimeScheduleName = mappings.TimeScheduleName,
                            Message = mappings.Message,
                            Mappings = new TimeScheduleMappings()
                        };
                        if (mappings.Mappings.AccessPortals.Any())
                            data.Mappings.AccessPortals.AddRange(mappings.Mappings.AccessPortals);
                        if (mappings.Mappings.AccessGroups.Any())
                            data.Mappings.AccessGroups.AddRange(mappings.Mappings.AccessGroups);
                        if (mappings.Mappings.AccessGroupAccessPortals.Any())
                            data.Mappings.AccessGroups.AddRange(mappings.Mappings.AccessGroupAccessPortals);
                        if (mappings.Mappings.GalaxyPanels.Any())
                            data.Mappings.GalaxyPanels.AddRange(mappings.Mappings.GalaxyPanels);
                        if (mappings.Mappings.InputOutputGroups.Any())
                            data.Mappings.InputOutputGroups.AddRange(mappings.Mappings.InputOutputGroups);
                        if (mappings.Mappings.InputDevices.Any())
                            data.Mappings.InputDevices.AddRange(mappings.Mappings.InputDevices);
                        if (mappings.Mappings.OutputDevices.Any())
                            data.Mappings.OutputDevices.AddRange(mappings.Mappings.OutputDevices);
                        if (mappings.Mappings.People.Any())
                            data.Mappings.People.AddRange(mappings.Mappings.People);

                        var response = new CustomValidationProblemDetails()
                        {
                            errors = data,
                            status = StatusCodes.Status400BadRequest,
                            title = "One or more validation errors occurred."
                        };
                        return BadRequest(response);
                    }
                    return BadRequest($"TimeScheduleUid {timeScheduleUid} cannot be un-mapped from a cluster {clusterUid} because it is in use.");
                }

                var result = await mgr.SaveTimeScheduleClusterMappingAsync(timeScheduleUid, clusterUid, false, false);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                return Ok(Mapper.Map<ApiEntities.GalaxyClusterTimeScheduleMapBasic>(result));
            }
            catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

                if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
                    return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

                if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
                    return NotFound();

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                    return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");
            }
            catch (Exception ex)
            {
                Logger.LogError(
                    $"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message); //$"Failure:{ex.ToString()}");
            }
        }
        private async Task<ValidationProblemDetails> ValidateClusterTimeScheduleMapping(Guid timeScheduleUid, Guid clusterUid)
        {
            var mgr = Helpers.GetManager<ValidationManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

            var parameters = new WcfEntities.GuidValidationRequest()
            {

            };
            parameters.Items.Add(new WcfEntities.GuidValidationRequestItem()
            {
                ValidationRequestType = ValidationRequestType.ClusterAndTimeScheduleEntities,
                ClusterUid = clusterUid,
                TimeScheduleUid = timeScheduleUid,
                PreventSystemEntityMatches = false,
                PropertyName = "ClusterTimeScheduleMapping"
            });
            var results = await mgr.ValidateRequest(parameters);

            if (results is { IsValid: false })
            {
                return new ValidationProblemDetails(results.Errors);
            }

            return null;
        }


    }
}
