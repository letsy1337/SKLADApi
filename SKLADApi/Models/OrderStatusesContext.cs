using Microsoft.EntityFrameworkCore;

namespace SKLADApi.Models
{
    public class OrderStatusesContext : DbContext
    {
        public OrderStatusesContext(DbContextOptions<OrderStatusesContext> options)
                : base(options)
        {

        }

        public DbSet<OrderStatuses> OrderStatuses { get; set; } = null!;
    }
}
