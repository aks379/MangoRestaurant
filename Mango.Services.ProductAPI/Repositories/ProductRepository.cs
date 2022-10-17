using AutoMapper;
using Mango.Services.ProductAPI.DBContexts;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Payloads;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateOrUpdateProduct(ProductDto product)
        {
            Product prod = _mapper.Map<Product>(product);
            if(prod.ProductId > 0)
            {
                _applicationDbContext.Products.Update(prod);
            }
            else
            {
                _applicationDbContext.Products.Add(prod);
            }

            await _applicationDbContext.SaveChangesAsync();

            return _mapper.Map<ProductDto>(prod);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            bool isDeleted = false;
            try
            {
                var product = await _applicationDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
                if (product != null) 
                {
                    _applicationDbContext.Products.Remove(product);
                    await _applicationDbContext.SaveChangesAsync();
                    isDeleted = true;
                }
            }
            catch { }
            
            return isDeleted;
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            var product = await _applicationDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> products = await _applicationDbContext.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
