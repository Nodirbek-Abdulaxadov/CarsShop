namespace CarsShopMVC.Data.Entities;

public class Image : BaseEntity
{
    public string Url { get; set; } = null!;
    public int ColorId { get; set; }
    public Color Color { get; set; } = new();
}