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
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using RequestModels = GalaxySMS.Api.Models.RequestModels;
using ResponseModels = GalaxySMS.Api.Models.ResponseModels;
using WcfEntities = GalaxySMS.Business.Entities;
using GalaxySMS.Api.Models.RequestModels;

namespace GalaxySMS.Api.Controllers.Api
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Operations relating to Areas. </summary>
    ///<remarks>  </remarks>
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================

    [Route("api/[controller]")]
    [ApiController]  // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AreaController : ControllerBaseEx
    {
        public AreaController(IConfiguration config,
            IMapper mapper,
            ILogger<AreaController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper, logger, linkGenerator, cache, distributedCache)
        {

        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Get all areas for the current entity. </summary>
        /////
        ///// <param name="pageSize">     Size of the page. 0 = no paging</param>
        ///// <param name="pageNumber">   The page number. </param>
        /////  <param name="sortBy"> (Optional) The property to sort the results by</param>
        /////  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        /////
        ///// <returns>   A Task&lt;ActionResult&lt;ApiEntities.AreaBasic[]&gt;&gt; </returns>
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
        //public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.AreaBasic>>> Get(int pageSize, int pageNumber, AreaSortProperty sortBy = AreaSortProperty.Display, OrderBy orderBy = OrderBy.Asc /*bool includeChildren = false*/)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<GalaxyAreaManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var results = await mgr.GetAllAreasForEntityAsync(new WcfEntities.GetParametersWithPhoto()
        //        {
        //            IncludePhoto = false,
        //            IncludeMemberCollections = false,
        //            PageNumber = pageNumber,
        //            PageSize = pageSize,
        //            DescendingOrder = orderBy == OrderBy.Desc,
        //            SortProperty = sortBy.ToString()
        //        });

        //        if (mgr.HasErrors)
        //        {
        //            return GetStatusCodeResult(mgr);
        //        }

        //        var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.AreaBasic>>(results);
        //        return Ok(resp);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //}


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Get all areas. </summary>
        /////
        ///// <param name="pageSize">     Size of the page. 0 = no paging</param>
        ///// <param name="pageNumber">   The page number. </param>
        /////  <param name="sortBy"> (Optional) The property to sort the results by</param>
        /////  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        /////
        ///// <returns>   A Task&lt;ActionResult&lt;ApiEntities.AreaBasic[]&gt;&gt; </returns>
        /////=================================================================================================

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
        //public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.AreaBasic>>> GetAll(int pageSize, int pageNumber, AreaSortProperty sortBy = AreaSortProperty.Display, OrderBy orderBy = OrderBy.Asc /*bool includeChildren = false*/)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<GalaxyAreaManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var results = await mgr.GetAllAreasAsync(new WcfEntities.GetParametersWithPhoto()
        //        {
        //            IncludePhoto = false,
        //            IncludeMemberCollections = false,
        //            PageNumber = pageNumber,
        //            PageSize = pageSize,
        //            DescendingOrder = orderBy == OrderBy.Desc,
        //            SortProperty = sortBy.ToString()
        //        });

        //        if (mgr.HasErrors)
        //        {
        //            return GetStatusCodeResult(mgr);
        //        }

        //        var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.AreaBasic>>(results);
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
        /// Get all areas for a specific entity.
        /// </summary>
        ///
        /// <param name="entityId">  The entity ID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   The areas for the entity. </returns>
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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.AreaBasic>>> GetAreasForEntity(Guid entityId, int pageSize, int pageNumber, AreaSortProperty sortBy = AreaSortProperty.Display, OrderBy orderBy = OrderBy.Asc /*, bool includeChildren = false*/)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<GalaxyAreaManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetAllAreasForEntityAsync(new WcfEntities.GetParametersWithPhoto()
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

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.AreaBasic>>(results);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get all areas for a cluster.
        /// </summary>
        ///
        /// <param name="clusterUid">  The cluster UID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   The areas for cluster. </returns>
        ///=================================================================================================
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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.AreaBasic>>> GetAreasForCluster(Guid clusterUid, int pageSize, int pageNumber, AreaSortProperty sortBy = AreaSortProperty.Display, OrderBy orderBy = OrderBy.Asc /*, bool includeChildren = false*/)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<GalaxyAreaManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetAreasForClusterAsync(new WcfEntities.GetParametersWithPhoto()
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

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.AreaBasic>>(results);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get a area by AreaUid value. </summary>
        /// 
        /// <param name="areaUid">   The area UID. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.Area&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{areaUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ResponseModels.AreaResp>> Get(Guid areaUid)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var getForPut = true;

                var mgr = Helpers.GetManager<GalaxyAreaManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = areaUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = false,
                };

                var result = await mgr.GetAreaAsync(wcfGetParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                if (getForPut)
                    return Ok(Mapper.Map<RequestModels.AreaPutReq>(result));

                var model = Mapper.Map<ResponseModels.AreaResp>(result);
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
        /// Create a new area.
        /// </summary>
        /// <remarks>   </remarks>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.Area&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RequestModels.AreaPutReq>> Post(RequestModels.SaveParams<RequestModels.AreaReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (parameters.Data.ClusterUid == Guid.Empty)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot add Area with ClusterUid value of {parameters.Data.ClusterUid}");

                // Can't create NoArea, NOChange, 1 & 2. The back-end creates these when a cluster is created or saved.
                if ((parameters.Data.AreaNumber == (int)GalaxySMS.Common.Enums.AreaNumber.NoArea ||
                    parameters.Data.AreaNumber == (int)Common.Enums.AreaNumber.NoChange ||
                    parameters.Data.AreaNumber == (int)Common.Enums.AreaNumber.In ||
                    parameters.Data.AreaNumber == (int)Common.Enums.AreaNumber.Out) && parameters.Data.AreaUid != Guid.Empty)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"AreaNumber {parameters.Data.AreaNumber} cannot be created because it is a reserved system area");

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());
                var mgr = Helpers.GetManager<GalaxyAreaManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.Area>(parameters.Data);
                wcfEntity.ConcurrencyValue = 0;

                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.Area>(wcfEntity, wcfSaveParameters);

                var results = await mgr.SaveAreaAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var savedItem = Mapper.Map<AreaPutReq>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "Area",
                        new { areaUid = savedItem.AreaUid });
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
        /// Update an existing Area item. Can also create a new area.
        /// </summary>
        /// <remarks>  </remarks>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.Area&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<AreaPutReq>> Put(RequestModels.SaveParams<RequestModels.AreaPutReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (parameters.Data.ClusterUid == Guid.Empty)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot update Area with ClusterUid value of {parameters.Data.ClusterUid}");

                // Cant modify NoArea (0) and No Change (255), can rename an other
                if (parameters.Data.AreaNumber == (int)Common.Enums.AreaNumber.NoArea ||
                    parameters.Data.AreaNumber == (int)Common.Enums.AreaNumber.NoChange)
                    //|| parameters.Data.AreaNumber == (int)Common.Enums.AreaNumber.In ||
                    //parameters.Data.AreaNumber == (int)Common.Enums.AreaNumber.Out)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot update Area with AreaNumber value of {parameters.Data.AreaNumber}");

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgr = Helpers.GetManager<GalaxyAreaManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.Area>(parameters.Data);
                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.Area>(wcfEntity, wcfSaveParameters);

                var results = await mgr.SaveAreaAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var savedItem = Mapper.Map<AreaPutReq>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "Area",
                        new { areaUid = savedItem.AreaUid });
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
        /// Delete a specific area by AreaUid.
        /// </summary>
        ///
        /// <param name="areaUid"> Identifier for the area to delete. </param>
        ///
        /// <returns>   A Task&lt;IActionResult&gt; </returns>
        ///=================================================================================================        
        [HttpDelete("{areaUid}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid areaUid)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<GalaxyAreaManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetAreaAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = areaUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = false
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                // Can't attempt to delete NoArea and NoChange
                if (result.AreaNumber == (int)GalaxySMS.Common.Enums.AreaNumber.NoArea ||
                    result.AreaNumber == (int)Common.Enums.AreaNumber.NoChange)
                    //|| result.AreaNumber == (int)Common.Enums.AreaNumber.In ||
                    //result.AreaNumber == (int)Common.Enums.AreaNumber.Out)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"This area cannot be deleted because it is a reserved system area");

                var x = await mgr.DeleteAreaByUniqueIdAsync(new WcfEntities.DeleteParameters() { UniqueId = areaUid });

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
    }
}
