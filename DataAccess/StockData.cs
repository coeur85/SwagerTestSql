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

namespace PdaHub.DataAccess
{
    public class StockData
    {
        private readonly iHelper _helper;
        private readonly BasicData _basicData;

        public StockData(iHelper helper, BasicData basicData)
        {
            _helper = helper;
            _basicData = basicData;
        }


        public async Task<StockDetailModel> GetOrderDetailAsync(StockReviewModel model)
        {

            StockDetailModel stockDetailModel = new StockDetailModel();
            using (IDbConnection connection = new SqlConnection(_helper.PdaNubConnection())) 
            {

                stockDetailModel.StockOrder = await connection.QueryFirstOrDefaultAsync<StockOrderModel>("select branch, sites,orderno, orderdate, invoiceno, invoicedate, doctype" +
                    " from stk_order " +
                    "where orderno = @orderno and orderdate = @orderdate and branch = @BranchCode and doctype = @DocType", model);


                stockDetailModel.StockOrderItems =  connection.QueryAsync<StockOrderItemsModel>("select itemean,trim(barcode) as [barcode] ,unit,actual_qty,free_qty from stk_order_items " +
                    "where orderno = @orderno and orderdate = @orderdate and branch = @BranchCode and doctype = @DocType", model).Result.ToList();
            }

          

                stockDetailModel.StockOrder.BranchName = await _basicData.GetBranchNameAsync(stockDetailModel.StockOrder.Branch);
                stockDetailModel.StockOrder.SiteName = await _basicData.GetBranchNameAsync(stockDetailModel.StockOrder.Sites);


                foreach (var item in stockDetailModel.StockOrderItems)
                {
                    item.ItemName = await _basicData.GetBarcodeItemNameAsync(item.Barcode);
                    item.UnitName = await _basicData.GetUnitNameAsync(item.Unit);
                }
           
            


                return stockDetailModel;
        }



        public void SaveToExcel(StockDetailModel model)
        {
            using (var p = new ExcelPackage())
            {
                //A workbook must have at least on cell, so lets add one... 
                var ws = p.Workbook.Worksheets.Add("MySheet");

                ws.View.RightToLeft = true;

                // create sheet header

                ws.Cells[1, 1].Value = "رقم اذن الاستلام";      ws.Cells[1, 2].Value = model.StockOrder.Orderno ;
                ws.Cells[2, 1].Value = "تاريخ الاستلام";        ws.Cells[2, 2].Value = model.StockOrder.Orderdate.ToString("yyyy-MM-dd") ;
                ws.Cells[3, 1].Value = "فرع الاستلام";          ws.Cells[3, 2].Value = model.StockOrder.BranchName;


                ws.Cells[1, 4].Value = "رقم اذن الصرف";      ws.Cells[1, 5].Value = model.StockOrder.Invoiceno?.ToString();
                ws.Cells[2, 4].Value = "تاريخ الصرف";        ws.Cells[2, 5].Value = model.StockOrder.Invoicedate?.ToString("yyyy-MM-dd");
                ws.Cells[3, 4].Value = "فرع الصرف";          ws.Cells[3, 5].Value = model.StockOrder.SiteName;

                HeaderFormate(ws.Cells[1, 1, 3, 1]);
                HeaderFormate(ws.Cells[1, 4, 3, 4]);

                // end of sheet header

                
                // sheet items


                ws.Cells[5, 1].Value = "#";
                ws.Cells[5, 2].Value = "كود الصنف";
                ws.Cells[5, 3].Value = "باركود";
                ws.Cells[5, 4].Value = "اسم الصنف";
                ws.Cells[5, 5].Value = "كود الوحده";
                ws.Cells[5, 6].Value = "الوحده";
                ws.Cells[5, 7].Value = "كميه فعليه";
                ws.Cells[5, 8].Value = "كميه بونص";

                HeaderFormate(ws.Cells[5, 1, 5, 8]);

                int i = 6; int index = 1;
                foreach (var item in model.StockOrderItems)
                {
                    ws.Cells[i, 1].Value = index;
                    ws.Cells[i, 2].Value = item.Itemean ;
                    ws.Cells[i, 3].Value = item.Barcode;
                    ws.Cells[i, 4].Value = item.ItemName ;
                    ws.Cells[i, 5].Value = item.Unit;
                    ws.Cells[i, 6].Value = item.UnitName;
                    ws.Cells[i, 7].Value = item.actual_qty;
                    ws.Cells[i, 8].Value = item.free_qty;
                    index += 1;
                    i += 1;
                }

                ws.Cells[ws.Dimension.Address].AutoFitColumns();



                string filename = _helper.ExcelSaveRoot() + 
                    model.StockOrder.Branch.ToString() + "." +
                    model.StockOrder.DocType.ToString()+ "."+
                    model.StockOrder.Orderdate.ToString("yyyy.MM.dd")+ "."+
                    model.StockOrder.Orderno.ToString() +
                    ".xlsx";



                p.SaveAs(new FileInfo(filename));
            }

            
        }


        void HeaderFormate(ExcelRange range)
        {
           
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.Black);
                range.Style.Font.Color.SetColor(Color.White);
            
        }


    }
}
