using Microsoft.AspNetCore.Authorization;

namespace CarsShopMVC.Areas.Admin.Controllers;

[Area("admin")]
[Authorize(AuthenticationSchemes = "Admin")]
public class HomeController : Controller
{   

    public IActionResult Index()
    {
        var res = HttpContext.User;
        
        return View();
    }

    public IActionResult Error(string? url)
    {
        if (url == null)
        {
            url = "/";
        }
        return View("Error404", url);
    }
}
