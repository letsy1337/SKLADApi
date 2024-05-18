using Microsoft.EntityFrameworkCore;

namespace SKLADApi.Models
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options)
                : base(options)
        {

        }

        public DbSet<Products> Products { get; set; } = null!;
    }
}
