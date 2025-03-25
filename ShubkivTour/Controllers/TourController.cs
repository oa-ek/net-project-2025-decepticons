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
		private readonly ILocation _locationRepository;
		private readonly IEntertainments _entertainmentRepository;

		private static List<Guide> guidsInTour = new List<Guide>();
		private static List<Location> locationInTour = new List<Location>();
		private static List<Event> entertainmentInTour = new List<Event>();
        private static TourProgramViewModel tourProgram = new TourProgramViewModel();


        public TourController(ILogger<TourController> logger, ITour tourRepository, IGuide guideRepository, ILocation locationRepository, IEntertainments entertainmentRepository)
		{
			_logger = logger;
			_tourRepository = tourRepository;
			_guideRepository = guideRepository;
			_locationRepository = locationRepository;
			_entertainmentRepository = entertainmentRepository;
		}

		[HttpPost]
		public IActionResult AddGuide(int guideId)
		{
			var guide = _guideRepository.GetGuideById(guideId);
			if (guide != null)
			{
				guidsInTour.Add(guide);
			}
			return RedirectToAction("TourManagement");
		}
		public IActionResult AddLocation(int locationId)
		{
			var location = _locationRepository.GetLocationById(locationId);
			if (location != null)
			{
				locationInTour.Add(location);
			}
			return RedirectToAction("TourManagement");
		}
		public IActionResult AddEntertainment(int entertainmentId)
		{
			var entertainment = _entertainmentRepository.GetEntertainmentById(entertainmentId);
			if (entertainment != null)
			{
				entertainmentInTour.Add(entertainment);
			}
			return RedirectToAction("TourManagement");
		}

		public IActionResult TourManagement()
		{
			var allGuids = _guideRepository.GetAllGuides()
	.Where(g => !guidsInTour.Any(gt => gt.Id == g.Id))
	.ToList();
			var allLocations = _locationRepository.GetAllLocations()
				.Where(l => !locationInTour.Any(lt => lt.Id == l.Id))
				.ToList();
			var allEntertainment = _entertainmentRepository.GetAllEntertainments()
				.Where(e => !entertainmentInTour.Any(et => et.Id == e.Id))
				.ToList();

			var allTours = _tourRepository.GetAllTours();

			ViewBag.AllGuids = allGuids;
			ViewBag.AllLocations = allLocations;
			ViewBag.AllEntertainments = allEntertainment;

			ViewBag.AllTours = allTours;

			return View();
		}
		[HttpPost]
        public IActionResult TourCreate(TourDTOCreate model)
        {
            if (model == null)
            {
                return BadRequest("���������� ���� ��� ��������� ����.");
            }

            var tour = new Tour
            {
                Name = model.Name,
                Complexity = model.Complexity ?? "DefaultValue",
                Price = model.Price,
                Date = model.Date,
				Category = model.Category,
                TourGuides = guidsInTour.Select(guide => new TourGuides
                {
                    GuideId = guide.Id
                }).ToList(),
       
                Days = tourProgram.Days.Select(dayDto => new Day
                {
                    Date = model.Date, 
                    Events = dayDto.Events.Select(eventDto => new Event
                    {
                        Name = eventDto.Name,
                        Description = eventDto.Description,
                        Time = eventDto.Time,
                        Location = eventDto.Location 
                    }).ToList()
                }).ToList()
            };

            _tourRepository.CreateTour(tour);

            guidsInTour.Clear();
            locationInTour.Clear();
            entertainmentInTour.Clear();
            tourProgram = new TourProgramViewModel(); 

            return RedirectToAction("TourManagement");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}


    }

}
