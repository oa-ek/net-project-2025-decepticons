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
		public IActionResult Create(Guide guide)
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
				return RedirectToAction("GuideManagement");
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
		public IActionResult Get()
		{
			_guideRepository.GetAllGuides();
			return View("GuideLook");
		}
		[HttpDelete]
		public IActionResult Delete(int id) //��� ����� ������� ���������
		{
			_guideRepository.DeleteGuide(id);
			return View();
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
