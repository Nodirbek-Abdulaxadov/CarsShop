namespace CarsShop.Data.Entities;

public class Brend : BaseEntity
{
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;

    public List<Car> Cars { get; set; } = new();
}