using AutoMapper;
using ProductAPI.DTOs;
using ProductAPI.Entities;

namespace ProductAPI.ProductServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ProjectDbContext.ProjectDbContext _dbContext;

        private readonly IMapper _mapper;

        public CategoryService(ProjectDbContext.ProjectDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CategoryDTO> CreateCategory(CategoryDTO categoryDTO)
        {
            try
            {
                if(categoryDTO == null || categoryDTO.CategoryName == null)
                {
                    throw new Exception("Category Object is invalid");
                } else
                {
                    var category = _mapper.Map<Category>(categoryDTO);
                    _dbContext.Category.Add(category);
                    await _dbContext.SaveChangesAsync();

                    var result = _mapper.Map<CategoryDTO>(category);
                    return result;
                }
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseCommandResponse> DeleteCategory(CategoryDTO categoryDTO)
        {
           try
           {
                var category = _mapper.Map<Category>(categoryDTO);
                BaseCommandResponse response = new BaseCommandResponse();
                _dbContext.Category.Remove(category);
                await _dbContext.SaveChangesAsync();

                response.Id = category.CategoryId;
                response.Message = "Category has been successfully deleted";
                response.Entity = "Category";

                return response;
           }catch (Exception ex)
           {
                throw ex;
           }
        }

        public async Task<List<CategoryDTO>> getAllCategories()
        {
            try
            {
                var list = _dbContext.Category.ToList();
                var result = _mapper.Map<List<CategoryDTO>>(list);
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoryDTO> getCategoryByCategoryId(int categoryId)
        {
            try
            {
                var category = _dbContext.Category.FirstOrDefault(c=>c.CategoryId == categoryId);
                var result = _mapper.Map<CategoryDTO>(category);
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoryDTO> UpdateCategory(CategoryDTO categoryDTO)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryDTO);
                _dbContext.Category.Update(category);
                await _dbContext.SaveChangesAsync();

                var result = _mapper.Map<CategoryDTO>(category);
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
