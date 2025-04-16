using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShubkivTour.Data;
using ShubkivTour.Models.DTO;
using ShubkivTour.Models.Entity;
using ShubkivTour.Repository;

public class ProgramController : Controller
{
    private readonly ApplicationDbContext _context;
    public static TourProgramViewModel tourProgram = new TourProgramViewModel
    {
        Days = new List<DayDTO>(),
        CurrentDay = new DayDTO
        {
            Events = new List<EventDTO>()
        }
    };

    public ProgramController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult DayCreate()
    {
        var allPrograms = _context.TourPrograms.ToList();
        ViewBag.AllPrograms = allPrograms;
        return View(tourProgram);
    }

    [HttpPost]
    public async Task<IActionResult> AddEvent(string name, string description, TimeOnly time, int locationId, IFormFile imageFile)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            var location = _context.Locations.FirstOrDefault(l => l.Id == locationId);

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
                Directory.CreateDirectory(uploadsFolder); // Створюємо директорію, якщо її ще немає

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                var imagePath = Path.Combine("img", uniqueFileName);

                /*var eventImage = new EventImage
                {
                    //EventId = newEvent.Id, // Ідентифікатор події
                    ImagePath = imagePath // Шлях до зображення
                };*/

                //_context.EventImages.Add(eventImage);
                //await _context.SaveChangesAsync();

