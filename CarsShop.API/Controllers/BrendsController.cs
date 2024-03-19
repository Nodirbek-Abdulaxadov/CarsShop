using CarsShop.Application.DTOs.BrendDTOs;

namespace CarsShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrendsController(IBrendService brendService)
    : ControllerBase
{
    private readonly IBrendService _brendService = brendService;

    [HttpGet]
    public async Task<IActionResult> GetBrends()
    {
        var categories = await _brendService.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("paged")]
    public async Task<IActionResult> GetBrendsPaged(int pageNumber, int pageSize)
    {
        var categories = await _brendService.GetPagedAsync(pageNumber, pageSize);
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrend(int id)
    {
        try
        {
            var brend = await _brendService.GetByIdAsync(id);
            return Ok(brend);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateBrend(AddBrendDto brendDto)
    {
        try
        {
            await _brendService.CreateAsync(brendDto);
            return Ok();
        }
        catch (CarsShopException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBrend(UpdateBrendDto brendDto)
    {
        try
        {
            await _brendService.UpdateAsync(brendDto);
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
    public async Task<IActionResult> DeleteBrend(int id)
    {
        try
        {
            await _brendService.DeleteAsync(id);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}