using CarsShop.BusinessLogic.DTOs.UserDTOs;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace CarsShop.BusinessLogic.Services;

public class AuthService(IUnitOfWork unitOfWork,
                         IHttpContextAccessor httpContextAccessor)
    : IAuthService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public AuthResult CreateUser(RegisterDto registerDto)
    {
        if (registerDto == null)
        {
            return new()
            {
                IsSuccess = false,
                ErrorMessage = "LoginDto is null"
            };
        }

        var user = _unitOfWork.Users
                              .GetAll()
                              .FirstOrDefault(u => u.TelNomer == registerDto.TelNomer);

        if (user != null)
        {
            return new()
            {
                IsSuccess = false,
                ErrorMessage = "Phone Number already exists"
            };
        }

        if (registerDto.Password != registerDto.ConfirmPassword)
        {
            return new()
            {
                IsSuccess = false,
                ErrorMessage = "Passwords do not match"
            };
        }

        var newUser = new User
        {
            FISH = registerDto.FullName!,
            TelNomer = registerDto.TelNomer!,
            Password = registerDto.Password!,
            Address = registerDto.Address!,
            Role = Role.User
        };

        _unitOfWork.Users.Add(newUser);

        return new()
        {
            IsSuccess = true
        };
    }

    public bool IsLoggedIn()
    {
        var res = _httpContextAccessor.HttpContext!.AuthenticateAsync(Role.User.ToString());
        return res.Result.Succeeded;
    }

    public async Task<AuthResult> LoginAsync(LoginDto loginDto, Role kim)
    {
        if (loginDto == null)
        {
            return new()
            {
                IsSuccess = false,
                ErrorMessage = "LoginDto is null"
            };
        }

        var user = _unitOfWork.Users
                              .GetAll()
                              .FirstOrDefault(u => u.TelNomer == loginDto.TelNomer);

        if (user == null)
        {
            return new()
            {
                IsSuccess = false,
                ErrorMessage = "User not found"
            };
        }

        if (user.Password != loginDto.Password)
        {
            return new()
            {
                IsSuccess = false,
                ErrorMessage = "Password is incorrect"
            };
        }

        if (user.Role != kim && kim != Role.User)
        {
            return new()
            {
                IsSuccess = false,
                ErrorMessage = "You don't have a permission for this page"
            };
        }

        //write user data to cookies
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.FISH),
            new Claim(ClaimTypes.MobilePhone, user.TelNomer),
            new Claim(ClaimTypes.Role, kim.ToString())
        };

        var identity = new ClaimsIdentity(claims, kim.ToString());
        var principal = new ClaimsPrincipal(identity);

        if (loginDto.RememberMe)
        {
            await _httpContextAccessor.HttpContext!.SignInAsync(kim.ToString(), principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddDays(1)
                });
        }
        else
        {
            await _httpContextAccessor.HttpContext!.SignInAsync(kim.ToString(), principal);
        }

        return new()
        {
            IsSuccess = true
        };
    }

    public async void Logout(Role kim)
    {
        await _httpContextAccessor.HttpContext!.SignOutAsync(kim.ToString());
    }
}