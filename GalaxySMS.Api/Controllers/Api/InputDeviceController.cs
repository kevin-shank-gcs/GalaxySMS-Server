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

namespace GalaxySMS.Api.Controllers.Api
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Operations relating to input devices. </summary>
    ///<remarks>  </remarks>
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================
    //[ApiExplorerSettings(IgnoreApi = true)]

    [Route("api/[controller]")]
    [ApiController]  // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class InputDeviceController : ControllerBaseEx
    {
        public InputDeviceController(IConfiguration config,
            IMapper mapper,
            ILogger<InputDeviceController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper, logger, linkGenerator, cache, distributedCache)
        {

        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get all input devices for an entity. </summary>
        ///
        /// <param name="entityId">     (Optional) The unique ID of the entity to request input devices for. If not specified, input devices for current entity will be requested. </param>
        /// <param name="searchText"> (Optional) Specifies text to search for in the name and optionally the comments and location properties.</param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        /// <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        /// <param name="photoPixelWidth">  (Optional) Specifies the width (in pixels) of the photo image.</param>
        /// <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        /// <param name="searchCommentsAndLocation"> (Optional) If search text is specified, True will also search comments and location properties for specified text.</param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.InputDeviceBasic[]&gt;&gt; </returns>
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
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.InputDeviceBasic>>> Get(Guid entityId, string searchText, int pageSize, int pageNumber, bool includeChildren = false, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, bool searchCommentsAndLocation = false, InputDeviceSortProperty sortBy = InputDeviceSortProperty.InputName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                WcfEntities.ArrayResponse<WcfEntities.InputDevice> results = null;
                var parameters = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = entityId,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = includeChildren,
                    IncludeCommands = includeCommands,
                    GetString = searchText,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                };
                if (string.IsNullOrEmpty(searchText))
                {
                    results = await mgr.GetAllInputDevicesForEntityAsync(parameters);
                }
                else
                {
                    if (searchCommentsAndLocation)
                        parameters.AddOption(GetOptions_AccessPortal.SearchIncludesComments, searchCommentsAndLocation);

                    results = await mgr.GetInputDevicesByTextSearchAsync(parameters);
                }

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.InputDeviceBasic>>(results);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get all input devices for an entity. </summary>
        /// 
        ///  <param name="entityId">     (Optional) The unique ID of the entity to request input devices for. If not specified, input devices for current entity will be requested. </param>
        /// <param name="searchText"> (Optional) Specifies text to search for in the name and optionally the comments and location properties.</param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        /// <param name="photoPixelWidth">  (Optional) Specifies the width (in pixels) of the photo image.</param>
        /// <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        /// <param name="searchCommentsAndLocation"> (Optional) If search text is specified, True will also search comments and location properties for specified text.</param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.InputDeviceBasic[]&gt;&gt; </returns>
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
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.InputDeviceListItemCommands>>> GetList(Guid entityId, string searchText, int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, bool searchCommentsAndLocation = false, InputDeviceSortProperty sortBy = InputDeviceSortProperty.InputName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                WcfEntities.ArrayResponse<WcfEntities.InputDeviceListItemCommands> results = null;
                var parameters = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = entityId,
                    GetString = searchText,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = false,
                    IncludeCommands = includeCommands,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                };

                if (string.IsNullOrEmpty(searchText))
                {
                    results = await mgr.GetAllInputDevicesListForEntityAsync(parameters);
                }
                else
                {
                    if (searchCommentsAndLocation)
                        parameters.AddOption(GetOptions_AccessPortal.SearchIncludesComments, searchCommentsAndLocation);

                    results = await mgr.GetInputDevicesListByTextSearchAsync(parameters);
                }

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.InputDeviceListItemCommands>>(results);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Get all input devices. </summary>
        /////
        ///// <param name="pageSize">     Size of the page. 0 = no paging</param>
        ///// <param name="pageNumber">   The page number. </param>
        ///// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        ///// <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        ///// <param name="photoPixelWidth">  (Optional) Specifies the width (in pixels) of the photo image.</param>
        ///// <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        /////  <param name="sortBy"> (Optional) The property to sort the results by</param>
        /////  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///// 
        ///// <returns>   A Task&lt;ActionResult&lt;ApiEntities.InputDeviceBasic[]&gt;&gt; </returns>
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
        //public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.InputDeviceBasic>>> GetAll(int pageSize, int pageNumber, bool includeChildren = false, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, InputDeviceSortProperty sortBy = InputDeviceSortProperty.InputName, OrderBy orderBy = OrderBy.Asc)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var results = await mgr.GetAllInputDevicesAsync(new WcfEntities.GetParametersWithPhoto()
        //        {
        //            IncludePhoto = includePhoto,
        //            PhotoPixelWidth = photoPixelWidth,
        //            IncludeMemberCollections = includeChildren,
        //            IncludeCommands = includeCommands,
        //            PageNumber = pageNumber,
        //            PageSize = pageSize,
        //            DescendingOrder = orderBy == OrderBy.Desc,
        //            SortProperty = sortBy.ToString()
        //        });

        //        if (mgr.HasErrors)
        //        {
        //            return GetStatusCodeResult(mgr);
        //        }

        //        var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.InputDeviceBasic>>(results);
        //        return Ok(resp);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //}


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Get list of all input devices. </summary>
        ///// 
        ///// <param name="pageSize">     Size of the page. 0 = no paging</param>
        ///// <param name="pageNumber">   The page number. </param>
        ///// <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        ///// <param name="photoPixelWidth">  (Optional) Specifies the width (in pixels) of the photo image.</param>
        ///// <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        /////  <param name="sortBy"> (Optional) The property to sort the results by</param>
        /////  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        /////
        ///// <returns>   A Task&lt;ActionResult&lt;ApiEntities.InputDeviceBasic[]&gt;&gt; </returns>
        /////=================================================================================================

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet("alllist")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        ////[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        //// If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        ////[MapToApiVersion("1.0")]
        //public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.InputDeviceListItemCommands>>> GetAllList(int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, InputDeviceSortProperty sortBy = InputDeviceSortProperty.InputName, OrderBy orderBy = OrderBy.Asc)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var results = await mgr.GetAllInputDevicesListAsync(new WcfEntities.GetParametersWithPhoto()
        //        {
        //            IncludePhoto = includePhoto,
        //            PhotoPixelWidth = photoPixelWidth,
        //            IncludeMemberCollections = false,
        //            IncludeCommands = includeCommands,
        //            PageNumber = pageNumber,
        //            PageSize = pageSize,
        //            DescendingOrder = orderBy == OrderBy.Desc,
        //            SortProperty = sortBy.ToString()
        //        });

        //        if (mgr.HasErrors)
        //        {
        //            return GetStatusCodeResult(mgr);
        //        }

        //        var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.InputDeviceListItemCommands>>(results);
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
        /// Get all input devices for a site.
        /// </summary>
        ///
        /// <param name="siteUid">  The site UID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        /// <param name="photoPixelWidth">  (Optional) Specifies the width (in pixels) of the photo image.</param>
        /// <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   The list for site. </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("allforsite/{siteUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.InputDeviceBasic>>> GetInputDevicesForSite(Guid siteUid, int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, InputDeviceSortProperty sortBy = InputDeviceSortProperty.InputName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetInputDevicesForSiteAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = siteUid,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = false,
                    IncludeCommands = includeCommands,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.InputDeviceBasic>>(results);
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
        /// Get list of all input devices for a site.
        /// </summary>
        ///
        /// <param name="siteUid">  The site UID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        /// <param name="photoPixelWidth">  (Optional) Specifies the width (in pixels) of the photo image.</param>
        /// <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   The list for site. </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("listforsite/{siteUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.InputDeviceListItemCommands>>> GetInputDevicesListForSite(Guid siteUid, int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, InputDeviceSortProperty sortBy = InputDeviceSortProperty.InputName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetInputDevicesListForSiteAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = siteUid,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = false,
                    IncludeCommands = includeCommands,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.InputDeviceListItemCommands>>(results);
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
        /// Get all input devices for a cluster.
        /// </summary>
        ///
        /// <param name="clusterUid">  The cluster UID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        /// <param name="photoPixelWidth">  (Optional) Specifies the width (in pixels) of the photo image.</param>
        /// <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   The input devices for cluster. </returns>
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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.InputDeviceBasic>>> GetInputDevicesForCluster(Guid clusterUid, int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, InputDeviceSortProperty sortBy = InputDeviceSortProperty.InputName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetInputDevicesForClusterAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = clusterUid,
                    IncludePhoto = includeCommands,
                    PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = false,
                    IncludeCommands = includeCommands,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.InputDeviceBasic>>(results);
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
        /// Get list of all input devices for a cluster.
        /// </summary>
        ///
        /// <param name="clusterUid">  The cluster UID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        /// <param name="photoPixelWidth">  (Optional) Specifies the width (in pixels) of the photo image.</param>
        /// <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   The input devices for cluster. </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("listforcluster/{clusterUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.InputDeviceListItemCommands>>> GetInputDevicesListForCluster(Guid clusterUid, int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, InputDeviceSortProperty sortBy = InputDeviceSortProperty.InputName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetInputDevicesListForClusterAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = clusterUid,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = false,
                    IncludeCommands = includeCommands,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.InputDeviceListItemCommands>>(results);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>
        ///// Get all input devices for a entity.
        ///// </summary>
        /////
        ///// <param name="entityId">  The entity ID. </param>
        ///// <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        ///// <param name="photoPixelWidth">  (Optional) Specifies the width (in pixels) of the photo image.</param>
        ///// <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        /////
        ///// <returns>   The input devices for entity. </returns>
        /////=================================================================================================
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet("allforentity/{entityId}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        ////[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        //// If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        ////[MapToApiVersion("1.0")]

        //public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.InputDeviceBasic>>> GetInputDevicesForEntity(Guid entityId, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var results = await mgr.GetAllInputDevicesForEntityAsync(new WcfEntities.GetParametersWithPhoto()
        //        {
        //            UniqueId = entityId,
        //            IncludePhoto = includePhoto,
        //            PhotoPixelWidth = photoPixelWidth,
        //            IncludeMemberCollections = false,
        //            IncludeCommands = includeCommands
        //        });

        //        if (mgr.HasErrors)
        //        {
        //            var errString = mgr.GetErrorsString();
        //            if (errString.Contains(Support.MagicStrings.unauthorized))
        //                return this.StatusCode(StatusCodes.Status401Unauthorized, errString);
        //            if (errString.Contains(Support.MagicStrings.forbidden))
        //                return this.StatusCode(StatusCodes.Status403Forbidden, errString);
        //            return this.StatusCode(StatusCodes.Status500InternalServerError, errString);
        //        }

        //        var resp = new ApiEntities.ArrayResponse<ApiEntities.InputDeviceBasic>();
        //        resp.Items = Mapper.Map<ApiEntities.InputDeviceBasic[]>(results);
        //        resp.Count = resp.Items.Length;

        //        return Ok(resp);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>
        ///// Get list of all input devices for a entity.
        ///// </summary>
        /////
        ///// <param name="entityId">  The entity ID. </param>
        ///// <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        ///// <param name="photoPixelWidth">  (Optional) Specifies the width (in pixels) of the photo image.</param>
        ///// <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        /////
        ///// <returns>   The input devices for entity. </returns>
        /////=================================================================================================
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet("listforentity/{entityId}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        ////[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        //// If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        ////[MapToApiVersion("1.0")]

        //public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.InputDeviceListItemCommands>>> GetInputDevicesListForEntity(Guid entityId, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var results = await mgr.GetAllInputDevicesListForEntityAsync(new WcfEntities.GetParametersWithPhoto()
        //        {
        //            UniqueId = entityId,
        //            IncludePhoto = includePhoto,
        //            PhotoPixelWidth = photoPixelWidth,
        //            IncludeMemberCollections = false,
        //            IncludeCommands = includeCommands
        //        });

        //        if (mgr.HasErrors)
        //        {
        //            var errString = mgr.GetErrorsString();
        //            if (errString.Contains(Support.MagicStrings.unauthorized))
        //                return this.StatusCode(StatusCodes.Status401Unauthorized, errString);
        //            if (errString.Contains(Support.MagicStrings.forbidden))
        //                return this.StatusCode(StatusCodes.Status403Forbidden, errString);
        //            return this.StatusCode(StatusCodes.Status500InternalServerError, errString);
        //        }

        //        var resp = new ApiEntities.ArrayResponse<ApiEntities.InputDeviceListItemCommands>();
        //        resp.Items = Mapper.Map<ApiEntities.InputDeviceListItemCommands[]>(results);
        //        resp.Count = resp.Items.Length;

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
        /// Get all input devices for a region.
        /// </summary>
        ///
        /// <param name="regionUid">  The region UID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        /// <param name="photoPixelWidth">  (Optional) Specifies the width (in pixels) of the photo image.</param>
        /// <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   The input devices for region. </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("allforregion/{regionUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.InputDeviceBasic>>> GetInputDevicesForRegion(Guid regionUid, int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, InputDeviceSortProperty sortBy = InputDeviceSortProperty.InputName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetInputDevicesForRegionAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = regionUid,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = false,
                    IncludeCommands = includeCommands,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.InputDeviceBasic>>(results);
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
        /// Get list of all input devices for a region.
        /// </summary>
        ///
        /// <param name="regionUid">  The region UID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        /// <param name="photoPixelWidth">  (Optional) Specifies the width (in pixels) of the photo image.</param>
        /// <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   The input devices for region. </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("listforregion/{regionUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.InputDeviceListItemCommands>>> GetInputDevicesListForRegion(Guid regionUid, int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, InputDeviceSortProperty sortBy = InputDeviceSortProperty.InputName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetInputDevicesListForRegionAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = regionUid,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = false,
                    IncludeCommands = includeCommands,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.InputDeviceListItemCommands>>(results);
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
        /// Get all input devices for a galaxy panel.
        /// </summary>
        ///
        /// <param name="galaxyPanelUid">  The panel UID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        /// <param name="photoPixelWidth">  (Optional) Specifies the width (in pixels) of the photo image.</param>
        /// <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   The input devices for a specific panel. </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("allforgalaxypanel/{galaxyPanelUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.InputDeviceBasic>>> GetInputDevicesForGalaxyPanel(Guid galaxyPanelUid, int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, InputDeviceSortProperty sortBy = InputDeviceSortProperty.InputName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetInputDevicesForGalaxyPanelAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = galaxyPanelUid,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = false,
                    IncludeCommands = includeCommands,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.InputDeviceBasic>>(results);
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
        /// Get list of all input devices for a galaxy panel.
        /// </summary>
        ///
        /// <param name="galaxyPanelUid">  The panel UID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        /// <param name="photoPixelWidth">  (Optional) Specifies the width (in pixels) of the photo image.</param>
        /// <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   The input devices for a specific panel. </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("listforgalaxypanel/{galaxyPanelUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.InputDeviceListItemCommands>>> GetInputDevicesListForGalaxyPanel(Guid galaxyPanelUid, int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, InputDeviceSortProperty sortBy = InputDeviceSortProperty.InputName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetInputDevicesListForGalaxyPanelAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = galaxyPanelUid,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = false,
                    IncludeCommands = includeCommands,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.InputDeviceListItemCommands>>(results);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get a input device by InputDeviceUid value. </summary>
        /// 
        /// <param name="InputDeviceUid">   The input device UID. </param>
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        /// <param name="includePhoto">  (Optional) True to include, false to exclude the photo. </param>
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.InputDevice&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{InputDeviceUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ResponseModels.InputDeviceResp>> Get(Guid InputDeviceUid, bool includeChildren = false, bool includePhoto = false)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var getForPut = true;

                var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = InputDeviceUid,
                    IncludePhoto = includePhoto,
                    IncludeMemberCollections = includeChildren,
                };

                //wcfGetParams.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(WcfEntities.Cluster.GalaxyPanels), true));
                //wcfGetParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.Cluster.GalaxyPanels));
                var result = await mgr.GetInputDeviceAsync(wcfGetParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                if (getForPut)
                {
                    var putResult = Mapper.Map<RequestModels.InputDevicePutReq>(result);
                    putResult.PhotoImage = result.gcsBinaryResource?.BinaryResource;
                    return Ok(putResult);
                }

                var model = Mapper.Map<ResponseModels.InputDeviceResp>(result);
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
        /// Get input device Galaxy common editor data.
        /// </summary>
        ///
        /// <returns>   The editor data. </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("galaxycommoneditordata")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.InputDeviceGalaxyCommonEditingDataBasic>> GetGalaxyCommonEditorData()
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetInputDeviceGalaxyCommonEditingDataAsync(new WcfEntities.GetParametersWithPhoto()
                {
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();
                var model = Mapper.Map<ApiEntities.InputDeviceGalaxyCommonEditingDataBasic>(result);
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
        /// Get editor data for a specific input device.
        /// <param name="includePhoto"></param>
        /// <param name="photoPixelWidth"></param>
        /// </summary>
        /// <param name="InputDeviceUid">  The input device UID. </param>
        /// <returns>   The editor data. </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("InputDeviceeditordata/{InputDeviceUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.InputDeviceHardwareSpecificEditingDataBasic>> GetInputDeviceEditorData(Guid InputDeviceUid, bool includePhoto = false, int photoPixelWidth = 200)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (InputDeviceUid == Guid.Empty)
                    return BadRequest($"InputDeviceUid cannot be an empty value");

                var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetInputDeviceHardwareSpecificEditingDataAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = InputDeviceUid,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();
                var model = Mapper.Map<ApiEntities.InputDeviceHardwareSpecificEditingDataBasic>(result);
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

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>
        ///// Create a new input device.
        ///// </summary>
        ///// <remarks>   IgnoreProperties: InputDeviceGalaxyHardwareAddress, Properties, MappedEntitiesPermissionLevels, EntityIds, 
        /////             Areas, Schedules, AlertEvents, AuxiliaryOutputs, Notes, AccessGroupInputDevices, Commands, </remarks>
        ///// <param name="parameters">   Options for controlling the operation. </param>
        /////
        ///// <returns>   A Task&lt;ActionResult&lt;ApiEntities.InputDevice&gt;&gt; </returns>
        /////=================================================================================================
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<ApiEntities.InputDevice>> Post(RequestModels.SaveParams<RequestModels.InputDeviceReq> parameters)
        //{
        //    //return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot add an InputDevice using this technique. New input devices are created via the GalaxyPanel POST/PUT operations.");
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        if (parameters.Data.GalaxyInterfaceBoardSectionNodeUid == Guid.Empty)
        //            return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot add InputDevice with GalaxyInterfaceBoardSectionNodeUid value of {parameters.Data.GalaxyInterfaceBoardSectionNodeUid}");

        //        var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

        //        if (parameters.Data.AccessGroupInputDevices == null)
        //            parameters.Data.AccessGroupInputDevices = new List<RequestModels.AccessGroupInputDeviceReq>();

        //        if (parameters.Data.AlertEvents == null)
        //            parameters.Data.AlertEvents = new List<RequestModels.InputDeviceAlertEventReq>();

        //        if (parameters.Data.Areas == null)
        //            parameters.Data.Areas = new List<RequestModels.InputDeviceAreaReq>();

        //        if (parameters.Data.AuxiliaryOutputs == null)
        //            parameters.Data.AuxiliaryOutputs = new List<RequestModels.InputDeviceAuxiliaryOutputReq>();

        //        if (parameters.Data.Notes == null)
        //            parameters.Data.Notes = new List<RequestModels.NoteReq>();

        //        if (parameters.Data.Schedules == null)
        //            parameters.Data.Schedules = new List<RequestModels.InputDeviceTimeScheduleReq>();

        //        if (parameters.Data.Properties == null)
        //        {
        //            parameters.Data.Properties = new RequestModels.InputDevicePropertiesReq()
        //            {

        //            };
        //        }

        //        var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

        //        var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

        //        var wcfEntity = Mapper.Map<WcfEntities.InputDevice>(parameters.Data);
        //        wcfEntity.ConcurrencyValue = 0;

        //        var wcfParams = new WcfEntities.SaveParameters<WcfEntities.InputDevice>(wcfEntity, wcfSaveParameters);

        //        var results = await mgr.SaveInputDeviceAsync(wcfParams);
        //        if (results != null)
        //        {
        //            var savedItem = Mapper.Map<ApiEntities.InputDevice>(results);
        //            var url = LinkGenerator.GetPathByAction("Get",
        //                "InputDevice",
        //                new { InputDeviceUid = savedItem.InputDeviceUid });
        //            if (savedItem.UpdateDate > savedItem.InsertDate)
        //                return Ok(savedItem);
        //            return Created(url, savedItem);
        //        }
        //        if (mgr.HasErrors)
        //        {
        //            return BadRequest(mgr.Errors[0].ErrorMessage);
        //            //if (mgr.Errors[0].ExceptionType.Contains(typeof(GCS.Core.Common.Exceptions.DuplicateIndexException).ToString()))
        //            //     return BadRequest(mgr.Errors[0].ErrorMessage);
        //            // return this.StatusCode(StatusCodes.Status500InternalServerError, mgr.Errors[0]);
        //        }
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ResponseMessages.UnknownReason);
        //    }
        //    catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

        //        if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
        //            return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

        //        if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.AuthorizationValidationException).ToString()))
        //            return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

        //        if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
        //            return NotFound();

        //        if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.DuplicateIndexException).ToString()))
        //            return BadRequest(ex.Message);


        //        if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.DataValidationException).ToString()))
        //            return BadRequest(ex.Message);

        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //    catch (FaultException ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
        //        if (ex.Message.Contains(Support.MagicStrings.unauthorized))
        //            return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }

        //}


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Update an existing input device item.
        /// </summary>
        /// <remarks>   
        ///     IgnoreProperties: Properties, EntityIds, Areas, Schedules, AlertEvents, AuxiliaryOutputs, Notes, AccessGroupInputDevices
        ///             </remarks>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.InputDevice&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<InputDevicePutReq>> Put(RequestModels.SaveParams<RequestModels.InputDevicePutReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (parameters.Data.InputDeviceUid == Guid.Empty)
                    return BadRequest($"Cannot update InputDevice without a valid InputDeviceUid value");

                //if (parameters.Data.GalaxyHardwareAddress == null || parameters.Data.GalaxyHardwareAddress.GalaxyInterfaceBoardSectionNodeUid == Guid.Empty)
                //    return BadRequest($"Cannot update InputDevice without a GalaxyHardwareAddress.GalaxyInterfaceBoardSectionNodeUid value");

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var id = await mgr.GetInputDeviceAsync(new WcfEntities.GetParametersWithPhoto() { UniqueId = parameters.Data.InputDeviceUid, IncludeMemberCollections = false, IncludePhoto = parameters.SavePhoto });
                if (id == null)
                {
                    return NotFound($"Cannot PUT (save) InputDevice with InputDeviceUid value {parameters.Data.InputDeviceUid} because it does not exist.");
                }

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.InputDevice>(parameters.Data);
   
                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.InputDevice>(wcfEntity, wcfSaveParameters);

                // If savePhoto is true, compare incoming photo image data with that from DB. If different, mark IsModified as true
                if (parameters.SavePhoto)
                {
                    // If some photo data has been provided
                    if (parameters.Data.PhotoImage != null && parameters.Data.PhotoImage.Length > 0)
                    {
                        wcfEntity.gcsBinaryResource = id.gcsBinaryResource;
                        if (wcfEntity.gcsBinaryResource == null)
                        {
                            wcfEntity.gcsBinaryResource = new WcfEntities.gcsBinaryResource();
                            if (wcfEntity.BinaryResourceUid != null)
                                wcfEntity.gcsBinaryResource.BinaryResourceUid = wcfEntity.BinaryResourceUid.Value;
                        }
                        wcfEntity.BinaryResourceUid = wcfEntity.gcsBinaryResource.BinaryResourceUid;
                        if (!GCS.Core.Common.Shared.Utils.ObjectComparer.AreByteArraysEqual(wcfEntity.gcsBinaryResource.BinaryResource, parameters.Data.PhotoImage))
                        {
                            wcfEntity.gcsBinaryResource.BinaryResource = parameters.Data.PhotoImage;
                            wcfEntity.gcsBinaryResource.HasBeenModified = true;
                        }
                    }
                    else
                    {   // No photo has been provided. that means delete any existing photo
                        wcfEntity.gcsBinaryResource = null;
                    }
                }

                var results = await mgr.SaveInputDeviceAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var savedItem = Mapper.Map<InputDevicePutReq>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "InputDevice",
                        new { InputDeviceUid = savedItem.InputDeviceUid });
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
        /// Delete a specific input device by InputDeviceUid.
        /// </summary>
        ///
        /// <param name="InputDeviceUid"> Identifier for the input device to delete. </param>
        ///
        /// <returns>   A Task&lt;IActionResult&gt; </returns>
        ///=================================================================================================        
        [HttpDelete("{InputDeviceUid}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid InputDeviceUid)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetInputDeviceAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = InputDeviceUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = false
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                var x = await mgr.DeleteInputDeviceByUniqueIdAsync(new WcfEntities.DeleteParameters() { UniqueId = InputDeviceUid });

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
        /// Send a command to one or more input devices.
        /// </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;IActionResult&gt; </returns>
        ///=================================================================================================

        [HttpPost("sendcommand")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> ExecuteCommand(RequestModels.CommandParams<RequestModels.InputDeviceCommandActionReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                switch (parameters.Data.CommandAction)
                {
                    case InputDeviceCommandActionCode.Shunt:
                    case InputDeviceCommandActionCode.Unshunt:
                    case InputDeviceCommandActionCode.Enable:
                    case InputDeviceCommandActionCode.Disable:
                    case InputDeviceCommandActionCode.ReadVoltages:
                    case InputDeviceCommandActionCode.RequestStatus:
                        break;

                    case InputDeviceCommandActionCode.None:
                    default:
                        return BadRequest($"Invalid CommandAction value");
                }

                if (parameters.Data.InputDeviceUid == Guid.Empty)
                    return BadRequest($"Invalid InputDeviceUid value");

                var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var wcfParams = Mapper.Map<WcfEntities.CommandParameters<WcfEntities.InputDeviceCommandAction>>(parameters);
                var result = await mgr.ExecuteCommandAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                return Ok(result);
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
        /// <summary> Gets activity history. </summary>
        ///
        /// <remarks>   Kevin, 2/4/2022. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The activity history. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //        [HttpPost("activityhistory")]
        [HttpGet("activityhistory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.ActivityHistoryEvent>>> GetActivityHistory([FromQuery] RequestModels.InputDeviceActivityHistoryEventSearchParametersReq parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<InputDeviceManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetActivityHistoryEventsAsync(Mapper.Map<WcfEntities.ActivityHistoryEventSearchParameters>(parameters));

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.ActivityHistoryEvent>>(results);
                return Ok(resp);
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
