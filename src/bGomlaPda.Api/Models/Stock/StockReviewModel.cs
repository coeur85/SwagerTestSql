using System;
using System.ComponentModel.DataAnnotations;

namespace PdaHub.Api.Models.Stock
{
    public record StockReviewModel
    {
        public int BranchCode { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public int OrderNo { get; set; }
        public int DocType { get; set; }

    }
}