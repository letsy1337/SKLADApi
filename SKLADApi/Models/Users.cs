namespace SKLADApi.Models
{
    public class Users
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Guid Type_id { get; set; }
        public Guid? Supplier_id { get; set; }
        public int? Phone { get; set; }
        public string? Address { get; set; }
        public string? Company { get; set; }
        public Guid? Image_id { get; set; }
    }
}
