namespace CarsShopMVC.Data.Repositories;

public class ImageRepository (AppDbContext dbContext)
    : Repository<Image>(dbContext), IImageInterface
{
}