namespace CarsShop.Infrastucture.Repositories;

public class CarRepository(AppDbContext dbContext)
    : Repository<AppDbContext, Car>(dbContext),
      ICarInterface
{
    public new async Task<List<Car>> GetAllAsync()
        => await _dbContext.Cars
                    .Include(c => c.Brend)
                    .Include(c => c.Category)
                    .Include(c => c.Colors)
                    .ThenInclude(c => c.Images)
                    .ToListAsync();
}