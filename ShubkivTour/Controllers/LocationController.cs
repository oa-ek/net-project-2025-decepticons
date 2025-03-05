using Microsoft.AspNetCore.Mvc;
using ShubkivTour.Models;
using ShubkivTour.Models.Entity;
using ShubkivTour.Models.DTO;
using ShubkivTour.Repository.Interfaces;
using System.Diagnostics;

namespace ShubkivTour.Controllers
{
	public class LocationController : Controller
	{
		private readonly ILogger<LocationController> _logger;
		private readonly ITour _tourRepository;
		private readonly IGuide _guideRepository;
		private readonly ILocation _locationRepository;

		public LocationController(ILogger<LocationController> logger, ITour tourRepository, IGuide guideRepository, ILocation locationRepository)
		{
			_logger = logger;
			_tourRepository = tourRepository;
			_guideRepository = guideRepository;
			_locationRepository = locationRepository;
		}

		public IActionResult LocationManagement()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(LocationDTOCreate model)
		{
			if (ModelState.IsValid)
			{
				var location = new Location
				{
					Name = model.Name,
					Description = model.Description
				};
				_locationRepository.CreateLocation(location);
				return RedirectToAction("LocationAdd");
			}
			return View(model);
		}

		[HttpGet]
		public IActionResult LocationLook()
		{
			var locations = _locationRepository.GetAllLocations();

			var locationDTOs = locations.Select(l => new LocationDTOCreate
			{
				Id = l.Id,
				Name = l.Name,
				Description = l.Description
			}).ToList();

			return View(locationDTOs);
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			_locationRepository.DeleteLocation(id);
			return RedirectToAction("LocationLook");
		}


		//GuideEdit

		[HttpGet]
		public IActionResult LocationEdit(int id)
		{
			var location = _locationRepository.GetLocationById(id);
			if (location == null)
			{
				return NotFound();
			}

			var locationDTO = new LocationDTOCreate
			{
				Id = location.Id,
				Name = location.Name,
				Description = location.Description
			};

			return View(locationDTO);
		}

		[HttpPost]
		public IActionResult LocationEdit(LocationDTOCreate model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var location = new Location
			{
				Id = model.Id,
				Name = model.Name,
				Description = model.Description
			};

			_locationRepository.UpdateLocation(location);

			return RedirectToAction("LocationLook");
		}
        public IActionResult LocationAdd()
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
