using AutoMapper;

namespace CarsShop.BusinessLogic.Services;

public class BrendService(IUnitOfWork unitOfWork,
                          IFileService fileService,
                          IMapper mapper)
    : IBrendService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IFileService _fileService = fileService;
    private readonly IMapper _mapper = mapper;

    public void Create(AddBrendDto brendDto)
    {
        if (brendDto == null)
        {
            throw new CustomException("", "BrendDto was null");
        }

        if (string.IsNullOrEmpty(brendDto.Name))
        {
            throw new CustomException("Name", "Brend name is required");
        }

        if (brendDto.Name.Length < 3 || brendDto.Name.Length > 30)
        {
            throw new CustomException("Name", "Brend name must be between 3 and 30 characters");
        }

        if (brendDto.file == null)
        {
            throw new CustomException("file", "Brend image is required");
        }

        Brend brend = new()
        {
            Name = brendDto.Name,
            ImageUrl = _fileService.UploadImage(brendDto.file)
        };

        _unitOfWork.Brends.Add(brend);
    }

    public void Delete(int id)
    {
        var brend = _unitOfWork.Brends.GetById(id);

        if (brend == null)
        {
            throw new CustomException("", "Brend not found");
        }
        _fileService.DeleteImage(brend.ImageUrl);
        _unitOfWork.Brends.Delete(brend.Id);
    }

    public List<BrendDto> GetAll()
    {
        var categories = _unitOfWork.Brends.GetAll();
        var list = categories.Select(_mapper.Map<BrendDto>)
                             .ToList();

        return list;
    }

    public BrendDto GetById(int id)
    {
        var brend = _unitOfWork.Brends.GetById(id);

        if (brend == null)
        {
            throw new CustomException("", "Brend not found");
        }

        var dto = new BrendDto()
        {
            Id = brend.Id,
            Name = brend.Name,
            ImagePath = brend.ImageUrl
        };

        return dto;
    }

    public void Update(UpdateBrendDto brendDto)
    {
        var brend = _unitOfWork.Brends.GetById(brendDto.Id);

        if (brend == null)
        {
            throw new CustomException("", "Brend not found");
        }

        if (string.IsNullOrEmpty(brendDto.Name))
        {
            throw new CustomException("", "Brend name is required");
        }

        if (brendDto.Name.Length < 3 || brendDto.Name.Length > 30)
        {
            throw new CustomException("", "Brend name must be between 3 and 30 characters");
        }

        if (brendDto.file != null)
        {
            _fileService.DeleteImage(brend.ImageUrl);
            brendDto.ImagePath = _fileService.UploadImage(brendDto.file);
        }

        brend.Name = brendDto.Name;
        brend.ImageUrl = brendDto.ImagePath;

        _unitOfWork.Brends.Update(brend);
    }
}