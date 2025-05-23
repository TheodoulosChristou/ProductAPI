using ProductAPI.Entities;

namespace ProductAPI.ProductServices
{
    public interface IOrderService
    {
        public Task<List<Order>> GetAllOrders();
        public Task<Order> CreateOrder(Order orderRequest);

        public Task<BaseCommandResponse> DeleteOrder(Order orderRequest);
    }
}
