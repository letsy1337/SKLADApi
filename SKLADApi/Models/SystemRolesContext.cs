using Microsoft.EntityFrameworkCore;

namespace SKLADApi.Models
{
    public class SystemRolesContext : DbContext
    {
        public SystemRolesContext(DbContextOptions<SystemRolesContext> options)
               : base(options)
        {

        }

        public DbSet<SystemRoles> SystemRoles { get; set; } = null!;
    }
}
