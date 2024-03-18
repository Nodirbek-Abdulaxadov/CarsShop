namespace CarsShop.Infrastucture.Repositories;

public class ColorRepository(AppDbContext dbContext)
    : Repository<AppDbContext, Color>(dbContext),
      IColorInterface
{
}