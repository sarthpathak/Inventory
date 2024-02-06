namespace Inventory.Model
{
    public class PostProduct
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Measurement { get; set; }
        public Guid CategoryId { get; set; }
    }
}
