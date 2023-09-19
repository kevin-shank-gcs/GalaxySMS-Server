extern alias NetCoreCommon;
using AutoMapper;
using GalaxySMS.Api.Models.RequestModels;
using GalaxySMS.Api.Support;
using GalaxySMS.Client.SDK.Helpers;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using RequestModels = GalaxySMS.Api.Models.RequestModels;
using ResponseModels = GalaxySMS.Api.Models.ResponseModels;
using WcfEntities = GalaxySMS.Business.Entities;
using System.Drawing.Drawing2D;

namespace GalaxySMS.Api.Controllers.Api
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Operations relating to access portals. </summary>
    ///<remarks>  </remarks>
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================
    //[ApiExplorerSettings(IgnoreApi = true)]

    [Route("api/[controller]")]
    //    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]  // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    [ApiVersion("1.0")]
    //    [ApiVersion("1.1")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccessPortalController : ControllerBaseEx
    {
        public AccessPortalController(IConfiguration config,
            IMapper mapper,
            ILogger<AccessPortalController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper, logger, linkGenerator, cache, distributedCache)
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get a collection access portals. </summary>
        /// 
        /// <remarks>   Kevin, 6/10/2021. </remarks>
        /// 
        /// <param name="entityId">     (Optional) The unique ID of the entity to request access portals for. If not specified, access portals for current entity will be requested. </param>
        /// <param name="searchText"> (Optional) Specifies text to search for in the name and optionally the comments and location properties.</param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includeCommands"> (Optional) True indicates DisabledCommandIds should be populated</param>
        /// <param name="searchCommentsAndLocation"> (Optional) If search text is specified, True will also search comments and location properties for specified text.</param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        /// 
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.AccessPortalMinimal&gt;&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.AccessPortalMinimal>>> Get(Guid entityId, string searchText, int pageSize, int pageNumber, /*bool includeChildren = false, bool includePhoto = false, int photoPixelWidth = 200,*/ bool includeCommands = false, bool searchCommentsAndLocation = false, AccessPortalSortProperty sortBy = AccessPortalSortProperty.PortalName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<AccessPortalManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                WcfEntities.ArrayResponse<WcfEntities.AccessPortal> results = null;
                var parameters = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = entityId,
                    IncludePhoto = false,// includePhoto,
                    //PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = false,//includeChildren,
                    IncludeCommands = includeCommands,
                    GetString = searchText,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                };
                if (string.IsNullOrEmpty(searchText))
                {
                    results = await mgr.GetAllAccessPortalsForEntityAsync(parameters);
                }
                else
                {
                    if (searchCommentsAndLocation)
                        parameters.AddOption(GetOptions_AccessPortal.SearchIncludesComments, searchCommentsAndLocation);

                    results = await mgr.GetAccessPortalsByTextSearchAsync(parameters);
                }

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.AccessPortalMinimal>>(results);
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
        /// Gets a list of access portals.
        /// </summary>
        ///
        /// <remarks>   Kevin, 2/8/2022. </remarks>
        ///
        /// <param name="entityId">                     The unique ID of the entity to request access
        ///                                             portals for. If not specified, access portals for
        ///                                             current entity will be requested. </param>
        /// <param name="searchText">                   Specifies text to search for in the name and
        ///                                             optionally the comments and location properties. </param>
        /// <param name="pageSize">                     Size of the page. 0 = no paging. </param>
        /// <param name="pageNumber">                   The page number. </param>
        /// <param name="includePhoto">                 (Optional) </param>
        /// <param name="photoPixelWidth">              (Optional) </param>
        /// <param name="includeCommands">              (Optional) True indicates DisabledCommandIds should be populated</param>
        /// <param name="searchCommentsAndLocation">    (Optional) If search text is specified, True will
        ///                                             also search comments and location properties for
        ///                                             specified text. </param>
        /// <param name="sortBy">                       (Optional) The property to sort the results by. </param>
        /// <param name="orderBy">                      (Optional) Specifies if the results should be
        ///                                             returned in ascending or descending order. </param>
        ///
        /// <returns>   The list. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.AccessPortalListItemCommands>>> GetList(Guid entityId, string searchText, int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, bool searchCommentsAndLocation = false, AccessPortalSortProperty sortBy = AccessPortalSortProperty.PortalName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<AccessPortalManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                WcfEntities.ArrayResponse<WcfEntities.AccessPortalListItemCommands> results = null;
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
                    results = await mgr.GetAllAccessPortalsListForEntityAsync(parameters);
                }
                else
                {
                    if (searchCommentsAndLocation)
                        parameters.AddOption(GetOptions_AccessPortal.SearchIncludesComments, searchCommentsAndLocation);

                    results = await mgr.GetAccessPortalsListByTextSearchAsync(parameters);
                }

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.AccessPortalListItemCommands>>(results);
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
        /// Get all access portals for a site.
        /// </summary>
        ///
        /// <param name="siteUid">  The site UID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includeCommands"> (Optional) True indicates DisabledCommandIds should be populated</param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   The list for site. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.AccessPortalMinimal>>> GetAccessPortalsForSite(Guid siteUid, int pageSize, int pageNumber, /*bool includePhoto = false, int photoPixelWidth = 200, */bool includeCommands = false, AccessPortalSortProperty sortBy = AccessPortalSortProperty.PortalName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<AccessPortalManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetAccessPortalsForSiteAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = siteUid,
                    IncludePhoto = false,//includePhoto,
                    //PhotoPixelWidth = photoPixelWidth,
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

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.AccessPortalMinimal>>(results);
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
        /// Get list of all access portals for a site.
        /// </summary>
        ///
        /// <param name="siteUid">  The site UID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includePhoto"></param>
        /// <param name="photoPixelWidth"></param>
        /// <param name="includeCommands"> (Optional) True indicates DisabledCommandIds should be populated</param>
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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.AccessPortalListItemCommands>>> GetAccessPortalsListForSite(Guid siteUid, int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, AccessPortalSortProperty sortBy = AccessPortalSortProperty.PortalName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<AccessPortalManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetAccessPortalsListForSiteAsync(new WcfEntities.GetParametersWithPhoto()
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

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.AccessPortalListItemCommands>>(results);
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
        /// Get all access portals for a cluster.
        /// </summary>
        ///
        /// <param name="clusterUid">  The cluster UID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includeCommands"> (Optional) True indicates DisabledCommandIds should be populated</param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   The access portals for cluster. </returns>
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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.AccessPortalMinimal>>> GetAccessPortalsForCluster(Guid clusterUid, int pageSize, int pageNumber, /*bool includePhoto = false, int photoPixelWidth = 200, */ bool includeCommands = false, AccessPortalSortProperty sortBy = AccessPortalSortProperty.PortalName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<AccessPortalManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetAccessPortalsForClusterAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = clusterUid,
                    IncludePhoto = false,// includePhoto,
                    //PhotoPixelWidth = photoPixelWidth,
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

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.AccessPortalMinimal>>(results);
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
        /// Get list of all access portals for a cluster.
        /// </summary>
        ///
        /// <param name="clusterUid">  The cluster UID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includePhoto"></param>
        /// <param name="photoPixelWidth"></param>
        /// <param name="includeCommands"> (Optional) True indicates DisabledCommandIds should be populated</param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   The access portals for cluster. </returns>
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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.AccessPortalListItemCommands>>> GetAccessPortalsListForCluster(Guid clusterUid, int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, AccessPortalSortProperty sortBy = AccessPortalSortProperty.PortalName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<AccessPortalManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetAccessPortalsListForClusterAsync(new WcfEntities.GetParametersWithPhoto()
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

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.AccessPortalListItemCommands>>(results);
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
        /// Get all access portals for a region.
        /// </summary>
        ///
        /// <param name="regionUid">  The region UID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includeCommands"> (Optional) True indicates DisabledCommandIds should be populated</param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   The access portals for region. </returns>
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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.AccessPortalMinimal>>> GetAccessPortalsForRegion(Guid regionUid, int pageSize, int pageNumber, /*bool includePhoto = false, int photoPixelWidth = 200, */ bool includeCommands = false, AccessPortalSortProperty sortBy = AccessPortalSortProperty.PortalName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<AccessPortalManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetAccessPortalsForRegionAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = regionUid,
                    IncludePhoto = false,//includePhoto,
                 //   PhotoPixelWidth = photoPixelWidth,
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

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.AccessPortalMinimal>>(results);
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
        /// Get list of all access portals for a region.
        /// </summary>
        ///
        /// <param name="regionUid">  The region UID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includePhoto"></param>
        /// <param name="photoPixelWidth"></param>
        /// <param name="includeCommands"> (Optional) True indicates DisabledCommandIds should be populated</param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   The access portals for region. </returns>
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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.AccessPortalListItemCommands>>> GetAccessPortalsListForRegion(Guid regionUid, int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, AccessPortalSortProperty sortBy = AccessPortalSortProperty.PortalName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<AccessPortalManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetAccessPortalsListForRegionAsync(new WcfEntities.GetParametersWithPhoto()
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

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.AccessPortalListItemCommands>>(results);
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
        /// Get all access portals for a galaxy panel.
        /// </summary>
        ///
        /// <param name="galaxyPanelUid">  The panel UID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includeCommands"> (Optional) True indicates DisabledCommandIds should be populated</param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   The access portals for a specific panel. </returns>
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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.AccessPortalMinimal>>> GetAccessPortalsForGalaxyPanel(Guid galaxyPanelUid, int pageSize, int pageNumber, /*bool includePhoto = false, int photoPixelWidth = 200, */bool includeCommands = false, AccessPortalSortProperty sortBy = AccessPortalSortProperty.PortalName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<AccessPortalManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetAccessPortalsForGalaxyPanelAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = galaxyPanelUid,
                    IncludePhoto = false,//includePhoto,
               //     PhotoPixelWidth = photoPixelWidth,
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

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.AccessPortalMinimal>>(results);
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
        /// Get list of all access portals for a galaxy panel.
        /// </summary>
        ///
        /// <param name="galaxyPanelUid">  The panel UID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includePhoto"></param>
        /// <param name="photoPixelWidth"></param>
        /// <param name="includeCommands"> (Optional) True indicates DisabledCommandIds should be populated</param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   The access portals for a specific panel. </returns>
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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.AccessPortalListItemCommands>>> GetAccessPortalsListForGalaxyPanel(Guid galaxyPanelUid, int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, AccessPortalSortProperty sortBy = AccessPortalSortProperty.PortalName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<AccessPortalManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetAccessPortalsListForGalaxyPanelAsync(new WcfEntities.GetParametersWithPhoto()
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

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.AccessPortalListItemCommands>>(results);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get a access portal by AccessPortalUid value. </summary>
        /// 
        /// <param name="accessPortalUid">   The access portal UID. </param>
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        /// <param name="includePhoto">  (Optional) True to include, false to exclude the photo. </param>
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.AccessPortal&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{accessPortalUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<AccessPortalPutReq>> Get(Guid accessPortalUid, bool includeChildren = false, bool includePhoto = false)
        {
            try
            {
                var getForPut = true;
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<AccessPortalManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = accessPortalUid,
                    IncludePhoto = includePhoto,
                    IncludeMemberCollections = includeChildren,
                    IncludeHardwareAddress = true
                };

                //wcfGetParams.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(WcfEntities.Cluster.GalaxyPanels), true));
                //wcfGetParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.Cluster.GalaxyPanels));
                var result = await mgr.GetAccessPortalAsync(wcfGetParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                var putResult = Mapper.Map<RequestModels.AccessPortalPutReq>(result);
                putResult.PhotoImage = result.gcsBinaryResource?.BinaryResource;

                foreach (var ae in putResult.AlertEvents)
                {
                    if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.AccessGranted)
                        ae.AlertEventType = AccessPortalAlertEventType.AccessGranted;
                    else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup1)
                        ae.AlertEventType = AccessPortalAlertEventType.AccessGrantedDisarmInputOutputGroup1;
                    else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup2)
                        ae.AlertEventType = AccessPortalAlertEventType.AccessGrantedDisarmInputOutputGroup2;
                    else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup3)
                        ae.AlertEventType = AccessPortalAlertEventType.AccessGrantedDisarmInputOutputGroup3;
                    else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup4)
                        ae.AlertEventType = AccessPortalAlertEventType.AccessGrantedDisarmInputOutputGroup4;
                    else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.DoorGroup)
                        ae.AlertEventType = AccessPortalAlertEventType.DoorGroup;
                    else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.DuressAuxiliaryFunction)
                        ae.AlertEventType = AccessPortalAlertEventType.Duress;
                    else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.ForcedOpen)
                        ae.AlertEventType = AccessPortalAlertEventType.ForcedOpen;
                    else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.InvalidAccessAttempt)
                        ae.AlertEventType = AccessPortalAlertEventType.InvalidAccessAttempt;
                    else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.LockedBy)
                        ae.AlertEventType = AccessPortalAlertEventType.LockedBy;
                    else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.OpenTooLong)
                        ae.AlertEventType = AccessPortalAlertEventType.OpenTooLong;
                    else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.PassbackViolation)
                        ae.AlertEventType = AccessPortalAlertEventType.PassbackViolation;
                    else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.ReaderHeartbeat)
                        ae.AlertEventType = AccessPortalAlertEventType.ReaderHeartbeat;
                    else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.UnlockedBy)
                        ae.AlertEventType = AccessPortalAlertEventType.UnlockedBy;

                    var fullAe = result.AlertEvents.FirstOrDefault(o =>
                        o.AccessPortalAlertEventTypeUid == ae.AccessPortalAlertEventTypeUid);
                    if (fullAe?.Note != null)
                        ae.UserInstructions = fullAe.Note.NoteText;


                }
                return Ok(putResult);

                var model = Mapper.Map<ResponseModels.AccessPortalResp>(result);
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
        /// Get Access Portal Galaxy common editor data.
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

        public async Task<ActionResult<ApiEntities.AccessPortalGalaxyCommonEditingDataBasic>> GetGalaxyCommonEditorData(string includeProperties)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);


                var wcfParameters = new WcfEntities.GetParametersWithPhoto()
                {
                };

                if (!string.IsNullOrEmpty(includeProperties))
                {
                    var includeProps = includeProperties.Split(',');

                    var responseProperties =
                        typeof(WcfEntities.AccessPortalGalaxyCommonEditingData).GetComplexProperties().ToList();
                    foreach (var p in responseProperties)
                    {
                        var included = includeProps.FirstOrDefault(o => o.TrimStart().TrimEnd().ToLower() == p.Name.ToLower());
                        if (included == null)
                            wcfParameters.ExcludeMemberCollectionSettings.Add(p.Name);
                    }
                }

                var mgr = Helpers.GetManager<AccessPortalManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetAccessPortalGalaxyCommonEditingDataAsync(wcfParameters);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();
                var model = Mapper.Map<ApiEntities.AccessPortalGalaxyCommonEditingDataBasic>(result);
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
        /// Get editor data for a specific access portal.
        /// </summary>
        /// <param name="accessPortalUid">  The access portal UID. </param>
        /// <param name="includePhoto"></param>
        /// <param name="photoPixelWidth"></param>
        /// <returns>   The editor data. </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("accessportaleditordata/{accessPortalUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.AccessPortalGalaxyPanelSpecificEditingDataBasic>> GetAccessPortalEditorData(Guid accessPortalUid, string includeProperties, bool includePhoto = true, int photoPixelWidth = 200)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (accessPortalUid == Guid.Empty)
                    return BadRequest($"accessPortalUid cannot be an empty value");

                var wcfParameters = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = accessPortalUid,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth
                };

                if (!string.IsNullOrEmpty(includeProperties))
                {
                    var includeProps = includeProperties.Split(',');

                    var responseProperties =
                        typeof(WcfEntities.AccessPortalGalaxyPanelSpecificEditingData).GetComplexProperties().ToList();
                    foreach (var p in responseProperties)
                    {
                        var included = includeProps.FirstOrDefault(o => o.TrimStart().TrimEnd().ToLower() == p.Name.ToLower());
                        if (included == null)
                            wcfParameters.ExcludeMemberCollectionSettings.Add(p.Name);
                    }
                }

                var mgr = Helpers.GetManager<AccessPortalManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetAccessPortalGalaxyPanelSpecificEditingDataAsync(wcfParameters);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();
                var model = Mapper.Map<ApiEntities.AccessPortalGalaxyPanelSpecificEditingDataBasic>(result);
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
        ///// Create a new access portal.
        ///// </summary>
        ///// <remarks>   IgnoreProperties: AccessPortalGalaxyHardwareAddress, Properties, MappedEntitiesPermissionLevels, EntityIds, 
        /////             Areas, Schedules, AlertEvents, AuxiliaryOutputs, Notes, AccessGroupAccessPortals, Commands, </remarks>
        ///// <param name="parameters">   Options for controlling the operation. </param>
        /////
        ///// <returns>   A Task&lt;ActionResult&lt;ApiEntities.AccessPortal&gt;&gt; </returns>
        /////=================================================================================================
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<ApiEntities.AccessPortal>> Post(RequestModels.SaveParams<RequestModels.AccessPortalReq> parameters)
        //{
        //    //return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot add an AccessPortal using this technique. New Access Portals are created via the GalaxyPanel POST/PUT operations.");
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        if (parameters.Data.GalaxyInterfaceBoardSectionNodeUid == Guid.Empty)
        //            return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot add AccessPortal with GalaxyInterfaceBoardSectionNodeUid value of {parameters.Data.GalaxyInterfaceBoardSectionNodeUid}");

        //        var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

        //        if (parameters.Data.AccessGroupAccessPortals == null)
        //            parameters.Data.AccessGroupAccessPortals = new List<RequestModels.AccessGroupAccessPortalReq>();

        //        if (parameters.Data.AlertEvents == null)
        //            parameters.Data.AlertEvents = new List<RequestModels.AccessPortalAlertEventReq>();

        //        if (parameters.Data.Areas == null)
        //            parameters.Data.Areas = new List<RequestModels.AccessPortalAreaReq>();

        //        if (parameters.Data.AuxiliaryOutputs == null)
        //            parameters.Data.AuxiliaryOutputs = new List<RequestModels.AccessPortalAuxiliaryOutputReq>();

        //        if (parameters.Data.Notes == null)
        //            parameters.Data.Notes = new List<RequestModels.NoteReq>();

        //        if (parameters.Data.Schedules == null)
        //            parameters.Data.Schedules = new List<RequestModels.AccessPortalTimeScheduleReq>();

        //        if (parameters.Data.Properties == null)
        //        {
        //            parameters.Data.Properties = new RequestModels.AccessPortalPropertiesReq()
        //            {

        //            };
        //        }

        //        var mgr = Helpers.GetManager<AccessPortalManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

        //        var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

        //        var wcfEntity = Mapper.Map<WcfEntities.AccessPortal>(parameters.Data);
        //        wcfEntity.ConcurrencyValue = 0;

        //        var wcfParams = new WcfEntities.SaveParameters<WcfEntities.AccessPortal>(wcfEntity, wcfSaveParameters);

        //        var results = await mgr.SaveAccessPortalAsync(wcfParams);
        //        if (results != null)
        //        {
        //            var savedItem = Mapper.Map<ApiEntities.AccessPortal>(results);
        //            var url = LinkGenerator.GetPathByAction("Get",
        //                "AccessPortal",
        //                new { accessPortalUid = savedItem.AccessPortalUid });
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
        /// Update an existing access portal item.
        /// </summary>
        /// <remarks>   
        ///     IgnoreProperties: Properties, EntityIds, Areas, Schedules, AlertEvents, AuxiliaryOutputs, Notes, AccessGroupAccessPortals
        ///             </remarks>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.AccessPortal&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<AccessPortalPutReq>> Put(RequestModels.SaveParams<RequestModels.AccessPortalPutReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (parameters.Data.AccessPortalUid == Guid.Empty)
                    return BadRequest($"Cannot update AccessPortal without a valid AccessPortalUid value");

                //if (parameters.Data.GalaxyHardwareAddress == null || parameters.Data.GalaxyHardwareAddress.GalaxyInterfaceBoardSectionNodeUid == Guid.Empty)
                //    return BadRequest($"Cannot update AccessPortal without a GalaxyHardwareAddress.GalaxyInterfaceBoardSectionNodeUid value");

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgr = Helpers.GetManager<AccessPortalManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var ap = await mgr.GetAccessPortalAsync(new WcfEntities.GetParametersWithPhoto() { UniqueId = parameters.Data.AccessPortalUid, IncludeMemberCollections = false, IncludePhoto = false });
                if (ap == null)
                {
                    return NotFound($"Cannot PUT (save) AccessPortal with AccessPortalUid value {parameters.Data.AccessPortalUid} because it does not exist.");
                }

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);
                if (parameters.Data?.AlertEvents == null || parameters.Data?.AlertEvents?.Count == 0)
                    wcfSaveParameters.IgnoreProperties.Add(nameof(parameters.Data.AlertEvents));
                else
                {
                    //var commonEditorData =
                    //    await GetCommonEditingDataBasic(
                    //        $"{nameof(WcfEntities.AccessPortalGalaxyCommonEditingData.AlertEventTypes)}");

                    //var validationProblemDetails = await ValidateAlertEventProperties(parameters.Data.AlertEvents, commonEditorData);
                    //if (validationProblemDetails != null)
                    //    return ValidationProblem(validationProblemDetails);
                }

                var wcfEntity = Mapper.Map<WcfEntities.AccessPortal>(parameters.Data);

                if (parameters.Data.AlertEvents != null)
                {
                    var x = 0;
                    foreach (var ae in parameters.Data.AlertEvents)
                    {
                        if (!string.IsNullOrEmpty(ae.UserInstructions))
                        {
                            var wcfAe = wcfEntity.AlertEvents.FirstOrDefault(o =>
                                o.AccessPortalAlertEventTypeUid == ae.AccessPortalAlertEventTypeUid);
                            if (wcfAe != null)
                            {
                                wcfAe.Note = new WcfEntities.Note()
                                {
                                    NoteText = ae.UserInstructions,
                                    IsDirty = true
                                };
                            }
                        }

                        x++;
                    }

                }

                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.AccessPortal>(wcfEntity, wcfSaveParameters);
                var validationProblems = await mgr.ValidateAccessPortalAsync(wcfParams);
                if (validationProblems != null)
                {
                    if (validationProblems is { IsValid: false })
                    {
                        return ValidationProblem(new ValidationProblemDetails(validationProblems.Errors));
                    }
                }

                // If savePhoto is true, compare incoming photo image data with that from DB. If different, mark IsModified as true
                if (parameters.SavePhoto)
                {
                    // If some photo data has been provided
                    if (parameters.Data.PhotoImage != null && parameters.Data.PhotoImage.Length > 0)
                    {
                        wcfEntity.gcsBinaryResource = ap.gcsBinaryResource;
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

                var results = await mgr.SaveAccessPortalAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var savedItem = Mapper.Map<AccessPortalPutReq>(results);
                    //foreach (var ae in results.AlertEvents)
                    //{
                    //    var ae1 = savedItem.AlertEvents.FirstOrDefault(o =>
                    //        o.AccessPortalAlertEventTypeUid == ae.AccessPortalAlertEventTypeUid);
                    //    if (ae1 != null)
                    //    {
                    //        ae1.UserInstructions = ae.Note?.NoteText;
                    //    }
                    //}
                    savedItem.PhotoImage = results.gcsBinaryResource?.BinaryResource;

                    foreach (var ae in savedItem.AlertEvents)
                    {
                        if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.AccessGranted)
                            ae.AlertEventType = AccessPortalAlertEventType.AccessGranted;
                        else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup1)
                            ae.AlertEventType = AccessPortalAlertEventType.AccessGrantedDisarmInputOutputGroup1;
                        else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup2)
                            ae.AlertEventType = AccessPortalAlertEventType.AccessGrantedDisarmInputOutputGroup2;
                        else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup3)
                            ae.AlertEventType = AccessPortalAlertEventType.AccessGrantedDisarmInputOutputGroup3;
                        else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.AccessGrantedDisarmInputOutputGroup4)
                            ae.AlertEventType = AccessPortalAlertEventType.AccessGrantedDisarmInputOutputGroup4;
                        else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.DoorGroup)
                            ae.AlertEventType = AccessPortalAlertEventType.DoorGroup;
                        else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.DuressAuxiliaryFunction)
                            ae.AlertEventType = AccessPortalAlertEventType.Duress;
                        else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.ForcedOpen)
                            ae.AlertEventType = AccessPortalAlertEventType.ForcedOpen;
                        else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.InvalidAccessAttempt)
                            ae.AlertEventType = AccessPortalAlertEventType.InvalidAccessAttempt;
                        else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.LockedBy)
                            ae.AlertEventType = AccessPortalAlertEventType.LockedBy;
                        else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.OpenTooLong)
                            ae.AlertEventType = AccessPortalAlertEventType.OpenTooLong;
                        else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.PassbackViolation)
                            ae.AlertEventType = AccessPortalAlertEventType.PassbackViolation;
                        else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.ReaderHeartbeat)
                            ae.AlertEventType = AccessPortalAlertEventType.ReaderHeartbeat;
                        else if (ae.AccessPortalAlertEventTypeUid == AccessPortalAlertEventTypeIds.UnlockedBy)
                            ae.AlertEventType = AccessPortalAlertEventType.UnlockedBy;

                        var fullAe = results.AlertEvents.FirstOrDefault(o =>
                            o.AccessPortalAlertEventTypeUid == ae.AccessPortalAlertEventTypeUid);
                        if (fullAe?.Note != null)
                            ae.UserInstructions = fullAe.Note.NoteText;
                    }

                    var url = LinkGenerator.GetPathByAction("Get",
                        "AccessPortal",
                        new { accessPortalUid = savedItem.AccessPortalUid });
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

        private async Task<ApiEntities.AccessPortalGalaxyCommonEditingDataBasic> GetCommonEditingDataBasic(string includeProperties)
        {
            var mgr = Helpers.GetManager<AccessPortalManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

            var wcfParameters = new WcfEntities.GetParametersWithPhoto()
            {
                UniqueId = Guid.Empty,
                IncludeMemberCollections = true,
                //                   IncludePhoto = true
            };

            if (!string.IsNullOrEmpty(includeProperties))
            {
                var includeProps = includeProperties.Split(',');

                var responseProperties =
                    typeof(WcfEntities.AccessPortalGalaxyCommonEditingData).GetComplexProperties().ToList();
                foreach (var p in responseProperties)
                {
                    var included = includeProps.FirstOrDefault(o => o.TrimStart().TrimEnd().ToLower() == p.Name.ToLower());
                    if (included == null)
                        wcfParameters.ExcludeMemberCollectionSettings.Add(p.Name);
                }
            }

            var result = await mgr.GetAccessPortalGalaxyCommonEditingDataAsync(wcfParameters);

            if (mgr.HasErrors)
            {
                return null;
            }
            var model = ConvertToAccessPortalGalaxyCommonEditingDataBasic(result);
            return model;
        }

        private ApiEntities.AccessPortalGalaxyCommonEditingDataBasic ConvertToAccessPortalGalaxyCommonEditingDataBasic(WcfEntities.AccessPortalGalaxyCommonEditingData result)
        {
            var model = Mapper.Map<ApiEntities.AccessPortalGalaxyCommonEditingDataBasic>(result);
            return model;
        }


        private async Task<ValidationProblemDetails> ValidateAlertEventProperties(IEnumerable<AccessPortalAlertEventPutReq> events, ApiEntities.AccessPortalGalaxyCommonEditingDataBasic editorData)
        {
            var validationProblems = new Dictionary<string, string[]>();
            var errorsArray = new List<string>();
            var index = 0;
            foreach (var ev in events)
            {
                if (ev.AccessPortalAlertEventTypeUid == Guid.Empty)
                {
                    errorsArray.Add($"AlertEvents[{index}].AccessPortalAlertEventTypeUid is missing or contains an empty value.");
                }
                else
                {
                    if (editorData.AlertEventTypes.FirstOrDefault(o =>
                            o.AccessPortalAlertEventTypeUid == ev.AccessPortalAlertEventTypeUid) == null)
                        errorsArray.Add($"AlertEvents[{index}].AccessPortalAlertEventTypeUid contains an invalid value.");

                    var dupCount = events.Count(o => o.AccessPortalAlertEventTypeUid == ev.AccessPortalAlertEventTypeUid);
                    if (dupCount > 1)
                    {
                        errorsArray.Add($"AlertEvents[{index}] - There are [{dupCount}] duplicate AlertEvent items with AccessPortalAlertEventTypeUid value {ev.AccessPortalAlertEventTypeUid}. Only one item for each value be specified.");
                    }
                }

                index++;
            }

            if (errorsArray.Any())
            {
                validationProblems.Add($"AlertEvents", errorsArray.ToArray());
                return new ValidationProblemDetails(validationProblems);
            }

            return null;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Delete a specific access portal by accessPortalUid.
        /// </summary>
        ///
        /// <param name="accessPortalUid"> Identifier for the Access Portal to delete. </param>
        ///
        /// <returns>   A Task&lt;IActionResult&gt; </returns>
        ///=================================================================================================        
        [HttpDelete("{accessPortalUid}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid accessPortalUid)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<AccessPortalManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetAccessPortalAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = accessPortalUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = false
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                var x = await mgr.DeleteAccessPortalByUniqueIdAsync(new WcfEntities.DeleteParameters() { UniqueId = accessPortalUid });

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
        /// Send a command to one or more access portals.
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

        public async Task<IActionResult> ExecuteCommand(RequestModels.CommandParams<RequestModels.AccessPortalCommandActionReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                switch (parameters.Data.CommandAction)
                {
                    case AccessPortalCommandActionCode.Pulse:
                    case AccessPortalCommandActionCode.Unlock:
                    case AccessPortalCommandActionCode.Lock:
                    case AccessPortalCommandActionCode.Enable:
                    case AccessPortalCommandActionCode.Disable:
                    case AccessPortalCommandActionCode.AuxRelayOn:
                    case AccessPortalCommandActionCode.AuxRelayOff:
                    case AccessPortalCommandActionCode.SetLedTemporaryState:
                    case AccessPortalCommandActionCode.RequestStatus:
                        break;

                    case AccessPortalCommandActionCode.None:
                    default:
                        return BadRequest($"Invalid CommandAction value");
                }

                if (parameters.Data.AccessPortalUid == Guid.Empty)
                    return BadRequest($"Invalid AccessPortalUid value");

                var mgr = Helpers.GetManager<AccessPortalManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var wcfParams = Mapper.Map<WcfEntities.CommandParameters<WcfEntities.AccessPortalCommandAction>>(parameters);
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
        //        public async Task<ActionResult<ApiEntities.ActivityHistoryEvent[]>> GetActivityHistory([FromBody] RequestModels.AccessPortalActivityHistoryEventSearchParametersReq parameters)

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.ActivityHistoryEvent>>> GetActivityHistory([FromQuery] RequestModels.AccessPortalActivityHistoryEventSearchParametersReq parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<AccessPortalManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
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
