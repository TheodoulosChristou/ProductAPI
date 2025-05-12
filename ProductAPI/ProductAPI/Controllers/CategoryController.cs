using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.DTOs;
using ProductAPI.Entities;
using ProductAPI.ProductServices;
using System.ComponentModel;
using System.Net;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
             _service = service;
        }

        [HttpGet("GetAllCategories")]
        public async Task<ActionResult<List<CategoryDTO>>> GetAllCategories()
        {
            var res = await _service.getAllCategories();
            return Ok(res);
        }

        [HttpGet("getCategoryByCategoryId")]
        public async Task<ActionResult<CategoryDTO>> getCategoryByCategoryId(int id)
        {
            var res = await _service.getCategoryByCategoryId(id);
            return Ok(res);
        }

        [HttpPost("CreateCategory")]
        public async Task<ActionResult<CategoryDTO>> CreateCategory([FromBody]CategoryDTO request)
        {
            var res = await _service.CreateCategory(request);
            return Ok(res);
        }

        [HttpPut("UpdateCategory")]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory([FromBody] CategoryDTO request)
        {
            var res = await _service.UpdateCategory(request);
            return Ok(res);
        }

        [HttpDelete("DeleteCategory")]
        public async Task<ActionResult<BaseCommandResponse>> DeleteCategory([FromBody] CategoryDTO request)
        {
            var res = await _service.DeleteCategory(request);
            return Ok(res);
        }
    }
}
