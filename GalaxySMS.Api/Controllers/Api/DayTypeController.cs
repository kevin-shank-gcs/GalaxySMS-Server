extern alias NetCoreCommon;
using AutoMapper;
using GalaxySMS.Api.Support;
using GalaxySMS.Client.SDK.Helpers;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
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
using System.ServiceModel;
using System.Threading.Tasks;
using GCS.Core.Common.Extensions;
using Microsoft.Extensions.Caching.Distributed;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using RequestModels = GalaxySMS.Api.Models.RequestModels;
using WcfEntities = GalaxySMS.Business.Entities;
using GalaxySMS.Api.Models.RequestModels;
using GalaxySMS.Common.Enums;
using System.Globalization;
using Microsoft.Extensions.Options;

namespace GalaxySMS.Api.Controllers.Api
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Operations relating to Day Types. </summary>
    ///<remarks>  </remarks>
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================
    //[ApiExplorerSettings(IgnoreApi = true)]

    [Route("api/[controller]")]
    [ApiController]  // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DayTypeController : ControllerBaseEx
    {
        public DayTypeController(IConfiguration config,
            IMapper mapper,
            ILogger<DayTypeController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper, logger, linkGenerator, cache, distributedCache)
        {

        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get all Day Types for an entity. </summary>
        ///
        /// <param name="entityId">     (Optional) The unique ID of the entity to request day types for. If not specified, day types for current entity will be requested. </param>
        /// <param name="isActive">     (Optional) If specified, only DayTypes that match the isActive parameter value will be returned. If omitted, all DayTypes will be returned</param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.DayTypeBasic[]&gt;&gt; </returns>
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
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.DayTypeBasic>>> GetByEntity(Guid entityId, bool? isActive, int pageSize, int pageNumber, bool includeChildren = false, DayTypeSortProperty sortBy = DayTypeSortProperty.Name, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<DayTypeManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var wcfParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = entityId,
                    IncludePhoto = false,
                    IncludeMemberCollections = includeChildren,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                };

                if (isActive.HasValue)
                {
                    wcfParams.AddOption(GetOptions_DayType.IsActive, isActive.Value);
                }

                var results = await mgr.GetDayTypesForEntityAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.DayTypeBasic>>(results);
                //var resp = new ApiEntities.ArrayResponse<ApiEntities.DayTypeBasic>();
                //resp.Items = Mapper.Map<ApiEntities.DayTypeBasic[]>(results.Items);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get all Day Types for an entity. </summary>
        ///
        /// <param name="entityId">     (Optional) The unique ID of the entity to request day types for. If not specified, day types for current entity will be requested. </param>
        /// <param name="isActive"></param>
        /// <param name="isActive">     (Optional) If specified, only DayTypes that match the isActive parameter value will be returned. If omitted, all DayTypes will be returned</param>
        /// <param name="pageSize">     Size of the page. 0 = no paging</param>
        /// <param name="pageNumber">   The page number. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        /// 
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.DayTypeBasic[]&gt;&gt; </returns>
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
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.DayTypeListItem>>> GetList(Guid entityId, bool? isActive, int pageSize, int pageNumber, DayTypeSortProperty sortBy = DayTypeSortProperty.Name, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<DayTypeManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var wcfParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = entityId,
                    IncludePhoto = false,
                    IncludeMemberCollections = false,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                };

                if (isActive.HasValue)
                {
                    wcfParams.AddOption(GetOptions_DayType.IsActive, isActive.Value);
                }

                var results = await mgr.GetAllDayTypesListForEntityAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.DayTypeListItem>>(results);

                //var resp = new ApiEntities.ArrayResponse<ApiEntities.ListItemBase>();
                //resp.Items = Mapper.Map<ApiEntities.ListItemBase[]>(results);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Get all Day Types. </summary>
        /////
        ///// <param name="pageSize">     Size of the page. 0 = no paging</param>
        ///// <param name="pageNumber">   The page number. </param>
        ///// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        /////  <param name="sortBy"> (Optional) The property to sort the results by</param>
        /////  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        /////
        ///// <returns>   A Task&lt;ActionResult&lt;ApiEntities.DayTypeBasic[]&gt;&gt; </returns>
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
        //public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.DayTypeBasic>>> GetAll(int pageSize, int pageNumber, bool includeChildren = false, DayTypeSortProperty sortBy = DayTypeSortProperty.Name, OrderBy orderBy = OrderBy.Asc)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<DayTypeManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var results = await mgr.GetAllDayTypesAsync(new WcfEntities.GetParametersWithPhoto()
        //        {
        //            IncludePhoto = false,
        //            IncludeMemberCollections = includeChildren,
        //            PageNumber = pageNumber,
        //            PageSize = pageSize,
        //            DescendingOrder = orderBy == OrderBy.Desc,
        //            SortProperty = sortBy.ToString()
        //        });

        //        if (mgr.HasErrors)
        //        {
        //            return GetStatusCodeResult(mgr);
        //        }

        //        var resp = new ApiEntities.ArrayResponse<ApiEntities.DayTypeBasic>();
        //        resp.Items = Mapper.Map<ApiEntities.DayTypeBasic[]>(results);
        //        return Ok(resp);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //}


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Get list of all Day Types. </summary>
        ///// 
        ///// <param name="pageSize">     Size of the page. 0 = no paging</param>
        ///// <param name="pageNumber">   The page number. </param>
        /////  <param name="sortBy"> (Optional) The property to sort the results by</param>
        /////  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        /////
        ///// <returns>   A Task&lt;ActionResult&lt;ApiEntities.DayTypeListItem[]&gt;&gt; </returns>
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
        //public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.DayTypeListItem>>> GetAllList(int pageSize, int pageNumber, DayTypeSortProperty sortBy = DayTypeSortProperty.Name, OrderBy orderBy = OrderBy.Asc)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<DayTypeManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var results = await mgr.GetAllDayTypesListAsync(new WcfEntities.GetParametersWithPhoto()
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

        //        //var resp = new ApiEntities.ArrayResponse<ApiEntities.ListItemBase>();
        //        //resp.Items = Mapper.Map<ApiEntities.ListItemBase[]>(results);
        //        var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.DayTypeListItem>>(results);
        //        return Ok(resp);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //}


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get a Day Type by DayTypeUid value. </summary>
        /// 
        /// <param name="dayTypeUid">   The DayTypeUID. </param>
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        ///
        /// <remarks> IgnoreProperties: EntityIds</remarks>
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.DayType&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{dayTypeUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.DayType>> Get(Guid dayTypeUid, bool includeChildren = false)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var getForPut = true;

                var mgr = Helpers.GetManager<DayTypeManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = dayTypeUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = includeChildren,
                };

                //wcfGetParams.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(WcfEntities.Cluster.GalaxyPanels), true));
                //wcfGetParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.Cluster.GalaxyPanels));
                var result = await mgr.GetDayTypeAsync(wcfGetParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                if (getForPut)
                    return Ok(Mapper.Map<RequestModels.DayTypePutReq>(result));

                var model = Mapper.Map<ApiEntities.DayType>(result);
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
        /// Create a new Day Type.
        /// </summary>
        /// <remarks>    </remarks>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.DayType&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DayTypePutReq>> Post(RequestModels.SaveParams<RequestModels.DayTypeReq> parameters, bool includeChildren = false)
        {
            //return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot add an DayType using this technique. New Day Types are created via the GalaxyPanel POST/PUT operations.");
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());
                var mgr = Helpers.GetManager<DayTypeManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                if (parameters.Data.IsActive == null)
                    parameters.Data.IsActive = true;

                var wcfEntity = Mapper.Map<WcfEntities.DayType>(parameters.Data);

                if (wcfEntity.Dates.Any())
                {
                    var dateValidationResults = await mgr.ValidateDatesForDayTypeAsync(wcfEntity);
                    if (mgr.HasErrors)
                    {
                        return GetStatusCodeResult(mgr);
                    }

                    if (dateValidationResults.Any())
                    {
                        var validationProblems = new Dictionary<string, string[]>();

                        foreach (var error in dateValidationResults)
                        {
                            var errorsArray = new List<string>();
                            errorsArray.Add(
                                $"Date '{error.Date.Date.ToShortDateString()}' is currently assigned to DayType '{error.DayTypeName}', (DayTypeUid: {error.DayTypeUid}).");
                            validationProblems.Add($"Data.{nameof(WcfEntities.DayType.Dates)}[{error.Index}].Date",
                                errorsArray.ToArray());
                        }

                        return ValidationProblem(new ValidationProblemDetails(validationProblems));
                    }
                }

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);
                wcfSaveParameters.IncludeMemberCollections = includeChildren;
                wcfSaveParameters.Options.Add(new KeyValuePair<string, string>(nameof(SaveDayTypeOption.SaveDates), SaveDayTypeOption.SaveDates.ToString()));
                if (parameters.Data.DayTypeUid == Guid.Empty &&
                    parameters.Data.DayTypeCode == DayTypeCode.DayType0)
                {
                    wcfSaveParameters.Options.Add(new KeyValuePair<string, string>(nameof(SaveDayTypeOption.SelectIsActiveFalseDayTypeForReuse), true.ToString()));
                }

                wcfEntity.ConcurrencyValue = 0;
                wcfEntity.HighlightColor = parameters.Data.HighlightColorRGBA.RGBAToInt();
                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.DayType>(wcfEntity, wcfSaveParameters);

                var results = await mgr.SaveDayTypeAsync(wcfParams);
                if (results != null)
                {
                    var savedItem = Mapper.Map<DayTypePutReq>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "DayType",
                        new { DayTypeUid = savedItem.DayTypeUid });
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
        /// Ensures that default day types exist for the current entity. Any missing day types will be created.
        /// </summary>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.DayTypeBasic[]&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("verifydefaults")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ApiEntities.DayTypeBasic[]>> EnsureDefaultDayTypesExist()
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());
                var mgr = Helpers.GetManager<DayTypeManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var results = await mgr.EnsureDefaultDayTypesExistForEntityAsync(new WcfEntities.SaveParameters<WcfEntities.DayType>()
                {

                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    if (!results.Items.Any())
                        return NotFound();
                    var models = Mapper.Map<ApiEntities.DayTypeBasic[]>(results);
                    return Ok(models);
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
        /// Update an existing Day Type item. Can also create a new Day Type.
        /// </summary>
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.DayType&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<DayTypePutReq>> Put(RequestModels.SaveParams<RequestModels.DayTypePutReq> parameters, bool includeChildren = false)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (parameters.Data.DayTypeUid == Guid.Empty)
                    return BadRequest($"Cannot update DayType without a valid DayTypeUid value");

                var getForPut = true;

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());
                var wcfEntity = Mapper.Map<WcfEntities.DayType>(parameters.Data);

                var mgr = Helpers.GetManager<DayTypeManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                if (parameters.Data.Dates.Any())
                {
                    var dateValidationResults = await mgr.ValidateDatesForDayTypeAsync(wcfEntity);
                    if (mgr.HasErrors)
                    {
                        return GetStatusCodeResult(mgr);
                    }

                    if (dateValidationResults.Any())
                    {
                        var validationProblems = new Dictionary<string, string[]>();

                        foreach (var error in dateValidationResults)
                        {
                            var errorsArray = new List<string>();
                            errorsArray.Add(
                                $"Date '{error.Date.Date.ToShortDateString()}' is currently assigned to DayType '{error.DayTypeName}', (DayTypeUid: {error.DayTypeUid}).");
                            validationProblems.Add($"Data.{nameof(WcfEntities.DayType.Dates)}[{error.Index}].Date",
                                errorsArray.ToArray());
                        }

                        return ValidationProblem(new ValidationProblemDetails(validationProblems));
                    }
                }

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);
                wcfSaveParameters.IncludeMemberCollections = includeChildren;
                wcfSaveParameters.Options.Add(new KeyValuePair<string, string>(nameof(SaveDayTypeOption.SaveDates), SaveDayTypeOption.SaveDates.ToString()));
                wcfSaveParameters.Options.Add(new KeyValuePair<string, string>(nameof(SaveDayTypeOption.DeleteMissingDates), SaveDayTypeOption.DeleteMissingDates.ToString()));
//                wcfSaveParameters.Options.Add(new KeyValuePair<string, string>(nameof(SaveDayTypeOption.SetIsActiveFalseIfNoDates), true.ToString()));

                wcfEntity.HighlightColor = parameters.Data.HighlightColorRGBA.RGBAToInt();

                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.DayType>(wcfEntity, wcfSaveParameters);

                var results = await mgr.SaveDayTypeAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var url = LinkGenerator.GetPathByAction("Get",
                        "DayType",
                        new { DayTypeUid = results.DayTypeUid });
                    if (results.UpdateDate > results.InsertDate)
                    {
                        //if (getForPut)
                        return Ok(Mapper.Map<RequestModels.DayTypePutReq>(results));

                        //return Ok(Mapper.Map<ApiEntities.DayType>(results));
                    }

                    //if (getForPut)
                    return Created(url, Mapper.Map<RequestModels.DayTypePutReq>(results));
                    //return Created(url, Mapper.Map<ApiEntities.DayType>(results));
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
        /// Delete a specific Day Type by DayTypeUid.
        /// </summary>
        ///
        /// <param name="DayTypeUid"> Identifier for the Day Type to delete. </param>
        ///
        /// <returns>   A Task&lt;IActionResult&gt; </returns>
        ///=================================================================================================        
        [HttpDelete("{DayTypeUid}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid DayTypeUid)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<DayTypeManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetDayTypeAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = DayTypeUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = false
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                result.IsActive = false;
                result.Dates = new List<WcfEntities.DateType>();
                result.HighlightColor = 0;

                var wcfSaveParams = new WcfEntities.SaveParameters<WcfEntities.DayType>() { Data = result };
                var updatedResult = await mgr.SaveDayTypeAsync(wcfSaveParams);
                //var x = await mgr.DeleteDayTypeByUniqueIdAsync(new WcfEntities.DeleteParameters() { UniqueId = DayTypeUid });

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
