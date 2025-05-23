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

        [HttpPost("CreateOrder")]
        public async Task<ActionResult<Order>> CreateOrder([FromBody]Order request)
        {
            var order = await _service.CreateOrder(request);
            return Ok(order);
        }
    }
}
