using System.ComponentModel.DataAnnotations;

namespace Attendance.Shared.ViewModels;

public class LoginVM
{
    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = Constants.RequireMsg)]
    public string Email { get; set; }

    [Display(Name = "پسورد")]
    [Required(ErrorMessage = Constants.RequireMsg)]
    public string Password { get; set; }
}