using Microsoft.EntityFrameworkCore;
using ProductAPI.Entities;

namespace ProductAPI.ProductServices
{
    public class OrderService : IOrderService
    {
        private ProjectDbContext.ProjectDbContext _dbContext;

        public OrderService(ProjectDbContext.ProjectDbContext dbContext)
        {
             _dbContext = dbContext;
        }
        public async Task<Order> CreateOrder(Order orderRequest)
        {
            try
            {
                _dbContext.Order.Add(orderRequest);
                await _dbContext.SaveChangesAsync();
                return orderRequest;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseCommandResponse> DeleteOrder(Order orderRequest)
        {
            try
            {
                if(orderRequest == null)
                {
                    throw new Exception("Order Object is empty");
                } else
                {
                    BaseCommandResponse response = new BaseCommandResponse();
                    _dbContext.Order.Remove(orderRequest);
                    await _dbContext.SaveChangesAsync();

                    response.Id = orderRequest.OrderId;
                    response.Message = "Order object has been deleted successfully";
                    response.Entity = "Order";

                    return response;
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Order>> GetAllOrders()
        {
            try
            {
                var orders = _dbContext.Order.Include(x => x.Product).Include(x => x.User).ToList();
                return orders;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
