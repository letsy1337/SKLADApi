using Microsoft.EntityFrameworkCore;

namespace SKLADApi.Models
{
    public class ReportTypesContext : DbContext
    {
        public ReportTypesContext(DbContextOptions<ReportTypesContext> options)
               : base(options)
        {

        }

        public DbSet<ReportTypes> ReportTypes { get; set; } = null!;
    }
}
