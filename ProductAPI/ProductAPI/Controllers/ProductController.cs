using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.DTOs;
using ProductAPI.Entities;
using ProductAPI.ProductServices;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<List<ProductDTO>>> GetAllProducts()
        {
            var list = await _service.GetAllProducts();
            return Ok(list);
        }

        [HttpGet("GetProductByProductId")]
        public async Task<ActionResult<ProductDTO>> GetProductByProductId(int productId)
        {
            var list = await _service.GetProductByProductId(productId);
            return Ok(list);
        }


        [HttpPost("CreateProduct")]
        public async Task<ActionResult<ProductDTO>> CreateProduct([FromBody]ProductDTO productRequest)
        {
            var response = await _service.CreateProduct(productRequest);
            return Ok(response);
        }

        [HttpPost("SearchProducts")]
        public async Task<ActionResult<List<ProductDTOSearchResults>>> SearchProducts([FromBody] ProductCriteriaDTO criteria)
        {
            var response = await _service.SearchProductByCriteria(criteria);
            return Ok(response);
        }

        [HttpPut("UpdateProduct")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct([FromBody] ProductDTO productRequest)
        {
            var response = await _service.UpdateProduct(productRequest);
            return Ok(response);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<ActionResult<BaseCommandResponse>> DeleteProduct([FromBody] ProductDTO productRequest)
        {
            var response = await _service.DeleteProduct(productRequest);
            return Ok(response);
        }
    }
}
