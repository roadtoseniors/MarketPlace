using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using MarketPlace.Context;
using MarketPlace.Entities;
using MarketPlace.Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MarketPlace.API.Service;

public class AuthService : IAuthService
{
    private readonly MyDbContext _context;
    private readonly IConfiguration _config;

    public AuthService(MyDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public async Task<UserDto?> RegisterAsync(RegisterUserDto dto)
    {
        var login = dto.Login.Trim();
        if (await _context.Users.AnyAsync(u => u.Login == login))
            return null;

        var user = new User
        {
            Login = login,
            PasswordHash = HashPassword(dto.Password),
            Name = dto.Name,
            LastName = dto.LastName,
            RoleId = 1
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        await _context.Entry(user).Reference(u => u.Role).LoadAsync();

        return ToDto(user);
    }

    public async Task<LoginResult?> LoginAsync(LoginUserDto dto)
    {
        var login = dto.Login.Trim();
        var hash = HashPassword(dto.Password);

        var user = await _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Login == login && u.PasswordHash == hash);

        if (user is null)
            return null;

        return new LoginResult(ToDto(user), CreateToken(user));
    }

    private static string HashPassword(string password) =>
        Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(password))).ToLowerInvariant();

    private string CreateToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Login),
            new Claim(ClaimTypes.Role, user.Role.Name)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(12),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static UserDto ToDto(User u) =>
        new(u.Id, u.Login, u.Name, u.LastName, u.RoleId, u.Role.Name);
}