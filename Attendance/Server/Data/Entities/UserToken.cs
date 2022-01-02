using Microsoft.AspNetCore.Identity;

namespace Attendance.Server.Data.Entities
{
    public partial class UserToken : IdentityUserToken<int>
    {
        public int Id { get; set; }
    }
}