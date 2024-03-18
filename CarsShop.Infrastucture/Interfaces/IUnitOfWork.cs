namespace CarsShop.Infrastucture.Interfaces;

public interface IUnitOfWork
{
    ICategoryInterface Categories { get; }
    ICarInterface Cars { get; }
    IColorInterface Colors { get; }
    IBrendInterface Brends { get; }
    IImageInterface Images { get; }
}