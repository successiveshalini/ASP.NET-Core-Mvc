using Microsoft.EntityFrameworkCore;
using MyWatch.Models;

namespace MyWatch.Data
{
    public class WatchDBContext:DbContext
    {
        public WatchDBContext(DbContextOptions<WatchDBContext> options) : base(options)
        {
        }
        public DbSet<WatchDetails> WatchDBContexts { get; set; }
    }
}
