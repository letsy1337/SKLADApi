using Microsoft.EntityFrameworkCore;

namespace SKLADApi.Models
{
    public class ImagesContext : DbContext
    {
        public ImagesContext(DbContextOptions<ImagesContext> options)
                : base(options)
        {

        }

        public DbSet<Images> Images { get; set; } = null!;
    }
}
