namespace CarsShop.BusinessLogic.DTOs.ColorDTOs;

public class ColorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string HexCode { get; set; } = null!;
    public int CarId { get; set; }
    public List<ImageDto> Images { get; set; } = new();

    public static implicit operator ColorDto(Color color)
        => new()
        {
            Id = color.Id,
            Name = color.Name,
            HexCode = color.HexCode,
            CarId = color.CarId,
            Images = color.Images.Select(i => (ImageDto)i).ToList(),
        };
}

public class ImageDto
{
    public int Id { get; set; }
    public string Url { get; set; } = null!;
    public int ColorId { get; set; }

    public static implicit operator ImageDto(Image image)
        => new()
        {
            Id = image.Id,
            Url = image.Url,
            ColorId = image.ColorId
        };
}