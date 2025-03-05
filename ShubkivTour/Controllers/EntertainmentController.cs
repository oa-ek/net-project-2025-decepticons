using Microsoft.AspNetCore.Mvc;
using ShubkivTour.Models.DTO;
using ShubkivTour.Models.Entity;
using ShubkivTour.Models;
using ShubkivTour.Repository;
using ShubkivTour.Repository.Interfaces;
using System.Diagnostics;

namespace ShubkivTour.Controllers
{
    public class EntertainmentController : Controller
    {
        private readonly ILogger<EntertainmentController> _logger;
        private readonly IEntertainments _entertainmentRepository;

        public EntertainmentController(ILogger<EntertainmentController> logger, IEntertainments entertainmentRepository)
        {
            _logger = logger;
            _entertainmentRepository = entertainmentRepository;
        }


		[HttpPost]
		public IActionResult Create(EntertainmentDTOCreate model)
		{
			if (ModelState.IsValid)
			{
				var entertainment = new Entertainment
				{
					Name = model.Name,
					Description = model.Description,
				};
				_entertainmentRepository.CreateEntertainment(entertainment);
				return RedirectToAction("EntertainmentAdd");
			}
			return View(model);

		}
		public IActionResult EntertainmentAdd()
		{
			return View();
		}

		//EntertainmentLook

		[HttpGet]
		public IActionResult EntertainmentLook()
		{
			var entertainments = _entertainmentRepository.GetAllEntertainments();

			var entertainmentDTOs = entertainments.Select(g => new EntertainmentDTOCreate
			{
				Id = g.Id,
				Name = g.Name,
				Description = g.Description,
			}).ToList();

			return View(entertainmentDTOs);
		}
		[HttpPost]
		public IActionResult Delete(int id)
		{
			_entertainmentRepository.DeleteEntertainment(id);
			return RedirectToAction("EntertainmentLook");
		}


        //EntertainmentEdit

        [HttpGet]
        public IActionResult EntertainmentEdit(int id)
        {
            var entertainment = _entertainmentRepository.GetEntertainmentById(id);
            if (entertainment == null)
            {
                return NotFound();
            }

            var entertainmentDTO = new EntertainmentDTOCreate
            {
                Id = entertainment.Id,
                Name = entertainment.Name,
                Description = entertainment.Description
            };

            return View(entertainmentDTO);
        }


        [HttpPost]
		public IActionResult EntertainmentEdit(EntertainmentDTOCreate model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var entertainment = new Entertainment
			{
				Id = model.Id,
				Name = model.Name,
				Description = model.Description,
			};

			_entertainmentRepository.UpdateEntertainment(entertainment);

			return RedirectToAction("EntertainmentLook");
		}


		//Base
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

	}
}
