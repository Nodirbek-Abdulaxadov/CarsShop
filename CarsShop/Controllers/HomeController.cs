using CarsShop.Models;

namespace CarsShop.Controllers;
public class HomeController (ICarService carService, 
                             IBrendService brendService,
                             ICategoryService categoryService)
    : Controller
{
    private readonly ICarService _carService = carService;
    private readonly IBrendService _brendService = brendService;
    private readonly ICategoryService _categoryService = categoryService;

    public IActionResult Index()
    {
        var res = HttpContext.User;

        
        var cars = _carService.GetAll();
        var brends = _brendService.GetAll();
        var categories = _categoryService.GetAll();

        IndexViewModel viewModel = new()
        {
            Cars = cars,
            Brends = brends,
            Categories = categories
        };

        return View(viewModel);
    }

    public IActionResult More(int id)
    {
        var car = _carService.GetById(id);
        return View(car);
    }
}
