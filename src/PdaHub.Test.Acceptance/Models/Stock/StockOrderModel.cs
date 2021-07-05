using System;
using System.ComponentModel.DataAnnotations;

namespace PdaHub.Test.Acceptance.Models.Stock
{
    public record StockOrderModel
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
}
