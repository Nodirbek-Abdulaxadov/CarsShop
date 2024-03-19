namespace CarsShop.Application.Interfaces;

public interface ICoffeeService<Dto, AddDto, UpdateDto>
{
    Task<List<Dto>> GetAllAsync();
    Task<PagedModel<Dto>> GetPagedAsync(int pageNumber, int pageSize);
    Task<Dto> GetByIdAsync(int id);
    Task CreateAsync(AddDto model);
    Task UpdateAsync(UpdateDto model);
    Task DeleteAsync(int id);
}