using AutoMapper;
using GalaxySMS.MercuryApi.Support;
using GalaxySMS.Client.SDK.Helpers;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GCS.Framework.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using WcfEntities = GalaxySMS.Business.Entities;

namespace GalaxySMS.MercuryApi.Controllers.Api
{
    /// <summary>
    /// Manage user authentication operations such as sign in and sign out
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]  // This attribute enables model binding and validation by default. Will use model attributes and [FromBody] for post/put automatically
    public class AuthController : ControllerBaseEx//ControllerBase
    {
        //private readonly ILogger<AuthController> _logger;

        public AuthController(IConfiguration config,
            IMapper mapper,
            ILogger<AuthController> logger,
            LinkGenerator linkGenerator, IMemoryCache cache, IRedisCacheService distributedCache) : base(config, mapper, logger, linkGenerator, cache, distributedCache)
        {
            //_logger = logger;
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
            }

            return Ok();

        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sign in asynchronously. </summary>
        ///
        /// <remarks>   Use this to sign in to a specific application and obtain a token along with entities and roles/permissions </remarks>
        ///
        /// <param name="requestData">  Information describing the request. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.UserSignInResult&gt;&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [AllowAnonymous]
        [HttpPost("signinrequest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ApiEntities.UserSignInResult>> SignInAsync(ApiEntities.UserSignInRequest requestData)
        {
            try
            {
                var mgr = Helpers.GetManager<UserSessionManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                mgr.ClientUserSessionData.SessionGuid = Guid.Empty;

                var wcfParams = Mapper.Map<WcfEntities.UserSignInRequest>(requestData);

                wcfParams.SignInRequestDateTime = DateTimeOffset.Now;
                wcfParams.ComputerInformation = new WcfEntities.ComputerInformation();

                var myAssemblyAttributes = GCS.Framework.Utilities.SystemUtilities.GetEntryAssemblyAttributes();
                wcfParams.ApplicationVersion = myAssemblyAttributes.Version;
                wcfParams.ComputerInformation.IPAddresses.Add(HttpContext.Connection.RemoteIpAddress.ToString());
                wcfParams.ApplicationName = mgr.ClientUserSessionData.ApplicationName;
                if (wcfParams.ApplicationId == Guid.Empty)
                    wcfParams.ApplicationId = GalaxySMS.Common.Constants.ApplicationIds.GalaxySMS_DefaultApp_Id;

                PrepareRequestData(ref wcfParams);

                var result = await mgr.SignInAsync(wcfParams);
                switch (result?.RequestResult)
                {
                    case UserSignInRequestResult.Success:
                    case UserSignInRequestResult.SuccessWithInfo:
                    case UserSignInRequestResult.MustProvideTwoFactorToken:
                        //var userClaims = new List<Claim>();
                        //foreach (var ue in result.SessionToken.UserData.UserEntities.Where(o => o.IsActive == true))
                        //{
                        //    foreach (var app in ue.UserApplications)
                        //    {
                        //        if (result.SessionToken.IsInAdminRole(ue.EntityId, app.ApplicationId))
                        //        {
                        //            if (userClaims.FirstOrDefault(o => o.Type == GalaxySMSClaimTypes.ApplicationAdmin && o.Value == app.ApplicationId.ToString()) == null)
                        //                userClaims.Add(new Claim(GalaxySMSClaimTypes.ApplicationAdmin, app.ApplicationId.ToString()));
                        //        }
                        //        foreach (var r in app.UserRoles.Where(o => o.IsActive == true))
                        //        {
                        //            var value = $"{app.ApplicationId}^{r.RoleName}";
                        //            if (userClaims.FirstOrDefault(o => o.Type == GalaxySMSClaimTypes.ApplicationRole && o.Value == value) == null)
                        //                userClaims.Add(new Claim(GalaxySMSClaimTypes.ApplicationRole, value));
                        //        }
                        //    }
                        //}

                        //var claims = new[]
                        //{
                        //    new Claim(JwtRegisteredClaimNames.Sub, result.SessionToken.UserData.UserName),
                        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        //    new Claim(JwtRegisteredClaimNames.GivenName, result.SessionToken.UserData.FirstName),
                        //    new Claim(JwtRegisteredClaimNames.FamilyName, result.SessionToken.UserData.LastName),
                        //    new Claim(JwtRegisteredClaimNames.Email, result.SessionToken.UserData.Email),
                        //    new Claim(GalaxySMSClaimTypes.SessionId, result.SessionToken.SessionId.ToString()),
                        //    new Claim(GalaxySMSClaimTypes.ApplicationId, result.SessionToken.ApplicationId.ToString()),
                        //    new Claim(GalaxySMSClaimTypes.ApplicationName, result.SessionToken.ApplicationName),
                        //    //new Claim(GalaxySMSClaimTypes.CurrentEntityId, result.SessionToken.CurrentEntityId.ToString()),
                        //    new Claim(GalaxySMSClaimTypes.UserId, result.SessionToken.UserData.UserId.ToString()),
                        //}.Union(userClaims);

                        //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["Tokens:Key"]));
                        //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        //var token = new JwtSecurityToken(
                        //    issuer: Config["Tokens:Issuer"],
                        //    audience: Config["Tokens:Audience"],
                        //    claims: claims,
                        //    expires: result.SessionToken.ExpirationDateTime,
                        //    signingCredentials: creds
                        //);
                        var apiResult = Mapper.Map<ApiEntities.UserSignInResult>(result);
                        //apiResult.SessionToken.JwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                        //apiResult.SessionToken.JwtTokenValidTill = token.ValidTo;
                        Globals.Instance.UserSignInResult = result;
                        //                       var ut = await mgr.SetJwtAsync(result.SessionToken.SessionId, apiResult.SessionToken.JwtToken);
                        return Ok(apiResult);

                    case UserSignInRequestResult.InvalidUserName:
                    case UserSignInRequestResult.InvalidPassword:
                        return ValidationProblem(GetValidationError($"{result?.RequestResult.ToString()}", $"User with this email/password does not exist"));

                    case UserSignInRequestResult.Unknown:
                        return ValidationProblem(GetValidationError($"{result?.RequestResult.ToString()}", $"Unknown error"));

                    case UserSignInRequestResult.UserAccountIsNotActive:
                        return ValidationProblem(GetValidationError($"{result?.RequestResult.ToString()}", $"User account is not active"));

                    case UserSignInRequestResult.UserAccountIsLockedOut:
                        return ValidationProblem(GetValidationError($"{result?.RequestResult.ToString()}", $"User account is locked out"));

                    case UserSignInRequestResult.ApplicationNotPermitted:
                        return ValidationProblem(GetValidationError($"{result?.RequestResult.ToString()}", $"Application not permitted"));

                    case UserSignInRequestResult.EmailAndPhoneNumberNotConfirmed:
                        return ValidationProblem(GetValidationError($"{result?.RequestResult.ToString()}", $"User with this email/password does not exist"));

                    case UserSignInRequestResult.InvalidTwoFactorToken:
                        return ValidationProblem(GetValidationError($"{result?.RequestResult.ToString()}", $"Invalid 2FA token"));
                        //return Unauthorized(Mapper.Map<ApiEntities.UserSignInResult>(result));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }

            return BadRequest("Failed to sign in");
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Verify two factor authentication token.
        /// </summary>
        /// <remarks>   Validate a two-factor authentication. Requires Authorization Bearer header which was returned from a prior call to api/auth/signinrequest</remarks>
        /// <param name="requestData">  Information describing the request. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.UserSignInResult&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("verify2fatoken")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ApiEntities.UserSignInResult>> VerifyTwoFactorAuthenticationTokenAsync(ApiEntities.TwoFactorAuthenticationData requestData)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest("Token missing sessionId");

                var mgr = Helpers.GetManager<UserSessionManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var wcfParams = Mapper.Map<WcfEntities.TwoFactorAuthenticationData>(requestData);
                wcfParams.SessionId = sessionId;
                var result = await mgr.VerifyTwoFactorAuthenticationTokenAsync(wcfParams);
                if (result == null)
                {
                    return BadRequest("Failed to verify token.");
                }
                switch (result.RequestResult)
                {
                    case UserSignInRequestResult.Success:
                    case UserSignInRequestResult.SuccessWithInfo:
                    case UserSignInRequestResult.MustProvideTwoFactorToken:
                        //var userClaims = new List<Claim>();
                        //foreach (var ue in result.SessionToken.UserData.UserEntities.Where(o => o.IsActive == true))
                        //{
                        //    foreach (var app in ue.UserApplications)
                        //    {
                        //        if (result.SessionToken.IsInAdminRole(ue.EntityId, app.ApplicationId))
                        //        {
                        //            if (userClaims.FirstOrDefault(o => o.Type == GalaxySMSClaimTypes.ApplicationAdmin && o.Value == app.ApplicationId.ToString()) == null)
                        //                userClaims.Add(new Claim(GalaxySMSClaimTypes.ApplicationAdmin, app.ApplicationId.ToString()));
                        //        }
                        //        foreach (var r in app.UserRoles.Where(o => o.IsActive == true))
                        //        {
                        //            var value = $"{app.ApplicationId}^{r.RoleName}";
                        //            if (userClaims.FirstOrDefault(o => o.Type == GalaxySMSClaimTypes.ApplicationRole && o.Value == value) == null)
                        //                userClaims.Add(new Claim(GalaxySMSClaimTypes.ApplicationRole, value));
                        //        }
                        //    }
                        //}

                        //var claims = new[]
                        //{
                        //    new Claim(JwtRegisteredClaimNames.Sub, result.SessionToken.UserData.UserName),
                        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        //    new Claim(JwtRegisteredClaimNames.GivenName, result.SessionToken.UserData.FirstName),
                        //    new Claim(JwtRegisteredClaimNames.FamilyName, result.SessionToken.UserData.LastName),
                        //    new Claim(JwtRegisteredClaimNames.Email, result.SessionToken.UserData.Email),
                        //    new Claim(GalaxySMSClaimTypes.SessionId, result.SessionToken.SessionId.ToString()),
                        //    new Claim(GalaxySMSClaimTypes.ApplicationId, result.SessionToken.ApplicationId.ToString()),
                        //    new Claim(GalaxySMSClaimTypes.UserId, result.SessionToken.UserData.UserId.ToString()),
                        //}.Union(userClaims);

                        //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["Tokens:Key"]));
                        //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        //var token = new JwtSecurityToken(
                        //    issuer: Config["Tokens:Issuer"],
                        //    audience: Config["Tokens:Audience"],
                        //    claims: claims,
                        //    expires: result.SessionToken.ExpirationDateTime,
                        //    signingCredentials: creds
                        //);
                        var apiResult = Mapper.Map<ApiEntities.UserSignInResult>(result);
                        //apiResult.SessionToken.JwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                        //apiResult.SessionToken.JwtTokenValidTill = token.ValidTo;
                        //var ut = await mgr.SetJwtAsync(result.SessionToken.SessionId, apiResult.SessionToken.JwtToken);
                        return Ok(apiResult);


                    case UserSignInRequestResult.Unknown:
                    case UserSignInRequestResult.InvalidUserName:
                    case UserSignInRequestResult.InvalidPassword:
                    case UserSignInRequestResult.UserAccountIsNotActive:
                    case UserSignInRequestResult.UserAccountIsLockedOut:
                    case UserSignInRequestResult.ApplicationNotPermitted:
                    case UserSignInRequestResult.EmailAndPhoneNumberNotConfirmed:
                    case UserSignInRequestResult.InvalidTwoFactorToken:
                        return Unauthorized(Mapper.Map<ApiEntities.UserSignInResult>(result));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }

            return BadRequest("Failed to sign in");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Sign out user.
        /// </summary>
        /// <remarks>   Sign out by passing the SessionId value in the request body. Requires Authorization Bearer header</remarks>
        /// 
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.UserSessionToken&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("signout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiEntities.UserSessionToken>> SignOutUserSessionToken()
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<UserSessionManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var result = await mgr.SignOutAsync(sessionId);
                if (result != null)
                {
                    return Ok(Mapper.Map<ApiEntities.UserSessionToken>(result));
                }
                return NotFound($"The requested session does not exist");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Keep session alive. </summary>
        /// <remarks>   Refresh the session expiration time so that it does not go stale</remarks>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.UserSessionToken&gt;&gt; </returns>
        ///=================================================================================================

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //        [Authorize(Policy = "SuperUsers")]
        [HttpPost("keepalive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ApiEntities.UserSessionToken>> KeepSessionAlive()
        {
            try
            {
                var authHeader = this.GetAuthHeader();//Request.Headers["Authorization"];
                if (authHeader.Count == 0)
                    return BadRequest("The request is missing an Authorization header.");

                JwtSecurityToken jwtToken = null;
                try
                {
                    jwtToken = this.GetJwtSecurityToken();
                }
                catch (ArgumentException ex)
                {
                    var msg = $"Failed to refresh token. The token is not valid.";
                    Logger.LogError($"Exception thrown while refreshing JWT: {ex}");
                    return BadRequest($"{msg}, {ex.ToString()}");
                }

                if (jwtToken == null)
                {
                    var msg = $"Failed to refresh token. The token is not valid.";
                    Logger.LogError(msg);
                    return BadRequest(msg);
                }

                if (jwtToken.ValidTo < DateTimeOffset.UtcNow)
                    return Unauthorized($"The Token has expired");

                if (jwtToken.Issuer != Config["Tokens:Issuer"])
                    return BadRequest($"The Issuer value is not valid");

                if (jwtToken.Audiences.FirstOrDefault() != Config["Tokens:Audience"])
                    return BadRequest($"The Audience value is not valid");

                var sessionId = jwtToken.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest($"The SessionId value is missing or invalid");


                var mgr = Helpers.GetManager<UserSessionManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var result = await mgr.KeepAliveAsync(sessionId);
                if (result != null)
                {
                    //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["Tokens:Key"]));
                    //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    //var newToken = new JwtSecurityToken(
                    //    issuer: Config["Tokens:Issuer"],
                    //    audience: Config["Tokens:Audience"],
                    //    claims: jwtToken.Claims,
                    //    expires: result.ExpirationDateTime,
                    //    signingCredentials: creds
                    //    );
                    var apiResult = Mapper.Map<ApiEntities.UserSessionToken>(result);
                    //apiResult.JwtToken = new JwtSecurityTokenHandler().WriteToken(newToken);
                    //apiResult.JwtTokenValidTill = newToken.ValidTo;
                    //var ut = await mgr.SetJwtAsync(sessionId, apiResult.JwtToken);

                    return Ok(apiResult);
                }

                return NotFound($"The requested session does not exist");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Decodes the JSON Web Token and returns the decoded values </summary>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;JwtSecurityToken&gt;&gt; </returns>
        ///=================================================================================================

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [AllowAnonymous]
        [HttpGet("decodetoken")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JwtSecurityToken>> DecodeToken()
        {
            try
            {
                var authHeader = this.GetAuthHeader();//Request.Headers["Authorization"];
                if (authHeader.Count == 0)
                {
                    throw new Exception("The request is missing an Authorization header.");
                    return BadRequest("The request is missing an Authorization header.");
                }
                JwtSecurityToken jwtToken = null;
                try
                {
                    jwtToken = this.GetJwtSecurityToken();
                }
                catch (ArgumentException ex)
                {
                    var msg = $"Failed to get token. The token is not valid.";
                    Logger.LogError($"Exception thrown while decoding JWT: {ex}");
                    return BadRequest($"{msg}, {ex.ToString()}");
                }
                if (jwtToken == null)
                {
                    var msg = $"Failed to get token. The token is not valid.";
                    Logger.LogError(msg);
                    return BadRequest(msg);
                }
                return Ok(jwtToken);

            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// updates the session settings described by parameters.
        /// </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;ActionResult&lt;ApiEntities.UserSessionToken&gt;&gt; </returns>
        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("updatesessionsettings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ApiEntities.UserSessionToken>> UpdateSessionSettings(ApiEntities.SaveParameters<ApiEntities.UserSessionSettings> parameters)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var mgr = Helpers.GetManager<UserSessionManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                var wcfData = Mapper.Map<WcfEntities.UserSessionSettings>(parameters.Data);
                var wcfSaveParams = Mapper.Map<WcfEntities.SaveParameters>(parameters);

                var wcfParams = Mapper.Map<WcfEntities.SaveParameters<WcfEntities.UserSessionSettings>>(parameters);

                var result = await mgr.UpdateSessionSettingsAsync(wcfParams);
                if (result != null)
                {
                    return Ok(Mapper.Map<ApiEntities.UserSessionToken>(result));
                }
                if (mgr.HasErrors)
                {
                    if (mgr.Errors.FirstOrDefault().ErrorMessage.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                        return this.StatusCode(StatusCodes.Status403Forbidden, $"User is not permitted to access EntityId {parameters.CurrentEntityId}");
                }
                return NotFound($"The requested session does not exist");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("userentity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiEntities.UserEntity>> GetUserEntity(Guid entityId)
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);
                if (entityId == Guid.Empty)
                    entityId = ClientUserSessionData.CurrentEntityId;
                //if (applicationId == Guid.Empty)
                //    applicationId = GalaxySMS.Common.Constants.ApplicationIds.GalaxySMS_DefaultApp_Id;

                var mgr = Helpers.GetManager<UserSessionManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var result = await mgr.GetUserEntityAsync(entityId);
                if (result != null)
                {
                    return Ok(Mapper.Map<ApiEntities.UserEntity>(result));
                }
                return NotFound($"The requested session does not exist");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }
        }





        ///=================================================================================================
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("sampledata")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> GetSampleData()
        {
            try
            {
                var sessionId = this.GetClaimGuid(GalaxySMSClaimTypes.SessionId.ToString());
                if (sessionId == Guid.Empty)
                    return BadRequest(ResponseMessages.JwtMissingSessionId);

                var clusterMgr = Helpers.GetManager<ClusterManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);

                var result = await clusterMgr.GetAllClustersListAsync(new WcfEntities.GetParametersWithPhoto());
                if (result != null)
                {
                    var cluster = result?.Items?.FirstOrDefault();
                    if (cluster != null)
                    {
                        Globals.Instance.ClusterUid = cluster.Uid;

                        //var areaMgr = Helpers.GetManager<GalaxyAreaManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                        //var scheduleMgr =Helpers.GetManager<TimeScheduleManager>(ServerWcfServerAddress, ServerWcfBindingType, ServerUserName, ServerPassword, ClientUserSessionData);
                        //var parameters = new WcfEntities.GetParametersWithPhoto(){UniqueId = cluster.Uid, IncludeMemberCollections =  false, IncludePhoto = false};
                        //var areas = await areaMgr.GetAreasForClusterAsync(parameters);
                        //if( areas != null)
                        //{
                        //    var noArea = areas.FirstOrDefault(o=>o.AreaNumber == Common.Constants.AreaLimits.None);
                        //    if( noArea != null)
                        //        Globals.Instance.NoAreaUid = noArea.AreaUid;
                        //}

                        //var schedules = await scheduleMgr.GetTimeSchedulesForClusterAsync(parameters);


                        //if( clusterMgr.HasErrors == false)
                        //{

                        //}
                    }
                    return Ok(result);
                }
                if (clusterMgr.HasErrors)
                {
                    if (clusterMgr.Errors.FirstOrDefault().ErrorMessage.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                        return this.StatusCode(StatusCodes.Status403Forbidden, $"User is not permitted to access EntityId: {clusterMgr.ClientUserSessionData.CurrentEntityId}");
                }
                return NotFound($"The requested session does not exist");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception thrown in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}: {ex}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);//$"Failure:{ex.ToString()}");
            }

        }


        private void PrepareRequestData(ref WcfEntities.UserSignInRequest requestData)
        {
            var encryptPasspharase = requestData.SignInRequestDateTime.Ticks.ToString();
            foreach (var ipAddr in requestData.ComputerInformation.IPAddresses)
                encryptPasspharase += ipAddr;
            encryptPasspharase += requestData.ComputerInformation.MachineName;
            encryptPasspharase += requestData.ApplicationName;
            encryptPasspharase += requestData.ComputerInformation.DomainName;
            encryptPasspharase += requestData.CurrentWindowsUserIdentity?.DomainName;
            encryptPasspharase += requestData.CurrentWindowsUserIdentity?.Name;
            encryptPasspharase += requestData.ApplicationId.ToString();
            var encryptedPassword = Crypto.EncryptString(requestData.Password, encryptPasspharase);
            requestData.Password = encryptedPassword;
        }



    }
}

