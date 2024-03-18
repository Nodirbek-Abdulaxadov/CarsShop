namespace CarsShopMVC.Data.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;

    public List<Car> Cars { get; set; } = new();
}