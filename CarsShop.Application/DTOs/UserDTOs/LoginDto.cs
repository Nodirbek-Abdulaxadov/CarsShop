namespace CarsShop.Application.DTOs.UserDTOs;

public class LoginDto
{
    public string TelNomer { get; set; } = "";
    public string Password { get; set; } = "";

    public bool RememberMe { get; set; }
    public string Error { get; set; } = "";
}