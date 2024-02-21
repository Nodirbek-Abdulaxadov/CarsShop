namespace CarsShop.BusinessLogic.Services;

public class CategoryService(IUnitOfWork unitOfWork)
    : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public void Create(AddCategoryDto categoryDto)
    {
        if (categoryDto == null)
        {
            throw new CustomException("CategoryDto was null");
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
        var category = _unitOfWork.Categories.GetById(id);

        if (category == null)
        {
            throw new CustomException("Category not found");
        }

        _unitOfWork.Categories.Delete(category.Id);
    }

    public List<CategoryDto> GetAll()
    {
        var categories = _unitOfWork.Categories.GetAll();
        var list = categories.Select(c => new CategoryDto()
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();

        return list;
    }

    public CategoryDto GetById(int id)
    {
        var category = _unitOfWork.Categories.GetById(id);

        if (category == null)
        {
            throw new CustomException("Category not found");
        }

        var dto = new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name
        };

        return dto;
    }

    public void Update(CategoryDto categoryDto)
    {
        var category = _unitOfWork.Categories.GetById(categoryDto.Id);

        if (category == null)
        {
            throw new CustomException("Category not found");
        }

        if (string.IsNullOrEmpty(categoryDto.Name))
        {
            throw new CustomException("Category name is required");
        }

        if (categoryDto.Name.Length < 3 || categoryDto.Name.Length > 30)
        {
            throw new CustomException("Category name must be between 3 and 30 characters");
        }

        var dto = new Category()
        {
            Id = categoryDto.Id,
            Name = categoryDto.Name
        };

        _unitOfWork.Categories.Update(dto);
    }
}