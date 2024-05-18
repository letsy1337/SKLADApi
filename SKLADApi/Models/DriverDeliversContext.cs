using Microsoft.EntityFrameworkCore;

namespace SKLADApi.Models
{
    public class DriverDeliversContext : DbContext
    {
        public DriverDeliversContext(DbContextOptions<DriverDeliversContext> options)
                : base(options)
        {

        }

        public DbSet<DriverDelivers> DriverDelivers { get; set; } = null!;
    }
}
