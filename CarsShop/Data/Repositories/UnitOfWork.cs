namespace CarsShop.Data.Repositories;

public class UnitOfWork(AppDbContext dbContext)
    : IUnitOfWork
{
    public IBrendInterface Brends => new BrendRepository(dbContext);

    public ICarInterface Cars => new CarRepository(dbContext);

    public ICategoryInterface Categories => new CategoryRepository(dbContext);

    public IColorInterface Colors => new ColorRepository(dbContext);

    public IImageInterface Images => new ImageRepository(dbContext);

    public IModelInterface Models => new ModelRepository(dbContext);

    public IOrderInterface Orders => new OrderRepository(dbContext);

    public IUserInterface Users => new UserRepository(dbContext);
}