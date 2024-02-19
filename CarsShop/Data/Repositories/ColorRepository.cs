namespace CarsShop.Data.Repositories;

public class ColorRepository (AppDbContext dbContext)
    : Repository<Color>(dbContext), IColorInterface
{
}