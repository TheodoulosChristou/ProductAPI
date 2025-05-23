using System.Text.Json.Serialization;

namespace ProductAPI.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        //Map to Category Entity Relationship
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        [JsonIgnore]
        public List<Order>? Orders { get; set; }
    }
}
