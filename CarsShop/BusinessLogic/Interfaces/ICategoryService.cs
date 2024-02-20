namespace CarsShop.BusinessLogic.Interfaces;

public interface ICategoryService
{
    List<CategoryDto> GetAll();
    CategoryDto GetById(int id);
    void Create(AddCategoryDto categoryDto);
    void Update(CategoryDto categoryDto);
    void Delete(int id);
}