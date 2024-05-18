namespace SKLADApi.Models
{
    public class Products
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public Guid Category_id { get; set; }
        public Guid Warehouse_id { get; set; }
        public decimal Price { get; set; }
        public int? Quantity { get; set; }
        public Guid? Image_id { get; set; }
    }
}