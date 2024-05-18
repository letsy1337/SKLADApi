using Microsoft.EntityFrameworkCore;

namespace SKLADApi.Models
{
    public class UserRolesContext : DbContext
    {
        public UserRolesContext(DbContextOptions<UserRolesContext> options)
                : base(options)
        {

        }

        public DbSet<UserRoles> UserRoles { get; set; } = null!;
    }
}
