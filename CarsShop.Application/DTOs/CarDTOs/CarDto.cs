using CarsShop.Application.DTOs.ColorDTOs;

namespace CarsShop.Application.DTOs.CarDTOs;

public class CarDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Price { get; set; }
    public CategoryDto Category { get; set; } = new();
    public BrendDto Brend { get; set; } = new();

    public List<ColorDto> Colors { get; set; } = new();
}