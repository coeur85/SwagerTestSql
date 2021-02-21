using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PdaHub.Models {
    public class StockReviewModel
    {
        public int BranchCode { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public int OrderNo { get; set; }
        public int DocType { get; set; }

    }
    public class StockOrderModel
    {
        public int Branch { get; set; }
        public int Sites { get; set; }
        public int Orderno { get; set; }
        [DataType(DataType.Date)]
        public DateTime Orderdate { get; set; }
        public string BranchName { get; set; }
        public string SiteName { get; set; }

        public int? Invoiceno { get; set; }
        public DateTime? Invoicedate { get; set; }

        public int DocType { get; set; }
    }
    public class StockOrderItemsModel 
    {
        public int Itemean { get; set; }
        public string Barcode { get; set; }
        public string ItemName { get; set; }
        public int Unit { get; set; }

        public string UnitName { get; set; }

        public decimal actual_qty { get; set; }
        public decimal free_qty { get; set; }


    }
    public class StockInOutDetailModel
    {
        public StockDetailModel StockOrderIn { get; set; }
        public StockDetailModel StockOrderOut { get; set; }
    }
    public class StockDetailModel
    {
        public StockOrderModel StockOrder { get; set; }
        public List<StockOrderItemsModel> StockOrderItems { get; set; } = new List<StockOrderItemsModel>();
    }
    public class XlsFile
    {
        public string FileName { get; set; }
        public ExcelPackage FileData { get; set; } = new ExcelPackage();
    }
}