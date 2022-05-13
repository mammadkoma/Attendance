namespace Attendance.Shared.Dtos;

public class LoginDto
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public string FullName { get; set; }
    public string ErrorMessage { get; set; }
}