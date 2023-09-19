extern alias NetCoreCommon;
using AutoMapper;
using Microsoft.Extensions.Configuration;

using GCS.Core.Common.Contracts;
using GCS.Core.Common.ServiceModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.MercuryApi.Support;
using Microsoft.Extensions.Logging;
using GalaxySMS.Client.SDK.DataClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using GalaxySMS.Api.Models.RequestModels;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using NetCoreCommon::GCS.Core.Common.Core;

namespace GalaxySMS.MercuryApi.Controllers.Api
{
    public class ControllerBaseEx : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly ILogger<ControllerBaseEx> _logger;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMemoryCache _cache;
        private readonly IRedisCacheService _distributedCache;
        private MemoryCacheEntryOptions _memoryCacheOptions;
        private DistributedCacheEntryOptions _distributedCacheOptions;

        public ControllerBaseEx(IConfiguration config,
            IMapper mapper,
            Microsoft.Extensions.Logging.ILogger<ControllerBaseEx> logger,
            LinkGenerator linkGenerator,
            IMemoryCache cache,
            IRedisCacheService distributedCache)
        {
            this._config = config;
            this._mapper = mapper;
            this._logger = logger;
            _linkGenerator = linkGenerator;
            ServerWcfServerAddress = Config["GalaxySMSWcfHost:ServerAddress"];
            ServerWcfBindingType = GalaxySiteServerConnectionSettings.WcfBindingType.Tcp;
            ServerUserName = string.Empty;
            ServerPassword = string.Empty;
            _cache = cache;
            _distributedCache = distributedCache;
            var absExp = DateTimeOffset.Now + TimeSpan.FromMinutes(int.Parse(_config["CacheOptions:AbsoluteExpiration"]));

            _memoryCacheOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = absExp,
                SlidingExpiration = new TimeSpan(0, int.Parse(_config["CacheOptions:SlidingExpiration"]), 0)
            };

            _distributedCacheOptions = new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = absExp,
                SlidingExpiration = new TimeSpan(0, int.Parse(_config["CacheOptions:SlidingExpiration"]), 0)
            };
        }

        public IApplicationUserSessionDataHeader ClientUserSessionData { get; internal set; } = new ApplicationUserSessionHeader();
        public JwtSecurityToken JwtSecurityToken { get; internal set; }
        public string ServerWcfServerAddress { get; internal set; }
        public GalaxySiteServerConnectionSettings.WcfBindingType ServerWcfBindingType { get; internal set; }
        public string ServerUserName { get; internal set; }
        public string ServerPassword { get; internal set; }
        public ILogger<ControllerBaseEx> Logger { get { return _logger; } }
        public IMapper Mapper { get { return _mapper; } }
        public IConfiguration Config { get { return _config; } }
        public LinkGenerator LinkGenerator { get { return _linkGenerator; } }
        public IMemoryCache Cache { get { return _cache; } }
        public IRedisCacheService DistributedCache { get { return _distributedCache; } }

        public DistributedCacheEntryOptions DistributedCacheOptions => _distributedCacheOptions;
        public MemoryCacheEntryOptions MemoryCacheOptions => _memoryCacheOptions;

        public override ObjectResult StatusCode([ActionResultStatusCode] int statusCode,
            [ActionResultObjectValue] object value)
        {
            var result = base.StatusCode(statusCode, value);

            var jsonResult = new JsonResult(new
            {
                code = Convert.ToString((int)statusCode),
                message = result.Value
            });

            result.Value = jsonResult.Value;
            return result;
        }


        protected ActionResult GetStatusCodeResult(IManagerBase mgr)
        {
            var errString = mgr.GetErrorsString();
            if (errString.Contains(MagicExceptionStrings.forbidden, StringComparison.OrdinalIgnoreCase))
                return this.StatusCode(StatusCodes.Status403Forbidden, errString);
            if (errString.Contains(MagicExceptionStrings.unauthorized, StringComparison.OrdinalIgnoreCase))
                return this.StatusCode(StatusCodes.Status401Unauthorized, errString);
            if (errString.Contains(MagicExceptionStrings.duplicate))
                return this.StatusCode(StatusCodes.Status409Conflict, errString);
            if (errString.Contains(MagicExceptionStrings.not_in_database) ||
                errString.Contains(MagicExceptionStrings.not_found))
                return this.StatusCode(StatusCodes.Status404NotFound, errString);
            if (errString.Contains(MagicExceptionStrings.no_rows_updated, StringComparison.OrdinalIgnoreCase))
                return ValidationProblem(GetNoRowsUpdatedValidationError());
            if (errString.Contains(nameof(PutRequestBase.ConcurrencyValue)))
            {
                var e = mgr.Errors.FirstOrDefault();
                if (e?.ExceptionDetailEx != null)
                    return ValidationProblem(new ValidationProblemDetails(e.ExceptionDetailEx.ValidationErrors));
            }
            return this.StatusCode((int)mgr.HttpStatusCode, errString);
        }



        //protected ObjectResult StatusCode(StatusCodes code, string message)
        //{

        //}

        protected ValidationProblemDetails GetNoRowsUpdatedValidationError()
        {
            var validationProblems = new Dictionary<string, string[]>();
            var errorsArray = new List<string>();

            errorsArray.Add($"Cannot update record. The ConcurrencyValue field value is wrong.");
            validationProblems.Add("ConcurrencyValue", errorsArray.ToArray());

            return new ValidationProblemDetails(validationProblems);
        }


        protected ValidationProblemDetails GetValidationError(string propertyName, string message)
        {
            var validationProblems = new Dictionary<string, string[]>();
            var errorsArray = new List<string>();

            errorsArray.Add(message);
            validationProblems.Add(propertyName, errorsArray.ToArray());

            return new ValidationProblemDetails(validationProblems);
        }

        protected ValidationProblemDetails GetValidationError(IEnumerable<KeyValuePair<string, string>> data)
        {
            var validationProblems = new Dictionary<string, string[]>();
            var errorsArray = new List<string>();

            foreach (var kvp in data)
            {
                errorsArray.Add(kvp.Value);
                validationProblems.Add(kvp.Key, errorsArray.ToArray());
            }

            return new ValidationProblemDetails(validationProblems);
        }

    }

}
