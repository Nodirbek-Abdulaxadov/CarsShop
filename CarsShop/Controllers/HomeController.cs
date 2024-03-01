using CarsShop.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarsShop.Controllers;
public class HomeController (ICarService carService, 
                             IBrendService brendService,
                             ICategoryService categoryService,
                             IColorService colorService,
                             IOrderService orderService)
    : Controller
{
    private readonly ICarService _carService = carService;
    private readonly IBrendService _brendService = brendService;
    private readonly ICategoryService _categoryService = categoryService;
    private readonly IColorService _colorService = colorService;
    private readonly IOrderService _orderService = orderService;

    public IActionResult Index()
    {
        var res = HttpContext.User;

        
        var cars = _carService.GetAll();
        var brends = _brendService.GetAll();
        var categories = _categoryService.GetAll();

        IndexViewModel viewModel = new()
        {
            Cars = cars.Take(9).ToList(),
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

    public IActionResult GetImages(int colorId)
    {
        var images = _colorService.GetImages(colorId);
        return Ok(images);
    }

    public IActionResult Cars(int pageNumber = 1)
    {
        var cars = _carService.GetAll();
        var pageModel = new PageModel<CarDto>(cars, pageNumber, 12);
        var brends = _brendService.GetAll();

        CarsViewModel viewModel = new()
        {
            PageModel = pageModel,
            BrendChecks = brends.Select(c => new BrendCheck() 
                                                    { Id = c.Id, Name = c.Name }
                                                    ).ToList()
        };

        return View(viewModel);
    }

    public IActionResult Filter(CarsViewModel model, int pageNumber = 1)
    {
        var cars = _carService.GetAll();
        var selectedBrendIds = model.BrendChecks!.Where(b => b.IsChecked)
                                                .Select(b => b.Id)
                                                .ToList();

        if (selectedBrendIds.Any())
        {
            cars = cars.Where(c => selectedBrendIds.Contains(c.Brend.Id))
                               .ToList();
        }

        var pageModel = new PageModel<CarDto>(cars, pageNumber, 12);

        CarsViewModel viewModel = new()
        {
            PageModel = pageModel,
            BrendChecks = model.BrendChecks
        };

        return View("Cars", viewModel);
    }

    [Authorize(AuthenticationSchemes = "User")]
    public IActionResult Order(int carId, int colorId)
    {
        _orderService.Add(carId, colorId);
        return RedirectToAction("Index");
    }
}
