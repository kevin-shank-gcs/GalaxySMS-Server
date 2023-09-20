extern alias NetCoreCommon;
using AutoMapper;
using GalaxySMS.MercuryApi.Support;
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
    /// <summary>   Operations relating to Merc Panels. </summary>
    ///<remarks>  </remarks>
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]  // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MercScpController : ControllerBaseEx
    {
        public MercScpController(IConfiguration config,
            IMapper mapper,
            ILogger<MercScpController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper, logger, linkGenerator, cache, distributedCache)
        {

        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get all Merc panels. </summary>
        ///
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        /// <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
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
        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.GalaxyPanelBasic>>> Get(bool includeChildren = false, bool includeCommands = false)
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
                    IncludeCommands = includeCommands
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = new ApiEntities.ArrayResponse<ApiEntities.GalaxyPanelBasic>();
                resp.Items = Mapper.Map<ApiEntities.GalaxyPanelBasic[]>(results);
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
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        /// <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.GalaxyPanelBasic>>> GetGalaxyControllersForSite(Guid siteUid, bool includeChildren = false, bool includeCommands = false)
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
                    IncludeCommands = includeCommands
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = new ApiEntities.ArrayResponse<ApiEntities.GalaxyPanelBasic>();
                resp.Items = Mapper.Map<ApiEntities.GalaxyPanelBasic[]>(results);
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
        /// <param name="includeChildren">  (Optional) True to include, false to exclude the children. </param>
        /// <param name="includeCommands">  (Optional) True to include, false to exclude the commands that are available. </param>
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

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.GalaxyPanelBasic>>> GetGalaxyControllersForCluster(Guid clusterUid, bool includeChildren = false, bool includeCommands = false)
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
                    IncludeCommands = includeCommands
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                var resp = new ApiEntities.ArrayResponse<ApiEntities.GalaxyPanelBasic>();
                resp.Items = Mapper.Map<ApiEntities.GalaxyPanelBasic[]>(results);
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
        public async Task<ActionResult<ResponseModels.GalaxyPanelResp>> Get(Guid galaxyPanelUid, bool includeChildren = false)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

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
        /// Get Merc panel editor data.
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

        public async Task<ActionResult<ApiEntities.GalaxyPanelEditingData>> GetEditorData()
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<GalaxyPanelManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var result = await mgr.GetGalaxyPanelEditingDataAsync(new WcfEntities.GetParametersWithPhoto()
                {
                });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }

                if (result == null)
                    return NotFound();
                var model = Mapper.Map<ApiEntities.GalaxyPanelEditingData>(result);
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


        /////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Create a new Merc panel.
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
        public async Task<ActionResult<ApiEntities.GalaxyPanel>> Post(RequestModels.SaveParams<RequestModels.GalaxyPanelReq> parameters)
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

                // Validate, Convert Enum to appropriate UID values and Build up the hardware correctly
                foreach (var b in parameters.Data.InterfaceBoards)
                {
                    // If the InterfaceBoardTypeUid is empty, then assign it the correct value based on the BoardType enum value
                    if (b.InterfaceBoardTypeUid == Guid.Empty)
                    {
                        switch (b.BoardType)
                        {
                            case Common.Enums.GalaxyInterfaceBoardType.None:
                            case Common.Enums.GalaxyInterfaceBoardType.Cpu600:
                            case Common.Enums.GalaxyInterfaceBoardType.Cpu635:
                            case Common.Enums.GalaxyInterfaceBoardType.DualPortInterfaceBoard500:
                                return BadRequest($"Unsupported board type: {b.BoardType}");

                            case Common.Enums.GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
                                b.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface600;
                                break;

                            case Common.Enums.GalaxyInterfaceBoardType.DigitalInputOutputBoard600:
                                b.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DigitalInputOutput600;
                                break;

                            //case Common.Enums.GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                            //    b.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface600;
                            //    break;

                            case Common.Enums.GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                            case Common.Enums.GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
                                b.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635;
                                break;

                            case Common.Enums.GalaxyInterfaceBoardType.OtisElevatorInterface:
                                b.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_OtisElevatorInterface;
                                break;

                            //case Common.Enums.GalaxyInterfaceBoardTypCardTourManagerCpu:
                            //    b.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_CardTourManager;
                            //    break;

                            case Common.Enums.GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                                b.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635;
                                break;

                            case Common.Enums.GalaxyInterfaceBoardType.KoneElevatorInterface:
                                b.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_KoneElevatorInterface;
                                break;

                            case Common.Enums.GalaxyInterfaceBoardType.Veridt_Cpu:
                                b.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_Cpu;
                                break;

                            case Common.Enums.GalaxyInterfaceBoardType.Veridt_ReaderModule:
                                b.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_ReaderModule;
                                break;

                        }
                    }

                    var sections = new List<RequestModels.GalaxyInterfaceBoardSectionReq>();
                    if (b.InterfaceBoardSections != null)
                        sections = b.InterfaceBoardSections.ToList();

                    if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface600)
                    {   // there must be two sections, numbered 1 & 2
                        var invalidSections = sections.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
                        foreach (var s in invalidSections)
                        {
                            //sections.Remove(s);
                            return BadRequest($"Invalid section number {s.SectionNumber}. This board type can only have section numbers 1 and 2");
                        }
                    }
                    else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635)
                    {
                        var invalidSections = sections.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
                        foreach (var s in invalidSections)
                        {
                            //sections.Remove(s);
                            return BadRequest($"Invalid section number {s.SectionNumber}. This board type can only have section numbers 1 and 2");
                        }
                    }
                    //else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface600)
                    //{
                    //    var invalidSections = sections.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
                    //    foreach (var s in invalidSections)
                    //    {
                    //        //sections.Remove(s);
                    //        return BadRequest($"Invalid section number {s.SectionNumber}. This board type can only have section numbers 1 and 2");
                    //    }
                    //    foreach (var s in sections)
                    //    {
                    //        // If the InterfaceBoardSectionModeUid is not specified, then use the SectionType enum and assign the correct Uid value
                    //        if (s.InterfaceBoardSectionModeUid == Guid.Empty)
                    //        {
                    //            switch (s.SectionMode)
                    //            {
                    //                case Common.Enums.PanelInterfaceBoardSectionType.DsiIngersolRandPimClockData:
                    //                    s.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimAba;
                    //                    break;

                    //                case Common.Enums.PanelInterfaceBoardSectionType.DsiIngersolRandPimWiegand:
                    //                    s.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand;
                    //                    break;

                    //                case Common.Enums.PanelInterfaceBoardSectionType.DsiAssaAbloyAperio:
                    //                    s.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio;
                    //                    break;

                    //                case Common.Enums.PanelInterfaceBoardSectionType.DsiCypressClockDisplay:
                    //                    s.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_CypressClockDisplay;
                    //                    break;

                    //                case Common.Enums.PanelInterfaceBoardSectionType.DsiElevatorControlRelays:
                    //                    s.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_ElevatorRelays;
                    //                    break;

                    //                case Common.Enums.PanelInterfaceBoardSectionType.DsiLcd4x20Display:
                    //                    s.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_LCD_4x20Display;
                    //                    break;

                    //                case Common.Enums.PanelInterfaceBoardSectionType.DsiOutputControlRelays:
                    //                    s.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_OutputRelays;
                    //                    break;

                    //                case Common.Enums.PanelInterfaceBoardSectionType.DsiSalto:
                    //                    s.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_SaltoSallis;
                    //                    break;

                    //                case Common.Enums.PanelInterfaceBoardSectionType.DrmSection:
                    //                case Common.Enums.PanelInterfaceBoardSectionType.None:
                    //                case Common.Enums.PanelInterfaceBoardSectionType.Dio8X4Outputs:
                    //                case Common.Enums.PanelInterfaceBoardSectionType.Dio8X4Inputs:
                    //                case Common.Enums.PanelInterfaceBoardSectionType.DsiRs485DoorModule:
                    //                case Common.Enums.PanelInterfaceBoardSectionType.DsiRs485InputModule:
                    //                case Common.Enums.PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                    //                //case Common.Enums.PanelInterfaceBoardSectionType.CardTourManagerCpu:
                    //                case Common.Enums.PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                    //                case Common.Enums.PanelInterfaceBoardSectionType.VeridtCpu:
                    //                case Common.Enums.PanelInterfaceBoardSectionType.VeridtReader:
                    //                    break;
                    //            }
                    //        }
                    //        if (s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimAba &&
                    //            s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand &&
                    //            s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio &&
                    //            s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_CypressClockDisplay &&
                    //            s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_ElevatorRelays &&
                    //            s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_LCD_4x20Display &&
                    //            s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_OutputRelays &&
                    //            s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_SaltoSallis &&
                    //            s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Shell &&
                    //            s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_Unused &&
                    //            s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_VeridtCac)
                    //            return BadRequest($"Invalid InterfaceBoardSectionModeUid ({s.InterfaceBoardSectionModeUid}) or SectionType ({s.SectionMode}) value for board type ({b.InterfaceBoardTypeUid})");
                    //    }
                    //}
                    else if (b.InterfaceBoardTypeUid == Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface635)
                    {
                        var invalidSections = sections.Where(o => o.SectionNumber < 1 || o.SectionNumber > 2);
                        foreach (var s in invalidSections)
                        {
                            //sections.Remove(s);
                            return BadRequest($"Invalid section number {s.SectionNumber}. This board type can only have section numbers 1 and 2");
                        }
                        foreach (var s in sections)
                        {
                            // If the InterfaceBoardSectionModeUid is not specified, then use the SectionType enum and assign the correct Uid value
                            if (s.InterfaceBoardSectionModeUid == Guid.Empty)
                            {
                                switch (s.SectionMode)
                                {
                                    case Common.Enums.PanelInterfaceBoardSectionType.AllegionPimAba:
                                        s.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimAba;
                                        break;

                                    case Common.Enums.PanelInterfaceBoardSectionType.AllegionPimWiegand:
                                        s.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand;
                                        break;

                                    case Common.Enums.PanelInterfaceBoardSectionType.AssaAbloyAperio:
                                        s.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio;
                                        break;

                                    case Common.Enums.PanelInterfaceBoardSectionType.CypressClockDisplay:
                                        s.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_CypressClockDisplay;
                                        break;

                                    case Common.Enums.PanelInterfaceBoardSectionType.ElevatorRelays:
                                        s.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_ElevatorRelays;
                                        break;

                                    case Common.Enums.PanelInterfaceBoardSectionType.LCD_4x20Display:
                                        s.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_LCD_4x20Display;
                                        break;

                                    case Common.Enums.PanelInterfaceBoardSectionType.OutputRelays:
                                        s.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_OutputRelays;
                                        break;

                                    case Common.Enums.PanelInterfaceBoardSectionType.SaltoSallis:
                                        s.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_SaltoSallis;
                                        break;

                                    case Common.Enums.PanelInterfaceBoardSectionType.RS485DoorModule:
                                        s.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485DoorModule;
                                        break;

                                    case Common.Enums.PanelInterfaceBoardSectionType.RS485InputModule:
                                        s.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485InputModule;
                                        break;

                                    case Common.Enums.PanelInterfaceBoardSectionType.DrmSection:
                                    case Common.Enums.PanelInterfaceBoardSectionType.Unused:
                                    case Common.Enums.PanelInterfaceBoardSectionType.Dio8X4Outputs:
                                    case Common.Enums.PanelInterfaceBoardSectionType.Dio8X4Inputs:
                                    case Common.Enums.PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                                    //case Common.Enums.PanelInterfaceBoardSectionType.CardTourManagerCpu:
                                    case Common.Enums.PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                                    case Common.Enums.PanelInterfaceBoardSectionType.VeridtCpu:
                                    case Common.Enums.PanelInterfaceBoardSectionType.VeridtReader:
                                        break;
                                }
                            }

                            if (s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimAba &&
                                s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand &&
                                s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio &&
                                s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_CypressClockDisplay &&
                                s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_ElevatorRelays &&
                                s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_LCD_4x20Display &&
                                s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_OutputRelays &&
                                s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_SaltoSallis &&
                                s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485DoorModule &&
                                s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485InputModule &&
                                s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Shell &&
                                s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_Unused &&
                                s.InterfaceBoardSectionModeUid != GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_VeridtCac)
                                return BadRequest($"Invalid InterfaceBoardSectionModeUid ({s.InterfaceBoardSectionModeUid}) or SectionType ({s.SectionMode}) value for board type ({b.InterfaceBoardTypeUid})");
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
                }

                var mgr = Helpers.GetManager<GalaxyPanelManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfEntity = Mapper.Map<WcfEntities.GalaxyPanel>(parameters.Data);
                wcfEntity.ConcurrencyValue = 0;

                var cpuTypeUid = Guid.Empty;
                if (wcfEntity.GalaxyPanelModelUid.HasValue == false || wcfEntity.GalaxyPanelModelUid == Guid.Empty)
                {
                    switch (parameters.Data.GalaxyPanelModel)
                    {
                        //case Common.Enums.GalaxyPanelModel.GalaxyPanel5xx:
                        //    if (wcfEntity.PanelNumber > 254)
                        //        return BadRequest($"Cannot add GalaxyPanel with PanelNumber > 254 for model {parameters.Data.GalaxyPanelModel}");
                        //    wcfEntity.GalaxyPanelModelUid = GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_500;
                        //    cpuTypeUid = GalaxySMS.Common.Constants.GalaxyCpuTypeIds.GalaxyCpuType_500;
                        //    break;
                        //case Common.Enums.GalaxyPanelModel.GalaxyPanel600:
                        //    if (wcfEntity.PanelNumber > 254)
                        //        return BadRequest($"Cannot add GalaxyPanel with PanelNumber > 254 for model {parameters.Data.GalaxyPanelModel}");

                        //    wcfEntity.GalaxyPanelModelUid = GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_600;
                        //    cpuTypeUid = GalaxySMS.Common.Constants.GalaxyCpuTypeIds.GalaxyCpuType_600;
                        //    break;
                        case Common.Enums.GalaxyPanelModel.GalaxyPanel635:
                        default:
                            wcfEntity.GalaxyPanelModelUid = GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_635;
                            cpuTypeUid = GalaxySMS.Common.Constants.GalaxyCpuTypeIds.GalaxyCpuType_635;
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
                    if (wcfBoards == null || wcfBoards.Count == 0)
                        continue;
                    if (wcfBoards.Count > 1)
                        return BadRequest($"There are {wcfBoards.Count} boards with board number: {b.BoardNumber}. This is not permitted.");
                    var wcfBoard = wcfBoards.First();

                    var wcfSections = wcfBoard.InterfaceBoardSections.ToList();

                    switch (b.BoardType)
                    {
                        case Common.Enums.GalaxyInterfaceBoardType.None:
                        case Common.Enums.GalaxyInterfaceBoardType.Cpu600:
                        case Common.Enums.GalaxyInterfaceBoardType.Cpu635:
                        case Common.Enums.GalaxyInterfaceBoardType.DualPortInterfaceBoard500:
                            return BadRequest($"Unsupported board type: {b.BoardType}");

                        case Common.Enums.GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
                            wcfBoard.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface600;
                            foreach (var wcfSection in wcfSections)
                            {
                                wcfSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualReaderInterface600ModeIds.ReaderInterfaceMode_AccessPortal;
                            }
                            break;

                        case Common.Enums.GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
                            wcfBoard.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635;
                            foreach (var wcfSection in wcfSections)
                            {
                                wcfSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualReaderInterface635ModeIds.ReaderInterfaceMode_AccessPortal;
                            }
                            break;

                        case Common.Enums.GalaxyInterfaceBoardType.DigitalInputOutputBoard600:
                            wcfBoard.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DigitalInputOutput600;
                            break;

                        case Common.Enums.GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                        case Common.Enums.GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                            wcfBoard.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface635;
                            foreach (var wcfSection in wcfSections)
                            {
                                var s = b.InterfaceBoardSections.FirstOrDefault(o => o.SectionNumber == wcfSection.SectionNumber);
                                if (s != null)
                                {
                                    switch (s.SectionMode)
                                    {
                                        case Common.Enums.PanelInterfaceBoardSectionType.ElevatorRelays:
                                            wcfSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_ElevatorRelays;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RelayModule8;
                                            break;
                                        case Common.Enums.PanelInterfaceBoardSectionType.CypressClockDisplay:
                                            wcfSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_CypressClockDisplay;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_CypressLCD;
                                            break;
                                        case Common.Enums.PanelInterfaceBoardSectionType.OutputRelays:
                                            wcfSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_OutputRelays;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RelayModule8;
                                            break;
                                        case Common.Enums.PanelInterfaceBoardSectionType.AllegionPimWiegand:
                                            wcfSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AllegionPIM;
                                            break;
                                        case Common.Enums.PanelInterfaceBoardSectionType.AllegionPimAba:
                                            wcfSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimAba;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AllegionPIM;
                                            break;
                                        case Common.Enums.PanelInterfaceBoardSectionType.LCD_4x20Display:
                                            wcfSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_LCD_4x20Display;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_CypressLCD;
                                            break;
                                        case Common.Enums.PanelInterfaceBoardSectionType.RS485DoorModule:
                                            wcfSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485DoorModule;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RemoteDoorModule;
                                            break;
                                        case Common.Enums.PanelInterfaceBoardSectionType.AssaAbloyAperio:
                                            wcfSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AssaAbloyAperioHub;
                                            break;
                                        case Common.Enums.PanelInterfaceBoardSectionType.SaltoSallis:
                                            wcfSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_SaltoSallis;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_SaltoSallisHub;
                                            break;
                                        case Common.Enums.PanelInterfaceBoardSectionType.RS485InputModule:
                                            wcfSection.InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485InputModule;
                                            foreach (var m in wcfSection.GalaxyHardwareModules)
                                                m.GalaxyHardwareModuleTypeUid = GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_InputModule16;
                                            break;
                                        case Common.Enums.PanelInterfaceBoardSectionType.Unused:
                                        case Common.Enums.PanelInterfaceBoardSectionType.DrmSection:
                                        case Common.Enums.PanelInterfaceBoardSectionType.Dio8X4Outputs:
                                        case Common.Enums.PanelInterfaceBoardSectionType.Dio8X4Inputs:
                                        case Common.Enums.PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                                        //case Common.Enums.PanelInterfaceBoardSectionType.CardTourManagerCpu:
                                        case Common.Enums.PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                                        case Common.Enums.PanelInterfaceBoardSectionType.VeridtCpu:
                                        case Common.Enums.PanelInterfaceBoardSectionType.VeridtReader:
                                        default:
                                            break;
                                    }
                                }
                            }
                            break;

                        case Common.Enums.GalaxyInterfaceBoardType.OtisElevatorInterface:
                            wcfBoard.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_OtisElevatorInterface;
                            break;

                        //case Common.Enums.GalaxyInterfaceBoardType.CardTourManagerCpu:
                        //    wcfBoard.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_CardTourManager;
                        //    break;

                        case Common.Enums.GalaxyInterfaceBoardType.KoneElevatorInterface:
                            wcfBoard.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_KoneElevatorInterface;
                            break;
                        case Common.Enums.GalaxyInterfaceBoardType.Veridt_Cpu:
                            wcfBoard.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_Cpu;
                            break;
                        case Common.Enums.GalaxyInterfaceBoardType.Veridt_ReaderModule:
                            wcfBoard.InterfaceBoardTypeUid = GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_ReaderModule;
                            break;
                    }
                }

                var wcfParams = new WcfEntities.SaveParameters<WcfEntities.GalaxyPanel>(wcfEntity, wcfSaveParameters);

                var results = await mgr.SaveGalaxyPanelAsync(wcfParams);
                if (results != null)
                {
                    var savedItem = Mapper.Map<ApiEntities.GalaxyPanel>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "GalaxyPanel",
                        new { galaxyPanelUid = savedItem.GalaxyPanelUid });
                    if (savedItem.UpdateDate > savedItem.InsertDate)
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
        /// Update an existing Merc Panel item. Can also create a new panel.
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

        public async Task<ActionResult<ApiEntities.GalaxyPanel>> Put(RequestModels.SaveParams<ApiEntities.GalaxyPanel> parameters)
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

                var results = await mgr.SaveGalaxyPanelAsync(wcfParams);

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
                }
                if (results != null)
                {
                    var savedItem = Mapper.Map<ApiEntities.GalaxyPanel>(results);
                    var url = LinkGenerator.GetPathByAction("Get",
                        "GalaxyPanel",
                        new { galaxyPanelUid = savedItem.GalaxyPanelUid });
                    if (savedItem.UpdateDate > savedItem.InsertDate)
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
        /// Delete a specific panel by galaxyPanelUid.
        /// </summary>
        ///
        /// <param name="galaxyPanelUid"> Identifier for the Merc Panel to delete. </param>
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

                var resp = new ApiEntities.ArrayResponse<ApiEntities.ActivityHistoryEvent>();
                resp.Items = Mapper.Map<ApiEntities.ActivityHistoryEvent[]>(results);
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
