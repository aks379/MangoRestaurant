using Mango.Services.ProductAPI.Payloads;
using Mango.Services.ProductAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ProductResponse> Get()
        {
            ProductResponse productResponse = new ProductResponse();

            try
            {
                productResponse.Result = await _productRepository.GetProducts();
            }
            catch (Exception ex)
            {
                productResponse.IsSuccess = false;
                productResponse.ErrorMessages = new List<string>() { ex.Message };
            }

            return productResponse;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ProductResponse> Get(int id)
        {
            ProductResponse productResponse = new ProductResponse();

            try
            {
                productResponse.Result = await _productRepository.GetProductById(id);
            }
            catch (Exception ex)
            {
                productResponse.IsSuccess = false;
                productResponse.ErrorMessages = new List<string>() { ex.Message };
            }

            return productResponse;
        }

        [HttpPost]
        public async Task<ProductResponse> Post(ProductDto product)
        {
            ProductResponse productResponse = new ProductResponse();

            try
            {
                productResponse.Result = await _productRepository.CreateOrUpdateProduct(product);
            }
            catch (Exception ex)
            {
                productResponse.IsSuccess = false;
                productResponse.ErrorMessages = new List<string>() { ex.Message };
            }

            return productResponse;
        }

        [HttpPut]
        public async Task<ProductResponse> Put(ProductDto product)
        {
            ProductResponse productResponse = new ProductResponse();

            try
            {
                productResponse.Result = await _productRepository.CreateOrUpdateProduct(product);
            }
            catch (Exception ex)
            {
                productResponse.IsSuccess = false;
                productResponse.ErrorMessages = new List<string>() { ex.Message };
            }

            return productResponse;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ProductResponse> Delete(int id)
        {
            ProductResponse productResponse = new ProductResponse();

            try
            {
                productResponse.Result = await _productRepository.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                productResponse.IsSuccess = false;
                productResponse.ErrorMessages = new List<string>() { ex.Message };
            }

            return productResponse;
        }
    }
}
