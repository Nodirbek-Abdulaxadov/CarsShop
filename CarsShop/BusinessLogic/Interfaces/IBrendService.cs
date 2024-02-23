namespace CarsShop.BusinessLogic.Interfaces;

public interface IBrendService
{
    List<BrendDto> GetAll();
    BrendDto GetById(int id);
    void Create(AddBrendDto brendDto);
    void Update(UpdateBrendDto brendDto);
    void Delete(int id);
}