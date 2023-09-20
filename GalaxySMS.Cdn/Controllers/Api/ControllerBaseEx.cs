using AutoMapper;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.ServiceModel.Api;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace GalaxySMS.Cdn.Controllers.Api
{
    public class ControllerBaseEx : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly ILogger<ControllerBaseEx> _logger;
        private readonly LinkGenerator _linkGenerator;

        public ControllerBaseEx(IConfiguration config,
            IMapper mapper,
            Microsoft.Extensions.Logging.ILogger<ControllerBaseEx> logger,
            LinkGenerator linkGenerator)
        {
            this._config = config;
            this._mapper = mapper;
            this._logger = logger;
            _linkGenerator = linkGenerator;
            //ServerWcfServerAddress = Config["GalaxySMSWcfHost:ServerAddress"];
            //ServerWcfBindingType = GalaxySiteServerConnectionSettings.WcfBindingType.Tcp;
            //ServerUserName = string.Empty;
            //ServerPassword = string.Empty;
        }

        public IApplicationUserSessionDataHeader ClientUserSessionData { get; internal set; } = new ApplicationUserSessionHeader();
        public JwtSecurityToken JwtSecurityToken { get; internal set; }
        //public string ServerWcfServerAddress { get; internal set; }
        //public GalaxySiteServerConnectionSettings.WcfBindingType ServerWcfBindingType { get; internal set; }
        //public string ServerUserName { get; internal set; }
        //public string ServerPassword { get; internal set; }
        public ILogger<ControllerBaseEx> Logger { get { return _logger; } }
        public IMapper Mapper { get { return _mapper; } }
        public IConfiguration Config { get { return _config; } }
        public LinkGenerator LinkGenerator { get { return _linkGenerator; } }
    }

}
