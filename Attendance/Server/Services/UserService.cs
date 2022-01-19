using Attendance.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Server.Data;

namespace Attendance.Server.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
    }

    public class UserService : IUserService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<User>> GetAll()
        {
            return await _db.Users.ToListAsync();
        }
    }
}