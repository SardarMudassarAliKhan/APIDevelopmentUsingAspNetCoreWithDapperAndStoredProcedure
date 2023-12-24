using APIDevelopmentUsingAspNetCoreWithDapperAndStoredProcedure.Model;
using APIDevelopmentUsingAspNetCoreWithDapperAndStoredProcedure.ServiceContracts;
using Dapper;
using System.Data;

namespace APIDevelopmentUsingAspNetCoreWithDapperAndStoredProcedure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDapperDbConnection _dapperDbConnection;

        public ProductRepository(IDapperDbConnection dapperDbConnection)
        {
            _dapperDbConnection = dapperDbConnection;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            using(IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                return await db.QueryAsync<Product>("StpGetAllProducts", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            using(IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                return await db.QueryFirstOrDefaultAsync<Product>("StpGetProductById", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> CreateProductAsync(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            using(IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                return await db.ExecuteScalarAsync<int>("YourStoredProcedureName_AddProduct",
                    new
                    {
                        product.Name,
                        // Other parameters
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            using(IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                int rowsAffected = await db.ExecuteAsync("YourStoredProcedureName_UpdateProduct",
                    new
                    {
                        product.Id,
                        product.Name,
                        // Other parameters
                    },
                    commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            using(IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                int rowsAffected = await db.ExecuteAsync("YourStoredProcedureName_DeleteProduct",
                    new { Id = id },
                    commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
        }
    }
}
