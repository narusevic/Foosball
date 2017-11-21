using Microsoft.AspNetCore.Mvc;

namespace FoosballWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}