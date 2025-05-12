using ProductAPI.DTOs;
using ProductAPI.Entities;

namespace ProductAPI.ProductServices
{
    public interface IProductService
    {
        public Task<List<ProductDTO>> GetAllProducts();

        public Task<ProductDTO> GetProductByProductId(int productId);  

        public Task<ProductDTO> CreateProduct(ProductDTO productRequest);

        public Task<ProductDTO> UpdateProduct(ProductDTO productRequest);

        public Task<BaseCommandResponse> DeleteProduct(ProductDTO productRequest);


    }
}
