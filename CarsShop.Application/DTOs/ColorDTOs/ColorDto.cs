namespace CarsShop.Application.DTOs.ColorDTOs;

public class ColorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string HexCode { get; set; } = null!;
    public int CarId { get; set; }
    public List<ImageDto> Images { get; set; } = new();
}

public class ImageDto
{
    public int Id { get; set; }
    public string Url { get; set; } = null!;
    public int ColorId { get; set; }
}