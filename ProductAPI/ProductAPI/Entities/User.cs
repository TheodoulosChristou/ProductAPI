using System.Text.Json.Serialization;

namespace ProductAPI.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [JsonIgnore]
        public List<Order>? Orders { get; set; }

    }
}
