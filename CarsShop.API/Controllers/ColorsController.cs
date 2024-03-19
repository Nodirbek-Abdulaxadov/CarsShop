using CarsShop.Application.DTOs.ColorDTOs;

namespace CarsShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColorsController(IColorService colorService)
    : ControllerBase
{
    private readonly IColorService _colorService = colorService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cars = await _colorService.GetAllAsync();
        return Ok(cars);
    }

    [HttpGet("paged")]
    public async Task<IActionResult> GetPaged(int pageSize, int pageNumber)
    {
        try
        {
            var cars = await _colorService.GetPagedAsync(pageSize, pageNumber);
            return Ok(cars);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var car = await _colorService.GetByIdAsync(id);
            return Ok(car);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddColorDto dto)
    {
        try
        {
            await _colorService.CreateAsync(dto);
            return Ok();
        }
        catch (CarsShopException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateColorDto dto)
    {
        try
        {
            await _colorService.UpdateAsync(dto);
            return Ok();
        }
        catch (CarsShopException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _colorService.DeleteAsync(id);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}