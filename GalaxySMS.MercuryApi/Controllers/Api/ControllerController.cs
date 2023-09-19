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
using AscendGalaxyLibrary.Serialization.Enumeration;
using AscendGalaxyLibrary.Serialization.Mercury;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using MercuryPanelType = AscendGalaxyLibrary.Serialization.Mercury.Enumerations.MercuryPanelType;
using RequestModels = GalaxySMS.Api.Models.RequestModels;
using ResponseModels = GalaxySMS.Api.Models.ResponseModels;
using WcfEntities = GalaxySMS.Business.Entities;
using System.Drawing.Printing;
using System.Globalization;
using System.Net;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.MercuryApi.Controllers.Api
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Operations relating to Galaxy Panels. </summary>
    ///<remarks>  </remarks>
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================

    [Route("api/[controller]")]
    [ApiController]  // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ControllerController : ControllerBaseEx
    {
        public ControllerController(IConfiguration config,
            IMapper mapper,
            ILogger<ControllerController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper, logger, linkGenerator, cache, distributedCache)
        {

        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<AscendGalaxyLibrary.Serialization.Mercury.MercuryPanel[]>> Get()
        {
            //var data = new List<AscendGalaxyLibrary.Serialization.Mercury.MercuryPanel>
            //{
            //    new()
            //    {
            //        Guid = "00000000-0000-0000-0000-000FE50869CF",
            //        MacAddress = "000FE50869CF",
            //        PanelType = MercuryPanelType.LP1501,
            //        Name = "LP1501 000FE50869CF",
            //        Description = "",
            //        Online = false,
            //        DeviceManufacturer = DeviceManufacturer.Mercury,
            //        LastConnected = DateTime.MinValue,
            //        Authorized = true,
            //        Serialnumber = 1234
            //    },
            //    new()
            //    {
            //        Guid = "00000000-0000-0000-0000-000FE50C958C",
            //        MacAddress = "000FE50C958C",
            //        PanelType = MercuryPanelType.LP4502,
            //        Name = "LP4502 000FE50C958C",
            //        Description = "",
            //        Online = false,
            //        DeviceManufacturer = DeviceManufacturer.Mercury,
            //        LastConnected = DateTime.MinValue,
            //        Authorized = true,
            //        Serialnumber = 5678
            //    },
            //    new()
            //    {
            //        Guid = "00000000-0000-0000-0000-000FE50C958B",
            //        MacAddress = "000FE50C958B",
            //        PanelType = MercuryPanelType.LP4502,
            //        Name = "LP4502 000FE50C958B",
            //        Description = "",
            //        Online = false,
            //        DeviceManufacturer = DeviceManufacturer.Mercury,
            //        LastConnected = DateTime.MinValue,
            //        Authorized = true,
            //        Serialnumber = 12344
            //    },
            //    new()
            //    {
            //        Guid = "00000000-0000-0000-0000-000FE500073D",
            //        MacAddress = "000FE500073D",
            //        PanelType = MercuryPanelType.EP1502,
            //        Name = "EP1502 000FE500073D",
            //        Description = "",
            //        Online = false,
            //        DeviceManufacturer = DeviceManufacturer.Mercury,
            //        LastConnected = DateTime.MinValue,
            //        Authorized = false,
            //        Serialnumber = 12345
            //    }
            //};

            //return Ok(data);
            try
            {
                //var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                //if (sessionId == Guid.Empty)
                //    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<MercScpManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.GetAllMercScpsAsync(new WcfEntities.GetParametersWithPhoto()
                {
                    IncludePhoto = false,
                    IncludeMemberCollections = false,
                    IncludeCommands = false,
                    DoNotValidateAuthorization = true
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var data = new List<AscendGalaxyLibrary.Serialization.Mercury.MercuryPanel>();
                foreach (var scp in results.Items)
                {
                    var panelType = MercuryPanelType.SCP;
                    if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.Lp1501)
                        panelType = MercuryPanelType.LP1501;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.Lp1502)
                        panelType = MercuryPanelType.LP1502;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.Lp2500)
                        panelType = MercuryPanelType.LP2500;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.Lp4502)
                        panelType = MercuryPanelType.LP4502;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.SCP)
                        panelType = MercuryPanelType.SCP;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.SCPC)
                        panelType = MercuryPanelType.SCPC;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.SCPE)
                        panelType = MercuryPanelType.SCPE;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.PW5000)
                        panelType = MercuryPanelType.PW5000;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.PW5000A)
                        panelType = MercuryPanelType.PW5000A;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.PW3000)
                        panelType = MercuryPanelType.PW3000;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.EP1501)
                        panelType = MercuryPanelType.EP1501;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.EP1502)
                        panelType = MercuryPanelType.EP1502;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.EP2500)
                        panelType = MercuryPanelType.EP2500;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.EP4502)
                        panelType = MercuryPanelType.EP4502;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.PW6000)
                        panelType = MercuryPanelType.PW6000;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.PRO3200)
                        panelType = MercuryPanelType.PRO3200;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.NXT)
                        panelType = MercuryPanelType.NXT;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.MIRS4)
                        panelType = MercuryPanelType.MIRS4;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.MIXL16)
                        panelType = MercuryPanelType.MIXL16;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.MSICS)
                        panelType = MercuryPanelType.MSICS;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.M5IC)
                        panelType = MercuryPanelType.M5IC;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.SSC)
                        panelType = MercuryPanelType.SSC;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.AP2)
                        panelType = MercuryPanelType.AP2;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.X1100)
                        panelType = MercuryPanelType.X1100;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.PW7000)
                        panelType = MercuryPanelType.PW7000;
                    else if (scp.MercScpTypeUid == GalaxySMS.Common.Constants.MercScpTypeIds.PRO4200)
                        panelType = MercuryPanelType.PRO4200;

                    //if (panelType != MercuryPanelType.SCP)
                    //{
                    var mp = new MercuryPanel()
                    {
                        Guid = scp.MercScpUid.ToString(),
                        Authorized = scp.AllowConnection,
                        Description = scp.Description,
                        DeviceManufacturer = DeviceManufacturer.Mercury,
                        LastConnected = DateTime.MinValue,
                        MacAddress = scp.MacAddress,
                        Name = scp.ScpName,
                        Online = null,
                        Serialnumber = scp.Serialnumber,
                        PanelType = panelType
                    };
                    data.Add(mp);
                    //                   }
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        //      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Add new panels. </summary>
        ///
        /// <remarks>   Adds new panels. Duplicate MACAddress values are not permitted. If any dups are detected, the entire request fails. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A list of. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiEntities.SaveResponse<List<ApiEntities.MercuryPanel>>>> Post(List<MercuryPanel> parameters)
        {
            try
            {
                //var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                //if (sessionId == Guid.Empty)
                //    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var wcfEntity = Mapper.Map<List<WcfEntities.MercuryPanel>>(parameters);
                var mgr = Helpers.GetManager<MercScpManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var wcfParams = new WcfEntities.SaveParameters<List<WcfEntities.MercuryPanel>>(wcfEntity);
                wcfParams.SaveType = SaveOperationType.AddOnly;
                var results = await mgr.SaveMercuryPanelsAsync(wcfParams);
                if (results != null)
                {
                    if (results.HttpStatus == HttpStatusCode.BadRequest && results.Errors.Any())
                    {
                        return ValidationProblem(new ValidationProblemDetails(results.Errors));
                    }
                    else if (results.HttpStatus == HttpStatusCode.OK)
                    {
                        var savedItem = Mapper.Map<ApiEntities.SaveResponse<List<ApiEntities.MercuryPanel>>>(results);
                        return Ok(savedItem.Data);
                    }
                    //if( results.Ex != null)
                    //    return this.StatusCode((int)results.HttpStatus, results.Ex.Message);

                    return this.StatusCode((int)results.HttpStatus, ResponseMessages.UnknownReason);
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


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiEntities.SaveResponse<List<ApiEntities.MercuryPanel>>>> Put(List<MercuryPanel> parameters)
        {
            try
            {
                //var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                //if (sessionId == Guid.Empty)
                //    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var wcfEntity = Mapper.Map<List<WcfEntities.MercuryPanel>>(parameters);
                var mgr = Helpers.GetManager<MercScpManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var wcfParams = new WcfEntities.SaveParameters<List<WcfEntities.MercuryPanel>>(wcfEntity);
                wcfParams.SaveType = SaveOperationType.UpdateOnly;
                var results = await mgr.SaveMercuryPanelsAsync(wcfParams);
                if (results != null)
                {
                    if (results.HttpStatus == HttpStatusCode.BadRequest && results.Errors.Any())
                    {
                        return ValidationProblem(new ValidationProblemDetails(results.Errors));
                    }
                    else if (results.HttpStatus == HttpStatusCode.OK)
                    {
                        var savedItem = Mapper.Map<ApiEntities.SaveResponse<List<ApiEntities.MercuryPanel>>>(results);
                        return Ok(savedItem.Data);
                    }
                    //if( results.Ex != null)
                    //    return this.StatusCode((int)results.HttpStatus, results.Ex.Message);

                    return this.StatusCode((int)results.HttpStatus, ResponseMessages.UnknownReason);
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



    }
}
