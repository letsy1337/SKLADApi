namespace SKLADApi.Models
{
    public class Reports
    {
        public Guid Id { get; set; }
        public Guid Report_type { get; set; }
        public DateTime Creation_date { get; set; }
        public string File { get; set; }
        public Guid Created_by { get; set; }
    }
}
