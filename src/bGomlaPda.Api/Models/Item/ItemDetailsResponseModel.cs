using System;

namespace PdaHub.Models.Item
{
    public record ItemDetailsResponseModel
    {
        public string Barcode { get; set; }
        public string CategoryName { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public DateTime PrintDate { get; set; } = DateTime.Now;
        public string Notes { get; set; }
        public bool IsSpecial { get; set; } = false;
        public decimal Price { get; set; }

    }

}



