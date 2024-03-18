namespace CarsShop.Infrastucture.Repositories;

public class CarRepository(AppDbContext dbContext)
    : Repository<AppDbContext, Car>(dbContext),
      ICarInterface
{
}