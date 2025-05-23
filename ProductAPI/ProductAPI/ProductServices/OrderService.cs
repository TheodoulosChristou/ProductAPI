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
    }
}
