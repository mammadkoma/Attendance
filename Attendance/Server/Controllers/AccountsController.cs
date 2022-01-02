using Attendance.Server.Data.Entities;
using Attendance.Shared.Dtos;
using Attendance.Shared.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Attendance.Server.Controllers;

[Route("api/accounts")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly UserManager<User> _userManager;

    public AccountsController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(RegisterVM model)
    {
        var user = new User { FirstName = model.FirstName, LastName = model.LastName, UserName = model.Email, Email = model.Email };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            return BadRequest(new ResultDto { Message = string.Join(" , ", result.Errors.Select(e => e.Description)) });
        }

        return StatusCode(201);
    }
}