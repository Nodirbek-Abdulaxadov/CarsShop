namespace CarsShop.BusinessLogic.Services;

public class CategoryService(IUnitOfWork unitOfWork)
    : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public void Create(AddCategoryDto categoryDto)
    {
        if (categoryDto == null)
        {
            throw new ArgumentNullException("CategoryDto was null");
        }

        if (string.IsNullOrEmpty(categoryDto.Name))
        {
            throw new CustomException("Category name is required");
        }

        if (categoryDto.Name.Length < 3 || categoryDto.Name.Length > 30)
        {
            throw new CustomException("Category name must be between 3 and 30 characters");
        }

        Category category = new()
        {
            Name = categoryDto.Name
        };

        _unitOfWork.Categories.Add(category);
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<CategoryDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public CategoryDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(CategoryDto categoryDto)
    {
        throw new NotImplementedException();
    }
}