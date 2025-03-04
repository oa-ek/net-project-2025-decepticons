using Microsoft.AspNetCore.Mvc;
using ShubkivTour.Models;
using System.Diagnostics;

namespace ShubkivTour.Controllers
{
    public class GuideController : Controller
    {
        private readonly ILogger<GuideController> _logger;

        public GuideController(ILogger<GuideController> logger)
        {
            _logger = logger;
        }

        public IActionResult GuideManagement()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
