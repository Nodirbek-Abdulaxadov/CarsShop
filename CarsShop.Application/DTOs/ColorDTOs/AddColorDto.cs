namespace CarsShop.Application.DTOs.ColorDTOs;

public class AddColorDto
{
    public string Name { get; set; } = null!;
    public string HexCode { get; set; } = null!;
    public int CarId { get; set; }
    public List<string> ImageUrls { get; set; } = new();
}
