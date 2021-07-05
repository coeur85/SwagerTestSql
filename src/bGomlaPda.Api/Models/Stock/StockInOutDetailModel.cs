namespace PdaHub.Api.Models.Stock
{
    public record StockInOutDetailModel
    {
        public StockDetailModel StockOrderIn { get; set; }
        public StockDetailModel StockOrderOut { get; set; }
    }
}