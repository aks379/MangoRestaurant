using Mango.Services.ProductAPI.Payloads;

namespace Mango.Services.ProductAPI.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int productId);
        Task<ProductDto> CreateOrUpdateProduct(ProductDto product);
        Task<bool> DeleteProduct(int productId);
    }
}
