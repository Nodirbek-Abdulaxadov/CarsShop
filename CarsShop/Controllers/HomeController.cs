using CarsShop.Models;

namespace CarsShop.Controllers;

public class HomeController (ICarService carService, 
                             IBrendService brendService)
    : Controller
{
    private readonly ICarService _carService = carService;
    private readonly IBrendService _brendService = brendService;

    public IActionResult Index()
    {
        var cars = _carService.GetAll();
        var brends = _brendService.GetAll();

        IndexViewModel viewModel = new()
        {
            Cars = cars,
            Brends = brends
        };

        return View(viewModel);
    }
}
