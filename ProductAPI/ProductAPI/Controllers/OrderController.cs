using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Entities;
using ProductAPI.ProductServices;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet("GetAllOrders")]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            var order = await _service.GetAllOrders();
            return Ok(order);
        }

        [HttpPost("CreateOrder")]
        public async Task<ActionResult<Order>> CreateOrder([FromBody]Order request)
        {
            var order = await _service.CreateOrder(request);
            return Ok(order);
        }

        [HttpDelete("DeleteOrder")]
        public async Task<ActionResult<BaseCommandResponse>> DeleteOrder([FromBody] Order request)
        {
            var order = await _service.DeleteOrder(request);
            return Ok(order);
        }
    }
}
