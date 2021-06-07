using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PdaHub.Broker.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess, IDisposable
    {

        public async Task<T> QueryFirstOrDefaultAsync<T, U>(string connectionString, string sqlQury, U paramters)
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<T>(sqlQury, paramters);
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string connectionString, string sqlQury)
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<T>(sqlQury);
        }
        public async Task<IEnumerable<T>> QueryAsync<T, U>(string connectionString, string sqlQury, U paramters)
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<T>(sqlQury, param: paramters);
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string connectionString, string sqlQury)
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<T>(sqlQury);
        }
        public async Task<T> QuerySingleAsync<T, U>(string connectionString, string sqlQury, U paramters)
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QuerySingleAsync<T>(sqlQury, paramters);
        }
        public async Task<T> QuerySingleAsync<T>(string connectionString, string sqlQury)
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QuerySingleAsync<T>(sqlQury);
        }
        public void Dispose()
        {

        }
    }
}
