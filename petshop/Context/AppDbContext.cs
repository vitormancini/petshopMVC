using Microsoft.EntityFrameworkCore;
using petshop.Models;

namespace petshop.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Category> Categories {  get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
    }
}
