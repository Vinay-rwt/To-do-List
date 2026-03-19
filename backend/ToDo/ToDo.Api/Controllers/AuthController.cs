using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDo.Api.Data;
using ToDo.Api.DTOs;
using ToDo.Api.Models;

namespace ToDo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _config;

    public AuthController(ApplicationDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    // POST /api/auth/register
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        // Check if email already exists
        if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            return BadRequest("Email already in use.");

        // Check if username already exists
        if (await _context.Users.AnyAsync(u => u.UserName == dto.UserName))
            return BadRequest("Username already taken.");

        // Hash the password
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var user = new User
        {
            UserName = dto.UserName,
            Email = dto.Email,
            PasswordHash = passwordHash
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Registration successful." });
    }

    // POST /api/auth/login
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        // Find user by email
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
        if (user == null)
            return Unauthorized("Invalid email or password.");

        // Verify password hash
        if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return Unauthorized("Invalid email or password.");

        // Generate JWT
        var token = GenerateJwtToken(user);

        return Ok(new { token });
    }

    private string GenerateJwtToken(User user)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("username", user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                double.Parse(_config["Jwt:ExpiryInMinutes"]!)),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
