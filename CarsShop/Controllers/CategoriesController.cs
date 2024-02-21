using Microsoft.AspNetCore.Mvc;

namespace CarsShop.Controllers;

public class CategoriesController(ICategoryService categoryService)
    : Controller
{
    private readonly ICategoryService _categoryService = categoryService;

    public IActionResult Index()
    {
        var categories = _categoryService.GetAll();
        return View(categories);
    }
}