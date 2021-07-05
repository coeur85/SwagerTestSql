using PdaHub.Broker.DataAccess;
using PdaHub.Models.Stock;
using PdaHub.Repositories.BasicData;
using System.Threading.Tasks;

namespace PdaHub.Repositories.Stock.Order
{
    public class StockOrder : IStockOrder
    {
        private readonly ISqlDataAccess _dataAccess;
        private readonly IBasicDataRepository _basicData;

        public StockOrder(ISqlDataAccess dataAccess, IBasicDataRepository basicData)
        {
            _dataAccess = dataAccess;
            _basicData = basicData;
        }

        public async Task<StockOrderModel> GetOrder(StockReviewModel model, string connectionString)
        {

            StockOrderModel stockOrder = await _dataAccess.QueryFirstOrDefaultAsync<StockOrderModel, dynamic>
                (connectionString, "select o.branch, o.sites,o.orderno, o.orderdate, o.invoiceno, o.invoicedate, o.doctype" +
              " from stk_order o" +
              "where orderno = @orderno and orderdate = @orderdate and branch = @BranchCode and doctype = @DocType", model);

            if (stockOrder is not null)
            {
                stockOrder.BranchName = await _basicData.GetBranchNameAsync(stockOrder.Branch);
                stockOrder.SiteName = await _basicData.GetBranchNameAsync(stockOrder.Sites);
            }


            return stockOrder;
        }

    }
}
