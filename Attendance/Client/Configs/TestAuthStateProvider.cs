using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Attendance.Client.Configs;

public class TestAuthStateProvider : AuthenticationStateProvider
{
    public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, "mk"),
            new Claim(ClaimTypes.Role, "Admin")
        };
        //var anonymous = new ClaimsIdentity(claims, "a");
        var anonymous = new ClaimsIdentity();
        return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
    }
}