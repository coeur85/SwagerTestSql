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



        public Task<T> QueryFirstOrDefaultAsync<T, U>(string connectionString, string sqlQury, U paramters)
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return connection.QueryFirstOrDefaultAsync<T>(sqlQury, paramters);
        }
        public Task<T> QueryFirstOrDefaultAsync<T>(string connectionString, string sqlQury)
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return connection.QueryFirstOrDefaultAsync<T>(sqlQury);
        }
        public Task<IEnumerable<T>> QueryAsync<T, U>(string connectionString, string sqlQury, U paramters)
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return connection.QueryAsync<T>(sqlQury, paramters);
        }
        public Task<IEnumerable<T>> QueryAsync<T, U>(string connectionString, string sqlQury)
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return connection.QueryAsync<T>(sqlQury);
        }

        public void Dispose()
        {

        }
    }
}
