namespace CarsShop.Application.Services;

public class CategoryService(IUnitOfWork unitOfWork,
                             IMapper mapper,
                             IValidator<Category> validator)
    : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<Category> _validator = validator;

    public async Task CreateAsync(AddCategoryDto dto)
    {
        if (dto is null)
        {
            throw new ArgumentNullException("Category is null");
        }

        var category = _mapper.Map<Category>(dto);
        category.ImageUrl = await Coffee.UploadFile(dto.file!);

        var validate = _validator.Validate(category);
        if (!validate.IsValid)
        {
            throw new CarsShopException(validate.GetErrorMessages());
        }

        var categories = await _unitOfWork.Categories.GetAllAsync();
        if (category.IsExists(categories))
        {
            throw new CarsShopException("Category is already exists");
        }

        await _unitOfWork.Categories.AddAsync(category);
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id);

        if (category is null)
        {
            throw new NotFoundException("Category is not found");
        }

        await _unitOfWork.Categories.DeleteAsync(category);
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var categories = await _unitOfWork.Categories.GetAllAsync();
        return categories.Select(_mapper.Map<CategoryDto>).ToList();
    }

    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id);

        if (category is null)
        {
            throw new NotFoundException("Category is not found");
        }

        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<PagedModel<CategoryDto>> GetPagedAsync(int pageNumber, int pageSize)
    {
        var dtos = await GetAllAsync();
        return new PagedModel<CategoryDto>(dtos, pageNumber, pageSize);
    }

    public async Task UpdateAsync(UpdateCategoryDto dto)
    {
        if (dto is null)
        {
            throw new ArgumentNullException("Category is null");
        }

        var category = await _unitOfWork.Categories.GetByIdAsync(dto.Id);
        if (category is null)
        {
            throw new NotFoundException("Category is not found");
        }
        
        category.Name = dto.Name;
        category.ImageUrl = await Coffee.UploadFile(dto.file!);

        var validate = _validator.Validate(category);
        if (!validate.IsValid)
        {
            throw new CarsShopException(validate.GetErrorMessages());
        }

        var categories = await _unitOfWork.Categories.GetAllAsync();
        if (category.IsExists(categories))
        {
            throw new CarsShopException("Category is already exists");
        }

        await _unitOfWork.Categories.UpdateAsync(category);
    }
}