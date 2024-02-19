namespace CarsShop.Data.Repositories;

public class ModelRepository(AppDbContext dbContext)
    : Repository<Model>(dbContext), IModelInterface
{
}