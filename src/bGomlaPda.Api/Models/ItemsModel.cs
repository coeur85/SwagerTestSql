using System;
using System.Collections.Generic;

namespace PdaHub.Models
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
    public record PosItemEnitityModel
    {
        public string barcode { get; set; }
        public string a_name { get; set; }
        public string l_name { get; set; }
        public decimal? vatrate { get; set; }
        public decimal? sell_price { get; set; }
        public short? department { get; set; }
        public decimal? f11 { get; set; }
        public decimal? f12 { get; set; }
        public decimal? f13 { get; set; }
        public decimal? f14 { get; set; }
        public decimal? f15 { get; set; }
        public decimal? f16 { get; set; }
        public decimal? f17 { get; set; }
        public decimal? f18 { get; set; }
        public decimal? f21 { get; set; }
        public decimal? f22 { get; set; }
        public decimal? f23 { get; set; }
        public decimal? f24 { get; set; }
        public decimal? f25 { get; set; }
        public decimal? f26 { get; set; }
        public decimal? f27 { get; set; }
        public decimal? f28 { get; set; }
        public short? velocity_code { get; set; }
        public short? return_type { get; set; }
        public int? discountno { get; set; }
        public DateTime? date_from { get; set; }
        public DateTime? date_to { get; set; }
        public short? discounttype { get; set; }
        public decimal? discountvalue { get; set; }
        public decimal? cost_price { get; set; }
        public decimal? usage { get; set; }
        public short? itemtype { get; set; }
        public string itemean { get; set; }
        public short? category { get; set; }
        public DateTime last_modified_time { get; set; }

    }
    public record ItemSectionEnitiyModel
    {

        public short? itemclass { get; set; }
        public short section { get; set; }
        public string a_name { get; set; }
        public string l_name { get; set; }
        public short? usage { get; set; }
        public DateTime? transdate { get; set; }
    }
    public record ItemSpecialEnitiyModel
    {
        public string Barcode { get; set; }
        public string Notes { get; set; }
    }


    public record PromotionItemDetailsModel
    {
        public Header Header { get; set; }
        public Body Body { get; set; }
        public Footer Footer { get; set; }
    }
    public record Header
    {
        public string CategoryName { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
    }
    public record Body
    {
        public decimal Price { get; set; }
        public Descriptionarea DescriptionArea { get; set; }
    }
    public record Descriptionarea
    {
        public bool IsDivided { get; set; }
        public bool DescriptionLineTwoDrawX { get; set; }
        public string DescriptionLineOne { get; set; }
        public string DescriptionLineTwo { get; set; }
    }
    public record Footer
    {
        public string DescriptionRight { get; set; }
        public string DescriptionCenter { get; set; }
        public string PrintDate { get; set; }
        public int PromotionNumber { get; set; }
        public string PromotionExpireDate { get; set; }
        public bool DrawDescriptionCenterAsBarcode { get; set; }
    }

    public record PromotionItemsReponseModel
    {
        public List<PromotionItemDetailsModel> Items { get; set; } = new();
    }

}



