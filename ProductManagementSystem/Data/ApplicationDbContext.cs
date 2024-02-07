using EcommerceManagementProject.Models.Domain;
using EcommerceManagementProject.Models.Dto;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceManagementProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserModel>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ProductModel> products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }

        public DbSet<CartsModel> Carts { get; set; }

        public DbSet<FavModel> Favorites { get; set; }


    }
}
