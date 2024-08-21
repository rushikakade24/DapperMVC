namespace DapperCRUDProduct.DataAccessLayer
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> GetData<T, P>(string spName, P parameters, string connectionId = "dbcs");


        Task SaveData<T>(string spName, T parameters, string connectionId = "dbcs");
    }
}