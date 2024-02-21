namespace CarsShop.BusinessLogic.Interfaces;

public interface ICategoryService
{
    List<CategoryDto> GetAll();
    CategoryDto GetById(int id);
    void Create(AddCategoryDto categoryDto);
    void Update(UpdateCategoryDto categoryDto);
    void Delete(int id);
}