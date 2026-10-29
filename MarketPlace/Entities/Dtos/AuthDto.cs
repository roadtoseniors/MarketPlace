namespace MarketPlace.Entities.Dtos;

public record RegisterUserDto(string Login, string Password, string ConfirmPassword, string? Name, string? LastName);
public record LoginUserDto(string Login, string Password);

public record UserDto(int Id, string Login, string? Name, string? LastName, int RoleId, string RoleName);
public record LoginResult(UserDto User, string Token);