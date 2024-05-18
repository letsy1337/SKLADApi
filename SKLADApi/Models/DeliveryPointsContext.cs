using Microsoft.EntityFrameworkCore;

namespace SKLADApi.Models
{
        public class DeliveryPointsContext : DbContext
        {
            public DeliveryPointsContext(DbContextOptions<DeliveryPointsContext> options)
                    : base(options)
            {

            }

            public DbSet<DeliveryPoints> DeliveryPoints { get; set; } = null!;
        }
}

