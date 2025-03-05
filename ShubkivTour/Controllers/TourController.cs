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

		public TourController(ILogger<TourController> logger, ITour tourRepository)
        {
            _logger = logger;
			_tourRepository = tourRepository;
        }

        public IActionResult TourManagement()
        {
            return View();
        }

		[HttpPost]
		public IActionResult GuideCreate(TourDTOCreate model)
		{
			if (ModelState.IsValid)
			{
				var tour = new Tour
				{

				};
				_tourRepository.CreateTour(tour);
				return RedirectToAction("TourManagement");
			}
			return View(model);
			/*			if (ModelState.IsValid)
						{
							_guideRepository.CreateGuide(guide);
							return RedirectToAction("GuideManagement");
						}
						return View(guide);*//*
			_guideRepository.CreateGuide(guide);
			return RedirectToAction("GuideManagement");*/

		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
