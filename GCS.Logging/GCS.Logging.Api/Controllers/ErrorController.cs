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
    public class ErrorController : Controller// ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void Write([FromBody] LogDetail logDetail)
        {
            Logger.WriteError(logDetail);
        }
    }
}
