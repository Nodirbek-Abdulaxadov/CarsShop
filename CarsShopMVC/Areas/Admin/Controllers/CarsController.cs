using Microsoft.AspNetCore.Authorization;

namespace CarsShopMVC.Areas.Admin.Controllers;

[Area("admin")]
[Authorize(AuthenticationSchemes = "Admin")]
public class CarsController (ICarService carService,
                             ICategoryService categoryService,
                             IBrendService brendService)
    : Controller
{
    private readonly ICarService _carService = carService;
    private readonly ICategoryService _categoryService = categoryService;
    private readonly IBrendService _brendService = brendService;

    public IActionResult Index(int pageNumber = 1)
    {
        var moshinalar = _carService.GetAll();
        var pageModel = new PageModel<CarDto>("Views/Shared", moshinalar, pageNumber);
        return View(pageModel);
    }

    public IActionResult Add()
    {
        var categories = _categoryService.GetAll();
        var brends = _brendService.GetAll();

        AddCarDto dto = new()
        {
            Categories = categories,
            Brends = brends
        };

        return View(dto);
    }

    [HttpPost]
    public IActionResult Add(AddCarDto dto)
    {
        try
        {
            _carService.Create(dto);
            return RedirectToAction("index");
        }
        catch (CustomException ex)
        {
            ModelState.AddModelError(ex.Key, ex.Message);
            return View(dto);
        }
    }

    public IActionResult Delete(int id)
    {
        try
        {
            _carService.Delete(id);
            return RedirectToAction("index");
        }
        catch (CustomException)
        {
            return RedirectToAction("error", "home", new { url = "/categories/index" });
        }
    }

    public IActionResult Edit(int id)
    {
        try
        {
            var car = _carService.GetById(id);
            UpdateCarDto dto = new()
            {
                Id = car.Id,
                Name = car.Name,
                Description = car.Description,
                Price = car.Price,
                CategoryId = car.Category.Id,
                BrendId = car.Brend.Id,
                Categories = _categoryService.GetAll(),
                Brends = _brendService.GetAll()
            };

            return View(dto);
        }
        catch (CustomException)
        {
            return RedirectToAction("error", "home", new { url = "/categories/index" });
        }
    }

    [HttpPost]
    public IActionResult Edit(UpdateCarDto dto)
    {
        try
        {
            _carService.Update(dto);
            return RedirectToAction("index");
        }
        catch (CustomException ex)
        {
            ModelState.AddModelError(ex.Key, ex.Message);
            return View(dto);
        }
    }

    public IActionResult Detail(int id)
    {
        try
        {
            var car = _carService.GetById(id);
            return View(car);
        }
        catch (CustomException)
        {
            return RedirectToAction("error", "home", new { url = "/categories/index" });
        }
    }
}