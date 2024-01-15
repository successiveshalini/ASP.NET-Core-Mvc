using JsonResultFormate.Models;
using Microsoft.EntityFrameworkCore;

namespace JsonResultFormate.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
        public DbSet<ProductDetails> productDetails  { get; set; }
    }
}
