using CarsShop.BusinessLogic.DTOs.UserDTOs;

namespace CarsShop.Controllers;

public class AuthController(IAuthService authService)
    : Controller
{
    private readonly IAuthService _authService = authService;

    public IActionResult Login()
    {
        LoginDto dto = new();
        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        if (loginDto == null)
        {
            return View(loginDto);
        }

        var result = await _authService.LoginAsync(loginDto, Role.User);

        if (result.IsSuccess)
        {
            return RedirectToAction("Index", "Home");
        }

        return View(loginDto);
    }

    public IActionResult Register()
    {
        RegisterDto dto = new();
        return View(dto);
    }

    [HttpPost]
    public IActionResult Register(RegisterDto registerDto)
    {
        var result = _authService.CreateUser(registerDto);
        if (result.IsSuccess)
        {
            return RedirectToAction("Login");
        }
        else
        {
            registerDto.ErrorMessage = result.ErrorMessage;
            return View(registerDto);
        }
    }
}
