using System.Security.Policy;

namespace SKLADApi.Models
{
    public class DriverDelivers
    {
        public Guid Id { get; set; }
        public Guid Driver_id { get; set; }
        public Guid Order_id { get; set; }
        public Guid Status_id { get; set; }
        public decimal Total_cost { get; set; }
        public Guid Deliver_to { get; set; }
    }
}
