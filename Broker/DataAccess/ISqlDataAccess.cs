using System.Collections.Generic;
using System.Threading.Tasks;

namespace PdaHub.Broker.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> QueryAsync<T, U>(string connectionString, string sqlQury);
        Task<IEnumerable<T>> QueryAsync<T, U>(string connectionString, string sqlQury, U paramters);
        Task<T> QueryFirstOrDefaultAsync<T, U>(string connectionString, string sqlQury, U paramters);
        Task<T> QueryFirstOrDefaultAsync<T>(string connectionString, string sqlQury);
        public Task<T> QuerySingleAsync<T, U>(string connectionString, string sqlQury, U paramters);
        public Task<T> QuerySingleAsync<T>(string connectionString, string sqlQury);
    }
}