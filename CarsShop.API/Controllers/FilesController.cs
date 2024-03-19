using GenericRepository;

namespace CarsShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilesController : ControllerBase
{

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        var result = await Coffee.UploadFile(file);
        if (string.IsNullOrEmpty(result))
        {
            return BadRequest("Upload failed");
        }

        return Ok(result);
    }

    [HttpPost("uploadMultiple")]
    public async Task<IActionResult> UploadMultiple(List<IFormFile> files)
    {
        var result = await Coffee.UploadMultipleFiles(files);
        if (!result.Any())
        {
            return BadRequest("Upload failed");
        }

        return Ok(result);
    }
}