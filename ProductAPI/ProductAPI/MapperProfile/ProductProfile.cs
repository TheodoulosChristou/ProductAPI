using AutoMapper;
using ProductAPI.DTOs;
using ProductAPI.Entities;

namespace ProductAPI.MapperProfile
{
    public class ProductProfile :Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
