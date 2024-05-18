namespace SKLADApi.Models
{
    public class SupportMessages
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid Role_id { get; set; }
        public bool Is_read { get; set; }
        public Guid Created_by { get; set; }
    }
}
