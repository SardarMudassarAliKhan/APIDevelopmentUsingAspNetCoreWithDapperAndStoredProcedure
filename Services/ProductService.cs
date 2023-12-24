using APIDevelopmentUsingAspNetCoreWithDapperAndStoredProcedure.Model;
using APIDevelopmentUsingAspNetCoreWithDapperAndStoredProcedure.ServiceContracts;

namespace APIDevelopmentUsingAspNetCoreWithDapperAndStoredProcedure.Services
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        ILogger<ProductService> _logger;
        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            this._productRepository = productRepository;
            _logger = logger;
        }

        public async Task<int> CreateProductAsync(Product Product)
        {
            try
            {
                return await _productRepository.CreateProductAsync(Product);
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);    
                throw new Exception();
            }
        }

        public Task<bool> DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            try
            {
                return await _productRepository.GetAllProductsAsync();
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                throw new Exception();
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                return await _productRepository.GetProductByIdAsync(id);
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                throw new Exception();
            }
        }

        public async Task<bool> UpdateProductAsync(Product Product)
        {
            try
            {
                return await _productRepository.UpdateProductAsync(Product);
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                throw new Exception();
            }
        }
    }
}
