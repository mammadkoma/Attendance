using System.ComponentModel.DataAnnotations;

namespace Attendance.Shared.ViewModels;

public class RegisterVM
{
    [Display(Name = "نام")]
    [Required(ErrorMessage = Constants.RequireMsg)]
    [StringLength(maximumLength: 20, ErrorMessage = Constants.MaxLengthMsg)]
    public string FirstName { get; set; }

    [Display(Name = "نام خانوادگی")]
    [Required(ErrorMessage = Constants.RequireMsg)]
    [StringLength(maximumLength: 20, ErrorMessage = Constants.MaxLengthMsg)]
    public string LastName { get; set; }

    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = Constants.RequireMsg)]
    [StringLength(maximumLength: 20, ErrorMessage = Constants.MaxLengthMsg)]
    [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = Constants.RegularExpressionMsg)]
    public string Email { get; set; }

    [Display(Name = "پسورد")]
    [Required(ErrorMessage = Constants.RequireMsg)]
    [StringLength(maximumLength: 20, ErrorMessage = Constants.MaxLengthMsg)]
    public string Password { get; set; }
}