using Microsoft.AspNetCore.Mvc;

namespace CarsShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
