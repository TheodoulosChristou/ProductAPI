using AutoMapper;
using ProductAPI.DTOs;
using ProductAPI.Entities;

namespace ProductAPI.ProductServices
{
    public class UserService : IUserService
    {

        private readonly ProjectDbContext.ProjectDbContext _dbContext;

        private readonly IMapper _mapper;

        public UserService(ProjectDbContext.ProjectDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<UserDTO> CreateUser(UserDTO userDTO)
        {
            try
            {
                if(userDTO == null || userDTO.UserName == null || userDTO.DateOfBirth == null)
                {
                    throw new Exception("User validation failed");
                } else
                {
                    var user = _mapper.Map<User>(userDTO);
                    _dbContext.User.Add(user);
                    await _dbContext.SaveChangesAsync();

                    UserDTO res = _mapper.Map<UserDTO>(user);
                    return res;
                }
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseCommandResponse> DeleteUser(UserDTO userDTO)
        {
            try
            {
                if (userDTO == null || userDTO.UserName == null || userDTO.DateOfBirth == null)
                {
                    throw new Exception("User validation failed");
                } else
                {
                    BaseCommandResponse response = new BaseCommandResponse();

                    var user = _mapper.Map<User>(userDTO);
                    _dbContext.User.Remove(user);
                    await _dbContext.SaveChangesAsync();

                    response.Id = user.UserId;
                    response.Entity = "User";
                    response.Message = "User has been deleted successfully";

                    return response;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            try
            {
                var users = _dbContext.User.ToList();
                List<UserDTO> result = _mapper.Map<List<UserDTO>>(users);   
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            try
            {
                var userExists = _dbContext.User.FirstOrDefault(u => u.UserId == id);
                if (userExists == null)
                {
                    throw new Exception("User not found");
                } else
                {
                    UserDTO result = _mapper.Map<UserDTO>(userExists);
                    return result;
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserDTO> UpdateUser(UserDTO userDTO)
        {
            try
            {
                if (userDTO == null || userDTO.UserName == null || userDTO.DateOfBirth == null)
                {
                    throw new Exception("User validation failed");
                }
                else
                {
                    var user = _mapper.Map<User>(userDTO);
                    _dbContext.User.Update(user);
                    await _dbContext.SaveChangesAsync();

                    UserDTO result = _mapper.Map<UserDTO>(user);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
