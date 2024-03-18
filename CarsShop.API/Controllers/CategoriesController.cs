using CarsShop.Application.DTOs.CategoryDTOs;

namespace CarsShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService categoryService)
    : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _categoryService.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("paged")]
    public async Task<IActionResult> GetCategoriesPaged(int pageNumber, int pageSize)
    {
        var categories = await _categoryService.GetPagedAsync(pageNumber, pageSize);
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        try
        {
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(category);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(AddCategoryDto categoryDto)
    {
        try
        {
            await _categoryService.CreateAsync(categoryDto);
            return Ok();
        }
        catch (CarsShopException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto)
    {
        try
        {
            await _categoryService.UpdateAsync(categoryDto);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (CarsShopException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        try
        {
            await _categoryService.DeleteAsync(id);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}