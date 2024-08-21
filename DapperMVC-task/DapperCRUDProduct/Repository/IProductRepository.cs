using DapperCRUDProduct.Models;
using DapperCRUDProduct.DataAccessLayer;
namespace DapperCRUDProduct.Repository
{
    public interface IProductRepository
    {
        Task<bool> AddAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
        Task<Product?> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetallAsync();


    }
}