namespace CarsShop.Application.Services;

public class CarService (IUnitOfWork unitOfWork, 
                         IMapper mapper, 
                         IValidator<Car> validator)
        : ICarService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<Car> _validator = validator;

    public async Task CreateAsync(AddCarDto model)
    {
        if (model is null)
        {
            throw new CarsShopException("Car model is null");
        }

        var car = _mapper.Map<Car>(model);
        var validationResult = _validator.Validate(car);
        if (!validationResult.IsValid)
        {
            throw new CarsShopException(validationResult.GetErrorMessages());
        }

        await _unitOfWork.Cars.AddAsync(car);
    }

    public async Task DeleteAsync(int id)
    {
        var car = await _unitOfWork.Cars.GetByIdAsync(id);
        if (car is null)
        {
            throw new NotFoundException("Car is not found");
        }

        await _unitOfWork.Cars.DeleteAsync(car);
    }

    public async Task<List<CarDto>> GetAllAsync()
    {
        var cars = await _unitOfWork.Cars.GetAllAsync();
        return cars.Select(_mapper.Map<CarDto>).ToList();
    }

    public async Task<CarDto> GetByIdAsync(int id)
    {
        var car = await _unitOfWork.Cars.GetByIdAsync(id);
        if (car is null)
        {
            throw new NotFoundException("Car is not found");
        }

        return _mapper.Map<CarDto>(car);
    }

    public async Task<PagedModel<CarDto>> GetPagedAsync(int pageNumber, int pageSize)
    {
        var cars = await GetAllAsync();
        var pagedModel = new PagedModel<CarDto>(cars, pageNumber, pageSize);

        if (pageNumber > pagedModel.TotalPages && pagedModel.TotalPages != 0)
        {
            throw new NotFoundException("Page is not found");
        }

        return pagedModel;
    }

    public async Task UpdateAsync(UpdateCarDto model)
    {
        var car = await _unitOfWork.Cars.GetByIdAsync(model.Id);
        if (car is null)
        {
            throw new NotFoundException("Car is not found");
        }

        car.Name = model.Name;
        car.Price = model.Price;
        car.BrendId = model.BrendId;
        car.CategoryId = model.CategoryId;
        car.Description = model.Description;

        var validationResult = _validator.Validate(car);
        if (!validationResult.IsValid)
        {
            throw new CarsShopException(validationResult.GetErrorMessages());
        }

        await _unitOfWork.Cars.UpdateAsync(car);
    }
}