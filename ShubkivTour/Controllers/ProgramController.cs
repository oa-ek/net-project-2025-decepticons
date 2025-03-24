using Microsoft.AspNetCore.Mvc;

namespace ShubkivTour.Controllers
{
	public class ProgramController : Controller
	{
		public IActionResult DayCreate()
		{
			return View();
		}

	}
}
