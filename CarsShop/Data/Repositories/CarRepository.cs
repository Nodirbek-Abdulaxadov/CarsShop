
namespace CarsShop.Data.Repositories;

public class CarRepository(AppDbContext dbContext)
    : Repository<Car>(dbContext), ICarInterface
{
    public List<Car> GetCarsWithReleations()
        => _dbContext.Cars
            .Include(c => c.Category)
            .Include(c => c.Brend)
            .ToList();
}