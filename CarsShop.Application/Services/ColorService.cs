
using System.Text.Json;

namespace CarsShop.Application.Services;

public class ColorService(IUnitOfWork unitOfWork, 
                          IMapper mapper,
                          IValidator<Color> validator)
    : IColorService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<Color> _validator = validator;

    public async Task CreateAsync(AddColorDto model)
    {
        if (model == null)
        {
            throw new CarsShopException("Model is null");
        }

        var color = _mapper.Map<Color>(model);
        var images = model.ImageUrls.Select(url => new Image { Url = url }).ToList();
        color.Images = images;

        var validationResult = await _validator.ValidateAsync(color);
        if (!validationResult.IsValid)
        {
            throw new CarsShopException(validationResult.ToString());
        }

        await _unitOfWork.Colors.AddAsync(color);
    }

    public async Task DeleteAsync(int id)
    {
        var color = await _unitOfWork.Colors.GetByIdAsync(id);
        if (color == null)
        {
            throw new NotFoundException("Color not found");
        }

        await _unitOfWork.Colors.DeleteAsync(color);
    }

    public async Task<List<ColorDto>> GetAllAsync()
    {
        var colors = await _unitOfWork.Colors.GetAllAsync();
        return colors.Select(_mapper.Map<ColorDto>).ToList();
    }

    public async Task<ColorDto> GetByIdAsync(int id)
    {
        var colors = await GetAllAsync();
        var color = colors.FirstOrDefault(x => x.Id == id);
        if (color == null)
        {
            throw new NotFoundException("Color not found");
        }

        return color;
    }

    public async Task<PagedModel<ColorDto>> GetPagedAsync(int pageNumber, int pageSize)
    {
        var colors = await GetAllAsync();
        var pagedModel = new PagedModel<ColorDto>(colors, pageNumber, pageSize);
        if (pageNumber > pagedModel.TotalPages && pagedModel.TotalPages != 0)
        {
            throw new NotFoundException("Colors not found");
        }

        return pagedModel;
    }

    public async Task UpdateAsync(UpdateColorDto model)
    {
        if (model == null)
        {
            throw new CarsShopException("Model is null");
        }

        var colors = await _unitOfWork.Colors.GetAllAsync();
        var color = colors.FirstOrDefault(x => x.Id == model.Id);
        if (color == null)
        {
            throw new NotFoundException("Color not found");
        }


        color.Name = model.Name;
        color.HexCode = model.HexCode;
        color.CarId = model.CarId;

        var imageUrls = color.Images.Select(x => x.Url).ToList();

        var ochirishimKerak = imageUrls.Except(model.ImageUrls).ToList();
        var qoshishimKerak = model.ImageUrls.Except(imageUrls).ToList();

        foreach (var url in ochirishimKerak)
        {
            var image = color.Images.FirstOrDefault(x => x.Url == url);
            color.Images.Remove(image!);
        }

        foreach (var url in qoshishimKerak)
        {
            color.Images.Add(new Image { Url = url });
        }

        var validationResult = await _validator.ValidateAsync(color);
        if (!validationResult.IsValid)
        {
            throw new CarsShopException(validationResult.ToString());
        }

        await _unitOfWork.Colors.UpdateAsync(color);
    }
}