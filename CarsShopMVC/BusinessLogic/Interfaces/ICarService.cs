namespace CarsShopMVC.BusinessLogic.Interfaces;

public interface ICarService
{
    List<CarDto> GetAll();
    CarDto GetById(int id);
    void Create(AddCarDto carDto);
    void Update(UpdateCarDto carDto);
    void Delete(int id);
}