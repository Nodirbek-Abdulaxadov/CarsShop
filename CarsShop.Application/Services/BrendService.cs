namespace CarsShop.Application.Services;

public class BrendService(IUnitOfWork unitOfWork,
                             IMapper mapper,
                             IValidator<Brend> validator)
    : IBrendService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<Brend> _validator = validator;

    public async Task CreateAsync(AddBrendDto dto)
    {
        if (dto is null)
        {
            throw new ArgumentNullException("Brend is null");
        }

        var brend = _mapper.Map<Brend>(dto);
        brend.ImageUrl = await Coffee.UploadFile(dto.file!);

        var validate = _validator.Validate(brend);
        if (!validate.IsValid)
        {
            throw new CarsShopException(validate.GetErrorMessages());
        }

        var categories = await _unitOfWork.Brends.GetAllAsync();
        if (brend.IsExists(categories))
        {
            throw new CarsShopException("Brend is already exists");
        }

        await _unitOfWork.Brends.AddAsync(brend);
    }

    public async Task DeleteAsync(int id)
    {
        var brend = await _unitOfWork.Brends.GetByIdAsync(id);

        if (brend is null)
        {
            throw new NotFoundException("Brend is not found");
        }

        await _unitOfWork.Brends.DeleteAsync(brend);
    }

    public async Task<List<BrendDto>> GetAllAsync()
    {
        var categories = await _unitOfWork.Brends.GetAllAsync();
        return categories.Select(_mapper.Map<BrendDto>).ToList();
    }

    public async Task<BrendDto> GetByIdAsync(int id)
    {
        var brend = await _unitOfWork.Brends.GetByIdAsync(id);

        if (brend is null)
        {
            throw new NotFoundException("Brend is not found");
        }

        return _mapper.Map<BrendDto>(brend);
    }

    public async Task<PagedModel<BrendDto>> GetPagedAsync(int pageNumber, int pageSize)
    {
        var dtos = await GetAllAsync();
        return new PagedModel<BrendDto>(dtos, pageNumber, pageSize);
    }

    public async Task UpdateAsync(UpdateBrendDto dto)
    {
        if (dto is null)
        {
            throw new ArgumentNullException("Brend is null");
        }

        var brend = await _unitOfWork.Brends.GetByIdAsync(dto.Id);
        if (brend is null)
        {
            throw new NotFoundException("Brend is not found");
        }
        
        brend.Name = dto.Name;
        brend.ImageUrl = await Coffee.UploadFile(dto.file!);

        var validate = _validator.Validate(brend);
        if (!validate.IsValid)
        {
            throw new CarsShopException(validate.GetErrorMessages());
        }

        var categories = await _unitOfWork.Brends.GetAllAsync();
        if (brend.IsExists(categories))
        {
            throw new CarsShopException("Brend is already exists");
        }

        await _unitOfWork.Brends.UpdateAsync(brend);
    }
}