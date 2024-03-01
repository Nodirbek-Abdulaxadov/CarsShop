namespace CarsShop.Models;

public class CarsViewModel
{
    public PageModel<CarDto>? PageModel { get; set; }
    public List<BrendCheck>? BrendChecks { get; set; }
}

public class BrendCheck
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsChecked { get; set; }
}