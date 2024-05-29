using Microsoft.EntityFrameworkCore;

namespace SKLADApi.Models
{
    public class SupportMessagesContext : DbContext
    {
        public SupportMessagesContext(DbContextOptions<SupportMessagesContext> options)
                : base(options)
        {

        }

        public DbSet<SupportMessages> SupportMessages { get; set; } = null!;
    }

}
