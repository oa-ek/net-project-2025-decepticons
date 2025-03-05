using Microsoft.AspNetCore.Mvc;
using ShubkivTour.Models;
using ShubkivTour.Models.Entity;
using ShubkivTour.Repository.Interfaces;
using System.Diagnostics;

namespace ShubkivTour.Controllers
{
	public class GuideController : Controller
	{
		private readonly ILogger<GuideController> _logger;
		private readonly IGuide _guideRepository;

		public GuideController(ILogger<GuideController> logger, IGuide guideRepository)
		{
			_logger = logger;
			_guideRepository = guideRepository;

		}
		/*public GuideController(IGuide guideRepository)
		{
			_guideRepository = guideRepository;
		}*/

		[HttpPost]
		public IActionResult GuideCreate(Guide guide)
		{
			/*			if (ModelState.IsValid)
						{
							_guideRepository.CreateGuide(guide);
							return RedirectToAction("GuideManagement");
						}
						return View(guide);*/
			_guideRepository.CreateGuide(guide);
			return RedirectToAction("GuideManagement");
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
