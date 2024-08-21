using DapperCRUDProduct.Models;
using DapperCRUDProduct.DataAccessLayer;
namespace DapperCRUDProduct.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ISqlDataAccess db;

        public ProductRepository(ISqlDataAccess db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(Product product)
        {
            try
            {
                await db.SaveData("sp_products", new { product.Name,product.Description,product.Price,product.DateCreated});
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            try
            {
                await db.SaveData("sp_Update_products", product);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await db.SaveData("sp_Delete_products", new { ID  = id});
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            IEnumerable<Product> result = await db.GetData<Product, dynamic>("sp_Get_ByID_products", new { ID = id });
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Product>> GetallAsync()
        {
            string query = "sp_Get_products";
            return await db.GetData<Product,dynamic>(query, new { });
        }
    }
}
