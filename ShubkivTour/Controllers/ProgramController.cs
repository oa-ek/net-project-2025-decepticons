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
		CurrentDay = new DayDTO { Events = new List<EventDTO>() }
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
	public IActionResult AddEvent(string name, string description, TimeOnly time)
	{
		if (!string.IsNullOrWhiteSpace(name))
		{
			tourProgram.CurrentDay.Events.Add(new EventDTO
			{
				Name = name,
				Description = description,
				Time = time,
				Location = null
			});
		}

		return RedirectToAction("DayCreate");
	}

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
        var tourProgramEntity = new TourProgram
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
                    LocationId = eventDto.Location?.Id ?? 1
                }).ToList()
            }).ToList()
        };

        _context.TourPrograms.Add(tourProgramEntity);
        _context.SaveChanges();

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
