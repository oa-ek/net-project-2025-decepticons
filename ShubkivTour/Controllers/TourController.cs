using Microsoft.AspNetCore.Mvc;
using ShubkivTour.Models;
using ShubkivTour.Models.Entity;
using ShubkivTour.Models.DTO;
using ShubkivTour.Repository.Interfaces;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ShubkivTour.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Drawing;

namespace ShubkivTour.Controllers
{
    public class TourController : Controller
    {
        private readonly ILogger<TourController> _logger;
        private readonly ITour _tourRepository;
        private readonly IGuide _guideRepository;
        private readonly ILocation _locationRepository;
        private readonly IEntertainments _entertainmentRepository;

        private readonly ApplicationDbContext _context;
        private readonly UserManager<Client> _userManager;

        private static List<Guide> guidsInTour = new List<Guide>();
        private static List<Location> locationInTour = new List<Location>();
        private static List<Event> entertainmentInTour = new List<Event>();


        public TourController(UserManager<Client> userManager, ILogger<TourController> logger, ITour tourRepository, IGuide guideRepository, ILocation locationRepository, IEntertainments entertainmentRepository, ApplicationDbContext context)
        {
            _logger = logger;
            _tourRepository = tourRepository;
            _guideRepository = guideRepository;
            _locationRepository = locationRepository;
            _entertainmentRepository = entertainmentRepository;
            _context = context;
            _userManager = userManager;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddGuide([FromBody] int guideId)
        {
            var guide = _guideRepository.GetGuideById(guideId);
            if (guide == null)
            {
                return BadRequest(new { success = false, message = "Гід не знайдений." });
            }

            guidsInTour.Add(guide);
            return Ok(new { success = true, message = "Гіда додано до туру.", guide });

        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddLocation(int locationId)
        {
            var location = _locationRepository.GetLocationById(locationId);
            if (location != null)
            {
                locationInTour.Add(location);
            }
            return RedirectToAction("TourLook");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AddEntertainment(int entertainmentId)
        {
            var entertainment = _entertainmentRepository.GetEntertainmentById(entertainmentId);
            if (entertainment != null)
            {
                entertainmentInTour.Add(entertainment);
            }
            return RedirectToAction("TourLook");
        }

        public IActionResult TourLook()
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

            var allTourPrograms = _context.TourPrograms.ToList();

            ViewBag.AllGuids = allGuids;
            ViewBag.AllLocations = allLocations;
            ViewBag.AllEntertainments = allEntertainment;
            ViewBag.AllTours = allTours;
            ViewBag.AllTourPrograms = allTourPrograms;

            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> TourCreate(TourDTOCreate model, int TourProgramId, IFormFile imageFile)
        {
            if (model == null)
            {
                return BadRequest("Alah.");
            }

            var selectedProgram = _context.TourPrograms
                .Include(tp => tp.Days)
                .ThenInclude(d => d.Events)
                .FirstOrDefault(tp => tp.Id == TourProgramId);

            if (selectedProgram == null)
            {
                return BadRequest("Babah.");
            }

            string imagePath = null;

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
                Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                imagePath = Path.Combine("img", uniqueFileName);

            }

            var tour = new Tour
            {
                Name = model.Name,
                Complexity = model.Complexity ?? "DefaultValue",
                Price = model.Price,
                Date = model.Date,
                Category = model.Category,
                MaxMembers = model.MaxMembers,
                CurrentMembers = 0,
                TourGuides = guidsInTour.Select(guide => new TourGuides { GuideId = guide.Id }).ToList(),
                TourProgram = selectedProgram,
                Status = "Набір людей",
                EndDate = model.Date.AddDays(selectedProgram.Days.Count),
                ReviewSent = false
            };


            _tourRepository.CreateTour(tour);

            if (!string.IsNullOrEmpty(imagePath))
            {
                var tourImage = new TourImage
                {
                    ImagePath = imagePath,
                    Tour = tour
                };

                _context.TourImages.Add(tourImage);
                await _context.SaveChangesAsync();
            }


            guidsInTour.Clear();
            locationInTour.Clear();
            entertainmentInTour.Clear();

            return RedirectToAction("TourLook");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TourDetails(int id)
        {
            var tour = _context.Tours
      .Include(t => t.TourProgram)
          .ThenInclude(tp => tp.Days)
              .ThenInclude(d => d.Events)
                  .ThenInclude(e => e.Image)
                  .Include(t => t.TourClients)
      .FirstOrDefault(t => t.Id == id);

            var ev = _context.Events
    .Include(e => e.Image)
    .FirstOrDefault(e => e.Id == id);

            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult RemoveTour(int id)
        {
            var deletedTour = _tourRepository.GetToursById(id);
            if (deletedTour != null)
            {
                _tourRepository.DeleteTour(id);
            }
            return RedirectToAction("TourLook");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult TourAdd()
        {
            ViewBag.AllGuids = _guideRepository.GetAllGuides();
            ViewBag.AllTourPrograms = _context.TourPrograms.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult GetTourWithDetails(int id)
        {
            var tour = _context.Tours
     .Where(t => t.Id == id)
     .Include(t => t.TourProgram)
         .ThenInclude(tp => tp.Days)
             .ThenInclude(d => d.Events)
     .FirstOrDefault();


            if (tour == null)
            {
                return NotFound("��� �� ��������");
            }

            return View(tour);
        }

        //РЕЄСТРАЦІЯ НА ТУР ТА ОПЛАТА
        public async Task<IActionResult> Pay(int tourId)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            var tour = _tourRepository.GetToursById(tourId);
            decimal tourPrice = Convert.ToDecimal(tour.Price);

            var model = new BusinessPaymentDto
            {
                ApiKey = "MTSIT9i7HY7QpskDE1iKPPgHBjdviu",
                Amount = tourPrice,
                Currency = "UAH"
            };

            ViewBag.TourId = tourId;
            return View("Pay", model);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmPayment(BusinessPaymentDto payment, int tourId)
        {
            var tour = _tourRepository.GetToursById(tourId);
            decimal tourPrice = Convert.ToDecimal(tour.Price);

            payment.Amount = tourPrice;

            using var client = new HttpClient();

            var response = await client.PostAsJsonAsync(
                "https://chakish-bank-api-2f1d3ff18869.herokuapp.com/api/business/pay",
                payment
            );

            if (response.IsSuccessStatusCode)
            {
                var userId = _userManager.GetUserId(User);

                try
                {
                    await _tourRepository.RegisterForTour(tourId, userId);
                    TempData["SuccessMessage"] = "Оплата пройшла успішно! Ви зареєстровані на тур.";
                    return RedirectToAction("RegThanks");   
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Помилка реєстрації: " + ex.Message;
                    return RedirectToAction("TourLook");
                }
            }

            var error = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, $"Оплата не вдалася: {error}");
            ViewBag.TourId = tourId;
            return View("Pay", payment);
        }

        public IActionResult RegThanks()
        {
            return View();
        }


        //ВІДГУКИ
        [HttpGet]
        public IActionResult AddTourReview(int id)
        {
            var tour = _context.Tours.FirstOrDefault(t => t.Id == id);
            if (tour == null)
                return NotFound();

            var model = new ReviewViewModel
            {
                TourId = tour.Id
                //TourName = tour.Name
            };

            return View("AddTourReview", model);
        }

        public IActionResult Review(int id)
        {
            var tour = _context.Tours.FirstOrDefault(t => t.Id == id);
            if (tour == null)
                return NotFound();

            var model = new ReviewViewModel
            {
                TourId = tour.Id
                //TourName = tour.Name
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult SubmitReview(ReviewViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("AddTourReview", model);
            }

            var review = new Review
            {
                TourId = model.TourId,
                ReviewerName = model.ReviewerName,
                Comment = model.Comment,
                Date = DateTime.Now
            };

            _context.Reviews.Add(review);
            _context.SaveChanges();

            return RedirectToAction("ReviewThanks");
        }
        public IActionResult ReviewThanks()
        {
            return View();
        }


        //CLIENT
        [HttpGet]
        public IActionResult TourClient(int id)
        {
            var clients = _tourRepository.GetTourClient(id);
            ViewBag.TourId = id;
            return View(clients);
        }
        [HttpPost]
        public IActionResult RemoveClientFromTour(int tourId, string clientId)
        {
            _tourRepository.RemoveClientFromTour(tourId, clientId);
            return RedirectToAction("TourClient", new { id = tourId });
        }

    }

}
