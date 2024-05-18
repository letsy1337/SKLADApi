using Microsoft.EntityFrameworkCore;

namespace SKLADApi.Models
{
    public class OrdersContext : DbContext
    {
        public OrdersContext(DbContextOptions<OrdersContext> options)
                : base(options)
        {

        }

        public DbSet<Orders> Orders { get; set; } = null!;
    }
}
