namespace CarsShop.Application.DTOs.CarDTOs;

public class AddCarDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Price { get; set; }
    public int CategoryId { get; set; }
    public int BrendId { get; set; }
}