namespace CarsShop.Areas.Admin.Controllers;

[Area("admin")]
public class ColorsController(IColorService colorService)
    : Controller
{
    private readonly IColorService _colorService = colorService;

    public IActionResult Add(int carId)
    {
        AddColorDto dto = new()
        {
            CarId = carId
        };
        return View(dto);
    }

    [HttpPost]
    public IActionResult Add(AddColorDto dto)
    {
        _colorService.Create(dto);
        return RedirectToAction("Detail", "Cars", new { id = dto.CarId });
    }

    public IActionResult Images(int id)
    {
        var color = _colorService.GetImages(id);
        return View(color);
    }

    public IActionResult Delete(int colorId, int carId)
    {
        _colorService.Delete(colorId);
        return RedirectToAction("Detail", "Cars", new { id = carId });
    }

    public IActionResult Edit(int colorId, int carId)
    {
        var color = _colorService.GetById(colorId);
        UpdateColorDto dto = new()
        {
            Id = colorId,
            Name = color.Name,
            HexCode = color.HexCode,
            CarId = carId,
            Images = color.Images,
        };

        return View(dto);
    }

    public IActionResult DeleteImage(int colorId, int carId, int imageId)
    {
        _colorService.DeleteImage(imageId);
        return RedirectToAction("Edit", new { colorId, carId });
    }

    [HttpPost]
    public IActionResult Edit(UpdateColorDto dto)
    {
        _colorService.Update(dto);

        return RedirectToAction("Detail", "Cars", new { id = dto.CarId });
    }
}