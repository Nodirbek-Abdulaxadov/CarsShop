
namespace CarsShop.Infrastucture.Repositories;

public class ColorRepository(AppDbContext dbContext)
    : Repository<AppDbContext, Color>(dbContext),
      IColorInterface
{
    public new async Task<List<Color>> GetAllAsync()
        => await _dbContext.Colors
                .Include(c => c.Images)
                .ToListAsync();
}