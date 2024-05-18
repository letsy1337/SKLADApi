namespace SKLADApi.Models
{
    public class Orders
    {
        public Guid Id { get; set; }
        public int Order_number { get; set; }
        public string Client_PIB { get; set; }
        public int Client_phone { get; set; }
        public DateTime Order_date { get; set; }
        public Guid Status_id { get; set; }
        public DateTime? Order_date_completed { get; set; }
        public Guid Delivery_point_id { get; set; }
    }
}
