namespace CarsShop.BusinessLogic.DTOs.ColorDTOs;

public class UpdateColorDto : ColorDto
{
    public List<IFormFile> Files { get; set; } = new();
}