namespace CarsShop.Infrastucture.Repositories;

public class BrendRepository(AppDbContext dbContext)
    : Repository<AppDbContext, Brend>(dbContext),
      IBrendInterface
{
}