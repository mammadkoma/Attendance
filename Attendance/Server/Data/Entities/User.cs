using Microsoft.AspNetCore.Identity;

namespace Attendance.Server.Data.Entities;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }


    //[NotMapped]
    //public override string UserName { get; set; }
    //[NotMapped]
    //public override string NormalizedUserName { get; set; }
}