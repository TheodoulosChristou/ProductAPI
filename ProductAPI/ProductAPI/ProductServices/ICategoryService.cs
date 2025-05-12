using ProductAPI.DTOs;
using ProductAPI.Entities;

namespace ProductAPI.ProductServices
{
    public interface ICategoryService
    {
        public Task<List<CategoryDTO>> getAllCategories();

        public Task<CategoryDTO> getCategoryByCategoryId(int categoryId);

        public Task<CategoryDTO> CreateCategory(CategoryDTO categoryDTO);

        public Task<CategoryDTO> UpdateCategory(CategoryDTO categoryDTO);

        public Task<BaseCommandResponse> DeleteCategory(CategoryDTO categoryDTO);
    }
}
