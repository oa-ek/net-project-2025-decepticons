using Microsoft.AspNetCore.Mvc;

namespace ShubkivTour.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
