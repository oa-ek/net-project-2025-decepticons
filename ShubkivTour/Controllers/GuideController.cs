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

		//GuideAdd

		[HttpPost]
		public IActionResult Create(GuideDTOCreate model)
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
        public IActionResult GuideAdd()
        {
            return View();
        }

        //Guidelook

        [HttpGet]
        public IActionResult GuideLook()
        {
            var guides = _guideRepository.GetAllGuides();

            var guideDTOs = guides.Select(g => new GuideDTOCreate
            {
                Id = g.Id,
                Name = g.Name,
                Specialty = g.Specialty,
                Contact = g.Contact
            }).ToList();

            return View(guideDTOs);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _guideRepository.DeleteGuide(id);
            return RedirectToAction("GuideLook"); 
        }


        //GuideEdit

        [HttpGet]
        public IActionResult GuideEdit(int id)
        {
            var guide = _guideRepository.GetGuideById(id);
            if (guide == null)
            {
                return NotFound();
            }

            var guideDTO = new GuideDTOCreate
            {
                Id = guide.Id,
                Name = guide.Name,
                Specialty = guide.Specialty,
                Contact = guide.Contact
            };

            return View(guideDTO);
        }

        [HttpPost]
        public IActionResult GuideEdit(GuideDTOCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var guide = new Guide
            {
                Id = model.Id,
                Name = model.Name,
                Specialty = model.Specialty,
                Contact = model.Contact
            };

            _guideRepository.UpdateGuide(guide);

            return RedirectToAction("GuideLook");
        }


        //Base
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
