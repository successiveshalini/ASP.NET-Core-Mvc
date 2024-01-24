using Microsoft.EntityFrameworkCore;
using NewProject.Controllers;
using NewProject.Models;

namespace NewProject.Data
{
    public class UserDBContext:DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }
        public DbSet<User>User { get; set; }
    }
}
