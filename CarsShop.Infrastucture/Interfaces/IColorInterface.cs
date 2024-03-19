namespace CarsShop.Infrastucture.Interfaces;

public interface IColorInterface : IRepository<Color>
{
    new Task<List<Color>> GetAllAsync();
}