namespace ProductAPI.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        //Map Relationship to Product
        public Product? Product { get; set; }

        public int UserId { get; set; }

        //Map Relationship to User
        public User? User { get; set; }
    }
}
