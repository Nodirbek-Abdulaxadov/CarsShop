namespace CarsShop.Infrastucture.Repositories;

public class UnitOfWork(AppDbContext dbContext)
    : IUnitOfWork
{
    private readonly AppDbContext _dbContext = dbContext;

    public ICategoryInterface Categories => new CategoryRepository(_dbContext);

    public ICarInterface Cars => new CarRepository(_dbContext);

    public IColorInterface Colors => new ColorRepository(_dbContext);

    public IBrendInterface Brends => new BrendRepository(_dbContext);

    public IImageInterface Images => new ImageRepository(_dbContext);
}