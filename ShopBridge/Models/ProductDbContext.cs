using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ShopBridge.Models
{
    [ExcludeFromCodeCoverage]
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
