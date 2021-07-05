﻿using System;

namespace PdaHub.Models.Item
{
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

}



