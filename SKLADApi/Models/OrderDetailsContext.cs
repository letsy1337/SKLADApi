using Microsoft.EntityFrameworkCore;

namespace SKLADApi.Models
{
    public class OrderDetailsContext : DbContext
    {
        public OrderDetailsContext(DbContextOptions<OrderDetailsContext> options)
               : base(options)
        {

        }

        public DbSet<OrderDetails> OrderDetails { get; set; } = null!;
    }
}
