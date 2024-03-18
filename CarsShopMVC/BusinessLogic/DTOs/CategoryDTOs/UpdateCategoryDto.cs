namespace CarsShopMVC.BusinessLogic.DTOs.CategoryDTOs;

public class UpdateCategoryDto : CategoryDto
{
    public IFormFile? file { get; set; }
}