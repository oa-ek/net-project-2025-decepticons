using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShubkivTour.Models;
using System.Diagnostics;
using ShubkivTour.Repository.Interfaces;

namespace ShubkivTour.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITour _tourService;

        public HomeController(ILogger<HomeController> logger, ITour tourService)
        {
            _logger = logger;
            _tourService = tourService;
        }

        public IActionResult Index()
        {
            var tours = _tourService.GetUpcomingTours();
            return View(tours);
        }
        [Authorize]
        public IActionResult Privacy()
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
