using Microsoft.EntityFrameworkCore;

namespace SKLADApi.Models
{
    public class WarehousesContext : DbContext
    {
        public WarehousesContext(DbContextOptions<WarehousesContext> options)
                : base(options)
        {

        }

        public DbSet<Warehouses> Warehouses { get; set; } = null!;
    }
}
