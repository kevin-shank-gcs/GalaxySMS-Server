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
    /// <summary>   Operations relating to MercScpGroups. </summary>
    ///<remarks>  </remarks>
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================

    [Route("api/[controller]")]
    [ApiController]  // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MercScpGroupController : ControllerBaseEx
    {
        public MercScpGroupController(IConfiguration config,
            IMapper mapper,
            ILogger<MercScpGroupController> logger,
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
        ///  <param name="sortBy"> (Optional) The property to sort the results by (MercScpGroupName, InsertDate, UpdateDate)</param>
        ///  <param name="orderBy">      (Optional) Specifies if the results should be returned in ascending (asc, default) or descending (desc) order.</param>
        ///  <returns>   A Task&lt;ActionResult&lt;ApiEntities.MercScpGroupBasic[]&gt;&gt; </returns>
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
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.MercScpGroupBasic>>> Get(Guid entityId, int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeChildren = false, bool includeCommands = false, MercScpGroupSortProperty sortBy = MercScpGroupSortProperty.Name, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<MercScpGroupManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetAllMercScpGroupsForEntityAsync(new WcfEntities.GetParametersWithPhoto()
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

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.MercScpGroupBasic>>(results);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary>   Get a list of MercScpGroups for an entity. </summary>
        /// 
        ///  <param name="entityId">     (Optional) The unique ID of the entity to request clusters for. If not specified, clusters for current entity will be requested. </param>
        ///  <param name="pageSize">     Size of the page. 0 = no paging</param>
        ///  <param name="pageNumber">   The page number. </param>
        ///  <param name="includePhoto">     (Optional) True to include photo, false to exclude the photo. </param>
        ///  <param name="photoPixelWidth">  (Optional) Width of the photo pixel. </param>
        ///  <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        ///  <param name="includeCounts"> (Optional) True to only include counts of data elements in the response. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by (MercScpGroupName, InsertDate, UpdateDate)</param>
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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.MercScpGroupListItemCommands>>> GetList(Guid entityId, int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, bool includeCounts = false, MercScpGroupSortProperty sortBy = MercScpGroupSortProperty.Name, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<MercScpGroupManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

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

                var results = await mgr.GetAllMercScpGroupsForEntityListAsync(parameters);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.MercScpGroupListItemCommands>>(results);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get a list of MercScpGroups for a site. </summary>
        ///
        /// <param name="siteUid">          The Guid (uuid) value that identifies the site. </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includePhoto">     (Optional) True to include photo, false to exclude the photo. </param>
        /// <param name="photoPixelWidth">  (Optional) Width of the photo pixel. </param>
        ///  <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
        ///  <param name="includeCounts"> (Optional) True to only include counts of data elements in the response. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by (MercScpGroupName, InsertDate, UpdateDate)</param>
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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.MercScpGroupListItemCommands>>> GetListForSite(Guid siteUid, int pageSize, int pageNumber, bool includePhoto = false, int photoPixelWidth = 200, bool includeCommands = false, bool includeCounts = false, MercScpGroupSortProperty sortBy = MercScpGroupSortProperty.Name, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<MercScpGroupManager>(ServerWcfServerAddress, ServerWcfBindingType,
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

                var results = await mgr.GetAllMercScpGroupsForSiteListAsync(parameters);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                //var resp = new ApiEntities.ArrayResponse<ApiEntities.ListItemBase>();
                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.MercScpGroupListItemCommands>>(results);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary>   Get a cluster by MercScpGroupUid value. </summary>
        ///  
        ///  <param name="mercScpGroupUid">       The mercury scp group UID. </param>
        ///  <param name="includeProperties"> (Optional) Comma-separated list of properties to populate.</param>
        ///  <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        ///  <param name="photoPixelWidth"> (Optional) Specifies the width of the returned photo image</param>
        ///  <param name="responseFormat">  (Optional) Specifies the format of the response message. </param>
        /// 
        ///  <returns>   A Task&lt;ActionResult&lt;ApiEntities.MercScpGroup&gt;&gt; </returns>
        /// =================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{mercScpGroupUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ResponseModels.MercScpGroupResp>> Get(Guid mercScpGroupUid, string includeProperties, bool includePhoto = false, int photoPixelWidth = 200, ResponseFormat responseFormat = ResponseFormat.Default)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<MercScpGroupManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = mercScpGroupUid,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = !string.IsNullOrEmpty(includeProperties)
                };

                if (!string.IsNullOrEmpty(includeProperties))
                {
                    var includeProps = includeProperties.Split(',');
                    var responseProperties = typeof(WcfEntities.MercScpGroup).GetComplexProperties().ToList();

                    var panelProps = typeof(WcfEntities.GalaxyPanel).GetComplexProperties();
                    responseProperties.AddRange(panelProps);
                    var ibsProperties = typeof(WcfEntities.GalaxyInterfaceBoard).GetComplexProperties();
                    responseProperties.AddRange(ibsProperties);

                    if (includeProperties.Contains(nameof(WcfEntities.MercScpGroup.DisabledCommandIds)))
                    {
                        //var clusterCommandsInfo = responseProperties.FirstOrDefault(o =>
                        //    o.Name == nameof(WcfEntities.MercScpGroup.MercScpGroupCommands));
                        //if (clusterCommandsInfo != null)
                        //{
                        //    responseProperties.Remove(clusterCommandsInfo);
                        //}

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

                //wcfGetParams.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(WcfEntities.MercScpGroup.GalaxyPanels), true));
                //wcfGetParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.MercScpGroup.GalaxyPanels));
                var result = await mgr.GetMercScpGroupAsync(wcfGetParams);

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

        private object ConvertToFormat(ResponseFormat responseFormat, WcfEntities.MercScpGroup result)
        {
            if (responseFormat == ResponseFormat.ForPut)
                return Mapper.Map<RequestModels.MercScpGroupPutReq>(result);

            if (responseFormat == ResponseFormat.Minimal)
                return Mapper.Map<ApiEntities.MercScpGroupMinimal>(result);

            if (responseFormat == ResponseFormat.ForPutMinimalChildren)
                return Mapper.Map<RequestModels.ClusterPutReqMinimalChildren>(result);

            return Mapper.Map<ResponseModels.MercScpGroupResp>(result);
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

        public async Task<ActionResult<ApiEntities.MercScpGroupEditingDataBasic>> GetEditorData(/*Guid clusterTypeUid,*/ string includeProperties )
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<MercScpGroupManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfParameters = new WcfEntities.GetParametersWithPhoto()
                {
                    //UniqueId = clusterTypeUid,
                    IncludeMemberCollections = true
                };

                if (!string.IsNullOrEmpty(includeProperties))
                {
                    var includeProps = includeProperties.Split(',');
                    var responseProperties =
                        typeof(WcfEntities.MercScpGroupEditingData).GetComplexProperties().ToList();
                    foreach (var p in responseProperties)
                    {
                        var included = includeProps.FirstOrDefault(o => o.TrimStart().TrimEnd().ToLower() == p.Name.ToLower());
                        if (included == null)
                            wcfParameters.ExcludeMemberCollectionSettings.Add(p.Name);
                    }
                }

                var result = await mgr.GetMercScpGroupEditingDataAsync(wcfParameters);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();
                var model = Mapper.Map<ApiEntities.MercScpGroupEditingDataBasic>(result);
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
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.MercScpGroup&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RequestModels.MercScpGroupPutReq>> Post(RequestModels.SaveParams<RequestModels.MercScpGroupReq> parameters, string includeProperties, bool includePhoto = false, int photoPixelWidth = 200, ResponseFormat responseFormat = ResponseFormat.Default)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgr = Helpers.GetManager<MercScpGroupManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);
                wcfSaveParameters.IncludeMemberCollections = !string.IsNullOrEmpty(includeProperties);
                wcfSaveParameters.IncludePhoto = includePhoto;
                wcfSaveParameters.PhotoPixelWidth = photoPixelWidth;
                
                ProcessIncludeProperties(includeProperties, wcfSaveParameters);

                var wcfEntity = Mapper.Map<WcfEntities.MercScpGroup>(parameters.Data);
                //wcfEntity.ConcurrencyValue = 0;
                //if (parameters.Data.Image != null)
                //    wcfEntity.gcsBinaryResource.BinaryResource = parameters.Data.Image;

                //if (parameters.Data.MercScpGroupTypeUid == Guid.Empty)
                //{
                //    switch (parameters.Data.MercScpGroupType)
                //    {
                //        //case Common.Enums.MercScpGroupType.Hybrid6xx:
                //        //    wcfEntity.MercScpGroupTypeUid = GalaxySMS.Common.Constants.GalaxyMercScpGroupTypeIds.GalaxyMercScpGroupType_Hybrid6xx;
                //        //    break;

                //        //case Common.Enums.MercScpGroupType.Only600:
                //        //    wcfEntity.MercScpGroupTypeUid = GalaxySMS.Common.Constants.GalaxyMercScpGroupTypeIds.GalaxyMercScpGroupType_Only600;
                //        //    break;
                //        case Common.Enums.MercScpGroupType.Only7xx:
                //            wcfEntity.MercScpGroupTypeUid = GalaxySMS.Common.Constants.GalaxyMercScpGroupTypeIds.GalaxyMercScpGroupType_Only7xx;
                //            break;
                //        case Common.Enums.MercScpGroupType.Hybrid7xx:
                //            wcfEntity.MercScpGroupTypeUid = GalaxySMS.Common.Constants.GalaxyMercScpGroupTypeIds.GalaxyMercScpGroupType_Hybrid7xx;
                //            break;
                //        case Common.Enums.MercScpGroupType.Only635:
                //        default:
                //            wcfEntity.MercScpGroupTypeUid = GalaxySMS.Common.Constants.GalaxyMercScpGroupTypeIds.GalaxyMercScpGroupType_Only635;
                //            break;
                //    }
                //}

                //if (parameters.Data.CredentialDataLengthUid == Guid.Empty)
                //{
                //    switch (parameters.Data.CredentialDataLength)
                //    {
                //        case Common.Enums.CredentialDataSize.Extended256Bits:
                //            wcfEntity.CredentialDataLengthUid = GalaxySMS.Common.Constants.CredentialDataLengthIds.Extended256Bits;
                //            break;
                //        case Common.Enums.CredentialDataSize.Standard48Bits:
                //        default:
                //            wcfEntity.CredentialDataLengthUid = GalaxySMS.Common.Constants.CredentialDataLengthIds.Standard48Bits;
                //            break;
                //    }
                //}

                //if (parameters.Data.TimeScheduleTypeUid == Guid.Empty)
                //{
                //    switch (parameters.Data.TimeScheduleType)
                //    {
                //        case Common.Enums.TimeScheduleType.GalaxyFifteenMinuteInterval:
                //            wcfEntity.TimeScheduleTypeUid = GalaxySMS.Common.Constants.TimeScheduleTypeIds.TimeScheduleType_GalaxyLegacy15MinuteInterval;
                //            break;
                //        case Common.Enums.TimeScheduleType.AssaAbloyDsr:
                //        //break;
                //        case Common.Enums.TimeScheduleType.GalaxyOneMinuteInterval:
                //        default:
                //            wcfEntity.TimeScheduleTypeUid = GalaxySMS.Common.Constants.TimeScheduleTypeIds.TimeScheduleType_GalaxyMinuteInterval;
                //            break;
                //    }
                //}

                //if (parameters.Data.AccessPortalLockedLedBehaviorModeUid == Guid.Empty)
                //{
                //    switch (parameters.Data.AccessPortalLockedLedBehaviorMode)
                //    {
                //        case Common.Enums.MercScpGroupLedBehavior.SteadyHigh:
                //            wcfEntity.AccessPortalLockedLedBehaviorModeUid = GalaxySMS.Common.Constants.MercScpGroupLedBehaviorIds.SteadyHigh;
                //            break;
                //        case Common.Enums.MercScpGroupLedBehavior.Strobe:
                //            wcfEntity.AccessPortalLockedLedBehaviorModeUid = GalaxySMS.Common.Constants.MercScpGroupLedBehaviorIds.Strobe;
                //            break;
                //        case Common.Enums.MercScpGroupLedBehavior.StrobeRapid:
                //            wcfEntity.AccessPortalLockedLedBehaviorModeUid = GalaxySMS.Common.Constants.MercScpGroupLedBehaviorIds.StrobeRapid;
                //            break;
                //        case Common.Enums.MercScpGroupLedBehavior.SteadyLow:
                //        default:
                //            wcfEntity.AccessPortalLockedLedBehaviorModeUid = GalaxySMS.Common.Constants.MercScpGroupLedBehaviorIds.SteadyLow;
                //            break;
                //    }
                //}

                //if (parameters.Data.AccessPortalUnlockedLedBehaviorModeUid == Guid.Empty)
                //{
                //    switch (parameters.Data.AccessPortalUnlockedLedBehaviorMode)
                //    {
                //        case Common.Enums.MercScpGroupLedBehavior.SteadyHigh:
                //            wcfEntity.AccessPortalUnlockedLedBehaviorModeUid = GalaxySMS.Common.Constants.MercScpGroupLedBehaviorIds.SteadyHigh;
                //            break;
                //        case Common.Enums.MercScpGroupLedBehavior.StrobeRapid:
                //            wcfEntity.AccessPortalUnlockedLedBehaviorModeUid = GalaxySMS.Common.Constants.MercScpGroupLedBehaviorIds.StrobeRapid;
                //            break;
                //        case Common.Enums.MercScpGroupLedBehavior.SteadyLow:
                //            wcfEntity.AccessPortalUnlockedLedBehaviorModeUid = GalaxySMS.Common.Constants.MercScpGroupLedBehaviorIds.SteadyLow;
                //            break;
                //        case Common.Enums.MercScpGroupLedBehavior.Strobe:
                //        default:
                //            wcfEntity.AccessPortalUnlockedLedBehaviorModeUid = GalaxySMS.Common.Constants.MercScpGroupLedBehaviorIds.Strobe;
                //            break;
                //    }
                //}

                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.MercScpGroup>(wcfEntity, wcfSaveParameters);
                
                //if( parameters.Data.ScheduleIds != null)
                //{
                //    if (parameters.Data.ScheduleIds.Count > TimeScheduleLimits.HighestDefinableNumber)
                //        return BadRequest(
                //            $"There are to many ScheduleId values specified. The maximum allowed is {TimeScheduleLimits.HighestDefinableNumber}. {parameters.Data.ScheduleIds.Count} have been specified.");
                //    foreach (var schId in parameters.Data.ScheduleIds)
                //    {
                //        wcfParams.Data.TimeSchedules.Add(new WcfEntities.TimeScheduleSelect()
                //        {
                //            TimeScheduleUid = schId,
                //            Selected = true
                //        });
                //    }
                //}
 
                var validationProblemDetails = await mgr.ValidateMercScpGroupAsync(wcfParams);
                if (validationProblemDetails != null)
                {
                    if (validationProblemDetails is { IsValid: false })
                    {
                        return ValidationProblem(new ValidationProblemDetails(validationProblemDetails.Errors));
                    }
                }

                var results = await mgr.SaveMercScpGroupAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var url = LinkGenerator.GetPathByAction("Get",
                        "MercScpGroup",
                        new { clusterUid = results.MercScpGroupUid });

                    var model = ConvertToFormat(responseFormat, results);
                    if (results.UpdateDate > results.InsertDate)
                        return Ok(model);
                    return Created(url, model);

                    //if (responseFormat == ResponseFormat.ForPut)
                    //{
                    //    var savedItem = Mapper.Map<RequestModels.MercScpGroupPutReq>(results);
                    //    if (results.UpdateDate > results.InsertDate)
                    //        return Ok(savedItem);
                    //    return Created(url, savedItem);
                    //}

                    //if (responseFormat == ResponseFormat.Minimal)
                    //{
                    //    var savedItemA = Mapper.Map<ApiEntities.MercScpGroupMinimal>(results);
                    //    if (results.UpdateDate > results.InsertDate)
                    //        return Ok(savedItemA);
                    //    return Created(url, savedItemA);
                    //}


                    //if (responseFormat == ResponseFormat.ForPutMinimalChildren)
                    //{
                    //    var savedItemB = Mapper.Map<RequestModels.MercScpGroupPutReqMinimalChildren>(results);
                    //    if (results.UpdateDate > results.InsertDate)
                    //        return Ok(savedItemB);
                    //    return Created(url, savedItemB);
                    //}

                    //var savedItemC = Mapper.Map<ResponseModels.MercScpGroupResp>(results);
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
        /// Update an existing MercScpGroup item. Can also create a new MercScpGroup.
        /// </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///  <param name="includeProperties"> (Optional) Comma-separated list of properties to populate.</param>
        ///  <param name="includePhoto">     (Optional) True to include, false to exclude the photo. </param>
        ///  <param name="photoPixelWidth"> (Optional) Specifies the width of the returned photo image</param>
        ///  <param name="responseFormat">  (Optional) Specifies the format of the response message. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.MercScpGroup&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<MercScpGroupPutReq>> Put(RequestModels.SaveParams<RequestModels.MercScpGroupPutReq> parameters, string includeProperties, bool includePhoto = false, int photoPixelWidth = 200, ResponseFormat responseFormat = ResponseFormat.Default)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (parameters.Data.MercScpGroupUid == Guid.Empty)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot update MercScpGroup with MercScpGroupUid value of {parameters.Data.MercScpGroupUid}");

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgr = Helpers.GetManager<MercScpGroupManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);
                wcfSaveParameters.IncludeMemberCollections = !string.IsNullOrEmpty(includeProperties);
                wcfSaveParameters.IncludePhoto = includePhoto;
                wcfSaveParameters.PhotoPixelWidth = photoPixelWidth;

                ProcessIncludeProperties(includeProperties, wcfSaveParameters);

                var wcfEntity = Mapper.Map<WcfEntities.MercScpGroup>(parameters.Data);

                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.MercScpGroup>(wcfEntity, wcfSaveParameters);
                //if (parameters.Data.ScheduleIds != null)
                //{
                //    foreach (var schId in parameters.Data.ScheduleIds)
                //    {
                //        wcfParams.Data.TimeSchedules.Add(new WcfEntities.TimeScheduleSelect()
                //        {
                //            TimeScheduleUid = schId,
                //            Selected = true
                //        });
                //    }
                //}

                var validationProblemDetails = await mgr.ValidateMercScpGroupAsync(wcfParams);
                if (validationProblemDetails != null)
                {
                    if (validationProblemDetails is { IsValid: false })
                    {
                        return ValidationProblem(new ValidationProblemDetails(validationProblemDetails.Errors));
                    }
                }
                var results = await mgr.SaveMercScpGroupAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    ////var savedItem = Mapper.Map<MercScpGroupPutReq>(results);
                    //var savedItem = Mapper.Map<MercScpGroupPutReqMinimalChildren>(results);
                    //var url = LinkGenerator.GetPathByAction("Get",
                    //    "MercScpGroup",
                    //    new { clusterUid = savedItem.MercScpGroupUid });
                    //if (results.UpdateDate > results.InsertDate)
                    //    return Ok(savedItem);
                    //return Created(url, savedItem);

                    var url = LinkGenerator.GetPathByAction("Get",
                        "MercScpGroup",
                        new { clusterUid = results.MercScpGroupUid });
  
                    var model = ConvertToFormat(responseFormat, results);
                    if (results.UpdateDate > results.InsertDate)
                        return Ok(model);
                    return Created(url, model);

                    //if (responseFormat == ResponseFormat.ForPut)
                    //{
                    //    var savedItem = Mapper.Map<RequestModels.MercScpGroupPutReq>(results);
                    //    if (results.UpdateDate > results.InsertDate)
                    //        return Ok(savedItem);
                    //    return Created(url, savedItem);
                    //}

                    //if (responseFormat == ResponseFormat.Minimal)
                    //{
                    //    var savedItemA = Mapper.Map<ApiEntities.MercScpGroupMinimal>(results);
                    //    if (results.UpdateDate > results.InsertDate)
                    //        return Ok(savedItemA);
                    //    return Created(url, savedItemA);
                    //}


                    //if (responseFormat == ResponseFormat.ForPutMinimalChildren)
                    //{
                    //    var savedItemB = Mapper.Map<RequestModels.MercScpGroupPutReqMinimalChildren>(results);
                    //    if (results.UpdateDate > results.InsertDate)
                    //        return Ok(savedItemB);
                    //    return Created(url, savedItemB);
                    //}


                    //var savedItemC = Mapper.Map<ResponseModels.MercScpGroupResp>(results);
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
                var responseProperties = typeof(WcfEntities.MercScpGroup).GetComplexProperties().ToList();

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
        /// Delete a specific MercScpGroup by MercScpGroupUid.
        /// </summary>
        ///
        /// <param name="mercScpGroupUid"> Identifier for the MercScpGroup to delete. </param>
        ///
        /// <returns>   A Task&lt;IActionResult&gt; </returns>
        ///=================================================================================================        
        [HttpDelete("{mercScpGroupUid}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid mercScpGroupUid)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<MercScpGroupManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetMercScpGroupAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = mercScpGroupUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = false
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                var x = await mgr.DeleteMercScpGroupByUniqueIdAsync(new WcfEntities.DeleteParameters() { UniqueId = mercScpGroupUid });

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

        //public async Task<IActionResult> ExecuteCommand(RequestModels.CommandParams<RequestModels.GalaxyCpuCommandActionReq> parameters)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<MercScpGroupManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var wcfParams = Mapper.Map<WcfEntities.CommandParameters<WcfEntities.GalaxyCpuCommandAction>>(parameters);
        //        var result = await mgr.ExecuteMercScpGroupCommandAsync(wcfParams);

        //        if (mgr.HasErrors)
        //        {
        //            return GetStatusCodeResult(mgr);
        //        }

        //        return Ok(result);
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
        //        if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
        //            return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Send a command to load configuration data. </summary>
        ///// 
        ///// <remarks>   Kevin, 1/5/2023. </remarks>
        ///// <param name="parameters">   . </param>
        ///// <param name="backgroundJob"></param>
        ///// <returns>   The data. </returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //[HttpPost("loaddata")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]


        //public async Task<IActionResult> LoadData(RequestModels.CommandParams<RequestModels.MercScpGroupDataLoadParametersReq> parameters, bool backgroundJob)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        //if (parameters.Data.MercScpGroupUid == Guid.Empty && parameters.Data.GalaxyPanelUid == Guid.Empty && parameters.Data.CpuUid == Guid.Empty)
        //        //    return BadRequest($"{nameof(parameters.Data.MercScpGroupUid)} or {nameof(parameters.Data.GalaxyPanelUid)} or {nameof(parameters.Data.CpuUid)} is required.");


        //        //var validationProblemDetails = await ValidateLoadDataUids(parameters);
        //        //if (validationProblemDetails != null)
        //        //    return ValidationProblem(validationProblemDetails);

        //        var mgr = Helpers.GetManager<GalaxyPanelCommunicationManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

        //        var wcfParams = Mapper.Map<WcfEntities.CommandParameters<WcfEntities.MercScpGroupDataLoadParameters>>(parameters);

        //        if (backgroundJob)
        //        {
        //            var resultJob = await mgr.SendMercScpGroupDataToPanelsJobAsync(wcfParams);

        //            if (mgr.HasErrors)
        //            {
        //                return GetStatusCodeResult(mgr);
        //            }

        //            var resJob = Mapper.Map<ApiEntities.BackgroundJobInfo<ResponseModels.LoadDataCommandResponseSimple<MercScpGroupDataLoadParametersReq>>>(resultJob);
        //            return Ok(resJob);
        //        }
        //        var result = await mgr.SendMercScpGroupDataToPanelsAsync(wcfParams);

        //        if (mgr.HasErrors)
        //        {
        //            return GetStatusCodeResult(mgr);
        //        }

        //        var res = Mapper.Map<ResponseModels.LoadDataCommandResponseSimple<MercScpGroupDataLoadParametersReq>>(result);
        //        return Ok(res);

        //        //var details = Mapper.Map<RequestModels.MercScpGroupDataLoadParametersReq>(result.Data);
        //        //var res = Mapper.Map<ResponseModels.CommandResponseSimple>(result);
        //        //var response = new ResponseModels.CommandResponseSimple<RequestModels.MercScpGroupDataLoadParametersReq>()
        //        //{
        //        //    OperationUid = res.OperationUid,
        //        //    RequestDateTime = res.RequestDateTime,
        //        //    ApproximateDuration = res.ApproximateDuration,
        //        //    PanelsSentTo = res.PanelsSentTo,
        //        //    Data = details
        //        //};
        //        //return Ok(response);
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
        //        if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
        //            return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //}

        //private ValidationProblemDetails ValidateUids(GalaxyCpuCommandBaseReq parameters)
        //{
        //    var response = new ValidationProblemDetails();
        //    var errorsArray = new List<string>();

        //    errorsArray.Add($"The {nameof(parameters.Data.MercScpGroupUid)} cannot be changed.");
        //    if (errorsArray.Any())
        //    {
        //        response.Errors.Add($"{nameof(MercScpGroup)}", errorsArray.ToArray());
        //        return response;
        //    }

        //    return null;
        //}

        //[HttpPost("{clusterUid}/mapschedule/{timeScheduleUid}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<ApiEntities.GalaxyMercScpGroupTimeScheduleMapBasic>> PostTimeScheduleMapping(Guid clusterUid, Guid timeScheduleUid, bool fifteenMinuteFormatUsesHolidays = true)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var validationProblemDetails = await ValidateMercScpGroupTimeScheduleMapping(timeScheduleUid, clusterUid);
        //        if (validationProblemDetails != null)
        //            return ValidationProblem(validationProblemDetails);

        //        var mgr = Helpers.GetManager<TimeScheduleManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var result = await mgr.SaveTimeScheduleMercScpGroupMappingAsync(timeScheduleUid, clusterUid, true, fifteenMinuteFormatUsesHolidays);

        //        if (mgr.HasErrors)
        //        {
        //            return GetStatusCodeResult(mgr);
        //        }

        //        return Ok(Mapper.Map<ApiEntities.GalaxyMercScpGroupTimeScheduleMapBasic>(result));
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
        //        if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
        //            return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //}


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>
        ///// Delete a specific MercScpGroup to TimeSchedule mapping.
        ///// </summary>
        /////
        ///// <param name="clusterUid"> Identifier for the MercScpGroup to delete. </param>
        ///// <param name="timeScheduleUid"> Identifier for the TimeSchedule to delete. </param>
        /////
        ///// <returns>   A Task&lt;IActionResult&gt; </returns>
        /////=================================================================================================        
        //[HttpDelete("{clusterUid}/mapschedule/{timeScheduleUid:Guid}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> DeleteTimeScheduleMapping(Guid clusterUid, Guid timeScheduleUid)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);
        //        if (timeScheduleUid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never ||
        //            timeScheduleUid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always)
        //            return BadRequest($"TimeScheduleUid {timeScheduleUid} cannot be un-mapped from a cluster.");

        //        var mgr = Helpers.GetManager<TimeScheduleManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var canUnmap = await mgr.CanTimeScheduleBeUnmappedFromMercScpGroupAsync(timeScheduleUid, clusterUid);
        //        if (!canUnmap)
        //        {
        //            var mappings = await mgr.GetTimeScheduleUsageInformationAsync(timeScheduleUid, clusterUid);
        //            if (mappings != null && mappings.IsUsed)
        //            {
        //                var data = new CustomTimeScheduleUsageData()
        //                {
        //                    MercScpGroupName = mappings.MercScpGroupName,
        //                    MercScpGroupUid = mappings.MercScpGroupUid,
        //                    TimeScheduleUid = mappings.TimeScheduleUid,
        //                    TimeScheduleName = mappings.TimeScheduleName,
        //                    Message = mappings.Message,
        //                    Mappings = new TimeScheduleMappings()
        //                };
        //                if( mappings.Mappings.AccessPortals.Any())
        //                    data.Mappings.AccessPortals.AddRange(mappings.Mappings.AccessPortals);
        //                if (mappings.Mappings.AccessGroups.Any())
        //                    data.Mappings.AccessGroups.AddRange(mappings.Mappings.AccessGroups);
        //                if (mappings.Mappings.AccessGroupAccessPortals.Any())
        //                    data.Mappings.AccessGroups.AddRange(mappings.Mappings.AccessGroupAccessPortals);
        //                if (mappings.Mappings.GalaxyPanels.Any())
        //                    data.Mappings.GalaxyPanels.AddRange(mappings.Mappings.GalaxyPanels);
        //                if (mappings.Mappings.InputOutputGroups.Any())
        //                    data.Mappings.InputOutputGroups.AddRange(mappings.Mappings.InputOutputGroups); 
        //                if (mappings.Mappings.InputDevices.Any())
        //                    data.Mappings.InputDevices.AddRange(mappings.Mappings.InputDevices); 
        //                if (mappings.Mappings.OutputDevices.Any())
        //                    data.Mappings.OutputDevices.AddRange(mappings.Mappings.OutputDevices); 
        //                if (mappings.Mappings.People.Any())
        //                    data.Mappings.People.AddRange(mappings.Mappings.People);

        //                var response = new CustomValidationProblemDetails()
        //                {
        //                    errors = data,
        //                    status = StatusCodes.Status400BadRequest,
        //                    title = "One or more validation errors occurred."
        //                };
        //                return BadRequest(response);
        //            }
        //            return BadRequest($"TimeScheduleUid {timeScheduleUid} cannot be un-mapped from a cluster {clusterUid} because it is in use.");
        //        }

        //        var result = await mgr.SaveTimeScheduleMercScpGroupMappingAsync(timeScheduleUid, clusterUid, false, false);

        //        if (mgr.HasErrors)
        //        {
        //            return GetStatusCodeResult(mgr);
        //        }

        //        return Ok(Mapper.Map<ApiEntities.GalaxyMercScpGroupTimeScheduleMapBasic>(result));
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
        //        if (ex.Message.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
        //            return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //}


        //private async Task<ValidationProblemDetails> ValidateMercScpGroupTimeScheduleMapping(Guid timeScheduleUid, Guid clusterUid)
        //{
        //    var mgr = Helpers.GetManager<ValidationManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

        //    var parameters = new WcfEntities.GuidValidationRequest()
        //    {

        //    };
        //    parameters.Items.Add(new WcfEntities.GuidValidationRequestItem()
        //    {
        //        ValidationRequestType = ValidationRequestType.MercScpGroupAndTimeScheduleEntities,
        //        MercScpGroupUid = clusterUid,
        //        TimeScheduleUid = timeScheduleUid,
        //        PreventSystemEntityMatches = false,
        //        PropertyName = "MercScpGroupTimeScheduleMapping"
        //    });
        //    var results = await mgr.ValidateRequest(parameters);

        //    if (results is { IsValid: false })
        //    {
        //        return new ValidationProblemDetails(results.Errors);
        //    }

        //    return null;
        //}

        //private async Task<ApiEntities.TimeScheduleUsageData> ValidateDeleteMercScpGroupTimeScheduleMapping(Guid timeScheduleUid, Guid clusterUid)
        //{
        //    var mgr = Helpers.GetManager<TimeScheduleManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

        //    var results = await mgr.GetTimeScheduleUsageInformationAsync(timeScheduleUid, clusterUid);
        //    return Mapper.Map<ApiEntities.TimeScheduleUsageData>(results);
        //}


    }
}
