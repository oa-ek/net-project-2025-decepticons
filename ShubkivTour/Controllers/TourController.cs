using Microsoft.AspNetCore.Mvc;
using ShubkivTour.Models;
using System.Diagnostics;

namespace ShubkivTour.Controllers
{
    public class TourController : Controller
    {
        private readonly ILogger<TourController> _logger;

        public TourController(ILogger<TourController> logger)
        {
            _logger = logger;
        }

        public IActionResult TourManagement()
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
