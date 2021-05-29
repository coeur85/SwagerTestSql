 using Dapper;
using Microsoft.Data.SqlClient;
using PdaHub.Helpers;
using PdaHub.Models;
using PdaHub.Repositories.BasicData;
using PdaHub.Repositories.Stock.Order;
using PdaHub.Repositories.Stock.OrderItems;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace PdaHub.Repositories.Stock
{
    public class StockRepository : IStockOrderRepository
    {
        private readonly iHelper _helper;
        private readonly IStockOrder _stockOrde;
        private readonly IStockOrderItems _stockOrderItems;

        public StockRepository(iHelper helper, IBasicDataRepository basicData, IStockOrder stockOrde, IStockOrderItems stockOrderItems)
        {
            _helper = helper;
            _basicData = basicData;
            _stockOrde = stockOrde;
            _stockOrderItems = stockOrderItems;
        }


        public async Task<StockDetailModel> GetOrderDetailAsync(StockReviewModel model, string connectionString)
        {
            StockDetailModel output = new StockDetailModel();
            output.StockOrder = await _stockOrde.GetOrder(model, connectionString);
            output.StockOrderItems = await _stockOrderItems.GetOrderItems(model, connectionString);
            return output;

        }
        public async Task<StockInOutDetailModel> GetInOutOrderDetailAsync(StockReviewModel model)
        {

            StockInOutDetailModel stockDetailModel = new StockInOutDetailModel();
            stockDetailModel.StockOrderIn = await GetOrderDetailAsync(model, _helper.PdaHubConnection());
            if (stockDetailModel.StockOrderIn.StockOrder.Invoicedate.HasValue &&
            stockDetailModel.StockOrderIn.StockOrder.Invoiceno.HasValue)
            {
                stockDetailModel.StockOrderOut = await GetOrderDetailAsync(new StockReviewModel
                {
                    BranchCode = stockDetailModel.StockOrderIn.StockOrder.Sites,
                    DocType = 2052,
                    OrderNo = stockDetailModel.StockOrderIn.StockOrder.Invoiceno.Value,
                    OrderDate = stockDetailModel.StockOrderIn.StockOrder.Invoicedate.Value
                }, _helper.BranchLocalDB());
            }
            else
            {
                stockDetailModel.StockOrderOut = null;
            }
            return stockDetailModel;
        }



    }
}
