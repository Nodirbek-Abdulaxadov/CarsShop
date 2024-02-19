namespace CarsShop.Data.Entities;

public class Order : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } = new();
    public DateTime Date { get; set; } = DateTime.Now;

    public int CarId { get; set; }
    public Car Car { get; set; } = new();
    public string ColorName { get; set; } = null!;
    public string ModelName { get; set; } = null!;
    public double Price { get; set; }
}