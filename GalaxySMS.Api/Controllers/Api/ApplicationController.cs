extern alias NetCoreCommon;
using AutoMapper;
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
using System.Threading.Tasks;
using GalaxySMS.Api.Support;
using GalaxySMS.Business.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;


namespace GalaxySMS.Api.Controllers.Api
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A controller for handling applications. </summary>
    ///
    /// <seealso cref="T:GalaxySMS.Api.Controllers.Api.ControllerBaseEx"/>
    ///=================================================================================================

    [Route("api/[controller]")]
    [ApiController]  // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ApplicationController : ControllerBaseEx
    {
        public ApplicationController(IConfiguration config,
            IMapper mapper,
            ILogger<ApplicationController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper, logger, linkGenerator, cache, distributedCache)
        {

        }


        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [AllowAnonymous]
        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // If no MapToApiVersion attribute is specified, then this endpoint will work for all versions
        //[MapToApiVersion("1.0")]

        public async Task<ActionResult<ApiEntities.ArrayResponse<ApiEntities.gcsApplicationBasic>>> GetList()
        {
            try
            {
                //var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                //if (sessionId == Guid.Empty)
                //    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<ApplicationManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var results = await mgr.GetApplicationBasicListAsync();

                if (mgr.HasErrors)
                {
                    return GetStatusCodeResult(mgr);
}

                var resp = new ApiEntities.ArrayResponse<ApiEntities.gcsApplicationBasic>();
                resp.Items = Mapper.Map<ApiEntities.gcsApplicationBasic[]>(results);
return Ok(resp);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }




    }
}
