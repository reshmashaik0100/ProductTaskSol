using Microsoft.EntityFrameworkCore;
using ProductTaskPro.Models;

namespace ProductTaskPro.Context
{
    public class ProductTaskDBContext : DbContext
    {
        public ProductTaskDBContext(DbContextOptions<ProductTaskDBContext> option) : base(option) 
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
