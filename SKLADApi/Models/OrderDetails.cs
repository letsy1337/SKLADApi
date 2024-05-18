namespace SKLADApi.Models
{
    public class OrderDetails
    {
        public Guid Id { get; set; }
        public Guid Order_id { get; set; }
        public Guid Product_id { get; set; }
        public int? Quantity { get; set; }
    }
}