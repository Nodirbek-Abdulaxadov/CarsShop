namespace CarsShop.BusinessLogic.DTOs.ColorDTOs;

public class AddColorDto
{
    public string Name { get; set; } = null!;
    public string HexCode { get; set; } = null!;
    public int CarId { get; set; }
    public List<IFormFile> Files { get; set; } = new();
}
