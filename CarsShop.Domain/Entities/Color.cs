namespace CarsShop.Domain.Entities;

public class Color : BaseEntity
{
    public string Name { get; set; } = null!;
    public string HexCode { get; set; } = null!;

    public int CarId { get; set; }
    public Car? Car { get; set; }

    public List<Image> Images { get; set; } = new();
}