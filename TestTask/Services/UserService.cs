using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class UserService : IUserService
    {
        private readonly IDatabaseContext _dbContext;
        public UserService(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<User> GetUser()
        {
            var user = await _dbContext.Users
               .Where(u => u.Id == _dbContext.Orders
               .GroupBy(o => o.UserId)
                   .Select(m => new
                   {
                       Id = m.Key,
                       Count = m.Count()
                   })
                   .OrderByDescending(k => k.Count)
                   .First().Id)
               .FirstAsync();

            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _dbContext.Users
               .Where(u => u.Status == UserStatus.Inactive).ToListAsync();

            return users;
        }
    }
}
