namespace CarsShop.Data.Entities;

public class Model: BaseEntity
{
    public string Name { get; set; } = null!;
    public double Narxi { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; } = new();
}