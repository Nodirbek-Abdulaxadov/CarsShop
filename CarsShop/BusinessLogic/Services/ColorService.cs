using CarsShop.BusinessLogic.DTOs.ColorDTOs;

namespace CarsShop.BusinessLogic.Services;

public class ColorService(IUnitOfWork unitOfWork,
                          IFileService fileService)
    : IColorService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IFileService _fileService = fileService;

    public void Create(AddColorDto carDto)
    {
        if (carDto == null)
        {
            throw new ArgumentNullException(nameof(carDto));
        }

        var images = _fileService.UploadMultipleImageWithoutBg(carDto.Files);

        Color newColor = new()
        {
            Name = carDto.Name,
            HexCode = carDto.HexCode,
            CarId = carDto.CarId,
            Images = images.Select(i => new Image() { Url = i }).ToList(),
            Car = null
        };

        _unitOfWork.Colors.Add(newColor);
    }

    public void Delete(int id)
    {
        var color = _unitOfWork.Colors.GetById(id);
        if (color == null)
        {
            throw new ArgumentNullException(nameof(color));
        }

        _fileService.DeleteMultiple(color.Images.Select(i => i.Url).ToList());
        _unitOfWork.Colors.Delete(color.Id);
    }

    public void DeleteImage(int id)
    {
        var image = _unitOfWork.Images.GetById(id);
        _fileService.DeleteImage(image.Url);
        _unitOfWork.Images.Delete(image.Id);
    }

    public List<ColorDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public ColorDto GetById(int id)
    {
        var color = _unitOfWork.Colors.GetByIdWithImages(id);
        return (ColorDto)color;
    }

    public List<string> GetImages(int id)
    {
        var images = _unitOfWork.Images.GetAll();
        return images.Where(i => i.ColorId == id)
                                .Select(i => i.Url)
                                .ToList();
    }

    public void Update(UpdateColorDto carDto)
    {
        if (carDto == null)
        {
            throw new ArgumentNullException(nameof(carDto));
        }


        var color = _unitOfWork.Colors.GetByIdWithImages(carDto.Id);
        if (carDto.Files.Any())
        {
            var images = _fileService.UploadMultipleImageWithoutBg(carDto.Files);

            color.Images.AddRange(images.Select(i => new Image() { Url = i }));
        }

        color.Name = carDto.Name;
        color.HexCode = carDto.HexCode;
        color.CarId = carDto.CarId;
        color.Car = null;
        

        _unitOfWork.Colors.Update(color);
    }
}