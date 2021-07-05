namespace PdaHub.Api.Models.Stock
{
    public record StockOrderItemsModel
    {
        public int Itemean { get; set; }
        public string Barcode { get; set; }
        public string ItemName { get; set; }
        public int Unit { get; set; }

        public string UnitName { get; set; }

        public decimal actual_qty { get; set; }
        public decimal free_qty { get; set; }


    }
}