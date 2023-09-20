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
    public class PerformanceController : Controller// ControllerBase
    {
        private readonly ILogger<PerformanceController> _logger;

        public PerformanceController(ILogger<PerformanceController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void Write([FromBody] LogDetail logDetail)
        {
            Logger.WritePerf(logDetail);
        }
    }
}
