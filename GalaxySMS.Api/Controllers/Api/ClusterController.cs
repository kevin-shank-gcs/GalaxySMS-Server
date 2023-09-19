extern alias NetCoreCommon;
using AutoMapper;
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
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using RequestModels = GalaxySMS.Api.Models.RequestModels;
using ResponseModels = GalaxySMS.Api.Models.ResponseModels;
using WcfEntities = GalaxySMS.Business.Entities;
using GalaxySMS.Api.Models.RequestModels;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.Json;
using GalaxySMS.Business.Entities.Api.NetCore.Response;

namespace GalaxySMS.Api.Controllers.Api
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Operations relating to Clusters. </summary>
    ///<remarks>  </remarks>
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================

    [Route("api/[controller]")]
    [ApiController]  // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClusterController : ControllerBaseEx
    {
        public ClusterController(IConfiguration config,
            IMapper mapper,
            ILogger<ClusterController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper, logger, linkGenerator, cache, distributedCache)
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary>   Get all clusters for an entity. </summary>
        /// 
        ///  <param name="entityId">     (Optional) The unique ID of the entity to request clusters for. If not specified, clusters for current entity will be requested. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        ///  <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        ///  <param name="photoPixelWidth">  (Optional) Width of the photo pixel. </param>
        ///  <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        ///  <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by (ClusterName, InsertDate, UpdateDate)</param>
        ///  <param name="orderBy">      (Optional) Specifies if the results should be returned in ascending (asc, default) or descending (desc) order.</param>
        ///  <returns>   A Task&lt;ActionResult&lt;ApiEntities.ClusterBasic[]&gt;&gt; </returns>
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
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.ClusterBasic>>> Get(Guid entityId, int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeChildren = false, bool includeCommands = false, ClusterSortProperty sortBy = ClusterSortProperty.ClusterName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<ClusterManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetAllClustersForEntityAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = entityId,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = includeChildren,
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

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.ClusterBasic>>(results);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary>   Get a list of Clusters for an entity. </summary>
        /// 
        ///  <param name="entityId">     (Optional) The unique ID of the entity to request clusters for. If not specified, clusters for current entity will be requested. </param>
        ///  <param name="pageSize">     Size of the page. 0 = no paging</param>
        ///  <param name="pageNumber">   The page number. </param>
        ///  <param name="includePhoto">     (Optional) True to include photo, false to exclude the photo. </param>
        ///  <param name="photoPixelWidth">  (Optional) Width of the photo pixel. </param>
        ///  <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        ///  <param name="includeCounts"> (Optional) True to only include counts of data elements in the response. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by (ClusterName, InsertDate, UpdateDate)</param>
        ///   <param name="orderBy">      (Optional) Specifies if the results should be returned in ascending (asc, default) or descending (desc) order.</param>
        /// 
        ///  <returns>   The list. </returns>
        /// =================================================================================================
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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.ClusterListItemCommands>>> GetList(Guid entityId, int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, bool includeCounts = false, ClusterSortProperty sortBy = ClusterSortProperty.ClusterName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<ClusterManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var parameters = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = entityId,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = false,
                    IncludeCommands = includeCommands,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                };

                if (includeCounts)
                    parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeCounts, includeCounts));

                var results = await mgr.GetAllClustersForEntityListAsync(parameters);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.ClusterListItemCommands>>(results);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get a list of Clusters for a site. </summary>
        ///
        /// <param name="siteUid">          The Guid (uuid) value that identifies the site. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includePhoto">     (Optional) True to include photo, false to exclude the photo. </param>
        /// <param name="photoPixelWidth">  (Optional) Width of the photo pixel. </param>
        ///  <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        ///  <param name="includeCounts"> (Optional) True to only include counts of data elements in the response. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by (ClusterName, InsertDate, UpdateDate)</param>
        ///  <param name="orderBy">      (Optional) Specifies if the results should be returned in ascending (asc, default) or descending (desc) order.</param>
        ///
        /// <returns>   The list. </returns>
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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.ClusterListItemCommands>>> GetListForSite(Guid siteUid, int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, bool includeCounts = false, ClusterSortProperty sortBy = ClusterSortProperty.ClusterName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<ClusterManager>(ServerWcfServerAddress, ServerWcfBindingType,
                    ServerUserName, ServerPassword, ClientUserSessionData);

                var parameters = new WcfEntities.GetParametersWithPhoto()
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
                };

                if (includeCounts)
                    parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeCounts, includeCounts));

                var results = await mgr.GetAllClustersForSiteListAsync(parameters);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                //var resp = new ApiEntities.ArrayResponse<ApiEntities.ListItemBase>();
                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.ClusterListItemCommands>>(results);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary>   Get a cluster by ClusterUid value. </summary>
        ///  
        ///  <param name="clusterUid">       The cluster UID. </param>
        ///  <param name="includeProperties"> (Optional) Comma-separated list of properties to populate.</param>
        ///  <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        ///  <param name="photoPixelWidth"> (Optional) Specifies the width of the returned photo image</param>
        ///  <param name="responseFormat">  (Optional) Specifies the format of the response message. </param>
        /// 
        ///  <returns>   A Task&lt;ActionResult&lt;ApiEntities.Cluster&gt;&gt; </returns>
        /// =================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{clusterUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ResponseModels.ClusterResp>> Get(Guid clusterUid, string includeProperties, bool includePhoto = false, int photoPixelWidth = 200, ResponseFormat responseFormat = ResponseFormat.Default)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<ClusterManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = clusterUid,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = !string.IsNullOrEmpty(includeProperties)
                };

                if (!string.IsNullOrEmpty(includeProperties))
                {
                    var includeProps = includeProperties.Split(',');
                    var responseProperties = typeof(WcfEntities.Cluster).GetComplexProperties().ToList();

                    var panelProps = typeof(WcfEntities.GalaxyPanel).GetComplexProperties();
                    responseProperties.AddRange(panelProps);
                    var ibsProperties = typeof(WcfEntities.GalaxyInterfaceBoard).GetComplexProperties();
                    responseProperties.AddRange(ibsProperties);

                    if (includeProperties.Contains(nameof(WcfEntities.Cluster.DisabledCommandIds)))
                    {
                        var clusterCommandsInfo = responseProperties.FirstOrDefault(o =>
                            o.Name == nameof(WcfEntities.Cluster.ClusterCommands));
                        if (clusterCommandsInfo != null)
                        {
                            responseProperties.Remove(clusterCommandsInfo);
                        }

                        var panelCommandsInfo = responseProperties.FirstOrDefault(o =>
                            o.Name == nameof(WcfEntities.GalaxyPanel.DisabledCommandIds));
                        if (panelCommandsInfo != null)
                        {
                            responseProperties.Remove(panelCommandsInfo);
                        }

                        wcfGetParams.IncludeCommands = true;
                    }
                    foreach (var p in responseProperties)
                    {
                        var included = includeProps.FirstOrDefault(o => o.TrimStart().TrimEnd().ToLower() == p.Name.ToLower());
                        if (included == null)
                            wcfGetParams.ExcludeMemberCollectionSettings.Add(p.Name);
                    }
                }

                //wcfGetParams.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(WcfEntities.Cluster.GalaxyPanels), true));
                //wcfGetParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.Cluster.GalaxyPanels));
                var result = await mgr.GetClusterAsync(wcfGetParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                var model =  ConvertToFormat(responseFormat, result);
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

        private object ConvertToFormat(ResponseFormat responseFormat, WcfEntities.Cluster result)
        {
            if (responseFormat == ResponseFormat.ForPut)
                return Mapper.Map<RequestModels.ClusterPutReq>(result);

            if (responseFormat == ResponseFormat.Minimal)
                return Mapper.Map<ApiEntities.ClusterMinimal>(result);

            if (responseFormat == ResponseFormat.ForPutMinimalChildren)
                return Mapper.Map<RequestModels.ClusterPutReqMinimalChildren>(result);

            return Mapper.Map<ResponseModels.ClusterResp>(result);
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{clusterGroupId:int}/{clusterNumber:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ResponseModels.ClusterResp>> GetByAddress(int clusterGroupId, int clusterNumber, string includeProperties, bool includePhoto = false, int photoPixelWidth = 200, ResponseFormat responseFormat = ResponseFormat.Default)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<ClusterManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
                {
                    ClusterGroupId = clusterGroupId,
                    ClusterNumber = clusterNumber,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = !string.IsNullOrEmpty(includeProperties)
                };


                if (!string.IsNullOrEmpty(includeProperties))
                {
                    var includeProps = includeProperties.Split(',');
                    //var responseProperties =
                    //    typeof(WcfEntities.Cluster).GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
                    //var responseProperties =
                    //    typeof(WcfEntities.Cluster).GetProperties(BindingFlags.Public | BindingFlags.Instance).
                    //        Where(p => p.PropertyType != typeof(Guid) &&
                    //                   p.PropertyType != typeof(string) &&
                    //                   p.PropertyType != typeof(int) &&
                    //                   p.PropertyType != typeof(bool) &&
                    //                   p.PropertyType != typeof(short) &&
                    //                   p.PropertyType != typeof(ExtensionDataObject) &&
                    //                   p.PropertyType != typeof(DateTimeOffset) &&
                    //                   p.PropertyType != typeof(Guid?) &&
                    //                   p.PropertyType != typeof(int?) &&
                    //                   p.PropertyType != typeof(bool?) &&
                    //                   p.PropertyType != typeof(short?) &&
                    //                   p.PropertyType != typeof(DateTimeOffset?)).ToList();
                    var responseProperties = typeof(WcfEntities.Cluster).GetComplexProperties().ToList();

                    var panelProps = typeof(WcfEntities.GalaxyPanel).GetComplexProperties();
                    responseProperties.AddRange(panelProps);
                    var ibsProperties = typeof(WcfEntities.GalaxyInterfaceBoard).GetComplexProperties();
                    responseProperties.AddRange(ibsProperties);

                    foreach (var p in responseProperties)
                    {
                        var included = includeProps.FirstOrDefault(o => o.TrimStart().TrimEnd().ToLower() == p.Name.ToLower());
                        if (included == null)
                            wcfGetParams.ExcludeMemberCollectionSettings.Add(p.Name);
                    }
                }

                //wcfGetParams.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(WcfEntities.Cluster.GalaxyPanels), true));
                //wcfGetParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.Cluster.GalaxyPanels));
                var result = await mgr.GetClusterByHardwareAddressAsync(wcfGetParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                if (responseFormat == ResponseFormat.ForPut)
                    return Ok(Mapper.Map<RequestModels.ClusterPutReq>(result));

                if (responseFormat == ResponseFormat.Minimal)
                    return Ok(Mapper.Map<ApiEntities.ClusterMinimal>(result));

                if (responseFormat == ResponseFormat.ForPutMinimalChildren)
                    return Ok(Mapper.Map<RequestModels.ClusterPutReqMinimalChildren>(result));

                var model = Mapper.Map<ResponseModels.ClusterResp>(result);
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
        [HttpGet("byaddress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ResponseModels.ClusterResp>> GetByAddress2(int clusterGroupId, int clusterNumber, string includeProperties, bool includePhoto = false, int photoPixelWidth = 200, ResponseFormat responseFormat = ResponseFormat.Default)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<ClusterManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
                {
                    ClusterGroupId = clusterGroupId,
                    ClusterNumber = clusterNumber,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = !string.IsNullOrEmpty(includeProperties)
                };


                if (!string.IsNullOrEmpty(includeProperties))
                {
                    var includeProps = includeProperties.Split(',');
                    //var responseProperties =
                    //    typeof(WcfEntities.Cluster).GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
                    //var responseProperties =
                    //    typeof(WcfEntities.Cluster).GetProperties(BindingFlags.Public | BindingFlags.Instance).
                    //        Where(p => p.PropertyType != typeof(Guid) &&
                    //                   p.PropertyType != typeof(string) &&
                    //                   p.PropertyType != typeof(int) &&
                    //                   p.PropertyType != typeof(bool) &&
                    //                   p.PropertyType != typeof(short) &&
                    //                   p.PropertyType != typeof(ExtensionDataObject) &&
                    //                   p.PropertyType != typeof(DateTimeOffset) &&
                    //                   p.PropertyType != typeof(Guid?) &&
                    //                   p.PropertyType != typeof(int?) &&
                    //                   p.PropertyType != typeof(bool?) &&
                    //                   p.PropertyType != typeof(short?) &&
                    //                   p.PropertyType != typeof(DateTimeOffset?)).ToList();
                    var responseProperties = typeof(WcfEntities.Cluster).GetComplexProperties().ToList();

                    var panelProps = typeof(WcfEntities.GalaxyPanel).GetComplexProperties();
                    responseProperties.AddRange(panelProps);
                    var ibsProperties = typeof(WcfEntities.GalaxyInterfaceBoard).GetComplexProperties();
                    responseProperties.AddRange(ibsProperties);

                    foreach (var p in responseProperties)
                    {
                        var included = includeProps.FirstOrDefault(o => o.TrimStart().TrimEnd().ToLower() == p.Name.ToLower());
                        if (included == null)
                            wcfGetParams.ExcludeMemberCollectionSettings.Add(p.Name);
                    }
                }

                //wcfGetParams.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(WcfEntities.Cluster.GalaxyPanels), true));
                //wcfGetParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.Cluster.GalaxyPanels));
                var result = await mgr.GetClusterByHardwareAddressAsync(wcfGetParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                if (responseFormat == ResponseFormat.ForPut)
                    return Ok(Mapper.Map<RequestModels.ClusterPutReq>(result));

                if (responseFormat == ResponseFormat.Minimal)
                    return Ok(Mapper.Map<ApiEntities.ClusterMinimal>(result));

                if (responseFormat == ResponseFormat.ForPutMinimalChildren)
                    return Ok(Mapper.Map<RequestModels.ClusterPutReqMinimalChildren>(result));

                var model = Mapper.Map<ResponseModels.ClusterResp>(result);
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
        /// Get cluster editor data.
        /// </summary>
        ///
        /// <returns>   The editor data. </returns>
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

        public async Task<ActionResult<ApiEntities.ClusterEditingDataBasic>> GetEditorData(Guid clusterTypeUid, string includeProperties )
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<ClusterManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                if (clusterTypeUid == Guid.Empty)
                    clusterTypeUid = Common.Constants.GalaxyClusterTypeIds.GalaxyClusterType_Only635;
                var wcfParameters = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = clusterTypeUid,
                    IncludeMemberCollections = true
                };

                if (!string.IsNullOrEmpty(includeProperties))
                {
                    var includeProps = includeProperties.Split(',');
                    var responseProperties =
                        typeof(WcfEntities.ClusterEditingData).GetComplexProperties().ToList();
                    foreach (var p in responseProperties)
                    {
                        var included = includeProps.FirstOrDefault(o => o.TrimStart().TrimEnd().ToLower() == p.Name.ToLower());
                        if (included == null)
                            wcfParameters.ExcludeMemberCollectionSettings.Add(p.Name);
                    }
                }

                var result = await mgr.GetClusterEditingDataAsync(wcfParameters);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();
                var model = Mapper.Map<ApiEntities.ClusterEditingDataBasic>(result);
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
        /// Create a new cluster.
        /// </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///  <param name="includeProperties"> (Optional) Comma-separated list of properties to populate.</param>
        ///  <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        ///  <param name="photoPixelWidth"> (Optional) Specifies the width of the returned photo image</param>
        ///  <param name="responseFormat">  (Optional) Specifies the format of the response message. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.Cluster&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RequestModels.ClusterPutReq>> Post(RequestModels.SaveParams<RequestModels.ClusterReq> parameters, string includeProperties, bool includePhoto = false, int photoPixelWidth = 200, ResponseFormat responseFormat = ResponseFormat.Default)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgr = Helpers.GetManager<ClusterManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);
                wcfSaveParameters.IncludeMemberCollections = !string.IsNullOrEmpty(includeProperties);
                wcfSaveParameters.IncludePhoto = includePhoto;
                wcfSaveParameters.PhotoPixelWidth = photoPixelWidth;
                
                ProcessIncludeProperties(includeProperties, wcfSaveParameters);

                var wcfEntity = Mapper.Map<WcfEntities.Cluster>(parameters.Data);
                wcfEntity.ConcurrencyValue = 0;
                if (parameters.Data.Image != null)
                    wcfEntity.gcsBinaryResource.BinaryResource = parameters.Data.Image;

                if (parameters.Data.ClusterTypeUid == Guid.Empty)
                {
                    switch (parameters.Data.ClusterType)
                    {
                        //case Common.Enums.ClusterType.Hybrid6xx:
                        //    wcfEntity.ClusterTypeUid = GalaxySMS.Common.Constants.GalaxyClusterTypeIds.GalaxyClusterType_Hybrid6xx;
                        //    break;

                        //case Common.Enums.ClusterType.Only600:
                        //    wcfEntity.ClusterTypeUid = GalaxySMS.Common.Constants.GalaxyClusterTypeIds.GalaxyClusterType_Only600;
                        //    break;
                        case Common.Enums.ClusterType.Only7xx:
                            wcfEntity.ClusterTypeUid = GalaxySMS.Common.Constants.GalaxyClusterTypeIds.GalaxyClusterType_Only7xx;
                            break;
                        case Common.Enums.ClusterType.Hybrid7xx:
                            wcfEntity.ClusterTypeUid = GalaxySMS.Common.Constants.GalaxyClusterTypeIds.GalaxyClusterType_Hybrid7xx;
                            break;
                        case Common.Enums.ClusterType.Only635:
                        default:
                            wcfEntity.ClusterTypeUid = GalaxySMS.Common.Constants.GalaxyClusterTypeIds.GalaxyClusterType_Only635;
                            break;
                    }
                }

                if (parameters.Data.CredentialDataLengthUid == Guid.Empty)
                {
                    switch (parameters.Data.CredentialDataLength)
                    {
                        case Common.Enums.CredentialDataSize.Extended256Bits:
                            wcfEntity.CredentialDataLengthUid = GalaxySMS.Common.Constants.CredentialDataLengthIds.Extended256Bits;
                            break;
                        case Common.Enums.CredentialDataSize.Standard48Bits:
                        default:
                            wcfEntity.CredentialDataLengthUid = GalaxySMS.Common.Constants.CredentialDataLengthIds.Standard48Bits;
                            break;
                    }
                }

                if (parameters.Data.TimeScheduleTypeUid == Guid.Empty)
                {
                    switch (parameters.Data.TimeScheduleType)
                    {
                        case Common.Enums.TimeScheduleType.GalaxyFifteenMinuteInterval:
                            wcfEntity.TimeScheduleTypeUid = GalaxySMS.Common.Constants.TimeScheduleTypeIds.TimeScheduleType_GalaxyLegacy15MinuteInterval;
                            break;
                        case Common.Enums.TimeScheduleType.AssaAbloyDsr:
                        //break;
                        case Common.Enums.TimeScheduleType.GalaxyOneMinuteInterval:
                        default:
                            wcfEntity.TimeScheduleTypeUid = GalaxySMS.Common.Constants.TimeScheduleTypeIds.TimeScheduleType_GalaxyMinuteInterval;
                            break;
                    }
                }

                if (parameters.Data.AccessPortalLockedLedBehaviorModeUid == Guid.Empty)
                {
                    switch (parameters.Data.AccessPortalLockedLedBehaviorMode)
                    {
                        case Common.Enums.ClusterLedBehavior.SteadyHigh:
                            wcfEntity.AccessPortalLockedLedBehaviorModeUid = GalaxySMS.Common.Constants.ClusterLedBehaviorIds.SteadyHigh;
                            break;
                        case Common.Enums.ClusterLedBehavior.Strobe:
                            wcfEntity.AccessPortalLockedLedBehaviorModeUid = GalaxySMS.Common.Constants.ClusterLedBehaviorIds.Strobe;
                            break;
                        case Common.Enums.ClusterLedBehavior.StrobeRapid:
                            wcfEntity.AccessPortalLockedLedBehaviorModeUid = GalaxySMS.Common.Constants.ClusterLedBehaviorIds.StrobeRapid;
                            break;
                        case Common.Enums.ClusterLedBehavior.SteadyLow:
                        default:
                            wcfEntity.AccessPortalLockedLedBehaviorModeUid = GalaxySMS.Common.Constants.ClusterLedBehaviorIds.SteadyLow;
                            break;
                    }
                }

                if (parameters.Data.AccessPortalUnlockedLedBehaviorModeUid == Guid.Empty)
                {
                    switch (parameters.Data.AccessPortalUnlockedLedBehaviorMode)
                    {
                        case Common.Enums.ClusterLedBehavior.SteadyHigh:
                            wcfEntity.AccessPortalUnlockedLedBehaviorModeUid = GalaxySMS.Common.Constants.ClusterLedBehaviorIds.SteadyHigh;
                            break;
                        case Common.Enums.ClusterLedBehavior.StrobeRapid:
                            wcfEntity.AccessPortalUnlockedLedBehaviorModeUid = GalaxySMS.Common.Constants.ClusterLedBehaviorIds.StrobeRapid;
                            break;
                        case Common.Enums.ClusterLedBehavior.SteadyLow:
                            wcfEntity.AccessPortalUnlockedLedBehaviorModeUid = GalaxySMS.Common.Constants.ClusterLedBehaviorIds.SteadyLow;
                            break;
                        case Common.Enums.ClusterLedBehavior.Strobe:
                        default:
                            wcfEntity.AccessPortalUnlockedLedBehaviorModeUid = GalaxySMS.Common.Constants.ClusterLedBehaviorIds.Strobe;
                            break;
                    }
                }

                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.Cluster>(wcfEntity, wcfSaveParameters);
                
                if( parameters.Data.ScheduleIds != null)
                {
                    if (parameters.Data.ScheduleIds.Count > TimeScheduleLimits.HighestDefinableNumber)
                        return BadRequest(
                            $"There are to many ScheduleId values specified. The maximum allowed is {TimeScheduleLimits.HighestDefinableNumber}. {parameters.Data.ScheduleIds.Count} have been specified.");
                    foreach (var schId in parameters.Data.ScheduleIds)
                    {
                        wcfParams.Data.TimeSchedules.Add(new WcfEntities.TimeScheduleSelect()
                        {
                            TimeScheduleUid = schId,
                            Selected = true
                        });
                    }
                }
 
                var validationProblemDetails = await mgr.ValidateClusterAsync(wcfParams);
                if (validationProblemDetails != null)
                {
                    if (validationProblemDetails is { IsValid: false })
                    {
                        return ValidationProblem(new ValidationProblemDetails(validationProblemDetails.Errors));
                    }
                }

                var results = await mgr.SaveClusterAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var url = LinkGenerator.GetPathByAction("Get",
                        "Cluster",
                        new { clusterUid = results.ClusterUid });

                    var model = ConvertToFormat(responseFormat, results);
                    if (results.UpdateDate > results.InsertDate)
                        return Ok(model);
                    return Created(url, model);

                    //if (responseFormat == ResponseFormat.ForPut)
                    //{
                    //    var savedItem = Mapper.Map<RequestModels.ClusterPutReq>(results);
                    //    if (results.UpdateDate > results.InsertDate)
                    //        return Ok(savedItem);
                    //    return Created(url, savedItem);
                    //}

                    //if (responseFormat == ResponseFormat.Minimal)
                    //{
                    //    var savedItemA = Mapper.Map<ApiEntities.ClusterMinimal>(results);
                    //    if (results.UpdateDate > results.InsertDate)
                    //        return Ok(savedItemA);
                    //    return Created(url, savedItemA);
                    //}


                    //if (responseFormat == ResponseFormat.ForPutMinimalChildren)
                    //{
                    //    var savedItemB = Mapper.Map<RequestModels.ClusterPutReqMinimalChildren>(results);
                    //    if (results.UpdateDate > results.InsertDate)
                    //        return Ok(savedItemB);
                    //    return Created(url, savedItemB);
                    //}

                    //var savedItemC = Mapper.Map<ResponseModels.ClusterResp>(results);
                    //if (results.UpdateDate > results.InsertDate)
                    //    return Ok(savedItemC);
                    //return Created(url, savedItemC);
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
        /// Update an existing Cluster item. Can also create a new Cluster.
        /// </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///  <param name="includeProperties"> (Optional) Comma-separated list of properties to populate.</param>
        ///  <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        ///  <param name="photoPixelWidth"> (Optional) Specifies the width of the returned photo image</param>
        ///  <param name="responseFormat">  (Optional) Specifies the format of the response message. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.Cluster&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ClusterPutReq>> Put(RequestModels.SaveParams<RequestModels.ClusterPutReq> parameters, string includeProperties, bool includePhoto = false, int photoPixelWidth = 200, ResponseFormat responseFormat = ResponseFormat.Default)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (parameters.Data.ClusterUid == Guid.Empty)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot update Cluster with ClusterUid value of {parameters.Data.ClusterUid}");

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgr = Helpers.GetManager<ClusterManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);
                wcfSaveParameters.IncludeMemberCollections = !string.IsNullOrEmpty(includeProperties);
                wcfSaveParameters.IncludePhoto = includePhoto;
                wcfSaveParameters.PhotoPixelWidth = photoPixelWidth;

                ProcessIncludeProperties(includeProperties, wcfSaveParameters);

                var wcfEntity = Mapper.Map<WcfEntities.Cluster>(parameters.Data);

                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.Cluster>(wcfEntity, wcfSaveParameters);
                if (parameters.Data.ScheduleIds != null)
                {
                    foreach (var schId in parameters.Data.ScheduleIds)
                    {
                        wcfParams.Data.TimeSchedules.Add(new WcfEntities.TimeScheduleSelect()
                        {
                            TimeScheduleUid = schId,
                            Selected = true
                        });
                    }
                }

                var validationProblemDetails = await mgr.ValidateClusterAsync(wcfParams);
                if (validationProblemDetails != null)
                {
                    if (validationProblemDetails is { IsValid: false })
                    {
                        return ValidationProblem(new ValidationProblemDetails(validationProblemDetails.Errors));
                    }
                }
                var results = await mgr.SaveClusterAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    ////var savedItem = Mapper.Map<ClusterPutReq>(results);
                    //var savedItem = Mapper.Map<ClusterPutReqMinimalChildren>(results);
                    //var url = LinkGenerator.GetPathByAction("Get",
                    //    "Cluster",
                    //    new { clusterUid = savedItem.ClusterUid });
                    //if (results.UpdateDate > results.InsertDate)
                    //    return Ok(savedItem);
                    //return Created(url, savedItem);

                    var url = LinkGenerator.GetPathByAction("Get",
                        "Cluster",
                        new { clusterUid = results.ClusterUid });
  
                    var model = ConvertToFormat(responseFormat, results);
                    if (results.UpdateDate > results.InsertDate)
                        return Ok(model);
                    return Created(url, model);

                    //if (responseFormat == ResponseFormat.ForPut)
                    //{
                    //    var savedItem = Mapper.Map<RequestModels.ClusterPutReq>(results);
                    //    if (results.UpdateDate > results.InsertDate)
                    //        return Ok(savedItem);
                    //    return Created(url, savedItem);
                    //}

                    //if (responseFormat == ResponseFormat.Minimal)
                    //{
                    //    var savedItemA = Mapper.Map<ApiEntities.ClusterMinimal>(results);
                    //    if (results.UpdateDate > results.InsertDate)
                    //        return Ok(savedItemA);
                    //    return Created(url, savedItemA);
                    //}


                    //if (responseFormat == ResponseFormat.ForPutMinimalChildren)
                    //{
                    //    var savedItemB = Mapper.Map<RequestModels.ClusterPutReqMinimalChildren>(results);
                    //    if (results.UpdateDate > results.InsertDate)
                    //        return Ok(savedItemB);
                    //    return Created(url, savedItemB);
                    //}


                    //var savedItemC = Mapper.Map<ResponseModels.ClusterResp>(results);
                    //if (results.UpdateDate > results.InsertDate)
                    //    return Ok(savedItemC);
                    //return Created(url, savedItemC);

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

        private static void ProcessIncludeProperties(string includeProperties, WcfEntities.SaveParameters wcfSaveParameters)
        {
            if (!string.IsNullOrEmpty(includeProperties))
            {
                var includeProps = includeProperties.Split(',');
                var responseProperties = typeof(WcfEntities.Cluster).GetComplexProperties().ToList();

                var panelProps = typeof(WcfEntities.GalaxyPanel).GetComplexProperties();
                responseProperties.AddRange(panelProps);
                var ibsProperties = typeof(WcfEntities.GalaxyInterfaceBoard).GetComplexProperties();
                responseProperties.AddRange(ibsProperties);

                foreach (var p in responseProperties)
                {
                    var included = includeProps.FirstOrDefault(o => o.TrimStart().TrimEnd().ToLower() == p.Name.ToLower());
                    if (included == null)
                        wcfSaveParameters.ExcludeMemberCollectionSettings.Add(p.Name);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Delete a specific Cluster by ClusterUid.
        /// </summary>
        ///
        /// <param name="clusterUid"> Identifier for the Cluster to delete. </param>
        ///
        /// <returns>   A Task&lt;IActionResult&gt; </returns>
        ///=================================================================================================        
        [HttpDelete("{clusterUid}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid clusterUid)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<ClusterManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetClusterAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = clusterUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = false
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                var x = await mgr.DeleteClusterByUniqueIdAsync(new WcfEntities.DeleteParameters() { UniqueId = clusterUid });

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
        /// Send a command to one or more control panels.
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

        public async Task<IActionResult> ExecuteCommand(RequestModels.CommandParams<RequestModels.GalaxyCpuCommandActionReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<ClusterManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var wcfParams = Mapper.Map<WcfEntities.CommandParameters<WcfEntities.GalaxyCpuCommandAction>>(parameters);
                var result = await mgr.ExecuteClusterCommandAsync(wcfParams);

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
        /// <summary>   Send a command to load configuration data. </summary>
        /// 
        /// <remarks>   Kevin, 1/5/2023. </remarks>
        /// <param name="parameters">   . </param>
        /// <param name="backgroundJob"></param>
        /// <returns>   The data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost("loaddata")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        //public async Task<IActionResult> LoadData(RequestModels.CommandParamsSimple<RequestModels.ClusterDataLoadParametersReq> parameters)
        public async Task<IActionResult> LoadData(RequestModels.CommandParams<RequestModels.ClusterDataLoadParametersReq> parameters, bool backgroundJob)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                //if (parameters.Data.ClusterUid == Guid.Empty && parameters.Data.GalaxyPanelUid == Guid.Empty && parameters.Data.CpuUid == Guid.Empty)
                //    return BadRequest($"{nameof(parameters.Data.ClusterUid)} or {nameof(parameters.Data.GalaxyPanelUid)} or {nameof(parameters.Data.CpuUid)} is required.");


                //var validationProblemDetails = await ValidateLoadDataUids(parameters);
                //if (validationProblemDetails != null)
                //    return ValidationProblem(validationProblemDetails);

                var mgr = Helpers.GetManager<GalaxyPanelCommunicationManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfParams = Mapper.Map<WcfEntities.CommandParameters<WcfEntities.ClusterDataLoadParameters>>(parameters);

                if (backgroundJob)
                {
                    var resultJob = await mgr.SendClusterDataToPanelsJobAsync(wcfParams);

                    if (mgr.HasErrors)
                    {
                        return GetStatusCodeResult(mgr);
                    }

                    var resJob = Mapper.Map<ApiEntities.BackgroundJobInfo<ResponseModels.LoadDataCommandResponseSimple<ClusterDataLoadParametersReq>>>(resultJob);
                    return Ok(resJob);
                }
                var result = await mgr.SendClusterDataToPanelsAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var res = Mapper.Map<ResponseModels.LoadDataCommandResponseSimple<ClusterDataLoadParametersReq>>(result);
                return Ok(res);

                //var details = Mapper.Map<RequestModels.ClusterDataLoadParametersReq>(result.Data);
                //var res = Mapper.Map<ResponseModels.CommandResponseSimple>(result);
                //var response = new ResponseModels.CommandResponseSimple<RequestModels.ClusterDataLoadParametersReq>()
                //{
                //    OperationUid = res.OperationUid,
                //    RequestDateTime = res.RequestDateTime,
                //    ApproximateDuration = res.ApproximateDuration,
                //    PanelsSentTo = res.PanelsSentTo,
                //    Data = details
                //};
                //return Ok(response);
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

        //private ValidationProblemDetails ValidateUids(GalaxyCpuCommandBaseReq parameters)
        //{
        //    var response = new ValidationProblemDetails();
        //    var errorsArray = new List<string>();

        //    errorsArray.Add($"The {nameof(parameters.Data.ClusterUid)} cannot be changed.");
        //    if (errorsArray.Any())
        //    {
        //        response.Errors.Add($"{nameof(Cluster)}", errorsArray.ToArray());
        //        return response;
        //    }

        //    return null;
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary>
        ///  Maps a specific TimeSchedule to a cluster.
        ///  </summary>
        /// 
        ///  <param name="clusterUid"> Identifier for the Cluster to map. </param>
        ///  <param name="timeScheduleUid"> Identifier for the TimeSchedule to map. </param>
        ///  <param name="fifteenMinuteFormatUsesHolidays"> True enables holiday support for the time schedule</param>
        ///  <returns>   A Task&lt;IActionResult&gt; </returns>
        /// =================================================================================================        
        [HttpPost("{clusterUid}/mapschedule/{timeScheduleUid}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiEntities.GalaxyClusterTimeScheduleMapBasic>> PostTimeScheduleMapping(Guid clusterUid, Guid timeScheduleUid, bool fifteenMinuteFormatUsesHolidays = true)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var validationProblemDetails = await ValidateClusterTimeScheduleMapping(timeScheduleUid, clusterUid);
                if (validationProblemDetails != null)
                    return ValidationProblem(validationProblemDetails);

                var mgr = Helpers.GetManager<TimeScheduleManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.SaveTimeScheduleClusterMappingAsync(timeScheduleUid, clusterUid, true, fifteenMinuteFormatUsesHolidays);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                return Ok(Mapper.Map<ApiEntities.GalaxyClusterTimeScheduleMapBasic>(result));
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
        /// Delete a specific Cluster to TimeSchedule mapping.
        /// </summary>
        ///
        /// <param name="clusterUid"> Identifier for the Cluster to delete. </param>
        /// <param name="timeScheduleUid"> Identifier for the TimeSchedule to delete. </param>
        ///
        /// <returns>   A Task&lt;IActionResult&gt; </returns>
        ///=================================================================================================        
        [HttpDelete("{clusterUid}/mapschedule/{timeScheduleUid:Guid}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTimeScheduleMapping(Guid clusterUid, Guid timeScheduleUid)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);
                if (timeScheduleUid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never ||
                    timeScheduleUid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always)
                    return BadRequest($"TimeScheduleUid {timeScheduleUid} cannot be un-mapped from a cluster.");

                var mgr = Helpers.GetManager<TimeScheduleManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
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
                        if( mappings.Mappings.AccessPortals.Any())
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

        private async Task<ApiEntities.TimeScheduleUsageData> ValidateDeleteClusterTimeScheduleMapping(Guid timeScheduleUid, Guid clusterUid)
        {
            var mgr = Helpers.GetManager<TimeScheduleManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

            var results = await mgr.GetTimeScheduleUsageInformationAsync(timeScheduleUid, clusterUid);
            return Mapper.Map<ApiEntities.TimeScheduleUsageData>(results);
        }


    }
}
