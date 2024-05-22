using Microsoft.EntityFrameworkCore;

namespace SKLADApi.Models
{
    public class SuppliersContext : DbContext
    {
        public SuppliersContext(DbContextOptions<SuppliersContext> options)
                : base(options)
        {

        }

        public DbSet<Suppliers> Suppliers { get; set; } = null!;
    }
}
