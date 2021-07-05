namespace PdaHub.Models.Item
{
    public record Footer
    {
        public string DescriptionRight { get; set; }
        public string DescriptionCenter { get; set; }
        public string PrintDate { get; set; }
        public int PromotionNumber { get; set; }
        public string PromotionExpireDate { get; set; }
        public bool DrawDescriptionCenterAsBarcode { get; set; }
    }

}



