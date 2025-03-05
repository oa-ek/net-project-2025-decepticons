using Microsoft.AspNetCore.Mvc;
using ShubkivTour.Models;
using ShubkivTour.Models.Entity;
using ShubkivTour.Models.DTO;
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
		public IActionResult Create(GuideDTO model)
		{
			if(ModelState.IsValid)
			{
				var guide = new Guide
				{
					Name = model.Name,
					Specialty = model.Specialty,
					Contact = model.Contact
				};
				_guideRepository.CreateGuide(guide);
				return RedirectToAction("GuideAdd");
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
		[HttpGet]
        public IActionResult GuideLook()
        {
            var guides = _guideRepository.GetAllGuides();

            var guideDTOs = guides.Select(g => new GuideDTO
            {
                Id = g.Id,
                Name = g.Name,
                Specialty = g.Specialty,
                Contact = g.Contact
            }).ToList();

            return View(guideDTOs);
        }
        [HttpDelete]
		public IActionResult Delete(int id)
		{
			_guideRepository.DeleteGuide(id);
            return RedirectToAction("GuideLook");
        }
		public IActionResult GuideAdd()
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
