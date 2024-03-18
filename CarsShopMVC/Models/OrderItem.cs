namespace CarsShopMVC.Models;

public class OrderItem
{
    public CarDto Car { get; set; } = new();
    public int Quantity { get; set; }
    public decimal Price { get; set; } 
}