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
using Microsoft.Extensions.Caching.Distributed;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using RequestModels = GalaxySMS.Api.Models.RequestModels;
using WcfEntities = GalaxySMS.Business.Entities;
using GalaxySMS.Api.Models.RequestModels;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Extensions;
using System.Globalization;

namespace GalaxySMS.Api.Controllers.Api
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Operations relating to Date Types. </summary>
    ///<remarks>  </remarks>
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================
    //[ApiExplorerSettings(IgnoreApi = true)]

    [Route("api/[controller]")]
    [ApiController]  // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DateTypeController : ControllerBaseEx
    {
        public DateTypeController(IConfiguration config,
            IMapper mapper,
            ILogger<DateTypeController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper, logger, linkGenerator, cache, distributedCache)
        {

        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary>   Get all Date Types for an entity. </summary>
        ///  <param name="entityId"> Specifies the unique id of the entity that dates are requested for</param>
        ///  <param name="pageSize">     Size of the page. 0 = no paging</param>
        ///   <param name="pageNumber">   The page number. </param>
        ///   <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        ///   <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///   <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///  
        ///  <returns>   A Task&lt;ActionResult&lt;ApiEntities.DateTypeBasic[]&gt;&gt; </returns>
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
        public async Task<ActionResult<ApiEntities.ArrayResponse<RequestModels.DateTypePutReqNoEntity>>> GetByEntity(Guid entityId, int pageSize = 0, int pageNumber = 0, bool includeChildren = false, DateTypeSortProperty sortBy = DateTypeSortProperty.Date, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<DateTypeManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetDateTypesForEntityAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    IncludePhoto = false,
                    IncludeMemberCollections = false,
                    UniqueId = entityId,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<RequestModels.DateTypePutReqNoEntity>>(results);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Get all Date Types. </summary>
        /////
        /////  <param name="pageSize">     Size of the page. 0 = no paging</param>
        /////  <param name="pageNumber">   The page number. </param>
        /////  <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        /////  <param name="sortBy"> (Optional) The property to sort the results by</param>
        /////  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        ///// 
        ///// <returns>   A Task&lt;ActionResult&lt;ApiEntities.DateTypeBasic[]&gt;&gt; </returns>
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
        //public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.DateTypeBasic>>> GetAll(int pageSize = 0, int pageNumber = 0, bool includeChildren = false, DateTypeSortProperty sortBy = DateTypeSortProperty.Date, OrderBy orderBy = OrderBy.Asc)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<DateTypeManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var results = await mgr.GetAllDateTypesAsync(new WcfEntities.GetParametersWithPhoto()
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

        //        var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.DateTypeBasic>>(results);
        //        return Ok(resp);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //}



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get all Date Types for a specific day type (for the current entity). </summary>
        ///
        /// <param name="dayTypeUid">   The day type UID. </param>
        ///
        ///  <param name="pageSize">     Size of the page. 0 = no paging</param>
        ///  <param name="pageNumber">   The page number. </param>
        ///  <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        ///  <param name="sortBy"> (Optional) The property to sort the results by</param>
        ///  <param name="orderBy"> (Optional) Specifies if the results should be returned in ascending or descending order.</param>
        /// 
        /// <returns>   The by day type. </returns>
        ///=================================================================================================


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("bydaytype")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.DateTypeBasic>>> GetByDayType(Guid dayTypeUid, int pageSize = 0, int pageNumber = 0, bool includeChildren = false, DateTypeSortProperty sortBy = DateTypeSortProperty.Date, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<DateTypeManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetAllDateTypesForDayTypeAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    IncludePhoto = false,
                    IncludeMemberCollections = false,
                    UniqueId = dayTypeUid,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<ApiEntities.DateTypeBasic>>(results);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }





        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get a Date Type by DateTypeUid value. </summary>
        /// 
        /// <param name="dateTypeUid">   The dateTypeUID. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.DateType&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{dateTypeUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<RequestModels.DateTypePutReq>> Get(Guid dateTypeUid)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var getForPut = true;

                var mgr = Helpers.GetManager<DateTypeManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = dateTypeUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = false,
                };

                //wcfGetParams.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(WcfEntities.Cluster.GalaxyPanels), true));
                //wcfGetParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.Cluster.GalaxyPanels));
                var result = await mgr.GetDateTypeAsync(wcfGetParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();
                if (getForPut)
                    return Ok(Mapper.Map<RequestModels.DateTypePutReq>(result));

                var model = Mapper.Map<ApiEntities.DateType>(result);
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
        /// Gets a list of dates by entity and date range
        /// </summary>
        ///
        /// <remarks>   Kevin, 9/12/2022. </remarks>
        ///
        /// <param name="entityId">         Identifier for the entity. </param>
        /// <param name="year">             The year. </param>
        /// <param name="startMonth">       (Optional) The start month. </param>
        /// <param name="endMonth">         (Optional) The end month. </param>
        /// <param name="pageSize">         (Optional) Size of the page. 0 = no paging. </param>
        /// <param name="pageNumber">       (Optional) The page number. </param>
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        /// <param name="sortBy">           (Optional) The property to sort the results by. </param>
        /// <param name="orderBy">          (Optional) Specifies if the results should be returned in
        ///                                 ascending or descending order. </param>
        ///
        /// <returns>   The list. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("list/{entityId:Guid}/{year:int}/{startMonth:int=0}/{endMonth:int=0}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.ArrayResponse<DateTypePutReqNoEntity>>> GetList(Guid entityId, int year, int startMonth = 0, int endMonth = 0, int pageSize = 0, int pageNumber = 0, bool includeChildren = false, DateTypeSortProperty sortBy = DateTypeSortProperty.Date, OrderBy orderBy = OrderBy.Asc)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (startMonth > 0 && endMonth == startMonth)
                    return ValidationProblem(GetValidationError($"endMonth", $"startMonth and endMonth cannot be the same value"));

                var errors = new List<KeyValuePair<string, string>>();
                if (year < 1 || year > 9999)
                    errors.Add(new KeyValuePair<string, string>(nameof(year), $"{nameof(year)} must be >= 0 and <= 9999"));

                if (startMonth < 0 || startMonth > 12)
                    errors.Add(new KeyValuePair<string, string>(nameof(startMonth), $"{nameof(startMonth)} must be >= 0 and <= 12"));

                if (endMonth < 0 || endMonth > 12)
                    errors.Add(new KeyValuePair<string, string>(nameof(endMonth), $"{nameof(endMonth)} must be >= 0 and <= 12"));

                if (errors.Any())
                    return ValidationProblem(GetValidationError(errors));

                var mgr = Helpers.GetManager<DateTypeManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfGetParams = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = entityId,
                    IncludePhoto = false,
                    IncludeMemberCollections = false,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                    DescendingOrder = orderBy == OrderBy.Desc,
                    SortProperty = sortBy.ToString()
                };

                if (startMonth <= 0 && endMonth <= 0)
                {   // get the entire year
                    wcfGetParams.GetDate = new DateTimeOffset(year, 1, 1, 0, 0, 0, TimeSpan.Zero);
                    wcfGetParams.GetDate2 = wcfGetParams.GetDate.EndOfYear();
                }
                else if (startMonth > 0 && endMonth <= 0)
                {   // no end month specified, so just get one month specified by startMonth
                    wcfGetParams.GetDate = new DateTimeOffset(year, startMonth, 1, 0, 0, 0, TimeSpan.Zero);
                    wcfGetParams.GetDate2 = wcfGetParams.GetDate.EndOfMonth();
                }
                else if (startMonth > 0 && endMonth > 0)
                {   // both start & end month are specified, so a range of months is being requested
                    wcfGetParams.GetDate = new DateTimeOffset(year, startMonth, 1, 0, 0, 0, TimeSpan.Zero);

                    if (endMonth > startMonth)
                    {   // not wrapping year
                        wcfGetParams.GetDate2 = new DateTimeOffset(year, endMonth, 1, 0, 0, 0, TimeSpan.Zero);
                        wcfGetParams.GetDate2 = wcfGetParams.GetDate2.EndOfMonth();
                    }
                    else
                    {   // Next year
                        wcfGetParams.GetDate2 = new DateTimeOffset(year + 1, endMonth, 1, 0, 0, 0, TimeSpan.Zero);
                        wcfGetParams.GetDate2 = wcfGetParams.GetDate2.EndOfMonth();
                    }
                }

                //wcfGetParams.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(WcfEntities.Cluster.GalaxyPanels), true));
                //wcfGetParams.ExcludeMemberCollectionSettings.Add(nameof(WcfEntities.Cluster.GalaxyPanels));
                var results = await mgr.GetDateTypesForEntityAsync(wcfGetParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<DateTypePutReqNoEntity>>(results);

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


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Create a new Date Type.
        /// </summary>
        /// <remarks>    </remarks>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.DateType&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RequestModels.DateTypePutReq>> Post(RequestModels.SaveParams<RequestModels.DateTypeReq> parameters)
        {
            //return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot add an DateType using this technique. New Date Types are created via the GalaxyPanel POST/PUT operations.");
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());
                var mgr = Helpers.GetManager<DateTypeManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.DateType>(parameters.Data);
                wcfEntity.ConcurrencyValue = 0;

                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.DateType>(wcfEntity, wcfSaveParameters);

                var results = await mgr.SaveDateTypeAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var savedItem = Mapper.Map<DateTypePutReq>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "DateType",
                        new { DateTypeUid = savedItem.DateTypeUid });
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
        /// Update an existing Date Type item. Can also create a new Date Type.
        /// </summary>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.DateType&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<DateTypePutReq>> Put(RequestModels.SaveParams<RequestModels.DateTypePutReq> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                if (parameters.Data.DateTypeUid == Guid.Empty)
                    return BadRequest($"Cannot update DateType without a valid DateTypeUid value");

                var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

                var mgr = Helpers.GetManager<DateTypeManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.DateType>(parameters.Data);
                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.DateType>(wcfEntity, wcfSaveParameters);

                var results = await mgr.SaveDateTypeAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var savedItem = Mapper.Map<DateTypePutReq>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "DateType",
                        new { DateTypeUid = savedItem.DateTypeUid });
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
        /// Delete a specific Date Type by DateTypeUid.
        /// </summary>
        ///
        /// <param name="DateTypeUid"> Identifier for the Date Type to delete. </param>
        ///
        /// <returns>   A Task&lt;IActionResult&gt; </returns>
        ///=================================================================================================        
        [HttpDelete("{DateTypeUid}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid DateTypeUid)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<DateTypeManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetDateTypeAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = DateTypeUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = false
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();

                var x = await mgr.DeleteDateTypeByUniqueIdAsync(new WcfEntities.DeleteParameters() { UniqueId = DateTypeUid });

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
