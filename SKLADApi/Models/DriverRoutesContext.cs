using Microsoft.EntityFrameworkCore;

namespace SKLADApi.Models
{
    public class DriverRoutesContext : DbContext
    {
        public DriverRoutesContext(DbContextOptions<DriverRoutesContext> options)
                : base(options)
        {

        }

        public DbSet<DriverRoutes> DriverRoutes { get; set; } = null!;
    }
}
