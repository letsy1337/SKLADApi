using Microsoft.EntityFrameworkCore;

namespace SKLADApi.Models
{
    public class ReportsContext : DbContext
    {
        public ReportsContext(DbContextOptions<ReportsContext> options)
                : base(options)
        {

        }

        public DbSet<Reports> Reports { get; set; } = null!;
    }
}
