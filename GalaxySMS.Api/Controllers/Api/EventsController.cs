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
using WcfEntities = GalaxySMS.Business.Entities;
using GalaxySMS.Api.Models.RequestModels;
using GCS.Core.Common.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GalaxySMS.Api.Controllers.Api
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Operations relating to Departments. </summary>
    ///<remarks>  </remarks>
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================

    [Route("api/[controller]")]
    [ApiController]  // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EventsController : ControllerBaseEx
    {
        public EventsController(IConfiguration config,
            IMapper mapper,
            ILogger<EventsController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper, logger, linkGenerator, cache, distributedCache)
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary>
        ///  Get events for a specific entity.
        ///  </summary>
        /// 
        ///  <param name="entityId">  The entity ID. </param>
        ///  <param name="parameters"></param>
        ///  <param name="fromFlatTables"></param>
        ///  <returns>   The departments for the entity. </returns>
        /// =================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet("{entityId}")]
        [HttpPost("{entityId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.ArrayResponse<Models.ResponseModels.ActivityHistoryEventBasicResp>>> Get(Guid entityId, ApiEntities.EventSearchParameters parameters, bool fromFlatTables = true)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var wcfParams = new WcfEntities.ActivityHistoryEventSearchParameters
                {
                    CurrentEntityId = entityId,
                    UniqueId = entityId,
                    PageNumber = parameters.PageNumber,
                    PageSize = parameters.PageSize,
                    DescendingOrder = parameters.OrderBy == OrderBy.Desc,
                    SortProperty = parameters.SortBy.ToString(),
                    StartDateTime = parameters.StartDateTime,
                    EndDateTime = parameters.EndDateTime,
                    ClusterUid = parameters.ClusterUid,
                    DeviceUid = parameters.DeviceUid,
                    PersonUid = parameters.PersonUid,
                    IsAcknowledgeable = parameters.IsAcknowledgeable,
                    IsActionRequired = parameters.IsActionRequired,
                    IsTraced = parameters.IsTraced,
                    StartPriority = parameters.StartPriority,
                    EndPriority = parameters.EndPriority,
                    JustNumber = parameters.JustNumber,
                    EventTypeUids = parameters.EventTypeUids,
                    Priorities = parameters.Priorities,
                    IncludeLoggingOnOffEvents = parameters.IncludeLoggingOnOffEvents,
                    IncludeAcknowlegements = parameters.IncludeAcknowledgements,
                };

                wcfParams.AddOption(GetOptions_ActivityHistoryEvents.GetFromFlatTables.ToString(), fromFlatTables);
                //if (!string.IsNullOrEmpty(eventTypeUids))
                //{
                //    wcfParams.EventTypeUids = eventTypeUids.ToIEnumerableOf<Guid>(',').ToCollection();
                //}
                //if (!string.IsNullOrEmpty(priorities))
                //{
                //    wcfParams.Priorities = priorities.ToIEnumerableOf<int>(',').ToCollection();
                //}

                var mgr = Helpers.GetManager<ActivityHistoryEventManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetActivityHistoryEventsAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<GalaxySMS.Api.Models.ResponseModels.ActivityHistoryEventBasicResp>>(results);
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
        ///  Get events for a specific entity.
        ///  </summary>
        /// 
        ///  <param name="entityId">  The entity ID. </param>
        ///  <param name="parameters"></param>
        ///  <returns>   The departments for the entity. </returns>
        /// =================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet("{entityId}")]
        [HttpPost("allforoperator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.ArrayResponse<Models.ResponseModels.ActivityHistoryEventBasicWithEntityResp>>> GetAllForOperator(ApiEntities.EventSearchParameters parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var wcfParams = new WcfEntities.ActivityHistoryEventSearchParameters
                {
                    PageNumber = parameters.PageNumber,
                    PageSize = parameters.PageSize,
                    DescendingOrder = parameters.OrderBy == OrderBy.Desc,
                    SortProperty = parameters.SortBy.ToString(),
                    StartDateTime = parameters.StartDateTime,
                    EndDateTime = parameters.EndDateTime,
                    ClusterUid = parameters.ClusterUid,
                    DeviceUid = parameters.DeviceUid,
                    PersonUid = parameters.PersonUid,
                    IsAcknowledgeable = parameters.IsAcknowledgeable,
                    IsActionRequired = parameters.IsActionRequired,
                    IsTraced = parameters.IsTraced,
                    StartPriority = parameters.StartPriority,
                    EndPriority = parameters.EndPriority,
                    JustNumber = parameters.JustNumber,
                    EventTypeUids = parameters.EventTypeUids,
                    Priorities = parameters.Priorities,
                    IncludeLoggingOnOffEvents = parameters.IncludeLoggingOnOffEvents,
                    ForCurrentUser = true
                };

                //if (!string.IsNullOrEmpty(eventTypeUids))
                //{
                //    wcfParams.EventTypeUids = eventTypeUids.ToIEnumerableOf<Guid>(',').ToCollection();
                //}
                //if (!string.IsNullOrEmpty(priorities))
                //{
                //    wcfParams.Priorities = priorities.ToIEnumerableOf<int>(',').ToCollection();
                //}

                var mgr = Helpers.GetManager<ActivityHistoryEventManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetActivityHistoryEventsAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.ArrayResponse<GalaxySMS.Api.Models.ResponseModels.ActivityHistoryEventBasicWithEntityResp>>(results);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("filterdata")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.EventFilterData>> GetFilterData(Guid? personUid, Guid? clusterUid, Guid? galaxyPanelUid, Guid? accessPortalUid, Guid? inputDeviceUid, Guid? outputDeviceUid, string eventTypeUids)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<ActivityHistoryEventManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var parameters = new WcfEntities.EventFilterDataSelectionParameters()
                {

                };
                if (personUid.HasValue)
                    parameters.PersonUid = personUid.Value;
                if (clusterUid.HasValue)
                    parameters.ClusterUid = clusterUid.Value;
                if (galaxyPanelUid.HasValue)
                    parameters.GalaxyPanelUid = galaxyPanelUid.Value;
                if (accessPortalUid.HasValue)
                    parameters.AccessPortalUid = accessPortalUid.Value;
                if (inputDeviceUid.HasValue)
                    parameters.InputDeviceUid = inputDeviceUid.Value;
                if (outputDeviceUid.HasValue)
                    parameters.OutputDeviceUid = outputDeviceUid.Value;
                if (!string.IsNullOrEmpty(eventTypeUids))
                    parameters.EventTypeUIds = eventTypeUids.ToIEnumerableGuid(',').ToCollection();

                var results = await mgr.GetEventFilterDataAsync(parameters);
                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    if (string.IsNullOrEmpty(results.DeviceName))
                        results.DeviceName = null;
                    if (string.IsNullOrEmpty(results.DeviceType))
                        results.DeviceType = null;
                }
                var resp = Mapper.Map<ApiEntities.EventFilterData>(results);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("acknowledge")]
        //[SwaggerRequestExample(typeof(RequestModels.SaveParams<RequestModels.Entity>), typeof(SaveEntityExamples))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ApiEntities.AcknowledgedAlarmBasicData>> Acknowledge(RequestModels.SaveParams<ApiEntities.AcknowledgeAlarmEventParameters> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<AlarmEventAcknowledgeManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.AcknowledgeAlarmEventAsync(Mapper.Map<WcfEntities.SaveParameters<WcfEntities.AcknowledgeAlarmEventParameters>>(parameters));

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (results != null)
                {
                    var savedItem = Mapper.Map<ApiEntities.AcknowledgedAlarmBasicData>(results);
                    return Ok(savedItem);
                }

                return NotFound($"activityEventUid: {parameters.Data.ActivityEventUid} not found");
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("unacknowledge")]
        //[SwaggerRequestExample(typeof(RequestModels.SaveParams<RequestModels.Entity>), typeof(SaveEntityExamples))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> Unacknowledge(RequestModels.SaveParams<ApiEntities.UnacknowledgeAlarmEventParameters> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<AlarmEventAcknowledgeManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.UnacknowledgeAlarmEventAsync(Mapper.Map<WcfEntities.SaveParameters<WcfEntities.UnacknowledgeAlarmEventParameters>>(parameters));

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }
                
                if (results != 0)
                {
                    return Ok(new {deletedCount = results});
                }

                return NotFound($"Acknowledgement(s) for activityEventUid: {parameters.Data.ActivityEventUid} not found");
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


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("eventtypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.GalaxyActivityEventTypeBasicGroups>> GetActivityEventTypes()
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<GalaxyActivityEventTypeManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var parameters = new WcfEntities.GetParametersWithPhoto()
                {

                };
                var results = await mgr.GetGalaxyActivityEventTypesAsync(parameters);
                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.GalaxyActivityEventTypeBasicGroups>(results);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }



        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("alarmsettingform")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.EntityDeviceAlertEventSettings>> GetAlarmSettings(Guid entityId)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<ActivityHistoryEventManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var parameters = new WcfEntities.GetParametersWithPhoto()
                {
                    UniqueId = entityId,
                    GetBool = true
                };
                var results = await mgr.GetDeviceAlertEventSettingsAsync(parameters);
                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.EntityDeviceAlertEventSettings>(results);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("alarmsettingform")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<ApiEntities.EntityDeviceAlertEventSettings>> SaveAlarmSettings(RequestModels.SaveParams<ApiEntities.EntityDeviceAlertEventSettings> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<ActivityHistoryEventManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.EntityDeviceAlertEventSettings>(parameters.Data);

                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.EntityDeviceAlertEventSettings>(wcfEntity, wcfSaveParameters);
                var results = await mgr.SaveDeviceAlertEventSettingsAsync(wcfParams);
                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = Mapper.Map<ApiEntities.EntityDeviceAlertEventSettings>(results);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }


        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet("acknowledeableeventtypes")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        ////[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        //// If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        ////[MapToApiVersion("1.0")]
        //public async Task<ActionResult<ApiEntities.EntityDeviceAlertEventSettings>> GetAcknowledeableEventTypes()
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<ActivityHistoryEventManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

        //        var parameters = new WcfEntities.GetParametersWithPhoto()
        //        {
        //            UniqueId = entityId,
        //            GetBool = true
        //        };
        //        var results = await mgr.GetDeviceAlertEventSettingsAsync(parameters);
        //        if (mgr.HasErrors)
        //        {
        //            return GetStatusCodeResult(mgr);
        //        }

        //        var resp = Mapper.Map<ApiEntities.EntityDeviceAlertEventSettings>(results);

        //        return Ok(resp);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //}

    }
}
