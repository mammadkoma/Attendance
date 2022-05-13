using Microsoft.AspNetCore.Identity;

namespace Attendance.Server.Data.Entities;

public partial class UserClaim : IdentityUserClaim<int>
{
    override public int Id { get; set; }
}