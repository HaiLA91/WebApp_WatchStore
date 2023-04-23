namespace WebApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public short CategoryId { get; set; }
        public short BrandId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SaleOfPrice { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public byte IsPopular { get; set; }

    }
}
