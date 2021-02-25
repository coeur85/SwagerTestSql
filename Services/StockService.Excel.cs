using OfficeOpenXml;
using OfficeOpenXml.Style;
using PdaHub.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PdaHub.Services
{
    public partial class StockService
    {
        
        private async Task<byte[]> SaveToExcelByteArrayAsync(StockInOutDetailModel model)
        {
            using var p = new ExcelPackage();
            var ws = p.Workbook.Worksheets.Add("MySheet");
            ws.View.RightToLeft = true;

            CreateStaticHeader(model, ws);
            CreateDynamicRows(model, ws);
            AddSheetSettings(ws);

            return await p.GetAsByteArrayAsync();


        }

        private static void AddSheetSettings(ExcelWorksheet ws)
        {
            ws.View.FreezePanes(6, 5);
            ws.Protection.IsProtected = true;
            ws.Protection.AllowAutoFilter = true;
            ws.Protection.AllowSort = true;
            ws.Protection.SetPassword("$bgomlait!");

            ws.Cells[ws.Dimension.Address].AutoFitColumns();
        }
        private void CreateDynamicRows(StockInOutDetailModel model, ExcelWorksheet ws)
        {
            int i = 6; int index = 1;

            if (model.StockOrderOut == null)
            {

                foreach (var item in model.StockOrderIn.StockOrderItems)
                {
                    ws.Cells[i, 1].Value = index;
                    ws.Cells[i, 2].Value = item.Itemean;
                    ws.Cells[i, 3].Value = item.Barcode;
                    ws.Cells[i, 4].Value = item.ItemName;
                    ws.Cells[i, 5].Value = item.Unit;
                    ws.Cells[i, 6].Value = item.UnitName;
                    ws.Cells[i, 7].Value = item.actual_qty;
                    ws.Cells[i, 8].Value = item.free_qty;
                    ws.Cells[i, 9].Formula = $"=sum({ws.Cells[i, 7].Address}+ {ws.Cells[i, 8].Value})";
                    index += 1;
                    i += 1;
                }

            }
            else
            {
                ws.Cells[5, 10].Value = "كميه فعليه مصروفه";
                ws.Cells[5, 11].Value = "كميه بونص مصروفه";
                ws.Cells[5, 12].Value = "اجمالي مصروفه";
                HeaderFormate(ws.Cells[5, 10, 5, 12], Color.DarkOrange);

                ws.Cells[5, 13].Value = "فرق كميه فعليه";
                ws.Cells[5, 14].Value = "فرق كميه بونص";
                ws.Cells[5, 15].Value = "فرق اجمالي";
                HeaderFormate(ws.Cells[5, 13, 5, 15], Color.DarkSalmon);

                ws.Cells[5, 10, 5, 15].AutoFilter = true;

                List<string> barcodes = model.StockOrderIn.StockOrderItems.Select(x => x.Barcode).ToList();
                barcodes.AddRange(model.StockOrderOut.StockOrderItems.Select(x => x.Barcode));
                barcodes = barcodes.Distinct().ToList();

                foreach (var barcode in barcodes)
                {

                    var inItem = model.StockOrderIn.StockOrderItems.FirstOrDefault(x => x.Barcode == barcode);
                    var OutItem = model.StockOrderOut.StockOrderItems.FirstOrDefault(x => x.Barcode == barcode);

                    if (inItem == null)
                    {
                        inItem = new StockOrderItemsModel
                        {
                            actual_qty = 0,
                            Barcode = barcode,
                            free_qty = 0,
                            Itemean = OutItem.Itemean,
                            ItemName = OutItem.ItemName,
                            Unit = OutItem.Unit,
                            UnitName = OutItem.UnitName
                        };
                    }

                    if (OutItem == null)
                    {
                        OutItem = new StockOrderItemsModel
                        {
                            actual_qty = 0,
                            Barcode = barcode,
                            free_qty = 0,
                            Itemean = inItem.Itemean,
                            ItemName = inItem.ItemName,
                            Unit = inItem.Unit,
                            UnitName = inItem.UnitName
                        };
                    }


                    ws.Cells[i, 1].Value = index;
                    ws.Cells[i, 2].Value = inItem.Itemean;
                    ws.Cells[i, 3].Value = inItem.Barcode;
                    ws.Cells[i, 4].Value = inItem.ItemName;
                    ws.Cells[i, 5].Value = inItem.Unit;
                    ws.Cells[i, 6].Value = inItem.UnitName;
                    ws.Cells[i, 7].Value = inItem.actual_qty;
                    ws.Cells[i, 8].Value = inItem.free_qty;
                    ws.Cells[i, 9].Formula = $"=sum({ws.Cells[i, 7].Address}+ {ws.Cells[i, 8].Value})";



                    ws.Cells[i, 10].Value = OutItem.actual_qty;
                    ws.Cells[i, 11].Value = OutItem.free_qty;
                    ws.Cells[i, 12].Formula = $"=sum({ws.Cells[i, 10].Address}+ {ws.Cells[i, 11].Value})";


                    ws.Cells[i, 13].Formula = $"=sum({ ws.Cells[i, 7].Address} - { ws.Cells[i, 10].Address})";
                    ws.Cells[i, 14].Formula = $"=sum({ ws.Cells[i, 8].Address} - { ws.Cells[i, 11].Address})";
                    ws.Cells[i, 15].Formula = $"=sum({ ws.Cells[i, 13].Address} + { ws.Cells[i, 14].Address})";



                    index += 1;
                    i += 1;
                }




            }
        }
        private void CreateStaticHeader(StockInOutDetailModel model, ExcelWorksheet ws)
        {
            ws.Cells[1, 1].Value = "رقم اذن الاستلام"; ws.Cells[1, 2].Value = model.StockOrderIn.StockOrder.Orderno;
            ws.Cells[2, 1].Value = "تاريخ الاستلام"; ws.Cells[2, 2].Value = model.StockOrderIn.StockOrder.Orderdate.ToString("yyyy-MM-dd");
            ws.Cells[3, 1].Value = "فرع الاستلام"; ws.Cells[3, 2].Value = model.StockOrderIn.StockOrder.BranchName;


            ws.Cells[1, 4].Value = "رقم اذن الصرف"; ws.Cells[1, 5].Value = model.StockOrderIn.StockOrder.Invoiceno?.ToString();
            ws.Cells[2, 4].Value = "تاريخ الصرف"; ws.Cells[2, 5].Value = model.StockOrderIn.StockOrder.Invoicedate?.ToString("yyyy-MM-dd");
            ws.Cells[3, 4].Value = "فرع الصرف"; ws.Cells[3, 5].Value = model.StockOrderIn.StockOrder.SiteName;

            HeaderFormate(ws.Cells[1, 1, 3, 1], Color.DarkCyan);
            HeaderFormate(ws.Cells[1, 4, 3, 4], Color.DarkOrange);

            // end of sheet header


            // sheet items

            ws.Cells[5, 1].Value = "#";
            ws.Cells[5, 2].Value = "كود الصنف";
            ws.Cells[5, 3].Value = "باركود";
            ws.Cells[5, 4].Value = "اسم الصنف";
            ws.Cells[5, 5].Value = "كود الوحده";
            ws.Cells[5, 6].Value = "الوحده";
            HeaderFormate(ws.Cells[5, 1, 5, 6], Color.Black);
            ws.Cells[5, 1, 5, 6].AutoFilter = true;


            ws.Cells[5, 7].Value = "كميه فعليه مستلمه";
            ws.Cells[5, 8].Value = "كميه بونص مستلمة";
            ws.Cells[5, 9].Value = "اجمالي الاستلام";
            HeaderFormate(ws.Cells[5, 7, 5, 9], Color.DarkCyan);
            ws.Cells[5, 7, 5, 9].AutoFilter = true;
        }
        private string GenrateExcelFullFileName(StockInOutDetailModel model)
        {
            string filename = _helper.ExcelSaveRoot() +
                model.StockOrderIn.StockOrder.Branch.ToString() + "." +
                model.StockOrderIn.StockOrder.DocType.ToString() + "." +
                model.StockOrderIn.StockOrder.Orderdate.ToString("yyyy.MM.dd") + "." +
                model.StockOrderIn.StockOrder.Orderno.ToString();
            if (model.StockOrderOut != null)
            {
                filename += "__";
                filename += (model.StockOrderOut.StockOrder.Branch.ToString() + "." +
              model.StockOrderOut.StockOrder.Orderdate.ToString("yyyy.MM.dd") + "." +
              model.StockOrderOut.StockOrder.Orderno.ToString());

            }
            filename += ".xlsx";
            return filename;
        }
        private void HeaderFormate(ExcelRange range, Color BackGroudcolor)
        {

            range.Style.Font.Bold = true;
            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(BackGroudcolor);
            range.Style.Font.Color.SetColor(Color.White);

        }

       

    }
}
