using Microsoft.EntityFrameworkCore;

namespace SKLADApi.Models
{
    public class DeliveryStatusesContext : DbContext
    {
        public DeliveryStatusesContext(DbContextOptions<DeliveryStatusesContext> options)
                : base(options)
        {

        }

        public DbSet<DeliveryStatuses> DeliveryStatuses { get; set; } = null!;
    }
}
