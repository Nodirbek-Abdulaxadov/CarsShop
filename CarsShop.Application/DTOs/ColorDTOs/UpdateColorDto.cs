using Microsoft.AspNetCore.Http;

namespace CarsShop.Application.DTOs.ColorDTOs;

public class UpdateColorDto : ColorDto
{
    public List<IFormFile> Files { get; set; } = new();
}