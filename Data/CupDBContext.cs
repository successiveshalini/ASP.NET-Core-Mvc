using Microsoft.EntityFrameworkCore;
using MyCup.Models;

namespace MyCup.Data
{
    public class CupDBContext :DbContext
    {
        public CupDBContext(DbContextOptions<CupDBContext> options) : base(options)
        {
        }
        public DbSet<CupDetails>CupDetails { get; set; }
    }
}
