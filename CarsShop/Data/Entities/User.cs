namespace CarsShop.Data.Entities;

public class User : BaseEntity
{
    public string FISH { get; set; } = null!;
    public string TelNomer { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Address { get; set; } = null!;

    public List<Order> Orders { get; set; } = new();
}