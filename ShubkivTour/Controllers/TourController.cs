using Microsoft.AspNetCore.Mvc;
using ShubkivTour.Models;
using ShubkivTour.Models.Entity;
using ShubkivTour.Models.DTO;
using ShubkivTour.Repository.Interfaces;
using System.Diagnostics;

namespace ShubkivTour.Controllers
{
	public class TourController : Controller
	{
		private readonly ILogger<TourController> _logger;
		private readonly ITour _tourRepository;
		private readonly IGuide _guideRepository;

		public TourController(ILogger<TourController> logger, ITour tourRepository, IGuide guideRepository)
		{
			_logger = logger;
			_tourRepository = tourRepository;
			_guideRepository = guideRepository;
		}

		public IActionResult TourManagement()
		{
			return View();
		}


		[HttpPost]
		public IActionResult TourCreate()
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
