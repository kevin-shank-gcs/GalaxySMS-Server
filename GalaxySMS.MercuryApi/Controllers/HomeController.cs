using GalaxySMS.MercuryApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GalaxySMS.MercuryApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index()
        {
            return View();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
