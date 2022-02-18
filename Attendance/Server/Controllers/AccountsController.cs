using Attendance.Server.Data.Entities;
using Attendance.Shared.Dtos;
using Attendance.Shared.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Attendance.Server.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IConfigurationSection _jwtSettings;

    public AccountsController(UserManager<User> userManager, IConfiguration configuration
        )
    {
        _userManager = userManager;
        _configuration = configuration;
        _jwtSettings = _configuration.GetSection("JwtSettings");
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM model)
    {
        var user = new User
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            UserName = model.Email,
            Email = model.Email
        };
        await _userManager.CreateAsync(user, model.Password);
        await _userManager.AddToRoleAsync(user, "user");
        return StatusCode(201);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM model)
    {
        var user = await _userManager.FindByNameAsync(model.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            return Unauthorized("ایمیل یا پسورد اشتباه است.");

        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaimsAsync(user);
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return Ok(new LoginDto { Token = token, FullName = user.FirstName + " " + user.LastName });
    }



    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_jwtSettings["securityKey"]);
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaimsAsync(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim("UserName", user.Email),
            new Claim("FullName", user.FirstName+" "+user.LastName),
        };
        var roles = await _userManager.GetRolesAsync(user);
        foreach (var role in roles)
            claims.Add(new Claim("roles", role));

        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims
        )
    {
        var tokenOptions = new JwtSecurityToken(
            issuer: _jwtSettings["validIssuer"],
            audience: _jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings["expiryInMinutes"])),
            signingCredentials: signingCredentials);

        return tokenOptions;
    }
}