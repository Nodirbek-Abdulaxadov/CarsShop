﻿using Microsoft.AspNetCore.Mvc;

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

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(AddCategoryDto dto)
    {
        try
        {
            _categoryService.Create(dto);
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
            _categoryService.Delete(id);
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
            var category = _categoryService.GetById(id);
            UpdateCategoryDto dto = new()
            {
                Id = category.Id,
                Name = category.Name,
                ImagePath = category.ImagePath
            };

            return View(dto);
        }
        catch (CustomException)
        {
            return RedirectToAction("error", "home", new { url = "/categories/index" });
        }
    }

    [HttpPost]
    public IActionResult Edit(UpdateCategoryDto dto)
    {
        try
        {
            _categoryService.Update(dto);
            return RedirectToAction("index");
        }
        catch (CustomException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(dto);
        }
    }
}