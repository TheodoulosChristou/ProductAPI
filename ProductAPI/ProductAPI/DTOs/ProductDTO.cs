namespace ProductAPI.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public int? CategoryId { get; set; }
    }
}
