using System.ComponentModel.DataAnnotations.Schema;

namespace SKLADApi.Models
{
    public class SupportMessages
    {
        public Guid Id { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Message_number { get; set; }
        
        public string Content { get; set; }
        public Guid Type_id { get; set; }
        public bool Is_read { get; set; }
        public Guid Created_by { get; set; }
        public DateTime Created_date { get; set;}
    }
}
