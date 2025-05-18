using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.DTOs;
using ProductAPI.Entities;
using ProductAPI.ProductServices;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
             _service = service;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<UserDTO>>> GetAllUsers()
        {
            var result = await _service.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("GetUserByUserId")]
        public async Task<ActionResult<UserDTO>> GetUserByUserId(int userId)
        {
            var result = await _service.GetUserById(userId);
            return Ok(result);
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody]UserDTO userDto)
        {
            var result = await _service.CreateUser(userDto);
            return Ok(result);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<UserDTO>> UpdateUser([FromBody] UserDTO userDto)
        {
            var result = await _service.UpdateUser(userDto);
            return Ok(result);
        }

        [HttpDelete("DeleteUser")]
        public async Task<ActionResult<BaseCommandResponse>> DeleteUser([FromBody] UserDTO userDto)
        {
            var result = await _service.DeleteUser(userDto);
            return Ok(result);
        }
    }
}
