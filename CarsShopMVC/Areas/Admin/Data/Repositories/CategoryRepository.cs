namespace CarsShopMVC.Data.Repositories;

public class CategoryRepository(AppDbContext dbContext)
    : Repository<Category>(dbContext), ICategoryInterface
{
}