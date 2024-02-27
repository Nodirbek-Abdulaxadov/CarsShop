namespace CarsShop.Data.Interfaces;

public interface IColorInterface : IRepository<Color>
{
    Color GetByIdWithImages(int id);
}
