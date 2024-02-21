
namespace CarsShop.BusinessLogic.Services;

public class FileService(IWebHostEnvironment webHostEnvironment)
    : IFileService
{
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

    public void DeleteImage(string fileName)
    {
        var wwwrootFolder = _webHostEnvironment.WebRootPath;
        var filePath = Path.Combine(wwwrootFolder, fileName.Replace("~/", ""));

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    public string UploadImage(IFormFile file)
    {
        var wwwrootFolder = _webHostEnvironment.WebRootPath;
        var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        var filePath = Path.Combine(wwwrootFolder + "/images/", uniqueFileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(fileStream);
        }

        return $"~/images/{uniqueFileName}";
    }
}
