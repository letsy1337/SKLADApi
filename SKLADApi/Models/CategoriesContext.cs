using Microsoft.EntityFrameworkCore;

namespace SKLADApi.Models
{
    public class CategoriesContext : DbContext
    {
        public CategoriesContext(DbContextOptions<CategoriesContext> options)
                : base(options)
        {

        }

        public DbSet<Categories> Categories { get; set; } = null!;
    }
}
