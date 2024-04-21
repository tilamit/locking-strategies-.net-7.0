using Microsoft.EntityFrameworkCore;
using OurLockingApp.Models;

namespace OurLockingApp.UserDbContext
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {

        }
        public DbSet<Users> users { get; set; }
    }
}
