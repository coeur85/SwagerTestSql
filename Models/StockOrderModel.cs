using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PdaHub.Models {


    //public class StockOrderModel{
    //    public int Company { get; set; }
    //    public int Sector { get; set; }
    //    public int Region { get; set; }
    //    public int Branch { get; set; }
    //    public int Section { get; set; }
    //    public int Transtype { get; set; }
    //    public int Doctype { get; set; }
    //    public int Goodstype { get; set; }
    //    public int Sites { get; set; }
    //    public int? Sites_section { get; set; }
    //    public int Orderno { get; set; }
    //    public DateTime Orderdate { get; set; }
    //    public int? Userid { get; set; }
    //    public int? Reordertype { get; set; }
    //    public int? Reorderno { get; set; }
    //    public DateTime? Reorderdate { get; set; }
    //    public int? Invoiceno { get; set; }
    //    public DateTime? Invoicedate { get; set; }
    //    public int? Review { get; set; }
    //    public int? Posting { get; set; }
    //    public int? New_entry { get; set; }
    //    public int? Transid { get; set; }
    //    public int? Shipmentno { get; set; }
    //    public object Examinationno { get; set; }
    //    public int? Status { get; set; }
    //    public int? Collection { get; set; }
    //    public object StoreOrder { get; set; }

    //}


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