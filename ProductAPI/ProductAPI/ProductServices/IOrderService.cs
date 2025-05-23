using ProductAPI.Entities;

namespace ProductAPI.ProductServices
{
    public interface IOrderService
    {
        public Task<Order> CreateOrder(Order orderRequest);
    }
}
