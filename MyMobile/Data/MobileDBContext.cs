using Microsoft.EntityFrameworkCore;
using MyMobile.Models;

namespace MyMobile.Data
{
    public class MobileDBContext : DbContext
    {
        public MobileDBContext(DbContextOptions<MobileDBContext> options) : base(options) 
        {
        }
        public DbSet<MobileDetails>MobileDBContexts { get; set; }
    }
}
