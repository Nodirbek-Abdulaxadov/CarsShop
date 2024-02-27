namespace CarsShop.Areas.Admin.Controllers;

[Area("admin")]
public class BrendsController(IBrendService brendService)
    : Controller
{
    private readonly IBrendService _brendService = brendService;

    public IActionResult Index(int pageNumber = 1)
    {
        var categories = _brendService.GetAll();
        var pageModel = new PageModel<BrendDto>(categories, pageNumber);
        return View(pageModel);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(AddBrendDto dto)
    {
        try
        {
            _brendService.Create(dto);
            return RedirectToAction("index");
        }
        catch (CustomException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(dto);
        }
    }

    public IActionResult Delete(int id)
    {
        try
        {
            _brendService.Delete(id);
            return RedirectToAction("index");
        }
        catch (CustomException)
        {
            return RedirectToAction("error", "home", new { url = "/brends/index" });
        }
    }

    public IActionResult Edit(int id)
    {
        try
        {
            var brend = _brendService.GetById(id);
            UpdateBrendDto dto = new()
            {
                Id = brend.Id,
                Name = brend.Name,
                ImagePath = brend.ImagePath
            };

            return View(dto);
        }
        catch (CustomException)
        {
            return RedirectToAction("error", "home", new { url = "/brends/index" });
        }
    }

    [HttpPost]
    public IActionResult Edit(UpdateBrendDto dto)
    {
        try
        {
            _brendService.Update(dto);
            return RedirectToAction("index");
        }
        catch (CustomException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(dto);
        }
    }
}