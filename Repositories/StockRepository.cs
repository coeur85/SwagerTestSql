using Microsoft.Data.SqlClient;
using PdaHub.Helpers;
using PdaHub.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;


namespace PdaHub.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly iHelper _helper;
        private readonly IBasicDataRepository _basicData;
        public StockRepository(iHelper helper, IBasicDataRepository basicData)
        {
            _helper = helper;
            _basicData = basicData;
        }


        public async Task<StockDetailModel> GetOrderDetailAsync(StockReviewModel model, string connectionString)
        {
            StockDetailModel stockDetailModel = new StockDetailModel();
            using (IDbConnection connection = new SqlConnection(connectionString))
            {

                stockDetailModel.StockOrder = await connection.QueryFirstOrDefaultAsync<StockOrderModel>("select branch, sites,orderno, orderdate, invoiceno, invoicedate, doctype" +
                    " from stk_order " +
                    "where orderno = @orderno and orderdate = @orderdate and branch = @BranchCode and doctype = @DocType", model);


                stockDetailModel.StockOrderItems = connection.QueryAsync<StockOrderItemsModel>("select itemean,trim(barcode) as [barcode] ,unit,actual_qty,free_qty from stk_order_items " +
                    "where orderno = @orderno and orderdate = @orderdate and branch = @BranchCode and doctype = @DocType", model).Result.ToList();
            }
            if (stockDetailModel.StockOrder != null)
            {
                stockDetailModel.StockOrder.BranchName = await _basicData.GetBranchNameAsync(stockDetailModel.StockOrder.Branch);
                stockDetailModel.StockOrder.SiteName = await _basicData.GetBranchNameAsync(stockDetailModel.StockOrder.Sites);


                foreach (var item in stockDetailModel.StockOrderItems)
                {
                    item.ItemName = await _basicData.GetBarcodeItemNameAsync(item.Barcode);
                    item.UnitName = await _basicData.GetUnitNameAsync(item.Unit);
                }
                return stockDetailModel;

            }
            else
            {
                return null;
            }
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
