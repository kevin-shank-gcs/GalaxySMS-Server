extern alias NetCoreCommon;
using AutoMapper;
using GalaxySMS.Api.Models.RequestModels;
using GalaxySMS.MercuryApi.Support;
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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using RequestModels = GalaxySMS.Api.Models.RequestModels;
using ResponseModels = GalaxySMS.Api.Models.ResponseModels;
using WcfEntities = GalaxySMS.Business.Entities;

namespace GalaxySMS.MercuryApi.Controllers.Api
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Operations relating to Galaxy Panels. </summary>
    ///<remarks>  </remarks>
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================

    [Route("api/[controller]")]
    [ApiController]  // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GalaxyPanelController : ControllerBaseEx
    {
        public GalaxyPanelController(IConfiguration config,
            IMapper mapper,
            ILogger<GalaxyPanelController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper, logger, linkGenerator, cache, distributedCache)
        {

        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get all Galaxy panels. </summary>
        ///
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        /// <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        /// <param name="sortBy"> (Optional) The property to sort the results by</param>
        /// <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.GalaxyPanelBasic[]&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.GalaxyPanelBasic>>> Get(int pageSize, int pageNumber, bool includeChildren = false, bool includeCommands = false, GalaxyPanelSortProperty sortBy = GalaxyPanelSortProperty.PanelName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<GalaxyPanelManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetAllGalaxyPanelsAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    IncludePhoto = false,
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

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.GalaxyPanelBasic>>(results);
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
        /// Get all controllers for a site.
        /// </summary>
        ///
        /// <param name="siteUid">  The site UID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        /// <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        /// <param name="sortBy"> (Optional) The property to sort the results by</param>
        /// <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.GalaxyPanelBasic>>> GetGalaxyControllersForSite(Guid siteUid, int pageSize, int pageNumber, bool includeChildren = false, bool includeCommands = false, GalaxyPanelSortProperty sortBy = GalaxyPanelSortProperty.PanelName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<GalaxyPanelManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetGalaxyPanelsForSiteAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = siteUid,
                    IncludePhoto = false,
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

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.GalaxyPanelBasic>>(results);
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
        /// Get all controllers for a cluster.
        /// </summary>
        ///
        /// <param name="clusterUid">  The cluster UID. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        /// <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        /// <param name="sortBy"> (Optional) The property to sort the results by</param>
        /// <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   The controllers for cluster. </returns>
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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.GalaxyPanelBasic>>> GetGalaxyControllersForCluster(Guid clusterUid, int pageSize, int pageNumber, bool includeChildren = false, bool includeCommands = false, GalaxyPanelSortProperty sortBy = GalaxyPanelSortProperty.PanelName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<GalaxyPanelManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetGalaxyPanelsForClusterAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = clusterUid,
                    IncludePhoto = false,
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

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.GalaxyPanelBasic>>(results);
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
        ///  Get all controllers for a list of clusters.
        ///  </summary>
        /// 
        ///  <param name="clusterUids"> Comma-separated list of cluster uid values</param>
        /////  <param name="pageSize">     Size of the page. 0 = no paging</param>
        /////  <param name="pageNumber">   The page number. </param>
        ///  <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        ///  <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the GalaxyPanel results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the GalaxyPanel items should be returned in ascending or descending order.</param>
        /// 
        ///  <returns>   The controllers for clusters. </returns>
        /// =================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("allforclusters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.ClusterGalaxyPanelMinimal>>> GetGalaxyControllersForClusters(string clusterUids, /*int pageSize, int pageNumber, bool includeChildren = false, */bool includeCommands = false, GalaxyPanelSortProperty sortBy = GalaxyPanelSortProperty.PanelName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<ClusterManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                
                var results = await mgr.GetClustersWithGalaxyPanelInfoAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    GetString = clusterUids,
                    IncludePhoto = false,
                    IncludeMemberCollections = false,// includeChildren,
                    IncludeCommands = includeCommands,
                    PageNumber = 0,//pageNumber,
                    PageSize = 0,//pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.ClusterGalaxyPanelMinimal>>(results);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get a panel by GalaxyPanelUid value. </summary>
        /// 
        /// <param name="galaxyPanelUid">   The panel UID. </param>
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.GalaxyPanel&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{galaxyPanelUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<RequestModels.GalaxyPanelPutReq>> Get(Guid galaxyPanelUid, bool includeChildren = false)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var getForPut = true;

                var mgr = Helpers.GetManager<GalaxyPanelManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = galaxyPanelUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = includeChildren,
                };

                //wcfGetParams.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(WcfEntities.Cluster.GalaxyPanels), true));
                //wcfGetParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.Cluster.GalaxyPanels));
                var result = await mgr.GetGalaxyPanelAsync(wcfGetParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                if (getForPut)
                {
                    var putData = Mapper.Map<RequestModels.GalaxyPanelPutReq>(result);
                    if (putData.GalaxyPanelModelUid == GalaxyPanelTypeIds.GalaxyPanelType_635)
                        putData.GalaxyPanelModel = GalaxyPanelModel.GalaxyPanel635;
                    else if (putData.GalaxyPanelModelUid == GalaxyPanelTypeIds.GalaxyPanelType_708)
                        putData.GalaxyPanelModel = GalaxyPanelModel.GalaxyPanel708;
                    else if (putData.GalaxyPanelModelUid == GalaxyPanelTypeIds.GalaxyPanelType_600)
                        putData.GalaxyPanelModel = GalaxyPanelModel.GalaxyPanel600;
                    else if (putData.GalaxyPanelModelUid == GalaxyPanelTypeIds.GalaxyPanelType_500)
                        putData.GalaxyPanelModel = GalaxyPanelModel.GalaxyPanel5xx;

                    foreach (var ae in putData.AlertEvents)
                    {
                        if (ae.GalaxyPanelAlertEventTypeUid == GalaxyPanelAlertEventTypeIds.ACFailure)
                            ae.AlertEventType = GalaxyPanelAlertEventType.ACFailure;
                        else if (ae.GalaxyPanelAlertEventTypeUid == GalaxyPanelAlertEventTypeIds.LowBattery)
                            ae.AlertEventType = GalaxyPanelAlertEventType.LowBattery;
                        else if (ae.GalaxyPanelAlertEventTypeUid == GalaxyPanelAlertEventTypeIds.Tamper)
                            ae.AlertEventType = GalaxyPanelAlertEventType.Tamper;
                        else if (ae.GalaxyPanelAlertEventTypeUid == GalaxyPanelAlertEventTypeIds.EmergencyUnlock)
                            ae.AlertEventType = GalaxyPanelAlertEventType.EmergencyUnlock;

                        var fullAe = result.AlertEvents.FirstOrDefault(o =>
                            o.GalaxyPanelAlertEventTypeUid == ae.GalaxyPanelAlertEventTypeUid);
                        if (fullAe?.Note != null)
                            ae.UserInstructions = fullAe.Note.NoteText;
                    }
                    return Ok(putData);
                }

                var model = Mapper.Map<ResponseModels.GalaxyPanelResp>(result);
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
        /// <summary> Get Galaxy Panel by ClusterUid and Panel #
        ///
        /// <remarks>   Kevin, 8/25/2022. </remarks>
        ///
        /// <param name="clusterUid">       The cluster UID. </param>
        /// <param name="panelNumber">      The panel number. </param>
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        ///
        /// <returns>   The by address. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{clusterUid:guid}/{panelNumber:int}")]
        //        [HttpGet("byaddress/{clusterGroupId}/{clusterNumber}/{panelNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<GalaxyPanelPutReq>> GetByAddress(Guid clusterUid, int panelNumber, bool includeChildren = false)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var getForPut = true;

                var mgr = Helpers.GetManager<GalaxyPanelManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
                {
                    ClusterUid = clusterUid,
                    PanelNumber = panelNumber,
                    IncludePhoto = false,
                    IncludeMemberCollections = includeChildren,
                };

                //wcfGetParams.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(WcfEntities.Cluster.GalaxyPanels), true));
                //wcfGetParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.Cluster.GalaxyPanels));
                var result = await mgr.GetGalaxyPanelByHardwareAddressAsync(wcfGetParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                if (getForPut)
                {
                    var putData = Mapper.Map<RequestModels.GalaxyPanelPutReq>(result);
                    if (putData.GalaxyPanelModelUid == GalaxyPanelTypeIds.GalaxyPanelType_635)
                        putData.GalaxyPanelModel = GalaxyPanelModel.GalaxyPanel635;
                    else if (putData.GalaxyPanelModelUid == GalaxyPanelTypeIds.GalaxyPanelType_708)
                        putData.GalaxyPanelModel = GalaxyPanelModel.GalaxyPanel708;
                    else if (putData.GalaxyPanelModelUid == GalaxyPanelTypeIds.GalaxyPanelType_600)
                        putData.GalaxyPanelModel = GalaxyPanelModel.GalaxyPanel600;
                    else if (putData.GalaxyPanelModelUid == GalaxyPanelTypeIds.GalaxyPanelType_500)
                        putData.GalaxyPanelModel = GalaxyPanelModel.GalaxyPanel5xx;

                    foreach (var ae in putData.AlertEvents)
                    {
                        if (ae.GalaxyPanelAlertEventTypeUid == GalaxyPanelAlertEventTypeIds.ACFailure)
                            ae.AlertEventType = GalaxyPanelAlertEventType.ACFailure;
                        else if (ae.GalaxyPanelAlertEventTypeUid == GalaxyPanelAlertEventTypeIds.LowBattery)
                            ae.AlertEventType = GalaxyPanelAlertEventType.LowBattery;
                        else if (ae.GalaxyPanelAlertEventTypeUid == GalaxyPanelAlertEventTypeIds.Tamper)
                            ae.AlertEventType = GalaxyPanelAlertEventType.Tamper;
                        else if (ae.GalaxyPanelAlertEventTypeUid == GalaxyPanelAlertEventTypeIds.EmergencyUnlock)
                            ae.AlertEventType = GalaxyPanelAlertEventType.EmergencyUnlock;

                        var fullAe = result.AlertEvents.FirstOrDefault(o =>
                            o.GalaxyPanelAlertEventTypeUid == ae.GalaxyPanelAlertEventTypeUid);
                        if (fullAe?.Note != null)
                            ae.UserInstructions = fullAe.Note.NoteText;
                    }
                    return Ok(putData);
                }

                var model = Mapper.Map<ResponseModels.GalaxyPanelResp>(result);
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
        /// <summary> Get Galaxy Panel by ClusterUid and Panel #
        /// </summary>
        ///
        /// <remarks>   Kevin, 8/25/2022. </remarks>
        ///
        /// <param name="clusterUid">       The cluster UID. </param>
        /// <param name="panelNumber">      The panel number. </param>
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        ///
        /// <returns>   The by address 1. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
        public async Task<ActionResult<GalaxyPanelPutReq>> GetByAddress1(Guid clusterUid, int panelNumber, bool includeChildren = false)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var getForPut = true;

                var mgr = Helpers.GetManager<GalaxyPanelManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
                {
                    ClusterUid = clusterUid,
                    PanelNumber = panelNumber,
                    IncludePhoto = false,
                    IncludeMemberCollections = includeChildren,
                };

                //wcfGetParams.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(WcfEntities.Cluster.GalaxyPanels), true));
                //wcfGetParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.Cluster.GalaxyPanels));
                var result = await mgr.GetGalaxyPanelByHardwareAddressAsync(wcfGetParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                if (getForPut)
                {
                    var putData = Mapper.Map<RequestModels.GalaxyPanelPutReq>(result);
                    if (putData.GalaxyPanelModelUid == GalaxyPanelTypeIds.GalaxyPanelType_635)
                        putData.GalaxyPanelModel = GalaxyPanelModel.GalaxyPanel635;
                    else if (putData.GalaxyPanelModelUid == GalaxyPanelTypeIds.GalaxyPanelType_708)
                        putData.GalaxyPanelModel = GalaxyPanelModel.GalaxyPanel708;
                    else if (putData.GalaxyPanelModelUid == GalaxyPanelTypeIds.GalaxyPanelType_600)
                        putData.GalaxyPanelModel = GalaxyPanelModel.GalaxyPanel600;
                    else if (putData.GalaxyPanelModelUid == GalaxyPanelTypeIds.GalaxyPanelType_500)
                        putData.GalaxyPanelModel = GalaxyPanelModel.GalaxyPanel5xx;

                    foreach (var ae in putData.AlertEvents)
                    {
                        if (ae.GalaxyPanelAlertEventTypeUid == GalaxyPanelAlertEventTypeIds.ACFailure)
                            ae.AlertEventType = GalaxyPanelAlertEventType.ACFailure;
                        else if (ae.GalaxyPanelAlertEventTypeUid == GalaxyPanelAlertEventTypeIds.LowBattery)
                            ae.AlertEventType = GalaxyPanelAlertEventType.LowBattery;
                        else if (ae.GalaxyPanelAlertEventTypeUid == GalaxyPanelAlertEventTypeIds.Tamper)
                            ae.AlertEventType = GalaxyPanelAlertEventType.Tamper;
                        else if (ae.GalaxyPanelAlertEventTypeUid == GalaxyPanelAlertEventTypeIds.EmergencyUnlock)
                            ae.AlertEventType = GalaxyPanelAlertEventType.EmergencyUnlock;

                        var fullAe = result.AlertEvents.FirstOrDefault(o =>
                            o.GalaxyPanelAlertEventTypeUid == ae.GalaxyPanelAlertEventTypeUid);
                        if (fullAe?.Note != null)
                            ae.UserInstructions = fullAe.Note.NoteText;
                    }
                    return Ok(putData);
                }

                var model = Mapper.Map<ResponseModels.GalaxyPanelResp>(result);
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
        /// <summary>   Get a panel by GalaxyPanelUid value. </summary>
        /// 
        /// <param name="galaxyInterfaceBoardUid">   The board UID. </param>
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.GalaxyPanel&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("board/{galaxyInterfaceBoardUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.GalaxyInterfaceBoardBasic>> GetBoard(Guid galaxyInterfaceBoardUid, bool includeChildren = false)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var getForPut = true;

                var mgr = Helpers.GetManager<GalaxyInterfaceBoardManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = galaxyInterfaceBoardUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = includeChildren,
                };

                //wcfGetParams.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(WcfEntities.Cluster.GalaxyPanels), true));
                //wcfGetParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.Cluster.GalaxyPanels));
                var result = await mgr.GetGalaxyInterfaceBoardAsync(wcfGetParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                if (getForPut)
                {
                    var putData = Mapper.Map<RequestModels.GalaxyInterfaceBoardPutReq>(result);
                    return Ok(putData);
                }

                var model = Mapper.Map<ApiEntities.GalaxyInterfaceBoardBasic>(result);
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
        /// Get Galaxy panel editor data.
        ///
        /// <remarks>   Kevin, 3/10/2022. </remarks>
        ///
        /// <param name="clusterUid">           The cluster UID. </param>
        /// <param name="includeProperties">    Comma-separated list of response properties to populate. </param>
        ///
        /// <returns>   The editor data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        public async Task<ActionResult<ApiEntities.GalaxyPanelEditingDataBasic>> GetEditorData(Guid clusterUid, string includeProperties)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<GalaxyPanelManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfParameters = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = clusterUid,
                    IncludeMemberCollections = true
                };

                if (!string.IsNullOrEmpty(includeProperties))
                {
                    var includeProps = includeProperties.Split(',');
                    var responseProperties =
                        typeof(WcfEntities.GalaxyPanelEditingData).GetComplexProperties().ToList();
                    foreach (var p in responseProperties)
                    {
                        var included = includeProps.FirstOrDefault(o => o.TrimStart().TrimEnd().ToLower() == p.Name.ToLower());
                        if (included == null)
                            wcfParameters.ExcludeMemberCollectionSettings.Add(p.Name);
                    }
                }


                var excludeClusterSpecificProperties =
                    typeof(ApiEntities.GalaxyPanelEditingDataCommonBasic).GetComplexProperties();
                foreach (var p in excludeClusterSpecificProperties)
                {
                    if (!wcfParameters.IsExcluded(p.Name))
                        wcfParameters.ExcludeMemberCollectionSettings.Add(p.Name);
                }

                var result = await mgr.GetGalaxyPanelEditingDataAsync(wcfParameters);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();
                var model = Mapper.Map<ApiEntities.GalaxyPanelEditingDataBasic>(result);

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
        /// Get Galaxy panel editor data.
        ///
        /// <remarks>   Kevin, 3/10/2022. </remarks>
        ///
        /// <param name="clusterUid">           The cluster UID. </param>
        /// <param name="includeProperties">    Comma-separated list of response properties to populate. </param>
        ///
        /// <returns>   The editor data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("commoneditordata")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.GalaxyPanelEditingDataCommonBasic>> GetCommonEditorData(string includeProperties)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<GalaxyPanelManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

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
                        typeof(WcfEntities.GalaxyPanelEditingData).GetComplexProperties().ToList();
                    foreach (var p in responseProperties)
                    {
                        var included = includeProps.FirstOrDefault(o => o.TrimStart().TrimEnd().ToLower() == p.Name.ToLower());
                        if (included == null)
                            wcfParameters.ExcludeMemberCollectionSettings.Add(p.Name);
                    }
                }

                var excludeClusterSpecificProperties =
                    typeof(ApiEntities.GalaxyPanelEditingDataBasic).GetComplexProperties();
                foreach (var p in excludeClusterSpecificProperties)
                {
                    if (!wcfParameters.IsExcluded(p.Name))
                        wcfParameters.ExcludeMemberCollectionSettings.Add(p.Name);
                }
                if (!wcfParameters.IsExcluded(nameof(WcfEntities.GalaxyPanelEditingData.CpuModels)))
                    wcfParameters.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.GalaxyPanelEditingData.CpuModels));

                var result = await mgr.GetGalaxyPanelEditingDataAsync(wcfParameters);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();
                var model = ConvertToGalaxyPanelEditingDataCommonBasic(result);
                //model.InterfaceBoardSectionModes = null;

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


        private async Task<ApiEntities.GalaxyPanelEditingDataCommonBasic> GetCommonEditingDataBasic(string includeProperties)
        {
            var mgr = Helpers.GetManager<GalaxyPanelManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

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
                    typeof(WcfEntities.GalaxyPanelEditingData).GetComplexProperties().ToList();
                foreach (var p in responseProperties)
                {
                    var included = includeProps.FirstOrDefault(o => o.TrimStart().TrimEnd().ToLower() == p.Name.ToLower());
                    if (included == null)
                        wcfParameters.ExcludeMemberCollectionSettings.Add(p.Name);
                }
            }

            var excludeClusterSpecificProperties =
                typeof(ApiEntities.GalaxyPanelEditingDataBasic).GetComplexProperties();
            foreach (var p in excludeClusterSpecificProperties)
            {
                if (!wcfParameters.IsExcluded(p.Name))
                    wcfParameters.ExcludeMemberCollectionSettings.Add(p.Name);
            }

            var result = await mgr.GetGalaxyPanelEditingDataAsync(wcfParameters);

            if (mgr.HasErrors)
            {
                return null;
            }
            var model = ConvertToGalaxyPanelEditingDataCommonBasic(result);
            return model;
        }
        private ApiEntities.GalaxyPanelEditingDataCommonBasic ConvertToGalaxyPanelEditingDataCommonBasic(WcfEntities.GalaxyPanelEditingData result)
        {
            var model = Mapper.Map<ApiEntities.GalaxyPanelEditingDataCommonBasic>(result);
            foreach (var ibt in model.InterfaceBoardTypes)
            {
                ibt.InterfaceBoardSectionModes = Mapper.Map<ICollection<ApiEntities.InterfaceBoardSectionModeBasic>>(result.InterfaceBoardSectionModes.Where(o => o.InterfaceBoardTypeUid == ibt.InterfaceBoardTypeUid).ToCollection());
            }

            return model;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Create a new Galaxy panel.
        /// </summary>
        /// <remarks>   IgnoreProperties: Cpus, InterfaceBoards, AlertEvents, InterfaceBoardSections, GalaxyHardwareModules, GalaxyInterfaceBoardSectionNodes</remarks>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.GalaxyPanel&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GalaxyPanelPutReq>> Post(RequestModels.SaveParams<RequestModels.GalaxyPanelReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (parameters.Data.ClusterUid == Guid.Empty)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot add GalaxyPanel with ClusterUid value of {parameters.Data.ClusterUid}");

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                if (parameters.Data.InterfaceBoards == null)
                    parameters.Data.InterfaceBoards = new List<RequestModels.GalaxyInterfaceBoardReq>();
                if (parameters.Data.AlertEvents == null)
                    parameters.Data.AlertEvents = new List<RequestModels.GalaxyPanelAlertEventReq>();

                var boardIndex = 0;
                // Validate, Convert Enum to appropriate UID values and Build up the hardware correctly
                foreach (var b in parameters.Data.InterfaceBoards)
                {
                    var boardCount = parameters.Data.InterfaceBoards.Count(o => o.BoardNumber == b.BoardNumber);
                    if (boardCount > 1)
                    {
                        var validationProblems = new Dictionary<string, string[]>();
                        var errorsArray = new List<string>();
                        errorsArray.Add($"There are {boardCount} boards specified with BoardNumber {b.BoardNumber}. BoardNumbers must be unique.");
                        validationProblems.Add($"{nameof(WcfEntities.GalaxyInterfaceBoard)}[{boardIndex}]", errorsArray.ToArray());
                        return ValidationProblem(new ValidationProblemDetails(validationProblems));
                    }

                    if (b.InterfaceBoardTypeUid == Guid.Empty)
                    {
                        b.InterfaceBoardTypeUid = GetInterfaceBoardTypeUidFromBoardType(b.BoardType);
                    }

                    if (b.InterfaceBoardSections != null)
                    {
                        foreach (var s in b.InterfaceBoardSections)
                        {
                            if (s.InterfaceBoardSectionModeUid == Guid.Empty)
                                s.InterfaceBoardSectionModeUid =
                                    GetInterfaceBoardSectionModeUidFromSectionMode(b.InterfaceBoardTypeUid, s.SectionMode);
                        }
                    }
                }

                foreach (var ae in parameters.Data.AlertEvents)
                {
                    switch (ae.AlertEventType)
                    {
                        case GalaxyPanelAlertEventType.ACFailure:
                            ae.GalaxyPanelAlertEventTypeUid =
                                GalaxyPanelAlertEventTypeIds.ACFailure;
                            break;

                        case GalaxyPanelAlertEventType.LowBattery:
                            ae.GalaxyPanelAlertEventTypeUid =
                                GalaxyPanelAlertEventTypeIds.LowBattery;
                            break;

                        case GalaxyPanelAlertEventType.Tamper:
                            ae.GalaxyPanelAlertEventTypeUid =
                                GalaxyPanelAlertEventTypeIds.Tamper;
                            break;

                        case GalaxyPanelAlertEventType.EmergencyUnlock:
                            ae.GalaxyPanelAlertEventTypeUid =
                                GalaxyPanelAlertEventTypeIds.EmergencyUnlock;
                            break;

                        default:
                            if (ae.GalaxyPanelAlertEventTypeUid == GalaxyPanelAlertEventTypeIds.ACFailure)
                                ae.AlertEventType = GalaxyPanelAlertEventType.ACFailure;
                            else if (ae.GalaxyPanelAlertEventTypeUid == GalaxyPanelAlertEventTypeIds.LowBattery)
                                ae.AlertEventType = GalaxyPanelAlertEventType.LowBattery;
                            else if (ae.GalaxyPanelAlertEventTypeUid == GalaxyPanelAlertEventTypeIds.Tamper)
                                ae.AlertEventType = GalaxyPanelAlertEventType.Tamper;
                            else if (ae.GalaxyPanelAlertEventTypeUid == GalaxyPanelAlertEventTypeIds.EmergencyUnlock)
                                ae.AlertEventType = GalaxyPanelAlertEventType.EmergencyUnlock;
                            else
                                return BadRequest($"Unsupported alert event tag: {ae.AlertEventType}");
                            break;
                    }
                }

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.GalaxyPanel>(parameters.Data);
                wcfEntity.ConcurrencyValue = 0;

                var cpuTypeUid = Guid.Empty;
                if (wcfEntity.GalaxyPanelModelUid.HasValue == false || wcfEntity.GalaxyPanelModelUid == Guid.Empty)
                {
                    switch (parameters.Data.GalaxyPanelModel)
                    {
                        //case GalaxyPanelModel.GalaxyPanel5xx:
                        //    if (wcfEntity.PanelNumber > 254)
                        //        return BadRequest($"Cannot add GalaxyPanel with PanelNumber > 254 for model {parameters.Data.GalaxyPanelModel}");
                        //    wcfEntity.GalaxyPanelModelUid = GalaxyPanelTypeIds.GalaxyPanelType_500;
                        //    cpuTypeUid = GalaxyCpuTypeIds.GalaxyCpuType_500;
                        //    break;
                        //case GalaxyPanelModel.GalaxyPanel600:
                        //    if (wcfEntity.PanelNumber > 254)
                        //        return BadRequest($"Cannot add GalaxyPanel with PanelNumber > 254 for model {parameters.Data.GalaxyPanelModel}");

                        //    wcfEntity.GalaxyPanelModelUid = GalaxyPanelTypeIds.GalaxyPanelType_600;
                        //    cpuTypeUid = GalaxyCpuTypeIds.GalaxyCpuType_600;
                        //    break;
                        case GalaxyPanelModel.GalaxyPanel708:
                            wcfEntity.GalaxyPanelModelUid = GalaxyPanelTypeIds.GalaxyPanelType_708;
                            cpuTypeUid = GalaxyCpuTypeIds.GalaxyCpuType_708;
                            break;
                        case GalaxyPanelModel.GalaxyPanel635:
                        default:
                            wcfEntity.GalaxyPanelModelUid = GalaxyPanelTypeIds.GalaxyPanelType_635;
                            cpuTypeUid = GalaxyCpuTypeIds.GalaxyCpuType_635;
                            break;
                    }
                }

                foreach (var cpu in wcfEntity.Cpus)
                {
                    cpu.GalaxyCpuModelUid = cpuTypeUid;
                }

                foreach (var b in parameters.Data.InterfaceBoards)
                {
                    var wcfBoards = wcfEntity.InterfaceBoards.Where(o => o.BoardNumber == b.BoardNumber).ToList();
                    if (wcfBoards.Count == 0)
                        continue;
                    if (wcfBoards.Count > 1)
                        return BadRequest($"There are {wcfBoards.Count} boards with board number: {b.BoardNumber}. This is not permitted.");
                    var wcfBoard = wcfBoards.First();

                    var wcfSections = wcfBoard.InterfaceBoardSections.ToList();

                    switch (b.BoardType)
                    {
                        case GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
                            wcfBoard.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface600;
                            foreach (var wcfSection in wcfSections)
                            {
                                wcfSection.InterfaceBoardSectionModeUid = DualReaderInterface600ModeIds.ReaderInterfaceMode_AccessPortal;
                            }
                            break;

                        case GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
                            wcfBoard.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635;
                            foreach (var wcfSection in wcfSections)
                            {
                                wcfSection.InterfaceBoardSectionModeUid = DualReaderInterface635ModeIds.ReaderInterfaceMode_AccessPortal;
                            }
                            break;

                        case GalaxyInterfaceBoardType.DigitalInputOutputBoard600:
                            wcfBoard.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DigitalInputOutput600;
                            break;

                        case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                        case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                            wcfBoard.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface635;
                            foreach (var wcfSection in wcfSections)
                            {
                                var s = b.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == wcfSection.SectionNumber);
                                if (s != null)
                                {
                                    switch (s.SectionMode)
                                    {
                                        case PanelInterfaceBoardSectionType.ElevatorRelays:
                                            wcfSection.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_ElevatorRelays;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RelayModule8;
                                            break;
                                        case PanelInterfaceBoardSectionType.CypressClockDisplay:
                                            wcfSection.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_CypressClockDisplay;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_CypressLCD;
                                            break;
                                        case PanelInterfaceBoardSectionType.OutputRelays:
                                            wcfSection.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_OutputRelays;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RelayModule8;
                                            break;
                                        case PanelInterfaceBoardSectionType.AllegionPimWiegand:
                                            wcfSection.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AllegionPIM;
                                            break;
                                        case PanelInterfaceBoardSectionType.AllegionPimAba:
                                            wcfSection.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimAba;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AllegionPIM;
                                            break;
                                        case PanelInterfaceBoardSectionType.LCD_4x20Display:
                                            wcfSection.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_LCD_4x20Display;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_CypressLCD;
                                            break;
                                        case PanelInterfaceBoardSectionType.RS485DoorModule:
                                            wcfSection.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485DoorModule;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RemoteDoorModule;
                                            break;
                                        case PanelInterfaceBoardSectionType.AssaAbloyAperio:
                                            wcfSection.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AssaAbloyAperioHub;
                                            break;
                                        case PanelInterfaceBoardSectionType.SaltoSallis:
                                            wcfSection.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_SaltoSallis;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_SaltoSallisHub;
                                            break;
                                        case PanelInterfaceBoardSectionType.RS485InputModule:
                                            wcfSection.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485InputModule;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_InputModule16;
                                            break;
                                        case PanelInterfaceBoardSectionType.Unused:
                                        case PanelInterfaceBoardSectionType.DrmSection:
                                        case PanelInterfaceBoardSectionType.Dio8X4Outputs:
                                        case PanelInterfaceBoardSectionType.Dio8X4Inputs:
                                        case PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                                        //case PanelInterfaceBoardSectionType.CardTourManagerCpu:
                                        case PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                                        case PanelInterfaceBoardSectionType.VeridtCpu:
                                        case PanelInterfaceBoardSectionType.VeridtReader:
                                        default:
                                            break;
                                    }
                                }
                            }
                            break;

                        case GalaxyInterfaceBoardType.OtisElevatorInterface:
                            wcfBoard.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_OtisElevatorInterface;
                            break;

                        //case GalaxyInterfaceBoardType.CardTourManagerCpu:
                        //    wcfBoard.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_CardTourManager;
                        //    break;

                        case GalaxyInterfaceBoardType.KoneElevatorInterface:
                            wcfBoard.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_KoneElevatorInterface;
                            break;
                        case GalaxyInterfaceBoardType.Veridt_Cpu:
                            wcfBoard.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_Cpu;
                            break;
                        case GalaxyInterfaceBoardType.Veridt_ReaderModule:
                            wcfBoard.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_ReaderModule;
                            break;

                        case GalaxyInterfaceBoardType.None:
                            if (wcfBoard.InterfaceBoardTypeUid == Guid.Empty)
                                return BadRequest($"Unsupported board type: {b.BoardType}");
                            if (wcfBoard.InterfaceBoardTypeUid == GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DigitalInputOutput600)
                                b.BoardType = GalaxyInterfaceBoardType.DigitalInputOutputBoard600;
                            else if (wcfBoard.InterfaceBoardTypeUid == GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface600)
                                b.BoardType = GalaxyInterfaceBoardType.DualReaderInterfaceBoard600;
                            if (wcfBoard.InterfaceBoardTypeUid == GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface600)
                                b.BoardType = GalaxyInterfaceBoardType.DualReaderInterfaceBoard635;
                            if (wcfBoard.InterfaceBoardTypeUid == GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635)
                                b.BoardType = GalaxyInterfaceBoardType.DualReaderInterfaceBoard635;
                            if (wcfBoard.InterfaceBoardTypeUid == GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface635)
                                b.BoardType = GalaxyInterfaceBoardType.DualSerialInterfaceBoard635;
                            if (wcfBoard.InterfaceBoardTypeUid == GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_KoneElevatorInterface)
                                b.BoardType = GalaxyInterfaceBoardType.KoneElevatorInterface;
                            if (wcfBoard.InterfaceBoardTypeUid == GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_OtisElevatorInterface)
                                b.BoardType = GalaxyInterfaceBoardType.OtisElevatorInterface;
                            else BadRequest($"Unsupported board type: {b.BoardType}");
                            break;

                        case GalaxyInterfaceBoardType.Cpu600:
                        case GalaxyInterfaceBoardType.Cpu635:
                        case GalaxyInterfaceBoardType.DualPortInterfaceBoard500:
                        default:
                            return BadRequest($"Unsupported board type: {b.BoardType}");
                    }
                }

                foreach (var ae in parameters.Data.AlertEvents)
                {
                    var wcfAlertEvent = wcfEntity.AlertEvents.FirstOrDefault(o => o.GalaxyPanelAlertEventTypeUid == ae.GalaxyPanelAlertEventTypeUid);
                    if (!string.IsNullOrEmpty(ae.UserInstructions))
                    {
                        wcfAlertEvent ??= new WcfEntities.GalaxyPanelAlertEvent();
                        wcfAlertEvent.Note ??= new WcfEntities.Note();
                        wcfAlertEvent.Note.Category =
                            NoteCategories.GalaxyPanelAlertEventInstructions;
                        if (wcfAlertEvent.Note.NoteText != ae.UserInstructions)
                        {
                            wcfAlertEvent.Note.NoteText = ae.UserInstructions;
                            wcfAlertEvent.Note.IsDirty = true;
                        }
                    }
                }

                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.GalaxyPanel>(wcfEntity, wcfSaveParameters);
                var mgr = Helpers.GetManager<GalaxyPanelManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var validationProblemDetails = await mgr.ValidateGalaxyPanelAsync(wcfParams);
                if (validationProblemDetails != null)
                {
                    if (validationProblemDetails is { IsValid: false })
                    {
                        return ValidationProblem(new ValidationProblemDetails(validationProblemDetails.Errors));
                    }
                }

                wcfParams.IncludeMemberCollections = true;

                var results = await mgr.SaveGalaxyPanelAsync(wcfParams);
                if (results != null)
                {
                    var savedItem = Mapper.Map<GalaxyPanelPutReq>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "GalaxyPanel",
                        new { galaxyPanelUid = savedItem.GalaxyPanelUid });
                    if (results.UpdateDate > results.InsertDate)
                        return Ok(savedItem);
                    return Created(url, savedItem);
                }
                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
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

        private Guid GetInterfaceBoardSectionModeUidFromSectionMode(Guid interfaceBoardTypeUid, PanelInterfaceBoardSectionType sectionMode)
        {
            if (interfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface600)
            {   // there must be two sections, numbered 1 & 2
                if (sectionMode == PanelInterfaceBoardSectionType.AccessPortal)
                    return DualReaderInterface635ModeIds.ReaderInterfaceMode_AccessPortal;
                return DualReaderInterface635ModeIds.ReaderInterfaceMode_Unused;
            }
            if (interfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635)
            {
                if (sectionMode == PanelInterfaceBoardSectionType.AccessPortal)
                    return DualReaderInterface635ModeIds.ReaderInterfaceMode_AccessPortal;
                return DualReaderInterface635ModeIds.ReaderInterfaceMode_Unused;
            }
            if (interfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface635)
            {
                switch (sectionMode)
                {
                    case PanelInterfaceBoardSectionType.AllegionPimAba:
                        return DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimAba;

                    case PanelInterfaceBoardSectionType.AllegionPimWiegand:
                        return DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand;

                    case PanelInterfaceBoardSectionType.AssaAbloyAperio:
                        return DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio;

                    case PanelInterfaceBoardSectionType.CypressClockDisplay:
                        return DualSerialInterface635ChannelModeIds.DualSerialChannelMode_CypressClockDisplay;

                    case PanelInterfaceBoardSectionType.ElevatorRelays:
                        return DualSerialInterface635ChannelModeIds.DualSerialChannelMode_ElevatorRelays;

                    case PanelInterfaceBoardSectionType.LCD_4x20Display:
                        return DualSerialInterface635ChannelModeIds.DualSerialChannelMode_LCD_4x20Display;

                    case PanelInterfaceBoardSectionType.OutputRelays:
                        return DualSerialInterface635ChannelModeIds.DualSerialChannelMode_OutputRelays;

                    case PanelInterfaceBoardSectionType.SaltoSallis:
                        return DualSerialInterface635ChannelModeIds.DualSerialChannelMode_SaltoSallis;

                    case PanelInterfaceBoardSectionType.RS485DoorModule:
                        return DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485DoorModule;

                    case PanelInterfaceBoardSectionType.RS485InputModule:
                        return DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485InputModule;
                    
                    case PanelInterfaceBoardSectionType.Unused:
                        return DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Unused;

                    case PanelInterfaceBoardSectionType.DrmSection:
                    case PanelInterfaceBoardSectionType.Dio8X4Outputs:
                    case PanelInterfaceBoardSectionType.Dio8X4Inputs:
                    case PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                    //case PanelInterfaceBoardSectionType.CardTourManagerCpu:
                    case PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                    case PanelInterfaceBoardSectionType.VeridtCpu:
                    case PanelInterfaceBoardSectionType.VeridtReader:
                        break;
                }
            }
            else if (interfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DigitalInputOutput600)
            {

            }
            else if (interfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_KoneElevatorInterface)
            {

            }
            else if (interfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_OtisElevatorInterface)
            {

            }
            else if (interfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_Cpu)
            {

            }
            else if (interfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_ReaderModule)
            {

            }

            return DualReaderInterface635ModeIds.ReaderInterfaceMode_Unused;

        }

        private Guid GetInterfaceBoardTypeUidFromBoardType(GalaxyInterfaceBoardType boardType)
        {
            switch (boardType)
            {
                case GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
                    return GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface600;

                case GalaxyInterfaceBoardType.DigitalInputOutputBoard600:
                    return GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DigitalInputOutput600;

                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                    return GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface635;

                case GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
                    return GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635;

                case GalaxyInterfaceBoardType.OtisElevatorInterface:
                    return GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_OtisElevatorInterface;

                case GalaxyInterfaceBoardType.KoneElevatorInterface:
                    return GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_KoneElevatorInterface;

                case GalaxyInterfaceBoardType.Veridt_ReaderModule:
                    return GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_ReaderModule;

                case GalaxyInterfaceBoardType.Veridt_Cpu:
                    return GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_Cpu;

                default:
                    return Guid.Empty;
            }
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Create a new Galaxy panel.
        /// </summary>
        /// <remarks>   IgnoreProperties: InterfaceBoardSections, GalaxyHardwareModules, GalaxyInterfaceBoardSectionNodes</remarks>
        /// <param name="galaxyPanelUid">   The uid of the panel to add the board to. </param>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.GalaxyPanel&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("{galaxyPanelUid}/board")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GalaxyInterfaceBoardPutReq>> PostBoard(Guid galaxyPanelUid, RequestModels.SaveParams<RequestModels.GalaxyInterfaceBoardReq> parameters/*, bool createDefaultModulesAndNodes = true, bool defaultIsActive = true*/)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (galaxyPanelUid == Guid.Empty)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot add board with GalaxyPanelUid value of {galaxyPanelUid}");

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgrPanel = Helpers.GetManager<GalaxyPanelManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetPanelParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = galaxyPanelUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = true
                };
                wcfGetPanelParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.GalaxyPanel.AlertEvents));
                wcfGetPanelParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.GalaxyPanel.Cpus));

                var wcfGalaxyPanel = await mgrPanel.GetGalaxyPanelAsync(wcfGetPanelParams);
                if (wcfGalaxyPanel == null)
                    return NotFound($"GalaxyPanel with GalaxyPanelUid:{galaxyPanelUid} is not found");

                var existingBoard = wcfGalaxyPanel.InterfaceBoards.FirstOrDefault(o => o.BoardNumber == parameters.Data.BoardNumber);
                if (existingBoard != null)
                    return BadRequest($"There is already a board with board number: {parameters.Data.BoardNumber}. This is not permitted.");

                //var commonEditorData = await GetCommonEditingDataBasic($"{nameof(WcfEntities.GalaxyPanelEditingData.InterfaceBoardTypes)},{nameof(WcfEntities.GalaxyPanelEditingData.InterfaceBoardSectionModes)},{nameof(WcfEntities.GalaxyPanelEditingData.GalaxyHardwareModuleTypes)}");

                //var validationProblemDetails = await ValidateInterfaceBoardProperties(parameters.Data, 0, commonEditorData);
                //if (validationProblemDetails != null)
                //    return ValidationProblem(validationProblemDetails);
                if (parameters.Data.InterfaceBoardTypeUid == Guid.Empty)
                    parameters.Data.InterfaceBoardTypeUid =
                        GetInterfaceBoardTypeUidFromBoardType(parameters.Data.BoardType);

                if (parameters.Data.InterfaceBoardSections != null)
                {
                    foreach (var s in parameters.Data.InterfaceBoardSections)
                    {
                        if (s.InterfaceBoardSectionModeUid == Guid.Empty)
                            s.InterfaceBoardSectionModeUid =
                                GetInterfaceBoardSectionModeUidFromSectionMode(parameters.Data.InterfaceBoardTypeUid,
                                    s.SectionMode);
                    }
                }

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfBoard = Mapper.Map<WcfEntities.GalaxyInterfaceBoard>(parameters.Data);
                wcfBoard.GalaxyPanelUid = wcfGalaxyPanel.GalaxyPanelUid;
                wcfBoard.ConcurrencyValue = 0;

                var wcfSections = wcfBoard.InterfaceBoardSections.ToList();

                if (parameters.Data.InterfaceBoardTypeUid == Guid.Empty)
                {
                    switch (parameters.Data.BoardType)
                    {
                        case GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
                            wcfBoard.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds
                                .GalaxyInterfaceBoardType_DualReaderInterface600;
                            //foreach (var wcfSection in wcfSections)
                            //{
                            //    wcfSection.InterfaceBoardSectionModeUid = DualReaderInterface600ModeIds.ReaderInterfaceMode_AccessPortal;
                            //}
                            break;

                        case GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
                            wcfBoard.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds
                                .GalaxyInterfaceBoardType_DualReaderInterface635;
                            //foreach (var wcfSection in wcfSections)
                            //{
                            //    wcfSection.InterfaceBoardSectionModeUid = DualReaderInterface635ModeIds.ReaderInterfaceMode_AccessPortal;
                            //}
                            break;

                        case GalaxyInterfaceBoardType.DigitalInputOutputBoard600:
                            wcfBoard.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds
                                .GalaxyInterfaceBoardType_DigitalInputOutput600;
                            break;

                        case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                        case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                            wcfBoard.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds
                                .GalaxyInterfaceBoardType_DualSerialInterface635;
                            foreach (var wcfSection in wcfSections)
                            {
                                var s = parameters.Data.InterfaceBoardSections.FirstOrDefault(o =>
                                    o.SectionNumber == wcfSection.SectionNumber);
                                if (s != null)
                                {
                                    switch (s.SectionMode)
                                    {
                                        case PanelInterfaceBoardSectionType.ElevatorRelays:
                                            wcfSection.InterfaceBoardSectionModeUid =
                                                DualSerialInterface635ChannelModeIds
                                                    .DualSerialChannelMode_ElevatorRelays;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxyHardwareModuleTypeIds
                                                    .GalaxyHardwareModuleType_RelayModule8;
                                            break;
                                        case PanelInterfaceBoardSectionType.CypressClockDisplay:
                                            wcfSection.InterfaceBoardSectionModeUid =
                                                DualSerialInterface635ChannelModeIds
                                                    .DualSerialChannelMode_CypressClockDisplay;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxyHardwareModuleTypeIds
                                                    .GalaxyHardwareModuleType_CypressLCD;
                                            break;
                                        case PanelInterfaceBoardSectionType.OutputRelays:
                                            wcfSection.InterfaceBoardSectionModeUid =
                                                DualSerialInterface635ChannelModeIds.DualSerialChannelMode_OutputRelays;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxyHardwareModuleTypeIds
                                                    .GalaxyHardwareModuleType_RelayModule8;
                                            break;
                                        case PanelInterfaceBoardSectionType.AllegionPimWiegand:
                                            wcfSection.InterfaceBoardSectionModeUid =
                                                DualSerialInterface635ChannelModeIds
                                                    .DualSerialChannelMode_AllegionPimWiegand;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxyHardwareModuleTypeIds
                                                    .GalaxyHardwareModuleType_AllegionPIM;
                                            break;
                                        case PanelInterfaceBoardSectionType.AllegionPimAba:
                                            wcfSection.InterfaceBoardSectionModeUid =
                                                DualSerialInterface635ChannelModeIds
                                                    .DualSerialChannelMode_AllegionPimAba;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxyHardwareModuleTypeIds
                                                    .GalaxyHardwareModuleType_AllegionPIM;
                                            break;
                                        case PanelInterfaceBoardSectionType.LCD_4x20Display:
                                            wcfSection.InterfaceBoardSectionModeUid =
                                                DualSerialInterface635ChannelModeIds
                                                    .DualSerialChannelMode_LCD_4x20Display;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxyHardwareModuleTypeIds
                                                    .GalaxyHardwareModuleType_CypressLCD;
                                            break;
                                        case PanelInterfaceBoardSectionType.RS485DoorModule:
                                            wcfSection.InterfaceBoardSectionModeUid =
                                                DualSerialInterface635ChannelModeIds
                                                    .DualSerialChannelMode_RS485DoorModule;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxyHardwareModuleTypeIds
                                                    .GalaxyHardwareModuleType_RemoteDoorModule;
                                            break;
                                        case PanelInterfaceBoardSectionType.AssaAbloyAperio:
                                            wcfSection.InterfaceBoardSectionModeUid =
                                                DualSerialInterface635ChannelModeIds
                                                    .DualSerialChannelMode_AssaAbloyAperio;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxyHardwareModuleTypeIds
                                                    .GalaxyHardwareModuleType_AssaAbloyAperioHub;
                                            break;
                                        case PanelInterfaceBoardSectionType.SaltoSallis:
                                            wcfSection.InterfaceBoardSectionModeUid =
                                                DualSerialInterface635ChannelModeIds.DualSerialChannelMode_SaltoSallis;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxyHardwareModuleTypeIds
                                                    .GalaxyHardwareModuleType_SaltoSallisHub;
                                            break;
                                        case PanelInterfaceBoardSectionType.RS485InputModule:
                                            wcfSection.InterfaceBoardSectionModeUid =
                                                DualSerialInterface635ChannelModeIds
                                                    .DualSerialChannelMode_RS485InputModule;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxyHardwareModuleTypeIds
                                                    .GalaxyHardwareModuleType_InputModule16;
                                            break;
                                        case PanelInterfaceBoardSectionType.Unused:
                                        case PanelInterfaceBoardSectionType.DrmSection:
                                        case PanelInterfaceBoardSectionType.Dio8X4Outputs:
                                        case PanelInterfaceBoardSectionType.Dio8X4Inputs:
                                        case PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                                        //case PanelInterfaceBoardSectionType.CardTourManagerCpu:
                                        case PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                                        case PanelInterfaceBoardSectionType.VeridtCpu:
                                        case PanelInterfaceBoardSectionType.VeridtReader:
                                        default:
                                            break;
                                    }
                                }
                            }

                            break;

                        case GalaxyInterfaceBoardType.OtisElevatorInterface:
                            wcfBoard.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds
                                .GalaxyInterfaceBoardType_OtisElevatorInterface;
                            break;

                        //case GalaxyInterfaceBoardType.CardTourManagerCpu:
                        //    wcfBoard.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_CardTourManager;
                        //    break;

                        case GalaxyInterfaceBoardType.KoneElevatorInterface:
                            wcfBoard.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds
                                .GalaxyInterfaceBoardType_KoneElevatorInterface;
                            break;
                        case GalaxyInterfaceBoardType.Veridt_Cpu:
                            wcfBoard.InterfaceBoardTypeUid =
                                GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_Cpu;
                            break;
                        case GalaxyInterfaceBoardType.Veridt_ReaderModule:
                            wcfBoard.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds
                                .GalaxyInterfaceBoardType_Veridt_ReaderModule;
                            break;

                        case GalaxyInterfaceBoardType.None:
                        case GalaxyInterfaceBoardType.Cpu600:
                        case GalaxyInterfaceBoardType.Cpu635:
                        case GalaxyInterfaceBoardType.DualPortInterfaceBoard500:
                        default:
                            return BadRequest($"Unsupported board type: {parameters.Data.BoardType}");

                    }
                }

                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.GalaxyInterfaceBoard>(wcfBoard, wcfSaveParameters);

                //wcfParams.Options.Add(new KeyValuePair<string, string>(SaveGalaxyInterfaceBoardOption.CreateDefaultModulesAndNodes.ToString(), createDefaultModulesAndNodes.ToString()));
                //wcfParams.Options.Add(new KeyValuePair<string, string>(SaveGalaxyInterfaceBoardOption.DefaultIsActiveValue.ToString(), defaultIsActive.ToString()));

                var mgr = Helpers.GetManager<GalaxyInterfaceBoardManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var validationProblemDetails = await mgr.ValidateGalaxyInterfaceBoardAsync(wcfParams);
                if (validationProblemDetails != null)
                {
                    if (validationProblemDetails is { IsValid: false })
                    {
                        return ValidationProblem(new ValidationProblemDetails(validationProblemDetails.Errors));
                    }
                }


                var results = await mgr.SaveGalaxyInterfaceBoardAsync(wcfParams);
                if (results != null)
                {
                    var savedItem = Mapper.Map<GalaxyInterfaceBoardPutReq>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "GalaxyPanel",
                        new { galaxyPanelUid = savedItem.GalaxyPanelUid });
                    if (results.UpdateDate > results.InsertDate)
                        return Ok(savedItem);
                    return Created(url, savedItem);
                }
                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
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
        /// Update an existing Galaxy Panel item. Can also create a new panel.
        /// </summary>
        /// <remarks>   IgnoreProperties: Cpus, InterfaceBoards, AlertEvents, InterfaceBoardSections, GalaxyHardwareModules, GalaxyInterfaceBoardSectionNodes</remarks>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.GalaxyPanel&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<GalaxyPanelPutReq>> Put(RequestModels.SaveParams<RequestModels.GalaxyPanelPutReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (parameters.Data.ClusterUid == Guid.Empty)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot update GalaxyPanel with ClusterUid value of {parameters.Data.ClusterUid}");
                //if (parameters.Data.GalaxyPanelUid == Guid.Empty)
                //    return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot update GalaxyPanel with GalaxyPanelUid value of {parameters.Data.GalaxyPanelUid}");

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgr = Helpers.GetManager<GalaxyPanelManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.GalaxyPanel>(parameters.Data);
                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.GalaxyPanel>(wcfEntity, wcfSaveParameters);

                // If Cpus is null or empty, set the Ignore property so the server doesn't do anything with Cpus
                if (parameters.Data?.Cpus == null || parameters.Data?.Cpus?.Count == 0)
                    wcfParams.IgnoreProperties.Add(nameof(parameters.Data.Cpus));

                // If InterfaceBoards is null or empty, set the Ignore property so the server doesn't do anything with InterfaceBoards
                if (parameters.Data?.InterfaceBoards == null || parameters.Data?.InterfaceBoards?.Count == 0)
                    wcfParams.IgnoreProperties.Add(nameof(parameters.Data.InterfaceBoards));
                else
                {
                    var boardIndex = 0;
                    foreach (var b in parameters.Data.InterfaceBoards)
                    {
                        var boardCount = parameters.Data.InterfaceBoards.Count(o => o.BoardNumber == b.BoardNumber);
                        if (boardCount > 1)
                        {
                            var validationProblems = new Dictionary<string, string[]>();
                            var errorsArray = new List<string>();
                            errorsArray.Add($"There are {boardCount} boards specified with BoardNumber {b.BoardNumber}. BoardNumbers must be unique.");
                            validationProblems.Add($"{nameof(WcfEntities.GalaxyInterfaceBoard)}[{boardIndex}]", errorsArray.ToArray());
                            return ValidationProblem(new ValidationProblemDetails(validationProblems));
                        }

                        if (b.InterfaceBoardTypeUid == Guid.Empty)
                        {
                            b.InterfaceBoardTypeUid = GetInterfaceBoardTypeUidFromBoardType(b.BoardType);
                        }

                        if (b.InterfaceBoardSections != null)
                        {
                            foreach (var s in b.InterfaceBoardSections)
                            {
                                if (s.InterfaceBoardSectionModeUid == Guid.Empty)
                                    s.InterfaceBoardSectionModeUid =
                                        GetInterfaceBoardSectionModeUidFromSectionMode(b.InterfaceBoardTypeUid,
                                            s.SectionMode);
                            }
                        }
                    }
                }
                // If AlertEvents is null or empty, set the Ignore property so the server doesn't do anything with AlertEvents
                if (parameters.Data?.AlertEvents == null || parameters.Data?.AlertEvents?.Count == 0)
                    wcfParams.IgnoreProperties.Add(nameof(parameters.Data.AlertEvents));
                else
                {
                    foreach (var ae in parameters.Data.AlertEvents)
                    {
                        switch (ae.AlertEventType)
                        {
                            case GalaxyPanelAlertEventType.ACFailure:
                                ae.GalaxyPanelAlertEventTypeUid =
                                    GalaxyPanelAlertEventTypeIds.ACFailure;
                                break;

                            case GalaxyPanelAlertEventType.LowBattery:
                                ae.GalaxyPanelAlertEventTypeUid =
                                    GalaxyPanelAlertEventTypeIds.LowBattery;
                                break;

                            case GalaxyPanelAlertEventType.Tamper:
                                ae.GalaxyPanelAlertEventTypeUid =
                                    GalaxyPanelAlertEventTypeIds.Tamper;
                                break;

                            case GalaxyPanelAlertEventType.EmergencyUnlock:
                                ae.GalaxyPanelAlertEventTypeUid =
                                    GalaxyPanelAlertEventTypeIds.EmergencyUnlock;
                                break;

                            default:
                                if (ae.GalaxyPanelAlertEventTypeUid == GalaxyPanelAlertEventTypeIds.ACFailure)
                                    ae.AlertEventType = GalaxyPanelAlertEventType.ACFailure;
                                else if (ae.GalaxyPanelAlertEventTypeUid == GalaxyPanelAlertEventTypeIds.LowBattery)
                                    ae.AlertEventType = GalaxyPanelAlertEventType.LowBattery;
                                else if (ae.GalaxyPanelAlertEventTypeUid == GalaxyPanelAlertEventTypeIds.Tamper)
                                    ae.AlertEventType = GalaxyPanelAlertEventType.Tamper;
                                else if (ae.GalaxyPanelAlertEventTypeUid == GalaxyPanelAlertEventTypeIds.EmergencyUnlock)
                                    ae.AlertEventType = GalaxyPanelAlertEventType.EmergencyUnlock;
                                else 
                                    return BadRequest($"Unsupported alert event tag: {ae.AlertEventType}");
                                break;
                        }
                        var wcfAlertEvent = wcfEntity.AlertEvents.FirstOrDefault(o =>
                            o.GalaxyPanelAlertEventTypeUid == ae.GalaxyPanelAlertEventTypeUid);
                        if (!string.IsNullOrEmpty(ae.UserInstructions))
                        {
                            wcfAlertEvent ??= new WcfEntities.GalaxyPanelAlertEvent();
                            wcfAlertEvent.Note ??= new WcfEntities.Note();
                            wcfAlertEvent.Note.Category =
                                NoteCategories.GalaxyPanelAlertEventInstructions;
                            if (wcfAlertEvent.Note.NoteText != ae.UserInstructions)
                            {
                                wcfAlertEvent.Note.NoteText = ae.UserInstructions;
                                wcfAlertEvent.Note.IsDirty = true;
                            }
                        }
                    }
                }

                var validationProblemDetails = await mgr.ValidateGalaxyPanelAsync(wcfParams);
                if (validationProblemDetails != null)
                {
                    if (validationProblemDetails is { IsValid: false })
                    {
                        return ValidationProblem(new ValidationProblemDetails(validationProblemDetails.Errors));
                    }
                }

                wcfParams.IncludeMemberCollections = true;

                var results = await mgr.SaveGalaxyPanelAsync(wcfParams);
                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var savedItem = Mapper.Map<GalaxyPanelPutReq>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "GalaxyPanel",
                        new { galaxyPanelUid = savedItem.GalaxyPanelUid });
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
        /// Update an existing Galaxy Interface Board item. Can also create a new board.
        /// </summary>
        /// <remarks>   IgnoreProperties: InterfaceBoardSections, GalaxyHardwareModules, GalaxyInterfaceBoardSectionNodes</remarks>
        /// <param name="galaxyPanelUid">   The uid of the panel that the board belongs to to. </param>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.GalaxyPanel&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("board")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<GalaxyInterfaceBoardPutReq>> PutBoard(RequestModels.SaveParams<RequestModels.GalaxyInterfaceBoardPutReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (parameters.Data.GalaxyPanelUid == Guid.Empty)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot update board with GalaxyPanelUid value of {parameters.Data.GalaxyPanelUid}");

                if (parameters.Data.GalaxyInterfaceBoardUid == Guid.Empty)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot update board with GalaxyInterfaceBoardUid value of {parameters.Data.GalaxyInterfaceBoardUid}");

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgrPanel = Helpers.GetManager<GalaxyPanelManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetPanelParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = parameters.Data.GalaxyPanelUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = true
                };
                wcfGetPanelParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.GalaxyPanel.AlertEvents));
                wcfGetPanelParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.GalaxyPanel.Cpus));

                var wcfGalaxyPanel = await mgrPanel.GetGalaxyPanelAsync(wcfGetPanelParams);
                if (wcfGalaxyPanel == null)
                    return NotFound($"GalaxyPanel with GalaxyPanelUid:{parameters.Data.GalaxyPanelUid} is not found");

                var existingBoard = wcfGalaxyPanel.InterfaceBoards.FirstOrDefault(o => o.BoardNumber == parameters.Data.BoardNumber && o.GalaxyInterfaceBoardUid != parameters.Data.GalaxyInterfaceBoardUid);
                if (existingBoard != null)
                    return BadRequest($"There is already a board with board number: {parameters.Data.BoardNumber}. This is not permitted.");

                //var commonEditorData = await GetCommonEditingDataBasic($"{nameof(WcfEntities.GalaxyPanelEditingData.InterfaceBoardTypes)},{nameof(WcfEntities.GalaxyPanelEditingData.InterfaceBoardSectionModes)},{nameof(WcfEntities.GalaxyPanelEditingData.GalaxyHardwareModuleTypes)}");

                //var validationProblemDetails = await ValidateInterfaceBoardProperties(parameters.Data, 0, commonEditorData);
                //if (validationProblemDetails != null)
                //    return ValidationProblem(validationProblemDetails);

                if (parameters.Data.InterfaceBoardTypeUid == Guid.Empty)
                    parameters.Data.InterfaceBoardTypeUid =
                        GetInterfaceBoardTypeUidFromBoardType(parameters.Data.BoardType);

                foreach (var s in parameters.Data.InterfaceBoardSections)
                {
                    if (s.InterfaceBoardSectionModeUid == Guid.Empty)
                        s.InterfaceBoardSectionModeUid =
                            GetInterfaceBoardSectionModeUidFromSectionMode(parameters.Data.InterfaceBoardTypeUid,
                                s.SectionMode);
                }

                var mgr = Helpers.GetManager<GalaxyInterfaceBoardManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.GalaxyInterfaceBoard>(parameters.Data);
                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.GalaxyInterfaceBoard>(wcfEntity, wcfSaveParameters);

                // If InterfaceBoards is null or empty, set the Ignore property so the server doesn't do anything with InterfaceBoards
                if (parameters.Data?.InterfaceBoardSections == null || parameters.Data?.InterfaceBoardSections?.Count == 0)
                    wcfParams.IgnoreProperties.Add(nameof(parameters.Data.InterfaceBoardSections));

                var validationProblemDetails = await mgr.ValidateGalaxyInterfaceBoardAsync(wcfParams);
                if (validationProblemDetails != null)
                {
                    if (validationProblemDetails is { IsValid: false })
                    {
                        return ValidationProblem(new ValidationProblemDetails(validationProblemDetails.Errors));
                    }
                }


                var results = await mgr.SaveGalaxyInterfaceBoardAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var savedItem = Mapper.Map<GalaxyInterfaceBoardPutReq>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "GalaxyPanel",
                        new { galaxyPanelUid = savedItem.GalaxyPanelUid });
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


        private async Task<ValidationProblemDetails> ValidateInterfaceBoardProperties(GalaxyInterfaceBoardReq b, int boardIndex, ApiEntities.GalaxyPanelEditingDataCommonBasic editorData)
        {
            var validationProblems = new Dictionary<string, string[]>();
            var errorsArray = new List<string>();
            // If the InterfaceBoardTypeUid is empty, then assign it the correct value based on the BoardType enum value
            if (b.InterfaceBoardTypeUid == Guid.Empty)
            {
                switch (b.BoardType)
                {
                    case GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
                        b.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface600;
                        break;

                    case GalaxyInterfaceBoardType.DigitalInputOutputBoard600:
                        b.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DigitalInputOutput600;
                        break;

                    case GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
                        b.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635;
                        break;

                    case GalaxyInterfaceBoardType.OtisElevatorInterface:
                        b.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_OtisElevatorInterface;
                        break;

                    //case GalaxyInterfaceBoardTypCardTourManagerCpu:
                    //    b.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_CardTourManager;
                    //    break;

                    case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:  // DSI-600s are obsolete. Automatically convert to DSI-635
                    case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                        b.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface635;
                        break;

                    case GalaxyInterfaceBoardType.KoneElevatorInterface:
                        b.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_KoneElevatorInterface;
                        break;

                    case GalaxyInterfaceBoardType.Veridt_Cpu:
                        b.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_Cpu;
                        break;

                    case GalaxyInterfaceBoardType.Veridt_ReaderModule:
                        b.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_ReaderModule;
                        break;

                    case GalaxyInterfaceBoardType.None:
                    case GalaxyInterfaceBoardType.Cpu600:
                    case GalaxyInterfaceBoardType.Cpu635:
                    case GalaxyInterfaceBoardType.DualPortInterfaceBoard500:
                    default:
                        errorsArray.Add($"Unsupported board type: {b.BoardType}");
                        break;
                }
            }

            var sections = new List<RequestModels.GalaxyInterfaceBoardSectionReq>();
            if (b.InterfaceBoardSections != null)
                sections = b.InterfaceBoardSections.ToList();

            var boardType = editorData.InterfaceBoardTypes.FirstOrDefault(o => o.InterfaceBoardTypeUid == b.InterfaceBoardTypeUid);
            if (boardType != null)
            {
                if (sections.Count > boardType.NumberOfSections)
                {
                    errorsArray.Add($"There are {sections.Count} sections specified. BoardType {b.BoardType} can have {boardType.NumberOfSections} sections.");
                }
            }
            var sectionIndex = 0;
            foreach (var s in sections)
            {
                var sectionCount = sections.Count(o => o.SectionNumber == s.SectionNumber);
                if (sectionCount > 1)
                {
                    errorsArray.Add($"There are {sectionCount} sections specified with SectionNumber {s.SectionNumber}. SectionNumbers must be unique.");
                }
                if (boardType != null)
                {
                    ApiEntities.InterfaceBoardSectionModeBasic sectionMode = null;
                    if (s.InterfaceBoardSectionModeUid == Guid.Empty)
                        sectionMode = boardType.InterfaceBoardSectionModes.FirstOrDefault(o => o.SectionMode.ToLower() == s.SectionMode.ToString().ToLower());
                    else
                        sectionMode = boardType.InterfaceBoardSectionModes.FirstOrDefault(o => o.InterfaceBoardSectionModeUid == s.InterfaceBoardSectionModeUid);
                    //if( sectionMode == null )
                    //{
                    //    if (s.InterfaceBoardSectionModeUid != Guid.Empty)
                    //        sectionMode = boardType.InterfaceBoardSectionModes.FirstOrDefault(o => o.InterfaceBoardSectionModeUid == s.InterfaceBoardSectionModeUid);
                    //}
                    if (sectionMode == null)
                        errorsArray.Add($"InterfaceBoardSections[{sectionIndex}].SectionMode {s.SectionMode} is not valid for BoardType {b.BoardType}.");
                    else
                        s.InterfaceBoardSectionModeUid = sectionMode.InterfaceBoardSectionModeUid;
                }
                sectionIndex++;
            }

            if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface600)
            {   // there must be two sections, numbered 1 & 2
                var invalidSections = sections.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
                foreach (var s in invalidSections)
                {
                    errorsArray.Add($"Invalid section number {s.SectionNumber}. This board type can only have section numbers 1 and 2");
                }
            }
            else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635)
            {
                var invalidSections = sections.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
                foreach (var s in invalidSections)
                {
                    //sections.Remove(s);
                    errorsArray.Add($"Invalid section number {s.SectionNumber}. This board type can only have section numbers 1 and 2");
                }
            }
            else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface635)
            {
                var invalidSections = sections.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
                foreach (var s in invalidSections)
                {
                    //sections.Remove(s);
                    errorsArray.Add($"Invalid section number {s.SectionNumber}. This board type can only have section numbers 1 and 2");
                }


                foreach (var s in sections)
                {
                    // If the InterfaceBoardSectionModeUid is not specified, then use the SectionType enum and assign the correct Uid value
                    if (s.InterfaceBoardSectionModeUid == Guid.Empty)
                    {
                        switch (s.SectionMode)
                        {
                            case PanelInterfaceBoardSectionType.AllegionPimAba:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimAba;
                                break;

                            case PanelInterfaceBoardSectionType.AllegionPimWiegand:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand;
                                break;

                            case PanelInterfaceBoardSectionType.AssaAbloyAperio:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio;
                                break;

                            case PanelInterfaceBoardSectionType.CypressClockDisplay:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_CypressClockDisplay;
                                break;

                            case PanelInterfaceBoardSectionType.ElevatorRelays:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_ElevatorRelays;
                                break;

                            case PanelInterfaceBoardSectionType.LCD_4x20Display:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_LCD_4x20Display;
                                break;

                            case PanelInterfaceBoardSectionType.OutputRelays:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_OutputRelays;
                                break;

                            case PanelInterfaceBoardSectionType.SaltoSallis:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_SaltoSallis;
                                break;

                            case PanelInterfaceBoardSectionType.RS485DoorModule:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485DoorModule;
                                break;

                            case PanelInterfaceBoardSectionType.RS485InputModule:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485InputModule;
                                break;

                            case PanelInterfaceBoardSectionType.Unused:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Unused;
                                break;

                            case PanelInterfaceBoardSectionType.DrmSection:
                            case PanelInterfaceBoardSectionType.Dio8X4Outputs:
                            case PanelInterfaceBoardSectionType.Dio8X4Inputs:
                            case PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                            //case PanelInterfaceBoardSectionType.CardTourManagerCpu:
                            case PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                            case PanelInterfaceBoardSectionType.VeridtCpu:
                            case PanelInterfaceBoardSectionType.VeridtReader:
                                break;
                        }
                    }

                    if (s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimAba &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_CypressClockDisplay &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_ElevatorRelays &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_LCD_4x20Display &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_OutputRelays &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_SaltoSallis &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485DoorModule &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485InputModule &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Shell &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Unused &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_VeridtCac)
                        errorsArray.Add($"Invalid InterfaceBoardSectionModeUid ({s.InterfaceBoardSectionModeUid}) or SectionType ({s.SectionMode}) value for board type ({b.InterfaceBoardTypeUid})");
                }
            }
            else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DigitalInputOutput600)
            {

            }
            else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_KoneElevatorInterface)
            {

            }
            else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_OtisElevatorInterface)
            {

            }
            else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_Cpu)
            {

            }
            else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_ReaderModule)
            {

            }
            //else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_CardTourManager)
            //{

            //}
            //else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface600)
            //{
            //    var invalidSections = sections.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
            //    foreach (var s in invalidSections)
            //    {
            //        //sections.Remove(s);
            //        errorsArray.Add($"Invalid section number {s.SectionNumber}. This board type can only have section numbers 1 and 2");
            //    }
            //    foreach (var s in sections)
            //    {
            //        // If the InterfaceBoardSectionModeUid is not specified, then use the SectionType enum and assign the correct Uid value
            //        if (s.InterfaceBoardSectionModeUid == Guid.Empty)
            //        {
            //            switch (s.SectionMode)
            //            {
            //                case PanelInterfaceBoardSectionType.DsiIngersolRandPimClockData:
            //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimAba;
            //                    break;

            //                case PanelInterfaceBoardSectionType.DsiIngersolRandPimWiegand:
            //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand;
            //                    break;

            //                case PanelInterfaceBoardSectionType.DsiAssaAbloyAperio:
            //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio;
            //                    break;

            //                case PanelInterfaceBoardSectionType.DsiCypressClockDisplay:
            //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_CypressClockDisplay;
            //                    break;

            //                case PanelInterfaceBoardSectionType.DsiElevatorControlRelays:
            //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_ElevatorRelays;
            //                    break;

            //                case PanelInterfaceBoardSectionType.DsiLcd4x20Display:
            //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_LCD_4x20Display;
            //                    break;

            //                case PanelInterfaceBoardSectionType.DsiOutputControlRelays:
            //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_OutputRelays;
            //                    break;

            //                case PanelInterfaceBoardSectionType.DsiSalto:
            //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_SaltoSallis;
            //                    break;

            //                case PanelInterfaceBoardSectionType.DrmSection:
            //                case PanelInterfaceBoardSectionType.None:
            //                case PanelInterfaceBoardSectionType.Dio8X4Outputs:
            //                case PanelInterfaceBoardSectionType.Dio8X4Inputs:
            //                case PanelInterfaceBoardSectionType.DsiRs485DoorModule:
            //                case PanelInterfaceBoardSectionType.DsiRs485InputModule:
            //                case PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
            //                //case PanelInterfaceBoardSectionType.CardTourManagerCpu:
            //                case PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
            //                case PanelInterfaceBoardSectionType.VeridtCpu:
            //                case PanelInterfaceBoardSectionType.VeridtReader:
            //                    break;
            //            }
            //        }
            //        if (s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimAba &&
            //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand &&
            //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio &&
            //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_CypressClockDisplay &&
            //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_ElevatorRelays &&
            //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_LCD_4x20Display &&
            //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_OutputRelays &&
            //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_SaltoSallis &&
            //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Shell &&
            //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Unused &&
            //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_VeridtCac)
            //            return BadRequest($"Invalid InterfaceBoardSectionModeUid ({s.InterfaceBoardSectionModeUid}) or SectionType ({s.SectionMode}) value for board type ({b.InterfaceBoardTypeUid})");
            //    }
            //}

            if (errorsArray.Any())
            {
                validationProblems.Add($"{nameof(WcfEntities.GalaxyInterfaceBoard)}[{boardIndex}]", errorsArray.ToArray());
                return new ValidationProblemDetails(validationProblems);
            }

            return null;
        }

        private async Task<ValidationProblemDetails> ValidateInterfaceBoardProperties(GalaxyInterfaceBoardPutReq b, int boardIndex, ApiEntities.GalaxyPanelEditingDataCommonBasic editorData)
        {
            var validationProblems = new Dictionary<string, string[]>();
            var errorsArray = new List<string>();
            // If the InterfaceBoardTypeUid is empty, then assign it the correct value based on the BoardType enum value
            if (b.InterfaceBoardTypeUid == Guid.Empty)
            {
                switch (b.BoardType)
                {
                    case GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
                        b.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface600;
                        break;

                    case GalaxyInterfaceBoardType.DigitalInputOutputBoard600:
                        b.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DigitalInputOutput600;
                        break;

                    case GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
                        b.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635;
                        break;

                    case GalaxyInterfaceBoardType.OtisElevatorInterface:
                        b.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_OtisElevatorInterface;
                        break;

                    //case GalaxyInterfaceBoardTypCardTourManagerCpu:
                    //    b.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_CardTourManager;
                    //    break;

                    case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:  // DSI-600s are obsolete. Automatically convert to DSI-635
                    case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                        b.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface635;
                        break;

                    case GalaxyInterfaceBoardType.KoneElevatorInterface:
                        b.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_KoneElevatorInterface;
                        break;

                    case GalaxyInterfaceBoardType.Veridt_Cpu:
                        b.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_Cpu;
                        break;

                    case GalaxyInterfaceBoardType.Veridt_ReaderModule:
                        b.InterfaceBoardTypeUid = GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_ReaderModule;
                        break;

                    case GalaxyInterfaceBoardType.None:
                    case GalaxyInterfaceBoardType.Cpu600:
                    case GalaxyInterfaceBoardType.Cpu635:
                    case GalaxyInterfaceBoardType.DualPortInterfaceBoard500:
                    default:
                        errorsArray.Add($"Unsupported board type: {b.BoardType}");
                        break;
                }
            }

            var sections = new List<RequestModels.GalaxyInterfaceBoardSectionPutReq>();
            if (b.InterfaceBoardSections != null)
                sections = b.InterfaceBoardSections.ToList();

            var boardType = editorData.InterfaceBoardTypes.FirstOrDefault(o => o.InterfaceBoardTypeUid == b.InterfaceBoardTypeUid);
            if (boardType != null)
            {
                if (sections.Count > boardType.NumberOfSections)
                {
                    errorsArray.Add($"There are {sections.Count} sections specified. BoardType {b.BoardType} can have {boardType.NumberOfSections} sections.");
                }
            }
            var sectionIndex = 0;
            foreach (var s in sections)
            {
                var sectionCount = sections.Count(o => o.SectionNumber == s.SectionNumber);
                if (sectionCount > 1)
                {
                    errorsArray.Add($"There are {sectionCount} sections specified with SectionNumber {s.SectionNumber}. SectionNumbers must be unique.");
                }
                if (boardType != null)
                {
                    ApiEntities.InterfaceBoardSectionModeBasic sectionMode = null;
                    if (s.InterfaceBoardSectionModeUid == Guid.Empty)
                        sectionMode = boardType.InterfaceBoardSectionModes.FirstOrDefault(o => o.SectionMode.ToLower() == s.SectionMode.ToString().ToLower());
                    else
                        sectionMode = boardType.InterfaceBoardSectionModes.FirstOrDefault(o => o.InterfaceBoardSectionModeUid == s.InterfaceBoardSectionModeUid);

                    //sectionMode = boardType.InterfaceBoardSectionModes.FirstOrDefault(o => o.SectionMode.ToLower() == s.SectionMode.ToString().ToLower());
                    //if (sectionMode == null)
                    //{
                    //    if (s.InterfaceBoardSectionModeUid != Guid.Empty)
                    //        sectionMode = boardType.InterfaceBoardSectionModes.FirstOrDefault(o => o.InterfaceBoardSectionModeUid == s.InterfaceBoardSectionModeUid);
                    //}
                    if (sectionMode == null)
                        errorsArray.Add($"InterfaceBoardSections[{sectionIndex}].SectionMode is not valid for BoardType {b.BoardType}.");
                }
                sectionIndex++;
            }

            if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface600)
            {   // there must be two sections, numbered 1 & 2
                var invalidSections = sections.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
                foreach (var s in invalidSections)
                {
                    errorsArray.Add($"Invalid section number {s.SectionNumber}. This board type can only have section numbers 1 and 2");
                }
            }
            else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635)
            {
                var invalidSections = sections.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
                foreach (var s in invalidSections)
                {
                    //sections.Remove(s);
                    errorsArray.Add($"Invalid section number {s.SectionNumber}. This board type can only have section numbers 1 and 2");
                }
            }
            else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface635)
            {
                var invalidSections = sections.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
                foreach (var s in invalidSections)
                {
                    //sections.Remove(s);
                    errorsArray.Add($"Invalid section number {s.SectionNumber}. This board type can only have section numbers 1 and 2");
                }


                foreach (var s in sections)
                {
                    // If the InterfaceBoardSectionModeUid is not specified, then use the SectionType enum and assign the correct Uid value
                    if (s.InterfaceBoardSectionModeUid == Guid.Empty)
                    {
                        switch (s.SectionMode)
                        {
                            case PanelInterfaceBoardSectionType.AllegionPimAba:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimAba;
                                break;

                            case PanelInterfaceBoardSectionType.AllegionPimWiegand:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand;
                                break;

                            case PanelInterfaceBoardSectionType.AssaAbloyAperio:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio;
                                break;

                            case PanelInterfaceBoardSectionType.CypressClockDisplay:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_CypressClockDisplay;
                                break;

                            case PanelInterfaceBoardSectionType.ElevatorRelays:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_ElevatorRelays;
                                break;

                            case PanelInterfaceBoardSectionType.LCD_4x20Display:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_LCD_4x20Display;
                                break;

                            case PanelInterfaceBoardSectionType.OutputRelays:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_OutputRelays;
                                break;

                            case PanelInterfaceBoardSectionType.SaltoSallis:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_SaltoSallis;
                                break;

                            case PanelInterfaceBoardSectionType.RS485DoorModule:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485DoorModule;
                                break;

                            case PanelInterfaceBoardSectionType.RS485InputModule:
                                s.InterfaceBoardSectionModeUid = DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485InputModule;
                                break;

                            case PanelInterfaceBoardSectionType.DrmSection:
                            case PanelInterfaceBoardSectionType.Unused:
                            case PanelInterfaceBoardSectionType.Dio8X4Outputs:
                            case PanelInterfaceBoardSectionType.Dio8X4Inputs:
                            case PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                            //case PanelInterfaceBoardSectionType.CardTourManagerCpu:
                            case PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                            case PanelInterfaceBoardSectionType.VeridtCpu:
                            case PanelInterfaceBoardSectionType.VeridtReader:
                                break;
                        }
                    }

                    if (s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimAba &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_CypressClockDisplay &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_ElevatorRelays &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_LCD_4x20Display &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_OutputRelays &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_SaltoSallis &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485DoorModule &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485InputModule &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Shell &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Unused &&
                        s.InterfaceBoardSectionModeUid != DualSerialInterface635ChannelModeIds.DualSerialChannelMode_VeridtCac)
                        errorsArray.Add($"Invalid InterfaceBoardSectionModeUid ({s.InterfaceBoardSectionModeUid}) or SectionType ({s.SectionMode}) value for board type ({b.InterfaceBoardTypeUid})");
                }
            }
            else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DigitalInputOutput600)
            {

            }
            else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_KoneElevatorInterface)
            {

            }
            else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_OtisElevatorInterface)
            {

            }
            else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_Cpu)
            {

            }
            else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_ReaderModule)
            {

            }
            //else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_CardTourManager)
            //{

            //}
            //else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface600)
            //{
            //    var invalidSections = sections.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
            //    foreach (var s in invalidSections)
            //    {
            //        //sections.Remove(s);
            //        errorsArray.Add($"Invalid section number {s.SectionNumber}. This board type can only have section numbers 1 and 2");
            //    }
            //    foreach (var s in sections)
            //    {
            //        // If the InterfaceBoardSectionModeUid is not specified, then use the SectionType enum and assign the correct Uid value
            //        if (s.InterfaceBoardSectionModeUid == Guid.Empty)
            //        {
            //            switch (s.SectionMode)
            //            {
            //                case PanelInterfaceBoardSectionType.DsiIngersolRandPimClockData:
            //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimAba;
            //                    break;

            //                case PanelInterfaceBoardSectionType.DsiIngersolRandPimWiegand:
            //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand;
            //                    break;

            //                case PanelInterfaceBoardSectionType.DsiAssaAbloyAperio:
            //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio;
            //                    break;

            //                case PanelInterfaceBoardSectionType.DsiCypressClockDisplay:
            //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_CypressClockDisplay;
            //                    break;

            //                case PanelInterfaceBoardSectionType.DsiElevatorControlRelays:
            //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_ElevatorRelays;
            //                    break;

            //                case PanelInterfaceBoardSectionType.DsiLcd4x20Display:
            //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_LCD_4x20Display;
            //                    break;

            //                case PanelInterfaceBoardSectionType.DsiOutputControlRelays:
            //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_OutputRelays;
            //                    break;

            //                case PanelInterfaceBoardSectionType.DsiSalto:
            //                    s.InterfaceBoardSectionModeUid = DualSerialInterface600ChannelModeIds.DualSerialChannelMode_SaltoSallis;
            //                    break;

            //                case PanelInterfaceBoardSectionType.DrmSection:
            //                case PanelInterfaceBoardSectionType.None:
            //                case PanelInterfaceBoardSectionType.Dio8X4Outputs:
            //                case PanelInterfaceBoardSectionType.Dio8X4Inputs:
            //                case PanelInterfaceBoardSectionType.DsiRs485DoorModule:
            //                case PanelInterfaceBoardSectionType.DsiRs485InputModule:
            //                case PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
            //                //case PanelInterfaceBoardSectionType.CardTourManagerCpu:
            //                case PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
            //                case PanelInterfaceBoardSectionType.VeridtCpu:
            //                case PanelInterfaceBoardSectionType.VeridtReader:
            //                    break;
            //            }
            //        }
            //        if (s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimAba &&
            //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand &&
            //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio &&
            //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_CypressClockDisplay &&
            //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_ElevatorRelays &&
            //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_LCD_4x20Display &&
            //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_OutputRelays &&
            //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_SaltoSallis &&
            //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Shell &&
            //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Unused &&
            //            s.InterfaceBoardSectionModeUid != DualSerialInterface600ChannelModeIds.DualSerialChannelMode_VeridtCac)
            //            return BadRequest($"Invalid InterfaceBoardSectionModeUid ({s.InterfaceBoardSectionModeUid}) or SectionType ({s.SectionMode}) value for board type ({b.InterfaceBoardTypeUid})");
            //    }
            //}

            if (errorsArray.Any())
            {
                validationProblems.Add($"{nameof(WcfEntities.GalaxyInterfaceBoard)}[{boardIndex}]", errorsArray.ToArray());
                return new ValidationProblemDetails(validationProblems);
            }

            return null;
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Delete a specific panel by galaxyPanelUid.
        /// </summary>
        ///
        /// <param name="galaxyPanelUid"> Identifier for the Galaxy Panel to delete. </param>
        ///
        /// <returns>   A Task&lt;IActionResult&gt; </returns>
        ///=================================================================================================        
        [HttpDelete("{galaxyPanelUid}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid galaxyPanelUid)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<GalaxyPanelManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetGalaxyPanelAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = galaxyPanelUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = false
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                var x = await mgr.DeleteGalaxyPanelByUniqueIdAsync(new WcfEntities.DeleteParameters() { UniqueId = galaxyPanelUid });
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
        /// Delete a specific board by galaxyInterfaceBoardUid.
        /// </summary>
        ///
        /// <param name="galaxyInterfaceBoardUid"> Identifier for the board to delete. </param>
        ///
        /// <returns>   A Task&lt;IActionResult&gt; </returns>
        ///=================================================================================================        
        [HttpDelete("board/{galaxyInterfaceBoardUid}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBoard(Guid galaxyInterfaceBoardUid)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<GalaxyInterfaceBoardManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetGalaxyInterfaceBoardAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = galaxyInterfaceBoardUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = false
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                var x = await mgr.DeleteGalaxyInterfaceBoardByUniqueIdAsync(new WcfEntities.DeleteParameters() { UniqueId = galaxyInterfaceBoardUid });
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
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>
        ///// Send a command to one or more control panels.
        ///// </summary>
        /////
        ///// <param name="parameters">   Options for controlling the operation. </param>
        /////
        ///// <returns>   A Task&lt;IActionResult&gt; </returns>
        /////=================================================================================================

        //[HttpPost("sendcommand")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]

        //public async Task<IActionResult> ExecuteCommand(RequestModels.CommandParams<RequestModels.ClusterCommandActionReq> parameters)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<GalaxyPanelManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var wcfParams = Mapper.Map<WcfEntities.CommandParameters<WcfEntities.ClusterCommandAction>>(parameters);
        //        var result = await mgr.Sen(wcfParams);

        //        if (mgr.HasErrors)
        //        {
        //            return this.StatusCode(StatusCodes.Status500InternalServerError, mgr.Errors[0]);
        //        }

        //        return Ok();
        //    }
        //    catch (FaultException<NetCoreCommon.GCS.Core.Common.ServiceModel.ExceptionDetailEx> ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");

        //        if (ex.Detail.Type.Contains(typeof(System.UnauthorizedAccessException).ToString()))
        //            return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);

        //        if (ex.Detail.Type.Contains(typeof(GCS.Core.Common.Exceptions.NotFoundException).ToString()))
        //            return NotFound();

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
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.ActivityHistoryEvent>>> GetActivityHistory([FromQuery] RequestModels.GalaxyPanelActivityHistoryEventSearchParametersReq parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<GalaxyPanelManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
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
