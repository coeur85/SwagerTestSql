namespace PdaHub.Models.Item
{
    public record PriceArea
    {
        public decimal Price { get; set; }
        public bool ShowtSideBarcode { get; set; }
        public string SideBarcodeValue { get; set; }
    }

}



