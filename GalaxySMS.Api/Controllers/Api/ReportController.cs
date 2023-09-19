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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using RequestModels = GalaxySMS.Api.Models.RequestModels;
using WcfEntities = GalaxySMS.Business.Entities;
using GalaxySMS.Api.Models.RequestModels;

namespace GalaxySMS.Api.Controllers.Api
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Operations relating to Reports. </summary>
    ///<remarks>  </remarks>
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================

    [Route("api/[controller]")]
    [ApiController]  // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ReportController : ControllerBaseEx
    {
        public ReportController(IConfiguration config,
            IMapper mapper,
            ILogger<ReportController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper, logger, linkGenerator, cache, distributedCache)
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary> Get a collection of Report objects. </summary>
        ///  <param name="entityId"></param>
        /// 
        ///  <returns>   A Task&lt;ActionResult&lt;ApiEntities.Report[]&gt;&gt; </returns>
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
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.Report>>> Get(Guid entityId)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<ReportManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetReportsForEntityAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = entityId,
                    IncludePhoto = includePhoto,
                    PhotoPixelWidth = photoPixelWidth,
                    IncludeMemberCollections = includeChildren
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = new ApiEntities.ArrayResponse<ApiEntities.Report>();
                resp.Items = Mapper.Map<ApiEntities.Report[]>(results);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /////  <summary>
        /////  Get a list of Reports.
        /////  </summary>
        /////  <param name="entityId"></param>
        /////  <param name="includePhoto">     (Optional) True to include photo, false to exclude the photo. </param>
        /////  <param name="photoPixelWidth">  (Optional) Width of the photo pixel. </param>
        ///// 
        /////  <returns>   The list. </returns>
        ///// =================================================================================================
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet("list")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        ////[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        //// If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        ////[MapToApiVersion("1.0")]
        //public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.ListItemBase>>> GetList(Guid entityId)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<ReportManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var results = await mgr.GetReportsListItemsForEntityAsync(new WcfEntities.GetParametersWithPhoto()
        //        {
        //            UniqueId = entityId,
        //            IncludePhoto = includePhoto,
        //            PhotoPixelWidth = photoPixelWidth,
        //            IncludeMemberCollections = false
        //        });

        //        if (mgr.HasErrors)
        //        {
        //            return GetStatusCodeResult(mgr);
        //        }

        //        var resp = new ApiEntities.ArrayResponse<ApiEntities.ListItemBase>();
        //        resp.Items = Mapper.Map<ApiEntities.ListItemBase[]>(results);
        //        return Ok(resp);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary> Get a single Report based on ReportUid (unique id (Guid or uuid) value). </summary>
        /////
        ///// <param name="ReportUid">         Identifier for the Report. </param>
        ///// <param name="includePhoto">     (Optional) True to include photo, false to exclude the photo. </param>
        /////
        ///// <returns>   A Task&lt;ActionResult&lt;ApiEntities.Report[]&gt;&gt; </returns>
        /////=================================================================================================

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet("{ReportUid}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //// If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        ////[MapToApiVersion("1.0")]
        //public async Task<ActionResult<ApiEntities.Report>> Get(Guid ReportUid, bool includePhoto = true)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var getForPut = true;

        //        var includeChildren = true;
        //        if (getForPut)
        //        {
        //            includePhoto = true;
        //        }

        //        var mgr = Helpers.GetManager<ReportManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var result = await mgr.GetReportAsync(new WcfEntities.GetParametersWithPhoto()
        //        {
        //            UniqueId = ReportUid,
        //            IncludePhoto = includePhoto,
        //            IncludeMemberCollections = includeChildren
        //        });

        //        if (mgr.HasErrors)
        //        {
        //            return GetStatusCodeResult(mgr);
        //        }

        //        if (result == null)
        //            return NotFound();

        //        if (getForPut)
        //        {
        //            if (result.gcsBinaryResource?.BinaryResourceUid == Guid.Empty)
        //                result.gcsBinaryResource = null;
        //            return Ok(Mapper.Map<RequestModels.ReportPutReq>(result));
        //        }
        //        var model = Mapper.Map<ApiEntities.Report>(result);
        //        return Ok(model);
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
        ///// Create a new Report item.
        ///// </summary>
        /////
        ///// <param name="parameters">   Options for controlling the operation. </param>
        /////
        ///// <returns>   A Task&lt;ActionResult&lt;ApiEntities.Report[]&gt;&gt; </returns>
        /////=================================================================================================


        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]

        //public async Task<ActionResult<ReportPutReq>> Post(RequestModels.SaveParams<RequestModels.ReportReq> parameters)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

        //        var mgr = Helpers.GetManager<ReportManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

        //        var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

        //        var wcfEntity = Mapper.Map<WcfEntities.Report>(parameters.Data);
        //        wcfEntity.ConcurrencyValue = 0;
        //        if (parameters.Data.Image != null)
        //            wcfEntity.gcsBinaryResource.BinaryResource = parameters.Data.Image;

        //        var wcfParams = new WcfEntities.SaveParameters<WcfEntities.Report>(wcfEntity, wcfSaveParameters);

        //        var results = await mgr.SaveReportAsync(wcfParams);

        //        if (mgr.HasErrors)
        //        {
        //            return GetStatusCodeResult(mgr);
        //        }

        //        if (results != null)
        //        {
        //            var savedItem = Mapper.Map<ReportPutReq>(results);
        //            var url = LinkGenerator.GetPathByAction("Get",
        //                "Report",
        //                new { ReportUid = savedItem.ReportUid });
        //            if (results.UpdateDate > results.InsertDate)
        //                return Ok(savedItem);
        //            return Created(url, savedItem);
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
        ///// Update an existing Report item. Can also create a new Report.
        ///// </summary>
        /////
        ///// <param name="parameters">   Options for controlling the operation. </param>
        /////
        ///// <returns>   A Task&lt;ActionResult&lt;ApiEntities.Report&gt;&gt; </returns>
        /////=================================================================================================
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]

        //public async Task<ActionResult<ReportPutReq>> Put(RequestModels.SaveParams<RequestModels.ReportPutReq> parameters)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        if (parameters.Data.ReportUid == Guid.Empty)
        //            return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot update Report with ReportUid value of {parameters.Data.ReportUid}");

        //        var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

        //        var mgr = Helpers.GetManager<ReportManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

        //        var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

        //        var wcfEntity = Mapper.Map<WcfEntities.Report>(parameters.Data);
        //        var wcfParams = new WcfEntities.SaveParameters<WcfEntities.Report>(wcfEntity, wcfSaveParameters);

        //        var results = await mgr.SaveReportAsync(wcfParams);

        //        if (mgr.HasErrors)
        //        {
        //            return GetStatusCodeResult(mgr);
        //        }

        //        if (results != null)
        //        {
        //            var savedItem = Mapper.Map<ReportPutReq>(results);
        //            var url = LinkGenerator.GetPathByAction("Get",
        //                "Report",
        //                new { ReportUid = savedItem.ReportUid });
        //            if (results.UpdateDate > results.InsertDate)
        //                return Ok(savedItem);
        //            return Created(url, savedItem);
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
        ///// Delete a specific Report by ReportUid.
        ///// </summary>
        /////
        ///// <param name="ReportUid"> Identifier for the Report to delete. </param>
        /////
        ///// <returns>   A Task&lt;IActionResult&gt; </returns>
        /////=================================================================================================        
        //[HttpDelete("{ReportUid}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> Delete(Guid ReportUid)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<ReportManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var result = await mgr.GetReportAsync(new WcfEntities.GetParametersWithPhoto()
        //        {
        //            UniqueId = ReportUid
        //        });

        //        if (mgr.HasErrors)
        //        {
        //            return GetStatusCodeResult(mgr);
        //        }

        //        if (result == null)
        //            return NotFound();

        //        var x = await mgr.DeleteReportByUniqueIdAsync(new WcfEntities.DeleteParameters() { UniqueId = ReportUid });

        //        if (mgr.HasErrors)
        //        {
        //            return GetStatusCodeResult(mgr);
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

    }
}
