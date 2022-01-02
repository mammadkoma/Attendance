using Microsoft.AspNetCore.Identity;

namespace Attendance.Server.Data.Entities;

public partial class RoleClaim : IdentityRoleClaim<int>
{
    public int Id { get; set; }
}