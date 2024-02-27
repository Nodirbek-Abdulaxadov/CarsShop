namespace CarsShop.Models;

public class IndexViewModel
{
    public List<CarDto> Cars { get; set; } = new();
    public List<BrendDto> Brends { get; set; } = new();
}