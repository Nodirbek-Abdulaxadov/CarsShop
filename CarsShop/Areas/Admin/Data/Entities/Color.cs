namespace CarsShop.Data.Entities;

public class Color : BaseEntity
{
    public string Name { get; set; } = null!;
    public string HexCode { get; set; } = null!;

    public int CarId { get; set; }
    public Car Car { get; set; } = new();

    public List<Image> Images { get; set; } = new();
}