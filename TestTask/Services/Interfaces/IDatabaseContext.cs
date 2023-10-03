using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Services.Interfaces
{
    public interface IDatabaseContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
