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




        public Task<User> GetUser()
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
