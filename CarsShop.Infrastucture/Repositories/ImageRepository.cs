namespace CarsShop.Infrastucture.Repositories;

public class ImageRepository(AppDbContext dbContext)
    : Repository<AppDbContext, Image>(dbContext),
      IImageInterface
{
}