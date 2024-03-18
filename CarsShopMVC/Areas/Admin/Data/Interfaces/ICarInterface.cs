namespace CarsShopMVC.Data.Interfaces;

public interface ICarInterface : IRepository<Car>
{
    List<Car> GetCarsWithReleations();
}