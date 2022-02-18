using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace Attendance.Client.Configs;

public class AuthStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationState _authenticationState;
    public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
        _authenticationState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _localStorage.GetItemAsync<string>("token");
        if (string.IsNullOrWhiteSpace(token))
            return _authenticationState;
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromToken(token), "jwtAuthType")));
    }

    public void NotifyLogin(string token)
    {
        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromToken(token), "jwtAuthType"));
        var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
        NotifyAuthenticationStateChanged(authState);
    }

    public void NotifyLogout()
    {
        var authState = Task.FromResult(_authenticationState);
        NotifyAuthenticationStateChanged(authState);
    }

    public static IEnumerable<Claim> ParseClaimsFromToken(string token)
    {
        var claims = new List<Claim>();
        var payload = token.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        ExtractRolesFromToken(claims, keyValuePairs);
        claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
        return claims;
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }

    private static void ExtractRolesFromToken(List<Claim> claims, Dictionary<string, object> keyValuePairs)
    {
        keyValuePairs.TryGetValue("roles", out object roles);
        if (roles != null)
        {
            var parsedRoles = roles.ToString().Trim().TrimStart('[').TrimEnd(']').Split(',');
            if (parsedRoles.Length > 1)
            {
                foreach (var parsedRole in parsedRoles)
                    claims.Add(new Claim("roles", parsedRole.Trim('"')));
            }
            else
                claims.Add(new Claim("roles", parsedRoles[0]));
            keyValuePairs.Remove("roles");
        }
    }
}