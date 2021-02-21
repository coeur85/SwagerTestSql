using PdaHub.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace PdaHub.Repositories
{
    public class BasicDataRepository : IBasicDataRepository
    {
        private readonly iHelper _helper;

        public BasicDataRepository(iHelper helper)
        {
            _helper = helper;
        }
        public async Task<String> GetBarcodeItemNameAsync(string barcode)
        {
            using (IDbConnection connection = new SqlConnection(_helper.BranchLocalDB()))
            {

                var output = await connection.QuerySingleAsync<string>("select i.a_name from sys_item i inner " +
                    "join sys_item_units iu on i.itemean = iu.itemean where iu.barcode = @barcode ", new { barcode });

                return output;
            }
        }
        public async Task<string> GetBranchNameAsync(int branchCode)
        {
            using (IDbConnection connection = new SqlConnection(_helper.BranchLocalDB()))
            {
                var output = await connection.QuerySingleAsync<string>("select a_name from sys_branch where branch" +
                    " = @branchCode", new { branchCode });
                return output;
            }
        }
        public async Task<string> GetUnitNameAsync(int unit)
        {
            using (IDbConnection connection = new SqlConnection(_helper.BranchLocalDB()))
            {
                var output = await connection.QuerySingleAsync<string>("select a_name from sys_unit where unit" +
                    " = @unit", new { unit });
                return output;
            }
        }
    }
}
