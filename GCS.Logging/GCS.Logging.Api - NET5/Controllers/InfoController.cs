using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GCS.Logging.Core;
using GCS.Logging.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GCS.Logging.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfoController : Controller// ControllerBase
    {
        private readonly ILogger<InfoController> _logger;

        public InfoController(ILogger<InfoController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void Write([FromBody] LogDetail logDetail)
        {
            Logger.WriteInfo(logDetail);
        }
    }
}
