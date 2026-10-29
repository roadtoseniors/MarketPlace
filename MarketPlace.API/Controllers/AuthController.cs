using MarketPlace.API.Service;
using MarketPlace.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;

    public AuthController(IAuthService auth)
    {
        _auth = auth;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Login) || string.IsNullOrWhiteSpace(dto.Password))
            return BadRequest("Логин и пароль обязательны");
        if (dto.Password != dto.ConfirmPassword)
            return BadRequest("Пароли не совпадают");

        var user = await _auth.RegisterAsync(dto);
        return user is null ? Conflict("Такой логин уже занят") : Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto dto)
    {
        var result = await _auth.LoginAsync(dto);
        return result is null ? Unauthorized("Неверный логин или пароль") : Ok(result);
    }
}