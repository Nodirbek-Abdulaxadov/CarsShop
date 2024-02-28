using CarsShop.BusinessLogic.DTOs.UserDTOs;

namespace CarsShop.BusinessLogic.Interfaces;

public interface IAuthService
{
    Task<AuthResult> LoginAsync(LoginDto loginDto, Role kim);
    AuthResult CreateUser(RegisterDto registerDto);
    bool IsLoggedIn();
    void Logout(Role kim);
}