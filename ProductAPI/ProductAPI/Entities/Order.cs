namespace ProductAPI.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }

        public Product? Product { get; set; }

        public User? User { get; set; }  
    }
}
