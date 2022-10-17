using Mango.Web.Models;
using Mango.Web.Services.Interfaces;

namespace Mango.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _httpClient;

        public ProductService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> CreateProductAsync<T>(ProductDto product)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                APIType = StaticDetails.APIType.POST,
                Data = product,
                Url = StaticDetails.ProductAPIBaseUrl + "api/product",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                APIType = StaticDetails.APIType.DELETE,
                Url = StaticDetails.ProductAPIBaseUrl + "api/product/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                APIType = StaticDetails.APIType.GET,
                Url = StaticDetails.ProductAPIBaseUrl + "api/product",
                AccessToken = ""
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                APIType = StaticDetails.APIType.GET,
                Url = StaticDetails.ProductAPIBaseUrl + "api/product/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto product)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                APIType = StaticDetails.APIType.PUT,
                Data = product,
                Url = StaticDetails.ProductAPIBaseUrl + "api/product",
                AccessToken = ""
            });
        }
    }
}
