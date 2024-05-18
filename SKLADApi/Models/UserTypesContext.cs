using Microsoft.EntityFrameworkCore;

namespace SKLADApi.Models
{
    public class UserTypesContext : DbContext
    {
        public UserTypesContext(DbContextOptions<UserTypesContext> options)
                : base(options)
        {

        }

        public DbSet<UserTypes> UserTypes { get; set; } = null!;
    }
}
