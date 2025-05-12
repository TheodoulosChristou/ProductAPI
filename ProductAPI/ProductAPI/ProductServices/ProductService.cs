using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductAPI.DTOs;
using ProductAPI.Entities;
using ProductAPI.ProjectDbContext;

namespace ProductAPI.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly ProjectDbContext.ProjectDbContext _dbContext;

        private readonly IMapper _mapper;

        public ProductService(ProjectDbContext.ProjectDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ProductDTO> CreateProduct(ProductDTO productRequest)
        {
            try
            {
                if(productRequest == null || productRequest.ProductName == null || productRequest.ProductPrice == null)
                {
                    throw new Exception("Object is null");
                }
                else
                {
                    var product = _mapper.Map<Product>(productRequest);
                    _dbContext.Product.Add(product);
                    await _dbContext.SaveChangesAsync();

                    var result = _mapper.Map<ProductDTO>(product);
                    return result;
                }
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseCommandResponse> DeleteProduct(ProductDTO productRequest)
        {
            try
            {
                var product = _mapper.Map<Product>(productRequest);

                BaseCommandResponse response = new BaseCommandResponse();
                _dbContext.Remove(product);
                await _dbContext.SaveChangesAsync();

                response.Id = product.ProductId;
                response.Entity = "Product";
                response.Message = "Product has been deleted successfully";

                return response;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductDTO>> GetAllProducts()
        {
            try
            {
                var productList =  _dbContext.Product.Include(p=>p.Category).ToList();
                var result = _mapper.Map<List<ProductDTO>>(productList);
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductDTO> GetProductByProductId(int productId)
        {
            try
            {
                var productResponse = _dbContext.Product.Include(p=>p.Category).FirstOrDefault(p => p.ProductId == productId);
                var result = _mapper.Map<ProductDTO>(productResponse);
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductDTO> UpdateProduct(ProductDTO productRequest)
        {
            try
            {
                var productResponse = _dbContext.Product.AsNoTracking().Include(p=>p.Category).FirstOrDefault(x => x.ProductId == productRequest.ProductId);

                if(productResponse == null)
                {
                    throw new Exception("Product not found in Db");
                } else
                {
                    var product = _mapper.Map<Product>(productRequest);
                    _dbContext.Product.Update(product);
                    await _dbContext.SaveChangesAsync();

                    var result = _mapper.Map<ProductDTO>(product);
                    return result;
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
