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
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using ResponseModels = GalaxySMS.Api.Models.ResponseModels;
using WcfEntities = GalaxySMS.Business.Entities;

namespace GalaxySMS.Api.Controllers.Api
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Operations relating to Credentials. </summary>
    ///<remarks>  </remarks>
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================

    [Route("api/[controller]")]
    [ApiController]  // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CredentialController : ControllerBaseEx
    {
        public CredentialController(IConfiguration config,
            IMapper mapper,
            ILogger<CredentialController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper, logger, linkGenerator, cache, distributedCache)
        {

        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Analyze a credential number and determine the possible data formats it could be.
        /// </summary>
        ///
        /// <param name="credentialNumber">   Contains the credential number to be evaluated. </param>
        /// <param name="bitCount">   Specifies the bit count of the credential. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ResponseModels.DecodedCredentialResp[]&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("decode/{credentialNumber}/{bitCount}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.ArrayResponse<ResponseModels.DecodedCredentialResp>>> DecodeCredential(string credentialNumber, short bitCount)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<CredentialManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var results = await mgr.DecodeCredentialNumberAsync(new WcfEntities.DecodeCredentialNumberParameters() { BitCount = bitCount, CredentialNumber = credentialNumber });

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
}

                var resp = new ApiEntities.ArrayResponse<ResponseModels.DecodedCredentialResp>();
                resp.Items = Mapper.Map<ResponseModels.DecodedCredentialResp[]>(results);
return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary> Get a collection of Credential objects. </summary>
        /////
        ///// <param name="includePhoto">     (Optional) True to include photo, false to exclude the photo. </param>
        ///// <param name="photoPixelWidth">  (Optional) Width of the photo in pixels (0 = full size). </param>
        ///// <param name="includeChildren">  (Optional) True to include, false to exclude the children. (True can significantly increase response time and body size) </param>
        /////
        ///// <returns>   A Task&lt;ActionResult&lt;ApiEntities.Credential[]&gt;&gt; </returns>
        /////=================================================================================================

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        ////[ApiExplorerSettings(IgnoreApi = true)] // purposely hide this from the Swagger page
        //// If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        ////[MapToApiVersion("1.0")]
        //public async Task<ActionResult<ApiEntities.Credential[]>> Get(bool includePhoto = true, int photoPixelWidth = 200, bool includeChildren = false)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<CredentialManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var results = await mgr.GetCredentialsAsync(new WcfEntities.GetParametersWithPhoto()
        //        {
        //            IncludePhoto = includePhoto,
        //            PhotoPixelWidth = photoPixelWidth,
        //            IncludeMemberCollections = includeChildren
        //        });

        //        if (!results.Any())
        //            return NotFound();
        //        var models = Mapper.Map<ApiEntities.Credential[]>(results);
        //        return Ok(models);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //}


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>
        ///// Get a list of regions.
        ///// </summary>
        /////
        ///// <param name="includePhoto">     (Optional) True to include photo, false to exclude the photo. </param>
        ///// <param name="photoPixelWidth">  (Optional) Width of the photo pixel. </param>
        /////
        ///// <returns>   The list. </returns>
        /////=================================================================================================

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
        //public async Task<ActionResult<ApiEntities.ListItemBase[]>> GetList(bool includePhoto = true, int photoPixelWidth = 200)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<CredentialManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var results = await mgr.GetCredentialsListItemsAsync(new WcfEntities.GetParametersWithPhoto()
        //        {
        //            IncludePhoto = includePhoto,
        //            PhotoPixelWidth = photoPixelWidth,
        //            IncludeMemberCollections = false
        //        });

        //        if (!results.Any())
        //            return NotFound();
        //        var models = Mapper.Map<ApiEntities.ListItemBase[]>(results);
        //        return Ok(models);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary> Get a single Credential based on regionUid (unique id (Guid or uuid) value). </summary>
        /////
        ///// <param name="regionUid">         Identifier for the region. </param>
        ///// <param name="includePhoto">     (Optional) True to include photo, false to exclude the photo. </param>
        ///// <param name="includeChildren">  (Optional) True to include, false to exclude the children.
        /////                                 (True can significantly increase response time and body size) </param>
        /////
        ///// <returns>   A Task&lt;ActionResult&lt;ApiEntities.Credential[]&gt;&gt; </returns>
        /////=================================================================================================

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet("{regionUid}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //// If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        ////[MapToApiVersion("1.0")]
        //public async Task<ActionResult<ApiEntities.Credential>> Get(Guid regionUid, bool includePhoto = true, bool includeChildren = false)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<CredentialManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var result = await mgr.GetCredentialAsync(new WcfEntities.GetParametersWithPhoto()
        //        {
        //            UniqueId = regionUid,
        //            IncludePhoto = includePhoto,
        //            IncludeMemberCollections = includeChildren
        //        });

        //        if (result == null)
        //            return NotFound();
        //        var model = Mapper.Map<ApiEntities.Credential>(result);
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

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>
        ///// Create a new Credential item.
        ///// </summary>
        /////
        ///// <param name="parameters">   Options for controlling the operation. </param>
        /////
        ///// <returns>   A Task&lt;ActionResult&lt;ApiEntities.Credential[]&gt;&gt; </returns>
        /////=================================================================================================


        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]

        //public async Task<ActionResult<ApiEntities.Credential>> Post(RequestModels.SaveParams<RequestModels.CredentialReq> parameters)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

        //        var mgr = Helpers.GetManager<CredentialManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

        //        var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

        //        var wcfEntity = Mapper.Map<WcfEntities.Credential>(parameters.Data);
        //        wcfEntity.ConcurrencyValue = 0;
        //        if (parameters.Data.Image != null)
        //            wcfEntity.gcsBinaryResource.BinaryResource = parameters.Data.Image;

        //        var wcfParams = new WcfEntities.SaveParameters<WcfEntities.Credential>(wcfEntity, wcfSaveParameters);

        //        var results = await mgr.SaveCredentialAsync(wcfParams);
        //        if (results != null)
        //        {
        //            var savedItem = Mapper.Map<ApiEntities.Credential>(results);
        //            var url = LinkGenerator.GetPathByAction("Get",
        //                "Credential",
        //                new { regionUid = savedItem.CredentialUid });
        //            if (savedItem.UpdateDate > savedItem.InsertDate)
        //                return Ok(savedItem);
        //            return Created(url, savedItem);
        //        }
        //        if (mgr.HasErrors)
        //        {
        //            return BadRequest(mgr.Errors[0].ErrorMessage);
        //            //if (mgr.Errors[0].ExceptionType.Contains(typeof(GCS.Core.Common.Exceptions.DuplicateIndexException).ToString()))
        //            //     return BadRequest(mgr.Errors[0].ErrorMessage);
        //            // return this.StatusCode(StatusCodes.Status500InternalServerError, mgr.Errors[0]);
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


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>
        ///// Update an existing Credential item. Can also create a new Credential.
        ///// </summary>
        /////
        ///// <param name="parameters">   Options for controlling the operation. </param>
        /////
        ///// <returns>   A Task&lt;ActionResult&lt;ApiEntities.Credential&gt;&gt; </returns>
        /////=================================================================================================
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]

        //public async Task<ActionResult<ApiEntities.Credential>> Put(RequestModels.SaveParams<RequestModels.CredentialPutReq> parameters)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        if (parameters.Data.CredentialUid == Guid.Empty)
        //            return this.StatusCode(StatusCodes.Status403Forbidden, $"Cannot update region with CredentialUid value of {parameters.Data.CredentialUid}");

        //        var userId = this.GetClaimGuid(GalaxySMSClaimTypes.UserId.ToString());

        //        var mgr = Helpers.GetManager<CredentialManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

        //        var wcfSaveParameters = Mapper.Map<WcfEntities.SaveParameters>(parameters);

        //        var wcfEntity = Mapper.Map<WcfEntities.Credential>(parameters.Data);
        //        var wcfParams = new WcfEntities.SaveParameters<WcfEntities.Credential>(wcfEntity, wcfSaveParameters);

        //        var results = await mgr.SaveCredentialAsync(wcfParams);
        //        if (results != null)
        //        {
        //            var savedItem = Mapper.Map<ApiEntities.Credential>(results);
        //            var url = LinkGenerator.GetPathByAction("Get",
        //                "Credential",
        //                new { regionUid = savedItem.CredentialUid });
        //            if (savedItem.UpdateDate > savedItem.InsertDate)
        //                return Ok(savedItem);
        //            return Created(url, savedItem);
        //        }
        //        if (mgr.HasErrors)
        //        {
        //            return BadRequest(mgr.Errors[0].ErrorMessage);
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

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>
        ///// Delete a specific Credential by regionUid.
        ///// </summary>
        /////
        ///// <param name="regionUid"> Identifier for the region to delete. </param>
        /////
        ///// <returns>   A Task&lt;IActionResult&gt; </returns>
        /////=================================================================================================        
        //[HttpDelete("{regionUid}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> Delete(Guid regionUid)
        //{
        //    try
        //    {
        //        var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
        //        if (sessionId == Guid.Empty)
        //            return BadRequest(ResponseMessages.JwtMissingSessionId);

        //        var mgr = Helpers.GetManager<CredentialManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
        //        var result = await mgr.GetCredentialAsync(new WcfEntities.GetParametersWithPhoto()
        //        {
        //            UniqueId = regionUid
        //        });

        //        if (result == null)
        //            return NotFound();

        //        var x = await mgr.DeleteCredentialByUniqueIdAsync(new WcfEntities.DeleteParameters() { UniqueId = regionUid });
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

    }
}
