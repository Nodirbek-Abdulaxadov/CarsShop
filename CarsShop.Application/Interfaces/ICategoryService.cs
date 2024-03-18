namespace CarsShop.Application.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllAsync();
    Task<PagedModel<CategoryDto>> GetPagedAsync(int pageNumber, int pageSize);
    Task<CategoryDto> GetByIdAsync(int id);
    Task CreateAsync(AddCategoryDto category);
    Task UpdateAsync(UpdateCategoryDto category);
    Task DeleteAsync(int id);
}