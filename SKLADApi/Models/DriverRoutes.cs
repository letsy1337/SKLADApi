namespace SKLADApi.Models
{
    public class DriverRoutes
    {
        public Guid Id { get; set; }
        public string Route { get; set; }
        public Guid Driver_id { get; set; }
        public DateTime Date_created { get; set; }
        public bool Is_archived { get; set; }
        public string? Order_numbers { get; set; }
    }
}
