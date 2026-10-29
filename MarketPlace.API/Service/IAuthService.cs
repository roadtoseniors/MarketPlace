using MarketPlace.Entities;
using MarketPlace.Entities.Dtos;

namespace MarketPlace.API.Service;
public interface IAuthService
{
    Task<UserDto?> RegisterAsync(RegisterUserDto dto);
    Task<LoginResult?> LoginAsync(LoginUserDto dto);
}