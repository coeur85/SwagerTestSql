using Dapper;
using Microsoft.Data.SqlClient;
using PdaHub.Models;
using System.Data;
using System.Threading.Tasks;

namespace PdaHub.Repositories.Stock.Order
{
    public class StockOrder
    {


        public async Task<StockOrderModel> GetOrder(StockReviewModel model, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                StockOrderModel StockOrder = await connection.QueryFirstOrDefaultAsync<StockOrderModel>
                    ("select branch, sites,orderno, orderdate, invoiceno, invoicedate, doctype" +
                  " from stk_order " +
                  "where orderno = @orderno and orderdate = @orderdate and branch = @BranchCode and doctype = @DocType", model);
                return StockOrder;
            }


        }

    }
}
