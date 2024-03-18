
namespace CarsShopMVC.Data.Repositories;

public class ColorRepository(AppDbContext dbContext)
    : Repository<Color>(dbContext), IColorInterface
{
    public Color GetByIdWithImages(int id)
        => _dbContext.Colors
            .Include(c => c.Images)
            .Include(x => x.Car)
            .FirstOrDefault(c => c.Id == id);
}