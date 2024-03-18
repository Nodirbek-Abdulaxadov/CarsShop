namespace CarsShopMVC.Data.Repositories;

public class BrendRepository (AppDbContext dbContext)
    : Repository<Brend>(dbContext), IBrendInterface
{
}