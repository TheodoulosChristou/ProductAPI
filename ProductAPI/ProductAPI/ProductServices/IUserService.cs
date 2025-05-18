using ProductAPI.DTOs;
using ProductAPI.Entities;

namespace ProductAPI.ProductServices
{
    public interface IUserService
    {
        public Task<List<UserDTO>> GetAllUsers();

        public Task<UserDTO> GetUserById(int id);

        public Task<UserDTO> CreateUser(UserDTO userDTO);

        public Task<UserDTO> UpdateUser(UserDTO userDTO);

        public Task<BaseCommandResponse> DeleteUser(UserDTO userDTO);
    }
}
