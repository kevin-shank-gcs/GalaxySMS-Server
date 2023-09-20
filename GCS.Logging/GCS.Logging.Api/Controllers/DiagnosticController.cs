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
    public class DiagnosticController : Controller// ControllerBase
    {
        private readonly ILogger<DiagnosticController> _logger;

        public DiagnosticController(ILogger<DiagnosticController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void Post([FromBody] LogDetail logDetail)
        {
            Logger.WriteDiagnostic(logDetail);
        }
    }
}
