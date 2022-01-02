using Microsoft.AspNetCore.Identity;

namespace Attendance.Server.Data.Entities;

public partial class UserClaim : IdentityUserClaim<int>
{
    public int Id { get; set; }
}