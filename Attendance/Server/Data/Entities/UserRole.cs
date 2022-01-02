using Microsoft.AspNetCore.Identity;

namespace Attendance.Server.Data.Entities;

public partial class UserRole : IdentityUserRole<int>
{
    public int Id { get; set; }
}