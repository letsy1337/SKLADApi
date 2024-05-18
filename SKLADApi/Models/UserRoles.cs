namespace SKLADApi.Models
{
    public class UserRoles
    {
        public Guid Id { get; set; }
        public Guid User_id { get; set; }
        public DateTime Date_assigned { get; set; }
        public Guid Role_id { get; set; }
        public Guid Assigned_by { get; set; }

    }
}
