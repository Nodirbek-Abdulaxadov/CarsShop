using CarsShopMVC.BusinessLogic.DTOs.ColorDTOs;

namespace CarsShopMVC.BusinessLogic.Interfaces;

public interface IColorService
{
    List<ColorDto> GetAll();
    List<string> GetImages(int id);
    ColorDto GetById(int id);
    void Create(AddColorDto carDto);
    void Update(UpdateColorDto carDto);
    void Delete(int id);
    void DeleteImage(int id);
}