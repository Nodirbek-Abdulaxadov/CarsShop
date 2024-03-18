namespace CarsShopMVC.Data.Interfaces;

public interface IColorInterface : IRepository<Color>
{
    Color GetByIdWithImages(int id);
}
