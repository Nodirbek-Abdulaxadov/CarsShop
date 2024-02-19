namespace CarsShop.Data.Repositories;

public class CarRepository(AppDbContext dbContext)
    : Repository<Car>(dbContext), ICarInterface
{
}