using System.ComponentModel.DataAnnotations;

namespace Attendance.Shared.ViewModels;

public class LoginVM
{
    [Required(ErrorMessage = Constants.RequireMsg)]
    public string Email { get; set; }

    [Required(ErrorMessage = Constants.RequireMsg)]
    public string Password { get; set; }
}