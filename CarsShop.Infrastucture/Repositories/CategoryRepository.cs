namespace CarsShop.Infrastucture.Repositories;

public class CategoryRepository(AppDbContext dbContext) 
    : Repository<AppDbContext, Category>(dbContext),
      ICategoryInterface
{
}