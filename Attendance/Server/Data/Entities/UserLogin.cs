using Microsoft.AspNetCore.Identity;

namespace Attendance.Server.Data.Entities;

public partial class UserLogin : IdentityUserLogin<int>
{
    public int Id { get; set; }
}