                var newEvent = new EventDTO
                {
                    Name = name,
                    Description = description,
                    Time = time,
                    Location = location,
                    ImageFilePath = imagePath
                };
                tourProgram.CurrentDay.Events.Add(newEvent);
            }



            return RedirectToAction("DayCreate");

        }

        return BadRequest("Event not added.");
    }

    /* [HttpPost]
     public async Task<IActionResult> AddEvent(string name, string description, TimeOnly time, int locationId, IFormFile imageFile)
     {
         if (!string.IsNullOrWhiteSpace(name))
         {
             var location = _context.Locations.FirstOrDefault(l => l.Id == locationId);
             if (location == null)
             {
                 return NotFound("Location not found.");
             }

             var newEvent = new Event
             {
                 Name = name,
                 Description = description,
                 Time = time,
                 Location = location,
                 Day = null,
                 DayId = null
             };

             _context.Events.Add(newEvent);
             await _context.SaveChangesAsync();

             var tempEvent = new EventDTO
             {
                 Name = newEvent.Name,
                 Description = newEvent.Description,
                 Time = newEvent.Time,
                 Location = newEvent.Location,
                 LocationId = newEvent.LocationId,
                 DayId = newEvent.DayId ?? 0,
                 Day = newEvent.Day
             };

             tourProgram.CurrentDay.Events.Add(tempEvent);

             if (imageFile != null && imageFile.Length > 0)
             {
                 var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
                 Directory.CreateDirectory(uploadsFolder); // Створюємо директорію, якщо її ще немає

                 var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                 var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                 using (var fileStream = new FileStream(filePath, FileMode.Create))
                 {
                     await imageFile.CopyToAsync(fileStream);
                 }

                 var imagePath = Path.Combine("img", uniqueFileName);

                 var eventImage = new EventImage
                 {
                     EventId = newEvent.Id, // Ідентифікатор події
                     ImagePath = imagePath // Шлях до зображення
                 };

                 _context.EventImages.Add(eventImage);
                 await _context.SaveChangesAsync();
             }

             // Повертаємось до створення дня
             return RedirectToAction("DayCreate");
         }

         return BadRequest("Event not added.");
     }*/

    /*public async Task<IActionResult> AddEvent(EventDTO model, int locationId)
    {
        if (ModelState.IsValid)
        {
            var location = _context.Locations.FirstOrDefault(l => l.Id == locationId);
            var newEvent = new Event
            {
                Name = model.Name,
                Description = model.Description,
                Time = model.Time,
                Location = location
            };
            var tempEvent = new EventDTO
            {
                Name = model.Name,
                Description = model.Description,
                Time = model.Time,
                Location = location
            };
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();

            tourProgram.CurrentDay.Events.Add(tempEvent);

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
                Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(fileStream);
                }

                var imagePath = Path.Combine("img", uniqueFileName);

                var eventImage = new EventImage
                {
                    EventID = newEvent.Id,
                    ImagePath = imagePath
                };

                _context.EventImages.Add(eventImage);
                await _context.SaveChangesAsync();
            }
                return RedirectToAction("DayCreate");
            //return Json(tourProgram.CurrentDay.Events);
        }
        return BadRequest("Event not added.");
    }*/


    [HttpPost]
    public IActionResult AddDay()
    {
        int dayNumber = tourProgram.Days.Count + 1;
        if (tourProgram.CurrentDay.Events.Count > 0)
        {
            tourProgram.Days.Add(new DayDTO
            {
                DayNumber = dayNumber,
                Events = new List<EventDTO>(tourProgram.CurrentDay.Events)
            });
            tourProgram.CurrentDay.Events.Clear();
        }

        return RedirectToAction("DayCreate");
    }

    [HttpPost]
    public IActionResult CreateProgram(string name)
    {
        /* var tourProgramEntity = new TourProgram
         {
             Name = name,
             Days = tourProgram.Days.Select(dayDto => new Day
             {
                 DayNumber = dayDto.DayNumber,
                 Events = dayDto.Events.Select(eventDto => new Event
                 {
                     Name = eventDto.Name,
                     Description = eventDto.Description,
                     Time = eventDto.Time,
                     Location = _context.Locations.FirstOrDefault(l => l.Id == eventDto.Location.Id),
                 }).ToList()
             }).ToList()
         };*/
        var tourProgramEntity = new TourProgram
        {
            Name = name,
            Days = new List<Day>()
        };
        var eventImages = new List<EventImage>();

        foreach (var dayDto in tourProgram.Days)
        {
            var day = new Day
            {
                DayNumber = dayDto.DayNumber,
                Events = new List<Event>()
            };
            foreach (var eventDto in dayDto.Events)
            {
                var eventEntity = new Event
                {
                    Name = eventDto.Name,
                    Description = eventDto.Description,
                    Time = eventDto.Time,
                    LocationId = eventDto.Location.Id,
                    Location = _context.Locations.FirstOrDefault(l => l.Id == eventDto.Location.Id)
                };
                day.Events.Add(eventEntity);
                if (!string.IsNullOrEmpty(eventDto.ImageFilePath))
                {
                    eventImages.Add(new EventImage
                    {
                        ImagePath = eventDto.ImageFilePath,
                        Event = eventEntity
                    });
                }
            }
            tourProgramEntity.Days.Add(day);
            _context.TourPrograms.Add(tourProgramEntity);
            _context.SaveChanges();

            foreach (var eventImage in eventImages)
            {
                _context.EventImages.Add(new EventImage
                {
                    EventId = eventImage.Event.Id,
                    ImagePath = eventImage.ImagePath
                });
            }
        }
        _context.SaveChanges();

        /* _context.TourPrograms.Add(tourProgramEntity);
         _context.SaveChanges();*/

        tourProgram = new TourProgramViewModel
        {
            Days = new List<DayDTO>(),
            CurrentDay = new DayDTO { Events = new List<EventDTO>() }
        };

        return RedirectToAction("DayCreate");
    }


    public IActionResult ProgramDetails(int id)
    {
        var tourProgram = _context.TourPrograms
            .Include(tp => tp.Days)
                .ThenInclude(d => d.Events)
                .ThenInclude(e => e.Location)
            .FirstOrDefault(tp => tp.Id == id);

        if (tourProgram == null)
        {
            return NotFound();
        }

        return View(tourProgram);
    }
    [HttpPost]
    public IActionResult RemoveProgram(int id)
    {
        var deletedProgram = _context.TourPrograms.FirstOrDefault(p => p.Id == id);

        if (deletedProgram != null)
        {
            _context.TourPrograms.Remove(deletedProgram);
            _context.SaveChanges();
        }

        return RedirectToAction("DayCreate");
    }


}
