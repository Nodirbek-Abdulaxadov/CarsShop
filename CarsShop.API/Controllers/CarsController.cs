using CarsShop.Application.DTOs.CarDTOs;

namespace CarsShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController(ICarService carService)
    : ControllerBase
{
    private readonly ICarService _carService = carService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cars = await _carService.GetAllAsync();
        return Ok(cars);
    }

    [HttpGet("paged")]
    public async Task<IActionResult> GetPaged(int pageSize, int pageNumber)
    {
        try
        {
            var cars = await _carService.GetPagedAsync(pageSize, pageNumber);
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
            var car = await _carService.GetByIdAsync(id);
            return Ok(car);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddCarDto dto)
    {
        try
        {
            await _carService.CreateAsync(dto);
            return Ok();
        }
        catch (CarsShopException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateCarDto dto)
    {
        try
        {
            await _carService.UpdateAsync(dto);
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
            await _carService.DeleteAsync(id);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}