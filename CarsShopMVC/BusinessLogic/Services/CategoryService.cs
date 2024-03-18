namespace CarsShopMVC.BusinessLogic.Services;

public class CategoryService(IUnitOfWork unitOfWork,
                             IFileService fileService)
    : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IFileService _fileService = fileService;

    public void Create(AddCategoryDto categoryDto)
    {
        if (categoryDto == null)
        {
            throw new CustomException("", "CategoryDto was null");
        }

        if (string.IsNullOrEmpty(categoryDto.Name))
        {
            throw new CustomException("Name", "Category name is required");
        }

        if (categoryDto.Name.Length < 3 || categoryDto.Name.Length > 30)
        {
            throw new CustomException("Name", "Category name must be between 3 and 30 characters");
        }

        if (categoryDto.file == null)
        {
            throw new CustomException("file", "Category image is required");
        }
        string img = _fileService.UploadImage(categoryDto.file);
        for (int i = 0; i < 1001; i++)
        {
            Category category = new()
            {
                Name = categoryDto.Name,
                ImageUrl = img
            };

            _unitOfWork.Categories.Add(category);
        }
    }

    public void Delete(int id)
    {
        var category = _unitOfWork.Categories.GetById(id);

        if (category == null)
        {
            throw new CustomException("", "Category not found");
        }
        _fileService.DeleteImage(category.ImageUrl);
        _unitOfWork.Categories.Delete(category.Id);
    }

    public List<CategoryDto> GetAll()
    {
        var categories = _unitOfWork.Categories.GetAll();
        var list = categories.Select(c => new CategoryDto()
        {
            Id = c.Id,
            Name = c.Name,
            ImagePath = c.ImageUrl
        }).ToList();

        return list;
    }

    public CategoryDto GetById(int id)
    {
        var category = _unitOfWork.Categories.GetById(id);

        if (category == null)
        {
            throw new CustomException("", "Category not found");
        }

        var dto = new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name,
            ImagePath = category.ImageUrl
        };

        return dto;
    }

    public void Update(UpdateCategoryDto categoryDto)
    {
        var category = _unitOfWork.Categories.GetById(categoryDto.Id);

        if (category == null)
        {
            throw new CustomException("", "Category not found");
        }

        if (string.IsNullOrEmpty(categoryDto.Name))
        {
            throw new CustomException("", "Category name is required");
        }

        if (categoryDto.Name.Length < 3 || categoryDto.Name.Length > 30)
        {
            throw new CustomException("", "Category name must be between 3 and 30 characters");
        }

        if (categoryDto.file != null)
        {
            _fileService.DeleteImage(category.ImageUrl);
            categoryDto.ImagePath = _fileService.UploadImage(categoryDto.file);
        }

        category.Name = categoryDto.Name;
        category.ImageUrl = categoryDto.ImagePath;

        _unitOfWork.Categories.Update(category);
    }
}