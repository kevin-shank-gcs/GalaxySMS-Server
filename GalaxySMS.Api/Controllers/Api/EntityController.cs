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
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using RequestModels = GalaxySMS.Api.Models.RequestModels;
using WcfEntities = GalaxySMS.Business.Entities;
using GalaxySMS.Api.Models.RequestModels;

namespace GalaxySMS.Api.Controllers.Api
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Operations relating Entities. </summary>
    ///<remarks> An entity is a foundational element of the system. Most all data items in the system are associated with an entity. 
    ///          Entities are used to separate, isolate or partition data within the system. An entity can be thought of as a 
    ///          customer or tenant in a multi-tenant application. Entities can also be used to represent a department or division
    ///           within a larger organization where the data needs to be separated or isolated from other groups within the organization. 
    ///           Individual data items such as persons, regions, sites, time schedules and users are all associated with a specific entity. 
    ///           Entities can be hierarchical in nature where an entity can have child entities. In this scenario, the parent entity can 
    ///           access its children’s data items. </remarks>
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================

    [Route("api/[controller]")]
    [ApiController]  // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EntityController : ControllerBaseEx
    {
        public EntityController(IConfiguration config,
            IMapper mapper,
            ILogger<EntityController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper, logger, linkGenerator, cache, distributedCache)
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary> Get a collection of gcsEntity objects. </summary>
        /// 
        ///  <param name="pageSize">     Size of the page. 0 = no paging</param>
        ///  <param name="pageNumber">   The page number. </param>
        ///  <param name="includePhoto">     (Optional) True to include photo, false to exclude the photo. </param>
        ///  <param name="photoPixelWidth">  (Optional) Width of the photo in pixels (0 = full size). </param>
        ///  <param name="includeChildren">  (Optional) True to include, false to exclude the children. (True can significantly increase response time and body size) </param>
        ///  <param name="includeCounts"> (Optional) True to only include counts of data elements in the response. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by (EntityName, InsertDate, UpdateDate)</param>
        ///  <param name="orderBy">      (Optional) Specifies if the results should be returned in ascending (asc, default) or descending (desc) order.</param>
        /// 
        ///  <returns>   A Task&lt;ActionResult&lt;ApiEntities.gcsEntity[]&gt;&gt; </returns>
        /// =================================================================================================
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
        public async Task<ActionResult<ApiEntities.ArrayResponse<EntityPutReq>>> Get(int pageSize, int pageNumber, bool includePhoto = true, int photoPixelWidth = 200, bool includeChildren = false, bool includeCounts = false, EntitySortProperty sortBy = EntitySortProperty.EntityName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<EntityManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var parameters = new WcfEntities.GetParametersWithPhoto()
                {
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = includeChildren,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                };

                if (includeCounts)
                    parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeCounts, includeCounts));

                //if (includeRegionsSites)
                //    parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeRegionSiteHierachy, includeRegionsSites));

                var results = await mgr.GetAllEntitiesAsync(parameters);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                //if (includeCounts)
                //{
                //    var respEx = Mapper.Map<ApiEntities.ArrayResponse<EntityPutReq>>(results);

                //    return Ok(respEx);
                //}

                var resp = Mapper.Map<ApiEntities.ArrayResponse<RequestModels.EntityPutReq>>(results);

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
        ///  Get Entities by name or description. If the search text is found anywhere in the name or description, the entity will be included in the response.
        ///  </summary>
        /// 
        ///  <param name="searchText">       The text to search for.  </param>
        ///  <param name="pageSize">     Size of the page. 0 = no paging</param>
        ///  <param name="pageNumber">   The page number. </param>
        ///  <param name="includePhoto">     (Optional) True to include photo, false to exclude the photo. </param>
        ///  <param name="photoPixelWidth">  (Optional) Width of the photo in pixels (0 = full size). </param>
        ///  <param name="includeChildren">  (Optional) True to include, false to exclude the children.
        ///                                  (True can significantly increase response time and body size) </param>
        ///  <param name="includeCounts">    (Optional) True to only include counts of data elements in
        ///                                  the response. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by (EntityName, InsertDate, UpdateDate)</param>
        ///  <param name="orderBy">      (Optional) Specifies if the results should be returned in ascending (asc, default) or descending (desc) order.</param>
        ///  <returns>   The entities by name or description. </returns>
        /// =================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("search/{searchtext}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.gcsEntity>>> GetByNameOrDescription(string searchText, int pageSize, int pageNumber, bool includePhoto = true, int photoPixelWidth = 200, bool includeChildren = false, bool includeCounts = false, bool includeRegionsSites = false, EntitySortProperty sortBy = EntitySortProperty.EntityName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<EntityManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var parameters = new WcfEntities.GetParametersWithPhoto()
                {
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = includeChildren,
                    GetString = searchText,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                };

                if (includeCounts)
                    parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeCounts, includeCounts));

                //if (includeRegionsSites)
                //    parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeRegionSiteHierachy, includeRegionsSites));

                var results = await mgr.GetEntitiesByNameOrDescriptionAsync(parameters);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (includeCounts)
                {
                    var respEx = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.gcsEntityEx>>(results);
                    return Ok(respEx);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.gcsEntity>>(results);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get a collection of gcsEntity objects. </summary>
        ///
        /// <remarks>   Kevin, 2/8/2022. </remarks>
        ///
        /// <param name="entityId">             Identifier for the entity to delete. </param>
        /// <param name="includePhoto">         (Optional) True to include photo, false to exclude the
        ///                                     photo. </param>
        ///  <param name="refreshCache"> (Optional) false = return data from cache if possible, true = always request data from database and cache the response</param>
        /// <param name="includeProperties">    (Optional) Comma-separated list of property names to include in the response
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.gcsEntity&gt;&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{entityId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        //public async Task<ActionResult<ApiEntities.gcsEntity>> Get(Guid entityId, bool includePhoto = true, bool includeChildren = false, bool getForPut = false, bool includeCounts = false, bool includeRegionsSites = true)
        public async Task<ActionResult<ApiEntities.gcsEntity>> Get(Guid entityId, bool includePhoto = true, string includeProperties = "", bool refreshCache = false)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var getForPut = true;

                //var cacheKey = $"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name}:{entityId}:{includeProperties}:{includePhoto}:{getForPut}".ToLower();

                ////if (!refreshCache)
                ////{
                ////    var cachedItem = Cache.Get(cacheKey);
                ////    if (cachedItem != null)
                ////        return Ok(cachedItem);
                ////}

                //if (!refreshCache)
                //{
                //    var cachedItem = await DistributedCache.GetAsync<ApiEntities.gcsEntity>(cacheKey);
                //    if (cachedItem != null)
                //        return Ok(cachedItem);
                //}

                var includeChildren = true;
                var includeCounts = true;
                var includeRegionsSites = true;

                var mgr = Helpers.GetManager<EntityManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                if (getForPut)
                {
                    includePhoto = true;
                    includeChildren = true;
                }

                var parameters = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = entityId,
                    IncludePhoto = includePhoto,
                    IncludeMemberCollections = includeChildren,
                    RefreshCache = refreshCache,
                };

                if (!string.IsNullOrEmpty(includeProperties))
                {
                    var includeProps = includeProperties.ToLower().Split(',');
                    var responseProperties =
                        typeof(WcfEntities.gcsEntityEx).GetComplexProperties().ToList();
                    foreach (var p in responseProperties)
                    {
                        var included = includeProps.FirstOrDefault(o => o.TrimStart().TrimEnd().ToLower() == p.Name.ToLower());
                        if (included == null)
                            parameters.ExcludeMemberCollectionSettings.Add(p.Name);
                    }

                    if (includeProps.Contains(nameof(WcfEntities.gcsEntityEx.Counts).ToLower()))
                    {
                        parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeCounts, true));
                        includeCounts = true;
                    }
                    else
                    {
                        includeCounts = false;
                    }

                    if (includeProps.Contains(nameof(WcfEntities.gcsEntityEx.Regions).ToLower()))
                    {
                        parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeRegionSiteHierachy, true));
                        parameters.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.SiteSelectionItem.Clusters));
                    }
                    if (includeProps.Contains(nameof(WcfEntities.gcsEntityEx.AllRoles).ToLower()) && !includeProperties.Contains(nameof(WcfEntities.gcsRole.RolePermissions).ToLower()))
                    {
                        parameters.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.gcsRole.RolePermissions));
                    }
                    if (includeProps.Contains(nameof(WcfEntities.gcsEntityEx.AllRoles).ToLower()) && !includeProperties.Contains(nameof(WcfEntities.gcsRole.DeviceFilters).ToLower()))
                    {
                        parameters.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.gcsRole.DeviceFilters));
                    }
                }
                else
                {
                    if (includeCounts)
                        parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeCounts, includeCounts));

                    parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeRegionSiteHierachy, includeRegionsSites));
                    parameters.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.SiteSelectionItem.Clusters));
                    //}
                }

                if (getForPut)
                {   // Force exclusions to include AllRoles, because roles are not part of the getForPut structure
                    if (!parameters.IsExcluded(nameof(WcfEntities.gcsEntityEx.AllRoles).ToLower()))
                    {
                        parameters.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.gcsEntityEx.AllRoles));
                    }
                    if (!parameters.IsExcluded(nameof(WcfEntities.gcsEntityEx.Settings).ToLower()))
                    {
                        parameters.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.gcsEntityEx.Settings));
                    }
                    if (!parameters.IsExcluded(nameof(WcfEntities.gcsEntityEx.ChildEntities).ToLower()))
                    {
                        parameters.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.gcsEntityEx.ChildEntities));
                    }
                    if (!parameters.IsExcluded(nameof(WcfEntities.gcsEntityEx.ParentEntity).ToLower()))
                    {
                        parameters.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.gcsEntityEx.ParentEntity));
                    }
                    parameters.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.gcsEntityEx.TheLicense));
                }

                var result = await mgr.GetEntityAsync(parameters);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                //var cacheOptions = new DistributedCacheEntryOptions()
                //    .SetAbsoluteExpiration(DateTimeOffset.Now.AddMinutes(10))
                //    .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                if (getForPut)
                {
                    if (result.gcsBinaryResource?.BinaryResourceUid == Guid.Empty)
                        result.gcsBinaryResource = null;
                    var data = Mapper.Map<RequestModels.EntityPutReq>(result);
                    ////var cachedData = Cache.Set(cacheKey, data);
                    //var cachedData = await DistributedCache.SetAsync(cacheKey, data);

                    return Ok(data);
                }

                //if (includeCounts)
                //{
                var modelsEx = Mapper.Map<ApiEntities.gcsEntityEx>(result);
                ////var cachedDataEx = Cache.Set(cacheKey, modelsEx);
                //var cachedData1 = await DistributedCache.SetAsync(cacheKey, JsonConvert.SerializeObject(modelsEx));
                return Ok(modelsEx);
                //}

                //var model = Mapper.Map<ApiEntities.gcsEntity>(result);
                //return Ok(model);
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
        /// Create a new gcsEntity item.
        /// </summary>
        /// 
        /// <remarks>Valid IgnoreProperties values: UserRequirements, gcsEntityApplications, gcsSettings
        ///           </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.gcsEntity[]&gt;&gt; </returns>
        ///=================================================================================================


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        //[SwaggerRequestExample(typeof(RequestModels.SaveParams<RequestModels.Entity>), typeof(SaveEntityExamples))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<EntityPutReq>> Post(RequestModels.SaveParams<RequestModels.EntityReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var validationPersonProblemDetails = await ValidateEntity(parameters.Data);
                if (validationPersonProblemDetails != null)
                    return ValidationProblem(validationPersonProblemDetails);

                var mgr = Helpers.GetManager<EntityManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.gcsEntity>(parameters.Data);
                if (parameters.Data.Image != null)
                    wcfEntity.gcsBinaryResource.BinaryResource = parameters.Data.Image;

                if (parameters.Data.Options == null)
                {
                    parameters.Data.Options = new AddEntityOptions();
                }

                wcfSaveParameters.AddOption(SaveEntityOption.AddToExistingUsersWithParentEntityAccess.ToString(), parameters.Data.Options.AddToExistingUsers);
                wcfSaveParameters.AddOption(SaveEntityOption.InheritParentEntityRoles.ToString(), parameters.Data.Options.InheritParentEntityRoles);
                wcfSaveParameters.AddOption(SaveEntityOption.IsEntityAdministrator.ToString(), parameters.Data.Options.IsEntityAdmin);
                wcfEntity.AutoMapTimeSchedules = parameters.Data.Options.AutoMapSchedules;

                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.gcsEntity>(wcfEntity, wcfSaveParameters);

                var results = await mgr.SaveEntityAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var savedItem = Mapper.Map<EntityPutReq>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "Entity",
                        new { entityId = savedItem.EntityId });
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
        /// Submit a request to create a new gcsEntity item using a background job
        /// </summary>
        /// 
        /// <remarks>Valid IgnoreProperties values: UserRequirements, gcsEntityApplications, gcsSettings
        ///           </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.gcsEntity[]&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("job")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        //[SwaggerRequestExample(typeof(RequestModels.SaveParams<RequestModels.Entity>), typeof(SaveEntityExamples))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ApiEntities.BackgroundJobInfo>> PostJob(RequestModels.SaveParams<RequestModels.EntityReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var validationPersonProblemDetails = await ValidateEntity(parameters.Data);
                if (validationPersonProblemDetails != null)
                    return ValidationProblem(validationPersonProblemDetails);

                var mgr = Helpers.GetManager<EntityManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.gcsEntity>(parameters.Data);
                if (parameters.Data.Image != null)
                    wcfEntity.gcsBinaryResource.BinaryResource = parameters.Data.Image;

                wcfEntity.AutoMapTimeSchedules = true;

                //if (parameters.Data.gcsEntityApplications == null)
                //    parameters.Data.gcsEntityApplications = new HashSet<RequestModels.EntityApplicationReq>();
                //foreach (var reqEa in parameters.Data.gcsEntityApplications)
                //{
                //    var wcfEa = wcfEntity.gcsEntityApplications.FirstOrDefault(o => o.ApplicationId == reqEa.ApplicationId);
                //    if (wcfEa != null)
                //    {
                //        foreach (var rid in reqEa.RoleIds)
                //        {
                //            wcfEa.gcsEntityApplicationRoles.Add(new WcfEntities.gcsEntityApplicationRole()
                //            {
                //                RoleId = rid
                //            });
                //        }
                //    }
                //}

                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.gcsEntity>(wcfEntity, wcfSaveParameters);

                var results = await mgr.SaveEntityJobAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var savedItem = Mapper.Map<ApiEntities.BackgroundJobInfo>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "Job",
                        new { JobId = savedItem.JobId });
                    //if (savedItem.JobType == ApiEntities.BackgroundJobInfo.OperationType.Update)
                    //    return Ok(savedItem);
                    return Accepted(url, savedItem);
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
        /// Updates an existing gcsEntity item. Can also create a new gcsEntity if the EntityId property is specified 
        /// </summary>
        /// 
        /// <remarks>Valid IgnoreProperties values: UserRequirements, gcsEntityApplications, gcsSettings
        /// </remarks>
        /// 
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.gcsEntity&gt;&gt; </returns>
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

        public async Task<ActionResult<EntityPutReq>> Put(RequestModels.SaveParams<RequestModels.EntityPutReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (parameters.Data.EntityId == Guid.Empty || parameters.Data.EntityId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot update entity with EntityId value of {parameters.Data.EntityId}");

                var mgr = Helpers.GetManager<EntityManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var originalEntity = await mgr.GetEntityAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = parameters.Data.EntityId,
                    IncludePhoto = false,
                    IncludeMemberCollections = false
                });

                var validationPersonProblemDetails = await ValidateEntity(parameters.Data, originalEntity);
                if (validationPersonProblemDetails != null)
                    return ValidationProblem(validationPersonProblemDetails);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());


                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.gcsEntity>(parameters.Data);
                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.gcsEntity>(wcfEntity, wcfSaveParameters);

                wcfParams.AddOption(SaveEntityOption.DontEnsureDefaultsExist.ToString(), true);
                wcfParams.IgnoreProperties.Add(nameof(wcfEntity.Settings));

                var results = await mgr.SaveEntityAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var savedItem = Mapper.Map<EntityPutReq>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "Entity",
                        new { entityId = savedItem.EntityId });
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
        /// Updates an existing gcsEntity item using a background job. Can also create a new gcsEntity if the EntityId property is specified 
        /// </summary>
        /// 
        /// <remarks>Valid IgnoreProperties values: UserRequirements, gcsEntityApplications, gcsSettings
        /// </remarks>
        /// 
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.BackgroundJobInfo&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("job")]
        //[SwaggerRequestExample(typeof(RequestModels.SaveParams<RequestModels.Entity>), typeof(SaveEntityExamples))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ApiEntities.BackgroundJobInfo>> PutJob(RequestModels.SaveParams<RequestModels.EntityPutReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (parameters.Data.EntityId == Guid.Empty || parameters.Data.EntityId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot update entity with EntityId value of {parameters.Data.EntityId}");

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgr = Helpers.GetManager<EntityManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var originalEntity = await mgr.GetEntityAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = parameters.Data.EntityId,
                    IncludePhoto = false,
                    IncludeMemberCollections = false
                });

                var validationPersonProblemDetails = await ValidateEntity(parameters.Data, originalEntity);
                if (validationPersonProblemDetails != null)
                    return ValidationProblem(validationPersonProblemDetails);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.gcsEntity>(parameters.Data);
                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.gcsEntity>(wcfEntity, wcfSaveParameters);

                var results = await mgr.SaveEntityJobAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var savedItem = Mapper.Map<ApiEntities.BackgroundJobInfo>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "Job",
                        new { JobId = savedItem.JobId });
                    //if (savedItem.JobType == ApiEntities.BackgroundJobInfo.OperationType.Update)
                    //    return Ok(savedItem);
                    return Accepted(url, savedItem);
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
        /// Delete a specific gcsEntity by entityId.
        /// </summary>
        ///
        /// <param name="entityId"> Identifier for the entity to delete. </param>
        ///
        /// <returns>   A Task&lt;IActionResult&gt; </returns>
        ///=================================================================================================        
        [HttpDelete("{entityId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid entityId)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (entityId == Guid.Empty || entityId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id || entityId == EntityIds.GalaxySMS_DefaultEntity_Id)
                    return this.StatusCode(StatusCodes.Status403Forbidden, $"Forbidden from deleting entityId:{entityId}");

                var mgr = Helpers.GetManager<EntityManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var wcfParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = entityId
                };

                var result = await mgr.GetEntityAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                var deleteParams = new WcfEntities.DeleteParameters() { UniqueId = entityId };

                deleteParams.AddOption(DeleteOptions_Entity.AutoDeleteRegions, true);
                deleteParams.AddOption(DeleteOptions_Entity.AutoDeleteSites, true);

                var x = await mgr.DeleteEntityByUniqueIdAsync(deleteParams);

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
        /// Get all gcsEntities that the current user is authorized to access.
        /// </summary>
        ///
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includePhoto">     (Optional) True to include photo, false to exclude the photo. </param>
        /// <param name="photoPixelWidth">  (Optional) Width of the photo pixel. </param>
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. (True can significantly increase response time and body size) </param>
        ///  <param name="includeCounts"> (Optional) True to only include counts of data elements in the response. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by (EntityName, InsertDate, UpdateDate)</param>
        ///  <param name="orderBy">      (Optional) Specifies if the results should be returned in ascending (asc, default) or descending (desc) order.</param>
        /// <returns> Get all entities for the current for user. </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("foruser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.gcsEntity>>> GetForUser(int pageSize, int pageNumber, bool includePhoto = true, int photoPixelWidth = 0, bool includeChildren = false, bool includeCounts = false, EntitySortProperty sortBy = EntitySortProperty.EntityName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgr = Helpers.GetManager<EntityManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var parameters = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = userId,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                };

                if (includeCounts)
                    parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeCounts, includeCounts));

                //if (includeRegionsSites)
                //    parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeRegionSiteHierachy, includeRegionsSites));

                var results = await mgr.GetAllEntitiesForUserAsync(parameters);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (includeCounts)
                {
                    var respEx = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.gcsEntityEx>>(results);
                    return Ok(respEx);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.gcsEntity>>(results);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary>  Get a list of gcsEntityBasic objects </summary>
        /// 
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        ///  <param name="buildAsTree">      (Optional) True to build the response as a hierarchical tree. </param>
        ///  <param name="includePhoto">     (Optional) True to include photo, false to exclude the photo. </param>
        ///  <param name="photoPixelWidth">  (Optional) Width of the photo pixel. </param>
        ///  <param name="activeOnly">       (Optional) True to active only. </param>
        ///  <param name="enforcePermissions"> (Optional) True to only include entities that the current user is authorized to view. </param>
        ///  <param name="includeCounts"> (Optional) True to only include counts of data elements in the response. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by (EntityName, InsertDate, UpdateDate)</param>
        ///  <param name="orderBy">      (Optional) Specifies if the results should be returned in ascending (asc, default) or descending (desc) order.</param>
        ///  <returns>   The list. </returns>
        /// =================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.gcsEntityBasic>>> GetList(int pageSize, int pageNumber, bool buildAsTree = false, bool includePhoto = true, int photoPixelWidth = 0, bool activeOnly = true, bool enforcePermissions = true, bool includeCounts = true, EntitySortProperty sortBy = EntitySortProperty.EntityName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<EntityManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var parameters = new WcfEntities.GetParametersWithPhoto()
                {
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                };
                if (buildAsTree)
                {
                    parameters.IncludeMemberCollections = true;
                    parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.BuildTreeStructure, buildAsTree));
                }
                if (enforcePermissions)
                {
                    parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.EnforcePermissions, enforcePermissions));
                }
                if (includeCounts)
                    parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeCounts, includeCounts));

                //if (includeRegionsSites)
                //    parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeRegionSiteHierachy, includeRegionsSites));

                parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeActiveOnly, activeOnly));

                //parameters.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(WcfEntities.gcsEntity.UserRequirements), true));
                //parameters.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(WcfEntities.gcsEntity.gcsEntityApplications), true));
                //parameters.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(WcfEntities.gcsEntity.AllApplications), true));
                //parameters.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(WcfEntities.gcsEntity.ParentEntity), true));
                parameters.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.gcsEntity.UserRequirements));
                //parameters.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.gcsEntity.gcsEntityApplications));
                //parameters.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.gcsEntity.AllApplications));
                parameters.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.gcsEntity.ParentEntity));

                var results = await mgr.GetEntityListAsync(parameters);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (includeCounts)
                {
                    var respEx = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.gcsEntityExBasic>>(results);
                    return Ok(respEx);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.gcsEntityBasic>>(results);
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
        ///  Get a list of gcsEntityBasic objects for the current user.
        ///  </summary>
        ///  <param name="parentEntityId"> Specifies the parent entity whos children to return</param>
        ///  <param name="pageSize">     Size of the page. 0 = no paging</param>
        ///  <param name="pageNumber">   The page number. </param>
        ///  <param name="buildAsTree">      (Optional) True to build the response as a hierarchical tree. </param>
        ///  <param name="includePhoto">     (Optional) True to include photo, false to exclude the photo. </param>
        ///  <param name="photoPixelWidth">  (Optional) Width of the photo pixel. </param>
        ///  <param name="includeCounts"> (Optional) True to only include counts of data elements in the response. </param>
        ///  <param name="ignoreCurrent"></param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by (EntityName, InsertDate, UpdateDate)</param>
        ///  <param name="orderBy">      (Optional) Specifies if the results should be returned in ascending (asc, default) or descending (desc) order.</param>
        ///  <returns>   The list for user. </returns>
        /// =================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("listforuser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.gcsEntityBasic>>> GetListForUser(Guid parentEntityId, int pageSize, int pageNumber, bool buildAsTree = false, bool includePhoto = true, int photoPixelWidth = 0, bool includeCounts = false, bool ignoreCurrent = false, EntitySortProperty sortBy = EntitySortProperty.EntityName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgr = Helpers.GetManager<EntityManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var parameters = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = userId,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString(),
                    GetGuid = parentEntityId
                };

                parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.BuildTreeStructure, buildAsTree));
                if (includeCounts)
                    parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeCounts, includeCounts));

                if (ignoreCurrent)
                {
                    parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions_Entity.IgnoreCurrentEntity, ignoreCurrent));
                }

                //if (includeRegionsSites)
                //    parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeRegionSiteHierachy, includeRegionsSites));

                var results = await mgr.GetEntityListForUserAsync(parameters);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (includeCounts)
                {
                    var respEx = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.gcsEntityExBasic>>(results);
                    return Ok(respEx);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.gcsEntityBasic>>(results);
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
        /// Get a list of gcsEntityBasic objects by name or description.
        /// </summary>
        ///
        /// <param name="searchtext">      The name or description to search for.  </param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="buildAsTree">      (Optional) True to build the response as a hierarchical tree. </param>
        /// <param name="includePhoto">     (Optional) True to include photo, false to exclude the photo. </param>
        /// <param name="photoPixelWidth">  (Optional) Width of the photo pixel. </param>       
        ///  <param name="includeCounts"> (Optional) True to only include counts of data elements in the response. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by (EntityName, InsertDate, UpdateDate)</param>
        ///  <param name="orderBy">      (Optional) Specifies if the results should be returned in ascending (asc, default) or descending (desc) order.</param>
        ///
        /// <returns>   The list by description. </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("listbysearchtext/{searchtext}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.gcsEntityBasic>>> GetListByNameOrDescription(string searchtext, int pageSize, int pageNumber, bool buildAsTree = false, bool includePhoto = true, int photoPixelWidth = 0, bool includeCounts = false, EntitySortProperty sortBy = EntitySortProperty.EntityName, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgr = Helpers.GetManager<EntityManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var parameters = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = userId,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    GetString = searchtext,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                };

                parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.BuildTreeStructure, buildAsTree));
                if (includeCounts)
                    parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeCounts, includeCounts));

                //if (includeRegionsSites)
                //    parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeRegionSiteHierachy, includeRegionsSites));

                var results = await mgr.GetEntityListByNameOrDescriptionAsync(parameters);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (includeCounts)
                {
                    var respEx = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.gcsEntityExBasic>>(results);
                    return Ok(respEx);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.gcsEntityBasic>>(results);
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
        /// Update counts for a specific entity.
        /// </summary>
        ///
        /// <param name="entityId"> Identifier for the entity. A value of '00000000-0000-0000-0000-000000000000' will update counts for all entities. This could potentially take a significant length of time to complete.</param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.gcsEntityCounts&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("updatecounts/{entityId}")]
        //[SwaggerRequestExample(typeof(RequestModels.SaveParams<RequestModels.Entity>), typeof(SaveEntityExamples))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ApiEntities.gcsEntityCounts>> PostUpdateCounts(Guid entityId)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgr = Helpers.GetManager<EntityManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var results = await mgr.UpdateEntityCountsAsync(entityId);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                return Ok(results);
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

        private async Task<ValidationProblemDetails> ValidateEntity(EntityReq data)
        {
            var validationProblems = new Dictionary<string, string[]>();
            var errorsArray = new List<string>();

            if (data.EntityId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id ||
                data.EntityId == EntityIds.GalaxySMS_SystemEntity_Id)
            {
                errorsArray.Add($"The EntityId '{data.EntityId}' is not allowed.");
                validationProblems.Add(nameof(data.EntityId), errorsArray.ToArray());
            }
            else if (!IsEntityTypeValid(data.EntityType))
            {
                errorsArray.Add($"The EntityType '{data.EntityType}' value is invalid. Valid values are: '{EntityTypes.Administrator}', '{EntityTypes.Customer}', '{EntityTypes.EnterpriseCustomer}', '{EntityTypes.Location}', '{EntityTypes.Dealer}', and '{EntityTypes.Reserved}'");
                validationProblems.Add(nameof(data.EntityType), errorsArray.ToArray());
            }
            else if (data.EntityId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id &&
                data.EntityType.ToLower() != EntityTypes.Administrator)
            {
                errorsArray.Add($"Illegal {nameof(data.EntityType)} value for EntityId {data.EntityId}. The only permitted value is '{EntityTypes.Administrator}'");
                validationProblems.Add(nameof(data.EntityType), errorsArray.ToArray());
            }
            else if (data.EntityId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id &&
                data.EntityType.ToLower() != EntityTypes.Reserved)
            {
                errorsArray.Add($"Illegal {nameof(data.EntityType)} value for EntityId {data.EntityId}. The only permitted value is '{EntityTypes.Reserved}'");
                validationProblems.Add(nameof(data.EntityType), errorsArray.ToArray());
            }

            if (validationProblems.Any())
            {
                return new ValidationProblemDetails(validationProblems);
            }

            return null;
        }

        private bool IsEntityTypeValid(string dataEntityType)
        {
            return dataEntityType == EntityTypes.Dealer ||
                   dataEntityType == EntityTypes.Administrator ||
                   dataEntityType == EntityTypes.Reserved ||
                   dataEntityType == EntityTypes.Customer ||
                   dataEntityType == EntityTypes.Location ||
                   dataEntityType == EntityTypes.EnterpriseCustomer;
        }

        private async Task<ValidationProblemDetails> ValidateEntity(EntityPutReq data, WcfEntities.gcsEntityEx original)
        {
            var validationProblems = new Dictionary<string, string[]>();
            var errorsArray = new List<string>();

            if (original.AutoMapTimeSchedules == false && data.AutoMapTimeSchedules == true)
            {
                errorsArray.Add($"AutoMapTimeSchedules cannot be changed from '{original.AutoMapTimeSchedules}' to '{data.AutoMapTimeSchedules}'");
                validationProblems.Add(nameof(data.AutoMapTimeSchedules), errorsArray.ToArray());
            }

            if (!IsEntityTypeValid(data.EntityType))
            {
                errorsArray.Add($"The EntityType '{data.EntityType}' value is invalid. Valid values are: '{EntityTypes.Administrator}', '{EntityTypes.Customer}', '{EntityTypes.EnterpriseCustomer}', '{EntityTypes.Location}', '{EntityTypes.Dealer}', and '{EntityTypes.Reserved}'");
                validationProblems.Add(nameof(data.EntityType), errorsArray.ToArray());
            }
            else if (original.EntityType != data.EntityType)
            {
                errorsArray.Add($"EntityType cannot be changed from '{original.EntityType}' to '{data.EntityType}'");
                validationProblems.Add(nameof(data.EntityType), errorsArray.ToArray());
            }
            else
            {
                if (data.EntityId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id &&
                    data.EntityType.ToLower() != EntityTypes.Administrator)
                {
                    errorsArray.Add($"Illegal {nameof(data.EntityType)} value for EntityId {data.EntityId}. The only permitted value is '{EntityTypes.Administrator}'");
                    validationProblems.Add(nameof(data.EntityType), errorsArray.ToArray());
                }
                else if (data.EntityId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id &&
                    data.EntityType.ToLower() != EntityTypes.Reserved)
                {
                    errorsArray.Add($"Illegal {nameof(data.EntityType)} value for EntityId {data.EntityId}. The only permitted value is '{EntityTypes.Reserved}'");
                    validationProblems.Add(nameof(data.EntityType), errorsArray.ToArray());
                }
            }

            if (string.IsNullOrEmpty(data.TimeZoneId))
                data.TimeZoneId = original.TimeZoneId;

            if( data.ClusterGroupId == 0)
                data.ClusterGroupId = original.ClusterGroupId;
            
            if (data.ClusterGroupId != original.ClusterGroupId)
            {
                errorsArray.Add($"{nameof(data.ClusterGroupId)} cannot be changed from '{original.ClusterGroupId}' to '{data.ClusterGroupId}'");
                validationProblems.Add(nameof(data.EntityType), errorsArray.ToArray());
            }
            if (validationProblems.Any())
            {
                return new ValidationProblemDetails(validationProblems);
            }

            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// gets editor data.
        /// </summary>
        ///
        /// <remarks>   Kevin, 4/18/2023. </remarks>
        ///
        /// <param name="entityId">             Identifier for the entity to delete. </param>
        /// <param name="includeProperties">    Comma-separated list of property names to include in the
        ///                                     response. </param>
        ///
        /// <returns>   The editor data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        public async Task<ActionResult<ApiEntities.EntityEditingDataBasic>> GetEditorData(Guid entityId, string includeProperties)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<EntityManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfParameters = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = entityId,
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

                var result = await mgr.GetEntityEditingDataAsync(wcfParameters);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();
                var model = Mapper.Map<ApiEntities.EntityEditingDataBasic>(result);
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
