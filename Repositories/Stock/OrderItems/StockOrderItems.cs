using PdaHub.Broker.DataAccess;
using PdaHub.Models;
using PdaHub.Repositories.BasicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdaHub.Repositories.Stock.OrderItems
{
    public class StockOrderItems : IStockOrderItems
    {
        private readonly ISqlDataAccess _dataAccess;
        private readonly IBasicDataRepository _basicData;

        public StockOrderItems(ISqlDataAccess dataAccess, IBasicDataRepository basicData)
        {
            _dataAccess = dataAccess;
            _basicData = basicData;
        }


        public async Task<List<StockOrderItemsModel>> GetOrderItems(StockReviewModel model ,string connectionString )
        {
            var output = await _dataAccess.QueryAsync<StockOrderItemsModel, dynamic>(connectionString,
                "select itemean,trim(barcode) as [barcode] ,unit,actual_qty,free_qty from stk_order_items " +
                    "where orderno = @orderno and orderdate = @orderdate and branch = @BranchCode and doctype = @DocType", model);

            if (output is not null)
            {
                foreach (var item in output)
                {
                    item.ItemName = await _basicData.GetBarcodeItemNameAsync(item.Barcode);
                    item.UnitName = await _basicData.GetUnitNameAsync(item.Unit);
                }
            }
            return output.ToList();
        }
    }
}
