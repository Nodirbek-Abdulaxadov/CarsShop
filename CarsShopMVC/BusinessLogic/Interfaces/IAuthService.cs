using CarsShopMVC.BusinessLogic.DTOs.UserDTOs;

namespace CarsShopMVC.BusinessLogic.Interfaces;

public interface IAuthService
{
    Task<AuthResult> LoginAsync(LoginDto loginDto, Role kim);
    AuthResult CreateUser(RegisterDto registerDto);
    bool IsLoggedIn();
    void Logout(Role kim);
    string GetFullName(Role kim);
    string GetPhoneNumber(Role kim);
}