using System.Collections.Generic;

namespace PdaHub.Api.Models.Stock
{
    public record StockDetailModel
    {
        public StockOrderModel StockOrder { get; set; }
        public List<StockOrderItemsModel> StockOrderItems { get; set; } = new List<StockOrderItemsModel>();
    }
}