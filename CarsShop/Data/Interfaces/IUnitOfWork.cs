namespace CarsShop.Data.Interfaces;

public interface IUnitOfWork
{
    IBrendInterface Brends { get; }
    ICarInterface Cars { get; }
    ICategoryInterface Categories { get; }
    IColorInterface Colors { get; }
    IImageInterface Images { get; }
    IOrderInterface Orders { get; }
    IUserInterface Users { get; }
}