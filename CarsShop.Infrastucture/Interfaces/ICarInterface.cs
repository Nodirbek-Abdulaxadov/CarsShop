namespace CarsShop.Infrastucture.Interfaces;

public interface ICarInterface : IRepository<Car>
{
    new Task<List<Car>> GetAllAsync();
}